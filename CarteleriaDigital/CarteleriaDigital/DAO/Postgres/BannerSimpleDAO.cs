using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using CarteleriaDigital.DTO;

namespace CarteleriaDigital.DAO
{
    class BannerSimpleDAO: IBannerSimple
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
                    "bannersimple(idbanner, texto) VALUES(:idbanner, :texto)", Connection.con);

                command.Parameters.AddWithValue("@idbanner", bsDTO.IdBanner);
                command.Parameters.AddWithValue("@texto", bsDTO.Texto);

                // Execute SQL command.
                Int32 recordAffected = command.ExecuteNonQuery();
                Connection.con.Close();
                if (Convert.ToBoolean(recordAffected))
                {
                    //Mostrar
                }
                Connection.con.Open();
                command = new NpgsqlCommand("UPDATE banner set tipo='simple' where idbanner=@idbanner",Connection.con);
                command.Parameters.AddWithValue("@idbanner",bsDTO.IdBanner);
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                
            }

            Connection.con.Close();
        }

        public void Modificar(BannerSimpleDTO bsDTO)
        {
            Connection.con.Open();

            try
            {
                // Create update command.
                NpgsqlCommand command = new NpgsqlCommand("UPDATE bannersimple " +
                    "SET texto = @texto WHERE idbannersimple = " + bsDTO.IdBannerSimple, Connection.con);

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

        /// <summary>
        /// Busca el banner simple por el id
        /// </summary>
        /// <param name="id">El id debe ser el perteneciente a la clase padre Banner</param>
        /// <returns></returns>
        public BannerSimpleDTO BuscarPorId(int id)
        {
            Connection.con.Open();

                String query = "select b.nombre, bs.texto, bs.idbannersimple, b.idbanner, b.idrango from banner b, bannersimple bs where b.idbanner = "+id+" and b.idbanner = bs.idbanner";
                NpgsqlCommand cmd = new NpgsqlCommand(query, Connection.con);
            //cmd.Parameters.AddWithValue("@id", id);
            NpgsqlDataReader dr = cmd.ExecuteReader();

                dr.Read();
                BannerSimpleDTO bsDTO = new BannerSimpleDTO();
                bsDTO.Nombre = dr.GetString(0);
                bsDTO.Texto = dr.GetString(1);
                bsDTO.IdBannerSimple = dr.GetInt32(2);
                bsDTO.IdBanner = dr.GetInt32(3);
                bsDTO.IdRango = dr.GetInt32(4);

            Connection.con.Close();
            return bsDTO;
        }

    }
}
