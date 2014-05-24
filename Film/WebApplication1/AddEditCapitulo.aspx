<%@ Page Title="Añadir capitulo" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="AddEditCapitulo.aspx.cs" Inherits="WebApplication1.AddCapitulo" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Capitulo.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div class="contenido">

         <!-- CABECERA DEL CAPITULO  -->
        <div class="cabecera_capitulo">
            <div class="portada_capitulo" style="background-image:url('');">
                <img class="fondoblurred" src="http://hdwpapers.com/download/vikings_tv_desktop_wallpaper-1920x1080.jpg" alt="fotou_portada"/>
            </div>
             <img class="caratula" src="http://pics.filmaffinity.com/Vikingos_Vikings_Serie_de_TV-616055151-large.jpg" alt="fotou_perfil"/>
             <div class="info_cabecera">
                <h2> 
                    <asp:TextBox ID="TextBoxTitulo" placeholder="Título"  runat="server" > </asp:TextBox> 
                    <asp:Literal ID="LiteralTitulo" runat="server" > </asp:Literal>   
                    <asp:RequiredFieldValidator CssClass="ValidarTitulo" ID="ValidarTituloRelleno" runat="server" 
                        ForeColor="White" ErrorMessage="¡Escribe el título!" 
                        ControlToValidate="TextBoxTitulo" ValidationGroup="1"> 
                    </asp:RequiredFieldValidator>
                </h2>
                
                <p>Serie: <asp:Literal ID="LiteralSerie"  runat="server"> </asp:Literal> </p>
                <p>Temporada: <asp:TextBox ID="TextBoxTemporada" placeholder="Nº Temporada" runat="server" > </asp:TextBox> 
                    <asp:RequiredFieldValidator CssClass="ValidarTitulo" ID="ValidarTemporadaRellena" runat="server" 
                        ForeColor="White" ErrorMessage="Escribe la temporada"
                        ControlToValidate="TextBoxTitulo" ValidationGroup="1"> 
                    </asp:RequiredFieldValidator>
                </p>
                <p>Capítulo nº: <asp:TextBox ID="TextBoxNCapitulo" placeholder="Nº capitulo" runat="server"> </asp:TextBox> 
                    <asp:RequiredFieldValidator CssClass="ValidarTitulo" ID="ValidarCapituloRelleno" runat="server" 
                        ForeColor="White" ErrorMessage="Escribe el capítulo"
                        ControlToValidate="TextBoxTitulo" ValidationGroup="1"> 
                    </asp:RequiredFieldValidator>

                    <asp:CustomValidator ID="ValidarTemporadaNCapitulo" runat="server" CssClass="ValidarTitulo" 
                        ControlToValidate="TextBoxNCapitulo"  OnServerValidate="ValidandoTemporadaNCapitulo" ValidationGroup="1" 
                        ErrorMessage="El número del capítulo ya existe en esa temporada">
                    </asp:CustomValidator>
                </p>

                
             </div>
         </div>
        

        <div class="contenido_capitulo">
            <div class="contenido_capitulo_i">
                <asp:Button ID="BotonAddEdit" ValidationGroup="1" CssClass="anadir" 
                runat="server" Text="Editar" OnClick="BotonAddEditOnClick" />
              
            </div>
            <div class="contenido_capitulo_d">
               <h2>Sinopsis 
                <span> <asp:HyperLink ID="HyperLinkEditarCapitulo" runat="server" Text="Editar"> </asp:HyperLink> </span>
               </h2>
               
               <p> <asp:TextBox ID="TextBoxSinopsis" runat="server" TextMode="MultiLine"> </asp:TextBox> </p>

               <div class="volver_serie" style="float:right;">
                <p> <asp:HyperLink ID="HyperLinkVolverSerie" runat="server" Text="Volver a la serie"> </asp:HyperLink> </p>
               </div>
            </div>


    </div>
</asp:Content>
