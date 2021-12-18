<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.Master" AutoEventWireup="true" CodeBehind="CustomerShoppingCart.aspx.cs" Inherits="TastyChef.CustomerShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
         .headd{
              color:#003366;
            text-align:center;
            font-family: Arial;
         }
          h1{
             font-size:4.5em;
         }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div class="headd" id="he" runat="server">
            <h1>Shopping Cart</h1>
        </div>
    </div>
</asp:Content>
