<%@ Page Title="Anadir o Editar película" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="AddEditSerie.aspx.cs" Inherits="WebApplication1.AddEditSerie" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Pelicula.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div class="contenido">

        <!-- CABECERA DE LA SERIE  -->
        <div class="cabecera_pelicula">
            <div class="portada_serie" style="background-image:url('');">
                <img class="fondoblurred" src="http://dfghj7h6esbng.cloudfront.net/wp-content/uploads/2013/10/EEEEE.jpg" alt="fotou_portada"/>
                 <div id="mybutton2">
                    Cambiar Imagen
                    <asp:FileUpload CssClass="upload"  id="FileUpload1" runat="server" /> 
                </div>
            </div>
             <img class="caratula" src="http://1.bp.blogspot.com/-vxniewvE-is/Uev-hLHff4I/AAAAAAAAYFE/M2-s72D2iM4/s1600/13060086-vista-frontal-de-un-rollo-de-pelicula-con-una-tira-de-pelicula-delante-de-el-3d.jpg" alt="fotou_perfil"/>
              
              <div id="mybutton">
                Cambiar Imagen
                <asp:FileUpload CssClass="upload"  id="FileUploadControl" runat="server" /> 
                
            </div>
            <div class="info_cabecera">
                
                <h2> 
                    <asp:TextBox ID="TextBoxTitulo" placeholder="Titulo" runat="server" > </asp:TextBox> 
                    <asp:Literal ID="LiteralTitulo" runat="server" > </asp:Literal>   
                    <asp:RequiredFieldValidator CssClass="ValidarTitulo" ID="ValidarTituloRelleno" runat="server" 
                        Text="¡Escribe un título!" ForeColor="White" 
                        ControlToValidate="TextBoxTitulo" ValidationGroup="1" > 
                    </asp:RequiredFieldValidator>
                </h2>

                <p> <asp:TextBox ID="TextBoxDirector" runat="server" placeholder="Director" >  </asp:TextBox> </p>
                <p> <asp:TextBox ID="TextBoxGenero" runat="server" placeholder="Genero" >  </asp:TextBox> </p>
                <p> <asp:TextBox ID="TextBoxBandaSonora" placeholder="Banda Sonora" runat="server"></asp:TextBox> </p>
                <p> <asp:TextBox ID="TextBoxAno" placeholder="Año" runat="server" ></asp:TextBox> </p>
               
             </div>
         </div>

        <div class="pelicula_contenido">
            <div class="pelicula_contenido_i">
                <asp:Button ID="BotonAddEdit" CssClass="anadir" runat="server" Text="Guardar cambios"
                     OnClick="BotonAddEditOnClick" />
            </div>
            <div class="pelicula_contenido_d">
               <h2>Sinopsis</h2>
               <p> <asp:TextBox ID="TextBoxSinopsis" runat="server"  TextMode="MultiLine" 
                    style="height:131px; width:945px;" placeholder="Escriba la sinopsis de la serie aquí">
                   </asp:TextBox>
               </p>

               <h2>Reparto</h2>
               <p> <asp:TextBox ID="TextBoxReparto" runat="server" TextMode="MultiLine" style="height:50px; width:945px;"
                    placeholder="Escriba el reparto de actores que participan en la serie">
                   </asp:TextBox>
               </p>
            
                <h2>Trailer</h2>
                <p> <asp:TextBox ID="TextBoxTrailer" runat="server" TextMode="MultiLine"
                        style="width:945px;" placeholder="Indique el enlace o archivo del trailer de la serie">
                    </asp:TextBox>
                </p>
                
                <h2>Capitulos - <span style="
                                background: rgba(195, 195, 199, 0.44);
                                font-size: 15px;
                                vertical-align: middle;
                                cursor: pointer;
                                padding: 4px 12px 4px 12px;
                                border-radius: 4px;">AÑADIR</span>
                </h2>
                
                </div>
            </div>
        </div>
    </div>
</asp:Content>



