<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="User_OrderCompleted.aspx.cs" Inherits="NewUIProject.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <Section id="main-content">
           <header>
            <div class="header-left">
                <h2 class="toggle-btn">
                    <i class="fa fa-bars"></i> Completed Orders
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
        <asp:GridView ID="GrdOrderCompleted" runat="server" AutoGenerateColumns="False" BorderColor="White" cellpadding="3" Width="100%">

            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id">
                     <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
               
                <asp:BoundField DataField="Fname" HeaderText="First Name" >
                     <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
               
                <asp:BoundField DataField="Lname" HeaderText="Last Name" >
                     <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
               
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" >
                     <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
               
                <asp:BoundField DataField="Qty" HeaderText="Qty" />
               
                <asp:BoundField DataField="Prize" HeaderText="Total Amount" >
                     <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
               
                <asp:ImageField DataImageUrlField="ProductImg" HeaderText="Product Image">
                    <ControlStyle Height="50px" Width="50px" />
                     <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                </asp:ImageField>

                <asp:BoundField DataField="Address" HeaderText="Address" >
                     <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
               
                <asp:BoundField DataField="Phone" HeaderText="Phone no." >
                     <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
               
                <asp:BoundField DataField="Email" HeaderText="Email Address" >
                     <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
               
                <asp:BoundField DataField="Date" HeaderText="Date" >
                 <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
          
       </Section>
</asp:Content>
