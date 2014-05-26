<%@ Page Title="Quienes somos" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="WebApplication1.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/About.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent"> 

       <div class="contenido">

        <!-- CABECERA DE LA PELICULA -->
        <div class="cabecera_about">
            <div class="portada_about">
                <asp:Image runat="server" CssClass="fondoblurred" ID="cabecera_fondo" ImageUrl="~/img/quienessomos.jpg" /> 
            </div>
             <div class="info_cabecera">
                <h2> Acerca de nosotros </h2>
             </div>
         </div>

        <div class="contenido_about">

            <div class="contenido_about_d">
                <h2>
                    Sobre la página
                </h2>
                <p> El propósito de esta página es la de una aplicación web a la que puedan acceder las distintas personas para consultar información sobre
                    películas, series y los capítulos de las distintas. </p>
                <p> Además, si se es usuario, la persona puede añadir nuevas películas, series, contar con un perfil propio, añadir amigos, comentar los distintos films...  </p>
                 
                <h2>
                    Fundadores
                </h2>
                <p> Daniel Moreno Gonzalez -  <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="https://twitter.com/DanyMorenoG94"
                                                 ForeColor="blueViolet" Text="@DanyMorenoG94">
                                              </asp:HyperLink> 
                </p>
                <p> Encarna Amorós Beneite -  <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="https://twitter.com/EncarnaAmoros"
                                                 ForeColor="blueViolet" Text="@EncarnaAmoros">
                                              </asp:HyperLink> 
                </p>
                <p> Jorge Vicente Azorín Martí - <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="https://twitter.com/JorgeAzorin"
                                                 ForeColor="blueViolet" Text="@JorgeAzorin">
                                                </asp:HyperLink> 
                </p>
                <p> Hector Compañ Gabucio - <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="https://twitter.com/Dorito4"
                                                 ForeColor="blueViolet" Text="@Dorito4">
                                                </asp:HyperLink> 
                </p>
                <p> Manuel José Verdú Ramón - <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="https://twitter.com/ManuVerdu7"
                                                 ForeColor="blueViolet" Text="@ManuVerdu7">
                                                </asp:HyperLink> 
                </p>
                <p> Vicente Martín Rueda - <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="https://twitter.com/SantoFrost"
                                                 ForeColor="blueviolet" Text="@SantoFrost">
                                                </asp:HyperLink> 
                </p>
                
                <h2>
                    Twitter <asp:HyperLink ID="tuiter" runat="server" NavigateUrl="http://twitter.com/share?url=<?php the_permalink() ?>" rel="nofollow" class="twitter-share-button" data-text="Que buenas películas y series en @WebInformaTV :)" data-count="vertical"  data-lang="es" > Tweet </asp:HyperLink>
                    <script type="text/javascript" src="http://platform.twitter.com/widgets.js"></script>
                    
                </h2>
                 <p>¡Síguenos!  <asp:HyperLink runat="server" NavigateUrl="https://twitter.com/@WebInformaTV"
                                 ForeColor="blueViolet" Text="@WebInformaTV">
                                 </asp:HyperLink>
                </p>
                <h2>
                    Contacto
                </h2>
                <p>
                    <asp:HyperLink runat="server" ForeColor="BlueViolet" Text="informhada@gmail.com" ></asp:HyperLink>
                </p>


            </div>
        </div>
    </div>

</asp:Content>
