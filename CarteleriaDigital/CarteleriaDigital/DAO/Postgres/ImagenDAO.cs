using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using CarteleriaDigital.DTO;

namespace CarteleriaDigital.DAO
{
    class ImagenDAO: IImagen
    {

        public ImagenDAO()
        {
                  
        }

        /// <summary>
        /// Crea un nuevo registro en la base de datos de la tabla Imagen
        /// </summary>
        /// <param name="imagenDTO"></param>
        public void Insertar(ImagenDTO imagenDTO)
        {
           
                Connection.con.Open();

                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO imagen (idcampaña, rutaimagen, duracion) VALUES ("+ imagenDTO.IdCampaña+", :rutaimagen, :duracion)", Connection.con);

                command.Parameters.AddWithValue("@rutaimagen", imagenDTO.RutaImagen);
                command.Parameters.AddWithValue("@duracion", imagenDTO.Duracion);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }

            Connection.con.Close();
        }

        /// <summary>
        /// Recibe una nueva imagen y la reemplaza en la original
        /// </summary>
        /// <param name="imagenDTO"></param>
        public void Modificar(ImagenDTO imagenDTO)
        {
            Connection.con.Close();

                NpgsqlCommand command = new NpgsqlCommand(@"UPDATE rango " +
                    "SET idcampaña = @idcampaña, duracion = @duracion, rutaimagen = @rutaimagen WHERE idmagen = " + imagenDTO.IdImagen, Connection.con);

                command.Parameters.AddWithValue("@idimagen", imagenDTO.IdImagen);
                command.Parameters.AddWithValue("@idcampaña", imagenDTO.IdCampaña);
                command.Parameters.AddWithValue("@duracion", imagenDTO.Duracion);
                command.Parameters.AddWithValue("@rutaimagen", imagenDTO.RutaImagen);

            try { 
                command.ExecuteNonQuery();
                }
            catch (NpgsqlException ex)
            {
                throw ex;
            }

            Connection.con.Close();
        }

        /// <summary>
        /// Devuelve una imagen que coincida con el código ingresado.
        /// </summary>
        /// <param name="id_Img"></param>
        /// <returns></returns>
        public ImagenDTO BuscarImagenPorID(int id_Img)
        {
            ImagenDAO img_DAO = new ImagenDAO();
            ImagenDTO img_DTO = new ImagenDTO();

            Connection.con.Open();

                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM rango WHERE + " + id_Img + " = idRango", Connection.con);

                command.Prepare();

            try
            {
                NpgsqlDataReader dr = command.ExecuteReader();

                dr.Read();

                img_DTO.IdImagen = dr.GetInt16(0);
                img_DTO.IdCampaña = dr.GetInt16(1);
                img_DTO.RutaImagen = dr.GetString(2);
                img_DTO.Duracion = dr.GetInt16(3);

            }
            catch (NpgsqlException ex)
            {
                throw ex;     
            }

            Connection.con.Close();
            return img_DTO;
        }

        /// <summary>
        /// Devuelve una lista con las imágenes pertenecientes a una campaña.
        /// </summary>
        /// <param name="pIdCampaña">ID de la campaña que contiene las imágenes</param>
        /// <returns></returns>
        public List<ImagenDTO> ListarPorCampaña(int pIdCampaña)
        {
            List<ImagenDTO> listaImagenes = new List<ImagenDTO>();
            
            Connection.con.Open();

                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM imagen WHERE imagen.idcampaña = "+ pIdCampaña +" ORDER BY idimagen ASC", Connection.con);
                command.Prepare();
            try
            {
                NpgsqlDataReader dr = command.ExecuteReader();

                //Rellenando los datos de la imágen y agregándolos a la lista
                while (dr.Read())
                {
                    ImagenDTO img = new ImagenDTO();
                    img.IdImagen = dr.GetInt32(0);
                    img.IdCampaña = dr.GetInt32(1);
                    img.RutaImagen = dr.GetString(2);
                    img.Duracion = dr.GetInt16(3);
                    listaImagenes.Add(img);
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            Connection.con.Close();

            return listaImagenes;
        }

        /// <summary>
        /// Elimina una imagen por su ID
        /// </summary>
        /// <param name="idImagen"></param>
        public void Eliminar(int idImagen)
        {
            Connection.con.Open();

                
                // Create update command.
                NpgsqlCommand command = new NpgsqlCommand("DELETE FROM " +
                        "imagen WHERE idimagen = :idimagen", Connection.con);

                command.Parameters.AddWithValue("@idimagen", idImagen);

                command.Parameters[0].Value = idImagen;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (NpgsqlException ex)
                {
                    throw ex;
                }

                Connection.con.Close();
        }
    }
}
