<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminNutritionGroupInsert.aspx.cs" Inherits="TastyChef.AdminNutritionGroupInsert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(window).load(function () {
            $(".loader").fadeOut("slow");
        })
    </script>
    <style>
        #content {
            width: 1200px;
            height: 1000px;
            margin-left: 18%;
            margin-top: 1%;
            /*border: solid;
            border-color: aqua;*/
            font-family: Arial;
            font-size: 26px;
            color: black;
        }

        #heading {
            font-family: Arial;
            font-size: 42px;
            color: black;
            text-align: center;
        }

        #desc {
            font-family: Arial;
            font-size: 28px;
            color: grey;
            text-align: center;
        }

        #line {
            text-align: center;
            color: black;
        }

        #foodallergiescondition {
            margin-left: 10%;
            margin-top: 13%;
        }

        #cb {
            margin-right: 85%;
            margin-top:5%;
        }
        #cbl{
            margin-top:5%;
        }

        #button {
            margin-left: 60%;
        }

        .auto-style4 {
            height: 60px;
        }

        .dropdownlist {
            border-radius: 4px;
            border-color: lightgrey;
            border-width: 1.5px;
            height: 35px;
            width: 250px;
            font-size: 20px;
            color: grey;
        }

        .checkbox {
            font-size: 20px;
        }

        .button {
            border-radius: 8px;
            border-color: lightgrey;
            border-width: 1.5px;
        }

        .auto-style5 {
            text-align: center;
            height: 118px;
        }

        .auto-style6 {
            text-align: center;
            height: 251px;
        }

        .auto-style7 {
            text-align: center;
            height: 118px;
            width: 595px;
        }

        .auto-style8 {
            text-align: center;
            height: 251px;
            width: 595px;
        }

        .auto-style10 {
            width: 595px;
            height: 38px;
        }

        .loader {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url('Images/Loading_icon.gif') 50% 50% no-repeat rgb(249,249,249);
        }
        .auto-style13 {
            height: 38px;
        }
    </style>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Panel ID="Panel1" runat="server" DefaultButton="BtnSubmits">
        <div class="loader"></div>
        <div id="content">

            <table class="auto-style1">
                <tr>
                    <td colspan="2" class="auto-style4">
                        <div id="heading">
                            Nutrition Group
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style4">
                        <div id="desc">
                            Allocate each customer to their nutrition group and eat right!
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style4">
                        <div id="line">
                            _____________________

                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <div class="auto-style2">
                            Group Name<asp:Label ID="Label1" runat="server" ForeColor="Black" Text="*"></asp:Label>
                            <br />
                            <br />

                            <asp:DropDownList ID="DDLGroupName" runat="server" CssClass="dropdownlist">
                                <asp:ListItem Text="Please Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Group A" Value="GroupA"></asp:ListItem>
                                <asp:ListItem Text="Group B" Value="GroupB"></asp:ListItem>
                                <asp:ListItem Text="Group C" Value="GroupC"></asp:ListItem>
                                <asp:ListItem Text="Group D" Value="GroupD"></asp:ListItem>
                                <asp:ListItem Text="Group E" Value="GroupE"></asp:ListItem>
                                <asp:ListItem Text="Group F" Value="GroupF"></asp:ListItem>
                                <asp:ListItem Text="Group G" Value="GroupG"></asp:ListItem>
                                <asp:ListItem Text="Group H" Value="GroupH"></asp:ListItem>



                            </asp:DropDownList>

                        </div>
                    </td>
                    <td class="auto-style5">
                        <div>
                            Diet Type<asp:Label ID="Label4" runat="server" ForeColor="Black" Text="*"></asp:Label>
                            <br />
                            <br />
                            <asp:CheckBox ID="CBDTNone" runat="server" Text="None" CssClass="checkbox" TextAlign="Left" AutoPostBack="True" OnCheckedChanged="CBDTNone_CheckedChanged" />
                            <asp:CheckBox ID="CBDTAsian" runat="server" Text="Asian" CssClass="checkbox" TextAlign="Left" AutoPostBack="True" OnCheckedChanged="CBDTAsian_CheckedChanged" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <div>
                            Medical Condition<asp:Label ID="Label3" runat="server" ForeColor="Black" Text="*"></asp:Label>
                            <br />
                            <br />
                            <asp:CheckBox ID="CBMCNone" runat="server" Text="None" CssClass="checkbox" TextAlign="Left" AutoPostBack="True" OnCheckedChanged="CBMCNone_CheckedChanged" />
                            <asp:CheckBox ID="CBMCDiabetes" runat="server" Text="Diabetes" CssClass="checkbox" TextAlign="Left" AutoPostBack="True" OnCheckedChanged="CBMCDiabetes_CheckedChanged" />
                        </div>
                    </td>
                    <td class="auto-style6">
                        <div id="foodallergiescondition">
                            Food Allergies Condition<asp:Label ID="Label5" runat="server" ForeColor="Black" Text="*"></asp:Label>
                            <br />
                            <div id="cb">
                                <asp:CheckBox ID="CBFANone" runat="server" CssClass="checkbox" AutoPostBack="True" OnCheckedChanged="CBFANone_CheckedChanged" Text="None" />
                            </div>
                            <div id="cbl">
                                <asp:CheckBoxList ID="CBLFoodAllergy" runat="server" RepeatDirection="Horizontal" CellPadding="4" Font-Size="Large" RepeatColumns="4"></asp:CheckBoxList>
                                </div>
                                    <br />
                                </div>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10"></td>
                    <td class="auto-style13">
                        <div id="button">

                            <asp:Button ID="BtnSubmits" runat="server" BackColor="#4DB6AC" BorderColor="White" BorderStyle="Solid" Font-Bold="True" Font-Names="Harrington" Font-Size="x-Large" ForeColor="White" Height="50px" Text="Submits" Width="125px" CssClass="button" OnClick="BtnSubmits_Click" />




                        </div>
                    </td>
                </tr>
            </table>

        </div>
    </asp:Panel>
</asp:Content>
