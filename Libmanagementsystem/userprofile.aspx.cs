using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Libmanagementsystem
{
    public partial class userprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"] == null || Session["username"].ToString() == "")
                {
                    Response.Write("<script>alert('Session Expired. Please Login Again.');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        getUserPersonalDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Session Expired. Please Login Again.');</script>");
                Response.Redirect("userlogin.aspx");
            }
        }

        void updateUserpersonalDetails()
        {
            string password = TextBox10.Text.Trim() == "" ? TextBox9.Text.Trim() : TextBox10.Text.Trim();

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET full_name=@full_name, dob=@dob, contact_no=@contact_no, email=@email, state=@state, city=@city, pincode=@pincode, full_address=@full_address, password=@password, account_status=@account_status WHERE member_id='" + Session["username"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@account_status", "pending");

                int result = cmd.ExecuteNonQuery();
                con.Close();

                if (result > 0)
                {
                    Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                    getUserPersonalDetails();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Entry!');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void getUserPersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id=@member_id", con);
                cmd.Parameters.AddWithValue("@member_id", Session["username"].ToString().Trim());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    TextBox1.Text = dt.Rows[0]["full_name"].ToString();
                    TextBox2.Text = dt.Rows[0]["dob"].ToString();
                    TextBox3.Text = dt.Rows[0]["contact_no"].ToString();
                    TextBox4.Text = dt.Rows[0]["email"].ToString();
                    DropDownList1.SelectedValue = dt.Rows[0]["state"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["city"].ToString();
                    TextBox7.Text = dt.Rows[0]["pincode"].ToString();
                    TextBox5.Text = dt.Rows[0]["full_address"].ToString();
                    TextBox8.Text = dt.Rows[0]["member_id"].ToString();
                    TextBox9.Text = dt.Rows[0]["password"].ToString();

                    Label1.Text = dt.Rows[0]["account_status"].ToString().Trim();
                    string accountStatus = dt.Rows[0]["account_status"].ToString().Trim();

                    if (accountStatus == "Active")
                    {
                        Label1.Attributes.Add("class", "badge badge-pill badge-success");
                    }
                    else if (accountStatus == "Pending")
                    {
                        Label1.Attributes.Add("class", "badge badge-pill badge-warning");
                    }
                    else if (accountStatus == "Deactivate")
                    {
                        Label1.Attributes.Add("class", "badge badge-pill badge-danger");
                    }
                    else
                    {
                        Label1.Attributes.Add("class", "badge badge-pill badge-secondary");
                    }
                }
                else
                {
                    Response.Write("<script>alert('No user data found.');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void GridViewbookdata_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"].ToString() == "")
            {
                Response.Write("<script>alert('Session Expired. Please Login Again.');</script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                updateUserpersonalDetails();
            }
        }
    }
}
