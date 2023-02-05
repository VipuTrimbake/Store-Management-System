<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="NewUIProject.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
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
                    <i class="fa fa-bars"></i> Sales
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
      
            <div class="view"">
        <asp:GridView ID="GrdSales" class="grd" runat="server" BorderColor="White" cellpadding="3" AutoGenerateColumns="False" DataKeyNames="Bill" OnRowCancelingEdit="GrdSales_RowCancelingEdit" OnRowDeleting="GrdSales_RowDeleting" OnRowUpdating="GrdSales_RowUpdating" OnRowEditing="GrdSales_RowEditing">
          
                <Columns>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkselect" runat="server"/>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="Bill" HeaderText="Bill No" ReadOnly="True" >
                    
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    
                    </asp:BoundField>
                    <asp:BoundField DataField="Product" HeaderText="Product Name" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Qty" HeaderText="Quantity" >
                    </asp:BoundField>
                    <asp:BoundField DataField="Unit" HeaderText="Unit Price" >
                    </asp:BoundField>
                    <asp:BoundField DataField="Total" HeaderText="Total Price" >
                    </asp:BoundField>
                    <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="True" >
               
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
               
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
