﻿<%@ Page Title="Reportar error" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Report.aspx.cs" Inherits="WebApplication1.Report" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Report.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent"> 

       <div class="contenido">

        <!-- CABECERA DE LA PELICULA -->
        <div class="cabecerausuario">
            <div class="fondoblurreddiv" style="background-image:url('');">
                <img class="fondoblurred" src="http://www.pasionseo.com/wp-content/uploads/2014/03/error-404-link-building.png" alt="fotou_portada"/>
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
                <p> Escribe el motivo de tu queja y tomaremos en cuenta tu opinión, consulta o aviso </p>
                <p> <asp:TextBox ID="TextBoxInformacionAdicional" runat="server" style="height:200px; width:500px; " > </asp:TextBox> </p>


            </div>
        </div>
    </div>

</asp:Content>

