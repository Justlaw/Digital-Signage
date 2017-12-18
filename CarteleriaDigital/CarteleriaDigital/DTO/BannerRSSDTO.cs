using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital.DTO
{
    public class BannerRSSDTO : BannerDTO
    {

        #region Atributos
        //Atributos
        private int idBannerRSS;
        private int idBanner;
        /// <summary>
        /// url de la fuente RSS
        /// </summary>
        private string fuenteRSS;
        /// <summary>
        /// Texto de respaldo. En caso de que al momento de pasar un banner RSS y no se puede obtener la fuente,
        /// se deslizará el textoDeRespaldo.
        /// </summary>
        private string textoDeRespaldo;
        #endregion

        #region Constructores
        //Constructor
        public BannerRSSDTO() { }
        #endregion

        #region Get&Set
        public int IdBannerRSS
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

        public int IdBanner
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

        public string TextoDeRespaldo
        {    get
            {
                return textoDeRespaldo;
            }
            set
            {
                textoDeRespaldo = value;
            }
        }   
        #endregion
    }
}
