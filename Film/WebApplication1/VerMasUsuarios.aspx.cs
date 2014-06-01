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
using System.Windows.Forms;

namespace WebApplication1
{
    public partial class VerMasUsuarios : System.Web.UI.Page
    {
        private DataSet d=new DataSet();
        //private FilmBiblio.UsuarioEN user = new FilmBiblio.UsuarioEN();
        private FilmBiblio.UsuarioEN usuario=new FilmBiblio.UsuarioEN();

        protected void Page_Load(object sender, EventArgs e)
        {
            //si no estas logeado no se permite
            if (Session["usuario"] == null)
                Response.Redirect("Error.aspx");

            usuario=(FilmBiblio.UsuarioEN)Session["usuario"]; 

        }
        //paginacion de sugerencias
        protected void DataPagerProducts_PreRender(object sender, EventArgs e)
        {
            usuario = (FilmBiblio.UsuarioEN)Session["usuario"];

            d = usuario.DameUsuariosQuizasConozca(0);
            ListViewQuizasConozcas.DataSource = d;
             ListViewQuizasConozcas.DataBind();

             //cantidad de sugerencias
             if (d.Tables[0].Rows.Count == 0)
                 LiteralListaAmigos.Text = "no se han encontrado sugerencias, inténtelo más tarde";
             else
                 LiteralListaAmigos.Text = d.Tables[0].Rows.Count.ToString() + " usuario/s:";
        }
    }
}