using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AddCapitulo : System.Web.UI.Page
    {

        FilmBiblio.CapituloEN capitulo = new FilmBiblio.CapituloEN();
        FilmBiblio.SerieEN serie = new FilmBiblio.SerieEN();

        protected void Page_Load(object sender, EventArgs e)
        {
            string id_capitulo = Request.QueryString["id2"];
            string id_serie = Request.QueryString["id1"];

            if (Session["usuario"] == null)
            {
                Response.Redirect("Error.aspx");
            }
            if (id_capitulo == null && id_serie == null)
            {
                Response.Redirect("Series.aspx");
            }
            else
            {
                if (id_capitulo != null)
                {
                    capitulo.Id = Convert.ToInt32(id_capitulo);
                    capitulo = capitulo.DameCapitulo();
                }

                serie.Id = Convert.ToInt32(id_serie);
                serie = serie.DameSerie();

                HyperLinkEditarCapitulo.Visible = false;
                HyperLinkVolverSerie.NavigateUrl = "Serie.aspx?id=" + serie.Id;

                if (!Page.IsPostBack)
                {
                    if (id_capitulo == null)
                    {
                        //Añadiendo capitulo
                        Page.Title = "Añadiendo capítulo a "+serie.Titulo;
                        
                        BotonAddEdit.Text = "Añadir capítulo";
                        LiteralSerie.Text = serie.Titulo.ToString();            
                    }
                    else
                    {
                        //Editar capítulo

                        Page.Title = "Editando el capítulo " + capitulo.Titulo;

                        BotonAddEdit.Text = "Guardar cambios";
                        caratula.ImageUrl = "/img/film/caratula/" + capitulo.Serie + ".jpg";
                        portada.ImageUrl = "/img/film/portada/" + capitulo.Serie + ".jpg";
                        TextBoxTitulo.Text = capitulo.Titulo.ToString();
                        LiteralSerie.Text = serie.Titulo.ToString();
                        TextBoxTemporada.Text = capitulo.Temporada.ToString();
                        TextBoxNCapitulo.Text = capitulo.N_capitulo.ToString();
                        TextBoxSinopsis.Text = capitulo.Sinopsis.ToString();
                        TextBoxTitulo.Enabled = false;
                        TextBoxTemporada.Enabled = false;
                        TextBoxNCapitulo.Enabled = false;
                    }
                
                }

            }
        }

        protected void BotonAddEditOnClick(object sender, EventArgs e)
        {
            string id_capitulo = Request.QueryString["id2"];
            string id_serie = Request.QueryString["id1"];

            if (Page.IsValid)
            {
                if (id_capitulo != null)
                {
                    capitulo.Id = Convert.ToInt32(id_capitulo);
                    capitulo = capitulo.DameCapitulo();
                    BotonAddEdit.Text = "Guardar cambios";
                }

                serie.Id = Convert.ToInt32(id_serie);
                serie = serie.DameSerie();

                //Editar o Añadir capitulo
                capitulo.Titulo = TextBoxTitulo.Text;
                capitulo.Temporada = Convert.ToInt32(TextBoxTemporada.Text);
                capitulo.N_capitulo = Convert.ToInt32(TextBoxNCapitulo.Text);
                capitulo.Sinopsis = TextBoxSinopsis.Text;
                capitulo.Serie = Convert.ToInt32(id_serie);

                if (id_capitulo == null)
                    capitulo.Id = capitulo.InsertarCapitulo();
                else
                    capitulo.UpdateCapitulo();

                Response.Redirect("Capitulo.aspx?id1=" + id_serie + "&id2=" + capitulo.Id);
            }

            
        }

        protected void ValidandoTemporadaNCapitulo(object sender, ServerValidateEventArgs e)
        {
            int id_serie = Convert.ToInt32(Request.QueryString["id1"].ToString());
            string id_capitulop = Request.QueryString["id2"];

            if (id_capitulop == "" || id_capitulop == null)
            {

                if (TextBoxTemporada.Text.ToString() == "")
                    ValidarTemporadaRellena.IsValid = false;
                else if (TextBoxNCapitulo.Text.ToString() == "")
                    ValidarCapituloRelleno.IsValid = false;
                else
                {
                    int temporada = Convert.ToInt32(TextBoxTemporada.Text.ToString());
                    int id_capitulo = Convert.ToInt32(TextBoxNCapitulo.Text.ToString());
                    if (capitulo.TemporadaCapituloRepetido(id_serie, temporada, id_capitulo))
                    {
                        ValidarTemporadaNCapitulo.Visible = true;
                        e.IsValid = false;
                    }
                }
            }
     }

}
}