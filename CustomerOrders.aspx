<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="CustomerOrders.aspx.cs" Inherits="NewUIProject.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script>
        var object = { status: false, ele: null };

        function OrderDone() {
            if (object.status) { return true; };

            swal({
                title: "Order Done!",
                text: "Order Successfully Done!",
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
                    <i class="fa fa-bars"></i> Orders
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
      
           <div style="border:1px solid; padding-left:30px;" >
        <h2>Customer Orders</h2>
     </div>
    <div class="view">
        <asp:GridView ID="GrdOrders" class="grd" runat="server" BorderColor="White" cellpadding="3"  AutoGenerateColumns="False" OnRowDeleting="GrdOrders_RowDeleting">
          
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="Fname" HeaderText="Fname" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Lname" HeaderText="Lname" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Prize" HeaderText="Unit Prize" >    
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="Qty" HeaderText="Qty">
                         <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    
                    <asp:ImageField DataImageUrlField="ProductImg" HeaderText="ProductImg">
                        <ControlStyle Height="50px" Width="50px" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:ImageField>
                    <asp:BoundField DataField="Address" HeaderText="Address">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
               
                    <asp:BoundField DataField="Email" HeaderText="Email" >
                     <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
               
                    <asp:BoundField DataField="Phone" HeaderText="Phone no" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
              
                    <asp:BoundField DataField="Date" HeaderText="Date" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
               
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ControlStyle-CssClass="GrdCButtons" ControlStyle-BackColor="LightGreen" HeaderText="Done" AccessibleHeaderText="Done" DeleteText="Done" >
<ControlStyle BackColor="LightGreen" CssClass="GrdCButtons"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
            </Columns>
        </asp:GridView>
    </div>
    </section>
</asp:Content>
