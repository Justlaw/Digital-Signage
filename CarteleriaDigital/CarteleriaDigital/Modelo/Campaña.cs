using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteleriaDigital.DAO;
using CarteleriaDigital.DTO;

namespace CarteleriaDigital
{
    public class Campaña
    {
        private Boolean iActivo;
        private String iNombre;
        private List<Imagen> iListaImagenes;
        private Rango iRango;

        public Campaña(Boolean pActivo, String pNombre, List<Imagen> pListaImagenes, Rango pRango)
        {
            iActivo = pActivo;
            iNombre = pNombre;
            iListaImagenes = pListaImagenes;
            iRango = pRango;
        }

        public Boolean Activo
        {
            get { return this.iActivo; }
            set { this.iActivo = value; }
        }

        public String Nombre
        {
            get { return this.iNombre; }
            set { this.iNombre = value; }
        }

        public List<Imagen> ListaImagenes
        {
            get { return this.iListaImagenes; }
            set { this.iListaImagenes = value; }
        }

        public Rango Rango { 
            get { return this.iRango; }
            set { iRango = value; }
        }

        //Permite Guardar una campaña
        public void Guardar(CampañaDTO camp_DTO, RangoDTO rng_DTO, List<ImagenDTO> listImgDTO)
        {
            CampañaDAO camp_DAO = new CampañaDAO();
            ImagenDAO Img_DAO = new ImagenDAO();
            RangoDAO rng_DAO = new RangoDAO();
            Rango rng = new Rango(rng_DTO);


            //Se controla que el rango esté disponible y en caso que lo esté, se procede a insertar la campaña.
            if (rng.RangoDisponibleCampaña(rng_DTO))
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

        //Este método permite modificar una campaña junto con su rango y lista de imagenes asociados a la misma
        public void Modificar(CampañaDTO camp_DTO, RangoDTO rng_DTO, List<ImagenDTO> listImg_DTO)
        {
            CampañaDAO camp_DAO = new CampañaDAO();
            ImagenDAO Img_DAO = new ImagenDAO();
            RangoDAO rng_DAO = new RangoDAO();
            int idcamp = camp_DTO.IdCampaña;

            Rango rng = new Rango(rng_DTO.FechaInicio, rng_DTO.FechaFin, rng_DTO.HoraInicio, rng_DTO.MinutoInicio, rng_DTO.HoraFin, rng_DTO.MinutoFin);

            if (rng_DTO != null)
            {
                if (rng.RangoDisponibleCampaña(rng_DTO))
                {
                    rng_DAO.Modificar(rng_DTO);
                }
            }
            if (listImg_DTO != null)
            {
                Img_DAO.eliminarImagenesCampaña(camp_DTO.IdCampaña);
                //En esta parte se trata de insertar las imagenes que no estan en la lista o bien modificar si cierto DTO de la lista fue modificado
                foreach (ImagenDTO imgDTO in listImg_DTO)
                {
                    imgDTO.IdCampaña = idcamp;
                    Img_DAO.Insertar(imgDTO);
                }
            }
            if (camp_DTO != null)
            {
                camp_DAO.Modificar(camp_DTO);
            }
        }
    }
}
