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
        //Metodo para agregar un Banner del tipo RSS a la base de datos.
        public void Insertar(BannerRSSDTO bRSSDTO)
        {
            
                Connection.con.Open();

                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                    "bannerrss(idbanner, fuenterss) VALUES(:idbanner, :fuenterss)", Connection.con);

                command.Parameters.AddWithValue("@idbanner", bRSSDTO.IdBanner);
                command.Parameters.AddWithValue("@fuenterss", bRSSDTO.FuenteRSS);
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

        ////Metodo para modificar un banner RSS de la base de datos.
        public void Modificar(BannerRSSDTO bRSSDTO)
        {
            Connection.con.Open();
                
            NpgsqlCommand command = new NpgsqlCommand(@"UPDATE Banner " +
                    "SET idbanner = @idbanner, fuenterss = @fuenterss WHERE idbannerRSS = " + bRSSDTO.IdBannerRSS, Connection.con);

                
            command.Parameters.AddWithValue("@idbanner", bRSSDTO.IdBanner);
            command.Parameters.AddWithValue("@fuenterss", bRSSDTO.FuenteRSS);

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
        /// Busca un banner RSS por el id
        /// </summary>
        /// <param name="id">debe ser el de la clase banner padre</param>
        /// <returns></returns>
        public BannerRSSDTO BuscarPorId (int id)
        {
            Connection.con.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT nombre, fuenterss, idbannersimple, idbanner, idrango FROM banner b, bannerrss brss " +
                                                    "WHERE b.idbanner = brss.idbanner and b.idbanner = " + id, Connection.con);

                NpgsqlDataReader dr = cmd.ExecuteReader();

                BannerRSSDTO brssDTO = new BannerRSSDTO
                {
                    IdBanner = dr.GetInt16(3),
                    IdBannerRSS = dr.GetInt16(2),
                    Nombre = dr.GetString(0),
                    FuenteRSS = dr.GetString(1),
                    IdRango = dr.GetInt16(4)
                };

            Connection.con.Close();
            return brssDTO;
        }
    }
}
