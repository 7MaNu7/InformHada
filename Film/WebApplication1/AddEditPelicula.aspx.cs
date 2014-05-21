using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication1
{
    public partial class AddEditPelicula : System.Web.UI.Page
    {
        private FilmBiblio.PeliculaEN pelicula= new FilmBiblio.PeliculaEN();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                    Response.Redirect("Default.aspx");

                int id = Convert.ToInt32(Request.QueryString["id"]);
                if (id != 0)
                {
                    pelicula.Id = id;
                    pelicula = pelicula.DamePelicula();
                    LiteralTitulo.Text = pelicula.Titulo;
                    TextBoxDirector.Text = pelicula.Director;
                    TextBoxAno.Text = pelicula.Ano.ToString();
                    TextBoxGenero.Text = pelicula.Genero;
                    TextBoxSinopsis.Text = pelicula.Sinopsis;
                    TextBoxReparto.Text = pelicula.Reparto;
                    TextBoxBandaSonora.Text = pelicula.BandaSonora;
                    TextBoxTrailer.Text = pelicula.Trailer;
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
            if (id!=0)
            {
                //Guardar datos y update
                pelicula.Id = id;
                pelicula = pelicula.DamePelicula();
                pelicula.Director = TextBoxDirector.Text;
                pelicula.Ano = Convert.ToInt32(TextBoxAno.Text);
                pelicula.Sinopsis = TextBoxSinopsis.Text;
                pelicula.Genero = TextBoxGenero.Text;
                pelicula.Reparto = TextBoxReparto.Text;
                pelicula.BandaSonora = TextBoxBandaSonora.Text;
                pelicula.Trailer = TextBoxTrailer.Text;
                pelicula.UpdatePelicula();
                Response.Redirect("Pelicula.aspx?id=" + id);

            }
            else
            {
                //Guardar datos y insert
                pelicula.Director = TextBoxDirector.Text;
                pelicula.Ano = int.Parse(TextBoxAno.Text);
                pelicula.Sinopsis = TextBoxSinopsis.Text;
                pelicula.Genero = TextBoxGenero.Text;
                pelicula.Reparto = TextBoxReparto.Text;
                pelicula.BandaSonora = TextBoxBandaSonora.Text;
                pelicula.Trailer = TextBoxTrailer.Text;
                pelicula.InsertarPelicula();
            }
            int max = pelicula.MaximoId();
            if (FileUploadControl.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUploadControl.FileName);
                    if (id==0)
                        FileUploadControl.SaveAs(Server.MapPath("~/img/film/caratula/") + max+1 + ".jpg");
                    else
                        FileUploadControl.SaveAs(Server.MapPath("~/img/film/caratula/") + pelicula.Id + ".jpg");
                 //   StatusLabel.Text = "Upload status: File uploaded!";
                }
                catch (Exception ex)
                {
                  //  StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            if (FileUpload1.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUpload1.FileName);
                    FileUpload1.SaveAs(Server.MapPath("~/img/film/portada/") + pelicula.Id + ".jpg");
                    //   StatusLabel.Text = "Upload status: File uploaded!";
                }
                catch (Exception ex)
                {
                    //  StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }

       
    }
}