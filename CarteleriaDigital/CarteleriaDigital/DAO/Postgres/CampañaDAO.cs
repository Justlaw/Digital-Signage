using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using CarteleriaDigital.DTO;

namespace CarteleriaDigital.DAO
{
    class CampañaDAO: ICampania
    {
        private Conexion iConexion;

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
                    "campaña(nombre, activo, listaimagenes) VALUES(:nombre, :activo, :listaimagenes)", Connection.con);

                command.Parameters.AddWithValue("@idcampaña", camDTO.Nombre);
                command.Parameters.AddWithValue("@duracion", camDTO.Activo);
                command.Parameters.AddWithValue("@rutaimagen", camDTO.IdRango);

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
                    "campaña.idrango = rango.idrango and " + pFechaIni.Year + "-" + pFechaIni.Month + "-" + pFechaIni.Day + " < rango.fechainicio and " 
                    + pFechaFin.Year + "-" + pFechaFin.Month + "-" + pFechaFin.Day + " > rango.fechafin ORDER BY idcampaña ASC", Connection.con);
                
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
    }
}