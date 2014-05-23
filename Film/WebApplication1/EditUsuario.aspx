<%@ Page Title="Add Usuario" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="EditUsuario.aspx.cs" Inherits="WebApplication1.AddEditUsuario" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Usuario.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div class="contenido">

        <!-- CABECERA DEL USUARIO  -->
        <div class="cabecera_usuario">
            <div class="portada_usuario">
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <img class="fondoblurred" src="http://4.bp.blogspot.com/-8JGsKAeWkB8/T3yuvVFrc9I/AAAAAAAACPE/lLBQtC2F_hs/s1600/The_Grass_aint_Greener.jpg" alt="fotou_portada"/>
                <div id="mybutton2">
                    Cambiar Imagen
                    <asp:FileUpload CssClass="upload"  id="FileUpload2" runat="server" /> 
                </div>
            </div>
             <img class="fotoperfilusuario" src="http://sintoniageek.com/wp-content/uploads/2011/03/avatar-geek-mario1.jpg" alt="fotou_perfil"/>
             <div id="mybutton3">
                Cambiar Imagen
                <asp:FileUpload CssClass="upload"  id="FileUploadControl" runat="server" /> 
                
            </div>
             
             <div class="infocabecera">
                <h2>
                    <asp:Literal ID="LiteralNombre" runat="server" > </asp:Literal>
                </h2>
                    
                    <asp:RegularExpressionValidator 
                    ID="RegularExpressionEmail" runat="server" 
                    ErrorMessage="Escriba un email válido como: ejemplo@dominio.extension" ForeColor="Red"
                    ControlToValidate="TextBoxEmail" ValidationExpression="\S+@\S+\.\S+">                    
                    </asp:RegularExpressionValidator>
                    
                    <p><asp:TextBox CssClass="cabecerasAddEdita" ID="TextBoxEmail" runat="server">e-mail</asp:TextBox></p>
             </div>
         </div>

         <!-- PARTE DE ABAJO DEL USUARIO  -->
         <div class="informacionusuario">
            <div class="usuarioinfcolizq">
                <p id="errorvalidacion" style="visibility:hidden;">Algún campo no se ha introducido correctamente</p>
                <div class="informacionpersonal">
                    <h2>Información personal: </h2>
                    <p><asp:TextBox ID="TextBoxUsuario" runat="server" PlaceHolder="Usuario" ></asp:TextBox></p>
                    <asp:RequiredFieldValidator ID="UserNameReq" runat="server" ControlToValidate="TextBoxUsuario" ErrorMessage="¡Introduce el usuario!"> </asp:RequiredFieldValidator>
                    <p><asp:TextBox ID="TextBoxFechaNacimiento" PlaceHolder="Fecha de nacimiento" runat="server"></asp:TextBox></p>
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
                        ID="RegularExpressionContraseña" runat="server" 
                        ErrorMessage="La contraseña debe tener de 6 a 20 caracteres" ForeColor="Red"
                        ControlToValidate="TextBoxPsswd" ValidationExpression="\S{5,20}">                    
                    </asp:RegularExpressionValidator>

                    <p><asp:TextBox ID="TextBoxPsswd2" runat="server" TextMode="Password"></asp:TextBox></p>
                
                    <asp:CustomValidator ID="ValidarPsswdIguales" runat="server" ControlToValidate="TextBoxPsswd" 
                        OnServerValidate="ComprobarPsswd" ForeColor="Red"
                        ErrorMessage="¡Las contraseñas deben ser iguales!"> 
                    </asp:CustomValidator>
                
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
                    <p>Eliminar mi cuenta</p>
                </div>
                 
                 <asp:Button ID="BotonEditar" CssClass="botonanadireditarusr" runat="server" Text="Crear usuario" OnClick="BotonEditarOnClick" />
            </div>
         </div>   
      
    </div>
</asp:Content>
