<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="ProyectoWeb.Favoritos" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Mis Favoritos</title>
    <link href="Content/fav.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">

    <header class="barra">
        <a class="inicio" href="index.aspx">MovieFinder</a>
        <h2>⭐ Favoritos</h2>
    </header>

    <section class="galeria">

        <asp:Repeater ID="rptFavoritos" runat="server" OnItemCommand="rptFavoritos_ItemCommand">
            <ItemTemplate>

                <div class="pelicula tarjeta-favorito">

                    <!-- Poster -->
                    <img src='<%# Eval("Poster") %>' alt="Poster" />

                    <!-- Info -->
                    <div class="info">
                        <h2><%# Eval("Titulo") %></h2>

                        <p><strong>Año:</strong> <%# Eval("Año") %></p>
                        <p><strong>Género:</strong> <%# Eval("Genero") %></p>
                        <p><strong>Director:</strong> <%# Eval("Director") %></p>
                        <p><strong>Actores:</strong> <%# Eval("Actores") %></p>

                        <p class="sinopsis">
                            <%# Eval("Sinopsis") %>
                        </p>

                        <!-- Botones -->
                        <div class="acciones">
                            <asp:Button
                                runat="server"
                                Text="Ver"
                                CssClass="btn-ver"
                                CommandName="ver"
                                CommandArgument='<%# Eval("Titulo") %>' />

                            <asp:Button
                                runat="server"
                                Text="Eliminar"
                                CssClass="btn-eliminar"
                                CommandName="eliminar"
                                CommandArgument='<%# Eval("Id") %>' />
                        </div>
                    </div>

                </div>

            </ItemTemplate>
        </asp:Repeater>

    </section>

</form>
</body>
</html>
