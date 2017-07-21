using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using CarteleriaDigital.DTO;


namespace CarteleriaDigital.DAO
{
    class BannerRSSDAO: IBannerRSS
    {
        public BannerRSSDAO()
        {

        }

        public void Insertar(BannerRSSDTO bRSSDTO)
        {
            try
            {
                Connection.con.Open();
                // Create insert command.
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                    "bannerrss(idbanner, fuenterss) VALUES(:idbanner, :fuenterss)", Connection.con);

                command.Parameters.AddWithValue("@idrango", bRSSDTO.IdBanner);
                command.Parameters.AddWithValue("@fuenterss", bRSSDTO.FuenteRSS);

                // Execute SQL command.
                Int32 recordAffected = command.ExecuteNonQuery();
                Connection.con.Close();
                if (Convert.ToBoolean(recordAffected))
                {
                    //Mostrar
                }

                Connection.con.Open();
                command = new NpgsqlCommand("UPDATE banner set tipo='rss' where idbanner=@idbanner", Connection.con);
                command.Parameters.AddWithValue("@idbanner", bRSSDTO.IdBanner);
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                //Mostrar error
            }

            Connection.con.Close();
        }

        public void Modificar(BannerRSSDTO bRSSDTO)
        {
            Connection.con.Open();

            try
            {
                // Create update command.
                NpgsqlCommand command = new NpgsqlCommand(@"UPDATE Banner " +
                    "SET idbanner = @idbanner, fuenterss = @fuenterss WHERE idbannerRSS = " + bRSSDTO.IdBannerRSS, Connection.con);

                // Add paramaters.
                command.Parameters.AddWithValue("@idbanner", bRSSDTO.IdBanner);
                command.Parameters.AddWithValue("@fuenterss", bRSSDTO.FuenteRSS);


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
