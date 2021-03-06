﻿<%@ Page Title="Amigos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerMasAmigos.aspx.cs" Inherits="WebApplication1.VerMasAmigos" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<link href="/Styles/VerMasAmigos.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div  style="
     margin:auto;
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
    <div class="peliculas_contenido" style="padding: 25px 25px 1.5px 25px; margin:auto;" >
       <div style="display:table;margin:auto;">
       <p><asp:Literal ID="LiteralListaAmigos" runat="server"></asp:Literal></p>
        <asp:ListView ID="ListViewAmigos"  runat="server">
            <ItemTemplate>
                  <a style="display: table-cell;float: left; margin: 7px; border: none; text-decoration:none; color:Gray;" href="usuario.aspx?id=<%# Eval("id2")%> ">
                    <div style="background:url( '/img/users/0.jpg'); height: 100px; background-size: cover; box-shadow: 0 0 5px;" >
                        <img style=" width: 100px; height: 100px; background:url('<%# "/img/users/"+ Eval("id2")+".jpg"%>'); background-size: cover; " />
                    </div> 
                 </a> 
            </ItemTemplate>
        </asp:ListView>
        </div>
        <div class="datapager">
        <asp:DataPager ID="DataPagerProducts" runat="server" PagedControlID="ListViewAmigos"
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
