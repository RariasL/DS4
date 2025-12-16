<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="ProyectoWeb.Favoritos" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Favoritos</title>
    <link href="Content/style.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">

    <header class="barra">
        <a class="inicio" href="index.aspx">MovieFinder</a>
    </header>

    <h1>⭐ Mis Favoritos</h1>

    <asp:Repeater ID="rptFavoritos" runat="server" OnItemCommand="rptFavoritos_ItemCommand">
        <ItemTemplate>
            <div class="pelicula">

                <a href='Pelicula.aspx?titulo=<%# Eval("Titulo") %>'>
                    <img src='<%# Eval("Poster") %>' width="150" />
                </a>

                <h3><%# Eval("Titulo") %> (<%# Eval("Año") %>)</h3>

                <p><strong>Género:</strong> <%# Eval("Genero") %></p>
                <p><strong>Director:</strong> <%# Eval("Director") %></p>

                <asp:Button 
                    runat="server"
                    Text="🗑 Eliminar"
                    CssClass="btn-eliminar"
                    CommandName="eliminar"
                    CommandArgument='<%# Eval("Id") %>' />
            </div>
        </ItemTemplate>
    </asp:Repeater>

</form>
</body>
</html>
