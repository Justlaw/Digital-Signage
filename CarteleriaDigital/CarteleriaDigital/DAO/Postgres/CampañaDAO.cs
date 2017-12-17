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
    class CampañaDAO: ICampania
    {
        public CampañaDAO()
        {
        }

        /// <summary>
        /// Crea un nuevo registro de una Campaña en la base de datos.
        /// </summary>
        /// <param name="camDTO"></param>
        public void Insertar(CampañaDTO camDTO)
        {
            
                Connection.con.Open();

                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                    "campaña(idrango, nombre, activo)VALUES (:idrango, :nombre, :activo)", Connection.con);

                command.Parameters.AddWithValue("@idrango", camDTO.IdRango);
                command.Parameters.AddWithValue("@nombre", camDTO.Nombre);
                command.Parameters.AddWithValue("@activo", camDTO.Activo);
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
        /// Reemplaza todos los valores de un objeto CampañaDTO en las respectivas columnas de la campaña en la base de datos 
        /// </summary>
        /// <param name="camDTO"></param>
        public void Modificar(CampañaDTO camDTO)
        {
            Connection.con.Open();

                NpgsqlCommand command = new NpgsqlCommand(@"UPDATE campaña " +
                    "SET idrango = @idrango, activo = @activo, nombre = @nombre WHERE idcampaña = " + camDTO.IdCampaña, Connection.con);

                command.Parameters.AddWithValue("@idrango", camDTO.IdRango);
                command.Parameters.AddWithValue("@activo", camDTO.Activo);
                command.Parameters.AddWithValue("@nombre", camDTO.Nombre);

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
        /// Devuelve un objeto con los datos de una campaña que corresponda con el ID
        /// </summary>
        /// <param name="id_Camp">ID de la campaña</param>
        /// <returns></returns>
        public CampañaDTO BuscarCampañaPorID(int id_Camp)
        {
            CampañaDTO camp_DTO = new CampañaDTO();

            Connection.con.Open();

                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM campaña WHERE + " + id_Camp + " = campaña.idcampaña", Connection.con);

                command.Prepare();

            try
            {
                NpgsqlDataReader dr = command.ExecuteReader();

                dr.Read();

                camp_DTO.IdCampaña = dr.GetInt16(0);
                camp_DTO.IdRango = dr.GetInt16(1);
                camp_DTO.Nombre = dr.GetString(2);
                camp_DTO.Activo = dr.GetBoolean(3);
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }

            Connection.con.Close();

            return camp_DTO;
        }

        /// <summary>
        /// Devuelve un objeto con los datos de una campaña que corresponda con el nombre
        /// </summary>
        /// <param name="pNombre">Nombre de la campaña</param>
        /// <returns></returns>
        public CampañaDTO BuscarPorNombre(String pNombre)
        {

            Connection.con.Open();
            CampañaDTO camp = new CampañaDTO();

                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM campaña WHERE nombre = " + pNombre + "ORDER BY idcampaña ASC", Connection.con);

                command.Prepare();

            try
            {
                NpgsqlDataReader dr = command.ExecuteReader();

                dr.Read();

                camp.IdCampaña = dr.GetInt32(0);
                camp.IdRango = dr.GetInt32(1);
                camp.Activo = dr.GetBoolean(2);
                camp.Nombre = dr.GetString(3);
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }

            Connection.con.Close();

            return camp;
        }

        public List<CampañaDTO> ListarPorActivo(Boolean pActivo)
        {
            List<CampañaDTO> listaCamp = new List<CampañaDTO>();
            CampañaDTO camp = new CampañaDTO();

            Connection.con.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM campaña WHERE activo = " + pActivo + "ORDER BY idcampaña ASC", Connection.con);

            command.Prepare();

            try
            {
                NpgsqlDataReader dr = command.ExecuteReader();

                //Rellenando los datos obtenidos con el DataReader
                while (dr.Read())
                {
                    camp.IdCampaña = dr.GetInt32(0);
                    camp.IdRango = dr.GetInt32(1);
                    camp.Activo = dr.GetBoolean(2);
                    camp.Nombre = dr.GetString(3);
                    listaCamp.Add(camp); 
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }

            Connection.con.Close();

            return listaCamp;
        }

        /// <summary>
        /// Lista todas las campañas para las cuales si fecha de inicio o su fecha de fin esté comprandida entre las dos fechas indicadas.
        /// </summary>
        /// <param name="pFechaIni"></param>
        /// <param name="pFechaFin"></param>
        /// <returns></returns>
        public CampañaDTO BuscarPorFecha(DateTime pFechaActual)
        {
            CampañaDTO camp = new CampañaDTO();

            Connection.con.Open();
                        
            NpgsqlCommand command = new NpgsqlCommand("SELECT campaña.idcampaña, campaña.idrango, campaña.nombre, campaña.activo FROM campaña, rango WHERE "+ 
                "campaña.idrango = rango.idrango and '" + pFechaActual.Year + "-" + pFechaActual.Month + "-" + pFechaActual.Day + "' >= rango.fechainicio and '" 
                + pFechaActual.Year + "-" + pFechaActual.Month + "-" + pFechaActual.Day + "' <= rango.fechafin and " + pFechaActual.Hour + pFechaActual.Minute +
                " >= (rango.horainicio*100)+rango.minutoinicio and " + pFechaActual.Hour + pFechaActual.Minute + " < (rango.horafin*100)+rango.minutofin", Connection.con);
                
            command.Prepare();

            try
            {
                NpgsqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    camp.IdCampaña = dr.GetInt16(0);
                    camp.IdRango = dr.GetInt16(1);
                    camp.Nombre = dr.GetString(2);
                    camp.Activo = dr.GetBoolean(3);
                } else
                {
                    camp = null;
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }

            Connection.con.Close();

            return camp;
        }

        /// <summary>
        /// Devuelve el ID de la última campaña agregada 
        /// </summary>
        /// <returns></returns>
        public int ObtenerUltimoId()
        {

            Connection.con.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Campaña ORDER BY idCampaña DESC LIMIT 1", Connection.con);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            int id = 0;
            while (dr.Read())
            {
                id = dr.GetInt32(0);
            }
            Connection.con.Close();

            return id;
        }

        public DataSet filtrarCampañaPorNombre(String pNombre)
        {
            Connection.con.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM campaña, rango WHERE " +
                    "campaña.idrango = rango.idrango and '"+ pNombre +"' = campaña.nombre ORDER BY idcampaña ASC", Connection.con);

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            Connection.con.Close();
            return ds;
        }

        public DataSet filtrarCampañaPorFecha(DateTime pFechaIni, DateTime pFechaFin)
        {
            Connection.con.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM campaña, rango WHERE " +
                    "campaña.idrango = rango.idrango and '" + pFechaIni.Year + "-" + pFechaIni.Month + "-" + pFechaIni.Day + "' < rango.fechainicio and '"
                    + pFechaFin.Year + "-" + pFechaFin.Month + "-" + pFechaFin.Day + "' > rango.fechafin ORDER BY idcampaña ASC", Connection.con);

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            Connection.con.Close();
            return ds;
        }

        public DataTable SelectCampaña()
        {
            //Creando el DataTable donde almacenaremos la respuessta de la consulta SQL y luego se devolverá
            DataTable dt = new DataTable();
            dt.Columns.Add("IdCampaña");
            dt.Columns.Add("IdRango");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Activo");
            dt.Columns.Add("FechaInicio");
            dt.Columns.Add("FechaFin");
            dt.Columns.Add("hhI");
            dt.Columns.Add("minI");
            dt.Columns.Add("hhF");
            dt.Columns.Add("minF");

            Connection.con.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("select idcampaña, campaña.idrango, nombre, activo, fechainicio, fechafin, horainicio as hhI, minutoinicio as minI, horafin as hhF, minutofin as minF " +
                                                  "from campaña, rango where campaña.idrango = rango.idrango", Connection.con);

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

            da.Fill(dt);

            Connection.con.Close();
            return dt;
        }

    }
}