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
                    "rango(fechainicio, fechafin, horainicio, minutoinicio, horafin, minutofin) VALUES(:fechainicio, :fechafin, :horainicio, :minutoinicio, :horafin, :minutofin)", Connection.con);

                command.Parameters.AddWithValue("@fechainicio", ranDTO.FechaInicio);
                command.Parameters.AddWithValue("@fechafin", ranDTO.FechaFin);
                command.Parameters.AddWithValue("@horainicio", ranDTO.HoraInicio);
                command.Parameters.AddWithValue("@minutoinicio", ranDTO.MinutoInicio);
                command.Parameters.AddWithValue("@horafin", ranDTO.HoraFin);
                command.Parameters.AddWithValue("@minutofin", ranDTO.MinutoFin);



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
                    "SET fechainicio = @fechainicio, fechafin = @fechafin, horainicio = @horainicio, minutoinicio = @minutoinicio, horafin = @horafin, minutofin = @minutofin WHERE idRango = " + ranDTO.IdRango, Connection.con);

                // Add paramaters.
                command.Parameters.AddWithValue("@fechainicio", ranDTO.FechaInicio);
                command.Parameters.AddWithValue("@fechafin", ranDTO.FechaFin);
                command.Parameters.AddWithValue("@horainicio", ranDTO.HoraInicio);
                command.Parameters.AddWithValue("@minutoinicio", ranDTO.MinutoInicio);
                command.Parameters.AddWithValue("@horafin", ranDTO.HoraFin);
                command.Parameters.AddWithValue("@minutofin", ranDTO.MinutoFin);

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

        public RangoDTO BuscarRangoPorID(int id_Rng)
        {
            RangoDAO rng_DAO = new RangoDAO();
            RangoDTO rng_DTO = new RangoDTO();

            Connection.con.Open();

            try {
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM rango WHERE + " + id_Rng + " = idRango", Connection.con);

                command.Prepare();

                NpgsqlDataReader dr = command.ExecuteReader();

                rng_DTO.FechaInicio = dr.GetDateTime(0);
                rng_DTO.FechaFin = dr.GetDateTime(1);
                rng_DTO.HoraInicio = dr.GetInt16(2);
                rng_DTO.MinutoInicio = dr.GetInt16(3);
                rng_DTO.HoraFin = dr.GetInt16(4);
                rng_DTO.MinutoFin = dr.GetInt16(5);

                
            }
            catch (NpgsqlException ex)
            {

            }

            Connection.con.Close();

            return rng_DTO;
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
                NpgsqlCommand command = new NpgsqlCommand("SELECT fechainicio, fechafin, horainicio, minutoinicio, horafin, minutofin FROM rango, banner WHERE banner.idrango = rango.idrango and banner.activo = true ORDER BY rango.idrango ASC", Connection.con);

                // Prepare the command.
                command.Prepare();

                // Execute SQL command.
                NpgsqlDataReader dr = command.ExecuteReader();

                // Fill results to music list.
                while (dr.Read())
                {
                    rang.FechaInicio = dr.GetDateTime(0);
                    rang.FechaFin = dr.GetDateTime(1);
                    rang.HoraInicio = dr.GetInt16(2);
                    rang.MinutoInicio = dr.GetInt16(3);
                    rang.HoraFin = dr.GetInt16(4);
                    rang.MinutoFin = dr.GetInt16(5);
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
            Connection.con.Open();

            List<RangoDTO> listaRango = new List<RangoDTO>();
            RangoDTO rang = new RangoDTO();
            

            try
            {
                // Create select command.
                NpgsqlCommand command = new NpgsqlCommand("SELECT fechainicio, fechafin, horainicio, minutoinicio, horafin, minutofin FROM rango, campaña WHERE campaña.idrango = rango.idrango and campaña.activo = true ORDER BY campaña.idrango ASC", Connection.con);

                // Prepare the command.
                command.Prepare();

                // Execute SQL command.
                NpgsqlDataReader dr = command.ExecuteReader();

                // Fill results to music list.
                while (dr.Read())
                {
                    rang.FechaInicio = dr.GetDateTime(0);
                    rang.FechaFin = dr.GetDateTime(1);
                    rang.HoraInicio = dr.GetInt16(2);
                    rang.MinutoInicio = dr.GetInt16(3);
                    rang.HoraFin = dr.GetInt16(4);
                    rang.MinutoFin = dr.GetInt16(5);
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
        /// Éste método obtiene la úlima inserción en la tabla Rango de la base de datos
        /// </summary>
        public int ObtenerUltimoId()
        {

            Connection.con.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM rango ORDER BY idrango DESC LIMIT 1", Connection.con);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            int id = 0;
            while (dr.Read())
            {
                id = dr.GetInt32(0);
            }
            Connection.con.Close();

            return id;
        }

        public bool RangoDisponible(RangoDTO rng)
        {
            bool result = true;
            RangoDAO rng_DAO = new RangoDAO();
            foreach (RangoDTO rango in rng_DAO.RangosCampañas())
            {
                if (rng.FechaInicio >= rango.FechaInicio && rng.FechaInicio <= rango.FechaFin)
                {
                    if (rng.HoraInicio >= rango.HoraInicio && rng.HoraInicio <= rango.HoraFin)
                    {
                        result = false;
                        return result;
                    }
                }
            }
            return result;

        }
    }
}
