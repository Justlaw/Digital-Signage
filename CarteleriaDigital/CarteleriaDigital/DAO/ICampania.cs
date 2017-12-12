using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.DTO;
using System.Data;

namespace CarteleriaDigital.DAO
{
    interface ICampania
    {
        void Insertar(CampañaDTO camDTO);

        void Modificar(CampañaDTO camDTO);

        CampañaDTO BuscarCampañaPorID(int id_Camp);

        CampañaDTO BuscarPorFecha(DateTime pFechaIni);

        CampañaDTO BuscarPorNombre(String pNombre);

        DataSet filtrarCampañaPorNombre(String pNombre);

        DataSet filtrarCampañaPorFecha(DateTime pFechaIni, DateTime pFechaFin);
    }
}
