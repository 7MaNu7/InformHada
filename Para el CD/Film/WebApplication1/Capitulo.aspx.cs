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
    public partial class Capitulo : System.Web.UI.Page
    {
        FilmBiblio.CapituloEN capitulo = new FilmBiblio.CapituloEN();
        FilmBiblio.SerieEN serie = new FilmBiblio.SerieEN();
        private DataSet d = new DataSet();
        FilmBiblio.UsuarioEN usuario = new FilmBiblio.UsuarioEN();
        FilmBiblio.ComentarioEN comentarioEn = new FilmBiblio.ComentarioEN();
        FilmBiblio.ComentarioEN comentario = new FilmBiblio.ComentarioEN();

        protected void Page_Load(object sender, EventArgs e)
        {
            //cogemos de la url los respectivos id
            string id_serie = Request.QueryString["id1"];
            string id_capitulo = Request.QueryString["id2"];

            //se muestran las imagenes almacenadas en sus directorios
            caratula.ImageUrl = "/img/film/caratula/" + id_serie + ".jpg";
            fondo.ImageUrl = "/img/film/portada/" + id_serie + ".jpg";

            //la parte privada se muestra solo con usuarios logeados, Ej: comentar, editar...
            if (Session["usuario"] == null)
            {
                BotonEditar.Visible = false;
                LiteralComentar.Visible = false;
                BotonComentar.Visible = false;
                TextBoxComentario.Visible = false;
                BotonEditar.Visible = false;
                Panelcomentar.Visible = false;
            }
            else
            {
                //si esta logeado cogemos su imagen
                usuario = (FilmBiblio.UsuarioEN) Session["usuario"];
                imagen_user.ImageUrl = "/img/users/" + usuario.Id + ".jpg";
            }

            if (id_capitulo == null || id_serie==null)
            {
                //si se intenta acceder desde url sin ids se impide volviendo a la serie del supuesto capitulo
                Response.Redirect("Series.aspx");
            }
            else             //si son id validos
            {
                LiteralComentar.Text = "Deja tu comentario";
                serie.Id = Convert.ToInt32(id_serie);
                serie = serie.DameSerie();
                capitulo.Id = Convert.ToInt32(id_capitulo);
                capitulo = capitulo.DameCapitulo();

                //mostrar en pestaña capitulo 
                Page.Title = serie.Titulo + " - " + capitulo.Titulo;

                //direccion de volver a la serie del respectivo capitulo
                HyperLinkVolverSerie.NavigateUrl = "Serie.aspx?id=" + serie.Id;

                //al editar te mandara a editar este capitulo concreto
                BotonEditar.NavigateUrl = "AddEditCapitulo.aspx?id1=" + id_serie + "&id2="+id_capitulo;
                BotonReport.NavigateUrl = "Report.aspx";

                LiteralTitulo.Text = capitulo.Titulo.ToString();
                LiteralSerie.Text = serie.Titulo;
                LiteralTemporada.Text = capitulo.Temporada.ToString();
                LiteralNCapitulo.Text = capitulo.N_capitulo.ToString();
                LiteralSinopsis.Text = capitulo.Sinopsis.ToString();
            }

            if (!Page.IsPostBack)
            {
                //cogemos de la url los respectivos id
                int id_ser = Convert.ToInt32(Request.QueryString["id1"]);
                int id_cap = Convert.ToInt32(Request.QueryString["id2"]);

                //tambien se muestran los comentarios estes logeado o no
                d = comentario.DameComentariosCapitulo(id_cap);
                ListViewComentarios.DataSource = d;
                if(d!=null)
                    ListViewComentarios.DataBind();
            }

        }
        //evento al comentar
        protected void ComentarOnClick(object sender, EventArgs e)
        {
            usuario = (FilmBiblio.UsuarioEN)Session["usuario"];

            //cogemos de la url los respectivos id
            int id_capitulo = Convert.ToInt32(Request.QueryString["id2"]);
            int id_serie = Convert.ToInt32(Request.QueryString["id1"]);

            //cogemos el texto introducido del comentario 
            string texto = TextBoxComentario.Text;

            //guardamos la fecha actual (momento en el que se comenta)
            DateTime tomorrow = DateTime.Today.AddDays(0);

            //rellenamos las propiedades del comentario y se inserta
            comentarioEn.Usuario = usuario.Id;
            comentarioEn.Film = id_serie;
            comentarioEn.Texto = texto;
            comentarioEn.Fecha = tomorrow.ToString();
            comentarioEn.Capitulo = id_capitulo;
            comentarioEn.InsertarComentario();

            //tras comentar se refresca el capitulo con el comentario ya puesto
            Response.Redirect("Capitulo.aspx?id1=" + id_serie+"&id2="+id_capitulo);
        }

        //para que aparezca el boton eliminar comentario debe de ser un comentario tuyo
        protected void mostrar(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int id_comentario = Convert.ToInt32(btn.ToolTip);
            if (usuario.Id != id_comentario)
                btn.Visible = false;
        }

        //cuando pulsas a eliminar un comentario tuyo
        protected void Eliminarcomentario(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //cogemos de la url los respectivos ids
            int id_capitulo = Convert.ToInt32(Request.QueryString["id2"]);
            int id_serie = Convert.ToInt32(Request.QueryString["id1"]);

            int id_comentario = Convert.ToInt32(btn.CommandArgument.ToString());

            //borramos el comentario y refrescamos con comentario ya borrado
            comentario.BorrarComentario(id_comentario);
            Response.Redirect("Capitulo.aspx?id1=" + id_serie + "&id2=" + id_capitulo);
        }


    }
}