<%@ Page Title="Películas" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Peliculas.aspx.cs" Inherits="WebApplication1.Peliculas" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<link href="/Styles/Peliculas.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div  style="
    position: absolute;
    padding-top: 33px;">
   <style>
   body {
        background: url('/img/fondovermas.png') ;

        }
   .page
   {
       background:none !important;
   }
   .main a:visited {
    color: white;
    }
    .main a {
    color: rgba(36, 36, 36, 0.8) !important;
    }
   </style>
    <h2> <asp:HyperLink ID="HyperLinkAddPelicula" runat="server" EnableViewState="false" PostBackUrl="String" style="padding: 25px 25px 1.5px 25px;"> Añadir película </asp:HyperLink> </h2>
        
        
    <div class="peliculas_contenido" style="padding: 25px 25px 1.5px 25px;">
       <div style="display:table;">
        <asp:ListView ID="ListViewPeliculas"  runat="server">
            
            <ItemTemplate> 
            <a style="display: table-cell;float: left; text-decoration:none; color:Gray;"  href="Pelicula.aspx?id=<asp:Literal ID="Literal5" Text='<%# Eval("id")%>'  runat="server"></asp:Literal>">
                
            <div class="peliculacaratula">
                <asp:Image ID="Image1" CssClass="peliculacaratulaimg" runat="server" ImageUrl='<%# "/img/film/caratula/"+ Eval("id")+".jpg"%>'  />
                <p><asp:Literal ID="Literal1" Text='<%# Eval("titulo")%>' runat="server"></asp:Literal></p>
                <div class="infopelicula">
                    <p>Año: <asp:Literal ID="Literal2" Text='<%# Eval("ano")%>' runat="server"></asp:Literal></p>
                    <p> Puntuacion: <asp:Literal ID="Literal3" Text='<%# Eval("puntuacion")%>' runat="server"></asp:Literal></p>
                    <p>Id: <asp:Literal ID="Literal4" Text='<%# Eval("id")%>' runat="server"></asp:Literal></p>
                </div>
            </div>
            </a>
        
            </ItemTemplate>  
        </asp:ListView>

        </div>
        <div class="datapager">
        <asp:DataPager ID="DataPagerProducts" runat="server" PagedControlID="ListViewPeliculas"
    PageSize="20" OnPreRender="DataPagerProducts_PreRender">
    <Fields>
        <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False" />
        <asp:NumericPagerField />
        <asp:NextPreviousPagerField ShowLastPageButton="True" ShowPreviousPageButton="False" />
    </Fields>
</asp:DataPager>
</div>
    </div>
    <!--<p style="text-align: center;">Página 1 &gt;&gt;</p>-->
    </div>
</asp:Content>
