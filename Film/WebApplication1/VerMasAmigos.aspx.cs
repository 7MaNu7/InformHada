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
    public partial class VerMasAmigos : System.Web.UI.Page
    {
        private DataSet d=new DataSet();
       // private FilmBiblio.UsuarioEN user = new FilmBiblio.UsuarioEN();
        private FilmBiblio.UsuarioEN usuario=new FilmBiblio.UsuarioEN();

        protected void Page_Load(object sender, EventArgs e)
        {
           // user=(FilmBiblio.UsuarioEN)Session["usuario"]; 
            int id = Convert.ToInt32(Request.QueryString["id"]);
            usuario.Id = id;
            usuario=usuario.DameUsuario();

            if (!Page.IsPostBack)
            {
                d = usuario.DameAmigos(0);
                ListViewAmigos.DataSource = d;
                ListViewAmigos.DataBind();
            }

            if (d.Tables[0].Rows.Count == 0)
                LiteralListaAmigos.Text = "La lista de amigos está vacia";
            else
                LiteralListaAmigos.Text = d.Tables[0].Rows.Count.ToString() + " amigos:";
        }

        protected void DataPagerProducts_PreRender(object sender, EventArgs e)
        {
          //  usuario = (FilmBiblio.UsuarioEN)Session["usuario"];
            int id = Convert.ToInt32(Request.QueryString["id"]);
            usuario.Id = id;
            usuario.DameUsuario();

            d = usuario.DameAmigos(0);
            ListViewAmigos.DataSource = d;
            ListViewAmigos.DataBind();
        }
    }
}