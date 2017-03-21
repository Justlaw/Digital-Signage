using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital.DAO
{
    interface IBanner 
        //REEVER LOS TIPOS DE LOS RETURN Y DEMÁS!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    {
        Boolean Insertar(Conexion con, Banner ban);

        Boolean Modificar();

        Boolean Listar();

        Boolean Borrar();
    }
}
