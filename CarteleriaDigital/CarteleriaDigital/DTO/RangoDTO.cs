using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital.DTO
{
    public class RangoDTO
    {
        #region Atributos
        private int? idRango;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private short horaInicio;
        private short minutoInicio;
        private short horaFin;
        private short minutoFin;

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

        public short HoraInicio
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

        public short MinutoInicio
        {
            get
            {
                return minutoInicio;
            }
            set
            {
                minutoInicio = value;
            }
        }

        public short HoraFin
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

        public short MinutoFin
        {
            get
            {
                return minutoFin;
            }
            set
            {
                minutoFin = value;
            }
        }

        #endregion

    }
}
