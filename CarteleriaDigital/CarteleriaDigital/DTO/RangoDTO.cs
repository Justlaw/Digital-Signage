using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital.DTO
{
    class RangoDTO
    {
        #region Atributos
        private int? idRango;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private DateTime horaInicio;
        private DateTime horaFin;
        #endregion

        #region Constructores
        public RangoDTO() { }
        #endregion


        #region Get&Set
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

        public DateTime FechaInicio
        {
            get
            {
                return fechaInicio;
            }

            set
            {
                fechaInicio = value;
            }
        }

        public DateTime FechaFin
        {
            get
            {
                return fechaFin;
            }

            set
            {
                fechaFin = value;
            }
        }

        public DateTime HoraInicio
        {
            get
            {
                return horaInicio;
            }

            set
            {
                horaInicio = value;
            }
        }

        public DateTime HoraFin
        {
            get
            {
                return horaFin;
            }

            set
            {
                horaFin = value;
            }
        }

        #endregion

    }
}
