using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using AjaxControlToolkit;


namespace WebApplication1
{
    public partial class Serie : System.Web.UI.Page
    {
        private FilmBiblio.SerieEN serie;
        private DataSet d = new DataSet();
        private FilmBiblio.ComentarioEN comentario = new FilmBiblio.ComentarioEN();
        private FilmBiblio.UsuarioEN usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            serie = new FilmBiblio.SerieEN();
            if (Session["usuario"] == null)
            {
                BotonEditar.Visible = false;
            }else
                usuario = (FilmBiblio.UsuarioEN)Session["usuario"];

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
                HyperLinkAddCapitulo.NavigateUrl = "AddEditCapitulo.aspx?id1=" + serie.Id;

                serie = serie.DameSerie();
                titulo.Text = serie.Titulo;
                musica.Text = serie.BandaSonora;
                sinopsis.Text = serie.Sinopsis;
                trailer.Text = serie.Trailer;
                puntuacion.Text = serie.Puntuacion.ToString();
                reparto.Text = serie.Reparto.ToString();
                ano.Text = serie.Ano.ToString();
                caratula.ImageUrl = serie.Caratula.ToString();
                fondo.ImageUrl = serie.Portada.ToString();
            
              FilmBiblio.CapituloEN capitulo = new FilmBiblio.CapituloEN();
              Label lblTitle;
              Label lblContent;
              DataTable dt = new DataTable();
              AjaxControlToolkit.AccordionPane pn;
                DataSet d=new DataSet();
                d = capitulo.DameCapitulos(serie.Id);
              for (int i = 1; i <=  capitulo.Temporadas(serie.Id); i++)
              {
                  dt = d.Tables[0];
                 //dt.DefaultView.RowFilter = "temporada = " + i.ToString();
                  pn = new AjaxControlToolkit.AccordionPane();
                  pn.ID = "Pane" + i;
                  lblTitle = new Label();
                  lblContent = new Label();
                  lblTitle.Text = "<h3 class='temporada_nombre'>Temporada " + i.ToString() + "</h3>";
                  string contenido="";
                  foreach (DataRow dr in dt.Rows)
                  {
                      if (dr["temporada"].ToString() == i.ToString())
                          contenido += "<a class='capitulo_nombre' href='Capitulo.aspx?id2=" + dr["id"].ToString() +"&id1="+serie.Id + "'>" + dr["titulo"].ToString() + "</a>";
                  }
                  
                  lblContent = new Label();


                  lblContent.Text = contenido;
                  pn.ContentContainer.Controls.Add(lblContent);
                  pn.HeaderContainer.Controls.Add(lblTitle);
                  pn.ContentContainer.Controls.Add(lblContent);
                  Accordion1.Panes.Add(pn);
              }
            }



            if (usuario != null)
                Rating1.CurrentRating = Convert.ToInt32(Math.Round(Convert.ToDecimal(serie.Puntuacion) / 2));
            else
                Rating1.Visible = false;
            if (!Page.IsPostBack)
            {
                comentario.Film = Convert.ToInt32(id);
                d = comentario.DameComentariosFilm(serie.Id);
                ListViewComentarios.DataSource = d;
                ListViewComentarios.DataBind();
            }



        }

        protected void OnRatingChanged(object sender, RatingEventArgs e)
        {
            //   pelicula.Puntuacion = Convert.ToSingle( e.Value.ToString());
            //titulo.Text = "Holaaaaaaaaaaaaaa";
            if (usuario != null)
            {
                serie.AnyadirPuntuacionSerie(usuario.Id, Convert.ToSingle(e.Value.ToString()) * 2);
                serie.DameSerie();
                puntuacion.Text = serie.Puntuacion.ToString();
                //  Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            //  

            //   e.Value;
        }
    }
}