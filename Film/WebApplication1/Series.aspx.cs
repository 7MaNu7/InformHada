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
            //al darle a añadir nos manda a la pagina de añadir
            HyperLinkAddSerie.NavigateUrl = "AddEditSerie.aspx";

            //solo podras añadir series estando logeado
            if (Session["usuario"] == null)
                HyperLinkAddSerie.Visible = false;

            //mostrar las series de la bd
            if (!Page.IsPostBack)
            {
                d = serie.DameSeries();
                ListViewSeries.DataSource = d;
                ListViewSeries.DataBind();
            }
        }
        //paginacion para el listview de las series
        protected void DataPagerProducts_PreRender(object sender, EventArgs e)
        {
            d = serie.DameSeries();
            ListViewSeries.DataSource = d;
            ListViewSeries.DataBind();
        }
    }
}