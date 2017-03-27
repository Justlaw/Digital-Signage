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
                    "rango(idRango, nombre, activo) VALUES(: idRango, :nombre, :activo)", iConexion.connection);
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

        public void Listar()
        {
            throw new NotImplementedException();
        }

    }
}
