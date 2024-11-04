<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewbooks.aspx.cs" Inherits="Libmanagementsystem.viewbooks" %>
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
      <div class="col-md-12">
      <div class="card">
          <div class="card-body">
              <div class="row">
                  <div class="col">
                      <center>
                          <h4>Book List | Search Your Favourites !</h4>
                      </center>
                  </div>
              </div>

              <div class="row">
                  <div class="col">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString3 %>" ProviderName="<%$ ConnectionStrings:elibraryDBConnectionString3.ProviderName %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                      <asp:GridView CssClass="table table-striped table-bordered" ID="GridViewInventory" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="false" DataKeyNames="book_id" >
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
</asp:Content>
