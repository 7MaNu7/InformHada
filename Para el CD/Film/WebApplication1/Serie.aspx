﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Serie.aspx.cs" Inherits="WebApplication1.Serie" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Serie.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div class="contenido">
   
       <!-- CABECERA DE LA serie  -->
        <div class="cabecera_serie">
            <div class="portada_serie">
                <asp:Image ID="fondo" CssClass="fondoblurred" runat="server" />           
            </div>
            <asp:Image ID="caratula" CssClass="caratula" runat="server" />
             <div class="info_cabecera">
                <h2><asp:Literal ID="titulo" runat="server"></asp:Literal></h2>
                <p>Director: <asp:Literal ID="director" runat="server"></asp:Literal></p>
                <p>Genero: <asp:Literal ID="genero" runat="server" >  </asp:Literal> </p>
                <p>Soundtrack: <asp:Literal ID="musica" runat="server"></asp:Literal></p>
                <p>Año: <asp:Literal ID="ano" runat="server"></asp:Literal></p>
             </div>
             <div class="puntuacion">
                <asp:Literal ID="puntuacion" runat="server"></asp:Literal>
             </div>
         </div>

        <div class="serie_contenido">
            <div class="serie_contenido_i">
              <asp:HyperLink ID="BotonEditar" CssClass="anadir" runat="server" EnableViewState="false" Text="Editar" />
                <asp:HyperLink ID="BotonReport" CssClass="reportar" runat="server" Text="Reportar error" />
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                <asp:Rating ID="Rating1" runat="server"     MaxRating="5"
                    StarCssClass="ratingStar"
                   WaitingStarCssClass="waitingstar" FilledStarCssClass="shiningstar"
                    EmptyStarCssClass="blankstar"
                     OnChanged="OnRatingChanged"
>
                </asp:Rating>

            <asp:Label runat="server" ID="Puntos" ForeColor="Red" ></asp:Label>

            </div>
            <div class="serie_contenido_d">
               <h2>Sinopsis</h2>
               <p><asp:Literal ID="sinopsis" runat="server"></asp:Literal></p>

               <h2>Reparto</h2>
               <p><asp:Literal ID="reparto" runat="server"></asp:Literal></p>
                <h2>Trailer</h2>
               <iframe width="820" height="400" src="//www.youtube.com/embed/<asp:Literal ID="trailer" runat="server"></asp:Literal>?rel=0" frameborder="0" allowfullscreen></iframe>
                
                <br />

                <br />
                <h2>Capitulos <asp:HyperLink ID="HyperLinkAddCapitulo" runat="server" Text="AÑADIR"> </asp:HyperLink> </h2>
                <div class="acordeon">
               
                    <asp:Accordion ID="Accordion1" runat="server">
                        <Panes>
                             
                        </Panes>
                    </asp:Accordion>
                </div>

                

                <br />

                <br />
                <h2> 
                    <asp:Literal ID="LiteralComentar" runat="server" > </asp:Literal> 
                
                </h2>
                <asp:Panel ID="Panelcomentar" runat="server">
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
        </div>
        <br /><br /><br /><br /><br />
    </div>
</asp:Content>