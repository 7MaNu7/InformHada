<%@ Page Title="Añadir capitulo" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="AddEditCapitulo.aspx.cs" Inherits="WebApplication1.AddCapitulo" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Serie.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div class="contenido">

         <!-- CABECERA DEL CAPITULO  -->
        <div class="cabecerausuario">
            <div class="fondoblurreddiv" style="background-image:url('');">
                <img class="fondoblurred" src="http://hdwpapers.com/download/vikings_tv_desktop_wallpaper-1920x1080.jpg" alt="fotou_portada"/>
            </div>
             <img class="caratula" src="http://pics.filmaffinity.com/Vikingos_Vikings_Serie_de_TV-616055151-large.jpg" alt="fotou_perfil"/>
             <div class="infocabecera">
                <h2> <asp:TextBox ID="TextBoxTitulo" runat="server"  Font-Size="1.5em"  style="width:616px">Título del capítulo</asp:TextBox> </h2>
                <p>Director: Michael Hirst</p>
                <p>Soundtrack: Hans Zimmer</p>
                <p>Año: 2013</p>
             </div>
         </div>
        

        <div class="pelicula_contenido">
            <div class="pelicula_contenido_i">
                
            </div>
            <div class="pelicula_contenido_d">
               <h2>Sinopsis</h2>
               <p> <asp:TextBox ID="TextBox4" runat="server" TextAlign = HorizontalAlignment.Left style="height:131px; width:945px;">Escriba la sinopsis del capítulo de la serie aquí</asp:TextBox> </p>

               <div class="volver_serie" style="float:right;">
                <p> <a id="A1" runat="server" href="~/Serie.aspx"> Volver a la serie </a> </p>
               </div>
            </div>


    </div>
</asp:Content>
