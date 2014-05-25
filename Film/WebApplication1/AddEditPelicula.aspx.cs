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
        private FilmBiblio.PeliculaEN pelicula = new FilmBiblio.PeliculaEN();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (Session["usuario"] == null)
                    Response.Redirect("Default.aspx");

                int id = Convert.ToInt32(Request.QueryString["id"]);
                if (id != 0)                                            //Para editar un film
                {
                    TextBoxTitulo.Visible = false;
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
                    caratula.ImageUrl = "/img/film/caratula/" + pelicula.Id + ".jpg";
                    portada.ImageUrl = "/img/film/portada/" + pelicula.Id + ".jpg";
                    BotonAddEdit.Text = "Guardar cambios";
                }
                else                                                    //Para añadir un film
                {
                    LiteralTitulo.Visible = false;
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

                    //int max = pelicula.MaximoId();
                    if (FileUploadControl.HasFile)
                    {
                        try
                        {
                            string filename = Path.GetFileName(FileUploadControl.FileName);
                            FileUploadControl.SaveAs(Server.MapPath("~/img/film/caratula/") + id + ".jpg");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    if (FileUpload1.HasFile)
                    {
                        try
                        {
                            string filename = Path.GetFileName(FileUpload1.FileName);
                            FileUpload1.SaveAs(Server.MapPath("~/img/film/portada/") + id + ".jpg");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    Response.Redirect("Pelicula.aspx?id=" + id);

                }
                else
                {
                    //Guardar datos y insert
                    pelicula.Titulo = TextBoxTitulo.Text;
                    pelicula.Director = TextBoxDirector.Text;
                    if (TextBoxAno.Text != "")
                        pelicula.Ano = Convert.ToInt32(TextBoxAno.Text);
                    pelicula.Sinopsis = TextBoxSinopsis.Text;
                    pelicula.Genero = TextBoxGenero.Text;
                    pelicula.Reparto = TextBoxReparto.Text;
                    pelicula.BandaSonora = TextBoxBandaSonora.Text;
                    pelicula.Trailer = TextBoxTrailer.Text;
                    pelicula.InsertarPelicula();

                    int id_nuevo = pelicula.MaximoId();

                    if (FileUpload1.HasFile)
                    {
                        try
                        {
                            string filename = Path.GetFileName(FileUpload1.FileName);
                            FileUpload1.SaveAs(Server.MapPath("~/img/film/portada/") + id_nuevo + ".jpg");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            string filename = Path.GetFileName(FileUpload1.FileName);
                            FileUpload1.SaveAs(Server.MapPath("~/img/film/portada/") + "00" + ".jpg");

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }


                    if (FileUploadControl.HasFile)
                    {
                        try
                        {
                            string filename = Path.GetFileName(FileUpload1.FileName);
                            FileUploadControl.SaveAs(Server.MapPath("~/img/film/caratula/") + id_nuevo + ".jpg");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            string filename = Path.GetFileName(FileUpload1.FileName);
                            FileUploadControl.SaveAs(Server.MapPath("~/img/film/caratula/") + "00" + ".jpg");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    Response.Redirect("Pelicula.aspx?id=" + id_nuevo);
            }
        }
    }
}