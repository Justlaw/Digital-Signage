using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.DTO;


namespace CarteleriaDigital.Controladores
{
    public static class ControladorCampañas
    {
        public static void CrearCampaña(Campaña camp, Rango rng, List<Imagen> listImg) {
            ControladorServiciosCampaña cSC = new ControladorServiciosCampaña();
            cSC.Guardar(camp,rng,listImg);
        }

        public static void ModificarCampaña() {
            ControladorServiciosCampaña cSC = new ControladorServiciosCampaña();
       //     cSC.Modificar();
        }

        public static void BajaCampaña(String nombreCampaña) {
            ControladorServiciosCampaña cSC = new ControladorServiciosCampaña();
            cSC.Baja(nombreCampaña);
        }
    }
}
