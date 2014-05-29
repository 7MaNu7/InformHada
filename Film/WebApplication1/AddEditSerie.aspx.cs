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
                    Response.Redirect("Error.aspx");

                int id = Convert.ToInt32(Request.QueryString["id"]);
                if (id != 0)
                {
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
                    TextBoxTitulo.Visible = false;
                    caratula.ImageUrl = "/img/film/caratula/" + serie.Id + ".jpg";
                    portada.ImageUrl = "/img/film/portada/" + serie.Id + ".jpg";
                }
                else
                {
                    Page.Title = " Añadiendo serie";
                    LiteralTitulo.Visible = false;
                    BotonAddEdit.Text = "Añadir serie";
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

                Response.Redirect("serie.aspx?id=" + id_nuevo);
            }


        }
        
    }
}