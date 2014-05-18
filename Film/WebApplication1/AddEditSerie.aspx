<%@ Page Title="Añadir/Editar serie" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="AddEditSerie.aspx.cs" Inherits="WebApplication1.AddEditSerie" %>

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
                <h2>  <asp:Literal ID="LiteralTitulo" runat="server" > </asp:Literal> </h2>
                <p> <asp:TextBox ID="TextBoxDirector" runat="server"> Director </asp:TextBox> </p>
                <p> <asp:TextBox ID="TextBoxGenero" runat="server"> Genero </asp:TextBox> </p>
                <p> <asp:TextBox ID="TextBoxBandaSonora" runat="server"> Banda sonora </asp:TextBox> </p>
                <p> <asp:TextBox ID="TextBoxAno" runat="server">Año</asp:TextBox> </p>
               
             </div>
         </div>

        <div class="contenido_serie">
            <div class="contenido_serie_i">
                <asp:Button ID="BotonAddEdit" CssClass="anadir" runat="server" Text="Guardar cambios" OnClick="BotonAddEditOnClick"/>
            </div>
            <div class="contenido_serie_d">
               <h2>Sinopsis</h2>
               <p> <asp:TextBox ID="TextBoxSinopsis" runat="server"  style="height:131px; width:945px;">Escriba la sinopsis de la serie aquí</asp:TextBox> </p>

               <h2>Reparto</h2>
               <p> <asp:TextBox ID="TextBoxReparto" runat="server" style="height:50px; width:945px;">Escriba el reparto de actores que participan en la serie</asp:TextBox> </p>
            
                <h2>Trailer</h2>
                <p> <asp:TextBox ID="TextBoxTrailer" runat="server" style="width:945px;">Indique el enlace o archivo del trailer de la serie</asp:TextBox> </p>
                
                <p> <asp:TextBox ID="TextBox1" runat="server" style="width:945px;">Indique el enlace o archivo de la foto de la carátula de la serie</asp:TextBox> </p>
                <p> <asp:TextBox ID="TextBox2" runat="server" style="width:945px;">Indique el enlace o archivo de la foto de la portada de la serie</asp:TextBox> </p>
                
                    
                <p> </p>
                <h2>Capitulos - <span style="
                                background: rgba(195, 195, 199, 0.44);
                                font-size: 15px;
                                vertical-align: middle;
                                cursor: pointer;
                                padding: 4px 12px 4px 12px;
                                border-radius: 4px;">AÑADIR</span>
                </h2>
                
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
