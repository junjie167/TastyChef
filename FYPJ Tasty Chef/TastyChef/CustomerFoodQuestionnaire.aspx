<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.Master" AutoEventWireup="true" CodeBehind="CustomerFoodQuestionnaire.aspx.cs" Inherits="TastyChef.CustomerFoodQuestionnaire" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/CustomerNutritionAssessment.css" rel="stylesheet" />
<%--      <link href="css/CustomerRegistration.css" rel="stylesheet" />--%>
    <style>
        .e{
            background:#4DB6AC;
             border-color:White;
             border:Solid;
             font-weight:bold;
             font-family:Harrington;
             Font-Size:x-large;
             color:White;
             Height:50px;
             Width:125px;
  }
    </style>
        <div class="container">
            <div class="headd">
                <h1>Nutrition Assessment</h1>
            </div>
             &nbsp;
             &nbsp;
            <div class="progressb">
                <nav>
                    <ul class="progressbar">
                        <li class="actived">Physical Profile</li>
                        <li class="actived">Food Questionnaire</li>
                        <li>Medical Condition</li>
                    </ul>
                </nav>
            </div>
            <div class="content">
                <table>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <th><h2>Food Questionnaire</h2></th>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="diet" Text="Diet Type: " runat="server"></asp:Label></td>
                        <td><asp:DropDownList ID="diettype" runat="server">
                    <asp:ListItem>Please Select</asp:ListItem>
                              <asp:ListItem>None</asp:ListItem>
                    <asp:ListItem>Vegetarian</asp:ListItem>
                              <asp:ListItem>Vegan</asp:ListItem> 
                            <asp:ListItem>Atkins/Ketogenic</asp:ListItem>                       
                    </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="foodallergy" Text="Food Allergy: " runat="server"></asp:Label></td>
                        <td>
                            <asp:CheckBoxList ID="allergies" runat="server" RepeatDirection="Horizontal" >
                                            <asp:ListItem Text="None" Value="None" runat="server"></asp:ListItem>
                                            <asp:ListItem Text="Fish" Value="Fish" runat="server"></asp:ListItem>
                                         <asp:ListItem Text="ShellFish" Value="ShellFish" runat="server"></asp:ListItem>
                                        <asp:ListItem Text="Peanut" Value="Peanut" runat="server">Peanut</asp:ListItem>
                                        <asp:ListItem Text="Tree Nut" Value="Tree Nut" runat="server"></asp:ListItem>
                             </asp:CheckBoxList>
                            <asp:CheckBox ID="other" Text="Others: " runat="server" AutoPostBack="true" OnCheckedChanged="other_CheckedChanged" />
                            <asp:TextBox ID="allergyother" runat="server"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="foodavoid" Text="Food Avoidance: " runat="server"></asp:Label></td>
                        <td>
                            <asp:CheckBoxList ID="avoid" runat="server" RepeatDirection="Horizontal" >
                                            <asp:ListItem Text="None" Value="None" runat="server"></asp:ListItem>
                                            <asp:ListItem Text="Beef" Value="Beef" runat="server">Beef</asp:ListItem>
                                         <asp:ListItem>Shellfish</asp:ListItem>
                                        <asp:ListItem>Peanut</asp:ListItem>
                                        <asp:ListItem>Tree Nut</asp:ListItem>
                             </asp:CheckBoxList>
                            <asp:CheckBox ID="otheravoidance" Text="Others: " runat="server" AutoPostBack="true" OnCheckedChanged="otheravoidance_CheckedChanged" />
                            <asp:TextBox ID="otheravoid" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="frequency" Text="Frequency of Meals per day: " runat="server"></asp:Label></td>
                        <td><asp:TextBox ID="mealfrequency" runat="server"></asp:TextBox>times</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="freq" Text="Frequency of Snacks per day: " runat="server"></asp:Label></td>
                        <td><asp:TextBox ID="snackfrequency" runat="server"></asp:TextBox>times</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="Back" CssClass="e" Text="Back" runat="server" OnClick="Back_Click" /></td>
                        <td><asp:Button ID="Next" CssClass="e" Text="Next" runat="server" OnClick="Next_Click" /></td>
                    </tr>
                </table>
            </div>
        </div>
</asp:Content>
