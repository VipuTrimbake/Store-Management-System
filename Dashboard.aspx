<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="NewUIProject.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <link type="text/css" rel="stylesheet" href="css/style.css" />
    <link type="text/css" rel="stylesheet" href="css/font-awesome.min.css" />
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
                <img src="images/user.png" class="img-responsive" />
                <h3>MyProject</h3>
                <p>Admin</p>
            </div>
            <div class="clear"></div>
        </header>
       <div class="clear"></div>
        <div class="main-content-info container">
            <div class="card">
                <h2 class="cus-num cus-h"><asp:Label ID="lblCustomer" runat="server" Text="Label"></asp:Label></h2>
                <p>Customers Joined</p>
            </div>
            <div class="card">
                <h2 class="cus-num cus-pro"><asp:Label ID="lblProducts" runat="server" Text="Label"></asp:Label></h2>
                <p>Products Varieties</p>
            </div>
            <div class="card">
                <h2 class="cus-num cus-ord"><asp:Label ID="lblOrders" runat="server" Text="Label"></asp:Label></h2>
                <p>Orders Completed</p>
            </div>
            <div class="card">
                <h2 class="cus-num cus-inc"><asp:Label ID="lblIncome" runat="server" Text="Label"></asp:Label></h2>
                <p>Income</p>
            </div>
            <div class="clear"></div>
        </div>
      </section>
</asp:Content>
