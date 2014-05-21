using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Capitulo : System.Web.UI.Page
    {
        FilmBiblio.CapituloEN capitulo = new FilmBiblio.CapituloEN();
        FilmBiblio.SerieEN serie = new FilmBiblio.SerieEN();

        protected void Page_Load(object sender, EventArgs e)
        {
            string id_serie = Request.QueryString["id1"];
            string id_capitulo = Request.QueryString["id2"];

            if (Session["usuario"] == null)
            {
                BotonEditar.Visible = false;
            }

            if (id_capitulo == null || id_serie==null)
            {
                Response.Redirect("Series.aspx");
            }
            else
            {
                serie.Id = Convert.ToInt32(id_serie);
                serie = serie.DameSerie();
                capitulo.Id = Convert.ToInt32(id_capitulo);
                capitulo = capitulo.DameCapitulo();

                HyperLinkVolverSerie.NavigateUrl = "Serie.aspx?id=" + serie.Id;
                BotonEditar.NavigateUrl = "AddEditCapitulo.aspx?id1=" + id_serie + "&id2="+id_capitulo;
                BotonReport.NavigateUrl = "Report.aspx";

                LiteralTitulo.Text = capitulo.Titulo.ToString();
                LiteralSerie.Text = serie.Titulo;
                LiteralTemporada.Text = capitulo.Temporada.ToString();
                LiteralNCapitulo.Text = capitulo.N_capitulo.ToString();
                LiteralSinopsis.Text = capitulo.Sinopsis.ToString();
            }

        }
    }
}