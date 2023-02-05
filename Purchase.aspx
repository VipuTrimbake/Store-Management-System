<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="NewUIProject.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/style.css" rel="stylesheet" />
   
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script>
        var object = { status: false, ele: null };

        function AddItem() {
            if (object.status) { return true; };

            swal({
                title: "Item Added!",
                text: "Item Successfully Added!",
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
        function ResetFields() {
            if (object.status) { return true; };

            swal({
                title: "Fields Reset!",
                text: "All fields are reset!",
                icon: "success",
                button: "Ok!",
            });
            return false;
        };
        var object = { status: false, ele: null };
        function ItemExist() {
            if (object.status) { return true; };

            swal({
                title: "Item Exist!",
                text: "Item already Exist!",
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
                if (willDelete)
                {
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
                    <i class="fa fa-bars"></i> Purchase
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
        <div class="clear"></div>

        <div class="view">
         <table cellpadding="2" cellspacing="10" width="100%">
           <tr>
               <td>
                    Bill No. 
                    <br />
                    <asp:TextBox ID="txtBillNo" class="BorderBottomStyle" enabled="false" style="text-align:center;border:none;background-color:white;" runat="server"></asp:TextBox>
                </td>
               
               <td>
                    Supplier Name
                    <br />
                   <asp:TextBox ID="txtSupplier" class="BorderBottomStyle" runat="server"></asp:TextBox>
                </td>
               <td class="auto-style6"> 
                    Location 
                    <br />
                   <asp:TextBox ID="txtLocation" class="BorderBottomStyle" runat="server"></asp:TextBox>
                </td>
                <td >
                   Date
                   <br />
                   <asp:TextBox ID="txtDate" class="BorderBottomStyle" style="text-align:center;border:none;background-color:white;" runat="server" Enabled="False"></asp:TextBox>
               </td>
               </tr>
            <tr>
             <td class="auto-style6">
                   Product Name
                   <br />
                   <asp:TextBox ID="txtProduct" class="BorderBottomStyle" runat="server" ViewStateMode="Disabled"></asp:TextBox>
               </td>
                <td class="auto-style5">
                   Qty. 
                    <br />
                   <asp:TextBox ID="txtQty" class="BorderBottomStyle" runat="server" Width="118px" ViewStateMode="Disabled"></asp:TextBox>
                </td> 
                <td class="auto-style7"> 
                    Unit Price 
                    <br />
                   <asp:TextBox ID="txtUnit" class="BorderBottomStyle" runat="server" Width="124px" OnTextChanged="txtUnit_TextChanged" ViewStateMode="Disabled" AutoPostBack="True"></asp:TextBox>
                </td>
                <td class="auto-style8">
                   Total Amount 
                    <br />
                   <asp:TextBox ID="txtTotal" class="BorderBottomStyle" runat="server" Width="130px" ViewStateMode="Disabled"></asp:TextBox>
                </td>
            </tr>
       </table>
        <table border="0" cellpadding="5" cellspacing="10"  style="border-color: #FFFFFF" align="center">
           <tr>
               <td class="auto-style9">
                   <asp:Button ID="btnAddItem" CssClass="btnPurchase" runat="server" Text="Add Item" OnClick="btnAddItem_Click"  style="margin-left:200px;" BorderColor="#CCFFFF"/>
               </td>
               
               <td>
                   
                   <asp:Button ID="btnReset" CssClass="btnPurchase" runat="server" Text="Reset" OnClick="btnReset_Click" Height="36px" Width="108px" BackColor="lightblue" BorderColor="#CCFFFF" />
               </td>
                <td>
                   <asp:Button ID="btnDelete" CssClass="btnPurchase" runat="server" Text="Delete Items" Height="36px" Width="108px" BackColor="lightblue" BorderColor="#CCFFFF" OnClick="btnDelete_Click" OnClientClick="return confirmDelete(this);" />
               </td>
            </tr>
        </table>
    </div>
    <div class="view" style="margin-top:50px;">
        <asp:GridView ID="GrdPurchase" class="grd" runat="server" BorderColor="White" cellpadding="3" OnRowCancelingEdit="GrdPurchase_RowCancelingEdit" OnRowDeleting="GrdPurchase_RowDeleting" OnRowEditing="GrdPurchase_RowEditing" OnRowUpdating="GrdPurchase_RowUpdating" AutoGenerateColumns="False" DataKeyNames="Bill">
          
                <Columns>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkselect" runat="server"/>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="Bill" HeaderText="Bill No" ReadOnly="True" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Product" HeaderText="Product Name" ReadOnly="True" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Qty" HeaderText="Quantity" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Unit" HeaderText="Unit Price" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Total" HeaderText="Total Price" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Supplier" HeaderText="Supplier Name" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Location" HeaderText="Location" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="True" >
               
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
               
                <asp:CommandField ShowEditButton="True" ButtonType="Button" ControlStyle-CssClass="GrdCButtons" ControlStyle-BackColor="LightGreen" HeaderText="Edit"  >
<ControlStyle BackColor="LightGreen" CssClass="GrdCButtons"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ControlStyle-CssClass="GrdCButtons" ControlStyle-BackColor="crimson" HeaderText="Delete" >
<ControlStyle BackColor="Crimson" CssClass="GrdCButtons"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
            </Columns>

        </asp:GridView>
      </div>
     </section>
</asp:Content>
