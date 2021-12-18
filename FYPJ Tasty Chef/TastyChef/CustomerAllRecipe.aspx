<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerHomeMasterPage.Master" AutoEventWireup="true" CodeBehind="CustomerAllRecipe.aspx.cs" Inherits="TastyChef.CustomerAllRecipe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
          .headd{
              color:#003366;
            text-align:center;
            font-family: Arial;
            margin-top: 160px;
         }
         .showbanner{
             font-family:Arial;
             font-size:2em;
             background:white;
         }
         .recipebackground{
             background:white;
         }
         table{
             border-collapse:separate;
             border-spacing:12px;
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
             Font-Size:1.2em;
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
             Font-Size:1.2em;
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
             font-size:5.5em;
         }
         li{
             list-style-type:none;
         }
         .filterborder{
             background:white;
             font-size:1.2em;
         }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <div class="container">
        <div class="headd" id="he" runat="server">
            <h1>All Menu</h1>
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
                      <td>
                          <div class="right">
                              <a href="#" onserverclick="filter_click" runat="server">Filter<b class="caret"></b></a>
                          </div>                         
                      </td>
                  </tr>
              </table>
          </div>
          <div class="filterborder">
              <asp:PlaceHolder ID="filter" runat="server">
                  <table>
                      <tr>
                          <td><asp:Label ID="lbl1" Text="Calories: " runat="server"></asp:Label></td>
                          <td>
                              <asp:CheckBoxList ID="filtercalories" RepeatDirection="Horizontal" runat="server">
                                  <asp:ListItem>150 - 400</asp:ListItem>
                                  <asp:ListItem>401 - 600</asp:ListItem>
                                  <asp:ListItem>601 - 800</asp:ListItem>
                                  <asp:ListItem>801 - 1000</asp:ListItem>
                              </asp:CheckBoxList>
                          </td>
                      </tr>
                      <tr>
                          <td colspan="2"><hr /></td>
                      </tr>
                      <tr>
                          <td><asp:Label ID="lbl2" Text="Tailor-Made:" runat="server"></asp:Label></td>
                          <td>
                              <asp:CheckBoxList ID="filtertm" RepeatDirection="Horizontal" runat="server">
                                  <asp:ListItem>Diabetes</asp:ListItem>
                                  <asp:ListItem>Non-Diabetes</asp:ListItem>
                              </asp:CheckBoxList>
                          </td>
                      </tr>
                  </table>
              </asp:PlaceHolder>
          </div>
          <br />
          <br />
          <div class="recipeborder">
              <asp:DataList ID="Recipe" runat="server" RepeatColumns="3" CellPadding="3" CellSpacing="-1" RepeatLayout="Table" >
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
                                   <td> <asp:Button ID="details" CssClass="buttondesign2" Text="View Details" OnClick="recipedetails" runat="server" /></td>
                                  <td>
                                      <div class="right">
                                            <asp:Button ID="addcart" CssClass="buttondesign" OnClick="addcart"  runat="server" Text="Add to Cart" />
                                      </div>
                                  </td>
                              </tr>
                          </table>
                          <div class="seprator">
                          </div>
                           <div class="caloriesborder">
                                    <asp:Label ID="recipeproteinlabel"   Text="Calories:" runat="server"></asp:Label>
                                     <br />
                                    <asp:Label ID="recipeprotein" ForeColor="Red" Text='<%#Eval("recipecalories") %>' runat="server"></asp:Label>
                                   <asp:Label ID="unit" Text=" Kcal" runat="server"></asp:Label>
                            </div>
                            <div class="right" style="width:50%;background:white;font-size:1.2em;text-align:center;">
                                  <asp:Label ID="tailo" Text="Suitable for: " runat="server"></asp:Label>
                                <br />
                                 <asp:Label ID="tailormade" ForeColor="Red" Text='<%#Eval("recipemedicalcondition ") %>' runat="server"></asp:Label>
                            </div>
                          </div>
                  </ItemTemplate>
                  <%--<ItemTemplate>
                      <div class="recipebackground">
                        <table>
                            <tr>
                                <td style="width:140px;"></td>
                                <td style="width:140px;"></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <center><asp:Image ID="recipeimage" ImageUrl='<%# Eval("recipeimage") %>' Width="100px" Height="130px" runat="server" /></center></td>
                            </tr>
                            <tr>
                                <td colspan="3"><asp:LinkButton ID="recipename" Text='<%# Eval("recipename")%>' runat="server"></asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td colspan="3"><asp:Button ID="addcart" runat="server" Text="Add to Cart" /></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="recipeproteinlabel" Text="Protein:" runat="server"></asp:Label>
                                    <br />
                                    <asp:Label ID="recipeprotein" Text='<%#Eval("recipeprotein") %>' runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="recipefatlabel" Text="Fats:" runat="server"></asp:Label>
                                    <br />
                                    <asp:Label ID="recipefat" Text='<%#Eval("recipetotalfat") %>' runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="recipecarblabel" Text="Carbs:" runat="server"></asp:Label>
                                    <br />
                                    <asp:Label ID="recipecarb" Text='<%#Eval("recipecarbohydrate") %>' runat="server"></asp:Label> 
                                </td>
                            </tr>
                        </table>
                          </div>
                    </ItemTemplate>--%>
              </asp:DataList>
          </div>
       </div>    
</asp:Content>
