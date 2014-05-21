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

namespace WebApplication1
{
    public partial class Series : System.Web.UI.Page
    {
        private DataSet d = new DataSet();
        private FilmBiblio.SerieEN serie = new FilmBiblio.SerieEN();

        protected void Page_Load(object sender, EventArgs e)
        {

            HyperLinkAddSerie.NavigateUrl = "AddEditPelicula.aspx?par1=anadirPelicula";

            if (Session["usuario"] == null)
                HyperLinkAddSerie.Visible = false;

            if (!Page.IsPostBack)
            {
                d = serie.DameSeries();
                ListViewSeries.DataSource = d;
                ListViewSeries.DataBind();
            }
        }

        protected void DataPagerProducts_PreRender(object sender, EventArgs e)
        {
            d = serie.DameSeries();
            ListViewSeries.DataSource = d;
            ListViewSeries.DataBind();
        }
    }
}