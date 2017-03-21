using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace CarteleriaDigital.DAO
{
    class BannerDAO
    {
        public void insertar(Conexion con, Banner ban)
        {
            try
            {
                con.openConection();
                
                // Create insert command.
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                    "rango(nombre, activo) VALUES(:nombre, :activo)", con.connection);
                // Add paramaters.
                command.Parameters.Add(new NpgsqlParameter("nombre",
                    NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters.Add(new NpgsqlParameter("activo",
                    NpgsqlTypes.NpgsqlDbType.Boolean));
                
                // Prepare the command.
                command.Prepare();

                // Add value to the paramater.
                command.Parameters[0].Value = ban.Nombre;
                command.Parameters[1].Value = ban.Activo;
                
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

            con.closeConection();
        }
    }
}
