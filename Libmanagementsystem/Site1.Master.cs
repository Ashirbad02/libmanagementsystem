using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Libmanagementsystem
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Check if Session["role"] is null or an empty string
                if (Session["role"] == null || Session["role"].ToString().Equals(""))
                {
                    // User is not logged in
                    LinkButton1.Visible = true;  // user login link button
                    LinkButton2.Visible = true;  // sign up link button
                    LinkButton3.Visible = false; // logout link button
                    LinkButton7.Visible = false; // hello user link button

                    LinkButton6.Visible = true;  // admin login link button
                    LinkButton11.Visible = false; // author management link button
                    LinkButton12.Visible = false; // publisher management link button
                    LinkButton8.Visible = false; // book inventory link button
                    LinkButton9.Visible = false; // book issuing link button
                    LinkButton10.Visible = false; // member management link button
                }
                else if (Session["role"].ToString().Equals("user"))
                {
                    // User is logged in as a regular user
                    LinkButton1.Visible = false;  // user login link button
                    LinkButton2.Visible = false;  // sign up link button
                    LinkButton3.Visible = true;   // logout link button
                    LinkButton7.Visible = true;   // hello user link button
                    LinkButton7.Text = "Hello " + Session["username"].ToString();

                    LinkButton6.Visible = true;   // admin login link button
                    LinkButton11.Visible = false; // author management link button
                    LinkButton12.Visible = false; // publisher management link button
                    LinkButton8.Visible = false;  // book inventory link button
                    LinkButton9.Visible = false;  // book issuing link button
                }
                else if (Session["role"].ToString().Equals("admin"))
                {
                    // User is logged in as an admin
                    LinkButton1.Visible = false;  // user login link button
                    LinkButton2.Visible = false;  // sign up link button
                    LinkButton3.Visible = true;   // logout link button
                    LinkButton7.Visible = true;   // hello admin link button
                    LinkButton7.Text = "Hello Admin";

                    LinkButton6.Visible = false;  // admin login link button
                    LinkButton11.Visible = true;  // author management link button
                    LinkButton12.Visible = true;  // publisher management link button
                    LinkButton8.Visible = true;   // book inventory link button
                    LinkButton9.Visible = true;
                    LinkButton10.Visible = true;// book issuing link button
                }
            }
            catch (Exception ex)
            {
                // Handle the exception or log it if necessary
                // You can use ex.Message to get the error details
            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookInventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            // Clear session variables on logout
            Session["username"] = null;
            Session["fullname"] = null;
            Session["role"] = null;
            Session["status"] = null;

            // Set visibility after logout
            LinkButton1.Visible = true;  // user login link button
            LinkButton2.Visible = true;  // sign up link button
            LinkButton3.Visible = false; // logout link button
            LinkButton7.Visible = false; // hello user link button
            LinkButton6.Visible = true;  // admin login link button
            LinkButton11.Visible = false; // author management link button
            LinkButton12.Visible = false; // publisher management link button
            LinkButton8.Visible = false;  // book inventory link button
            LinkButton9.Visible = false;  // book issuing link button
            LinkButton10.Visible = false; // member management link button
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }
    }
}
