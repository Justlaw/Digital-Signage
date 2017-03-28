using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital.DAO.Postgres
{
    class filtro
    {
        public String cPorNombre(String pNombre) {
            return "where nombre = "+pNombre;
        } 

        public String cPorActivo(){
            return "where activo = true";
        }

        public String cPorfecha(DateTime fecha1, DateTime fecha2) {
            return "where campaña.idrango = rango.idrango and rango.idFechaInicio = fecha1 and rango.idfechafin = fecha2";
        }

        public String iPorCampaña(int pIdCampaña) {
            return "where imagen.idCampaña = pIdCampaña";
        }

        public String bPorNombre(String pNombre) {
            return "where nombre =" +pNombre;
        }

        public String bPorActivo() {
            return "where activo = true";
        }

        public String bPorFecha(DateTime fecha1, DateTime fecha2) {
            return "where banner.idrango = rango.idrango and rango.idFechaInicio = fecha1 and rango.idfechafin = fecha2";
        }

        public String bSPorNombre(String pNombre)
        {
            return "where bannersimple.idbanner = banner.idbanner and nombre =" + pNombre;
        }

        public String bSPorActivo()
        {
            return "where bannersimple.idbanner = banner.idbanner and activo = true";
        }

        public String bSPorFecha(DateTime fecha1, DateTime fecha2)
        {
            return "where bannersimple.idbanner = banner.idbanner and banner.idrango = rango.idrango and rango.idFechaInicio = fecha1 and rango.idfechafin = fecha2";
        }
    }
}
