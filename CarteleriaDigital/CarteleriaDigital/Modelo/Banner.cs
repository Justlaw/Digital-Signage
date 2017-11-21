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
        public String iTipo;
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

        public String Tipo
        {
            get { return this.iTipo; }
            set { this.iTipo = value; }
        }

        public Rango Rango
        {
            get { return this.iRango; }
            set { iRango = value; }
        }
    }
}
