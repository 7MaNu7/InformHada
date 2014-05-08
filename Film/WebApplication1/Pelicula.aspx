<%@ Page Title="Divergente" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Pelicula.aspx.cs" Inherits="WebApplication1.Pelicula" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Pelicula.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div class="contenido">

        <!-- CABECERA DE LA PELICULA  -->
        <div class="cabecerausuario">
            <div class="fondoblurreddiv" style="background-image:url('');">
                <img class="fondoblurred" src="http://3.bp.blogspot.com/-tREmR3WN5LE/UwryZrZBKPI/AAAAAAAAu-s/E_UwmO8UvKM/s1600/divergente-banner.jpg" alt="fotou_portada"/>
            </div>
             <img class="caratula" src="http://s3-eu-west-1.amazonaws.com/abandomedia/db/foto/db_18973_41.jpg" alt="fotou_perfil"/>
             <div class="infocabecera">
                <h2>Divergente </h2>
                <p>Director: Neil Burger</p>
                <p>Soundtrack: Hans Zimmer</p>
                <p>Año: 2014</p>
             </div>
         </div>

        <div class="pelicula_contenido">
            <div class="pelicula_contenido_i">
                <h2>Puntuación: 1</h2>

                <div class="loginDisplay">
                <asp:LoginView ID="HeadLoginView" runat="server" EnableViewState="false">
                    <AnonymousTemplate>
                        
                    </AnonymousTemplate>
                    <LoggedInTemplate>
                     <h2> Editar película 1</h2>        
                   </LoggedInTemplate>
                </asp:LoginView>
            </div>

            </div>
            <div class="pelicula_contenido_d">
               <h2>Sinopsis</h2>
               <p>'Divergente' es la historia de una sociedad que se divide en cinco categorías: Verdad, Abnegación, Osadía, Cordialidad y Erudición. Todos los miembros de esta sociedad tienen que elegir a una edad temprana, los dieciséis años, a qué bando creen pertenecer, atendiendo a sus virtudes personales más destacadas. En este dilema se encuentra la protagonista, Beatrice, que sorprende a todos sus allegados y amigos con la decisión que tema. Beatrice, que pasa a llamarse más tarde Tris, tiene que buscar su lugar adecuado, pero ella no es como el resto. Guarda un secreto que podría ser definitivo para mantener el orden social descrito y también para salvar su propia vida.</p>

               <h2>Reparto</h2>
               <p>Shailene Woodley, Beatrice "Tris" Prior, Theo James, Kate Winslet, Jeanine Matthews, Zoë Kravitz, Ansel Elgort, Caleb Prior, Miles Teller, Jai Courtney, Jai Courtney, Maggie Q</p>
            
                <h2>Trailer</h2>
                <iframe width="761" height="415" src="//www.youtube.com/embed/zpFBzD-B8Ak" frameborder="0" allowfullscreen></iframe>
            </div>
        </div>
    </div>
</asp:Content>
