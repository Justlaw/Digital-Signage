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
        void Insertar(RangoDTO rangoDTO);

        void Modificar(RangoDTO rangoDTO);

    }
}
