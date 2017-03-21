using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using CarteleriaDigital.DTO;

namespace CarteleriaDigital.DAO
{
    class BannerSimpleDAO
    {
        private Conexion iConexion;

        public BannerSimpleDAO(Conexion pConexion)
        {
            this.iConexion = pConexion;

        }

        public void insertar(BannerSimpleDTO bsDTO)
        {
            try
            {
                //VER COMO TRATAMOS ESTA INSERCION EN LA BASE DE DATOS <<<<<<<<<<<<<<<<<<<<<<<<<<< NO ESTA TERMINADO >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                iConexion.openConection();
                // Create insert command.
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                    "banner(nombre, activo, Text) VALUES(:nombre, :activo, :Text)", iConexion.connection);
                command = new NpgsqlCommand("INSERT INTO " +
                    "bannersimple(nombre, activo, Text) VALUES(:nombre, :activo, :Text)", iConexion.connection);

                command.Parameters.AddWithValue("@id", bsDTO.IdBanner);
                command.Parameters.AddWithValue("@idnombre", bsDTO.Nombre);
                command.Parameters.AddWithValue("@activo", bsDTO.Activo);
                command.Parameters.AddWithValue("@Text", bsDTO.Texto);

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
    }
}
