<%@ Page Title="Reportar error" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Report.aspx.cs" Inherits="WebApplication1.Report" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Report.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent"> 

       <div class="contenido">

        <!-- CABECERA DE LA PELICULA -->
        <div class="cabecerausuario">
            <div class="fondoblurreddiv" >
                <asp:Image runat="server" CssClass="fondoblurred" ID="cabecera_fondo" ImageUrl="~/img/reporterror.jpg" /> 
            </div>
             <div class="infocabecera">
                <h2> Reportar error </h2>
             </div>
         </div>

        <div class="pelicula_contenido">

            <div class="pelicula_contenido_d">
                <h2>
                    Infórmanos
                </h2>
                <p> Escriba el motivo de su queja y tomaremos en cuenta su opinión o aviso. </p>
                <p> Escríbanos también si tiene alguna sugerencia o pregunta sobre la web. </p>
                <p> <asp:TextBox ID="TextBoxReport" TextMode="MultiLine" runat="server" 
                        style="height:200px; width:500px; " placeholder="Comuníquenos aquí" > </asp:TextBox> </p>

                <asp:Button runat="server" ID="BotonEnviar" Text="Enviar" OnClick="EnviarEmail" />
                <asp:Label ID="LabelConfirmacion" runat="server" ForeColor="BlueViolet" ></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>

