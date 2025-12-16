using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Data.SqlClient;

namespace ProyectoWeb
{
    public partial class _Default : System.Web.UI.Page
    {
        private static readonly HttpClient cliente = new HttpClient();
        private static readonly string apiKey = "543f87ad";

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                await CargarPeliculasPopulares();
                await CargarPeliculasAccion();
                await CargarPeliculasTerror();
                await CargarPeliculasSciFi();
                await CargarPeliculasComedia();
                await CargarPeliculasAnimacion();

               
                await CargarSeriesPopulares();
                await CargarSeriesSciFi();
                await CargarSeriesComedia();
                await CargarSeriesDrama();
                await CargarSeriesAccion();
                await CargarSeriesTerror();
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


        private void GuardarPelicula(string titulo, string poster, string categoria)
        {
            string cs = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(cs))
            {
                string sql = @"IF NOT EXISTS (SELECT 1 FROM Peliculas WHERE Titulo=@Titulo)
                               INSERT INTO Peliculas (Titulo, Poster, Categoria, Tipo)
                               VALUES (@Titulo, @Poster, @Categoria, 'Pelicula')";

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Titulo", titulo);
                cmd.Parameters.AddWithValue("@Poster", poster);
                cmd.Parameters.AddWithValue("@Categoria", categoria);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void GuardarSerie(string titulo, string poster, string categoria)
        {
            string cs = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;

            using (SqlConnection cn = new SqlConnection(cs))
            {
                string sql = @"IF NOT EXISTS (SELECT 1 FROM Series WHERE Titulo=@Titulo)
                               INSERT INTO Series (Titulo, Poster, Categoria, Tipo)
                               VALUES (@Titulo, @Poster, @Categoria, 'Serie')";

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Titulo", titulo);
                cmd.Parameters.AddWithValue("@Poster", poster);
                cmd.Parameters.AddWithValue("@Categoria", categoria);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

         

        private async Task CargarPeliculas(string[] lista, HtmlGenericControl contenedor, string categoria)
        {
            if (contenedor == null) return;
            contenedor.InnerHtml = "";

            foreach (string titulo in lista)
            {
                try
                {
                    string url = $"https://www.omdbapi.com/?t={Uri.EscapeDataString(titulo)}&apikey={apiKey}";
                    string resp = await cliente.GetStringAsync(url);
                    JObject json = JObject.Parse(resp);

                    if (json["Response"]?.ToString() != "True")
                        continue;

                    string poster = json["Poster"]?.ToString();
                    if (string.IsNullOrEmpty(poster) || poster == "N/A")
                        poster = "images/default-poster.jpg";

                    // Guardar en BD
                    GuardarPelicula(titulo, poster, categoria);

                    contenedor.InnerHtml += $@"
                        <div class='pelicula'>
                            <a href='Pelicula.aspx?titulo={Uri.EscapeDataString(titulo)}'>
                                <img src='{poster}' width='150' />
                            </a>
                        </div>";
                }
                catch { }
            }
        }

        // ===================== MÉTODO GENERAL SERIES =====================

        private async Task CargarSeries(string[] lista, HtmlGenericControl contenedor, string categoria)
        {
            if (contenedor == null) return;
            contenedor.InnerHtml = "";

            foreach (string nombre in lista)
            {
                try
                {
                    string url = $"https://api.tvmaze.com/singlesearch/shows?q={Uri.EscapeDataString(nombre)}";
                    HttpResponseMessage response = await cliente.GetAsync(url);

                    if (!response.IsSuccessStatusCode)
                        continue;

                    JObject json = JObject.Parse(await response.Content.ReadAsStringAsync());

                    string poster = json["image"]?["medium"]?.ToString();
                    if (string.IsNullOrEmpty(poster))
                        poster = "images/default-poster.jpg";

                    // Guardar en BD
                    GuardarSerie(nombre, poster, categoria);

                    contenedor.InnerHtml += $@"
                        <div class='pelicula'>
                            <a href='Serie.aspx?titulo={Uri.EscapeDataString(nombre)}'>
                                <img src='{poster}' width='150' />
                            </a>
                        </div>";
                }
                catch { }
            }
        }

        // ===================== PELÍCULAS =====================

        private async Task CargarPeliculasPopulares()
        {
            string[] lista = {
                "Inception","The Dark Knight","Avatar","Titanic","The Godfather",
                "Pulp Fiction","Fight Club","The Matrix","Forrest Gump","Gladiator",
                "Avengers: Endgame","Interstellar","Joker","Oppenheimer","The Shawshank Redemption"
            };
            await CargarPeliculas(lista, ContenedorPopulares, "Popular");
        }

        private async Task CargarPeliculasAccion()
        {
            string[] lista = {
                "John Wick","John Wick: Chapter 2","John Wick: Chapter 3","John Wick: Chapter 4",
                "Die Hard","Mission: Impossible","Mission: Impossible - Fallout",
                "Terminator 2","Mad Max: Fury Road","The Bourne Ultimatum",
                "Taken","The Raid","The Equalizer","Edge of Tomorrow","Extraction"
            };
            await CargarPeliculas(lista, ContenedorAccion, "Acción");
        }

        private async Task CargarPeliculasTerror()
        {
            string[] lista = {
                "The Conjuring","The Exorcist","Hereditary","It","A Quiet Place",
                "Insidious","The Ring","Halloween","The Shining","Smile",
                "Sinister","The Babadook","Midsommar","The Nun","Lights Out"
            };
            await CargarPeliculas(lista, ContenedorTerror, "Terror");
        }

        private async Task CargarPeliculasSciFi()
        {
            string[] lista = {
                "Interstellar","Dune","Star Wars","Blade Runner","Blade Runner 2049",
                "Arrival","The Matrix","Gravity","Ready Player One","District 9",
                "Minority Report","Oblivion","Tron","Moon","Passengers"
            };
            await CargarPeliculas(lista, ContenedorSciFi, "SciFi");
        }

        private async Task CargarPeliculasComedia()
        {
            string[] lista = {
                "Superbad","The Hangover","21 Jump Street","22 Jump Street","Deadpool",
                "Bruce Almighty","The Mask","Zoolander","Step Brothers","Ted",
                "Ted 2","White Chicks","Dumb and Dumber","Anchorman","Scary Movie"
            };
            await CargarPeliculas(lista, ContenedorComedia, "Comedia");
        }

        private async Task CargarPeliculasAnimacion()
        {
            string[] lista = {
                "Toy Story","Toy Story 2","Toy Story 3","Shrek","Finding Nemo",
                "Inside Out","Coco","Up","Frozen","Frozen II",
                "Ratatouille","Wall-E","Monsters Inc","Zootopia","Kung Fu Panda"
            };
            await CargarPeliculas(lista, ContenedorAnimacion, "Animación");
        }

        // ===================== SERIES =====================

        private async Task CargarSeriesPopulares()
        {
            string[] lista = {
                "Stranger Things","Breaking Bad","Game of Thrones","The Witcher","The Boys",
                "The Mandalorian","Peaky Blinders","Narcos","The Walking Dead","Better Call Saul",
                "House of the Dragon","Westworld","Black Mirror","Chernobyl","The Last of Us"
            };
            await CargarSeries(lista, SeriesPopulares, "Popular");
        }

        private async Task CargarSeriesSciFi()
        {
            string[] lista = {
                "Dark","Doctor Who","The X-Files","Westworld","Andor",
                "Rick and Morty","Star Trek","Star Trek: Discovery","Firefly","The 100",
                "Fringe","Altered Carbon","Foundation","The Orville","Lost"
            };
            await CargarSeries(lista, SeriesSciFi, "SciFi");
        }

        private async Task CargarSeriesComedia()
        {
            string[] lista = {
                "The Office","Brooklyn Nine-Nine","Friends","Parks and Recreation","The Big Bang Theory",
                "Modern Family","How I Met Your Mother","Community","Scrubs","Family Guy",
                "Arrested Development","Seinfeld","Two and a Half Men","The Simpsons","Ted Lasso"
            };
            await CargarSeries(lista, SeriesComedia, "Comedia");
        }

        private async Task CargarSeriesDrama()
        {
            string[] lista = {
                "The Crown","The Last of Us","Succession","House of Cards","Euphoria",
                "This Is Us","13 Reasons Why","Breaking Bad","Better Call Saul","Sons of Anarchy",
                "Ozark","True Detective","The Handmaid's Tale","Mad Men","Yellowstone"
            };
            await CargarSeries(lista, SeriesDrama, "Drama");
        }

        private async Task CargarSeriesAccion()
        {
            string[] lista = {
                "Jack Ryan","The Punisher","Daredevil","Luke Cage","Arrow",
                "The Flash","Supergirl","Gotham","Titans","The Mandalorian",
                "Reacher","Vikings","Into the Badlands","Banshee","24"
            };
            await CargarSeries(lista, SeriesAccion, "Acción");
        }

        private async Task CargarSeriesTerror()
        {
            string[] lista = {
                "The Walking Dead","American Horror Story","The Haunting of Hill House",
                "The Haunting of Bly Manor","Stranger Things","Penny Dreadful",
                "The Strain","Hannibal","Slasher","Mindhunter",
                "Scream: The TV Series","Marianne","From","The Exorcist","Castle Rock"
            };
            await CargarSeries(lista, SeriesTerror, "Terror");
        }
    }
}
