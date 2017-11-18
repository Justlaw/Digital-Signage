using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital
{
    class FuenteRSS
    {
        private String iURL;
        private String iDescripcion;

        public FuenteRSS(String pURL, String pDescripcion)
        {
            this.iURL = pURL;
            this.iDescripcion = pDescripcion;
        }

        public String URL
        {
            get { return this.iURL; }
            set { this.URL = value; }
        }

        public String Descripcion
        {
            get { return this.iDescripcion; }
            set { this.iDescripcion = value; }
        }

    }
}
