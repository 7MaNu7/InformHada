using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AddEditSerie : System.Web.UI.Page
    {
        private FilmBiblio.SerieEN Serie = new FilmBiblio.SerieEN();

        protected void Page_Load(object sender, EventArgs e)
        {
            String param1 = Request.QueryString["par1"];
            if (param1 == "editarSerie")
            {
                BotonAddEdit.Text = "Guardar cambios";
            }
            else if (param1 == "anadirSerie")
            {
                BotonAddEdit.Text = "Añadir serie";
            }
            else
            {
                BotonAddEdit.Visible = false;
            }

        }

        protected void BotonAddEditOnClick(object sender, EventArgs e)
        {
            String param1 = Request.QueryString["par1"];
            Response.BufferOutput = true;
            if (param1 == "editarSerie")
            {
                //Guardar datos y update
                Serie.Titulo = TextBoxTitulo.Text;
                Serie.Director = TextBoxDirector.Text;
                Serie.Ano = int.Parse(TextBoxAno.Text);
                Serie.Sinopsis = TextBoxSinopsis.Text;
                Serie.Genero = TextBoxGenero.Text;
                Serie.Reparto = TextBoxReparto.Text;
                Serie.BandaSonora = TextBoxBandaSonora.Text;
                Serie.Trailer = TextBoxTrailer.Text;
                Serie.UpdateSerie();
            }
            else if (param1 == "anadirSerie")
            {
                //Guardar datos y insert
                Serie.Titulo = TextBoxTitulo.Text;
                Serie.Director = TextBoxDirector.Text;
                Serie.Ano = Convert.ToInt32(TextBoxAno.Text);
                Serie.Sinopsis = TextBoxSinopsis.Text;
                Serie.Genero = TextBoxGenero.Text;
                Serie.Reparto = TextBoxReparto.Text;
                Serie.BandaSonora = TextBoxBandaSonora.Text;
                Serie.Trailer = TextBoxTrailer.Text;
                Serie.InsertarSerie();
            }
        }

        
    }
}