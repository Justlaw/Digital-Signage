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

        public BannerDAO()
        {

        }

        public void Insertar(BannerDTO ban)
        {
            try
            {
                Connection.con.Open();
                
                // Create insert command.
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                    "banner(idRango, nombre, activo) VALUES(: idRango, :nombre, :activo)", Connection.con);
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

            Connection.con.Close();
        }

        public void Modificar(BannerDTO ban)
        {
            Connection.con.Open();

            try
            {
                // Create update command.
                NpgsqlCommand command = new NpgsqlCommand(@"UPDATE Banner " +
                    "SET idRango = @idRango, Nombre = @Nombre, Activo = @Activo WHERE idBanner = " + ban.IdBanner , Connection.con);

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

            Connection.con.Close();
        }

        public void Listar()
        {
            throw new NotImplementedException();
        }

    }
}
