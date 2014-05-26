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
        private FilmBiblio.UsuarioEN usuario = new FilmBiblio.UsuarioEN();
        private FilmBiblio.ComentarioEN comentarioEn = new FilmBiblio.ComentarioEN();

        protected void Page_Load(object sender, EventArgs e)
        {
            serie = new FilmBiblio.SerieEN();

            if (Session["usuario"] == null)                 //Parte pública (ve comentarios, reportar error)
            {
                BotonEditar.Visible = false;
                LiteralComentar.Visible = false;
                BotonComentar.Visible = false;
                TextBoxComentario.Visible = false;
                Rating1.Visible = false;
                BotonEditar.Visible = false;
                HyperLinkAddCapitulo.Visible = false;
                Panelcomentar.Visible = false;

                Rating1.Visible = false;
            }
            else                                            //Parte privada (puede comentar, editar)
            {
                LiteralComentar.Text = "Deja tu comentario";
                usuario = (FilmBiblio.UsuarioEN)Session["usuario"];
                imagen_user.ImageUrl = "/img/users/" + usuario.Id + ".jpg";

                Rating1.CurrentRating = Convert.ToInt32(Math.Round(Convert.ToDecimal(serie.Puntuacion) / 2));
            }

            //Si no hay id del film redirige a Series
            String id = Request.QueryString["id"];
            if (id == null)
            {
                Response.Redirect("series.aspx");
            }
            else
            {
                serie.Id = Convert.ToInt32(id);

                //Si el id es una serie, si no redirige a Series
                if (serie.EsSerie(serie.Id))
                {
                    BotonEditar.NavigateUrl = "AddEditserie.aspx?id=" + id;
                    BotonReport.NavigateUrl = "Report.aspx";
                    HyperLinkAddCapitulo.NavigateUrl = "AddEditCapitulo.aspx?id1=" + serie.Id;
                        
                    serie = serie.DameSerie();

                    Page.Title = serie.Titulo;

                    titulo.Text = serie.Titulo;
                    musica.Text = serie.BandaSonora;
                    sinopsis.Text = serie.Sinopsis;
                    trailer.Text = serie.Trailer;
                    puntuacion.Text = serie.Puntuacion.ToString();
                    director.Text = serie.Director.ToString();
                    reparto.Text = serie.Reparto;
                    ano.Text = Convert.ToString( serie.Ano);
                    caratula.ImageUrl = "/img/film/caratula/" + serie.Id + ".jpg";
                    fondo.ImageUrl = "/img/film/portada/" + serie.Id + ".jpg";

                    //Acordeon para los capítulos
                    FilmBiblio.CapituloEN capitulo = new FilmBiblio.CapituloEN();
                    Label lblTitle;
                    Label lblContent;
                    DataTable dt = new DataTable();
                    AjaxControlToolkit.AccordionPane pn;
                    DataSet d = new DataSet();
                    d = capitulo.DameCapitulos(serie.Id);
                        
                    for (int i = 1; i <= capitulo.Temporadas(serie.Id); i++)
                    {
                        dt = d.Tables[0];
                        pn = new AjaxControlToolkit.AccordionPane();
                        pn.ID = "Pane" + i;
                        lblTitle = new Label();
                        lblContent = new Label();
                        lblTitle.Text = "<h3 class='temporada_nombre'>Temporada " + i.ToString() + "</h3>";
                        string contenido = "";
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["temporada"].ToString() == i.ToString())
                                contenido += "<a class='capitulo_nombre' href='Capitulo.aspx?id2=" + dr["id"].ToString() + "&id1=" + serie.Id + "'>" + dr["titulo"].ToString() + "</a>";
                        }

                        lblContent = new Label();
                        lblContent.Text = contenido;
                        pn.ContentContainer.Controls.Add(lblContent);
                        pn.HeaderContainer.Controls.Add(lblTitle);
                        pn.ContentContainer.Controls.Add(lblContent);
                        Accordion1.Panes.Add(pn);
                    }
                }
                else
                {
                    Response.Redirect("Series.aspx");
                }
            }
            
            //Carga los comentarios de la serie
            if (!Page.IsPostBack)
            {
                comentario.Film = Convert.ToInt32(id);
                d = comentario.DameComentariosFilm(serie.Id);
                ListViewComentarios.DataSource = d;
                ListViewComentarios.DataBind();
            }


            /*if (usuario != null)
                Rating1.CurrentRating = Convert.ToInt32(Math.Round(Convert.ToDecimal(serie.Puntuacion) / 2));
            else
                Rating1.Visible = false;*/
            



        }

        //Al darle al botón comentar se inserta el comentario
        protected void ComentarOnClick(object sender, EventArgs e)
        {
            usuario = (FilmBiblio.UsuarioEN)Session["usuario"];
            int id_serie = Convert.ToInt32(Request.QueryString["id"]);
            serie.Id = id_serie;
            serie = serie.DameSerie();
            string texto = TextBoxComentario.Text;
            DateTime tomorrow = DateTime.Today.AddDays(0);

            comentarioEn.Usuario = usuario.Id;
            comentarioEn.Film = serie.Id;
            comentarioEn.Texto = texto;
            comentarioEn.Fecha = tomorrow.ToString();
            comentarioEn.InsertarComentario();
            Response.Redirect("serie.aspx?id=" + serie.Id);
        }

        //Para puntuar la serie con el control rating de AJAX
        protected void OnRatingChanged(object sender, RatingEventArgs e)
        {
            if (usuario != null)
            {
                int id_serie = Convert.ToInt32(Request.QueryString["id"]);
                serie.Id = id_serie;

                serie.AnyadirPuntuacionSerie(usuario.Id, Convert.ToSingle(e.Value.ToString()) * 2);
                serie.DameSerie();
                puntuacion.Text = serie.Puntuacion.ToString();
            }
        }

        //Se encarga de mostrar el botón de eliminar comentario si el comentario es de ese usuario
        protected void mostrar(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int id_comentario = Convert.ToInt32(btn.ToolTip);
            if (usuario.Id != id_comentario)
                btn.Visible = false;
        }

        //Para eliminar el comentario de la base de datos
        protected void Eliminarcomentario(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int id_serie = Convert.ToInt32(Request.QueryString["id"]);

            int id_comentario = Convert.ToInt32(btn.CommandArgument.ToString());
            comentario.BorrarComentario(id_comentario);
            Response.Redirect("Serie.aspx?id=" + id_serie);
        }

    }
}