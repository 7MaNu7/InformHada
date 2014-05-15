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
                <h2>Vikings </h2>
                <p>Director: Michael Hirst</p>
                <p>Soundtrack: Hans Zimmer</p>
                <p>Año: 2013</p>
             </div>
         </div>

        <div class="contenido_serie">
            <div class="contenido_serie_i">
                <asp:HyperLink ID="ButtonEdit" CssClass="anadir" runat="server" EnableViewState="false" Text="Editar" />
                <asp:HyperLink ID="ButtonEdit2" CssClass="reportar" runat="server" Text="Reportar error" />
                <div class="basic" data-average="5" data-id="1" style="margin:auto;"></div>
            </div>
            <div class="contenido_serie_d">
               <h2>Sinopsis</h2>
               <p>Serie de TV (2013-Actualidad). Sigue las aventuras de Ragnar Lothbrok, el héroe más grande de su época. La serie narra las sagas de la banda de hermanos vikingos de Ragnar y su familia, cuando él se levanta para convertirse en el rey de las tribus vikingas. Además de ser un guerrero valiente, Ragnar encarna las tradiciones nórdicas de la devoción a los dioses, la leyenda dice que él era un descendiente directo de Odín, el dios de la guerra y los guerreros.</p>

               <h2>Reparto</h2>
               <p>Travis Fimmel, Clive Standen, Katheryn Winnick, Gabriel Byrne, Jessalyn Gilsig, Gustaf Skarsgård, George Blagden, Tadhg Murphy, Diarmaid Murtagh, David Pearse, Vladimir Kulich, Donal Logue</p>
            
                <h2>Trailer</h2>
                <iframe width="761" height="415" src="//www.youtube.com/embed/5aASH8HMJbo" frameborder="0" allowfullscreen="trailer"></iframe>
            
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
