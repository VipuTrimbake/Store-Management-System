<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="NewUIProject.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <Section id="main-content">
         <header>
            <div class="header-left">
                <h2 class="toggle-btn">
                    <i class="fa fa-bars"></i> Inventory
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
             <asp:GridView ID="GrdInventory" class="grd" BorderColor="White" cellpadding="3"  runat="server" AutoGenerateColumns="False" GridLines="Horizontal" HorizontalAlign="Center">

                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" >
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                         <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                      </asp:BoundField>
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:ImageField DataImageUrlField="ProductImg" HeaderText="Img">
                        <ControlStyle Height="50px" Width="50px" />
                         <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:ImageField>
                    <asp:BoundField DataField="Qty" HeaderText="Qty">
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                </Columns>

                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />

    </asp:GridView>


            
        </div>
         </section>
</asp:Content>
