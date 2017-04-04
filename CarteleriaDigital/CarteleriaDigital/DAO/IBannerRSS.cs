using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.DTO;

namespace CarteleriaDigital.DAO
{
    interface IBannerRSS
    {
        void Insertar(BannerRSSDTO bRSSDTO);

        void Modificar(BannerRSSDTO bRSSDTO);
    }
}
