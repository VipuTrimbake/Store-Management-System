<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="User_Dashboard.aspx.cs" Inherits="NewUIProject.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <link href="line-awesome-1.3.0/1.3.0/css/line-awesome.css" rel="stylesheet" />
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script>
        var object = { status: false, ele: null };

        function OrderPlaced() {
            if (object.status) { return true; };

            swal({
                title: "Order Placed!",
                text: "Order has been Placed Successfully!",
                icon: "success",
                button: "Ok!",
            });
            return false;
        };
        var object = { status: false, ele: null };

        function ValidQty() {
            if (object.status) { return true; };

            swal({
                title: "Invalid Quantity!",
                text: "Please Enter a Valid Quantity!",
                icon: "error",
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
                    <i class="fa fa-bars"></i> Dashboard
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
             <asp:DataList ID="dlProducts" runat="server" RepeatColumns="4" Width="100%" OnItemCommand="dlProducts_ItemCommand" >
        <ItemTemplate>
            <div style="border:1.2px solid; border-color:antiquewhite; padding:15px; margin:20px 0 0 10px;width:180px;">
                  <hr />

                <span>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("ProductImg") %>' height="100" Width="100"></asp:Image>
                   
                </span>
                  <hr />
                <br />
                <span>
                    <asp:Label ID="Productname" runat="server" Text='<%#Eval("Productname") %>' Height="50" Width="150" Font-Italic="False" Font-Bold="True" Font-Size="25px"></asp:Label> 
                </span>
                <br/>
                <br />
                
                <hr />
                     <asp:Label ID="lblQtyStatus" runat="server" style="font-size:20px;font-weight:bold;" Text='<%#Eval("QtyStatus") %>'></asp:Label>
                <br />
                <span style="font-weight:bold;font-style:italic;">
                    Prize :-
                    <asp:Label ID="mPrize" runat="server" Text='<%#Eval("mPrize") %>' Font-Strikeout="True"></asp:Label> <strike></strike>
                </span>
                <span style="font-weight:bold;font-style:italic;">
                   
                    <asp:Label ID="Prize" runat="server" Text='<%#Eval("Prize") %>'></asp:Label> 
                </span>
                <br />
                <span>
                   Add Qty
                    <asp:DropDownList runat="server" ID="ddlQty" style="border-radius:10px;width:40px;text-align:center;">
                       <asp:ListItem>1</asp:ListItem>                       
                       <asp:ListItem>2</asp:ListItem>
                       <asp:ListItem>3</asp:ListItem>
                       <asp:ListItem>4</asp:ListItem>
                       <asp:ListItem>5</asp:ListItem>
                       <asp:ListItem>6</asp:ListItem>
                       <asp:ListItem>7</asp:ListItem>           
                       <asp:ListItem>8</asp:ListItem>
                       <asp:ListItem>9</asp:ListItem>
                       <asp:ListItem>10</asp:ListItem>
                    </asp:DropDownList>
                </span>
                <hr />
                <br/>
                  <asp:Button ID="btnBuyNow" runat="server" Text="Buy Now"  CommandName="Insert" style="border:1px solid red;margin-left:10px;border-radius:20px;"  BackColor="#FF9933" ForeColor="#000066" Height="36px" Width="140px"  Font-Bold="True"  />
            </div>
            </ItemTemplate>
    </asp:DataList>
   
            </div>
      </section>
   
</asp:Content>
