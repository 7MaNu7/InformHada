<%@ Page Title="Vikings" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Serie.aspx.cs" Inherits="WebApplication1.Serie" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Serie.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div class="contenido">

        <!-- CABECERA DE LA SERIE  -->
        <div class="cabecerausuario">
            <div class="fondoblurreddiv" style="background-image:url('');">
                <img class="fondoblurred" src="http://hdwpapers.com/download/vikings_tv_desktop_wallpaper-1920x1080.jpg" alt="fotou_portada"/>
            </div>
             <img class="caratula" src="http://pics.filmaffinity.com/Vikingos_Vikings_Serie_de_TV-616055151-large.jpg" alt="fotou_perfil"/>
             <div class="infocabecera">
                <h2>Vikings </h2>
                <p>Director: Michael Hirst</p>
                <p>Soundtrack: Hans Zimmer</p>
                <p>Año: 2013</p>
             </div>
         </div>

        <div class="pelicula_contenido">
            <div class="pelicula_contenido_i">
                <h2>Puntuación: 1</h2>
            </div>
            <div class="pelicula_contenido_d">
               <h2>Sinopsis</h2>
               <p>Serie de TV (2013-Actualidad). Sigue las aventuras de Ragnar Lothbrok, el héroe más grande de su época. La serie narra las sagas de la banda de hermanos vikingos de Ragnar y su familia, cuando él se levanta para convertirse en el rey de las tribus vikingas. Además de ser un guerrero valiente, Ragnar encarna las tradiciones nórdicas de la devoción a los dioses, la leyenda dice que él era un descendiente directo de Odín, el dios de la guerra y los guerreros.</p>

               <h2>Reparto</h2>
               <p>Travis Fimmel, Clive Standen, Katheryn Winnick, Gabriel Byrne, Jessalyn Gilsig, Gustaf Skarsgård, George Blagden, Tadhg Murphy, Diarmaid Murtagh, David Pearse, Vladimir Kulich, Donal Logue</p>
            
                <h2>Trailer</h2>
                <iframe width="761" height="415" src="//www.youtube.com/embed/5aASH8HMJbo" frameborder="0" allowfullscreen></iframe>
            
                <h2>Capitulos</h2>
                <div class="Serie_capitulos">
                    <h2>Temporada 1</h2>
                    <p>1 - La venganza del Señor Potato</p>
                    <p>2 - La maldición mantecosa</p>
                    <p>3 - La vida no está hecha para contar Kcal</p>
                    <p>4 - Más vale pájaro en mano que ciervo volando</p>
                    <p>5 - El armario de Narnia</p>
                    <h2>Temporada 2</h2>
                    <p>1 - Adolfo se regocija en el barro</p>
                    <p>2 - Un McFlurry</p>
                    <p>3 - El burguerking da asco</p>
                    <p>4 - McDonald's mola más</p>
                    <p>5 - Eduardo ha matado a Adolfo</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
