using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital
{
    class Imagen
    {
        private String iRutaImagen;
        private Int16 iDuracion;

        public Imagen(String pRutaImagen, Int16 pDuracion)
        {
            this.iDuracion = pDuracion;
            this.iRutaImagen = pRutaImagen;
        }

        public Imagen()
        {
        }

        public Int16 Duracion
        {
            set { iDuracion = value; }
            get { return this.iDuracion; }
        }

        public String RutaImagen
        {
            set { iRutaImagen = value; }
            get { return this.iRutaImagen; }
        }
    }
}
