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
                    "bannerrss(idbanner, fuenterss, texto_respaldo) VALUES(:idbanner, :fuenterss, :texto_respaldo)", Connection.con);

                command.Parameters.AddWithValue("@idbanner", bRSSDTO.IdBanner);
                command.Parameters.AddWithValue("@fuenterss", bRSSDTO.FuenteRSS);
            command.Parameters.AddWithValue("@texto_respaldo", bRSSDTO.TextoDeRespaldo);
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

        //Metodo para modificar un banner RSS de la base de datos.
        public void Modificar(BannerRSSDTO bRSSDTO)
        {
            Connection.con.Open();
                
            NpgsqlCommand command = new NpgsqlCommand("UPDATE banerrss " +
                    "SET fuenterss = @fuenterss and texto_respaldo = @texto_respaldo WHERE idbanner = @idbanner", Connection.con);

            command.Parameters.AddWithValue("@fuenterss", bRSSDTO.FuenteRSS);    
            command.Parameters.AddWithValue("@idbanner", bRSSDTO.IdBanner);
            command.Parameters.AddWithValue("@texto_respaldo",bRSSDTO.TextoDeRespaldo);

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
        public BannerRSSDTO BuscarPorId (int? id)
        {
            Connection.con.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT nombre, fuenterss, idbannerrss, b.idbanner, idrango FROM banner b, bannerrss brss " +
                                                    "WHERE b.idbanner = brss.idbanner and b.idbanner = " + id, Connection.con);

                NpgsqlDataReader dr = cmd.ExecuteReader();
            BannerRSSDTO brssDTO = new BannerRSSDTO();
            if (dr.Read())
            {
                brssDTO.IdBanner = dr.GetInt16(3);
                brssDTO.IdBannerRSS = dr.GetInt16(2);
                brssDTO.Nombre = dr.GetString(0);
                brssDTO.FuenteRSS = dr.GetString(1);
                brssDTO.IdRango = dr.GetInt16(4);
            }
            else { brssDTO = null; }
            Connection.con.Close();
            return brssDTO;
        }

        /// <summary>
        /// Eliminar un registro de la clase bannerrss
        /// </summary>
        /// <param name="idBanner">id de la clae padre</param>
        public void Eliminar(short idBanner)
        {
            Connection.con.Open();

            NpgsqlCommand command = new NpgsqlCommand("DELETE FROM bannerrss WHERE idbanner="+idBanner, Connection.con);

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
