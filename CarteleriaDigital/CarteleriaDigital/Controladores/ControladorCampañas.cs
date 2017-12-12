using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.DTO;
using CarteleriaDigital.DAO;


namespace CarteleriaDigital.Controladores
{
    public static class ControladorCampañas
    {
        public static void CrearCampaña(CampañaDTO camp_DTO, RangoDTO rng_DTO, List<ImagenDTO> listImg_DTO) {
            List<Imagen> listImg = new List<Imagen>();
            foreach (ImagenDTO imgDTO in listImg_DTO) {
                Imagen img = new Imagen(imgDTO.RutaImagen, imgDTO.Duracion);
                listImg.Add(img);
            }
            Rango rng = new Rango(rng_DTO.FechaInicio, rng_DTO.FechaFin, rng_DTO.HoraInicio, rng_DTO.MinutoInicio, rng_DTO.HoraFin, rng_DTO.MinutoFin);
            Campaña camp = new Campaña(camp_DTO.Activo,camp_DTO.Nombre,listImg,rng);
            camp.Guardar(camp_DTO,rng_DTO,listImg_DTO);
        }

        public static void ModificarCampaña(CampañaDTO camp_DTO, RangoDTO rng_DTO, List<ImagenDTO> listImgV_DTO) {
            List<Imagen> listImg = new List<Imagen>();
            List<ImagenDTO> listImg_DTO = new List<ImagenDTO>();
            listImg_DTO = buscarImagenesCampaña(camp_DTO.IdCampaña);

            foreach (ImagenDTO imgDTO in listImg_DTO)
            {
                Imagen img = new Imagen(imgDTO.RutaImagen, imgDTO.Duracion);
                listImg.Add(img);
            }
            Rango rng = new Rango(rng_DTO.FechaInicio, rng_DTO.FechaFin, rng_DTO.HoraInicio, rng_DTO.MinutoInicio, rng_DTO.HoraFin, rng_DTO.MinutoFin);
            Campaña camp = new Campaña(camp_DTO.Activo, camp_DTO.Nombre, listImg, rng);
            camp.Modificar(camp_DTO, rng_DTO, listImg_DTO, listImgV_DTO);
        }

        public static CampañaDTO buscarCampaña(int idCampaña) {
            List<Imagen> listImg = new List<Imagen>();
            CampañaDAO camp = new CampañaDAO();
            return camp.BuscarCampañaPorID(idCampaña); 
        }

        public static CampañaDTO buscarCampañaActual()
        {
            DateTime FechaActual = DateTime.Today;
            CampañaDAO camp = new CampañaDAO();
            return camp.BuscarPorFecha(FechaActual);
        } 

        public static RangoDTO buscarRangoPorID(int idRango) {
            RangoDAO rng_DAO = new RangoDAO();
            rng_DAO.BuscarRangoPorID(idRango);
            return rng_DAO.BuscarRangoPorID(idRango);
        }

        public static List<ImagenDTO> buscarImagenesCampaña(int idCampaña) {
            List<Imagen> listImg = new List<Imagen>();
            ImagenDAO img_DAO = new ImagenDAO();
                        
            return img_DAO.ListarPorCampaña(idCampaña); 
        }
    }
}
