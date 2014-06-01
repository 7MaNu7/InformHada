<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Account.Register" 
        Culture="Auto" UICulture="Auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
                <asp:Label ID="LabelCampoObligatorio" runat="server" ForeColor="Red" > (*) </asp:Label>                
                <asp:RequiredFieldValidator ID="ValidarUsuarioRelleno" runat="server" ValidationGroup="1" 
                    Text="¡Escribe un nombre para tu usuario!" ForeColor="Red" ControlToValidate="TextBoxUsuario"> 
                </asp:RequiredFieldValidator>
                
                <asp:TextBox ID="TextBoxUsuario" runat="server" CssClass="textEntry">
                </asp:TextBox>
                

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
            <asp:CustomValidator runat="server" ID="ValidandoFecha" ErrorMessage="Debe ser una fecha comprendida entre los años 1904 y 2010"
                 ForeColor="Red" ControlToValidate="TextBoxFecha" ValidationGroup="1">
            </asp:CustomValidator>

            <span><asp:TextBox ID="TextBoxFecha" runat="server"></asp:TextBox>
                <asp:ImageButton runat="server" ID="ImagenCalendario" border-width="0" border-bottom="none" width="21px"
                    height="21px"  BorderStyle="none" border-bottom-style="none"  ImageUrl="/img/calendario_icono.jpg" />
                <asp:RegularExpressionValidator 
                    ID="ValidarFormatoFecha" runat="server" ValidationGroup="1"
                    ErrorMessage="El formato de la fecha debe ser: DD/MM/AAAA (ej: 01/10/1994)" ForeColor="Red"
                     ControlToValidate="TextBoxFecha" ValidationExpression="\d{2}/\d{2}/\d{4}">                    
                </asp:RegularExpressionValidator>
            </span>

            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" 
                EnableScriptGlobalization="true" EnableScriptLocalization="true"/>
            </asp:ToolkitScriptManager>

            <asp:CalendarExtender ID="CalendarioAJAX" TargetControlID="TextBoxFecha" 
                PopupButtonID="ImagenCalendario"  runat="server"  DefaultView="Years">
            </asp:CalendarExtender> 

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
                <asp:Label ID="LabelEmail" runat="server">Correo electrónico:</asp:Label>
                <asp:Label ID="LabelCampobligatorio2" runat="server" ForeColor="Red" > (*) </asp:Label>
                <asp:RequiredFieldValidator ID="ValidarEmailRelleno" runat="server" ValidationGroup="1"
                    ControlToValidate="TextBoxEmail" ErrorMessage="¡Escribe tu email!" ForeColor="Red">                            
                </asp:RequiredFieldValidator>

                <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="textEntry">
                </asp:TextBox>
                

            </p>
            <p>
                <asp:Label ID="LabelPsswd" runat="server" >Contraseña:</asp:Label>
                <asp:Label ID="LabelCampoObligatorio3" runat="server" ForeColor="Red" > (*) </asp:Label>
                 <asp:RequiredFieldValidator ID="ValidarPsswdRelleno" runat="server" ValidationGroup="1"
                    ControlToValidate="TextBoxPsswd" Text="¡Escribe tu contraseña!" ForeColor="Red">                            
                </asp:RequiredFieldValidator>         
                            
                <asp:TextBox ID="TextBoxPsswd" runat="server" CssClass="passwordEntry" TextMode="Password">
                </asp:TextBox>               
                
                <asp:RegularExpressionValidator 
                    ID="RegularExpressionContraseña" runat="server" ValidationGroup="1"
                    ErrorMessage="La contraseña debe tener de 6 a 20 caracteres" ForeColor="Red"
                     ControlToValidate="TextBoxPsswd" ValidationExpression="\S{6,20}">                    
                </asp:RegularExpressionValidator>

            </p>
            <p> 
                <asp:Label ID="LabelPasswd2" runat="server" style="float:left" >Confirmar contraseña:</asp:Label>
                <asp:Label ID="LabelCampoObligatorio4" runat="server" ForeColor="Red" > (*) </asp:Label>
                
                <asp:RequiredFieldValidator ID="ValidarPsswdRelleno2" runat="server" ValidationGroup="1" 
                    style="float:inherit" ControlToValidate="TextBoxPsswd2" Text="¡Repita su contraseña!" ForeColor="Red">                            
                </asp:RequiredFieldValidator>

                <asp:TextBox ID="TextBoxPsswd2" runat="server" CssClass="passwordEntry" TextMode="Password">
                </asp:TextBox>
                
                <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="1"
                    ErrorMessage="¡Las contraseñas deben ser iguales!" ForeColor="Red"
                     ControlToValidate="TextBoxPsswd2" ControlToCompare="TextBoxPsswd" >
                </asp:CompareValidator>
                
            </p>

            <asp:RegularExpressionValidator 
                    ID="RegularExpressionEmail" runat="server" ValidationGroup="1"
                    ErrorMessage="Escriba un email válido como: ejemplo@dominio.extension" ForeColor="Red"
                    ControlToValidate="TextBoxEmail" ValidationExpression="\S+@\S+\.\S+">                    
            </asp:RegularExpressionValidator>
        
            <p><asp:CustomValidator ID="ValidarEmailYaExiste" runat="server" ControlToValidate="TextBoxEmail" ValidationGroup="1"
                   OnServerValidate="EmailYaExiste" ErrorMessage="Ya hay una cuenta con este email" ForeColor="Red"> 
                </asp:CustomValidator></p>

            

            <asp:Button ID="BotonRegistro" ValidationGroup="1" CssClass="completar" runat="server" 
                OnClick="BotonRegistroOnClick" Text="Completar registro" />                   
        </div>
        </div>   
        <div>
        <a href="Default.aspx">Volver a la página principal</a>
        </div>
    </div>   

</asp:Content>