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
            String param1 = Request.QueryString["par1"];
            if (param1 == "verUsuario")
            {
                BotonEditar.Text = "Editar";
            }
            else if (param1 == "Registro")
            {
                BotonEditar.Text = "Registrarme";
            }
            else
            {
                BotonEditar.Visible = false;
            }
        }

        protected void BotonEditarOnClick(object sender, EventArgs e)
        {
            String param1 = Request.QueryString["par1"];
            Response.BufferOutput = true;
            if (param1 == "verUsuario")
            {
                Response.Redirect("AddEditUsuario.aspx?par1=editarUsuario");
            }
            else if (param1 == "Registro")
            {
                Response.Redirect("AddEditUsuario.aspx?par1=registrarUsuario");
            }
        
        }
    }
}