<%@ Page Title="Acerca de nosotros" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="WebApplication1.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/About.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent"> 

       <div class="contenido">

        <!-- CABECERA DE LA PELICULA -->
        <div class="cabecera_about">
            <div class="portada_about" style="background-image:url('');">
                <img class="fondoblurred" src="http://t3.gstatic.com/images?q=tbn:ANd9GcQExlQNgwgAIZb_PS-hrpzUKe4fSpVLuXqrJrrdV-Rt1dcc41PQ" alt="fotou_portada"/>
            </div>
             <div class="info_cabecera">
                <h2> Acerca de nosotros </h2>
             </div>
         </div>

        <div class="contenido_about">

            <div class="contenido_about_d">
                <h2>
                    Sobre la página
                </h2>
                <p> El propósito de esta página es la de una aplicación web a la que puedan acceder las distintas personas para consultar información sobre
                    películas, series y los capítulos de las distintas. </p>
                <p> Además, si se es usuario, la persona puede añadir nuevas películas, series o editar su información.  </p>
                <p> Contará con un un perfil propio, tendrá su lista de amigos, etc. </p>
                <h2>
                    Contacto
                </h2>
                <p>
                    654789657
                </p>
                <p>
                    film@gmail.com
                </p>


            </div>
        </div>
    </div>

</asp:Content>
