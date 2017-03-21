using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital
{
    class Campania
    {
        private Boolean iActivo;
        private String iNombre;
        private List<Imagen> iListaImagenes;
        private Rango iRango;

        public Campania(Boolean pActivo, String pNombre, List<Imagen> pListaImagenes, Rango pRango)
        {
            iActivo = pActivo;
            iNombre = pNombre;
            iListaImagenes = pListaImagenes;
            iRango = pRango;
        }

        public Boolean Activo
        {
            get { return this.iActivo; }
            set { this.iActivo = value; }
        }

        public String Nombre
        {
            get { return this.Nombre; }
            set { this.iNombre = value; }
        }

        public List<Imagen> ListaImagenes
        {
            get { return this.iListaImagenes; }
            set { this.iListaImagenes = value; }
        }

        public Rango Rango { 
            get { return this.iRango; }
            set { iRango = value; }
        }
    }
}
