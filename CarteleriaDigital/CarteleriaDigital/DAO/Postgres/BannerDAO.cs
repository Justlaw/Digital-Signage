using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using CarteleriaDigital.DTO;
using System.Data;

namespace CarteleriaDigital.DAO
{
    class BannerDAO : IBanner
    {

        public BannerDAO()
        {

        }

        public void Insertar(BannerDTO ban)
        {
            Connection.con.Open();
            try
            {
                // Create insert command.
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                    "banner (idrango, nombre, tipo) VALUES (@idrango, @nombre, @tipo)", Connection.con);
                // Add paramaters.
                command.Parameters.AddWithValue("@nombre", ban.Nombre);
                command.Parameters.AddWithValue("@idrango", ban.IdRango);
                command.Parameters.AddWithValue("@tipo", ban.Tipo);

                // Execute SQL command.
                Int32 recordAffected = command.ExecuteNonQuery();
                if (Convert.ToBoolean(recordAffected))
                {
                    //Mostrar error
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }

            Connection.con.Close();
        }

        public void Modificar(BannerDTO ban)
        {
            Connection.con.Open();

            try
            {
                // Create update command.
                NpgsqlCommand command = new NpgsqlCommand(@"UPDATE banner " +
                    "SET nombre = @nombre, activo = @activo WHERE idBanner = " + ban.IdBanner , Connection.con);

                // Add paramaters.
                command.Parameters.AddWithValue("@nombre", ban.Nombre);
                command.Parameters.AddWithValue("@activo", ban.Activo);

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

        public BannerDTO BuscarPorNombre(String pNombre)
        {

            Connection.con.Open();
            BannerDTO ban = new BannerDTO();
            try
            {
                // Create select command.
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM banner WHERE nombre = " + pNombre + "ORDER BY idbanner ASC", Connection.con);

                // Prepare the command.
                command.Prepare();

                // Execute SQL command.
                NpgsqlDataReader dr = command.ExecuteReader();

                ban.IdBanner = dr.GetInt16(0);
                ban.IdRango = dr.GetInt32(1);
                ban.Activo = dr.GetBoolean(2);
                ban.Nombre = dr.GetString(3);
           
            }
            catch (NpgsqlException ex)
            {

            }

            Connection.con.Close();

            return ban;
        }

        public List<BannerDTO> ListarPorActivo(Boolean pActivo)
        {
            List<BannerDTO> listaBan = new List<BannerDTO>();
            BannerDTO ban = new BannerDTO();

            Connection.con.Open();

            try
            {
                // Create select command.
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM banner WHERE activo = " + pActivo + "ORDER BY idbanner ASC", Connection.con);

                // Prepare the command.
                command.Prepare();

                // Execute SQL command.
                NpgsqlDataReader dr = command.ExecuteReader();

                // Fill results to music list.
                while (dr.Read())
                {
                    ban.IdBanner = dr.GetInt32(0);
                    ban.IdRango = dr.GetInt32(1);
                    ban.Activo = dr.GetBoolean(2);
                    ban.Nombre = dr.GetString(3);
                    listaBan.Add(ban);
                }
            }
            catch (NpgsqlException ex)
            {

            }

            Connection.con.Close();

            return listaBan;

        }

        public List<BannerDTO> ListarPorFecha(DateTime pFechaIni, DateTime pFechaFin)
        {
            List<BannerDTO> listaBan = new List<BannerDTO>();
            BannerDTO ban = new BannerDTO();

            Connection.con.Open();

            try
            {
                // Create select command.
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM banner, rango WHERE " +
                    "banner.idrango = rango.idrango and " + pFechaIni + " = rango.fechainicio and "
                    + pFechaFin +" = rango.fechafin ORDER BY idbanner ASC", Connection.con);

                // Prepare the command.
                command.Prepare();

                // Execute SQL command.
                NpgsqlDataReader dr = command.ExecuteReader();

                // Fill results to music list.
                while (dr.Read())
                {
                    ban.IdBanner = dr.GetInt32(0);
                    ban.IdRango = dr.GetInt32(1);
                    ban.Activo = dr.GetBoolean(2);
                    ban.Nombre = dr.GetString(3);
                    listaBan.Add(ban);
                }
            }
            catch (NpgsqlException ex)
            {

            }

            Connection.con.Close();

            return listaBan;

        }

        public DataTable SelectBannersConRango()
        {
            //Creando el DataTable donde almacenaremos la respuessta de la consulta SQL y luego se devolverá
            DataTable dt = new DataTable();
            dt.Columns.Add("IdBanner");
            dt.Columns.Add("IdRango");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Tipo");
            dt.Columns.Add("Activo");
            dt.Columns.Add("FechaInicio");
            dt.Columns.Add("FechaFin");
            dt.Columns.Add("hhI");
            dt.Columns.Add("minI");
            dt.Columns.Add("hhF");
            dt.Columns.Add("minF");

            Connection.con.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("select idbanner, banner.idrango, nombre, tipo, activo, fechainicio, fechafin, horainicio as hhI, minutoinicio as minI, horafin as hhF, minutofin as minF " +
                                                  "from banner, rango where banner.idrango = rango.idrango", Connection.con);

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

            da.Fill(dt);

            Connection.con.Close();
            return dt;
        }


        public int ObtenerUltimoId()
        {
            Connection.con.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("select idbanner from banner order by idbanner DESC limit 1", Connection.con);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            int id = 0;
            while (dr.Read())
            {
               id = dr.GetInt32(0);
            }
            Connection.con.Close();
            return id;
        }
    }
}
