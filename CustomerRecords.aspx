
<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="CustomerRecords.aspx.cs" Inherits="NewUIProject.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <Section id="main-content">
         <header>
            <div class="header-left">
                <h2 class="toggle-btn">
                    <i class="fa fa-bars"></i> Records
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
        <asp:GridView ID="grdRecords" class="grd" runat="server" BorderColor="White" cellpadding="3"  AutoGenerateColumns="False" OnRowDeleting="grdRecords_RowDeleting" style="text-align:right; align-content:center; align-items:center; ">

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
                     <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
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
               
                <asp:ButtonField HeaderText="More info" Text="More Info" ControlStyle-Font-Underline="true" CommandName="Delete">
<ControlStyle Font-Underline="True"></ControlStyle>

                      <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                 </asp:ButtonField>
            </Columns>

        </asp:GridView>
       </div>
    </section>
</asp:Content>
