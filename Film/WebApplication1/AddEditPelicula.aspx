<%@ Page Title="Añadir/Editar película" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="AddEditPelicula.aspx.cs" Inherits="WebApplication1.Serie" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Pelicula.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div class="contenido">

        <!-- CABECERA DE LA SERIE  -->
        <div class="cabecera_pelicula">
            <div class="portada_serie" style="background-image:url('');">
                <img class="fondoblurred" src="http://t2.gstatic.com/images?q=tbn:ANd9GcS5JCvSU5SqavKeAPTwr6syUG3y9tAIBfUYsqH7ZpxFnMMz_dw3Gg" alt="fotou_portada"/>
            </div>
             <img class="caratula" src="http://s3-eu-west-1.amazonaws.com/abandomedia/db/foto/db_18973_41.jpg" alt="fotou_perfil"/>
             <div class="info_cabecera">
                <h2> <asp:TextBox ID="TextBoxTitulo" runat="server" Font-Italic Font-Size="1.5em"  style="width:223px">Título</asp:TextBox> </h2>
                <p> <asp:TextBox ID="TextBoxDirector" runat="server"> Director </asp:TextBox> </p>
                <p> <asp:TextBox ID="TextBoxSoundtrack" runat="server">Soundtrack</asp:TextBox> </p>
                <p> <asp:TextBox ID="TextBoxAno" runat="server">Año</asp:TextBox> </p>
               
             </div>
         </div>

        <div class="pelicula_contenido">
            <div class="pelicula_contenido_i">
                <asp:HyperLink ID="ButtonEdit" CssClass="anadir" runat="server" EnableViewState="false" Text="Guardar cambios" />
            </div>
            <div class="pelicula_contenido_d">
               <h2>Sinopsis</h2>
               <p> <asp:TextBox ID="TextBox4" runat="server"  style="height:131px; width:945px;">Escriba la sinopsis de la película aquí</asp:TextBox> </p>

               <h2>Reparto</h2>
               <p> <asp:TextBox ID="TextBox5" runat="server" style="height:50px; width:945px;">Escriba el reparto de actores que participan en la película</asp:TextBox> </p>
            
                <h2>Trailer</h2>
                <p> <asp:TextBox ID="TextBox6" runat="server" style="width:945px;">Indique el enlace o archivo del trailer de la película</asp:TextBox> </p>
                
                <p> <asp:TextBox ID="TextBox1" runat="server" style="width:945px;">Indique el enlace o archivo de la foto de la carátula de la película</asp:TextBox> </p>
                <p> <asp:TextBox ID="TextBox2" runat="server" style="width:945px;">Indique el enlace o archivo de la foto de la portada de la película</asp:TextBox> </p>
                    
                
                </div>
            </div>
        </div>
    </div>
</asp:Content>
