<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Login.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

     <div class="Login">
         <div style="margin-bottom: 24px;"><h2>Iniciar sesión</h2></div>
         
         <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TextBoxEmail" 
              OnServerValidate="ComprobarCuenta" ForeColor="White" ErrorMessage="E-mail o contraseña incorrectos"> 
         </asp:CustomValidator>

         <asp:TextBox ID="TextBoxEmail" runat="server" placeholder="@ Email"></asp:TextBox>
         <asp:RequiredFieldValidator ID="ValidarEmailRelleno" runat="server" 
                ControlToValidate="TextBoxPsswd" Text="¡Introduce tu e-mail!" ForeColor="White">                            
         </asp:RequiredFieldValidator>

         <asp:TextBox ID="TextBoxPsswd" runat="server" TextMode="Password" Text="Contraseña">PASSWORD</asp:TextBox>
         <asp:RequiredFieldValidator ID="ValidarPsswdRelleno" runat="server" 
                ControlToValidate="TextBoxPsswd" Text="¡Introduce tu contraseña!" ForeColor="White">                            
         </asp:RequiredFieldValidator>
         
         <asp:Button ID="ButtonIniciarSesion" CssClass="botton" runat="server" Text="Iniciar sesión" OnClick="IniciarSesionOnClick" />
         <div>
            <a href="Register.aspx">Registrarse</a>
         </div>
     </div>

</asp:Content>