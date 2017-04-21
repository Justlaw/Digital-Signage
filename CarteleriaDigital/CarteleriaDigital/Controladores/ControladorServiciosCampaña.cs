using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.DTO;
using CarteleriaDigital.DAO;

namespace CarteleriaDigital.Controladores
{
    class ControladorServiciosCampaña
    {
        public void Guardar(Campaña camp, Rango rng, List<Imagen> listImg)
        {
            CampañaDAO camp_DAO = new CampañaDAO();
            ImagenDAO Img_DAO = new ImagenDAO();
            RangoDAO rng_DAO = new RangoDAO();

            CampañaDTO camp_DTO = new CampañaDTO();
            camp_DTO.Activo = camp.Activo;
            camp_DTO.Nombre = camp.Nombre;

            List<ImagenDTO> listImgDTO = new List<ImagenDTO>();



            foreach (Imagen img in listImg)
            {
                ImagenDTO img_DTO = new ImagenDTO();
                img_DTO.Duracion = img.Duracion;
                img_DTO.RutaImagen = img.RutaImagen;
                listImgDTO.Add(img_DTO);
            }

            RangoDTO rng_DTO = new RangoDTO();
            rng_DTO.FechaInicio = rng.FechaInicio;
            rng_DTO.FechaFin = rng.FechaFin;
            rng_DTO.HoraInicio = rng.HoraInicio;
            rng_DTO.HoraFin = rng.HoraFin;

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
                foreach (ImagenDTO img_DTO in listImg_DTO)
                {
                    encontrada = false;
                    foreach (ImagenDTO img_DTO2 in listImgV_DTO)
                    {
                        if (img_DTO.IdImagen == img_DTO2.IdImagen)
                        {
                            encontrada = true;
                            break;
                        }
                    }
                    if (encontrada == false)
                    {
                        Img_DAO.Insertar(img_DTO);
                    }
                }
                foreach (ImagenDTO img in listImgV_DTO)
                {
                    encontrada = false;
                    foreach (ImagenDTO img2 in listImg_DTO)
                    {
                        if (img.IdImagen == img2.IdImagen)
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
