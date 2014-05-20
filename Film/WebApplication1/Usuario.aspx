<%@ Page Title="Mario" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Usuario.aspx.cs" Inherits="WebApplication1.Usuario" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Usuario.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div class="contenido">

        <!-- CABECERA DEL USUARIO  -->
        <div class="cabecera_usuario">
            <div class="portada_usuario">
                <img class="fondoblurred" src="http://t1.gstatic.com/images?q=tbn:ANd9GcT3HhDuErxy_xMEFj9ie_T5q2sxgM5mB9Kp5CRGrC1BO1zqQ9Cl" alt="fotou_portada"/>
            </div>
             <img class="fotoperfilusuario" src="http://vang.blob.core.windows.net/images/2013/03/26/dempseey.jpg" alt="fotou_perfil"/>
             <div class="infocabecera">
                <h2> <asp:Literal ID="LiteralNombre1" runat="server"> </asp:Literal>    
               <asp:Button ID="BotonAmigo" CssClass="botonamigo" runat="server" OnClick="BotonAmigoOnClick" /> 
                </h2>
                <p> <asp:Literal ID="LiteralEmail1" runat="server"> </asp:Literal>  </p>
             </div>
         </div>

         <!-- PARTE DE ABAJO DEL USUARIO  -->
         <div class="informacionusuario">
            <div class="usuarioinfcolizq">
                <div class="informacionpersonal">
                    
                    <h2>Información personal</h2>
                    <p> <asp:Literal ID="LiteralNombre" runat="server"> </asp:Literal></p>
                    <p> <asp:Literal ID="LiteralFechaNacimiento" runat="server"> </asp:Literal></p>
                    <p> <asp:Literal ID="LiteralSexo" runat="server"> </asp:Literal></p>
                    <p> <asp:Literal ID="LiteralProvincia" runat="server"> </asp:Literal> , <asp:Literal ID="LiteralPais" runat="server"> </asp:Literal> </p>
                    <p> <asp:Literal ID="LiteralEmail" runat="server"> </asp:Literal>  </p>
                </div>
                <div class="infoamigos">
                    <h2>Amigos</h2>
                    <asp:ListView ID="ListViewAmigos" runat="server">
                         <ItemTemplate>
                             <a href="Usuario.aspx?id=<%# Eval("id2")%>">
                                <img src="img/users/<%# Eval("id2")%>.jpg" />
                             </a>
                         </ItemTemplate>
                    </asp:ListView>
                    <p>Ver más</p>
                </div>
                <div class="infoamigos">
                    <h2>Quizás conozcas a...</h2>
                    <img src="http://us.cdn1.123rf.com/168nwm/tuulijumala/tuulijumala1304/tuulijumala130400006/18849611-por-defecto-avatar-internet-en-estilo-antiguo-marco-de-fotos.jpg" alt="amigo1"/>
                    <img src="http://us.cdn1.123rf.com/168nwm/tuulijumala/tuulijumala1304/tuulijumala130400006/18849611-por-defecto-avatar-internet-en-estilo-antiguo-marco-de-fotos.jpg" alt="amigo1"/>
                    <img src="http://us.cdn1.123rf.com/168nwm/tuulijumala/tuulijumala1304/tuulijumala130400006/18849611-por-defecto-avatar-internet-en-estilo-antiguo-marco-de-fotos.jpg" alt="amigo1"/>
                    <img src="http://us.cdn1.123rf.com/168nwm/tuulijumala/tuulijumala1304/tuulijumala130400006/18849611-por-defecto-avatar-internet-en-estilo-antiguo-marco-de-fotos.jpg" alt="amigo1"/>
                    <img src="http://us.cdn1.123rf.com/168nwm/tuulijumala/tuulijumala1304/tuulijumala130400006/18849611-por-defecto-avatar-internet-en-estilo-antiguo-marco-de-fotos.jpg" alt="amigo1"/>
                    <img src="http://us.cdn1.123rf.com/168nwm/tuulijumala/tuulijumala1304/tuulijumala130400006/18849611-por-defecto-avatar-internet-en-estilo-antiguo-marco-de-fotos.jpg" alt="amigo1"/>
                    <img src="http://us.cdn1.123rf.com/168nwm/tuulijumala/tuulijumala1304/tuulijumala130400006/18849611-por-defecto-avatar-internet-en-estilo-antiguo-marco-de-fotos.jpg" alt="amigo1"/>
                    <img src="http://us.cdn1.123rf.com/168nwm/tuulijumala/tuulijumala1304/tuulijumala130400006/18849611-por-defecto-avatar-internet-en-estilo-antiguo-marco-de-fotos.jpg" alt="amigo1"/>
                    <img src="http://us.cdn1.123rf.com/168nwm/tuulijumala/tuulijumala1304/tuulijumala130400006/18849611-por-defecto-avatar-internet-en-estilo-antiguo-marco-de-fotos.jpg" alt="amigo1"/>
                    <p>Ver más</p>
                </div>
            </div>
            <div class="usuarioinfcolder">
                <div class="informacionpersonal" style="border-top: solid 4px rgb(51, 162, 197)">
                    <h2>Información adicional</h2>
                    <p><asp:Literal ID="LiteralInformacion" runat="server"> </asp:Literal> </p>                    
                </div>

                <div class="informacionpersonal" style="border-top: solid 4px rgb(158, 108, 108);">
                    <h2>Herramientas</h2>
                    <p> <asp:HyperLink ID="HyperLinkAddPelicula" runat="server" EnableViewState="false" PostBackUrl="String"> Añadir película </asp:HyperLink> </p>
                    <p> <asp:HyperLink ID="HyperLinkAddSerie" runat="server" EnableViewState="false" PostBackUrl="String"> Añadir serie </asp:HyperLink> </p>
                    <p> <asp:HyperLink ID="HyperLinkEditUsuario" runat="server" EnableViewState="false" PostBackUrl="String"> Editar mi usuario </asp:HyperLink> </p>
                    <p> <asp:HyperLink ID="HyperLinkEliminarUsuario" runat="server" EnableViewState="false" PostBackUrl="String"> Eliminar mi cuenta </asp:HyperLink> </p>
                </div>
                <asp:Button ID="BotonEditar" CssClass="botonanadireditarusr" runat="server" OnClick=BotonEditarOnClick Text="Editar" />
            </div>
         </div>
        

    </div>
</asp:Content>
