<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.Master" AutoEventWireup="true" CodeBehind="CustomerRecipeRecommendation1.aspx.cs" Inherits="TastyChef.CustomerRecipeRecommendation1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
          .headd{
              color:#003366;
            text-align:center;
            font-family: Arial;
                font-weight:bold;
            font-size:3.5em;
         }
         .showbanner{
             font-family:Arial;
             font-size:1.3em;
             background:white;
         }
         .recipebackground{
             background:white;
         }
         .namecenter{
             text-align:center;
             font-size:1.3em;
             font-family:Arial;
             font-weight:bold;
         }
         .right{
             float:right;
         }
         .left{
             width:30%;
             float:left;
         }
         .seprator{
             border:3px solid #4DB6AC;
         }
         .buttondesign{
                background:#4DB6AC;
             border-color:White;
             border:Solid;
             border-radius:10px;
             font-weight:bold;
             font-family:Arial;
             Font-Size:1em;
             color:White;
             Height:50px;
             Width:auto;
         }
         .buttondesign2{
             background:white;
              border-color:black;
             border:Solid;
             border-radius:10px;
             font-family:Arial;
             Font-Size:1em;
             color:black;
             Height:50px;
             Width:auto;
         }
         .linkdesign{
             color:blue;
             font-size:1.2em;
             font-family:Arial;
         }
         .caloriesborder{
             width:50%;
             font-size:1.2em;
             border-right-style:solid;
             background:white;
             float:left;
             text-align:center;
         }
         .hello{
             font-weight:bold;
             color: #003366;
         }
         h1{
             font-size:4.5em;
         }
         table{
             border-collapse:separate;
             border-spacing:12px;
         }
         li{
             list-style-type:none;
         }
         #none{
             display:none;
         }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
          <div class="headd">
             <asp:Label ID="Label1" Text="Recommended Recipes" runat="server"></asp:Label>
        </div>
         <div class="showbanner">
              <table class="table1">
                  <tr>
                      <td></td>
                      <td></td>
                      <td></td>
                  </tr>
                  <tr>
                      <td colspan="2">
                          <asp:Label ID="schedulehead" Text="Day of the week: " runat="server"></asp:Label>&nbsp;
                          <asp:DropDownList ID="sc" runat="server" AutoPostBack="true" OnSelectedIndexChanged="sched_SelectedIndexChanged" >
                               <asp:ListItem>Monday</asp:ListItem>
                              <asp:ListItem>Tuesday</asp:ListItem>
                              <asp:ListItem>Wednesday</asp:ListItem>
                              <asp:ListItem>Thursday</asp:ListItem>
                              <asp:ListItem>Friday</asp:ListItem>
                              <asp:ListItem>Saturday</asp:ListItem>
                              <asp:ListItem>Sunday</asp:ListItem>
                          </asp:DropDownList>
                      </td>
                  </tr>
              </table>
          </div>
        <br />
        <div class="left">
              <asp:LinkButton ID="previous" CssClass="linkdesign" Text="Previous" OnClick="previous_click" runat="server"></asp:LinkButton>
        </div>
          <div class="right">
            <asp:LinkButton ID="next" CssClass="linkdesign" Text="Next"  OnClick="next_click" runat="server"></asp:LinkButton>
            </div>
        <div class="recipeborder">
            <asp:DataList ID="RecommendRecipe" runat="server" RepeatColumns="3" CellPadding="3" CellSpacing="-1">
                 <ItemStyle  Width="33%" />
                <ItemTemplate>
                    <div class="recipebackground">
                    <center><asp:Image ID="recipeimage" ImageUrl='<%# Eval("recipeimage") %>' Width="358px" Height="260px" runat="server" /></center><br />
                    <div class="namecenter">
                               <asp:LinkButton ID="recipename" Text='<%# Eval("recipename")%>' OnClick="recipe_linkbutton" runat="server"></asp:LinkButton>
                          </div>
                          <br />
                          <table>
                              <tr>
                                   <td> <asp:Button ID="details" CssClass="buttondesign2" OnClick="recipedetails" Text="View Details" runat="server" /></td>
                                  <td>
                                      <div class="right">
                                            <asp:Button ID="addcart" CssClass="buttondesign" OnClick="addcart"  runat="server" Text="Add to Cart" />
                                      </div>
                                  </td>
                              </tr>
                          </table>
                          <div class="seprator">
                          </div>
                         <%--  <div class="caloriesborder">
                                    <asp:Label ID="recipeproteinlabel"   Text="Calories:" runat="server"></asp:Label>
                                     <br />
                                    <asp:Label ID="recipeprotein" ForeColor="Red" Text='<%#Eval("recipecalories") %>' runat="server"></asp:Label>
                                   <asp:Label ID="unit" Text=" Kcal" runat="server"></asp:Label>
                            </div>
                            <div class="right" style="width:50%;background:white;font-size:1.2em;text-align:center;">
                                  <asp:Label ID="tailo" Text="Suitable for: " runat="server"></asp:Label>
                                <br />
                                 <asp:Label ID="tailormade" ForeColor="Red" Text='<%#Eval("recipemedicalcondition") %>' runat="server"></asp:Label>
                            </div>--%>
                          </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
 </div>
</asp:Content>
