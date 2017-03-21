using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using CarteleriaDigital.DTO;

namespace CarteleriaDigital.DAO
{
    class ImagenDAO
    {
        private Conexion iConexion;

        public ImagenDAO(Conexion pConexion)
        {
            this.iConexion = pConexion;

        }

        public void insertar(ImagenDTO imagenDTO)
        {
            try
            {
                iConexion.openConection();
                // Create insert command.
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                    "rango(idcampaña, duracion, rutaimagen) VALUES(:idcampaña, :duracion, :rutaimagen)");

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

            iConexion.closeConection();
        }

        public void Modificar(ImagenDTO imagenDTO)
        {
            iConexion.openConection();

            try
            {
                // Create update command.
                NpgsqlCommand command = new NpgsqlCommand(@"UPDATE rango " +
                    "SET idcampaña = @idcampaña, duracion = @duracion, rutaimagen = @rutaimagen WHERE idmagen = " + imagenDTO.IdImagen, iConexion.connection);

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

            iConexion.closeConection();
        }
    }
}
