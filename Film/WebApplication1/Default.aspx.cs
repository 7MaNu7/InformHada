﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HyperLinkPeliculas.NavigateUrl = "Peliculas.aspx?";
            HyperLinkSeries.NavigateUrl = "Series.aspx";
            HyperLinkUsuario.NavigateUrl = "Usuario.aspx?par1=verUsuario";
            HyperLinkRegistro.NavigateUrl = "Login.aspx";
            HyperLinkAnadirPelicula.NavigateUrl = "AddEditPelicula.aspx?par1=anadirPelicula";
            HyperLinkAnadirSerie.NavigateUrl = "AddEditSerie.aspx?par1=anadirSerie";
            HyperLinkAbout.NavigateUrl = "About.aspx";
            HyperLinkReport.NavigateUrl = "Report.aspx";       
        }
    }
}
