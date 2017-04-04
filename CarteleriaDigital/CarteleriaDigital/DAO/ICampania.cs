using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.DTO;

namespace CarteleriaDigital.DAO
{
    interface ICampania
    {
        void Insertar(CampañaDTO camDTO);

        void Modificar(CampañaDTO camDTO);

        CampañaDTO BuscarPorNombre(String pNombre);

        List<CampañaDTO> ListarPorActivo(Boolean pActivo);

        List<CampañaDTO> ListarPorFecha(DateTime pFechaIni, DateTime pFechaFin);
    }
}
