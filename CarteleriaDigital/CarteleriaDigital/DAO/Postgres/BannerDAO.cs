using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using CarteleriaDigital.DTO;

namespace CarteleriaDigital.DAO
{
    class BannerDAO : IBanner
    {

        private Conexion iConexion;

        public BannerDAO(Conexion pConexion)
        {
            this.iConexion = pConexion;

        }

        public void Insertar(BannerDTO ban)
        {
            try
            {
                iConexion.openConection();
                
                // Create insert command.
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                    "banner(idRango, nombre, activo) VALUES(: idRango, :nombre, :activo)", iConexion.connection);
                // Add paramaters.
                command.Parameters.AddWithValue("@nombre", ban.Nombre);
                command.Parameters.AddWithValue("@Activo", ban.Activo);
                command.Parameters.AddWithValue("@idRango", ban.IdRango);

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

        public void Modificar(BannerDTO ban)
        {
            iConexion.openConection();

            try
            {
                // Create update command.
                NpgsqlCommand command = new NpgsqlCommand(@"UPDATE Banner " +
                    "SET idRango = @idRango, Nombre = @Nombre, Activo = @Activo WHERE idBanner = " + ban.IdBanner , iConexion.connection);

                // Add paramaters.
                command.Parameters.AddWithValue("@Nombre", ban.Nombre);
                command.Parameters.AddWithValue("@Activo", ban.Activo);
                command.Parameters.AddWithValue("@idRango", ban.Activo);

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

        public BannerDTO BuscarPorNombre(String pNombre)
        {

            iConexion.openConection();
            BannerDTO ban = new BannerDTO();
            try
            {
                // Create select command.
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM banner WHERE nombre = " + pNombre + "ORDER BY idbanner ASC", iConexion.connection);

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

            iConexion.closeConection();

            return ban;
        }

        public List<BannerDTO> ListarPorActivo(Boolean pActivo)
        {
            List<BannerDTO> listaBan = new List<BannerDTO>();
            BannerDTO ban = new BannerDTO();

            iConexion.openConection();

            try
            {
                // Create select command.
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM banner WHERE activo = " + pActivo + "ORDER BY idbanner ASC", iConexion.connection);

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

            iConexion.closeConection();

            return listaBan;

        }

        public List<BannerDTO> ListarPorFecha(DateTime pFechaIni, DateTime pFechaFin)
        {
            List<BannerDTO> listaBan = new List<BannerDTO>();
            BannerDTO ban = new BannerDTO();

            iConexion.openConection();

            try
            {
                // Create select command.
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM banner, rango WHERE" +
                    "banner.idrango = rango.idrango and pFechaIni = rango.fechainicio and"
                    + "pFechaFin = rango.fechafin ORDER BY idbanner ASC", iConexion.connection);

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

            iConexion.closeConection();

            return listaBan;

        }

        public void Listar()
        {
            throw new NotImplementedException();
        }
    }
}
