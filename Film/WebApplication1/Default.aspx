<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Default.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
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
            <img class="foto_cabecera" src="http://www.pordede.com/content/homecover.png" alt="foto_portada"/>
        </div>
       
        <div class="infocabecera">
            <h2>InformaTV</h2>
            <p>La mejor información de tus peliculas y series preferidas.</p>
            <div style="position:relative;">
                <asp:TextBox ID="TextBox1" runat="server">Buscar Peliculas y Series</asp:TextBox>
                <i style="color: rgba(0, 0, 0, 0.54);
                            font-size: 14px;
                            top: 25px;
                            position: absolute;
                            left: calc(50% - 230px);" class="fa fa-search">
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
        Peliculas añadidas recientemente
        </h2>
        <table>
            <tr>
            <asp:ListView ID="ListViewRecientes" runat="server">
            <ItemTemplate>
                <td>
                        <a style="display: table-cell;float: left; text-decoration:none; color:Gray;"  href="Pelicula.aspx?id=<asp:Literal ID="Literal5" Text='<%# Eval("id")%>'  runat="server"></asp:Literal>">
                
                        <div class="peliculacaratula">
                            <asp:Image ID="Image1" CssClass="peliculacaratulaimg" runat="server" ImageUrl='<%# Eval("caratula")%>' />
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
        Series añadidas recientemente
        </h2>
        <table>
            <tr>
            <asp:ListView ID="ListViewSrecientes" runat="server">
            <ItemTemplate>
                <td>
                   
                        <a style="display: table-cell;float: left; text-decoration:none; color:Gray;"  href="Serie.aspx?id=<asp:Literal ID="Literal5" Text='<%# Eval("id")%>'  runat="server"></asp:Literal>">
                
                        <div class="peliculacaratula">
                            <asp:Image ID="Image1" CssClass="peliculacaratulaimg" runat="server" ImageUrl='<%# Eval("caratula")%>' />
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
        Peliculas y series más puntuadas
        </h2>
        <table>
            <tr>
            <asp:ListView ID="ListViewPuntuadas" runat="server">
            <ItemTemplate>
                <td>
                   
                        <a style="display: table-cell;float: left; text-decoration:none; color:Gray;"  href="Pelicula.aspx?id=<asp:Literal ID="Literal5" Text='<%# Eval("id")%>'  runat="server"></asp:Literal>">
                
                        <div class="peliculacaratula">
                            <asp:Image ID="Image1" CssClass="peliculacaratulaimg" runat="server" ImageUrl='<%# Eval("caratula")%>' />
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
        <table>
            <tr>
            <asp:ListView ID="ListViewSPuntuadas" runat="server">
            <ItemTemplate>
                <td>
                        <a style="display: table-cell;float: left; text-decoration:none; color:Gray;"  href="Serie.aspx?id=<asp:Literal ID="Literal5" Text='<%# Eval("id")%>'  runat="server"></asp:Literal>">
                
                        <div class="peliculacaratula">
                            <asp:Image ID="Image1" CssClass="peliculacaratulaimg" runat="server" ImageUrl='<%# Eval("caratula")%>' />
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


  </div>
</asp:Content>
