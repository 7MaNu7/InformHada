﻿<%@ Page Title="Add Usuario" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="AddEditUsuario.aspx.cs" Inherits="WebApplication1.AddEditUsuario" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Usuario.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div class="contenido">

        <!-- CABECERA DEL USUARIO  -->
        <div class="cabecerausuario">
            <div class="fondoblurreddiv">
                <img class="fondoblurred" src="http://4.bp.blogspot.com/-8JGsKAeWkB8/T3yuvVFrc9I/AAAAAAAACPE/lLBQtC2F_hs/s1600/The_Grass_aint_Greener.jpg" alt="fotou_portada"/>
            </div>
             <img class="fotoperfilusuario" src="http://www.fisioclinica.es/wp-content/uploads/2014/02/imagenes-de-fondo-blanco-2.jpg" alt="fotou_perfil"/>
             <div class="infocabecera">=
                <h2><asp:TextBox CssClass="cabecerasAddEdit" ID="TextBoxNombre" runat="server" Font-Size="1.5em" >Nombre</asp:TextBox></h2>
                    <p><asp:TextBox CssClass="cabecerasAddEdit" ID="TextBoxemail" runat="server">e-mail</asp:TextBox></p>
             </div>
         </div>

         <!-- PARTE DE ABAJO DEL USUARIO  -->
         <div class="informacionusuario">
            <div class="usuarioinfcolizq">
                <p id="errorvalidacion" style="visibility:hidden;">Algún campo no se ha introducido correctamente</p>
                <div class="informacionpersonal">
                    <h2>Información personal: </h2>
                    <p><asp:TextBox ID="TextBoxUsuario" runat="server">Usuario</asp:TextBox></p>
                    <asp:RequiredFieldValidator ID="UserNameReq" runat="server" ControlToValidate="TextBoxUsuario" ErrorMessage="¡Introduce el usuario!"> </asp:RequiredFieldValidator>
                    <p><asp:TextBox ID="TextBoxEdad" runat="server">Edad</asp:TextBox></p>
                    <p>Sexo:</p>
                    <p><asp:RadioButton ID="RadioButtonsexohombre" runat="server" Text="Varón"/> <asp:RadioButton ID="RadioButtonsexomujer" runat="server" Text="Mujer"/></p>
                    <p><asp:TextBox ID="TextBoxPais" runat="server">País</asp:TextBox></p>
                    <p><asp:TextBox ID="TextBoxPrivincia" runat="server">Provincia</asp:TextBox></p>
                </div>
                <div class="infoamigos">
                    <h2>Contraseña</h2>
                    <p><asp:TextBox ID="TextBox2" runat="server">Contraseña</asp:TextBox></p>
                    <p><asp:TextBox ID="TextBox3" runat="server">Repita contraseña</asp:TextBox></p>
                </div>
            </div>
            <div class="usuarioinfcolder">
                <div class="informacionpersonal" style="border-top: solid 4px rgb(51, 162, 197);margin-top:43px">
                   <h2>Información adicional: </h2>
                    <p> <asp:TextBox ID="TextBoxInformacionAdicional" runat="server"  ></asp:TextBox> 
                    </p>                   
                </div>

                <div class="informacionpersonal" style="border-top: solid 4px rgb(158, 108, 108);">
                    <h2>Herramientas</h2>
                    <p>Eliminar mi cuenta</p>
                </div>
            </div>
         </div>
        

    </div>
</asp:Content>