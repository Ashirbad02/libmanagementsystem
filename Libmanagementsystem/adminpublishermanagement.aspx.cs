using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Libmanagementsystem
{
    public partial class adminpublishermanagement : System.Web.UI.Page
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

        // Add new publisher
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExists())
            {
                Response.Write("<script>alert('Publisher with this ID already exists.');</script>");
            }
            else
            {
                addNewPublisher();
            }
        }

        // Update publisher
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExists())
            {
                updatePublisher();
            }
            else
            {
                Response.Write("<script>alert('Publisher does not exist');</script>");
            }
        }

        // Delete publisher
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExists())
            {
                deletePublisher();
            }
            else
            {
                Response.Write("<script>alert('Publisher does not exist');</script>");
            }
        }

        // "Go" button action
        protected void Button1_Click(object sender, EventArgs e)
        {
            getPublisherById();
        }

        // Check if publisher exists
        bool checkIfPublisherExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tbl where publisher_id=@PublisherID", con);
                cmd.Parameters.AddWithValue("@PublisherID", TextBox1.Text.Trim());

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

        // Add new publisher
        void addNewPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl (publisher_id, publisher_name) values(@PublisherID, @PublisherName)", con);
                cmd.Parameters.AddWithValue("@PublisherID", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@PublisherName", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Publisher added successfully.');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        // Update publisher
        void updatePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl SET publisher_name=@PublisherName WHERE publisher_id=@PublisherID", con);
                cmd.Parameters.AddWithValue("@PublisherID", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@PublisherName", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Publisher updated successfully.');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        // Delete publisher
        void deletePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from publisher_master_tbl WHERE publisher_id=@PublisherID", con);
                cmd.Parameters.AddWithValue("@PublisherID", TextBox1.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Publisher deleted successfully.');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        // Get publisher by ID
        void getPublisherById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tbl WHERE publisher_id=@PublisherID", con);
                cmd.Parameters.AddWithValue("@PublisherID", TextBox1.Text.Trim());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    TextBox2.Text = dr["publisher_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Publisher does not exist.');</script>");
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
