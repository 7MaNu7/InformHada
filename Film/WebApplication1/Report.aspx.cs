using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;

namespace WebApplication1
{
    public partial class Report : System.Web.UI.Page
    {
        FilmBiblio.UsuarioEN usuario = new FilmBiblio.UsuarioEN();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Para enviar el email de la queja, consulta o sugerencia
        protected void EnviarEmail(object sender, EventArgs e)
        {
            //Texto a enviar por el usuario
            String texto_report = TextBoxReport.Text;

            //Si no se ha escrito ningún texto, mensaje indicándolo y no se envia el email
            if (texto_report == "")
            {
                LabelConfirmacion.Text = "¡El cuerpo del mensaje está vacío, escriba su queja, consulta o sugerencia y pulse en Enviar.";
                return;
            }

            //Datos del usuario si está registrado
            usuario = (FilmBiblio.UsuarioEN)Session["usuario"];
            //Servidor, en este caso gmail con el puerto 587
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            MailMessage mensaje = new MailMessage();

            try
            {
                MailAddress de_quien;

                if (usuario != null)
                {
                    //Si está registrado aparecerá como email de envio el del usuario
                    de_quien = new MailAddress(usuario.Email, usuario.Usuario);
                }
                else
                {
                    //Si no está registrado, es desconocido
                    de_quien = new MailAddress("desconocido@gmail.com", "desconocido");
                }

                //Se envia al correo oficial de la aplicación
                MailAddress a_quien = new MailAddress("informhada@gmail.com", "InformaTV");


                mensaje.From = de_quien;//Solo viene de una persona
                mensaje.To.Add(a_quien);//Solo va destinado al correo oficial de la aplicación
                mensaje.Subject = "Report sobre InformaTV";//El asunto
                mensaje.Body = texto_report;//El texto del correo es lo que el usuario ha escrito en el textbox
                smtpClient.EnableSsl = true;//Para mayor seguridad

                //Un email y su contraseña desde los cuales se envia realmente el correo (aunque luego aparezca  que es el usuario)
                smtpClient.Credentials = new System.Net.NetworkCredential("informhada@gmail.com", "eduardomanteca");
                smtpClient.Send(mensaje);

                TextBoxReport.Text = "";
                LabelConfirmacion.Text = "Mensaje enviado";
            }
            catch (Exception ex)
            {
                //Si hubo errores al enviar
                Console.WriteLine(ex.Message);
                LabelConfirmacion.Text = "No se pudo enviar el mensaje. Inténtelo de nuevo en unos minutos";  
            }
        }
    }
}