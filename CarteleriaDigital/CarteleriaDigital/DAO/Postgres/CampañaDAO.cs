using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using CarteleriaDigital.DTO;

namespace CarteleriaDigital.DAO
{
    class CampañaDAO
    {
        private Conexion iConexion;

        public CampañaDAO(Conexion pConexion)
        {
            this.iConexion = pConexion;

        }

        public void insertar(CampañaDTO camDTO)
        {
            try
            {
                iConexion.openConection();
                // Create insert command.
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                    "campaña(nombre, activo, listaimagenes) VALUES(:nombre, :activo, :listaimagenes)", iConexion.connection);

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

            iConexion.closeConection();
        }

        public void Modificar(CampañaDTO camDTO)
        {
            iConexion.openConection();

            try
            {
                // Create update command.
                NpgsqlCommand command = new NpgsqlCommand(@"UPDATE campaña " +
                    "SET idrango = @idrango, activo = @activo, nombre = @nombre WHERE idcampaña = " + camDTO.IdCampaña, iConexion.connection);

                // Add paramaters.
             // command.Parameters.AddWithValue("@idcampaña", camDTO.IdCampaña);
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

            iConexion.closeConection();
        }

        public CampañaDTO BuscarPorNombre(String pNombre)
        {

            iConexion.openConection();
            CampañaDTO camp = new CampañaDTO();
            try
            {
                // Create select command.
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM " +
                    "campaña where nombre = " + pNombre + "ORDER BY id ASC", iConexion.connection);

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

            iConexion.closeConection();

            return camp;
        }

        public List<CampañaDTO> ListarPorActivo(Boolean pActivo)
        {
            List<CampañaDTO> listaCamp = new List<CampañaDTO>();
            CampañaDTO camp = new CampañaDTO();

            iConexion.openConection();

            try
            {
                // Create select command.
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM " +
                    "campaña where activo = " + pActivo + "ORDER BY id ASC", iConexion.connection);

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

            iConexion.closeConection();

            return listaCamp;

        }
    }
}