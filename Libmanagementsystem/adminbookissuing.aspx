<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookissuing.aspx.cs" Inherits="Libmanagementsystem.adminbookissuing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .card{
            background-color:white;
            border-radius:13px;
            margin-top:10%;

        }
        body {
         background-image: url('imgs/background.jpg');
         background-size: cover;
         background-position: center;
         margin: 0;
         padding: 0;
         min-height: 100vh; /* Ensure it covers at least the viewport height */
          /* Stack items vertically */
      }
    </style>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Issuing</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/books1.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <!-- Member ID and Book ID in the same row -->
                        <div class="row">
                            <div class="col-md-6">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Member ID"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Book ID"></asp:TextBox>
                                        <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Member Name and Book Name in the same row -->
                        <div class="row">
                            <div class="col-md-6">
                                <label>Member Name</label>
                                <div class="form-group">
                                    <asp:TextBox ReadOnly="true" CssClass="form-control" ID="TextBox3" runat="server" placeholder="Member Name"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox ReadOnly="true" CssClass="form-control" ID="TextBox4" runat="server" placeholder="Book Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <!-- Start Date and End Date in the same row -->
                        <div class="row">
                            <div class="col-md-6">
                                <label>Start Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="dd-mm-yyyy" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>End Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="dd-mm-yyyy" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <!-- Buttons in a single row -->
                        <div class="row">
                            <div class="col-6">
                                <asp:Button ID="Button3" CssClass="btn btn-lg btn-block btn-primary" runat="server" Text="Issue" OnClick="Button3_Click" />
                            </div>
                            <div class="col-6">
                                <asp:Button ID="Button2" CssClass="btn btn-lg btn-block btn-success" runat="server" Text="Return" OnClick="Button2_Click" />
                            </div>
                        </div>

                    </div>
            </div>

         
        </div>
               <div class="col-md-7">
       <div class="card">
           <div class="card-body">
               <div class="row">
                   <div class="col">
                       <center>
                           <h4>Book Issue Data</h4>
                       </center>
                   </div>
               </div>
               <div class="row">
                   <div class="col">
                       <hr />
                   </div>
               </div>
               <div class="row">
                   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString3 %>" ProviderName="<%$ ConnectionStrings:elibraryDBConnectionString3.ProviderName %>" SelectCommand="SELECT * FROM [book_issue_tbl]"></asp:SqlDataSource>
                   <div class="col">
                       <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server"  DataSourceID="SqlDataSource1" RowDataBound="GridView1_RowDataBound"></asp:GridView>
                   </div>
               </div>
           </div>
       </div>
   </div>
   </div>
     </div>

</asp:Content>
