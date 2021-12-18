<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.Master" AutoEventWireup="true" CodeBehind="CustomerRecipeRecommendation.aspx.cs" Inherits="TastyChef.CustomerRecipeRecommendation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
         .borderouter{
            border:2px solid #4DB6AC;
            border-radius:12px;
            width:100%;
            background-color:white;
            font-family:Arial;
        }
         .borderouters{
              border:2px solid #4DB6AC;
            border-radius:12px;
            width:100%;
            background-color:white;
            font-family:Arial;
         }
          .borderhead{
            background-color:#4DB6AC;
            text-align:center;
            margin-top:0px;
            border-top-left-radius:10px;
            border-top-right-radius:10px;
        }
         .titlee{
          font-size:1.2em;
            color:#003366;
            font-weight:bold;
            display:inline-block;
        }
         .headd{
              color:#003366;
            text-align:center;
            font-family: Arial;
         }
          h4{
            text-decoration:underline;
            font-weight:bold;
        }
           .buttondesign{
              background:#4DB6AC;
             border-color:White;
             border:Solid;
             border-radius:10px;
             font-weight:bold;
             font-family:Arial;
             Font-Size:x-large;
             color:White;
             Height:50px;
             Width:auto;
         }
         .listdesign li{
             list-style-type:none;
             display:inline-block;
             background-color:lightgrey;
             margin-right:40px;
             padding:20px;
         }
         .table1{
             margin-left:0px;
         }
         @media (min-width: 768px) {
         .borderouter{
             clear:both;
             width:25%;
            margin-top:260px;

         }
         .recipeborder{
             float:right;
             margin:auto;
             width:70%;
         }
         .borderouters{
             float:left;
             width:25%;

         }
         table{
             margin-left:30px;
         }
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div class="headd">
            <h1>Recommended Menu</h1>
            <hr />
        </div>
     <div class="borderouters">
            <div class="borderhead">
                  <h3 class="titlee">Current diet stats</h3>
            </div>
            <table style="font-size:1.2em; font-weight:bold;">
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width:105px"><asp:Label ID="pro" Text="Protein: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="protein" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="fa" Text="Fats: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="fat" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="car" Text="Carbohydrate: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="carbohydrate" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="carl" Text="Total Calories: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="calories" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <%--  <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="false" runat="server">
        <ContentTemplate>--%>
        <div class="recipeborder">
            <asp:PlaceHolder ID="filter" runat="server">
                <table class="table1">
                    <tr>
                        <td style="width:85px;"><asp:Label ID="choice" Text="Your Choice: " runat="server"></asp:Label></td>
                        <td><ul id="fliterlist" class="listdesign" runat="server"></ul></td>
                    </tr>
                </table> 
            </asp:PlaceHolder>
            <br />
             <asp:Label ID="Label1" Text="hello" runat="server"></asp:Label>
        </div>

         <br />
        <br />
       
           <div class="borderouter">
            <div class="borderhead">
                <h3 class="titlee">Fliter By</h3>
            </div>
               <asp:LinkButton ID="cleare" Text="Clear All" ForeColor="blue" runat="server" OnClick="clear_Click" ></asp:LinkButton>
<%--                <asp:Button ID="clear" CssClass="buttondesign" Text="Clear All" runat="server" OnClick="clear_Click" />--%>
            <table style="font-size:1.2em; font-weight:bold;">
                <tr>
                    <td><h4>Schedule</h4></td>
                    <td></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                         <asp:CheckBoxList ID="schedule" runat="server" OnSelectedIndexChanged="schedule_SelectedIndexChanged"  AutoPostBack="true">
                            <asp:ListItem>Monday</asp:ListItem>
                            <asp:ListItem>Tuesday</asp:ListItem>
                            <asp:ListItem>Wednesday</asp:ListItem>
                            <asp:ListItem>Thursday</asp:ListItem>
                            <asp:ListItem>Friday</asp:ListItem>
                            <asp:ListItem>Saturday</asp:ListItem>
                            <asp:ListItem>Sunday</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                </table>
                
               <br />
              <%-- <hr />
               <table style="font-size:1.2em; font-weight:bold;">
                <tr>
                    <td><asp:Label ID="avo" Text="Food Avoidance: " runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBoxList ID="avoid" runat="server">
                            <asp:ListItem>Beef</asp:ListItem>
                            <asp:ListItem>ShellFish</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                   <tr>
                       <td>&nbsp;</td>
                   </tr>
            </table>--%>
        </div>
                   <%--  </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="schedule" EventName="SelectedIndexChanged"  />
                <asp:AsyncPostBackTrigger ControlID="clear" EventName="Click" />
            </Triggers>
         </asp:UpdatePanel> --%>
        
    </div>
</asp:Content>
