<%@ Page Title="Quizás conozcas a " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
CodeBehind="VerMasUsuarios.aspx.cs" Inherits="WebApplication1.VerMasUsuarios" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<link href="/Styles/VerMas.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div  style="
    position: absolute;
    padding-top: 33px;">
    <style>
   body {
        background: url('http://k45.kn3.net/707DBBD0B.png') ;

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
    <asp:Literal ID="LiteralListaAmigos" runat="server"></asp:Literal>
        
    <div class="peliculas_contenido" style="padding: 25px 25px 1.5px 25px;">
       <div style="display:table;">
        <asp:ListView ID="ListViewQuizasConozcas"  runat="server">
            
            <ItemTemplate>
                <td>
                  <a style="display: table-cell;float: left; text-decoration:none; color:Gray;"  
                  href="Usuario.aspx?id=<asp:Literal ID="Literal5" Text='<%# Eval("id2")%>'  runat="server"></asp:Literal>">
                
                    <div class="peliculacaratula">
                        <asp:Image ID="Image1" CssClass="peliculacaratulaimg" runat="server"  ImageUrl='<%# "/img/users/"+ Eval("id2")+".jpg"%>' />
                        <p><asp:Literal ID="LiteralNombre" runat="server"></asp:Literal></p>
                        <div class="infopelicula">
                            <p>Usuario: <asp:Literal ID="LiteralUsuario" runat="server"></asp:Literal></p>
                        </div>
                    </div>
                    </a>
                </td>
            </ItemTemplate>
        </asp:ListView>

        </div>
        <div class="datapager">
        <asp:DataPager ID="DataPagerProducts" runat="server" PagedControlID="ListViewQuizasConozcas"
    PageSize="20" OnPreRender="DataPagerProducts_PreRender">
    <Fields>
        <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False" />
        <asp:NumericPagerField />
        <asp:NextPreviousPagerField ShowLastPageButton="True" ShowPreviousPageButton="False" />
    </Fields>
</asp:DataPager>
</div>
    </div>
    </div>
</asp:Content>
