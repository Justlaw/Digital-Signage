using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital.DTO
{
    class CampañaDTO
    {
        #region Atributos
        private int? idCampaña;
        private int? idRango;
        private bool activo;
        private string nombre;
        #endregion

        #region Constructores
        public CampañaDTO() { }
        #endregion

        #region Get&Set
        public int? IdCampaña
        {
            get
            {
                return idCampaña;
            }

            set
            {
                idCampaña = value;
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

        public String Nombre
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
