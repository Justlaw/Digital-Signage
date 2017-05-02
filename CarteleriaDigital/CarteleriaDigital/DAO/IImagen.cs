using CarteleriaDigital.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleriaDigital.DAO
{
    interface IImagen
    {
        void Insertar(ImagenDTO imagenDTO);

        void Modificar(ImagenDTO imagenDTO);

        ImagenDTO BuscarImagenPorID(int id_Img);

        void Eliminar(int idImagen);

        List<ImagenDTO> ListarPorCampaña(int pIdCampaña);
    }
}
