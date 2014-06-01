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
                //si se intenta acceder a editar sin estar logeado se impide
                if (Session["usuario"] == null)
                    Response.Redirect("Error.aspx");

                int id = Convert.ToInt32(Request.QueryString["id"]);
                if (id != 0)                                            //Para editar un film
                {
                    //el titulo no se modifica lo demás si
                    TextBoxTitulo.Visible = false;
                    pelicula.Id = id;
                    pelicula = pelicula.DamePelicula();

                    Page.Title = "Editando " + pelicula.Titulo;

                    //se coge por defecto en los campos toda la info guardada de la pelicula

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
                    Page.Title = "Añadiendo película";

                    //en lugar de literal para mostrar se usa el textbox para añadir el titulo
                    LiteralTitulo.Visible = false;
                    BotonAddEdit.Text = "Añadir película";
                }
            }

        }
        //evento asociado al añadir o editar pelicula
        protected void BotonAddEditOnClick(object sender, EventArgs e)
        {
            //cogemos de la url el respectivo id
            int id = Convert.ToInt32(Request.QueryString["id"]);
            Response.BufferOutput = true;
            
                if (id != 0)
                {
                    //Guardar datos y update
                    pelicula.Id = id;
                    pelicula = pelicula.DamePelicula();
                    pelicula.Director = TextBoxDirector.Text;
                    if (TextBoxAno.Text == "" || TextBoxAno.Text == null)
                        TextBoxAno.Text = "0";
                    pelicula.Ano = Convert.ToInt32(TextBoxAno.Text);
                    pelicula.Sinopsis = TextBoxSinopsis.Text;
                    pelicula.Genero = TextBoxGenero.Text;
                    pelicula.Reparto = TextBoxReparto.Text;
                    pelicula.BandaSonora = TextBoxBandaSonora.Text;
                    pelicula.Trailer = TextBoxTrailer.Text;

                    pelicula.UpdatePelicula();

                    //caratula de pelicula cambiada
                    if (FileUploadControl.HasFile)
                    {
                        try
                        {
                            //guardamos el archivo en el directorio especificado
                            string filename = Path.GetFileName(FileUploadControl.FileName);
                            FileUploadControl.SaveAs(Server.MapPath("~/img/film/caratula/") + id + ".jpg");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    //fondo de pelicula cambiado
                    if (FileUpload1.HasFile)
                    {
                        try
                        {
                            //guardamos el archivo en el directorio especificado
                            string filename = Path.GetFileName(FileUpload1.FileName);
                            FileUpload1.SaveAs(Server.MapPath("~/img/film/portada/") + id + ".jpg");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    //al acabar redirigimos a la pelicula recien editada
                    Response.Redirect("Pelicula.aspx?id=" + id);

                }
                else
                {
                    //Guardar datos e insert
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

                    //fondo de pelicula añadido
                    if (FileUpload1.HasFile)
                    {
                        try
                        {
                            //guardamos el archivo en el directorio especificado
                            string filename = Path.GetFileName(FileUpload1.FileName);
                            FileUpload1.SaveAs(Server.MapPath("~/img/film/portada/") + id_nuevo + ".jpg");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    //caratula de pelicula añadida
                    if (FileUploadControl.HasFile)
                    {
                        try
                        {
                            //guardamos el archivo en el directorio especificado
                            string filename = Path.GetFileName(FileUpload1.FileName);
                            FileUploadControl.SaveAs(Server.MapPath("~/img/film/caratula/") + id_nuevo + ".jpg");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    //en acabar se redirige a la pelicula recien añadida
                    Response.Redirect("Pelicula.aspx?id=" + id_nuevo);
            }
        }
    }
}