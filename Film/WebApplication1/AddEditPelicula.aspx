<%@ Page Title="Anadir o Editar película" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="AddEditPelicula.aspx.cs" Inherits="WebApplication1.AddEditPelicula" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Pelicula.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div class="contenido">

        <!-- CABECERA DE LA SERIE  -->
        <div class="cabecera_pelicula">
            <div class="portada_serie" style="background-image:url('');">
                <img class="fondoblurred" src="http://3.bp.blogspot.com/-tREmR3WN5LE/UwryZrZBKPI/AAAAAAAAu-s/E_UwmO8UvKM/s1600/divergente-banner.jpg" alt="fotou_portada"/>
                <div id="mybutton2">
                    Cambiar Imagen
                    <asp:FileUpload CssClass="upload"  id="FileUpload1" runat="server" /> 
                </div>
            </div>
             <img class="caratula" src="http://s3-eu-west-1.amazonaws.com/abandomedia/db/foto/db_18973_41.jpg" alt="fotou_perfil"/>
              
              <div id="mybutton">
                Cambiar Imagen
                <asp:FileUpload CssClass="upload"  id="FileUploadControl" runat="server" /> 
                
            </div>
              
             <div class="info_cabecera">
                <h2> <asp:Literal ID="LiteralTitulo" runat="server" > </asp:Literal> </h2>
                <p> <asp:TextBox ID="TextBoxDirector" runat="server" > Director </asp:TextBox> </p>
                <p> <asp:TextBox ID="TextBoxGenero" runat="server" > Genero </asp:TextBox> </p>
                <p> <asp:TextBox ID="TextBoxBandaSonora" runat="server">Banda sonora</asp:TextBox> </p>
                <p> <asp:TextBox ID="TextBoxAno" runat="server" >Año</asp:TextBox> </p>
               
        
             </div>
         </div>

        <div class="pelicula_contenido">
            <div class="pelicula_contenido_i">
                <asp:Button ID="BotonAddEdit" CssClass="anadir" runat="server" Text="Guardar cambios" OnClick="BotonAddEditOnClick" />
            </div>
            <div class="pelicula_contenido_d">
               <h2>Sinopsis</h2>
               <p> <asp:TextBox ID="TextBoxSinopsis" runat="server"  TextMode="MultiLine" style="height:131px; width:945px;">Escriba la sinopsis de la película aquí</asp:TextBox> </p>

               <h2>Reparto</h2>
               <p> <asp:TextBox ID="TextBoxReparto" runat="server" TextMode="MultiLine" style="height:50px; width:945px;">Escriba el reparto de actores que participan en la película</asp:TextBox> </p>
            
                <h2>Trailer</h2>
                <p> <asp:TextBox ID="TextBoxTrailer" runat="server" TextMode="MultiLine" style="width:945px;">Indique el enlace o archivo del trailer de la película</asp:TextBox> </p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
