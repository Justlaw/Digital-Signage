using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace CarteleriaDigital.DAO
{
    class Conexion
    {

        private string stringConexion = "Server= locarhost; Port= 5432; User Id= postgres; Password= 123; Database= DBCarteleria;";

        public NpgsqlConnection connection = new NpgsqlConnection();

        public void ConectaPostgreSQL()
        {
            connection = new NpgsqlConnection(stringConexion);
        }

        public void openConection()
        {
            try
            {

                connection.Open();
            }
            catch (NpgsqlException ex)
            {
                
            }
        }

        public void closeConection()
        {
            try
            {
                connection.Close();
            }
            catch (NpgsqlException ex)
            {
                
            }
        }
    }
}
