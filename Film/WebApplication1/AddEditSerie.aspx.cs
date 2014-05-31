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
                //si se intenta acceder a editar sin estar logeado se impide
                if (Session["usuario"] == null)
                    Response.Redirect("Error.aspx");

                int id = Convert.ToInt32(Request.QueryString["id"]);

                if (id != 0)                            //para editar un film
                {
                    //se rellenan los campos por defecto con lo anterior guardado
                    serie.Id = id;
                    serie = serie.DameSerie();

                    Page.Title = "Editando " + serie.Titulo;

                    LiteralTitulo.Text = serie.Titulo;
                    TextBoxDirector.Text = serie.Director;
                    TextBoxAno.Text = serie.Ano.ToString();
                    TextBoxGenero.Text = serie.Genero;
                    TextBoxSinopsis.Text = serie.Sinopsis;
                    TextBoxReparto.Text = serie.Reparto;
                    TextBoxBandaSonora.Text = serie.BandaSonora;
                    TextBoxTrailer.Text = serie.Trailer;
                    BotonAddEdit.Text = "Guardar cambios";
                    //el titulo no se modifica lo demás si
                    TextBoxTitulo.Visible = false;
                    caratula.ImageUrl = "/img/film/caratula/" + serie.Id + ".jpg";
                    portada.ImageUrl = "/img/film/portada/" + serie.Id + ".jpg";
                }
                else                                        //Para añadir un film
                {
                    Page.Title = " Añadiendo serie";
                    //en lugar de literal para mostrar se usa el textbox para añadir el titulo
                    LiteralTitulo.Visible = false;
                    BotonAddEdit.Text = "Añadir serie";
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

                //caratula de serie cambiada
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
                //fondo de serie cambiado
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
                //en acabar se redirige a la serie recien editada
                Response.Redirect("serie.aspx?id=" + id);

            }
            else
            {
                //Guardar datos y insert
                serie.Titulo = TextBoxTitulo.Text;
                serie.Director = TextBoxDirector.Text;
                if (TextBoxAno.Text != "")
                    serie.Ano = Convert.ToInt32(TextBoxAno.Text);
                serie.Sinopsis = TextBoxSinopsis.Text;
                serie.Genero = TextBoxGenero.Text;
                serie.Reparto = TextBoxReparto.Text;
                serie.BandaSonora = TextBoxBandaSonora.Text;
                serie.Trailer = TextBoxTrailer.Text;
                serie.InsertarSerie();

                int id_nuevo = serie.MaximoId();

                //caratula de serie añadida
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
                else
                {
                    try
                    {
                        //guardamos el archivo en el directorio especificado
                        string filename = Path.GetFileName(FileUpload1.FileName);
                        FileUpload1.SaveAs(Server.MapPath("~/img/film/portada/") + "00" + ".jpg");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                //caratula de serie añadida
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
                else
                {
                    try
                    {
                        //guardamos el archivo en el directorio especificado
                        string filename = Path.GetFileName(FileUpload1.FileName);
                        FileUploadControl.SaveAs(Server.MapPath("~/img/film/caratula/") + "00" + ".jpg");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                //en acabar se redirige a la serie recien añadida
                Response.Redirect("serie.aspx?id=" + id_nuevo);
            }


        }
        
    }
}