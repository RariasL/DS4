<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ProyectoWeb._Default" Async="true" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>MovieFinder - Inicio</title>
    <link href="Content/style.css" rel="stylesheet"/>
</head>
<body>
<form id="form1" runat="server">

 
    <header class="barra">
        <a class="inicio" href="index.aspx">MovieFinder</a>

        <div class="busqueda">
            <asp:TextBox ID="txtBuscar" runat="server" CssClass="input-buscar" placeholder="Buscar..." />
            <asp:Button ID="btnBuscar" runat="server" CssClass="btn-buscar" Text="Buscar" OnClick="btnBuscar_Click" />
            <a class="fav" href="Favoritos.aspx">⭐ Favoritos</a>

        </div>
    </header>

  


    <h1>Películas populares</h1>
    <section>
        <div class="galeria" id="ContenedorPopulares" runat="server"></div>
    </section>

    <h1>Películas de acción</h1>
    <section>
        <div class="galeria" id="ContenedorAccion" runat="server"></div>
    </section>

    <h1>Películas de terror</h1>
    <section>
        <div class="galeria" id="ContenedorTerror" runat="server"></div>
    </section>

    <h1>Películas de ciencia ficción</h1>
    <section>
        <div class="galeria" id="ContenedorSciFi" runat="server"></div>
    </section>

    <h1>Películas de comedia</h1>
    <section>
        <div class="galeria" id="ContenedorComedia" runat="server"></div>
    </section>

    <h1>Películas de animación</h1>
    <section>
        <div class="galeria" id="ContenedorAnimacion" runat="server"></div>
    </section>


     


    <h1>Series populares</h1>
    <section>
        <div class="galeria" id="SeriesPopulares" runat="server"></div>
    </section>

    <h1>Series Sci-Fi</h1>
    <section>
        <div class="galeria" id="SeriesSciFi" runat="server"></div>
    </section>

    <h1>Series de comedia</h1>
    <section>
        <div class="galeria" id="SeriesComedia" runat="server"></div>
    </section>

    <h1>Series de drama</h1>
    <section>
        <div class="galeria" id="SeriesDrama" runat="server"></div>
    </section>

    <h1>Series de acción</h1>
    <section>
        <div class="galeria" id="SeriesAccion" runat="server"></div>
    </section>

    <h1>Series de terror</h1>
    <section>
        <div class="galeria" id="SeriesTerror" runat="server"></div>
    </section>

</form>
    <footer>
        <p>© 2025 MovieFinder. Todos los derechos reservados.</p>   
        </footer>
</body>
</html>
