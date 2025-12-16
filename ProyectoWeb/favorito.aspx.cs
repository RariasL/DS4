using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoWeb
{
    public partial class Favoritos : System.Web.UI.Page
    {
        string conexion = ConfigurationManager
            .ConnectionStrings["ConexionDB"]
            .ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarFavoritos();
            }
        }

        private void CargarFavoritos()
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string sql = @"
            SELECT 
                Id,
                Titulo,
                [Año],
                Genero,
                Director,
                Actores,
                Sinopsis,
                Poster,
                FechaAgregado
            FROM Favoritos
            ORDER BY FechaAgregado DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rptFavoritos.DataSource = dt;
                rptFavoritos.DataBind();
            }
        }


        protected void rptFavoritos_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "eliminar")
            {
                EliminarFavorito(Convert.ToInt32(e.CommandArgument));
                CargarFavoritos();
            }
        }

        private void EliminarFavorito(int id)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string sql = "DELETE FROM Favoritos WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
