<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLoginPage.aspx.cs" Inherits="TastyChef.AdminLoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login Page</title>
    <style>
           #a {
            background-color: #4DB6AC;
            font-family: Poiret One;
            color: white;
            font-size: 1.5em;
            text-align: center;
        }

        .auto-style1 {
            width: 45%;
            margin-left: 25%;
            margin-top: 3.5%;
            height: 30em;
            border-collapse: collapse;
        }

        #b {
            text-align: right;
            background-color: #4DB6AC;
            font-family: Poiret One;
            color: white;
            font-size: 1.5em;
        }

    
        .auto-style2 {
            text-align: left;
            height: 119px;
        }
        .auto-style3 {
            height: 377px;
        }
        .auto-style6 {
            height: 140px;
        }
        .auto-style7 {
            height: 119px;
        }
        .auto-style8 {
            height: 120px;
        }
        .auto-style9 {
            text-align: left;
            height: 120px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table class="auto-style1">
                        <tr>
                            <td colspan="2" style="text-align: center" class="auto-style3">
                                <asp:Image ID="Image1" ImageUrl="~/Images/Drawing (1) - Copy.png" runat="server" Height="192px" Width="207px" />


                            </td>
                        </tr>
                        <tr id="a">
                            <td id="b" class="auto-style8">Login ID:</td>
                            <td class="auto-style9">
                                <asp:TextBox ID="TbLoginID" runat="server" Height="25px" Width="200px" Font-Size="X-Large"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="a">
                            <td id="b" class="auto-style7">Password:</td>
                            <td class="auto-style2">
                                <asp:TextBox ID="TbPassword" runat="server" Height="25px" Width="200px" TextMode="Password" Font-Size="X-Large"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="a">
                            <td style="text-align: right" class="auto-style6">
                                <asp:Button ID="BtnSignUp" runat="server" Text="Sign Up" Height="40px" Width="100px" BackColor="#4DB6AC" BorderColor="White" Font-Bold="True" Font-Size="Large" ForeColor="White" Font-Names="Harrington" BorderStyle="Solid" OnClick="BtnSignUp_Click"/>
                            </td>
                            <td style="text-align: left" class="auto-style6">
                                <asp:Button ID="BtnLogin" runat="server" Text="Login" Height="40px" Width="100px" BackColor="#4DB6AC" BorderColor="White" Font-Bold="True" Font-Size="Large" ForeColor="White" Font-Names="Harrington" BorderStyle="Solid" OnClick="BtnLogin_Click" />
                            </td>
                        </tr>
                    </table>
        
    </div>
    </form>
</body>
</html>
