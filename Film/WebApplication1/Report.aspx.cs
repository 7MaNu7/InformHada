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

        protected void EnviarEmail(object sender, EventArgs e)
        {
            usuario = (FilmBiblio.UsuarioEN)Session["usuario"];
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            MailMessage mensaje = new MailMessage();

            try
            {
                MailAddress de_quien;

                if (usuario != null)
                {
                    de_quien = new MailAddress(usuario.Email, usuario.Usuario);
                }
                else
                {
                    de_quien = new MailAddress("desconocido@gmail.com", "desconocido");
                }

                MailAddress a_quien = new MailAddress("encaramorosb@gmail.com", "Encarna");
                mensaje.From = de_quien;

                mensaje.To.Add(a_quien);
                mensaje.Subject = "Report sobre InformaTV";
                String texto_report = TextBoxReport.Text;
                mensaje.Body = texto_report;
                smtpClient.EnableSsl = true;

                smtpClient.Credentials = new System.Net.NetworkCredential("jorgeazorin@gmail.com", "48720521N");
                smtpClient.Send(mensaje);
                LabelConfirmacion.Text = "Mensaje enviado";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                LabelConfirmacion.Text = "No se pudo enviar el mensaje. Inténtelo de nuevo en unos minutos";  
            }
        }
    }
}