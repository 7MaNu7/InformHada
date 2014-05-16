<%@ Page Title="Divergente" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Pelicula.aspx.cs" Inherits="WebApplication1.Pelicula" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>



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
                <h2><asp:Literal ID="Titlo" runat="server"></asp:Literal> </h2>
                <p><asp:Literal ID="Director" runat="server"></asp:Literal></p>
                <p><asp:Literal ID="Musica" runat="server"></asp:Literal></p>
                <p><asp:Literal ID="Ano" runat="server"></asp:Literal></p>
             </div>
             <div class="puntuacion">
                <asp:Literal ID="Puntuacion" runat="server"></asp:Literal>
             </div>
         </div>

        <div class="pelicula_contenido">
            <div class="pelicula_contenido_i">
              <asp:HyperLink ID="ButtonEdit" CssClass="anadir" runat="server" EnableViewState="false" Text="Editar" />
                <asp:HyperLink ID="ButtonEdit2" CssClass="reportar" runat="server" Text="Reportar error" />
               
                <asp:Rating ID="Rating1" runat="server" 
                CurrentRating="2"
                MaxRating="5"
                StarCssClass="ratingStar"
               WaitingStarCssClass="waitingstar" FilledStarCssClass="shiningstar"
        EmptyStarCssClass="blankstar"

                 >

                </asp:Rating>

            </div>
            <div class="pelicula_contenido_d">
               <h2>Sinopsis</h2>
               <p><asp:Literal ID="Sinopsis" runat="server"></asp:Literal></p>

               <h2>Reparto</h2>
               <p><asp:Literal ID="Reparto" runat="server"></asp:Literal></p>
            
                <h2>Trailer</h2>
                <iframe width="761" height="415" src="//www.youtube.com/embed/<asp:Literal ID="Video" runat="server"></asp:Literal>" frameborder="0" allowfullscreen></iframe>
            </div>
        </div>
    </div>
</asp:Content>
