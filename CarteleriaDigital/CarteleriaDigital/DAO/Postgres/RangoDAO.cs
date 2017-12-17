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

        /// <summary>
        /// Crea un nuevo registro de un Rango en la base de datos 
        /// </summary>
        /// <param name="ranDTO"></param>
        public void Insertar(RangoDTO ranDTO)
        {

                Connection.con.Open();

                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                    "rango(fechainicio, fechafin, horainicio, minutoinicio, horafin, minutofin) VALUES(:fechainicio, :fechafin, :horainicio, :minutoinicio, :horafin, :minutofin)", Connection.con);

                command.Parameters.AddWithValue("@fechainicio", ranDTO.FechaInicio);
                command.Parameters.AddWithValue("@fechafin", ranDTO.FechaFin);
                command.Parameters.AddWithValue("@horainicio", ranDTO.HoraInicio);
                command.Parameters.AddWithValue("@minutoinicio", ranDTO.MinutoInicio);
                command.Parameters.AddWithValue("@horafin", ranDTO.HoraFin);
                command.Parameters.AddWithValue("@minutofin", ranDTO.MinutoFin);

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
        /// Recibe un rango y reemplaza todos los valores de este en el original
        /// </summary>
        /// <param name="ranDTO">rango con los nuevos valores</param>
        public void Modificar(RangoDTO ranDTO)
        {
            Connection.con.Open();

                NpgsqlCommand command = new NpgsqlCommand("UPDATE rango " +
                    "SET fechainicio = @fechainicio, fechafin = @fechafin, horainicio = @horainicio, minutoinicio = @minutoinicio, horafin = @horafin, minutofin = @minutofin WHERE idrango = "+ranDTO.IdRango+";", Connection.con);

                command.Parameters.AddWithValue("@fechainicio", ranDTO.FechaInicio.Date);
                command.Parameters.AddWithValue("@fechafin", ranDTO.FechaFin.Date);
                command.Parameters.AddWithValue("@horainicio", ranDTO.HoraInicio);
                command.Parameters.AddWithValue("@minutoinicio", ranDTO.MinutoInicio);
                command.Parameters.AddWithValue("@horafin", ranDTO.HoraFin);
                command.Parameters.AddWithValue("@minutofin", ranDTO.MinutoFin);

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

        public void Eliminar(int idRango)
        {
            Connection.con.Open();

            NpgsqlCommand command = new NpgsqlCommand("DELETE FROM " +
                    "rango WHERE idrango = " + idRango, Connection.con);

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
        /// Devuelve un rango que coincida 
        /// </summary>
        /// <param name="id_Rng"></param>
        /// <returns></returns>
        public RangoDTO BuscarRangoPorID(int id_Rng)
        {
            RangoDAO rng_DAO = new RangoDAO();
            RangoDTO rng_DTO = new RangoDTO();

            Connection.con.Open();

                //creando comando del select
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM rango WHERE + " + id_Rng + " = idRango", Connection.con);

                command.Prepare();
            try
            {
                NpgsqlDataReader dr = command.ExecuteReader();
                dr.Read();

                rng_DTO.IdRango = dr.GetInt16(0);
                rng_DTO.FechaInicio = dr.GetDateTime(1);
                rng_DTO.FechaFin = dr.GetDateTime(2);
                rng_DTO.HoraInicio = dr.GetInt16(3);
                rng_DTO.MinutoInicio = dr.GetInt16(4);
                rng_DTO.HoraFin = dr.GetInt16(5);
                rng_DTO.MinutoFin = dr.GetInt16(6);
            }
            catch (NpgsqlException ex)
            {
                throw ex;
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


                // Create select command.
                NpgsqlCommand command = new NpgsqlCommand("SELECT fechainicio, fechafin, horainicio, minutoinicio, horafin, minutofin FROM rango, banner WHERE banner.idrango = rango.idrango and banner.activo = true ORDER BY rango.idrango ASC", Connection.con);

                // Prepare the command.
                command.Prepare();

            try
            {
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
                throw ex;
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
            
                NpgsqlCommand command = new NpgsqlCommand("SELECT fechainicio, fechafin, horainicio, minutoinicio, horafin, minutofin FROM rango, campaña WHERE campaña.idrango = rango.idrango and campaña.activo = true ORDER BY campaña.idrango ASC", Connection.con);

                command.Prepare();


            try
            {
                NpgsqlDataReader dr = command.ExecuteReader();

                // Leyendo cada registro y agregándolo a la lista de rangos
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
                throw ex;
            }

            Connection.con.Close();

            return listaRango;
        }

        public Boolean RangoDisponibleCampaña (RangoDTO rango)
        {
            Boolean disponible;

            Connection.con.Open();
            
            NpgsqlCommand command = new NpgsqlCommand("SELECT fechainicio, fechafin, horainicio, minutoinicio, horafin, minutofin FROM rango, " +
                "campaña WHERE campaña.idrango = rango.idrango and campaña.activo = true and rango.fechaInicio >="+ rango.FechaInicio + 
                " rango.fechaFin <= "+ rango.FechaFin +
                " ORDER BY campaña.idrango ASC", Connection.con);

            command.Prepare();


            try
            {
                NpgsqlDataReader dr = command.ExecuteReader();
                if (dr.Read()) { 
                    disponible = false;
                } else {
                    disponible = true;
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }

            Connection.con.Close();

            return disponible;
        }

        /// <summary>
        /// Éste método obtiene la úlima inserción en la tabla Rango de la base de datos
        /// </summary>
        public int ObtenerUltimoId()
        {

            Connection.con.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM rango ORDER BY idrango DESC LIMIT 1", Connection.con);

            int id = 0;
            try
            {
                NpgsqlDataReader dr = cmd.ExecuteReader();

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

        public static implicit operator RangoDAO(BannerDAO v)
        {
            throw new NotImplementedException();
        }

        public static void Eliminar()
        {

        }
    }
}
