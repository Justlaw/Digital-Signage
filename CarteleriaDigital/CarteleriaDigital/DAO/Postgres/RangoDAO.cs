using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using CarteleriaDigital.DTO;


namespace CarteleriaDigital.DAO
{
    class RangoDAO : IRango
    {

        public RangoDAO()
        {
            
        }


        public void Insertar(RangoDTO ranDTO)
        {
            try
            {
                Connection.con.Open();
                // Create insert command.
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                    "rango(fechainicio, fechafin, horainicio, horafin) VALUES(:fechainicio, :fechafin, :horainicio, :horafin)", Connection.con);

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

            Connection.con.Close();
        }

        public void Modificar(RangoDTO ranDTO)
        {
            Connection.con.Open();

            try
            {
                // Create update command.
                NpgsqlCommand command = new NpgsqlCommand(@"UPDATE rango " +
                    "SET fechainicio = @fechainicio, fechafin = @fechafin, horainicio = @horainicio, horafin = @horafin WHERE idRango = " + ranDTO.IdRango, Connection.con);

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

            Connection.con.Close();
        }
        
        /// <summary>
        /// Este método devuelve los rangos ocupados por banner
        /// </summary>
        /// <returns></returns>
        public List<RangoDTO> RangosBanners()
        {
            List<RangoDTO> listaRango = new List<RangoDTO>();
            RangoDTO rang = new RangoDTO();

            Connection.con.Open();

            try
            {
                // Create select command.
                NpgsqlCommand command = new NpgsqlCommand("SELECT fechainicio, fechafin, horainicio, horafin FROM rango, banner WHERE banner.idrango = rango.idrango and banner.activo = true ORDER BY rango.idrango ASC", Connection.con);

                // Prepare the command.
                command.Prepare();

                // Execute SQL command.
                NpgsqlDataReader dr = command.ExecuteReader();

                // Fill results to music list.
                while (dr.Read())
                {
                    rang.FechaInicio = dr.GetDateTime(0);
                    rang.FechaFin = dr.GetDateTime(1);
                    rang.HoraInicio = dr.GetDateTime(2);
                    rang.HoraFin = dr.GetDateTime(3);
                    listaRango.Add(rang);
                }
            }
            catch (NpgsqlException ex)
            {

            }

            Connection.con.Close();

            return listaRango;
        }

        /// <summary>
        /// Este método devuelve los rangos ocupados por campaña
        /// </summary>
        /// <returns></returns>
        public List<RangoDTO> RangosCampañas()
        {
            List<RangoDTO> listaRango = new List<RangoDTO>();
            RangoDTO rang = new RangoDTO();

            Connection.con.Open();

            try
            {
                // Create select command.
                NpgsqlCommand command = new NpgsqlCommand("SELECT fechainicio, fechafin, horainicio, horafin FROM rango, campaña WHERE campaña.idrango = rango.idrango and campaña.activo = true ORDER BY campaña.idrango ASC", Connection.con);

                // Prepare the command.
                command.Prepare();

                // Execute SQL command.
                NpgsqlDataReader dr = command.ExecuteReader();

                // Fill results to music list.
                while (dr.Read())
                {
                    rang.FechaInicio = dr.GetDateTime(0);
                    rang.FechaFin = dr.GetDateTime(1);
                    rang.HoraInicio = dr.GetDateTime(2);
                    rang.HoraFin = dr.GetDateTime(3);
                    listaRango.Add(rang);
                }
            }
            catch (NpgsqlException ex)
            {

            }

            Connection.con.Close();

            return listaRango;
        }
    }
}
