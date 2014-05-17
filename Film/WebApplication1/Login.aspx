<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Peliculas.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

 <div>
     
     <p> eeee </p>
     <p> eeee </p>
     <p> eeee </p>
     <p> eeee </p> 
     <asp:TextBox ID="TextBoxEmail" runat="server" Text="Email"></asp:TextBox>
     <asp:TextBox ID="TextBoxPsswd" runat="server" TextMode="Password" Text="Contraseña"></asp:TextBox>
     <asp:Button ID="ButtonIniciarSesion" runat="server" Text="Iniciar sesión" OnClick="IniciarSesionOnClick" />
 </div>

</asp:Content>