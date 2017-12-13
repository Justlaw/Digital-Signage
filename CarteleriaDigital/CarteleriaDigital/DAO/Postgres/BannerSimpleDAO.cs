﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using CarteleriaDigital.DTO;

namespace CarteleriaDigital.DAO
{
    class BannerSimpleDAO: IBannerSimple
    {
        public BannerSimpleDAO()
        {

        }

        //Metodo para agregar un Banner del tipo simple a la base de datos.
        public void Insertar(BannerSimpleDTO bsDTO)
        {
            
            Connection.con.Open();
            // Create insert command.
            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO " +
                "bannersimple(idbanner, texto) VALUES(:idbanner, :texto)", Connection.con);

            command.Parameters.AddWithValue("@idbanner", bsDTO.IdBanner);
            command.Parameters.AddWithValue("@texto", bsDTO.Texto);

            try
            {   // Execute SQL command.
                command.ExecuteNonQuery();
                
            }
            catch (NpgsqlException e)
            {
                throw e;
            }

            Connection.con.Close();
        }
        
        //Metodo para modificar un banner de la base de datos.
        public void Modificar(BannerSimpleDTO bsDTO)
        {
            Connection.con.Open();

            NpgsqlCommand command = new NpgsqlCommand("UPDATE bannersimple " +
                "SET texto = @texto WHERE idbannersimple = @idbannersimple", Connection.con);

            command.Parameters.AddWithValue("@idbannersimple", bsDTO.IdBannerSimple);
            command.Parameters.AddWithValue("@texto", bsDTO.Texto);

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
        /// Busca el banner simple por el id
        /// </summary>
        /// <param name="id">El id debe ser el perteneciente a la clase padre Banner</param>
        /// <returns></returns>
        public BannerSimpleDTO BuscarPorId(int id)
        {
            Connection.con.Open();

            String query = "select b.nombre, bs.texto, bs.idbannersimple, b.idbanner, b.idrango from banner b, bannersimple bs where b.idbanner = "+id+" and b.idbanner = bs.idbanner";
            NpgsqlCommand cmd = new NpgsqlCommand(query, Connection.con);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            dr.Read();
            BannerSimpleDTO bsDTO = new BannerSimpleDTO();
            bsDTO.Nombre = dr.GetString(0);
            bsDTO.Texto = dr.GetString(1);
            bsDTO.IdBannerSimple = dr.GetInt32(2);
            bsDTO.IdBanner = dr.GetInt32(3);
            bsDTO.IdRango = dr.GetInt32(4);

            Connection.con.Close();
            return bsDTO;
        }
    }
}
