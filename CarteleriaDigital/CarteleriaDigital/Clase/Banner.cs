using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital
{
    abstract class Banner
    {
        public Boolean iActivo;
        public String iNombre;
        public Rango iRango;

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

        public Rango Rango
        {
            get { return this.iRango; }
            set { iRango = value; }
        }
    }
}
