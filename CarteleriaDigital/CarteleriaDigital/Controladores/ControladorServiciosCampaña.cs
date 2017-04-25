using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.DTO;
using CarteleriaDigital.DAO;

namespace CarteleriaDigital.Controladores
{
    public class ControladorServiciosCampaña
    {
        public void Guardar(CampañaDTO camp_DTO, RangoDTO rng_DTO, List<ImagenDTO> listImgDTO)
        {
            CampañaDAO camp_DAO = new CampañaDAO();
            ImagenDAO Img_DAO = new ImagenDAO();
            RangoDAO rng_DAO = new RangoDAO();

           
            //Se controla que el rango esté disponible y en caso que lo esté, se procede a insertar la campaña.
            if (rng_DAO.RangoDisponible(rng_DTO))
            {
                rng_DAO.Insertar(rng_DTO);

                camp_DTO.IdRango = rng_DAO.ObtenerUltimoId();
                camp_DAO.Insertar(camp_DTO);

                foreach (ImagenDTO imgDTO in listImgDTO)
                {
                    imgDTO.IdCampaña = camp_DAO.ObtenerUltimoId();
                    Img_DAO.Insertar(imgDTO);
                }
            }
        }

        public void Baja(String nombreCampaña)
        {
            CampañaDAO camp_DAO = new CampañaDAO();
            CampañaDTO camp_DTO = new CampañaDTO();

            camp_DTO = camp_DAO.BuscarPorNombre(nombreCampaña);

            camp_DTO.Activo = false;

            camp_DAO.Modificar(camp_DTO);
        }

        public void Modificar(CampañaDTO camp_DTO, RangoDTO rng_DTO, List<ImagenDTO> listImg_DTO, List<ImagenDTO> listImgV_DTO)
        {
            CampañaDAO camp_DAO = new CampañaDAO();
            ImagenDAO Img_DAO = new ImagenDAO();
            RangoDAO rng_DAO = new RangoDAO();

            if (rng_DTO != null)
            {
                if (rng_DAO.RangoDisponible(rng_DTO))
                {
                    rng_DAO.Modificar(rng_DTO);
                }
            }
            if (camp_DTO != null)
            {
                camp_DAO.Modificar(camp_DTO);
            }
            if (listImg_DTO != null)
            {
                Boolean encontrada;
                //En esta parte se trata de insertar las imagenes que no estan en la lista o bien modificar si cierto DTO de la lista fue modificado
                foreach (ImagenDTO img_DTO in listImg_DTO)
                {
                    encontrada = false;
                    foreach (ImagenDTO img_DTO2 in listImgV_DTO)
                    {
                        if (img_DTO.Equals(img_DTO2))
                        {
                            encontrada = true;
                            break;
                        }
                        else if ((img_DTO.IdImagen == img_DTO2.IdImagen) && !img_DTO.Equals(img_DTO2))
                        {
                            encontrada = true;
                            Img_DAO.Modificar(img_DTO);
                            break;
                        }
                    }
                    if (encontrada == false)
                    {
                        Img_DAO.Insertar(img_DTO);
                    }
                }
                // En esta parte se encuentra si la imagen necesita ser eliminada debido a que el usuario la elimino de la lista
                foreach (ImagenDTO img in listImgV_DTO)
                {
                    encontrada = false;
                    foreach (ImagenDTO img2 in listImg_DTO)
                    {
                        if (img.IdImagen == img2.IdImagen) //Ver si esta comparación es válida.
                        {
                            encontrada = true;
                            break;
                        }
                    }
                    if (encontrada == false)
                    {
                        Img_DAO.Eliminar(img.IdImagen.Value);
                    }
                }
            }            
        }
    }
}
