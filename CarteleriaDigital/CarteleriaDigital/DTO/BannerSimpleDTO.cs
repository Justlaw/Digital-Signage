using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital.DTO
{
    class BannerSimpleDTO : BannerDTO
    {
        #region Atributos

        private int? idBannerSimple;
        private int? idBanner;
        private string texto;

        #endregion

        
        #region Constructores

        public BannerSimpleDTO() { }

        #endregion

        #region Get&Set
        public int? IdBannerSimple
        {
            get
            {
                return idBannerSimple;
            }

            set
            {
                idBannerSimple = value;
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

        public string Texto
        {
            get
            {
                return texto;
            }

            set
            {
                texto = value;
            }
        }
        #endregion
    }
}
