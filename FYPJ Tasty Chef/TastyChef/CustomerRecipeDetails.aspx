<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerHomeMasterPage.Master" AutoEventWireup="true" CodeBehind="CustomerRecipeDetails.aspx.cs" Inherits="TastyChef.CustomerRecipeDetails" %>
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
            margin-top: 160px;  
             clear:both;
         }
        .recipedetails{
            background:white;
            overflow:hidden;
            padding:15px;
        }
        .recipeimage{
            width:50%;
            float:left;
        }
        .reciped{
            width:100%;
            margin-top:415px;
        }
        .recipeequitment{
            background:white;
             overflow:hidden;
            padding:15px;
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
             Width:100%;
        }
        .buttondesign2{
             background:#FFF3EA;
              border-color:black;
             border:Solid;
             border-radius:10px;
             font-family:Arial;
             Font-Size:1em;
             color:black;
             Height:50px;
             Width:auto;
             float:left;
             margin-top:110px;       
         }
        .textdesign{
            font-family:Arial;
            font-size:1.3em;
        }
        .nutritionhead{
            clear:both;
              color:#003366;
            text-align:center;
            font-family: Arial;
            font-weight:bold;
            font-size:2.5em;
        }
        .nutritioncontent{
            /*padding-left:88px;*/
            font-size:1.3em;
            font-family:Arial;
        }
        .fontbold{
            font-weight:bold;
        }
        .ingredientcontent{
            width:50%;
            float:left;
        }
        .equipmentcontent{
            width:45%;
            float:right;
        }
        .namecenter{
            text-align:center;
        }
        .recipeingredient{
            font-family:Arial;
            font-size: 1.3em;
            overflow:auto;
            height:600px;
        }
        .cookingborder{
            background:white;
            padding:10px;
            font-family:Arial;
            overflow:hidden;
        }
        .bold{
            font-family:Arial;
            font-weight:bold;
            font-size:2.5em;
             color:#003366;
        }
        .cookingware{
            width:45%;
            float:right;
        }
        .cookinstructioncontent{
            width:50%;
            float:left;
        }
        .cookingcontent{
            font-size:1.3em;
            font-family:Arial;
             overflow:auto;
            height:600px;
        }
        .cookwarecontent{
            font-size:1.3em;
            font-family:Arial;
        }
        .fontbold{
            font-weight:bold;
        }
       
         @media (min-width: 768px) {
        .reciped{
            width:45%;
            float:right;
            margin-top:0px;
            }
         }
    </style>
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
         <asp:Button ID="back" CssClass="buttondesign2" runat="server" OnClick="back_Click" />
         <div class="headd" id="he" runat="server" >
                <asp:Label ID="Label4" Text="Recipe Details" runat="server"></asp:Label>
                </div>
        <br />
        <div class="recipedetails">
            <br />
            <div class="recipeimage">
                <asp:Image ID="image"  Width="550px" Height="400px" runat="server" />
            </div>
            <div class="reciped">
