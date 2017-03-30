using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace CarteleriaDigital.DAO
{
    static class Connection
    {
        static string stringConexion = "Server= localhost; Port= 5432; User Id= postgres; Password= 123; Database= DBCarteleria;";
        public static NpgsqlConnection con = new NpgsqlConnection(stringConexion);
    }
}
