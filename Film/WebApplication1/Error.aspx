<%@ Page Title="Error" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Error.aspx.cs" Inherits="WebApplication1.Error" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Report.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent"> 

       <div class="contenido">

        <!-- CABECERA DE LA PELICULA -->
        <div class="cabecerausuario">
            <div class="fondoblurreddiv" style="background-image:url('');">
                <asp:Image runat="server" CssClass="fondoblurred" ID="cabecera_fondo" ImageUrl="~/img/reporterror.jpg" /> 
            </div>
             <div class="infocabecera">
                <h2> Error </h2>
             </div>
         </div>

        <div class="pelicula_contenido">

            <div class="pelicula_contenido_d">
                <h2>
                    ¡Ups!
                </h2>
                <p> Debes haber iniciado sesión para acceder a esta página </p>

                <p><asp:HyperLink ID="HLPrincipal" runat="server" ForeColor="BlueViolet"
                 Text="Volver a la página principal" NavigateUrl="~/Default.aspx"></asp:HyperLink></p>

                 <p><asp:HyperLink ID="HLIniciarSesion" runat="server" ForeColor="BlueViolet"
                 Text="Iniciar sesión" NavigateUrl="~/Login.aspx"></asp:HyperLink></p>

                 <p><asp:HyperLink ID="HLRegistrarse" runat="server" ForeColor="BlueViolet"
                 Text="Registrarme" NavigateUrl="~/Register.aspx"></asp:HyperLink></p>
                
            </div>
        </div>
    </div>

</asp:Content>

