<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmembermanagement.aspx.cs" Inherits="Libmanagementsystem.adminmembermanagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" rel="stylesheet" />
    <style>
        .btn-custom {
            display: inline-flex;
            align-items: center;
            justify-content: center;
            padding: 5px 10px;
            border: none;
            color: white;
            cursor: pointer;
            margin-left: 5px; /* Spacing between buttons */
            border-radius: 5px; /* Rounded corners */
        }

        .btn-primary {
            background-color: green;
        }

        .btn-pause {
            background-color: yellow;
            color: black; /* Change text color for visibility */
        }

        .btn-delete {
            background-color: red;
            color: white;
        }

        .table-wider {
            width: 100%; /* Set to 100% or specify a width */
            table-layout: auto; /* Adjust the table layout */
        }

        .input-account-status {
            width: calc(100% - 110px); /* Increase width of Account Status input */
        }

        .card {
            background-color: white;
            border-radius: 13px;
            margin-top: 2%;
            margin-bottom: 10%;
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
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Member Details</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/generaluser.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBoxMemberID" runat="server" placeholder="Member ID"></asp:TextBox>
                                        <asp:Button CssClass="btn btn-primary" ID="GoButton" runat="server" Text="Go" OnClick="GoButton_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox ReadOnly="true" CssClass="form-control" ID="TextBoxFullName" runat="server" placeholder="Full Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <label>Account Status</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ReadOnly="true" CssClass="form-control input-account-status" ID="TextBoxAccountStatus" runat="server" placeholder="Account Status"></asp:TextBox>
                                        <asp:LinkButton ID="ActiveButton" runat="server" OnClick="ActiveButton_Click" class="btn btn-success mr-1">
                                            <i class="fas fa-check-circle"></i>
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="PendingButton" runat="server" class="btn btn-warning mr-1" OnClick="PendingButton_Click">
                                            <i class="far fa-pause-circle"></i>
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="DeactiveButton" runat="server" class="btn btn-danger mr-1" OnClick="DeactiveButton_Click">
                                            <i class="fas fa-times-circle"></i>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <label>DOB</label>
                                <div class="form-group">
                                    <asp:TextBox ReadOnly="true" CssClass="form-control" ID="TextBoxDOB" runat="server" placeholder="DD-MM-YYYY"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Contact No</label>
                                <div class="form-group">
                                    <asp:TextBox ReadOnly="true" CssClass="form-control" ID="TextBoxContactNo" runat="server" placeholder="Contact No"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox ReadOnly="true" CssClass="form-control" ID="TextBoxEmailID" runat="server" placeholder="Email ID"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:TextBox ReadOnly="true" CssClass="form-control" ID="TextBoxState" runat="server" placeholder="State"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox ReadOnly="true" CssClass="form-control" ID="TextBoxCity" runat="server" placeholder="City"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Pin Code</label>
                                <div class="form-group">
                                    <asp:TextBox ReadOnly="true" CssClass="form-control" ID="TextBoxPinCode" runat="server" placeholder="Pin Code"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Full Postal Address</label>
                                <div class="form-group">
                                    <asp:TextBox ReadOnly="true" CssClass="form-control" ID="TextBoxPostalAddress" runat="server" placeholder="Full Postal Address" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:Button CssClass="btn-custom btn-delete" ID="ButtonDelete" runat="server" Text="Delete" OnClick="ButtonDelete_Click"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>

                <br />
                <a href="homepage.aspx"><< Back to Home</a><br />
                <br />
            </div>

            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Member List</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString2 %>" ProviderName="<%$ ConnectionStrings:elibraryDBConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                                <asp:GridView CssClass="table table-striped table-bordered table-wider" ID="GridViewMembers" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="member_id" >
                                    <Columns>
                                        <asp:BoundField DataField="full_name" HeaderText="full_name" SortExpression="full_name"></asp:BoundField>
                                        <asp:BoundField DataField="dob" HeaderText="dob" SortExpression="dob"></asp:BoundField>
                                        <asp:BoundField DataField="contact_no" HeaderText="contact_no" SortExpression="contact_no"></asp:BoundField>
                                        <asp:BoundField DataField="email" HeaderText="email" SortExpression="email"></asp:BoundField>
                                        <asp:BoundField DataField="pincode" HeaderText="pincode" SortExpression="pincode"></asp:BoundField>
                                        <asp:BoundField DataField="member_id" HeaderText="member_id" ReadOnly="True" SortExpression="member_id"></asp:BoundField>
                                        <asp:BoundField DataField="account_status" HeaderText="account_status" SortExpression="account_status"></asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
