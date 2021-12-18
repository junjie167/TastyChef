<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerHomeMasterPage.Master" AutoEventWireup="true" CodeBehind="CustomerDeliveryRegister.aspx.cs" Inherits="TastyChef.CustomerDeliveryRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="css/CustomerRegistration.css" rel="stylesheet" />
    <section>
        <div class="container">
            <div class="headd">
                <h1>Registration</h1>
            </div>
               &nbsp;
             &nbsp;
            <div class="progressb">
                <nav>
                    <ul class="progressbar">
                        <li class="actived">Personal details</li>
                        <li class="actived">Delivery Information</li>
                        <li>Physical Profile</li>
                           <li>Food Questionnaire</li>
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
                        <th><h2>Delivery Information</h2></th>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="pc" Text="Postal Code: " runat="server"></asp:Label></td>
                        <td><asp:TextBox ID="PostalCode" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="add" Text="Delivery Address: " runat="server"></asp:Label></td>
                        <td><asp:Label ID="address" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="unit" Text="Unit Number: " runat="server"></asp:Label></td>
                        <td><asp:TextBox ID="UnitNumber" runat="server"></asp:TextBox></td>
                    </tr>
                     <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
                    <tr>
                        <td><asp:Button ID="Back" Text="Back" runat="server" OnClick="Back_Click" /></td>
                        <td><asp:Button ID="Next" Text="Next" runat="server" OnClick="Next_Click" /></td>
                    </tr>
                      <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
                      <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
                                          <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
                </table>
            </div>
        </div>
    </section>
</asp:Content>
