using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Configuration;

namespace ProyectoWeb
{
    public partial class Pelicula : System.Web.UI.Page
    {
        private static readonly string apiKey = "543f87ad";

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string titulo = Request.QueryString["titulo"];
                if (!string.IsNullOrEmpty(titulo))
                {
                    await BuscarPeliculaAsync(titulo);
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string titulo = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(titulo))
            {
                Response.Redirect("Pelicula.aspx?titulo=" + Uri.EscapeDataString(titulo));
            }
        }

        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            if (Session["PeliculaActual"] == null)
                return;

            JObject pelicula = (JObject)Session["PeliculaActual"];
            GuardarFavoritoEnBD(pelicula);
        }

        private async Task BuscarPeliculaAsync(string titulo)
        {
            string url = $"https://www.omdbapi.com/?t={Uri.EscapeDataString(titulo)}&apikey={apiKey}";

            using (HttpClient cliente = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await cliente.GetAsync(url);
                    string respuesta = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(respuesta);

                    if (json["Response"]?.ToString() == "False")
                    {
                        lblTitulo.Text = $"Error: {json["Error"]}";
                        LimpiarCampos();
                        return;
                    }

                    // GUARDAR JSON EN SESIÓN
                    Session["PeliculaActual"] = json;

                    lblTitulo.Text = json["Title"]?.ToString() ?? "N/A";
                    lblAño.Text = json["Year"]?.ToString() ?? "N/A";
                    lblGenero.Text = json["Genre"]?.ToString() ?? "N/A";
                    lblDirector.Text = json["Director"]?.ToString() ?? "N/A";
                    lblActores.Text = json["Actors"]?.ToString() ?? "N/A";
                    lblPlot.Text = json["Plot"]?.ToString() ?? "N/A";

                    string poster = json["Poster"]?.ToString();
                    imgPoster.ImageUrl = (!string.IsNullOrEmpty(poster) && poster != "N/A")
                        ? poster
                        : "images/default-poster.jpg";
                }
                catch (Exception ex)
                {
                    lblTitulo.Text = "Error inesperado: " + ex.Message;
                    LimpiarCampos();
                }
            }
        }

        private void GuardarFavoritoEnBD(JObject pelicula)
        {
            string conexion = ConfigurationManager
                                .ConnectionStrings["ConexionDB"]
                                .ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = @"
                    INSERT INTO Favoritos
                    (Titulo, Año, Genero, Director, Actores, Sinopsis, Poster, JsonCompleto)
                    VALUES
                    (@Titulo, @Año, @Genero, @Director, @Actores, @Sinopsis, @Poster, @Json)
                ";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", pelicula["Title"]?.ToString());
                    cmd.Parameters.AddWithValue("@Año", pelicula["Year"]?.ToString());
                    cmd.Parameters.AddWithValue("@Genero", pelicula["Genre"]?.ToString());
                    cmd.Parameters.AddWithValue("@Director", pelicula["Director"]?.ToString());
                    cmd.Parameters.AddWithValue("@Actores", pelicula["Actors"]?.ToString());
                    cmd.Parameters.AddWithValue("@Sinopsis", pelicula["Plot"]?.ToString());
                    cmd.Parameters.AddWithValue("@Poster", pelicula["Poster"]?.ToString());
                    cmd.Parameters.AddWithValue("@Json", pelicula.ToString());

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void LimpiarCampos()
        {
            lblAño.Text = "";
            lblGenero.Text = "";
            lblDirector.Text = "";
            lblActores.Text = "";
            lblPlot.Text = "";
            imgPoster.ImageUrl = "images/default-poster.jpg";
        }
    }
}
