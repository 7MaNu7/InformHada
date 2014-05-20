using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Serie : System.Web.UI.Page
    {
        private FilmBiblio.SerieEN serie = new FilmBiblio.SerieEN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                BotonEditar.Visible = false;
            }

            String id = Request.QueryString["id"];
            if (id == null)
            {
                Response.Redirect("series.aspx");
            }
            else
            {
                
                serie.Id = Convert.ToInt32(id);

                BotonEditar.NavigateUrl = "AddEditserie.aspx?id=" + id;
                BotonReport.NavigateUrl = "Report.aspx";

                serie = serie.DameSerie();
                titulo.Text = serie.Titulo;
                musica.Text = serie.BandaSonora;
                sinopsis.Text = serie.Sinopsis;
                trailer.Text = serie.Trailer;
                puntuacion.Text = serie.Puntuacion.ToString();
                reparto.Text = serie.Reparto.ToString();
                ano.Text = serie.Ano.ToString();
            }
              FilmBiblio.CapituloEN capitulo = new FilmBiblio.CapituloEN();
              Label lblTitle;
              Label lblContent;
              AjaxControlToolkit.AccordionPane pn;
              for (int i = 0; i < 3; i++)
              {
                  pn = new AjaxControlToolkit.AccordionPane();
                  pn.ID = "Pane" + i;
                  lblTitle = new Label();
                  lblContent = new Label();
                  lblTitle.Text = "HOLA";
                  lblContent.Text = "Caracola";
                  pn.HeaderContainer.Controls.Add(lblTitle);
                  pn.ContentContainer.Controls.Add(lblContent);
                  Accordion1.Panes.Add(pn);
              }
        }
    }
}