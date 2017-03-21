using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.DTO;

namespace CarteleriaDigital.DAO
{
    interface IRango
    {
        void insertar(RangoDTO rangoDTO);

        void modificar(RangoDTO rangoDTO);

        void eliminar(RangoDTO rangoDTO);
    }
}
