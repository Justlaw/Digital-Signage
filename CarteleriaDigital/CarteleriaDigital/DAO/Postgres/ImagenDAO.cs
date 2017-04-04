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

        public void Insertar(ImagenDTO imagenDTO)
        {
            try
            {
                Connection.con.Open();
                // Create insert command.
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                    "rango(idcampaña, duracion, rutaimagen) VALUES(:idcampaña, :duracion, :rutaimagen)",Connection.con);

                command.Parameters.AddWithValue("@idcampaña", imagenDTO.IdCampaña);
                command.Parameters.AddWithValue("@duracion", imagenDTO.Duracion);
                command.Parameters.AddWithValue("@rutaimagen", imagenDTO.RutaImagen);

                // Execute SQL command.
                Int32 recordAffected = command.ExecuteNonQuery();
                if (Convert.ToBoolean(recordAffected))
                {
                    //Mostrar error
                }
            }
            catch (NpgsqlException ex)
            {
                //Mostrar error
            }

            Connection.con.Close();
        }

        public void Modificar(ImagenDTO imagenDTO)
        {
            Connection.con.Close();

            try
            {
                // Create update command.
                NpgsqlCommand command = new NpgsqlCommand(@"UPDATE rango " +
                    "SET idcampaña = @idcampaña, duracion = @duracion, rutaimagen = @rutaimagen WHERE idmagen = " + imagenDTO.IdImagen, Connection.con);

                // Add paramaters.
                command.Parameters.AddWithValue("@idimagen", imagenDTO.IdImagen);
                command.Parameters.AddWithValue("@idcampaña", imagenDTO.IdCampaña);
                command.Parameters.AddWithValue("@duracion", imagenDTO.Duracion);
                command.Parameters.AddWithValue("@rutaimagen", imagenDTO.RutaImagen);

                // Execute SQL command.
                int recordAffected = command.ExecuteNonQuery();
                if (Convert.ToBoolean(recordAffected))
                {
                    //showInformation("Data successfully updated!");
                }
            }
            catch (NpgsqlException ex)
            {
                //showError(ex);
            }

            Connection.con.Close();
        }

        public List<ImagenDTO> ListarPorCampaña(int pIdCampaña)
        {
            List<ImagenDTO> listaImagenes = new List<ImagenDTO>();
            ImagenDTO img = new ImagenDTO();
            Connection.con.Open();

            try
            {
                // Create select command.
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM imagen WHERE imagen.idcampaña = "+ pIdCampaña +" ORDER BY idimagen ASC", Connection.con);

                // Prepare the command.
                command.Prepare();

                // Execute SQL command.
                NpgsqlDataReader dr = command.ExecuteReader();

                // Fill results to music list.
                while (dr.Read())
                {
                    img.IdImagen = dr.GetInt32(0);
                    img.IdCampaña = dr.GetInt32(1);
                    img.RutaImagen = dr.GetString(2);
                    img.Duracion = dr.GetInt16(3);
                    listaImagenes.Add(img);
                }
            }
            catch (NpgsqlException ex)
            {

            }
            Connection.con.Close();

            return listaImagenes;
        }  
    }
}
