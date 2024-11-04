using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Libmanagementsystem
{
    public partial class authomanagement : System.Web.UI.Page
    {
        // Connection string from the Web.config
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataBind();
            }
        }

        // Add new author
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExists())
            {
                Response.Write("<script>alert('Author with this ID already exists.');</script>");
            }
            else
            {
                addNewAuthor();
            }
        }

        // Update author
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExists())
            {
                updateAuthor();
            }
            else
            {
                Response.Write("<script>alert('Author does not exist');</script>");
            }
        }

        // Delete author
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExists())
            {
                deleteAuthor();
            }
            else
            {
                Response.Write("<script>alert('Author does not exist');</script>");
            }
        }

        // "Go" button action
        protected void Button1_Click(object sender, EventArgs e)
        {
            getAuthorById();
        }

        // Check if author exists
        bool checkIfAuthorExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from author_master_tbl where author_id=@AuthorID", con);
                cmd.Parameters.AddWithValue("@AuthorID", TextBox1.Text.Trim());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt.Rows.Count >= 1;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        // Add new author
        void addNewAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl (author_id, author_name) values(@AuthorID, @AuthorName)", con);
                cmd.Parameters.AddWithValue("@AuthorID", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@AuthorName", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Author added successfully.');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        // Update author
        void updateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name=@AuthorName WHERE author_id=@AuthorID", con);
                cmd.Parameters.AddWithValue("@AuthorID", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@AuthorName", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Author updated successfully.');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        // Delete author
        void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from author_master_tbl WHERE author_id=@AuthorID", con);
                cmd.Parameters.AddWithValue("@AuthorID", TextBox1.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Author deleted successfully.');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        // Get author by ID
        void getAuthorById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from author_master_tbl WHERE author_id=@AuthorID", con);
                cmd.Parameters.AddWithValue("@AuthorID", TextBox1.Text.Trim());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    TextBox2.Text = dr["author_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Author does not exist.');</script>");
                }

                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        // Clear form fields
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        // GridView selected index changed event
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected row
            GridViewRow row = GridView1.SelectedRow;

            // Populate your text boxes or any other controls with the data from the selected row
            TextBox1.Text = row.Cells[1].Text; // Assuming the ID is in the first cell
            TextBox2.Text = row.Cells[2].Text; // Assuming the name is in the second cell
        }
    }
}
