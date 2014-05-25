<%@ Page Title="Add Usuario" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="EditUsuario.aspx.cs" Inherits="WebApplication1.AddEditUsuario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Usuario.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div class="contenido">

        <!-- CABECERA DEL USUARIO  -->
        <div class="cabecera_usuario">
            <div class="portada_usuario">
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Image ID="fondo" CssClass="fondoblurred" runat="server" />
               
                <div id="mybutton2">
                    Cambiar Imagen
                    <asp:FileUpload CssClass="upload"  id="FileUpload2" runat="server" /> 
                </div>
            </div>
            <asp:Image ID="caratula" CssClass="fotoperfilusuario" runat="server" />
             <div id="mybutton3">
                Cambiar Imagen
                <asp:FileUpload CssClass="upload"  id="FileUploadControl" runat="server" /> 
                
            </div>
             
             <div class="infocabecera">
                <h2>
                    <asp:Literal ID="LiteralNombre" runat="server" > </asp:Literal>
                </h2>
                    
                    <asp:RegularExpressionValidator 
                        ID="RegularExpressionEmail" runat="server" ValidationGroup="1"
                        ErrorMessage="Escriba un email válido como: ejemplo@dominio.extension" ForeColor="Red"
                        ControlToValidate="TextBoxEmail" ValidationExpression="\S+@\S+\.\S+">                    
                    </asp:RegularExpressionValidator>

                    <asp:CustomValidator ID="ValidarEmailYaExiste" runat="server" 
                        ControlToValidate="TextBoxEmail" ValidationGroup="1" ForeColor="Red"
                        OnServerValidate="EmailYaExiste" ErrorMessage="¡¡Ya hay una cuenta con este email!!"> 
                    </asp:CustomValidator>
                    
                    <p style="margin:0;">
                    
                        <asp:TextBox CssClass="cabecerasAddEdita" 
                            ID="TextBoxEmail" runat="server">e-mail</asp:TextBox>
                    
                        <asp:RequiredFieldValidator ID="ValidarEmailRelleno" runat="server"
                            ErrorMessage="¡Escribe un email!" ValidationGroup="1" ForeColor="Red"
                            ControlToValidate="TextBoxEmail" >        
                         </asp:RequiredFieldValidator>

                    </p>
             </div>
         </div>

         <!-- PARTE DE ABAJO DEL USUARIO  -->
         <div class="informacionusuario">
            <div class="usuarioinfcolizq">
                <p id="errorvalidacion" style="visibility:hidden;">Algún campo no se ha introducido correctamente</p>
                <div class="informacionpersonal">
                    <h2>Información personal: </h2>
                    
                    <p>
                        <asp:TextBox ID="TextBoxUsuario" runat="server" PlaceHolder="Usuario" ></asp:TextBox></p>
                        <asp:RequiredFieldValidator ID="UserNameReq" ValidationGroup="1" runat="server"
                           ControlToValidate="TextBoxUsuario" ErrorMessage="¡Introduce el usuario!"> 
                        </asp:RequiredFieldValidator>
                    <p>

                    <asp:CustomValidator runat="server" ID="ValidandoFecha" ErrorMessage="Debe ser una fecha entre 1904 y 2010"
                         ForeColor="Red" ControlToValidate="TextBoxFechaNacimiento" ValidationGroup="1">
                    </asp:CustomValidator>
                    
                    <span>
                        <asp:TextBox ID="TextBoxFechaNacimiento" PlaceHolder="Fecha de nacimiento" runat="server"></asp:TextBox>
                        <asp:ImageButton runat="server" ID="ImagenCalendario" border-width="0" border-bottom="none" width="21px"
                            height="21px" vertical-align="middle"  BorderStyle="none" border-bottom-style="none"  ImageUrl="/img/calendario_icono.jpg" />
                    </span>

                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" 
                        EnableScriptGlobalization="true" EnableScriptLocalization="true"/>
                    </asp:ToolkitScriptManager>
                        
                    <asp:CalendarExtender ID="CalendarioAJAX" TargetControlID="TextBoxFechaNacimiento" 
                        PopupButtonID="ImagenCalendario" runat="server"  DefaultView="Years">
                    </asp:CalendarExtender>

                    <p>Sexo:</p>
                    <asp:RadioButtonList ID="Sexo" runat="server" CellPadding="8" TextAlign="Left" RepeatDirection="Horizontal">
                         <asp:ListItem ID="SexoHombre" runat="server" value="Varón" />
                         <asp:ListItem ID="SexoMujer" runat="server" value="Mujer" />
                    </asp:RadioButtonList>

                    <p><asp:TextBox ID="TextBoxPais" PlaceHolder="Pais" runat="server"></asp:TextBox></p>
                    <p><asp:TextBox ID="TextBoxProvincia" PlaceHolder="Provincia" runat="server"></asp:TextBox></p>
                
                </div>

                <div class="infoamigos">
                    <h2>Nueva contraseña</h2>
                    <p><asp:TextBox ID="TextBoxPsswd" runat="server" TextMode="Password"></asp:TextBox></p>
                    
                    <asp:RegularExpressionValidator 
                        ID="RegularExpressionContraseña" runat="server" ValidationGroup="1"
                        ErrorMessage="La contraseña debe tener de 6 a 20 caracteres" ForeColor="Red"
                        ControlToValidate="TextBoxPsswd" ValidationExpression="\S{5,20}">                    
                    </asp:RegularExpressionValidator>

                    <p><asp:TextBox ID="TextBoxPsswd2" runat="server" TextMode="Password"></asp:TextBox></p>
                
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="1"
                        ErrorMessage="¡Las contraseñas deben ser iguales!" ForeColor="Red"
                        ControlToValidate="TextBoxPsswd2" ControlToCompare="TextBoxPsswd" >
                    </asp:CompareValidator>
                
                </div>
                
            </div>
            <div class="usuarioinfcolder">
                <div class="informacionpersonal" style="border-top: solid 4px rgb(51, 162, 197);margin-top:43px">
                   <h2>Información adicional: </h2>
                    <p> <asp:TextBox ID="TextBoxInformacion" runat="server" TextMode="MultiLine"></asp:TextBox> 
                    </p>                   
                </div>

                <div class="informacionpersonal" style="border-top: solid 4px rgb(158, 108, 108);">
                    <h2>Herramientas</h2>
                    
                    <p> <asp:Button ID="BotonEliminarUsuario" ForeColor="Blue" runat="server" 
                            Text="Eliminar mi cuenta" OnClick="BotonEliminarUsuarioOnClick" 
                                BorderStyle="none" BorderWidth="0" Width="0" /> </p>

                </div>
                 
                 <asp:Button ID="BotonEditar" ValidationGroup="1" CssClass="botonanadireditarusr"
                  runat="server" Text="Crear usuario" OnClick="BotonEditarOnClick" />
            </div>
         </div>   
      
    </div>
</asp:Content>
