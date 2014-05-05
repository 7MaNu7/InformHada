
<%@ Page Title="Vikings" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="WebApplication1.Serie" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div class="fondo_blur" style="background-image:url('');">
        <img src="http://hdwpapers.com/download/vikings_tv_desktop_wallpaper-1920x1080.jpg" />
    </div>
    <div class="pelicula_blur">
        <img src="http://pics.filmaffinity.com/Vikingos_Vikings_Serie_de_TV-616055151-large.jpg" />
        <div>
            <h2>Vikings
            <asp:LoginView ID="HeadLoginView" runat="server" EnableViewState="false">
                    <AnonymousTemplate>
                       
                    </AnonymousTemplate>
                    <LoggedInTemplate>
                       
            <i class="fa fa-pencil-square-o" style="
    font-size: 18px;
    vertical-align: bottom;
    cursor: pointer;
"></i>
                    </LoggedInTemplate>
                </asp:LoginView>
            
            </h2>
            <p>Director: El señor de rojo</p>
            <p>Banda sonora: Fever Ray</p> 
            <p>Año: 2010</p>
        </div>
    </div>
    <div class="pelicula_contenido">
        <div class="pelicula_contenido_i">
            <h2>Puntuación: 1</h2>
        </div>
        <div class="pelicula_contenido_d">
           <h2>Sinopsis</h2>
           <p>Vikings (Vikingos) está basada en las leyendas sobre el vikingo Ragnar Lodbrok, uno de los héroes más famosos de la cultura nórdica que saqueó Northumbria, Francia y Bretaña. La serie retrata a Lodbrok como guerrero curioso y navegante tecnológicamente innovador, ambicioso y rebelde que construye un barco para lanzarse a explorar los territorios al oeste de Escandinavia desobedeciendo al jefe tribal, el conde Haraldson, que ordena viajar hacia el este.</p>
           

           <h2>Reparto</h2>
           <p>Después de abandonar su trabajo de enfermera en una clínica, Caroline (Hudson) es contratada para cuidar a un anciano que ha sufrido una embolia, aunque la esposa de éste (Rowlands) la acoge con bastante recelo. El matrimonio vive en una siniestra mansión sureña en las afueras de Nueva Orleáns, en el delta del Mississippi (Louisiana). Intrigada por las extrañas costumbres de la enigmática pareja, Caroline decide explorar la casa. Armada con una llave maestra, empieza a abrir todas las puertas hasta que descubre un desván que encierra un terrible secreto.</p>
            

            <h2>Trailer</h2>
            <iframe width="761" height="415" src="//www.youtube.com/embed/5aASH8HMJbo?rel=0" frameborder="0" allowfullscreen></iframe>
            
        </div>
    </div>
</asp:Content>
