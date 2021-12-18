<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.Master" AutoEventWireup="true" CodeBehind="CustomerMedicateCondition1.aspx.cs" Inherits="TastyChef.CustomerMedicateCondition1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/CustomerNutritionAssessment.css" rel="stylesheet" />
<%--    <link href="css/CustomerRegistration.css" rel="stylesheet" />--%>
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
                        <li class="actived">Medical Condition</li>
                    </ul>
                </nav>
            </div>
            <div class="content">
                <table>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <th>
                            <h2>Medical Condition</h2>
                        </th>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="dm" Text="Diagnosed Medical Condition: " runat="server"></asp:Label></td>
                        <td>
                              <asp:CheckBoxList ID="CBLMedicalCondition" runat="server" AutoPostBack="true" >
                                <asp:ListItem Text="Diabetes" Value="Diabetes" runat="server"></asp:ListItem>
                                <asp:ListItem Text="Hypertension" Value="Hypertension" runat="server"></asp:ListItem>
                                  <asp:ListItem Text="None" Value="None" runat="server"></asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="glu" Text="Glucose level: " runat="server"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="glucose" runat="server"></asp:TextBox>
                            <asp:Label ID="unit" Text="" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="gl" Text="" runat="server"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="bloodpressure" runat="server"></asp:TextBox>
                            <asp:Label ID="mmHg" Text="" runat="server"></asp:Label>
                        </td>
                    </tr>
                   
                    <tr>
                        <td></td>
                    </tr>
                         <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
                    <tr>
                        <td><asp:Button ID="Back" CssClass="e" Text="Back" runat="server" OnClick="Back_Click" /></td>
                        <td><asp:Button ID="Sub" CssClass="e" Text="Submit" runat="server" OnClick="Sub_Click" /></td>
                    </tr>
                </table>

            </div>
        </div>
</asp:Content>
