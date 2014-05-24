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
            string id_serie = Request.QueryString["id1"];
            string id_capitulo = Request.QueryString["id2"];

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
                usuario = (FilmBiblio.UsuarioEN) Session["usuario"];
                imagen_user.ImageUrl = "/img/users/" + usuario.Id + ".jpg";
            }

            if (id_capitulo == null || id_serie==null)
            {
                
                Response.Redirect("Series.aspx");
            }
            else
            {
                LiteralComentar.Text = "Deja tu comentario";
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

            if (!Page.IsPostBack)
            {
                int id_ser = Convert.ToInt32(Request.QueryString["id1"]);
                int id_cap = Convert.ToInt32(Request.QueryString["id2"]);
                d = comentario.DameComentariosCapitulo(id_cap);
                ListViewComentarios.DataSource = d;
                if(d!=null)
                    ListViewComentarios.DataBind();
            }

        }

        protected void ComentarOnClick(object sender, EventArgs e)
        {
            usuario = (FilmBiblio.UsuarioEN)Session["usuario"];
            int id_capitulo = Convert.ToInt32(Request.QueryString["id2"]);
            int id_serie = Convert.ToInt32(Request.QueryString["id1"]);
            
            string texto = TextBoxComentario.Text;
            DateTime tomorrow = DateTime.Today.AddDays(0);

            comentarioEn.Usuario = usuario.Id;
            comentarioEn.Film = id_serie;
            comentarioEn.Texto = texto;
            comentarioEn.Fecha = tomorrow.ToString();
            comentarioEn.Capitulo = id_capitulo;
            comentarioEn.InsertarComentario();
            Response.Redirect("Capitulo.aspx?id1=" + id_serie+"&id2="+id_capitulo);
        }

        protected void mostrar(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int id_comentario = Convert.ToInt32(btn.ToolTip);
            if (usuario.Id != id_comentario)
                btn.Visible = false;
        }

        protected void Eliminarcomentario(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int id_capitulo = Convert.ToInt32(Request.QueryString["id2"]);
            int id_serie = Convert.ToInt32(Request.QueryString["id1"]);

            int id_comentario = Convert.ToInt32(btn.CommandArgument.ToString());
            comentario.BorrarComentario(id_comentario);
            Response.Redirect("Capitulo.aspx?id1=" + id_serie + "&id2=" + id_capitulo);
        }


    }
}