﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AddCapitulo : System.Web.UI.Page
    {

        FilmBiblio.CapituloEN capitulo = new FilmBiblio.CapituloEN();
        FilmBiblio.SerieEN serie = new FilmBiblio.SerieEN();

        protected void Page_Load(object sender, EventArgs e)
        {
            string id_capitulo = Request.QueryString["id2"];
            string id_serie = Request.QueryString["id1"];

            if (Session["usuario"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            if (id_capitulo == null && id_serie == null)
            {
                Response.Redirect("Series.aspx");
            }
            else
            {
                if (id_capitulo != null)
                {
                    capitulo.Id = Convert.ToInt32(id_capitulo);
                    capitulo = capitulo.DameCapitulo();
                }
                else
                {
                
                }

                serie.Id = Convert.ToInt32(id_serie);
                serie = serie.DameSerie();

                HyperLinkEditarCapitulo.Visible = false;
                HyperLinkVolverSerie.NavigateUrl = "Serie.aspx?id=" + serie.Id;

                if (!Page.IsPostBack)
                {
                    if (id_capitulo == null)
                    {
                        //Añadiendo capitulo
                        BotonAddEdit.Text = "Añadir";
                        TextBoxTitulo.Text = "Titulo del capítulo";
                        LiteralSerie.Text = serie.Titulo.ToString();
                        TextBoxTemporada.Text = "Temporada a la que pertenece el capítulo";
                        TextBoxNCapitulo.Text = "Número del capítulo";
                        TextBoxSinopsis.Text = "Descripción sobre el capítulo";
                    }
                    else
                    {
                        //Editar capítulo
                        BotonAddEdit.Text = "Guardar cambios";
                        TextBoxTitulo.Text = capitulo.Titulo.ToString();
                        LiteralSerie.Text = serie.Titulo.ToString();
                        TextBoxTemporada.Text = capitulo.Temporada.ToString();
                        TextBoxNCapitulo.Text = capitulo.N_capitulo.ToString();
                        TextBoxSinopsis.Text = capitulo.Sinopsis.ToString();
                        TextBoxTitulo.Enabled = false;
                        TextBoxTemporada.Enabled = false;
                        TextBoxNCapitulo.Enabled = false;
                    }
                
                }

                
            }
        }

        protected void BotonAddEditOnClick(object sender, EventArgs e)
        {
            string id_capitulo = Request.QueryString["id2"];
            string id_serie = Request.QueryString["id1"];

            if (id_capitulo != null)
            {
                capitulo.Id = Convert.ToInt32(id_capitulo);
                capitulo = capitulo.DameCapitulo();
                BotonAddEdit.Text = "Guardar cambios";
            }

            serie.Id = Convert.ToInt32(id_serie);
            serie = serie.DameSerie();

            //Editar o Añadir capitulo
            capitulo.Titulo = TextBoxTitulo.Text;
            capitulo.Temporada = Convert.ToInt32(TextBoxTemporada.Text);
            capitulo.N_capitulo = Convert.ToInt32(TextBoxNCapitulo.Text);
            capitulo.Sinopsis = TextBoxSinopsis.Text;
            capitulo.Serie = Convert.ToInt32(id_serie);

            if (id_capitulo == null)
                capitulo.Id = capitulo.InsertarCapitulo();
            else
                capitulo.UpdateCapitulo();
            
            Response.Redirect("Capitulo.aspx?id1=" + id_serie+"&id2="+capitulo.Id);
        }
    }
}