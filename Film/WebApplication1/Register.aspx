<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Account.Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Register.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   
                    <div class="Login">


                     <div style="margin-bottom: 24px;"><h2>Registro</h2></div>
                     
                        <p>
                            Use el formulario siguiente para crear una cuenta nueva.
                        </p>
                        
                        <legend>Información de cuenta</legend>
                        <p>
                            <asp:Label ID="LabelUsuario" runat="server" >Nombre de usuario:</asp:Label>
                            <asp:TextBox ID="TextBoxUsuario" runat="server" CssClass="textEntry"></asp:TextBox>
                        </p>
                        <p>
                            <asp:Label ID="LabelPais" runat="server">Pais:</asp:Label>
                            <asp:TextBox ID="TextBoxPais" runat="server" CssClass="textEntry"></asp:TextBox>
                        </p>

                        <p>
                            <asp:Label ID="LabelProvincia" runat="server" >Provincia:</asp:Label>
                            <asp:TextBox ID="TextBoxProvincia" runat="server" CssClass="textEntry"></asp:TextBox>
                                   
                        </p>

                        <p>Sexo:</p>
                        <asp:RadioButtonList ID="Sexo" runat="server" CellPadding="8" TextAlign="Left" RepeatDirection="Horizontal">
                            <asp:ListItem ID="SexoHombre" runat="server" value="Varón" />
                            <asp:ListItem ID="SexoMujer" runat="server" value="Mujer" />
                        </asp:RadioButtonList>

                        <asp:Calendar ID="Calendar" runat="server"> </asp:Calendar>

                        <p>
                            <asp:Label ID="LabelEmail" runat="server" >Correo electrónico:</asp:Label>
                            <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="textEntry"></asp:TextBox>
                        
                        </p>
                        <p>
                            <asp:Label ID="LabelPsswd" runat="server" >Contraseña:</asp:Label>
                            <asp:TextBox ID="TextBoxPsswd" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        
                        </p>
                        <p>
                            <asp:Label ID="LabelPasswd2" runat="server" >Confirmar contraseña:</asp:Label>
                            <asp:TextBox ID="TextBoxPasswd2" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        </p>
                     
                        <asp:Button ID="BotonRegistro" runat="server" OnClick="BotonRegistroOnClick" Text="Completar registro" />
                        
                     <div>
                        <a href="Default.aspx">Volver a la página principal</a>
                     </div>


                     </div>



                        

</asp:Content>
