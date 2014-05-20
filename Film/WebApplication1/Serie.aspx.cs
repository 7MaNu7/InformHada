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
    public partial class Serie : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            FilmBiblio.SerieEN serie = new FilmBiblio.SerieEN();
            if (Session["usuario"] == null)
            {
                BotonEditar.Visible = false;
            }

            String id = Request.QueryString["id"];
            if (id == null)
            {
                Response.Redirect("series.aspx");
            }
            else
            {
                
                serie.Id = Convert.ToInt32(id);

                BotonEditar.NavigateUrl = "AddEditserie.aspx?id=" + id;
                BotonReport.NavigateUrl = "Report.aspx";

                serie = serie.DameSerie();
                titulo.Text = serie.Titulo;
                musica.Text = serie.BandaSonora;
                sinopsis.Text = serie.Sinopsis;
                trailer.Text = serie.Trailer;
                puntuacion.Text = serie.Puntuacion.ToString();
                reparto.Text = serie.Reparto.ToString();
                ano.Text = serie.Ano.ToString();
                caratula.ImageUrl = serie.Caratula.ToString();
                fondo.ImageUrl = serie.Portada.ToString();
            }
              FilmBiblio.CapituloEN capitulo = new FilmBiblio.CapituloEN();
              Label lblTitle;
              Label lblContent;
              DataTable dt = new DataTable();
              AjaxControlToolkit.AccordionPane pn;
                DataSet d=new DataSet();
                d = capitulo.DameCapitulos(serie.Id);
              for (int i = 1; i <=  capitulo.Temporadas(serie.Id); i++)
              {
                  dt = d.Tables[0];
                 //dt.DefaultView.RowFilter = "temporada = " + i.ToString();
                  pn = new AjaxControlToolkit.AccordionPane();
                  pn.ID = "Pane" + i;
                  lblTitle = new Label();
                  lblContent = new Label();
                  lblTitle.Text = "<h3 class='temporada_nombre'>Temporada " + i.ToString() + "</h3>";
                  string contenido="";
                  foreach (DataRow dr in dt.Rows)
                  {
                      if (dr["temporada"].ToString() == i.ToString())
                          contenido += "<a class='capitulo_nombre' href='Capitulo.aspx?id=" + dr["id"].ToString() + "'>" + dr["titulo"].ToString() + "</a>";
                  }
                  
                  lblContent = new Label();


                  lblContent.Text = contenido;
                  pn.ContentContainer.Controls.Add(lblContent);
                  pn.HeaderContainer.Controls.Add(lblTitle);
                  pn.ContentContainer.Controls.Add(lblContent);
                  Accordion1.Panes.Add(pn);
              }
        }
    }
}