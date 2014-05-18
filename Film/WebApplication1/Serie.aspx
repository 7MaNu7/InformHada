<%@ Page Title="Vikings" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Serie.aspx.cs" Inherits="WebApplication1.Serie" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Serie.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div class="contenido">

        <!-- CABECERA DE LA SERIE  -->
        <div class="cabecera_serie">
            <div class="portada_serie" style="background-image:url('');">
                <img class="fondoblurred" src="http://hdwpapers.com/download/vikings_tv_desktop_wallpaper-1920x1080.jpg" alt="fotou_portada"/>
            </div>
             <img class="caratula" src="http://pics.filmaffinity.com/Vikingos_Vikings_Serie_de_TV-616055151-large.jpg" alt="fotou_perfil"/>
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
                        
                <h2>Capitulos - <span style="
                                background: rgba(195, 195, 199, 0.44);
                                font-size: 15px;
                                vertical-align: middle;
                                cursor: pointer;
                                padding: 4px 12px 4px 12px;
                                border-radius: 4px;">AÑADIR</span>
                </h2>
                <div class="Serie_capitulos" >
                    <h2>Temporada 1</h2>
                    <p> <a runat="server" href="~/Capitulo.aspx"> 1 - Ritos de iniciación </a> </p>
                    <p>2 - La ira de los vikingos</p>
                    <p>3 - Despojados</p>
                    <p>4 - Prueba</p>
                    <p>5 - Ataque</p>
                    <p>6 - Sepultura para los muertos</p>
                    <p>7 - Rescate real</p>
                    <p>8 - Sacrificio</p>
                    <p>9 - Fin del trayecto</p>
                    <h2>Temporada 2</h2>
                    <p>1 - Hermanos en guerra</p>
                    <p>2 - Invasión</p>
                    <p>3 - Traición</p>
                    <p>4 - Ojo por ojo</p>
                    <p>5 - Respuestas sangrientas</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
