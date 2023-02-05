<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="New User.aspx.cs" Inherits="NewUIProject.New_User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/style.css" rel="stylesheet" />
    <link href="bootstrap-5.1.3-dist/css/bootstrap.css" rel="stylesheet" />
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
     <style rel="stylesheet">
        body{
            margin:0;
            padding:0;
            background-image: url('Images/01.jpg');
            background-size:cover;
        }
         h2{
            margin:0;
            padding:0;
            text-align:center;
            color:rgb(255,217,9);
        }
        .loginbox{
            font-weight:bold;
            position:absolute;
            top:50%;
            left:50%;
            width:450px;
            transform:translate(-50%,-50%);
            height:450px;
            border:1px solid;
            padding:30px 40px;
            box-sizing:border-box;
            background:rgba(0,0,0,0.5);
            border-radius:20px;
        }
         .btnsubmit{
            border:none;
            outline:none;
            height:30px;
            font-size:16px;
            color:white;
            background: linear-gradient(#022534,#0B546C,#A0BACC);
            border-radius:10px;
        }

   </style>
    <script>
        var object = { status: false, ele: null };

        function UserCreate()
        {
            if (object.status) { return true; };

            swal({
                title: "User Created!",
                text: "User created successfully!",
                icon: "success",
                button: "Ok!",
            }).then((value) => {
                    window.location = "LoginPage.aspx";
                });
            return false;
        };
        var object = { status: false, ele: null };
        function FieldsRequired() {
            if (object.status) { return true; };

            swal({
                title: "Sorry!",
                text: "All fields are Required!",
                icon: "error",
                button: "Ok!",
            });
            return false;
        };

        var object = { status: false, ele: null };
        function EmailExists() {
            if (object.status) { return true; };

            swal({
                title: "Sorry!",
                text: "Email Already Exists!",
                icon: "error",
                button: "Ok!",
            });
            return false;
        };

        var object = { status: false, ele: null };
        function confirmCancel() {
            if (object.status) { return true; };

            swal({
                title: "Are you sure!",
                text: "Do you really want to cancel!",
                icon: "warning",
                buttons: ["No", "Yes!"],
                

            }).then((willDelete) => {
                if (willDelete) {
                    window.location = "LoginPage.aspx";
                }
            });  
            return false;
        };

    </script>
</head>
<body>
        <form id="form1" runat="server">
             <div class="loginbox">
             <h2>Create New User</h2>
                 <br />
            <asp:Label ID="Label1" runat="server" Text="First Name" ></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="Last Name" style="margin-left: 155px"></asp:Label><br/>
            <asp:TextBox ID="txtFname" class="BorderBottomStyle" runat="server" style="color:white; border-radius:10px; width:150px;border-color:deepskyblue; height:25px;" Autofocus></asp:TextBox>
            <asp:TextBox ID="txtLname" class="BorderBottomStyle" runat="server" style="margin-left:30px; color:white; border-radius:10px; width:150px;border-color:deepskyblue; height:25px;"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                 <br />
                <asp:Label ID="Label7" runat="server" Text="Address"></asp:Label>
                <br />
                <asp:TextBox ID="txtAddress" class="BorderBottomStyle" runat="server" style="width:332px; color:white; border-radius:10px; border-color:deepskyblue; height:25px;"></asp:TextBox>
                <br /> <br />

                <asp:Label ID="Label3" runat="server" Text="Email Address"></asp:Label>&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <br />
                <asp:TextBox ID="txtEmail" class="BorderBottomStyle" runat="server" style="height:25px;color:white;width:332px; border-color:deepskyblue; border-radius:10px;" ></asp:TextBox>
                <br /> <br />
               
                <asp:Label ID="Label4" runat="server" Text="Mobile Number"></asp:Label>&nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPhone" ErrorMessage="Number should be 10 Digits" ForeColor="Red" MaximumValue="9999999999" MinimumValue="999999999" Type="Double"></asp:RangeValidator>
                <br />
                <asp:TextBox ID="txtPhone" class="BorderBottomStyle" runat="server" style="height:25px; color:white; width:332px;border-color:deepskyblue;border-radius:10px;"></asp:TextBox> 
                <br /><br />
                <asp:Label ID="Label5" runat="server" Text="Create Password"></asp:Label>&nbsp;
                <asp:Label ID="Label6" runat="server" Text="Confirm Password" style="margin-left:60px;"></asp:Label>&nbsp;
                <br/>
                <asp:TextBox ID="txtPasswd" class="BorderBottomStyle" runat="server" TextMode="Password" style="height:25px;color:white;width:150px;border-color:deepskyblue;border-radius:10px;"></asp:TextBox>
                <asp:TextBox ID="txtCPasswd" class="BorderBottomStyle" runat="server" TextMode="Password" style="height:25px;color:white;width:150px;margin-left:30px;border-color:deepskyblue;border-radius:10px;"></asp:TextBox>
                <br />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtCPasswd" ControlToValidate="txtPasswd" ErrorMessage="Both Password should be Same" ForeColor="Red"></asp:CompareValidator>
                <br />
                <asp:Button ID="btnCreateUser" runat="server" Text="Create User" CssClass="btnsubmit" style="padding:2px;border-color:blueviolet; background-color:lightcyan; width:100px; border-radius:10px;" OnClick="btnCreateUser_Click" />
                &nbsp;
                <asp:Button ID="btncancel" runat="server" CssClass="btnsubmit" Text="Cancel" OnClick="btncancel_Click" style="border-radius:10px; background-color:lightcyan; width:80px; border-color:blueviolet;padding:2px;"/>
            </div>
        
    </form>
</body>
</html>
