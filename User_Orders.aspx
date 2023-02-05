<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="User_Orders.aspx.cs" Inherits="NewUIProject.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script>
        var object = { status: false, ele: null };

        function OrderCancel() {
            if (object.status) { return true; };

            swal({
                title: "Order Cancel!",
                text: "Order has been Cancelld Successfully!",
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
                    <asp:LinkButton ID="lnkProfile" runat="server" OnClick="lnkProfile_Click">
                <img src="images/user.png" class="img-responsive" />
                <h3>MyProject</h3>
                <p>Welcome <asp:Label ID="lblHeaderText" runat="server"></asp:Label> !</p>
                </asp:LinkButton>
            </div>
            <div class="clear"></div>
        </header>
       
       <div class="clear"></div>
          <div class="view">
    <asp:DataList ID="dlOrders" runat="server"  RepeatColumns="2" Width="1020px" RepeatDirection="Horizontal" OnItemCommand="dlOrders_ItemCommand">
        <ItemTemplate>
          <div style="border:1.2px solid; border-color:navy; border-radius:30px; padding:0px 0 0 20px;margin:20px 0 0 10px; height:150px; width:400px;">
            <div style="float:left;padding:10px;">
                
                <span style="font-weight:bold;font-style:italic;">
                    ₹ <%#Eval("Date") %>
                </span>
                <br />
                <asp:Image ID="Image1" style="border:2px solid cyan;border-radius:15px; margin-top:5px;" runat="server" ImageUrl='<%#Eval("ProductImg") %>' height="80" Width="80"></asp:Image>
                <br /> 
                <b>Id : </b><asp:Label ID="Id" runat="server" style="font-weight:bold;font-style:italic;font-size:17px;" Text='<%#Eval("Id") %>'></asp:Label>

            </div>
            <div style="float:left;margin-left:30px;">
                <br />
                <span style="font-size:20px;font-weight:bold;margin:0 0 10px 0px;"> <asp:Label ID="Pname" runat="server" Text='<%#Eval("Productname") %>'></asp:Label> </span><br />
                <hr />
                <br />
                <span style="font-weight:bold;font-style:italic;margin-top:5px;font-size:20px;">
                    Qty :<asp:Label ID="Qty" runat="server" Text='<%#Eval("Qty") %>'></asp:Label>  / ₹ <%#Eval("Prize") %>
                </span>
                <hr />
                <br />
                <asp:Button ID="btnCancelOrder" style="padding:7px;border-radius:10px;color:cyan;background-color:cornflowerblue;font-weight:bold;" CommandName="Delete" runat="server" Text="Cancel Order" />
                
               </div>
         </div>
            </ItemTemplate>
    </asp:DataList>
              
          </div>
  </section>
</asp:Content>
