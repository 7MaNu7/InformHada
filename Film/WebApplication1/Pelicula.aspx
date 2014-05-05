
<%@ Page Title="La llave del mal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="WebApplication1.Pelicula" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

      <div class="fondo_blur" style="background-image:url('');">
        <img src="http://image.tmdb.org/t/p/original/ouZfvjWcN2u2SFiJD3nfqLqp3Uc.jpg" />
    </div>
    <div class="pelicula_blur">
        <img src="http://4.bp.blogspot.com/_qJx3wfBO98s/TRSkpQJls6I/AAAAAAAAAQ8/u7lWXgEJc0I/s1600/3131-la-llave-del-mal2005.jpg" alt="La llave del mal"/>
        <div>
            <h2>La llave del mal
                <asp:LoginView ID="HeadLoginView" runat="server" EnableViewState="false">
                    <AnonymousTemplate>
                       
                    </AnonymousTemplate>
                    <LoggedInTemplate>  
                        <i class="fa fa-pencil-square-o" style="font-size: 18px;vertical-align: bottom;cursor: pointer;"> </i>
                    </LoggedInTemplate>
                </asp:LoginView>
            
            </h2>
            <p>Director: El señor de rojo</p>
            <p>Banda sonora: Hans Zimmer</p>
            <p>Año: 1994</p>
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
