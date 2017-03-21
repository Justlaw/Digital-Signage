using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital.DTO
{
    class BannerDTO
    {
        #region Atributos
        //Atributos con sus getters y setters
        private int? idBanner;
        private int? idRango;
        private bool activo;
        private string nombre;
        #endregion

        #region Constructores
        //Constructor
        public BannerDTO() { }
        #endregion

        #region Get&Set
        public int? IdBanner
        {
            get
            {
                return idBanner;
            }

            set
            {
                idBanner = value;
            }
        }

        public int? IdRango
        {
            get
            {
                return idRango;
            }

            set
            {
                idRango = value;
            }
        }

        public bool Activo
        {
            get
            {
                return activo;
            }

            set
            {
                activo = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }
        #endregion


    }
}
