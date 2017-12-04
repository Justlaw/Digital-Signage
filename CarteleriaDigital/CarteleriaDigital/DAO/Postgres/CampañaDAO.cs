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

        public void Insertar(CampañaDTO camDTO)
        {
            try
            {
                Connection.con.Open();
                // Create insert command.
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                    "campaña(idrango, nombre, activo)VALUES (:idrango, :nombre, :activo)", Connection.con);

                command.Parameters.AddWithValue("@idrango", camDTO.IdRango);
                command.Parameters.AddWithValue("@nombre", camDTO.Nombre);
                command.Parameters.AddWithValue("@activo", camDTO.Activo);  

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

            Connection.con.Close();
        }

        public void Modificar(CampañaDTO camDTO)
        {
            Connection.con.Open();

            try
            {
                // Create update command.
                NpgsqlCommand command = new NpgsqlCommand(@"UPDATE campaña " +
                    "SET idrango = @idrango, activo = @activo, nombre = @nombre WHERE idcampaña = " + camDTO.IdCampaña, Connection.con);

                // Add paramaters.
                command.Parameters.AddWithValue("@idrango", camDTO.IdRango);
                command.Parameters.AddWithValue("@activo", camDTO.Activo);
                command.Parameters.AddWithValue("@nombre", camDTO.Nombre);

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

        public CampañaDTO BuscarCampañaPorID(int id_Camp)
        {
            CampañaDTO camp_DTO = new CampañaDTO();

            Connection.con.Open();

            try
            {
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM rango WHERE + " + id_Camp + " = idRango", Connection.con);

                command.Prepare();

                NpgsqlDataReader dr = command.ExecuteReader();

                camp_DTO.IdCampaña = dr.GetInt16(0);
                camp_DTO.IdRango = dr.GetInt16(1);
                camp_DTO.Nombre = dr.GetString(2);
                camp_DTO.Activo = dr.GetBoolean(3);


            }
            catch (NpgsqlException ex)
            {

            }

            return camp_DTO;
        }

        public CampañaDTO BuscarPorNombre(String pNombre)
        {

            Connection.con.Open();
            CampañaDTO camp = new CampañaDTO();
            try
            {
                // Create select command.
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM campaña WHERE nombre = " + pNombre + "ORDER BY idcampaña ASC", Connection.con);

                // Prepare the command.
                command.Prepare();

                // Execute SQL command.
                NpgsqlDataReader dr = command.ExecuteReader();

                
                camp.IdCampaña = dr.GetInt32(0);
                camp.IdRango = dr.GetInt32(1);
                camp.Activo = dr.GetBoolean(2);
                camp.Nombre = dr.GetString(3);
            }
            catch (NpgsqlException ex)
            {

            }

            Connection.con.Close();

            return camp;
        }

        public List<CampañaDTO> ListarPorActivo(Boolean pActivo)
        {
            List<CampañaDTO> listaCamp = new List<CampañaDTO>();
            CampañaDTO camp = new CampañaDTO();

            Connection.con.Open();

            try
            {
                // Create select command.
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM campaña WHERE activo = " + pActivo + "ORDER BY idcampaña ASC", Connection.con);

                // Prepare the command.
                command.Prepare();

                // Execute SQL command.
                NpgsqlDataReader dr = command.ExecuteReader();

                // Fill results to music list.
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

            }

            Connection.con.Close();

            return listaCamp;

        }

        public List<CampañaDTO> ListarPorFecha(DateTime pFechaIni, DateTime pFechaFin)
        {
            List<CampañaDTO> listaCamp = new List<CampañaDTO>();
            CampañaDTO camp = new CampañaDTO();

            Connection.con.Open();

            try
            {
                // Create select command.
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM campaña, rango WHERE "+ 
                    "campaña.idrango = rango.idrango and '" + pFechaIni.Year + "-" + pFechaIni.Month + "-" + pFechaIni.Day + "' < rango.fechainicio and '" 
                    + pFechaFin.Year + "-" + pFechaFin.Month + "-" + pFechaFin.Day + "' > rango.fechafin ORDER BY idcampaña ASC", Connection.con);
                
                // Prepare the command.
                command.Prepare();

                // Execute SQL command.
                NpgsqlDataReader dr = command.ExecuteReader();

                // Fill results to music list.
                while (dr.Read())
                {
                    camp.IdCampaña = dr.GetInt32(0);
                    camp.IdRango = dr.GetInt32(1);
                    camp.Nombre = dr.GetString(2);
                    camp.Activo = dr.GetBoolean(3);
                    listaCamp.Add(camp);
                }
            }
            catch (NpgsqlException ex)
            {

            }

            Connection.con.Close();

            return listaCamp;
        }

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