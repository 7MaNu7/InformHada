﻿<%@ Page Title="Resultados búsqueda" Language="C#" AutoEventWireup="true"
    CodeBehind="ResultadosBusqueda.aspx.cs" Inherits="WebApplication1.ResultadosBusqueda" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head id="Head1" runat="server">
<link href="//netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" rel="stylesheet">
<link rel="stylesheet" href="http://demos.myjqueryplugins.com/jrating/jquery/jRating.jquery.css" type="text/css">
     <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> </title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/Default.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="Form2" runat="server">

     <script>
         $(document).ready(function () {
             $(window).bind('scroll', function () {
                 var navHeight = 399 - 50;
                 if ($(window).scrollTop() > navHeight) {
                     $('.menuizq').addClass('fixed');
                 }
                 else {
                     $('.menuizq').removeClass('fixed');
                 }
             });
         });
    </script>

    <div class="cabecerausuario">
        <div class="fondo_cabecera" style="background-image:url('');">
            <div class="oscurecer"></div>
            <img class="foto_cabecera" src="/img/fondo.png" alt="foto_portada"/>
        </div>
       
        <div class="infocabecera">
            <h2>InformaTV</h2>
            <p>La mejor información de tus peliculas y series preferidas.</p>
            <div style="position:relative;">
                <asp:TextBox ID="TextBoxBuscar" runat="server" placeholder="Buscar Peliculas y Series"></asp:TextBox>
                <asp:Button ID="BotonBuscar" runat="server" OnClick="BotonBuscarOnClick" Text="Buscar" /> 
                <i style="color: rgba(0, 0, 0, 0.54);
                            font-size: 14px;
                            top: 10px;
                            position: absolute;
                            left: calc(50% - 199px);" class="fa fa-search">
                </i>
           </div>
        </div>
   </div>


   <div class="contenido">
    <div id="menuizq" class="menuizq">
         <asp:HyperLink ID="HyperLinkPeliculas" runat="server" EnableViewState="false" PostBackUrl="String"> Ver peliculas </asp:HyperLink> 
         <asp:HyperLink ID="HyperLinkSeries" runat="server" EnableViewState="false" PostBackUrl="String"> Ver series </asp:HyperLink> 
         <asp:HyperLink ID="HyperLinkAbout" runat="server" EnableViewState="false" PostBackUrl="String"> Quienes somos </asp:HyperLink> 
         <asp:HyperLink ID="HyperLinkReport" runat="server" EnableViewState="false" PostBackUrl="String"> Reportar error </asp:HyperLink> 
         <asp:HyperLink ID="HyperRegistro" runat="server" PostBackUrl="String" > Entrar / Registrarse</asp:HyperLink>
         <asp:HyperLink ID="HyperLinkUsuario" runat="server" EnableViewState="false" PostBackUrl="String"> Ver mi usuario </asp:HyperLink> 
         <asp:HyperLink ID="HyperLinkAnadirPelicula" runat="server" EnableViewState="false" PostBackUrl="String"> Añadir pelicula </asp:HyperLink> 
         <asp:HyperLink ID="HyperLinkAnadirSerie" runat="server" EnableViewState="false" PostBackUrl="String"> Añadir serie </asp:HyperLink>  
    </div>

    <div class="cabecera_contenido">
        <h2>
        <asp:Literal ID="LiteralResultado" runat="server"></asp:Literal>
        </h2>
        <h2>
        Peliculas 
        </h2>
        <p> <asp:Literal ID="LiteralPeliculas" runat="server"></asp:Literal> </p>
        <table>
            <tr>
            <asp:ListView ID="ListViewPeliculas" runat="server">
            <ItemTemplate>
                <td>
                        <a style="display: table-cell;float: left; text-decoration:none; color:Gray;"  href="Pelicula.aspx?id=<asp:Literal ID="Literal5" Text='<%# Eval("id")%>'  runat="server"></asp:Literal>">
                
                        <div class="peliculacaratula">
                            <asp:Image ID="Image1" CssClass="peliculacaratulaimg" runat="server"  ImageUrl='<%# "/img/film/caratula/"+ Eval("id")+".jpg"%>' />
                            <p><asp:Literal ID="Literal1" Text='<%# Eval("titulo")%>' runat="server"></asp:Literal></p>
                            <div class="infopelicula">
                                <p>Año: <asp:Literal ID="Literal2" Text='<%# Eval("ano")%>' runat="server"></asp:Literal></p>
                                <p> Puntuacion: <asp:Literal ID="Literal3" Text='<%# Eval("puntuacion")%>' runat="server"></asp:Literal></p>
                                <p>Id: <asp:Literal ID="Literal4" Text='<%# Eval("id")%>' runat="server"></asp:Literal></p>
                            </div>
                        </div>
                        </a>
         
                </td>
            </ItemTemplate>
            </asp:ListView>
            </tr>
        </table>
    </div>
    


    <div class="cabecera_contenido">
        <h2>
        Series
        </h2>
        <p> <asp:Literal ID="LiteralSeries" runat="server"></asp:Literal> </p>
        <table>
            <tr>
            <asp:ListView ID="ListViewSeries" runat="server">
            <ItemTemplate>
                <td>
                   
                        <a style="display: table-cell;float: left; text-decoration:none; color:Gray;"  href="Serie.aspx?id=<asp:Literal ID="Literal5" Text='<%# Eval("id")%>'  runat="server"></asp:Literal>">
                
                        <div class="peliculacaratula">
                            <asp:Image ID="Image1" CssClass="peliculacaratulaimg" runat="server"  ImageUrl='<%# "/img/film/caratula/"+ Eval("id")+".jpg"%>'/>
                            <p><asp:Literal ID="Literal1" Text='<%# Eval("titulo")%>' runat="server"></asp:Literal></p>
                            <div class="infopelicula">
                                <p>Año: <asp:Literal ID="Literal2" Text='<%# Eval("ano")%>' runat="server"></asp:Literal></p>
                                <p> Puntuacion: <asp:Literal ID="Literal3" Text='<%# Eval("puntuacion")%>' runat="server"></asp:Literal></p>
                                <p>Id: <asp:Literal ID="Literal4" Text='<%# Eval("id")%>' runat="server"></asp:Literal></p>
                            </div>
                        </div>
                        </a>
         
                </td>
            </ItemTemplate>
            </asp:ListView>
            </tr>
        </table>
    </div>  

        <div class="cabecera_contenido">
        <h2>
            Usuarios
        </h2>
        <p> <asp:Literal ID="LiteralUsuarios" runat="server"></asp:Literal> </p>
        <table>
            <tr>
            <asp:ListView ID="ListViewUsuarios" runat="server">
           <ItemTemplate>
                  <a style="display: table-cell;float: left; margin: 7px; height: 100px; border: none; text-decoration:none; color:Gray;" href="usuario.aspx?id=<%# Eval("id")%> ">
                    <div style="background:url( '/img/users/0.jpg'); background-size: cover; box-shadow: 0 0 5px;" >
                        <img style=" width: 100px; height: 100px; background:url('<%# "/img/users/"+ Eval("id")+".jpg"%>'); background-size: cover; " />
                    </div> 
                 </a> 
            </ItemTemplate>
            </asp:ListView>
            </tr>
        </table>
    </div>


  </div>


</form></body>    