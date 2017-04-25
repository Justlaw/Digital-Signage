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

        public void Baja(String nombreCampaña) {
            CampañaDAO camp_DAO = new CampañaDAO();
            CampañaDTO camp_DTO = new CampañaDTO();

            camp_DTO = camp_DAO.BuscarPorNombre(nombreCampaña);

            camp_DTO.Activo = false;

            camp_DAO.Modificar(camp_DTO);
        }

        public void Modificar(Campaña camp) {
            CampañaDAO camp_DAO = new CampañaDAO();
            ImagenDAO Img_DAO = new ImagenDAO();
            RangoDAO rng_DAO = new RangoDAO();

            
        }
    }
}
