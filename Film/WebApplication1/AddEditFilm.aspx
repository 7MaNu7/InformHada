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
                <img class="fondoblurred" src="http://t2.gstatic.com/images?q=tbn:ANd9GcS5JCvSU5SqavKeAPTwr6syUG3y9tAIBfUYsqH7ZpxFnMMz_dw3Gg" alt="fotou_portada"/>
            </div>
             <img class="caratula" src="http://pics.filmaffinity.com/Vikingos_Vikings_Serie_de_TV-616055151-large.jpg" alt="fotou_perfil"/>
             <div class="infocabecera">
                <h2>Título: <asp:TextBox ID="TextBoxEdad" runat="server">Título</asp:TextBox> </h2>
                <p>Director: <asp:TextBox ID="TextBox1" runat="server">Director</asp:TextBox> </p>
                <p>Soundtrack: <asp:TextBox ID="TextBox2" runat="server">Soundtrack</asp:TextBox> </p>
                <p>Año: <asp:TextBox ID="TextBox3" runat="server">Año</asp:TextBox> </p>
             </div>
         </div>

        <div class="pelicula_contenido">
            <div class="pelicula_contenido_i">
                <h2>Puntuación: </h2>
            </div>
            <div class="pelicula_contenido_d">
               <h2>Sinopsis</h2>
               <p> <asp:TextBox ID="TextBox4" runat="server">Título</asp:TextBox> </p>

               <h2>Reparto</h2>
               <p> <asp:TextBox ID="TextBox5" runat="server">Título</asp:TextBox> </p>
            
                <h2>Trailer</h2>
                <p> <asp:TextBox ID="TextBox6" runat="server">Título</asp:TextBox> </p>
                <!--<iframe width="761" height="415" src="//www.youtube.com/embed/5aASH8HMJbo" frameborder="0" allowfullscreen="trailer"></iframe>-->
            
                <h2>Capitulos</h2>
                <div class="Serie_capitulos">
                    <h2>Temporada </h2>
                    <p>Capitulos</p>
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
