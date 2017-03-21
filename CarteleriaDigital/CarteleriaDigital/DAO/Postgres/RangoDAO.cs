using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using CarteleriaDigital.DTO;


namespace CarteleriaDigital.DAO
{
    class RangoDAO
    {

        private Conexion iConexion;

        public RangoDAO(Conexion pConexion)
        {
            this.iConexion = pConexion;

        }


        public void insertar(RangoDTO ranDTO)
        {
            try
            {
                iConexion.openConection();
                // Create insert command.
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                    "rango(fechainicio, fechafin, horainicio, horafin) VALUES(:fechainicio, :fechafin, :horainicio, :horafin)", this.iConexion.connection);

                command.Parameters.AddWithValue("@fechainicio", ranDTO.FechaInicio);
                command.Parameters.AddWithValue("@fechafin", ranDTO.FechaFin);
                command.Parameters.AddWithValue("@horainicio", ranDTO.HoraInicio);
                command.Parameters.AddWithValue("@horafin", ranDTO.HoraFin);


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

        public void Modificar(RangoDTO ranDTO)
        {
            iConexion.openConection();

            try
            {
                // Create update command.
                NpgsqlCommand command = new NpgsqlCommand(@"UPDATE rango " +
                    "SET fechainicio = @fechainicio, fechafin = @fechafin, horainicio = @horainicio, horafin = @horafin WHERE idRango = " + ranDTO.IdRango, iConexion.connection);

                // Add paramaters.
                command.Parameters.AddWithValue("@fechainicio", ranDTO.FechaInicio);
                command.Parameters.AddWithValue("@fechafin", ranDTO.FechaFin);
                command.Parameters.AddWithValue("@horainicio", ranDTO.HoraInicio);
                command.Parameters.AddWithValue("@horafin", ranDTO.HoraFin);

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


    }
}
