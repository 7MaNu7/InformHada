using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HyperLinkAddPelicula.NavigateUrl="AddEditPelicula.aspx?par1=anadirPelicula";
            HyperLinkAddSerie.NavigateUrl="AddEditSerie.aspx?par1=anadirSerie";
            HyperLinkEditUsuario.NavigateUrl="AddEditUsuario.aspx?par1=editarUsuario";
            
            String param1 = Request.QueryString["par1"];
            if (param1 == "verUsuario")
            {
                BotonEditar.Text = "Editar";
            }
            else
            {
                BotonEditar.Visible = false;
            }
        }

        protected void EliminarUsuario(object sender, EventArgs e)
        {
            //id??
            HyperLinkEliminarUsuario.NavigateUrl = "Default.aspx";
        }

        protected void BotonEditarOnClick(object sender, EventArgs e)
        {
            String param1 = Request.QueryString["par1"];
            Response.BufferOutput = true;
            if (param1 == "verUsuario")
            {
                Response.Redirect("AddEditUsuario.aspx?par1=editarUsuario");
            }
        
        }
    }
}