using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.EnterpriseServices;

namespace Libmanagementsystem
{
    public partial class adminbookInventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillAuthorPublisherValues();
                GridViewInventory.DataBind();
            }
        }
        protected void GridViewInventory_SelectedIndexChanged1(object sender, EventArgs e)
        {
            // Add your logic here. Example:
            int index = GridViewInventory.SelectedIndex;
            string bookID = GridViewInventory.DataKeys[index].Value.ToString();

            // Perform action based on selected book ID
        }


        protected void ButtonGo_Click(object sender, EventArgs e)
        {
            getBookbyID();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            // add button logic
            if (checkIfBookExists())
            {
                Response.Write("<script>alert('Book Already Exists, try some other Book ID');</script>");
                ClearFormFields();
            }
            else
            {
                addNewBook();
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            updateBookbyID();
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            deleteBookbyID();
        }

        void deleteBookbyID()
        {
            if (checkIfBookExists())
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("DELETE from book_master_tbl WHERE book_id = @book_id", con);
                        cmd.Parameters.AddWithValue("@book_id", TextBoxBookID.Text.Trim());

                        cmd.ExecuteNonQuery();
                        Response.Write("<script>alert('Book Deleted Successfully');</script>");
                        ClearFormFields();
                        GridViewInventory.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID');</script>");
                ClearFormFields();
            }
        }

        bool checkIfBookExists()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id = @book_id", con))
                    {
                        cmd.Parameters.AddWithValue("@book_id", TextBoxBookID.Text.Trim());
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            return dt.Rows.Count > 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void getBookbyID()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl WHERE book_id=@book_id", con);
                    cmd.Parameters.AddWithValue("@book_id", TextBoxBookID.Text.Trim());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count >= 1)
                    {
                        TextBoxBookName.Text = dt.Rows[0]["book_name"].ToString();
                        TextBoxPublishDate.Text = dt.Rows[0]["publish_date"].ToString();
                        DropDownListLanguage.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                        DropDownListPublisher.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                        DropDownListAuthor.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();

                        TextBoxEdition.Text = dt.Rows[0]["edition"].ToString();
                        TextBoxCostPerUnit.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                        TextBoxPages.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                        TextBoxActualStock.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                        TextBoxCurrentStock.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                        TextBoxBookIssued.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));

                        listbox1.ClearSelection();
                        string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                        for (int i = 0; i < genre.Length; i++)
                        {
                            for (int j = 0; j < listbox1.Items.Count; j++)
                            {
                                if (listbox1.Items[j].ToString() == genre[i])
                                {
                                    listbox1.Items[j].Selected = true;
                                }
                            }
                        }

                        global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                        global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                        global_issued_books = global_actual_stock - global_current_stock;
                        global_filepath = dt.Rows[0]["book_img_link"].ToString();
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Book ID');</script>");
                        ClearFormFields();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void updateBookbyID()
        {
            try
            {
                int actual_stock = Convert.ToInt32(TextBoxActualStock.Text.Trim());
                int current_stock = Convert.ToInt32(TextBoxCurrentStock.Text.Trim());

                if (actual_stock < global_issued_books)
                {
                    Response.Write("<script>alert('Actual Stock value cannot be less than the Issued books');</script>");
                    return;
                }
                else
                {
                    current_stock = actual_stock - global_issued_books;
                    TextBoxCurrentStock.Text = current_stock.ToString();
                }

                string genres = "";
                foreach (int i in listbox1.GetSelectedIndices())
                {
                    genres += listbox1.Items[i].ToString() + ",";
                }
                genres = genres.TrimEnd(',');

                string filepath = global_filepath;
                if (FileUpload1.HasFile)
                {
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.SaveAs(Server.MapPath("book_pictures/" + filename));
                    filepath = "~/book_pictures/" + filename;
                }

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl SET " +
                        "book_name = @book_name, genre = @genre, author_name = @author_name, " +
                        "publisher_name = @publisher_name, publish_date = @publish_date, language = @language, " +
                        "edition = @edition, book_cost = @book_cost, no_of_pages = @no_of_pages, " +
                        "book_description = @book_description, actual_stock = @actual_stock, current_stock = @current_stock, " +
                        "book_img_link = @book_img_link WHERE book_id = @book_id", con);

                    cmd.Parameters.AddWithValue("@book_name", TextBoxBookName.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@author_name", DropDownListAuthor.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownListPublisher.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date", TextBoxPublishDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", DropDownListLanguage.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", TextBoxEdition.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", TextBoxCostPerUnit.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBoxPages.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", TextBoxDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                    cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);
                    cmd.Parameters.AddWithValue("@book_id", TextBoxBookID.Text.Trim());

                    cmd.ExecuteNonQuery();
                }

                ClearFormFields();
                GridViewInventory.DataBind();
                Response.Write("<script>alert('Book Status Updated');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void addNewBook()
        {
            try
            {
                string genres = "";
                foreach (int i in listbox1.GetSelectedIndices())
                {
                    genres = genres + listbox1.Items[i] + ",";
                }
                genres = genres.TrimEnd(',');

                string filepath = "~/book_pictures/books1.jpg";
                if (FileUpload1.HasFile)
                {
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.SaveAs(Server.MapPath("book_pictures/" + filename));
                    filepath = "~/book_pictures/" + filename;
                }

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl " +
                        "(book_id, book_name, genre, author_name, publisher_name, publish_date, language, edition, " +
                        "book_cost, no_of_pages, book_description, actual_stock, current_stock, book_img_link) " +
                        "VALUES(@book_id, @book_name, @genre, @author_name, @publisher_name, @publish_date, @language, " +
                        "@edition, @book_cost, @no_of_pages, @book_description, @actual_stock, @current_stock, @book_img_link)", con);

                    cmd.Parameters.AddWithValue("@book_id", TextBoxBookID.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_name", TextBoxBookName.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@author_name", DropDownListAuthor.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownListPublisher.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date", TextBoxPublishDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", DropDownListLanguage.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", TextBoxEdition.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", TextBoxCostPerUnit.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBoxPages.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", TextBoxDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", TextBoxActualStock.Text.Trim());
                    cmd.Parameters.AddWithValue("@current_stock", TextBoxActualStock.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);

                    cmd.ExecuteNonQuery();
                }

                Response.Write("<script>alert('Book Added Successfully');</script>");
                ClearFormFields();
                GridViewInventory.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void fillAuthorPublisherValues()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT author_name FROM author_master_tbl;", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DropDownListAuthor.DataSource = dt;
                    DropDownListAuthor.DataValueField = "author_name";
                    DropDownListAuthor.DataBind();

                    cmd = new SqlCommand("SELECT publisher_name from publisher_master_tbl", con);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    DropDownListPublisher.DataSource = dt;
                    DropDownListPublisher.DataValueField = "publisher_name";
                    DropDownListPublisher.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void ClearFormFields()
        {
            TextBoxBookID.Text = "";
            TextBoxBookName.Text = "";
            TextBoxPublishDate.Text = "";
            TextBoxEdition.Text = "";
            TextBoxCostPerUnit.Text = "";
            TextBoxPages.Text = "";
            TextBoxActualStock.Text = "";
            TextBoxCurrentStock.Text = "";
            TextBoxBookIssued.Text = "";
            listbox1.ClearSelection();
            DropDownListAuthor.ClearSelection();
            DropDownListPublisher.ClearSelection();
            DropDownListLanguage.ClearSelection();
            TextBoxDescription.Text = "";
        }
    }
}
