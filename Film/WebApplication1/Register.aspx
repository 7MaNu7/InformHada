<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Account.Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Register.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   
    <div class="Login">

        <div style="margin-bottom: 24px; margin-left: 69px;"><h2>Registro</h2></div>
                    
        <div class="cont_columna">
        <div class="columna">
            <p>
                <asp:Label ID="LabelUsuario" runat="server" >Nombre de usuario:</asp:Label>
                                
                <asp:TextBox ID="TextBoxUsuario" runat="server" CssClass="textEntry">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="ValidarUsuarioRelleno" runat="server" 
                    Text="¡Escribe un nombre para tu usuario!" ForeColor="Red" ControlToValidate="TextBoxUsuario"> 
                </asp:RequiredFieldValidator>

            </p>
            <p>
                <asp:Label ID="LabelPais" runat="server">Pais:</asp:Label>
                <asp:TextBox ID="TextBoxPais" runat="server" CssClass="textEntry"></asp:TextBox>
            </p>

            <p>
                <asp:Label ID="LabelProvincia" runat="server" >Provincia:</asp:Label>
                <asp:TextBox ID="TextBoxProvincia" runat="server" CssClass="textEntry"></asp:TextBox>                                  
            </p>

            <asp:Label ID="Label1" runat="server" >Fecha nacimiento:</asp:Label>
            <asp:TextBox ID="calendario" runat="server"></asp:TextBox>

            <p style="vertical-align:top;">Sexo:</p>
            <div style="display:inline;">
            <asp:RadioButtonList ID="Sexo" runat="server" CellPadding="8" TextAlign="Left" RepeatDirection="Horizontal">
                <asp:ListItem ID="SexoHombre" runat="server" value="Varón" />
                <asp:ListItem ID="SexoMujer" runat="server" value="Mujer" />
            </asp:RadioButtonList>
            </div>
                       
        </div>
        <div class="columna">
            <p>
                <asp:Label ID="LabelEmail" runat="server" >Correo electrónico:</asp:Label>

                <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="textEntry">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="ValidarEmailRelleno" runat="server" 
                    ControlToValidate="TextBoxEmail" Text="¡Escribe tu email!" ForeColor="Red">                            
                </asp:RequiredFieldValidator>
                <asp:CustomValidator ID="ValidarEmailYaExiste" runat="server" ControlToValidate="TextBoxEmail" 
                        OnServerValidate="EmailYaExiste" ErrorMessage="Ya hay una cuenta con este email" ForeColor="Red"> 
                </asp:CustomValidator>

            </p>
            <p>
                <asp:Label ID="LabelPsswd" runat="server" >Contraseña:</asp:Label>
                            
                <asp:TextBox ID="TextBoxPsswd" runat="server" CssClass="passwordEntry" TextMode="Password">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="ValidarPsswdRelleno" runat="server" 
                    ControlToValidate="TextBoxPsswd" Text="¡Escribe tu contraseña!" ForeColor="Red">                            
                </asp:RequiredFieldValidator>
                <asp:RangeValidator runat="server" ControlToValidate="TextBoxPsswd" 
                    MinimumValue="20" MaximumValue="6" ForeColor="Red">
                </asp:RangeValidator>

            </p>
            <p>
                <asp:Label ID="LabelPasswd2" runat="server" >Confirmar contraseña:</asp:Label>
                <asp:TextBox ID="TextBoxPsswd2" runat="server" CssClass="passwordEntry" TextMode="Password">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="ValidarPsswdRelleno2" runat="server" 
                    ControlToValidate="TextBoxPsswd2" Text="¡Repita su contraseña!" ForeColor="Red">                            
                </asp:RequiredFieldValidator>
                <asp:CustomValidator ID="ValidarPsswdIguales" runat="server" ControlToValidate="TextBoxPsswd" 
                        OnServerValidate="ComprobarPsswd" ErrorMessage="¡Las contraseñas deben ser iguales!"> 
                </asp:CustomValidator>
            </p>
        
            <asp:ValidationSummary ID="CuadroValidacion" runat="server" ForeColor="Red" />         
            <asp:Button ID="BotonRegistro" CssClass="completar" runat="server" 
                OnClick="BotonRegistroOnClick" Text="Completar registro" />                   
        </div>
        </div>   
        <div>
        <a href="Default.aspx">Volver a la página principal</a>
        </div>
    </div>   

</asp:Content>