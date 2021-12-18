<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.Master" AutoEventWireup="true" CodeBehind="CustomerSummary.aspx.cs" Inherits="TastyChef.CustomerSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .orderborder{
            width:60%;
            float:left;
        }
        .delivery{
            width:31%;
            float:right;
        }
        .orderhead{
              color:#003366;
            text-align:center;
            font-family: Arial;
            font-weight:bold;
            font-size:3em;
        }
        .addressdropdown{
            width:100%;
            padding:20px;
        }
         .caloriesborder{
             width:50%;
             font-size:1.2em;
             border-right-style:solid;
             background:white;
             float:left;
             text-align:center;
         }
          .right{
             float:right;
         }
          .namecenter{
             text-align:center;
             font-size:1.3em;
             font-family:Arial;
             font-weight:bold;
         }
          .seprator{
             border:3px solid #4DB6AC;
         }
           .recipebackground{
             background:white;
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
             Font-Size:1.3em;
             color:black;
             Height:50px;
             Width:auto;
         }
         .linkdesign{
             color:blue;
             font-size:1.2em;
             font-family:Arial;
         }
          table{
             border-collapse:separate;
             border-spacing:12px;
         }
          .hello{
               color:#003366;
            text-align:center;
            font-family: Arial;           
            font-weight:bold;
            font-size:3.5em; 
             clear:both;
          }
          .backgroundcolor{
              background-color:white;
              overflow:hidden;
          }
          .textcenter{
              text-align:center;
          }
          .subheaddesign{
              color:#003366;
            font-family: Arial;
            font-weight:bold;
            font-size:2.5em;
            text-align:center;
         }
         .orderhistoryborder{
              background-color:white;
             width:60%;
             float:right;
         }
         .nutritionsummaryborder{
              background-color:white;
             width:35%;
             float:left;
         }
         .textcontent{
             font-family:Arial;
             font-size:1.3em;
         }
         .padding{
             padding:10px;
         }
        @media (min-width: 768px) {
        header.carousel{
       height:400px;
       margin-top:-50px;
      }
      
        }
        .creditborder{
            border:2px solid #4DB6AC;
            border-radius:20px;
            width:17%;
            font-weight:bold;
        }      
    </style>
    <div  class="container">
            <div class="textcontent">
                <div class="hello">
                    Welcome,
                     <asp:Label ID="name" runat="server"></asp:Label>
                </div>
                <br />
                <div class="creditborder">
                     <div class="padding">
                     <asp:Label ID="creditlbl" Text="Credit Available: " runat="server"></asp:Label>
                     &nbsp;
                    <asp:Label ID="credit" Text="0" runat="server"></asp:Label>
                </div>
            </div>
                </div>
               
       <%-- <div class="padding">
        <div class="right">
            <div class="textcontent">
            Welcome,
            <asp:Label ID="name" runat="server"></asp:Label>
           </div>
        </div>
            <div class="left">
                <div class="textcontent">
                    <asp:Label ID="creditlbl" Text="Credit Available: " runat="server"></asp:Label>
                     &nbsp;
                    <asp:Label ID="credit" Text="0" runat="server"></asp:Label>
                </div>
            </div>
        </div>--%>
       
        <br />
        
            <div class="nutritionsummaryborder">
             <div class="subheaddesign">
                <asp:Label ID="Label1" Text="Daily Nutrition Tracker" runat="server"></asp:Label>
                <hr />
            </div>
             <div class="textcontent">
                 <table>
                     <tr>
                         <td></td>
                         <td></td>
                     </tr>
                     <tr>
                         <td colspan="2">
                             <asp:Label ID="proteinlbl" Text="Total Protein Intake: " runat="server"></asp:Label>
                             &nbsp;
                             <asp:Label ID="protein" runat="server"></asp:Label>
                         </td>
                     </tr>
                     <tr>
                         <td>&nbsp;</td>
                     </tr>
                     <tr>
                         <td colspan="2">
                             <asp:Label ID="fatlbl" Text="Total Fats Intake: " runat="server"></asp:Label>
                             &nbsp;
                             <asp:Label ID="fat" runat="server"></asp:Label>
                         </td>
                     </tr>
                     <tr>
                         <td>&nbsp;</td>
                     </tr>
                     <tr>
                         <td colspan="2">
                             <asp:Label ID="carbolbl" Text="Total Carbohydrate Intake: " runat="server"></asp:Label>
                             &nbsp;
                             <asp:Label ID="carbohydrate" runat="server"></asp:Label>
                         </td>
                     </tr>
                     <tr>
                         <td>&nbsp;</td>
                     </tr>
                     <tr>
                         <td colspan="2">
                             <asp:Label ID="calorieslbl" Text="Total Calories Intake: " runat="server"></asp:Label>
                             &nbsp;
                             <asp:Label ID="carlories" runat="server"></asp:Label>
                         </td>
                     </tr>
                 </table>
             </div>
                  <div class="textcenter">
            <asp:Button ID="tracker" CssClass="buttondesign" Text="View More Details" runat="server" />
        </div>
         <br />
        </div>  
             <div class="orderhistoryborder">
            <div class="subheaddesign">
                <asp:Label ID="orderlbl" Text="Order History" runat="server"></asp:Label>
                <hr />
            </div>
             <br />
            <div class="textcenter">
            <asp:Button ID="neworder" CssClass="buttondesign" Text="Start New Order" runat="server" />
        </div>
         <br />
        </div>   
        
         
        <%--<div class="orderborder">
             <div class="orderhead">
                <asp:Label ID="Label1" Text="Today Recommended Menu" runat="server"></asp:Label>
                    <hr />
                </div>
            <asp:LinkButton ID="viewall" CssClass="linkdesign" Text="View All" runat="server" OnClick="viewall_click"></asp:LinkButton>
            <div class="right">
           <asp:LinkButton ID="previous" CssClass="linkdesign" Text="Previous" OnClick="previous_click" runat="server"></asp:LinkButton>
            <asp:LinkButton ID="next" CssClass="linkdesign" Text="Next"  OnClick="next_click" runat="server"></asp:LinkButton>
            </div>
            <br />
            <br />
            <asp:DataList ID="recommendrecipe" runat="server"  RepeatColumns="2" CellPadding="3" CellSpacing="-1">
                 <ItemStyle  Width="30%" />
                <ItemTemplate>
                    <div class="recipebackground">
                    <center><asp:Image ID="recipeimage" ImageUrl='<%# Eval("recipeimage") %>' Width="320px" Height="260px" runat="server" /></center><br />
                    <div class="namecenter">
                               <asp:LinkButton ID="recipename" Text='<%# Eval("recipename")%>' runat="server"></asp:LinkButton>
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
                           <div class="caloriesborder">
                                    <asp:Label ID="recipeproteinlabel"   Text="Calories:" runat="server"></asp:Label>
                                     <br />
                                    <asp:Label ID="recipeprotein" ForeColor="Red" Text='<%#Eval("recipecalories") %>' runat="server"></asp:Label>
                                   <asp:Label ID="unit" Text=" Kcal" runat="server"></asp:Label>
                            </div>
                            <div class="right" style="width:50%;background:white;font-size:1.2em;text-align:center;">
                                  <asp:Label ID="tailo" Text="Suitable for: " runat="server"></asp:Label>
                                <br />
                                 <asp:Label ID="tailormade" ForeColor="Red" Text='<%#Eval("recipemedicalcondition") %>' runat="server"></asp:Label>
                            </div>
                          </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>--%>
       
    </div>
</asp:Content>
