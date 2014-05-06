<%@ Page Title="Vikings" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Pelicula.aspx.cs" Inherits="WebApplication1.Pelicula" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Pelicula.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div class="contenido">



        <!-- CABECERA DEL USUARIO  -->
        <div class="cabecerausuario">
            <div class="fondoblurreddiv" style="background-image:url('');">
                <img class="fondoblurred" src="http://hdwpapers.com/download/vikings_tv_desktop_wallpaper-1920x1080.jpg" alt="fotou_portada"/>
            </div>
             <img class="caratula" src="http://pics.filmaffinity.com/Vikingos_Vikings_Serie_de_TV-616055151-large.jpg" alt="fotou_perfil"/>
             <div class="infocabecera">
                <h2>Vikings </h2>
                <p>Los vampiros también lloramos</p>
             </div>
         </div>





    <div class="pelicula_contenido">
        <div class="pelicula_contenido_i">
            <h2>Puntuación: 1</h2>
        </div>
        <div class="pelicula_contenido_d">
           <h2>Sinopsis</h2>
           <p>Después de abandonar su trabajo de enfermera en una clínica, Caroline (Hudson) es contratada para cuidar a un anciano que ha sufrido una embolia, aunque la esposa de éste (Rowlands) la acoge con bastante recelo. El matrimonio vive en una siniestra mansión sureña en las afueras de Nueva Orleáns, en el delta del Mississippi (Louisiana). Intrigada por las extrañas costumbres de la enigmática pareja, Caroline decide explorar la casa. Armada con una llave maestra, empieza a abrir todas las puertas hasta que descubre un desván que encierra un terrible secreto.</p>

           <h2>Reparto</h2>
           <p>Después de abandonar su trabajo de enfermera en una clínica, Caroline (Hudson) es contratada para cuidar a un anciano que ha sufrido una embolia, aunque la esposa de éste (Rowlands) la acoge con bastante recelo. El matrimonio vive en una siniestra mansión sureña en las afueras de Nueva Orleáns, en el delta del Mississippi (Louisiana). Intrigada por las extrañas costumbres de la enigmática pareja, Caroline decide explorar la casa. Armada con una llave maestra, empieza a abrir todas las puertas hasta que descubre un desván que encierra un terrible secreto.</p>
            
            <h2>Trailer</h2>
            <iframe width="761" height="415" src="//www.youtube.com/embed/y4Oz7tmGGx8?rel=0" frameborder="0" allowfullscreen></iframe>
            
        </div>
    </div>
</asp:Content>
