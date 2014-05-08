<%@ Page Title="Adolfo" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Usuario.aspx.cs" Inherits="WebApplication1.Usuario" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Usuario.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div class="contenido">



        <!-- CABECERA DEL USUARIO  -->
        <div class="cabecerausuario">
            <div class="fondoblurreddiv">
                <img class="fondoblurred" src="http://t1.gstatic.com/images?q=tbn:ANd9GcT3HhDuErxy_xMEFj9ie_T5q2sxgM5mB9Kp5CRGrC1BO1zqQ9Cl" alt="fotou_portada"/>
            </div>
             <img class="fotoperfilusuario" src="https://lh5.googleusercontent.com/-gv9HDWtZqIA/AAAAAAAAAAI/AAAAAAAAAXQ/aeD4EsiTBao/s120-c/photo.jpg" alt="fotou_perfil"/>
             <div class="infocabecera">
                <h2>Adolfo </h2>
                <p>adolfo_342@hotmail.com</p>
             </div>
         </div>



         <!-- PARTE DE ABAJO DEL USUARIO  -->
         <div class="informacionusuario">
            <div class="usuarioinfcolizq">
                <div class="informacionpersonal">
                    <h2>Información personal</h2>
                    <p>Adolfo el cerdo</p>
                    <p>24 años</p>
                    <p>Hombreton</p>
                    <p>Alicante, España</p>
                    <p>Adolfo@gcerdos.com</p>
                </div>
                <div class="infoamigos">
                    <h2>Amigos</h2>
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
                    <p>Me llaman Afolf, el trampolín es mi vida, surfear me da vida, creo que mi destino es la vida es cazar la ola más grande
                    y para eso necesito a mi perrito.
                    Me gustan las películas de acción y de animales, sobretodo la de "Los 4 fantásticos y Silver Surfer"</p>                    
                </div>

                <div class="informacionpersonal" style="border-top: solid 4px rgb(158, 108, 108);">
                    <h2>Herramientas</h2>
                    <p>Crear una ficha</p>
                    <p>Editar información personal</p>
                    <p>Eliminar mi cuenta</p>
                </div>
            </div>
         </div>
        

    </div>
</asp:Content>
