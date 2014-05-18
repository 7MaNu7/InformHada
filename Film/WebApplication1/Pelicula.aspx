<%@ Page Title="Divergente" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Pelicula.aspx.cs" Inherits="WebApplication1.Pelicula" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Pelicula.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div class="contenido">

       <!-- CABECERA DE LA PELICULA  -->
        <div class="cabecera_pelicula">
            <div class="portada_serie" style="background-image:url('');">
                <asp:Image ID="fondo" CssClass="fondoblurred" runat="server" />           
            </div>
            <asp:Image ID="caratula" CssClass="caratula" runat="server" />
             <div class="info_cabecera">
                <h2><asp:Literal ID="titulo" runat="server"></asp:Literal></h2>
                <p>Director: <asp:Literal ID="director" runat="server"></asp:Literal></p>
                <p>Soundtrack: <asp:Literal ID="musica" runat="server"></asp:Literal></p>
                <p>Año: <asp:Literal ID="ano" runat="server"></asp:Literal></p>
             </div>
             <div class="puntuacion">
                <asp:Literal ID="puntuacion" runat="server"></asp:Literal>
             </div>
         </div>

        <div class="pelicula_contenido">
            <div class="pelicula_contenido_i">
              <asp:HyperLink ID="BotonEditar" CssClass="anadir" runat="server" EnableViewState="false" Text="Editar" />
                <asp:HyperLink ID="BotonReport" CssClass="reportar" runat="server" Text="Reportar error" />
                        <!--aa sp:Rating ID="Rating1" runat="servr" 
                    CurrentRating="2"
                    MaxRating="5"
                    StarCssClass="ratingStar"
                   WaitingStarCssClass="waitingstar" FilledStarCssClass="shiningstar"
            EmptyStarCssClass="blankstar"

                     -->
     


            </div>
            <div class="pelicula_contenido_d">
               <h2>Sinopsis</h2>
               <p><asp:Literal ID="sinopsis" runat="server"></asp:Literal></p>

               <h2>Reparto</h2>
               <p><asp:Literal ID="reparto" runat="server"></asp:Literal></p>
            
                <h2>Trailer</h2>
                <iframe width="761" height="415" src="//www.youtube.com/embed/<asp:Literal ID="trailer" runat="server"></asp:Literal>" frameborder="0" allowfullscreen></iframe>
            </div>
        </div>
    </div>
</asp:Content>
