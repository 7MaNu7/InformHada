using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication1
{
    public partial class AddEditSerie : System.Web.UI.Page
    {
        private FilmBiblio.SerieEN serie = new FilmBiblio.SerieEN();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                    Response.Redirect("Default.aspx");

                int id = Convert.ToInt32(Request.QueryString["id"]);
                if (id != 0)
                {
                    serie.Id = id;
                    serie = serie.DameSerie();
                    LiteralTitulo.Text = serie.Titulo;
                    TextBoxDirector.Text = serie.Director;
                    TextBoxAno.Text = serie.Ano.ToString();
                    TextBoxGenero.Text = serie.Genero;
                    TextBoxSinopsis.Text = serie.Sinopsis;
                    TextBoxReparto.Text = serie.Reparto;
                    TextBoxBandaSonora.Text = serie.BandaSonora;
                    TextBoxTrailer.Text = serie.Trailer;
                    BotonAddEdit.Text = "Guardar cambios";
                }
                else
                {
                    BotonAddEdit.Text = "Añadir película";
                }
            }

        }

        protected void BotonAddEditOnClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            Response.BufferOutput = true;
            if (id != 0)
            {
                //Guardar datos y update
                serie.Id = id;
                serie = serie.DameSerie();
                serie.Director = TextBoxDirector.Text;
                serie.Ano = Convert.ToInt32(TextBoxAno.Text);
                serie.Sinopsis = TextBoxSinopsis.Text;
                serie.Genero = TextBoxGenero.Text;
                serie.Reparto = TextBoxReparto.Text;
                serie.BandaSonora = TextBoxBandaSonora.Text;
                serie.Trailer = TextBoxTrailer.Text;
                serie.UpdateSerie();
            //    
            }
            else
            {
                //Guardar datos y insert
                serie.Director = TextBoxDirector.Text;
                serie.Ano = int.Parse(TextBoxAno.Text);
                serie.Sinopsis = TextBoxSinopsis.Text;
                serie.Genero = TextBoxGenero.Text;
                serie.Reparto = TextBoxReparto.Text;
                serie.BandaSonora = TextBoxBandaSonora.Text;
                serie.Trailer = TextBoxTrailer.Text;
                serie.InsertarSerie();
            }
            int max = serie.MaximoId();
            if (FileUploadControl.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUploadControl.FileName);
                    if (id == 0)
                        FileUploadControl.SaveAs(Server.MapPath("~/img/film/caratula/") + max + 1 + ".jpg");
                    else
                        FileUploadControl.SaveAs(Server.MapPath("~/img/film/caratula/") + serie.Id + ".jpg");
                    //   StatusLabel.Text = "Upload status: File uploaded!";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //  StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            if (FileUpload1.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUpload1.FileName);
                    FileUpload1.SaveAs(Server.MapPath("~/img/film/portada/") + serie.Id + ".jpg");
                    //   StatusLabel.Text = "Upload status: File uploaded!";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //  StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            Response.Redirect("serie.aspx?id=" + id);
        }
        
    }
}