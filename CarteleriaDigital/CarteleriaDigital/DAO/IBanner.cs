using CarteleriaDigital.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital.DAO
{
    interface IBanner 
        //REEVER LOS TIPOS DE LOS RETURN Y DEMÁS!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    {
        void Insertar(BannerDTO ban);

        void Modificar(BannerDTO ban);

        void Listar();
    }
}
