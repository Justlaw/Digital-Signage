using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.DTO;


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
            Rango rng = new Rango(rng_DTO.FechaInicio, rng_DTO.FechaFin, rng_DTO.HoraInicio, rng_DTO.HoraFin);
            Campaña camp = new Campaña(camp_DTO.Activo,camp_DTO.Nombre,listImg,rng);
            camp.Guardar(camp_DTO,rng_DTO,listImg_DTO);
        }

        public static void ModificarCampaña(CampañaDTO camp_DTO, RangoDTO rng_DTO, List<ImagenDTO> listImg_DTO, List<ImagenDTO> listImgV_DTO) {
            List<Imagen> listImg = new List<Imagen>();
            foreach (ImagenDTO imgDTO in listImg_DTO)
            {
                Imagen img = new Imagen(imgDTO.RutaImagen, imgDTO.Duracion);
                listImg.Add(img);
            }
            Rango rng = new Rango(rng_DTO.FechaInicio, rng_DTO.FechaFin, rng_DTO.HoraInicio, rng_DTO.HoraFin);
            Campaña camp = new Campaña(camp_DTO.Activo, camp_DTO.Nombre, listImg, rng);
            camp.Modificar(camp_DTO, rng_DTO, listImg_DTO, listImgV_DTO);
        }

        public static void BajaCampaña(Campaña camp) {
            camp.Baja();
        }
    }
}
