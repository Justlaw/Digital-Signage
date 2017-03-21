using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital.DTO
{
    class BannerRSSDTO
    {

        #region Atributos
        //Atributos
        private int? idBannerRSS;
        private int? idBanner;
        /// <summary>
        /// url de la fuente RSS
        /// </summary>
        private string fuenteRSS;
        #endregion

        #region Constructores
        //Constructor
        public BannerRSSDTO() { }
        #endregion

        #region Get&Set
        public int? IdBannerRSS
        {
            get
            {
                return idBannerRSS;
            }

            set
            {
                idBannerRSS = value;
            }
        }

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

        public string FuenteRSS
        {
            get
            {
                return fuenteRSS;
            }

            set
            {
                fuenteRSS = value;
            }
        }
        #endregion
    }
}
