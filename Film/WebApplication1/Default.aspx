﻿<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="/Styles/Default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <div class="cabecerausuario">
        <div class="fondoblurreddiv" style="background-image:url('');">
            <div class="oscurecer"></div>
            <img class="fondoblurred" src="http://www.pordede.com/content/homecover.png" alt="fotou_portada"/>
        </div>
       
        <div class="infocabecera">
            <h2>InformaTV</h2>
            <p>La mejor información de tus peliculas y series preferridas Dr.</p>
            <div style="position:relative;">
                <asp:TextBox ID="TextBox1" runat="server">Buscar Peliculas y Series </asp:TextBox>
                <i style="
    color: rgba(0, 0, 0, 0.54);
    font-size: 14px;
    top: 25px;
    position: absolute;
    left: calc(50% - 230px);
" class="fa fa-search"></i>
            </div>
        </div>
   </div>


   <div class="contenido">
    <div class="menuizq">
        <h2>Ver perliculas</h2>  
        <h2>Ver series</h2>  
        <h2>Añadir pelicula</h2>
        <h2>Añadir serie</h2>
        <h2>Entrar / registrarse</h2>
        <h2>Ver mi usuario</h2>
        <h2>Reportar error</h2>

    </div>
    <div class="cabecera_contenido">
        <h2>
        Peliculas añadidas recientemente
        </h2>
        <div class="peliculacaratula">
            <img src="http://cdn.glamour.mx/uploads/images/thumbs/201306/peliculas_brujas_cine_2013_671571654_699x.jpg" alt="Mago de Oz"/>
            <p>Mago de Oz</p>
        </div>

        <div class="peliculacaratula">
            <img src="http://www.cinesimf.com/media/k2/items/cache/057acae1d45bff2130e8f74dbba70218_M.jpg" alt="Divergente"/>
            <p>Divergente</p>
        </div>
        <div class="peliculacaratula">
            <img src="http://www.cinesimf.com/media/k2/items/cache/7df38b307602e35858bf410f5943c060_M.jpg" alt="Rio 2"/>
            <p>Rio 2</p>
        </div>
        <div class="peliculacaratula">
            <img src="http://www.cinesimf.com/media/k2/items/cache/d433202dd708ff711a72952d0a2b333a_M.jpg" alt="Capitán América"/>
            <p>Capitán América</p>
        </div>
        <div class="peliculacaratula">
            <img src="http://www.cinesimf.com/media/k2/items/cache/0d012c529b85966704821973c01a8a0f_M.jpg" alt="Ocho apellidos vascos"/>
            <p>Ocho apellidos vascos</p>
        </div>
    </div>
    
    <div class="cabecera_contenido2">
        <h2>
        Series añadidas recientemente
        </h2>
        <div class="peliculacaratula">
            <img src="http://www.seriesyonkis.com/img/series/170x243/perception.jpg" alt="Perception"/>
            <p>Perception</p>
        </div>

        <div class="peliculacaratula">
            <img src="http://www.seriesyonkis.com/img/series/170x243/dexter.jpg" alt="Dexter"/>
            <p>Dexter</p>
        </div>
        <div class="peliculacaratula">
            <img src="http://www.seriesyonkis.com/img/series/170x243/vikings-2013.jpg" alt="Vikings"/>
            <p>Vikings</p>
        </div>
        <div class="peliculacaratula">
            <img src="http://www.seriesyonkis.com/img/series/170x243/mentes-criminales.jpg" alt="Mentes criminales"/>
            <p>Mentes criminales</p>
        </div>
        <div class="peliculacaratula">
            <img src="http://www.seriesyonkis.com/img/series/170x243/dos-hombres-y-medio-two-and-a-half-men.jpg" alt="Dos hombres y medio"/>
            <p>Dos hombres y medio</p>
        </div>
    </div>
    
    <div class="cabecera_contenido2">
        <h2>
            Películas y series mejor puntuadas
        </h2>
        <div class="peliculacaratula">
            <img src="http://cdn.opensly.com/pelis/KWH3X3AETA.jpg" alt="La tostadora valiente"/>
            <p>La tostadora valiente</p>
        </div>

        <div class="peliculacaratula">
            <img src="http://cdn.opensly.com/pelis/FTCFEYWF4F.jpg" alt="The Amazing Spider-Man 2"/>
            <p>The Amazing Spider-Man</p>
        </div>
        <div class="peliculacaratula">
            <img src="http://cdn.opensly.com/pelis/T5U4AHVKY6.jpg" alt="Exposados"/>
            <p>Exposados</p>
        </div>
        <div class="peliculacaratula">
            <img src="http://cdn.opensly.com/pelis/V32WA5YRYZ.jpg" alt="El arte de pasar de todo"/>
            <p>El arte de pasar de todo</p>
        </div>
        <div class="peliculacaratula">
            <img src="http://cdn.opensly.com/pelis/ZUY7N4ZYXH.jpg" alt="Templario"/>
            <p>Templario</p>
        </div>
    </div>
    <div class="cabecera_contenido2">
        <div class="peliculacaratula">
            <img src="http://cdn.opensly.com/series/5HHY9YEFN7.jpg" alt="Como conocí a vuestra madre"/>
            <p>Como conocí a vuestra...</p>
        </div>

        <div class="peliculacaratula">
            <img src="http://cdn.opensly.com/series/CUE2CNKTN6.jpg" alt="Los Simpson"/>
            <p>Los Simpson</p>
        </div>
        <div class="peliculacaratula">
            <img src="http://cdn.opensly.com/series/SHXUD6PDPD.jpg" alt="Prison break"/>
            <p>Prison break</p>
        </div>
        <div class="peliculacaratula">
            <img src="http://cdn.opensly.com/series/EXS9A9CU9R.jpg" alt="Resurrection"/>
            <p>Resurrection</p>
        </div>
        <div class="peliculacaratula">
            <img src="http://cdn.opensly.com/series/SR43CKE932.jpg" alt="Salvados por la campana"/>
            <p>Salvados por la campana</p>
        </div>
    </div>
    </div>
</asp:Content>