<%--                <asp:Button ID="addcart" CssClass="buttondesign" Text="Add to Cart" runat="server" OnClick="addcart_Click" />--%>
                    <asp:Label ID="recipename" CssClass="bold" runat="server"></asp:Label>
                <br />
                <br />
                <table>
                    <tr>
                        <td style="width:200px;"></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="schedulelbl" CssClass="textdesign fontbold" Text="Day of the week: " runat="server"></asp:Label></td>
                        <td><asp:Label ID="schedule" CssClass="textdesign" runat="server"></asp:Label></td>
                    </tr>
                      <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="meal" CssClass="textdesign fontbold" Text="Cuisine Type: " runat="server"></asp:Label>
                        </td>
                        <td><asp:Label ID="mealtype" CssClass="textdesign" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="medicalbl" CssClass="textdesign fontbold" Text="Suitable for: " runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="medical" CssClass="textdesign" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="time" CssClass="textdesign fontbold" Text="Cooking Time: " runat="server"></asp:Label>
                        </td>
                        <td><asp:Label ID="cookingtime" CssClass="textdesign" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="portion" CssClass="textdesign fontbold" Text="Servings: " runat="server"></asp:Label>
                        </td>
                        <td><asp:Label ID="serving" CssClass="textdesign" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="ctype" CssClass="textdesign fontbold" Text="Cooking Type: " runat="server"></asp:Label></td>
                        <td><asp:Label ID="cookingtype" CssClass="textdesign" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="rfounder" CssClass="textdesign fontbold" Text="Created By: " runat="server"></asp:Label></td>
                        <td><asp:Label ID="founder" CssClass="textdesign" runat="server"></asp:Label></td>
                    </tr>
                </table>
                 <br />
                <br />
            </div>
            <br />
    <%--        <div class="nutritionhead">
                <asp:Label ID="nutritionhead" Text="Nutrition Facts" runat="server"></asp:Label>
                    <hr />
            </div>
            <div class="nutritioncontent">
                <table>
                     <tr>
                        <td>
                            <asp:Label ID="proteinlbl" CssClass="fontbold" Text="Protein: " runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="protein" CssClass="fontbold" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="fatlbl" CssClass="fontbold" Text="Total Fats: " runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="fat" CssClass="fontbold" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="carbslbl" CssClass="fontbold" Text="Total Carbohydrates: " runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="carbs" CssClass="fontbold" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="calorieslbl" CssClass="fontbold" Text="Calories: " runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="calories" CssClass="fontbold" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="sodiumlbl" Text="Sodium: " runat="server"></asp:Label>
                            &nbsp;
                            <asp:Label ID="sodium" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="sugarlbl" Text="Sugar: " runat="server"></asp:Label>
                            &nbsp;
                            <asp:Label ID="sugar" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="fibrelbl" Text="Dietary Fibre: " runat="server"></asp:Label>
                            &nbsp;
                            <asp:Label ID="fibre" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="cholsterollbl" Text="Cholestero: " runat="server"></asp:Label>
                            &nbsp;
                            <asp:Label ID="cholsterol" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="satfatlbl" Text="Saturated Fats: " runat="server"></asp:Label>
                            &nbsp;
                            <asp:Label ID="satfat" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="tranfatlbl" Text="Trans Fats: " runat="server"></asp:Label>
                            &nbsp;
                            <asp:Label ID="tranfat" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>--%>
        </div>
        <br />
        <div class="recipeequitment">
            <div class="ingredientcontent">
                <div class="nutritionhead">
                <asp:Label ID="Label1" Text="Ingredients" runat="server"></asp:Label>
                    <hr />
                </div>
                <div class="recipeingredient">
                     <asp:Label ID="allergylbl" CssClass="fontbold" Text="Allergens: " ForeColor="Red" runat="server"></asp:Label>
                    <asp:Label ID="allergy" CssClass="fontbold" runat="server"></asp:Label>    
                    <br />
                    <br />
                     <asp:Label ID="word" Text="What we provide: " runat="server"></asp:Label>
                     <br />
                    <br />
                     <asp:DataList ID="Ingredient" runat="server" RepeatColumns="2" CellPadding="3" CellSpacing="-1" RepeatLayout="Table">
                         <ItemStyle  Width="33%" />
                         <ItemTemplate>
                                <center><asp:Image ID="recipeimage" ImageUrl='<%# Eval("ingredientimage") %>' Width="100px" Height="100px" runat="server" /></center><br />
                             <div class="namecenter">
                                 <asp:Label ID="quantity" Text='<%#Eval("ingretientquantity") %>' runat="server"></asp:Label>
                                 <asp:Label ID="measurement" Text='<%#Eval("ingredientmeasurement") %>' runat="server"></asp:Label>
                                 <asp:Label ID="word2" Text=" of " runat="server"></asp:Label>
                                 <asp:Label ID="ingredientname" Text='<%#Eval("ingredientname") %>' runat="server"></asp:Label>
                             </div>
                         </ItemTemplate>
                     </asp:DataList>
                </div>
            </div>
            <div class="equipmentcontent">
                <div class="nutritionhead">
                <asp:Label ID="Label2" Text="Nutrition Facts" runat="server"></asp:Label>
                    <hr />
                </div>
                <div class="nutritioncontent">
                <table>
                    <tr>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                           <asp:Label ID="calorieslbl" CssClass="fontbold" Text="Calories: " runat="server"></asp:Label>
                            &nbsp;
                             <asp:Label ID="calories" CssClass="fontbold" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                             <asp:Label ID="fatlbl" CssClass="fontbold" Text="Total Fats: " runat="server"></asp:Label>
                             &nbsp;
                            <asp:Label ID="fat" CssClass="fontbold" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="satfatlbl" Text="Saturated Fats: " runat="server"></asp:Label>
                            &nbsp;
                            <asp:Label ID="satfat" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                              <asp:Label ID="tranfatlbl" Text="Trans Fats: " runat="server"></asp:Label>
                            &nbsp;
                            <asp:Label ID="tranfat" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                             <asp:Label ID="cholsterollbl" Text="Cholesterol: " runat="server"></asp:Label>
                            &nbsp;
                            <asp:Label ID="cholsterol" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="sodiumlbl" Text="Sodium: " runat="server"></asp:Label>
                            &nbsp;
                            <asp:Label ID="sodium" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                             <asp:Label ID="carbslbl" CssClass="fontbold" Text="Total Carbohydrates: " runat="server"></asp:Label>
                            &nbsp;
                            <asp:Label ID="carbs" CssClass="fontbold"  runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="fibrelbl" Text="Dietary Fibre: " runat="server"></asp:Label>
                            &nbsp;
                            <asp:Label ID="fibre" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                             <asp:Label ID="sugarlbl" Text="Sugar: " runat="server"></asp:Label>
                            &nbsp;
                            <asp:Label ID="sugar" runat="server"></asp:Label>
                        </td>
                    </tr>
                      <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                             <asp:Label ID="proteinlbl" CssClass="fontbold" Text="Protein: " runat="server"></asp:Label>
                            &nbsp;
                            <asp:Label ID="protein" CssClass="fontbold" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                </table>
               </div>
            </div>         
        </div>
         <br />
            <div class="cookingborder">
                <div class="cookinstructioncontent">              
                <div class="nutritionhead">
                     <asp:Label ID="Label3" Text="Cooking Instructions" runat="server"></asp:Label>
                    <hr />
                </div>               
                <br />
                <div class="cookingcontent">
                    <table>
                        <tr>
                            <td style="width:120px; text-align:center;">
                                <asp:Label ID="stepslbl" CssClass="fontbold" Text="Steps" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="instructionlbl" CssClass="fontbold" Text="Instruction" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="instructioncontent" AutoGenerateColumns="False"  runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td style="width:120px; text-align:center;">
                                                <asp:Label ID="steps" Text='<%#Eval("recipesteps") %>' runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="instruction"  Text='<%#Eval("recipeinstruction") %>' runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="recipesteps" HeaderText="Steps" />
                            <asp:BoundField DataField="recipeinstruction" HeaderText="Instructions" />--%>
                        </Columns>                     
                    </asp:GridView>
                </div>
            </div>
                <div class="cookingware">
                     <div class="nutritionhead">
                     <asp:Label ID="Label5" Text="Cookware(s)" runat="server"></asp:Label>
                    <hr />
                </div>
                    <div class="cookwarecontent">
                        <asp:Label ID="recipeequipment" runat="server"></asp:Label>
                    </div>                   
                </div>
          </div>
             
        <br />
        <br />
    </div>
</asp:Content>
