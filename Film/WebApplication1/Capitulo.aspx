<%@ Page Title="Vikings - Capitulo 1" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Capitulo.aspx.cs" Inherits="WebApplication1.Capitulo" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Capitulo.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div class="contenido">

         <!-- CABECERA DEL CAPITULO  -->
        <div class="cabecera_capitulo">
            <div class="portada_capitulo" style="background-image:url('');">
                <asp:Image ID="fondo" CssClass="fondoblurred" runat="server" />
             </div>

             <asp:Image ID="caratula" CssClass="caratula" runat="server" />

             <div class="info_cabecera">
                <h2> <asp:Literal ID="LiteralTitulo" runat="server"> </asp:Literal> </h2>
                <p>Serie: <asp:Literal ID="LiteralSerie" runat="server"> </asp:Literal> </p>
                <p>Temporada: <asp:Literal ID="LiteralTemporada" runat="server"> </asp:Literal> </p>
                <p>Capítulo nº: <asp:Literal ID="LiteralNCapitulo" runat="server"> </asp:Literal> </p>
             </div>
         </div>

        <div class="contenido_capitulo">
            <div class="contenido_capitulo_i">
                
                <asp:HyperLink ID="BotonEditar" CssClass="anadir" runat="server" EnableViewState="false" Text="Editar" />
                <asp:HyperLink ID="BotonReport" CssClass="reportar" runat="server" Text="Reportar error" /> 

            </div>
            <div class="contenido_capitulo_d">
               <h2>Sinopsis - <!--<span style="
                                background: rgba(195, 195, 199, 0.44);
                                font-size: 15px;
                                vertical-align: middle;
                                cursor: pointer;
                                padding: 4px 12px 4px 12px;
                                border-radius: 4px;">EDITAR</span>-->
                                <!--<span> <asp:HyperLink ID="HyperLinkEditarCapitulo" runat="server" Text="Editar"> </asp:HyperLink> </span>-->
               </h2>
               <p> <asp:Literal ID="LiteralSinopsis" runat="server"> </asp:Literal> </p>

               <div class="volver_serie" style="float:right;">
                <p> <asp:HyperLink ID="HyperLinkVolverSerie" runat="server" Text="Volver a la serie"> </asp:HyperLink> </p>
               </div>




                <br />

                <br />
                <asp:Panel ID="Panelcomentar" runat="server">
                <h2> 
                    <asp:Literal ID="LiteralComentar" runat="server" > </asp:Literal> 
                
                </h2>
                <div class="comentario">
                                <div class="comentario_img">
                                    <asp:Image ID="imagen_user" runat="server" CssClass="imagencomentar" />
                                </div>
                                <div class="comentario_txt">     
                                    <span class="comentario_p" > <asp:TextBox ID="TextBoxComentario" placeholder="Danos tu opinión." TextMode="MultiLine" runat="server" style="height: 61px;
                                    min-height: 20px;
                                    width: 497px;
                                    margin: 0px;
                                    border: none; " > </asp:TextBox> </span>

                                </div>
                                  <asp:Button ID="BotonComentar"  runat="server" OnClick="ComentarOnClick" Text="Comentar" CssClass="btncomentar" />
                            </div>
                
              
                </asp:Panel>



                <h2>Comentarios</h2>
                <div class="comentarios">
                    <asp:ListView ID="ListViewComentarios" runat="server">
                        <ItemTemplate>
                            <div class="comentario">
                                <div class="comentario_img">
                                     <img src="img/users/<%# Eval("usuario")%>.jpg" />
                                </div>
                                <div class="comentario_txt">     
                                    <span class="comentario_p" ><%# Eval("texto")%></span>
                                    <span class="comentario_f"><%# Eval("fecha")%></span>

                                    <asp:Button ID="Eliminar" CssClass="Eliminar_comentario"  
                                    runat="server" ToolTip=<%# Eval("usuario")%> Text="Eliminar" 
                                    OnClick="Eliminarcomentario" OnLoad="mostrar"  
                                    CommandArgument=<%# Eval("id")%> />

                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>

            </div>

            <br /><br /><br /><br /><br />
    </div>
</asp:Content>
