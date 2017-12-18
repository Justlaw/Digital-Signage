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

        //Metodo para agregar un Banner a la base de datos.
        public void Insertar(BannerDTO ban)
        {
            Connection.con.Open();
            
                // Se crea el comando para la inserción.
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                    "banner (idrango, nombre, tipo) VALUES (@idrango, @nombre, @tipo)", Connection.con);
                // Se agregan los parametros.
                command.Parameters.AddWithValue("@nombre", ban.Nombre);
                command.Parameters.AddWithValue("@idrango", ban.IdRango);
                command.Parameters.AddWithValue("@tipo", ban.Tipo);
            try
            {
                // Se ejecuta la consulta SQL.
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }

            Connection.con.Close();
        }

        //Metodo para modificar un banner de la base de datos.
        public void Modificar(BannerDTO ban)
        {
            Connection.con.Open();
                     
      
                NpgsqlCommand command = new NpgsqlCommand(@"UPDATE banner " +
                    "SET nombre = @nombre, activo = @activo WHERE idBanner = " + ban.IdBanner , Connection.con);

                
                command.Parameters.AddWithValue("@nombre", ban.Nombre);
                command.Parameters.AddWithValue("@activo", ban.Activo);
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

        //Método que permite buscar un banner mediante su nombre
        public BannerDTO BuscarPorId(short id)
        {

            Connection.con.Open();
            BannerDTO ban = new BannerDTO();
            
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM banner WHERE idbanner = " + id, Connection.con);


            try
            {
                command.Prepare();
                                
                NpgsqlDataReader dr = command.ExecuteReader();

                dr.Read();
                ban.IdBanner = dr.GetInt16(0);
                ban.IdRango = dr.GetInt32(1);
                ban.Activo = dr.GetBoolean(2);
                ban.Nombre = dr.GetString(3);
                ban.Tipo = dr.GetString(4);

           
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }

            Connection.con.Close();

            return ban;
        }

        //Metodo para listar los banner según si el mismo está activo o no
        public List<BannerDTO> ListarPorActivo(Boolean pActivo)
        {
            List<BannerDTO> listaBan = new List<BannerDTO>();
            BannerDTO ban = new BannerDTO();

            Connection.con.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM banner WHERE activo = " + pActivo + "ORDER BY idbanner ASC", Connection.con);

            command.Prepare();

            try
            {
                
                NpgsqlDataReader dr = command.ExecuteReader();

                // Completa la lista con los banners a listar.
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
                throw ex;
            }

            Connection.con.Close();

            return listaBan;

        }

        //Metodo para listar los banner según si el mismo se encuentra entres las fechas establecidas
        public List<BannerDTO> ListarPorFecha(DateTime pFechaIni, DateTime pFechaFin)
        {
            List<BannerDTO> listaBan = new List<BannerDTO>();
            BannerDTO ban = new BannerDTO();

            Connection.con.Open();

            
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM banner, rango WHERE " +
                    "banner.idrango = rango.idrango and " + pFechaIni + " = rango.fechainicio and "
                    + pFechaFin +" = rango.fechafin ORDER BY idbanner ASC", Connection.con);

                
            command.Prepare();
            try
            {
                
                NpgsqlDataReader dr = command.ExecuteReader();

                // completa la lista de banners con los banners a listar encontrados.
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
                throw ex;
            }

            Connection.con.Close();

            return listaBan;

        }

        //Este metodo busca todos los banners y los devuelve dentro de un DataTable
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

            try { 
                da.Fill(dt);
            }
            catch (NpgsqlException ex){
                throw ex;
            }
            
            Connection.con.Close();
            return dt;
        }

        // Este método nos permite obtener el id del último banner creado
        public int ObtenerUltimoId()
        {
            Connection.con.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("select idbanner from banner order by idbanner DESC limit 1", Connection.con);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            int id = 0;
            try { 
                while (dr.Read())
                {
                    id = dr.GetInt32(0);
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }

            Connection.con.Close();
            return id;
        }

        public BannerDTO ObtenerActual(DateTime pFechaActual)
        {
            Connection.con.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT b.idbanner, b.idrango, b.nombre, b.tipo FROM banner b, rango r WHERE " +
                "b.idrango = r.idrango and '" + pFechaActual.Year + "-" + pFechaActual.Month + "-" + pFechaActual.Day + "' >= r.fechainicio and '"
                + pFechaActual.Year + "-" + pFechaActual.Month + "-" + pFechaActual.Day + "' <= r.fechafin and " + pFechaActual.Hour + pFechaActual.Minute +
                " >= (r.horainicio*100)+r.minutoinicio and " + pFechaActual.Hour + pFechaActual.Minute + " < (r.horafin*100)+r.minutofin;", Connection.con);
            NpgsqlDataReader dr;
            try
            {
                dr = cmd.ExecuteReader();
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            

            BannerDTO bDTO = null; 
            if (dr.Read())
            {
                bDTO = new BannerDTO()
                {
                    IdBanner = dr.GetInt16(0),
                    IdRango = dr.GetInt16(1),
                    Nombre = dr.GetString(2),
                    Tipo = dr.GetString(3)
                };
            }

            Connection.con.Close();
            return bDTO;
        }

        public void Eliminar(short idBanner)
        {
            Connection.con.Open();

            NpgsqlCommand command = new NpgsqlCommand("DELETE FROM banner WHERE idbanner=" + idBanner, Connection.con);

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
