<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="Pelicula.aspx.cs" 
    Inherits="ProyectoWeb.Pelicula" 
    Async="true" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Detalles de película</title>
    <link href="Content/style.css" rel="stylesheet" />
</head>
<body>

<form id="form1" runat="server">

    <header class="barra">
        <a class="inicio" href="index.aspx">MovieFinder</a>
        <div class="busqueda">
            <asp:TextBox ID="txtBuscar" runat="server" CssClass="input-buscar" placeholder="Buscar..." />
            <asp:Button ID="btnBuscar" runat="server" CssClass="btn-buscar" Text="Buscar" OnClick="btnBuscar_Click" />
            <a href="Favoritos.aspx">⭐ Favoritos</a>

        </div>
    </header>

    <section class="pelicula">
        <div class="detalle">
            <h1><asp:Label ID="lblTitulo" runat="server" /></h1>

            <p><strong>Año:</strong>
                <asp:Label ID="lblAño" runat="server" />
            </p>

            <p><strong>Género:</strong>
                <asp:Label ID="lblGenero" runat="server" />
            </p>

            <p><strong>Director:</strong>
                <asp:Label ID="lblDirector" runat="server" />
            </p>

            <p><strong>Actores:</strong>
                <asp:Label ID="lblActores" runat="server" />
            </p>

            <p><strong>Sinopsis:</strong>
                <asp:Label ID="lblPlot" runat="server" />
            </p>

            <!-- BOTÓN FAVORITO -->
            <asp:Button 
                ID="btnFavorito" 
                runat="server" 
                Text="⭐ Agregar a Favoritos" 
                CssClass="btn-favorito"
                OnClick="btnFavorito_Click" />
        </div>

        <asp:Image 
            ID="imgPoster" 
            runat="server" 
            CssClass="poster-grande" 
            Width="200px" 
            Height="300px" />
    </section>

</form>

</body>
</html>
