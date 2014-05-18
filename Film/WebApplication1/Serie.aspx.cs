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
        protected void Page_Load(object sender, EventArgs e)
        {
            String id = Request.QueryString["id"];

            if (id == null)
            {
                Response.Redirect("series.aspx");
            }
            else
            {
                FilmBiblio.SerieEN serie = new FilmBiblio.SerieEN();
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
        }
    }
}