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

        void Eliminar(int idCampaña);

        CampañaDTO BuscarCampañaPorID(int idCampaña);

        CampañaDTO BuscarPorFecha(DateTime pFechaIni);

        CampañaDTO BuscarPorNombre(String pNombre);
    }
}
