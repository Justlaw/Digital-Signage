using CarteleriaDigital.DAO;
using CarteleriaDigital.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.Xml;

namespace CarteleriaDigital
{
    class BannerRSS : Banner
    {
        private String url;
        private String textoDeRespaldo;

        public BannerRSS() { }


        public BannerRSS(BannerRSSDTO brss, Rango rango)
        {
            this.Activo = true;
            this.Nombre = brss.Nombre;
            this.URL = brss.FuenteRSS;
            this.textoDeRespaldo = brss.TextoDeRespaldo;
            this.Tipo = "rss";
            this.Rango = rango;
        }
        
        public BannerRSS(String pURL, Boolean pActivo, String pNombre, Rango pRango)
        {
            this.iActivo = pActivo;
            this.iNombre = pNombre;
            this.url = pURL;
            this.iRango = pRango;
        }

        #region Accesores

        public Boolean Activo
        {
            get { return this.iActivo; }
            set { this.iActivo = value; }
        }

        public String URL
        {
            get { return this.url; }
            set { this.url = value; }
        }

        public String TextoDeRespaldo
        {
            get
            {
                return textoDeRespaldo;
            }
            set
            {
                textoDeRespaldo = value;
            }
        }

        public String Nombre
        {
            get { return this.iNombre; }
            set { this.iNombre = value; }
        }

        public Rango Rango
        {
            get { return this.iRango; }
            set { this.iRango = value; }
        }
        #endregion

        public bool Guardar(BannerRSSDTO brss_DTO, RangoDTO rng_DTO)
        {
            BannerRSSDAO brss_DAO = new BannerRSSDAO();
            BannerDAO b_DAO = new BannerDAO();
            RangoDAO rng_DAO = new RangoDAO();

            BannerDTO b_DTO = new BannerDTO
            {
                Nombre = brss_DTO.Nombre,
                Tipo = brss_DTO.Tipo
            };

            Rango rng = new Rango(rng_DTO);

            //Se controla que el rango esté disponible
            if (rng.RangoDisponibleBanner(rng_DTO))
            {

                rng_DAO.Insertar(rng_DTO);

                b_DTO.IdRango = rng_DAO.ObtenerUltimoId();
                b_DAO.Insertar(b_DTO);

                brss_DTO.IdBanner = b_DAO.ObtenerUltimoId();
                brss_DTO.TextoDeRespaldo = ObtenerTitulos();
                brss_DAO.Insertar(brss_DTO);

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Obtiene todos los item Titulo de un RSS o un Atom  
        /// </summary>
        /// <returns></returns>
        public String ObtenerTitulos()
        {
            String texto = "";
            try
            {
                XmlReader lector = XmlReader.Create(this.url);
                SyndicationFeed feed = SyndicationFeed.Load(lector);
                lector.Close();
                int i = 0;
                if (feed.Items != null)
                {
                    foreach (SyndicationItem item in feed.Items)
                    {
                        i++;
                        texto = String.Concat(texto, " | " + item.Title.Text);
                        if (i == 3)
                        { break; }
                    }
                    return texto;
                }
                else
                {
                    return TextoDeRespaldo;
                }


            }
            catch (XmlException e)
            {
               throw e;
            }

            catch (Exception e)
            {
                throw e;
            }
        } 
        }
    }


