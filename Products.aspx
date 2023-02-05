<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="NewUIProject.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
        .auto-style1 {
            height: 85px;
        }
    </style>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script>
        var object = { status: false, ele: null };

        function AddItem() {
            if (object.status) { return true; };

            swal({
                title: "Product Added!",
                text: "Product Successfully Added!",
                icon: "success",
                button: "Ok!",
            });
            return false;
        };
        var object = { status: false, ele: null };
        function FieldsRequired() {
            if (object.status) { return true; };

            swal({
                title: "Sorry!",
                text: "All fields are Required!",
                icon: "error",
                button: "Ok!",
            });
            return false;
        };
        var object = { status: false, ele: null };
        function confirmDelete(ev) {
            if (object.status) { return true; };

            swal({
                title: "Are you sure!",
                text: "Do you really want to Delete!",
                icon: "warning",
                buttons: ["No", "Yes!"],
            }).then((willDelete) => {
                if (willDelete) {
                    object.status = true;
                    object.ele = ev;
                    object.ele.click();
                }
            });
            return false;
        };
        var object = { status: false, ele: null };
        function ItemUpdate() {
            if (object.status) { return true; };

            swal({
                title: "Item Updated!",
                text: "Item Successfully Updated!",
                icon: "success",
                button: "Ok!",
            });
            return false;
        };
        var object = { status: false, ele: null };
        function ItemDelete() {
            if (object.status) { return true; };

            swal({
                title: "Item Deleted!",
                text: "Item Successfully Deleted!",
                icon: "success",
                button: "Ok!",
            });
            return false;
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <Section id="main-content">
          <header>
            <div class="header-left">
                <h2 class="toggle-btn">
                    <i class="fa fa-bars"></i> Products
                </h2>
            </div>
            <div class="header-left header-serach">
            </div>
            <div class="header-left header-profile">
                <img src="images/user.png" class="img-responsive" />
                <h3>MyProject</h3>
                <p>Admin</p>
            </div>
            <div class="clear"></div>
        </header>
      
          <div class="view">
               <table  cellpadding="2" cellspacing="10" width="100%" >
           <tr>
               <td class="auto-style1">
                    Category
                   <br />
                   <asp:DropDownList ID="ddlCategory" class="BorderBottomStyle" runat="server">
                       <asp:ListItem>Select</asp:ListItem>
                       <asp:ListItem>Camara</asp:ListItem>
                       <asp:ListItem>Laptop</asp:ListItem>
                       <asp:ListItem>Speakers</asp:ListItem>
                       <asp:ListItem>Mobile</asp:ListItem>
                       <asp:ListItem>Headphone</asp:ListItem>
                       <asp:ListItem>TV</asp:ListItem>
                       <asp:ListItem>Others</asp:ListItem>
                    </asp:DropDownList>
               </td>
               <td class="auto-style1">
                    Product Name
                    <br />
                   <asp:DropDownList ID="ddlProducts" class="BorderBottomStyle" runat="server" style="width:100px;" OnTextChanged="ddlProducts_TextChanged" AutoPostBack="True">
                   </asp:DropDownList>
                </td>
               <td class="auto-style1">
                    Qty
                    <br />
                   <asp:DropDownList ID="ddlQty" class="BorderBottomStyle" runat="server" style="width:60px;">
                   </asp:DropDownList>
                </td>
               <td class="auto-style1"> 
                    Prize
                    <br />
                   <asp:TextBox ID="txtPrize" class="BorderBottomStyle" runat="server" Width="156px"></asp:TextBox>
                </td>
                <td class="auto-style1">
                    Image
                   <br />
                   <asp:FileUpload ID="FileUpload" class="BorderBottomStyle" runat="server" Width="177px" />
               </td>
               <td>
               Date
                   <br />
                   <asp:TextBox ID="txtDate" class="BorderBottomStyle" style="text-align:center;border:none;" runat="server" Enabled="False" Width="138px"></asp:TextBox>
               </td>
       </table>
     <table border="0" cellpadding="5" cellspacing="10"  style="border-color: #FFFFFF" align="center">
           <tr>
               <td>
                   <asp:Button ID="btnAddProduct" CssClass="btnPurchase" runat="server" Text="Add Product" Height="36px" Width="108px" style="background-color:lightblue;" BorderColor="#CCFFFF" ForeColor="white" OnClick="btnAddProduct_Click"/>
               </td>
               <td>
                   <asp:Button ID="btnDeleteProduct" class="btnPurchase" runat="server" Text="Delete Products" Height="36px" Width="108px" style="background-color:lightblue;" BorderColor="#CCFFFF" ForeColor="white" OnClick="btnDeleteProduct_Click" OnClientClick="return confirmDelete(this);" />
               </td>
            </tr>
        </table>
              </div>
              <div class="view">
    <asp:GridView ID="GrdProducts" class="grd" BorderColor="White" cellpadding="3" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GrdProducts_RowCancelingEdit" OnRowDeleting="GrdProducts_RowDeleting" OnRowEditing="GrdProducts_RowEditing" OnRowUpdating="GrdProducts_RowUpdating">
        <Columns>
             <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkselect" runat="server"/>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>

            <asp:BoundField DataField="Pid" HeaderText="Sr no" ReadOnly="True" >
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Productname" HeaderText="Product Name" ReadOnly="True" >
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
             <asp:BoundField DataField="Qty" HeaderText="Qty" ReadOnly="True" />
            <asp:BoundField DataField="Prize" HeaderText="Prize" >
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="mPrize" HeaderText="mPrize" >
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Category" HeaderText="Category" >
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:ImageField HeaderText="Product Image" DataImageUrlField="ProductImg" ReadOnly="True">
                <ControlStyle Height="50px" Width="50px" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:ImageField>

             <asp:BoundField HeaderText="Date" ReadOnly="True" DataField="Date" />

            <asp:CommandField ButtonType="Button" HeaderText="Edit" ControlStyle-CssClass="GrdCButtons" ControlStyle-BackColor="LightGreen" ShowEditButton="True" >
<ControlStyle BackColor="LightGreen" CssClass="GrdCButtons"></ControlStyle>

            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:CommandField>

            <asp:CommandField ButtonType="Button" HeaderText="Delete" ControlStyle-CssClass="GrdCButtons" ControlStyle-BackColor="crimson" ShowDeleteButton="True" >
<ControlStyle BackColor="Crimson" CssClass="GrdCButtons"></ControlStyle>

            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:CommandField>
        </Columns>
    </asp:GridView>
          </div>
    </section>
</asp:Content>
