<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminSignUpPage.aspx.cs" Inherits="TastyChef.AdminSignUpPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Sign Up</title>
    <style type="text/css">
        .auto-style1 {
            width: 50%;
            align-content: center;
            margin-left: 25%;
            margin-top: 5%;
            border: solid;
            border-color: #4DB6AC;
        }

        #content {
            text-align: center;
            align-content: center;
        }

        .newStyle1 {
            font-family: Harrington;
            font-size: 3em;
            font-style: normal;
            font-weight: bold;
            color: #4DB6AC;
        }

        .auto-style2 {
            text-align: right;
            width: 278px;
            height: 72px;
        }

        .auto-style4 {
            margin-left: 61px;
            border-radius: 4px;
            border-color:lightgrey;
            border-width:1px;
            height:25px;
            width:250px;
            font-size:20px;
        }
        .auto-style5 {
            text-align: right;
            width: 278px;
            height: 100px;
        }
        .auto-style6 {
            text-align: left;
            height: 100px;
        }
        .auto-style7 {
            height: 72px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <div id="content">

            <table class="auto-style1">
                <tr class="newStyle1">
                    <td colspan="2">Registration</td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Imprint MT Shadow" Font-Size="X-Large" Text="Name"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TbName" runat="server" CssClass="auto-style4" ></asp:TextBox>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Imprint MT Shadow" Font-Size="X-Large" Text="LoginID"></asp:Label></td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TbLoginID" runat="server" CssClass="auto-style4" AutoPostBack="True" OnTextChanged="TbLoginID_TextChanged"></asp:TextBox>
                        <asp:Label ID="LblErrorMessage" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Imprint MT Shadow" Font-Size="X-Large" Text="Password"></asp:Label></td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TbPassword" TextMode="Password" runat="server" CssClass="auto-style4"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Imprint MT Shadow" Font-Size="X-Large" Text="Re-Enter Password"></asp:Label></td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TbReEnterPassword" TextMode="Password" runat="server" CssClass="auto-style4"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TbPassword" ControlToValidate="TbReEnterPassword" ErrorMessage="Password not matched" ForeColor="Red"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="BtnBack" runat="server" Text="Back" Height="40px" Width="100px" BackColor="#4DB6AC" BorderColor="White" Font-Bold="True" Font-Size="Large" ForeColor="White" Font-Names="Harrington" BorderStyle="Solid" OnClick="BtnBack_Click" />
                    </td>
                    <td class="auto-style7">
                        <asp:Button ID="BtnCreate" runat="server" Text="Create" Height="40px" Width="100px" BackColor="#4DB6AC" BorderColor="White" Font-Bold="True" Font-Size="Large" ForeColor="White" Font-Names="Harrington" BorderStyle="Solid" OnClick="BtnCreate_Click" />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
