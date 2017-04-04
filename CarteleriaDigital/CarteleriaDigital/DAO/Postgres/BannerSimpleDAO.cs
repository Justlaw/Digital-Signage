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
        public BannerSimpleDAO()
        {

        }

        public void Insertar(BannerSimpleDTO bsDTO)
        {
            try
            {
                Connection.con.Open();
                // Create insert command.
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                    "bannersimple(idbanner, text) VALUES(:idbanner, :text)", Connection.con);

                command.Parameters.AddWithValue("@id", bsDTO.IdBannerSimple);
                command.Parameters.AddWithValue("@idrango", bsDTO.IdBanner);
                command.Parameters.AddWithValue("@Text", bsDTO.Texto);

                // Execute SQL command.
                Int32 recordAffected = command.ExecuteNonQuery();
                if (Convert.ToBoolean(recordAffected))
                {
                    //Mostrar
                }
            }
            catch (NpgsqlException ex)
            {
                //Mostrar error
            }

            Connection.con.Close();
        }

        public void Modificar(BannerSimpleDTO bsDTO)
        {
            Connection.con.Open();

            try
            {
                // Create update command.
                NpgsqlCommand command = new NpgsqlCommand(@"UPDATE Banner " +
                    "SET idbanner = @idbanner, texto = @texto WHERE idbannersimple = " + bsDTO.IdBannerSimple , Connection.con);

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

            Connection.con.Close();
        }



    }
}
