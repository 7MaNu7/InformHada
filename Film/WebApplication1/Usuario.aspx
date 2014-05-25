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
                <asp:Image ID="portada" CssClass="fondoblurred" runat="server" />
                
            </div>
             <asp:Image class="fotoperfilusuario" ID="imgperfil" runat="server" />
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
                    <asp:Button ID="VerMasAmigos" runat="server" Text="Ver más" OnClick="VerMasAmigosOnClick" />
                   

                </div>
                 <asp:Panel ID="Panel1" runat="server">
                <div class="infoamigos">
                    <h2>
                        <h2> <asp:Literal ID="LiteralQuizasConozcas" runat="server" Text="Quizás conozcas a..." ></asp:Literal></h2>
                    </h2>
                    
                    <asp:ListView ID="ListViewQuizasConozcas" runat="server">
                         <ItemTemplate>
                             <a href="Usuario.aspx?id=<%# Eval("id2")%>">
                                <img src="img/users/<%# Eval("id2")%>.jpg" />
                             </a>
                         </ItemTemplate>
                    </asp:ListView>

                    <asp:Button ID="VerMasPosiblesAmigos" runat="server" Text="Ver más" OnClick="VerMasPosiblesAmigosOnClick" />
                    </div>

                    </asp:Panel>

               
            </div>
            <div class="usuarioinfcolder">
                <div class="informacionpersonal" style="border-top: solid 4px rgb(51, 162, 197)">
                    <h2>Información adicional</h2>
                    <p><asp:Literal ID="LiteralInformacion" runat="server"> </asp:Literal> </p>                    
                </div>

                <div class="informacionpersonal" style="border-top: solid 4px rgb(158, 108, 108);">
                    <h2>Herramientas</h2>

                    <p> <asp:HyperLink ID="HyperLinkAddPelicula" runat="server" 
                            EnableViewState="false" PostBackUrl="String"> Añadir película </asp:HyperLink> </p>

                    <p> <asp:HyperLink ID="HyperLinkAddSerie" runat="server" 
                        EnableViewState="false" PostBackUrl="String"> Añadir serie </asp:HyperLink> </p>

                    <p> <asp:Button ID="BotonEliminarUsuario" ForeColor="Blue" runat="server" Text="Eliminar mi cuenta" 
                         OnClick="BotonEliminarUsuarioOnClick" BorderStyle="none" BorderWidth="0" Width="0" /> </p>

                </div>
                <asp:Button ID="BotonEditar" CssClass="botonanadireditarusr" runat="server" OnClick="BotonEditarOnClick" Text="Editar" />
            </div>
         </div>
        </div>
</asp:Content>
