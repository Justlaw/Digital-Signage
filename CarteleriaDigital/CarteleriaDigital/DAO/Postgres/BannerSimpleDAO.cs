using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using CarteleriaDigital.DTO;

namespace CarteleriaDigital.DAO
{
    class BannerSimpleDAO
    {
        private Conexion iConexion;

        public BannerSimpleDAO(Conexion pConexion)
        {
            this.iConexion = pConexion;

        }

        public void insertar(BannerSimpleDTO bsDTO)
        {
            try
            {
                //VER COMO TRATAMOS ESTA INSERCION EN LA BASE DE DATOS <<<<<<<<<<<<<<<<<<<<<<<<<<< NO ESTA TERMINADO >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                iConexion.openConection();
                // Create insert command.
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                    "banner(idrango, nombre, activo) VALUES(:idrango, :nombre, :activo)", iConexion.connection);
                command = new NpgsqlCommand("INSERT INTO " +
                    "bannersimple(idbanner, text) VALUES(:idbanner, :text)", iConexion.connection);

                command.Parameters.AddWithValue("@id", bsDTO.IdBanner);
                command.Parameters.AddWithValue("@idrango", bsDTO.IdRango);
                command.Parameters.AddWithValue("@nombre", bsDTO.Nombre);
                command.Parameters.AddWithValue("@activo", bsDTO.Activo);
                command.Parameters.AddWithValue("@Text", bsDTO.Texto);

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

        public void Modificar(BannerSimpleDTO bsDTO)
        {
            iConexion.openConection();

            try
            {
                // Create update command.
                NpgsqlCommand command = new NpgsqlCommand(@"UPDATE Banner " +
                    "SET idbanner = @idbanner, texto = @texto WHERE idbannersimple = " + bsDTO.IdBannerSimple , iConexion.connection);

                // Add paramaters.
                command.Parameters.AddWithValue("@idbanner", bsDTO.IdBanner);
                command.Parameters.AddWithValue("@texto", bsDTO.Texto);
                

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
