<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookInventory.aspx.cs" Inherits="Libmanagementsystem.adminbookInventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
     .card{
         background-color:white;
         border-radius:13px;
         margin-top:2%;
         margin-bottom:10%;

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
                                    <h4>Book Details</h4>
                                </center>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <center>
                                    <img id="imgview" height="150px" width="100px" src="book_pictures/books1.jpg" />

                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>



                        <div class="row">
                            <div class="col">
                                <asp:FileUpload onChange="readURL(this)" class="form-control" ID="FileUpload1" runat="server" />
                            </div>
                        </div>

                        <!-- Book ID and Member ID in the same row -->
                        <div class="row">
                            <div class="col-md-3">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBoxBookID" runat="server" placeholder="Book ID"></asp:TextBox>
                                        <asp:Button CssClass="btn btn-primary" ID="ButtonGo" runat="server" Text="Go" OnClick="ButtonGo_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-9">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxBookName" runat="server" placeholder="Bookname"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <!-- Language, Author Name, and Genre in the same row -->
                        <div class="row">
                            <div class="col-md-4">
                                <label>Language</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownListLanguage" runat="server">
                                        <asp:ListItem>English</asp:ListItem>
                                        <asp:ListItem>Hindi</asp:ListItem>
                                        <asp:ListItem>Spanish</asp:ListItem>
                                        <asp:ListItem>Hindi</asp:ListItem>
                                        <asp:ListItem>Bengali</asp:ListItem>
                                        <asp:ListItem>Tamil</asp:ListItem>
                                        <asp:ListItem>Telugu</asp:ListItem>
                                        <asp:ListItem>Urdu</asp:ListItem>
                                        <asp:ListItem>English</asp:ListItem>
                                        <asp:ListItem>French</asp:ListItem>
                                        <asp:ListItem>German</asp:ListItem>
                                        <asp:ListItem>Spanish</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownListAuthor" runat="server">
                                        <asp:ListItem>Select Author</asp:ListItem>
                                        <asp:ListItem>Author 1</asp:ListItem>
                                        <asp:ListItem>Author 2</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Genre</label>
                                <div class="form-group">
                                    <asp:ListBox ID="listbox1" CssClass="form-control" runat="server" SelectionMode="Multiple">
                                        <asp:ListItem Text="Action" Value="Action" />
                                        <asp:ListItem Text="Adventure" Value="Adventure" />
                                        <asp:ListItem Text="Comic Book" Value="ComicBook" />
                                        <asp:ListItem Text="Self Help" Value="SelfHelp" />
                                        <asp:ListItem Text="Fantasy" Value="Fantasy" />
                                        <asp:ListItem Text="Horror" Value="Horror" />
                                        <asp:ListItem Text="Mystery" Value="Mystery" />
                                        <asp:ListItem Text="Romance" Value="Romance" />
                                        <asp:ListItem Text="Science Fiction" Value="ScienceFiction" />
                                        <asp:ListItem Text="Thriller" Value="Thriller" />
                                        <asp:ListItem Text="Historical" Value="Historical" />
                                        <asp:ListItem Text="Biography" Value="Biography" />
                                        <asp:ListItem Text="Cookbook" Value="Cookbook" />
                                        <asp:ListItem Text="Poetry" Value="Poetry" />
                                        <asp:ListItem Text="Drama" Value="Drama" />
                                        <asp:ListItem Text="Young Adult" Value="YoungAdult" />
                                        <asp:ListItem Text="Dystopian" Value="Dystopian" />
                                        <asp:ListItem Text="Chick Lit" Value="ChickLit" />
                                        <asp:ListItem Text="Cyberpunk" Value="Cyberpunk" />
                                        <asp:ListItem Text="Historical Fiction" Value="HistoricalFiction" />
                                        <asp:ListItem Text="LitRPG" Value="LitRPG" />
                                        <asp:ListItem Text="Sports" Value="Sports" />
                                        <asp:ListItem Text="Urban Fantasy" Value="UrbanFantasy" />
                                        <asp:ListItem Text="Crime" Value="Crime" />
                                        <asp:ListItem Text="Western" Value="Western" />
                                        <asp:ListItem Text="Non-Fiction" Value="NonFiction" />
                                        <asp:ListItem Text="Graphic Novel" Value="GraphicNovel" />
                                        <asp:ListItem Text="Self-Improvement" Value="SelfImprovement" />
                                        <asp:ListItem Text="Travel" Value="Travel" />
                                        <asp:ListItem Text="Children's" Value="Childrens" />
                                    </asp:ListBox>
                                </div>
                            </div>
                        </div>

                        <!-- Publisher Name and Publish Date in the same row -->
                        <div class="row">
                            <div class="col-md-4">
                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownListPublisher" runat="server">
                                        <asp:ListItem>Select Publisher</asp:ListItem>
                                        <asp:ListItem>Publisher 1</asp:ListItem>
                                        <asp:ListItem>Publisher 2</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Publish Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxPublishDate" runat="server" placeholder="dd-mm-yyyy"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <!-- Edition, Book Cost Per Unit, and Pages in the same row -->
                        <div class="row">
                            <div class="col-md-4">
                                <label>Edition</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxEdition" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Book Cost(Per Unit)</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxCostPerUnit" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Pages</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxPages" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <!-- Actual Stock, Current Stock, and Book Stock in the same row -->
                        <div class="row">
                            <div class="col-md-4">
                                <label>Actual Stock</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxActualStock" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Current Stock</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxCurrentStock" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Books Issued</label>
                                <div class="form-group">
                                    <asp:TextBox ReadOnly="true" CssClass="form-control" ID="TextBoxBookIssued" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <!-- Book Description in a full-width row -->
                        <div class="row ">
                            <div class="col-md-12">
                                <label>Book Description</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxDescription" runat="server" TextMode="MultiLine" Rows="4" placeholder="Enter Book Description"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <!-- Buttons in a single row -->
                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="ButtonAdd" CssClass="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="ButtonAdd_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="ButtonUpdate" CssClass="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="ButtonUpdate_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="ButtonDelete" CssClass="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="ButtonDelete_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Book Inventory List Grid -->
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Inventory List</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString3 %>" ProviderName="<%$ ConnectionStrings:elibraryDBConnectionString3.ProviderName %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridViewInventory" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="false" DataKeyNames="book_id" OnSelectedIndexChanged="GridViewInventory_SelectedIndexChanged1">
                                    <Columns>
                                        

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="X-Large">

                                                                    </asp:Label>
                                                                    <br />
                                                                    <span>Author</span>
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>'></asp:Label>

                                                                    <span>&nbsp; |</span>Genre : <span>&nbsp;</span>
                                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>

                                                                    <span>&nbsp; |</span>Language : <span>&nbsp;</span>
                                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("language") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <span>Publisher : </span>
                                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>

                                                                    <span>&nbsp; |</span>DOP : <span>&nbsp;</span>
                                                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>

                                                                    <span>&nbsp; |</span>Pages: <span>&nbsp;</span>
                                                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("no_of_pages") %>'></asp:Label>
                                                                    <span>&nbsp; |</span>Edition: <span>&nbsp;</span>
                                                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <span>Cost : </span>
                                                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>

                                                                    <span>&nbsp; |</span>Actual Stock : <span>&nbsp;</span>
                                                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>

                                                                    <span>&nbsp; |</span>Available Stock : <span>&nbsp;</span>
                                                                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>
                                                                    
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <span>Description : </span>
                                                                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Text='<%# Eval("book_description") %>'></asp:Label>
                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-lg-2">
                                                            <asp:Image ID="Image1" class="img-fluid p-2" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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

