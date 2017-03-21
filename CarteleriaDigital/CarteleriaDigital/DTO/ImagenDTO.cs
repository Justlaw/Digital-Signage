using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital.DTO
{
    class ImagenDTO
    {
        #region Atributos
        private int? idImagen;
        private int? idCampaña;
        private string rutaImagen;
        private short duracion;
        #endregion

        #region Constructores
        //Constructor
        public ImagenDTO() { }
        #endregion


        #region Get&Set
        public int? IdImagen
        {
            get
            {
                return idImagen;
            }

            set
            {
                idImagen = value;
            }
        }

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

        public string RutaImagen
        {
            get
            {
                return rutaImagen;
            }

            set
            {
                rutaImagen = value;
            }
        }

        public short Duracion
        {
            get
            {
                return duracion;
            }

            set
            {
                duracion = value;
            }
        }
        #endregion


    }
}
