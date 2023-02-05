<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="NewUIProject.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <link href="StyleSheet1.css" rel="stylesheet" />
    <link href="bootstrap-5.1.3-dist/css/bootstrap.min.css" rel="stylesheet" />
    <style rel="stylesheet">
        body{
            margin:0;
            padding:0;
            background-image: url('Images/01.jpg');
            background-size:cover;
        }
        .loginbox{
            position:absolute;
            top:50%;
            left:50%;
            width:350px;
            transform:translate(-50%,-50%);
            height:400px;
            border:1px solid;
            padding:50px 40px;
            box-sizing:border-box;
            background:rgba(0,0,0,0.5);
            border-radius:20px;
        }
        .user{
            width:100px;
            height:100px;
            overflow:hidden;
            top:calc(-100px/2);
            left:calc(50% - 50px);
            position:absolute;
        }
        h2{
            margin:0;
            padding:0;
            text-align:center;
            color:rgb(255,217,9);
        }
        .lblemail, .lblpass{
            font-weight:bold;
        }
        .txtemail, .txtpass, .btnsubmit{
            width:100%;
            margin-bottom:20px;
        }
        .txtemail, .txtpass{
            border:none;
            border-bottom:1px solid #fff;
            outline:none;
            height:40px;
            color:#fff;
            font-size:16px;
            background-color:transparent;
        }
        ::placeholder{
            color:rgba(255,255,255,.5);
        }
        .btnsubmit{
            border:none;
            outline:none;
            height:40px;
            font-size:16px;
            color:white;
            background: linear-gradient(#022534,#0B546C,#A0BACC);
            border-radius:10px;
        }
    </style>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script>
        var object = { status: false, ele: null };

        function AdminLogin() {
            if (object.status) { return true; };

            swal({
                title: "Login Success!",
                text: "Admin successfully logged in!",
                icon: "success",
                button: "Ok!",
            }).then((value) => {
                window.location = "Dashboard.aspx";
            });
            return false;
        };
        var object = { status: false, ele: null };

        function UserLogin() {
            if (object.status) { return true; };

            swal({
                title: "Login Success!",
                text: "User successfully logged in!",
                icon: "success",
                button: "Ok!",
            }).then((value) => {
                window.location = "User_Dashboard.aspx";
            });
            return false;
        };
            var object = { status: false, ele: null };
            function InvalidMsg() {
                if (object.status) { return true; };

                swal({
                    title: "Sorry!",
                    text: "Invalid Username or Password!",
                    icon: "error",
                    button: "Ok!",
                });
                return false;
        };
    </script>
</head>
<body>
    <div class="loginbox">
            <h2>Log in Here</h2>
        <br />
        
            <form id="form1" runat="server">
                <asp:Label ID="Label1" class="lblemail" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="txtUsername" class="txtemail" placeholder="Enter Email" runat="server"></asp:TextBox>
                
                <asp:Label ID="Label2" class="lblpass" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="txtPassword" class="txtpass" placeholder="*********" runat="server"></asp:TextBox>

                <asp:Button ID="btnLogin" runat="server" class="btnsubmit" Text="Sign In" OnClick="btnLogin_Click" />
<%--                <asp:LinkButton ID="LinkButton1" runat="server" Text="Forget Password"></asp:LinkButton>--%>
                
            <asp:LinkButton ID="lnCreateUser" style="margin:0 0 0 10px; color:black;" runat="server" OnClick="lnCreateUser_Click">Create New User</asp:LinkButton>
    </form>
        </div>
</body>
</html>
     
  