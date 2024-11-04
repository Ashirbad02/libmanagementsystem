using System;
using System.Configuration;
using System.Web.UI;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace Libmanagementsystem
{
    public partial class adminmembermanagement : Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewMembers.DataBind();
        }

        protected void GoButton_Click(object sender, EventArgs e)
        {
            getMemberByID();
        }

        protected void ActiveButton_Click(object sender, EventArgs e)
        {
            // Your logic for LinkButton1 //statusok
            updateMemberStatusByID("Active");
        }

        protected void PendingButton_Click(object sender, EventArgs e)
        {
            // Your logic for LinkButton2//satuspending
            updateMemberStatusByID("Pending");
        }
        protected void DeactiveButton_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("DeActive");
        }
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            // Your deletion logic here delete
            deleteMemberByID();
        }

        // member id fetching fuinction 
        void getMemberByID()
        {
            if (TextBoxMemberID.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('Member ID cannot be blank');</script>");
            }
            
             
            else if(checkIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("select * from member_master_tbl where member_id='" + TextBoxMemberID.Text.Trim() + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            TextBoxFullName.Text = dr.GetValue(0).ToString();
                            TextBoxAccountStatus.Text = dr.GetValue(10).ToString();
                            TextBoxDOB.Text = dr.GetValue(1).ToString();
                            TextBoxContactNo.Text = dr.GetValue(2).ToString();
                            TextBoxEmailID.Text = dr.GetValue(3).ToString();
                            TextBoxState.Text = dr.GetValue(4).ToString();
                            TextBoxCity.Text = dr.GetValue(5).ToString();
                            TextBoxPinCode.Text = dr.GetValue(6).ToString();
                            TextBoxPostalAddress.Text = dr.GetValue(7).ToString();
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Member donot exist!');</script>");
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Member donot exist!');</script>");
            }



        }
        void updateMemberStatusByID(string status)
        {
            if (checkIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='" + status + "' WHERE member_id='" + TextBoxMemberID.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("<script>alert('Member Status Updated');</script>");
                    clearform();
                    GridViewMembers.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {

                Response.Write("<script>alert('Member ID Invalid');</script>");
            }
            
        }

        bool checkIfMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT 1 from member_master_tbl where member_id='" + TextBoxMemberID.Text.Trim() + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        void deleteMemberByID()
        {
            if (checkIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from member_master_tbl WHERE member_id='" + TextBoxMemberID.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Member Deleted Successfully'); </script>");
                    clearform();
                    GridViewMembers.DataBind();
                }
                catch (Exception ex)

                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Member ID Invaid'); </script>");
            }
           
        }
        void clearform()
        {
            TextBoxFullName.Text = "";
            TextBoxAccountStatus.Text = "";
            TextBoxDOB.Text = "";
            TextBoxContactNo.Text = "";
            TextBoxEmailID.Text = "";
            TextBoxState.Text = "";
            TextBoxCity.Text = "";
            TextBoxPinCode.Text = "";
            TextBoxPostalAddress.Text = "";
        }





    }
}
