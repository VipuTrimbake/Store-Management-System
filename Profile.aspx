<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="NewUIProject.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
          <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script>
        var object = { status: false, ele: null };
        function ItemUpdate() {
            if (object.status) { return true; };

            swal({
                title: "Profile Updated!",
                text: "Profile Successfully Updated!",
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
                    <i class="fa fa-bars"></i> Profile
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
     
    <div class="view" style="width:600px;padding:50px;font-size:larger;">
          Id :&nbsp;
        <asp:Label ID="lblId" class="BorderBottomStyle" runat="server"></asp:Label>
        <br />
        <br />
        First Name : <asp:TextBox ID="pFname" class="BorderBottomStyle" runat="server"></asp:TextBox>
        <br />
        <br />
        Last Name : <asp:TextBox ID="pLname" class="BorderBottomStyle" runat="server"></asp:TextBox>
        <br />
        <br />
        Email&nbsp;&nbsp; : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="pEmail" class="BorderBottomStyle" runat="server"></asp:TextBox>
        <br />
        <br />
        Phone No. : <asp:TextBox ID="pPhone" class="BorderBottomStyle" runat="server"></asp:TextBox>
        <br />
        <br />
        Change Password : <asp:TextBox ID="pNewPwd" class="BorderBottomStyle" runat="server"></asp:TextBox>
   
        <br />
        <br />
        <br />
   
        <asp:Button ID="btnUpdate" CssClass="btnPurchase" runat="server" Text="Update" OnClick="btnUpdate_Click" />
     </div>
  </section>
</asp:Content>
