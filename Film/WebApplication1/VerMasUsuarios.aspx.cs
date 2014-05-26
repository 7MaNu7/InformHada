﻿using System;
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
            if (Session["usuario"] == null)
                Response.Redirect("Error.aspx");

            usuario=(FilmBiblio.UsuarioEN)Session["usuario"]; 
            /*int id = Convert.ToInt32(Request.QueryString["id"]);
            usuario.Id = id;
            usuario=usuario.DameUsuario();*/

            if (!Page.IsPostBack)
            {
                d = usuario.DameUsuariosQuizasConozca(0);
                ListViewQuizasConozcas.DataSource = d;
                ListViewQuizasConozcas.DataBind();
            }

            if (d.Tables[0].Rows.Count == 0)
                LiteralListaAmigos.Text = "no se han encontrado sugerencias, inténtelo más tarde";
            else
                LiteralListaAmigos.Text = d.Tables[0].Rows.Count.ToString() + " usuarios:";
        }

        protected void DataPagerProducts_PreRender(object sender, EventArgs e)
        {
            usuario = (FilmBiblio.UsuarioEN)Session["usuario"];
          /*  int id = Convert.ToInt32(Request.QueryString["id"]);
            usuario.Id = id;
            usuario.DameUsuario();*/

            d = usuario.DameUsuariosQuizasConozca(0);
            ListViewQuizasConozcas.DataSource = d;
            ListViewQuizasConozcas.DataBind();
        }
    }
}