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
                <img class="fondoblurred" src="http://t2.gstatic.com/images?q=tbn:ANd9GcS5JCvSU5SqavKeAPTwr6syUG3y9tAIBfUYsqH7ZpxFnMMz_dw3Gg" alt="fotou_portada"/>
            </div>
             <img class="caratula" src="http://pics.filmaffinity.com/Vikingos_Vikings_Serie_de_TV-616055151-large.jpg" alt="fotou_perfil"/>
             <div class="info_cabecera">
                <h2> <asp:TextBox ID="TextBoxTitulo" runat="server" Font-Italic Font-Size="1.5em"  style="width:223px">Título</asp:TextBox> </h2>
                <p> <asp:TextBox ID="TextBoxDirector" runat="server"> Director </asp:TextBox> </p>
                <p> <asp:TextBox ID="TextBoxSoundtrack" runat="server">Soundtrack</asp:TextBox> </p>
                <p> <asp:TextBox ID="TextBoxAno" runat="server">Año</asp:TextBox> </p>
               
             </div>
         </div>

        <div class="contenido_serie">
            <div class="contenido_serie_i">
               <asp:HyperLink ID="ButtonEdit" CssClass="anadir" runat="server" EnableViewState="false" Text="Guardar cambios" />
            </div>
            <div class="contenido_serie_d">
               <h2>Sinopsis</h2>
               <p> <asp:TextBox ID="TextBox4" runat="server"  style="height:131px; width:945px;">Escriba la sinopsis de la serie aquí</asp:TextBox> </p>

               <h2>Reparto</h2>
               <p> <asp:TextBox ID="TextBox5" runat="server" style="height:50px; width:945px;">Escriba el reparto de actores que participan en la serie</asp:TextBox> </p>
            
                <h2>Trailer</h2>
                <p> <asp:TextBox ID="TextBox6" runat="server" style="width:945px;">Indique el enlace o archivo del trailer de la serie</asp:TextBox> </p>
                
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
