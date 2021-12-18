<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.Master" AutoEventWireup="true" CodeBehind="CustomerNutritionAssessementAfter.aspx.cs" Inherits="TastyChef.CustomerNutritionAssessementAfter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="css/CustomerLogin.css" rel="stylesheet" />
    <style>
         .headd{
            color:#003366;
            text-align:center;
            font-size:3.5em;
            font-weight:bold;
        }
          .borderhead{
            background-color:#4DB6AC;
            text-align:center;
            margin-top:0px;
            border-top-left-radius:10px;
            border-top-right-radius:10px;
        }
          .titlee{
          font-size:2.5em;
            color:#003366;
            font-weight:bold;
            font-family:Arial;
            display:inline-block;
        }
          .title2design{
              font-size:2.5em;
            color:white;
            font-weight:bold;
            display:inline-block;
          }
          .antropometricborder{
            border:2px solid #4DB6AC;
            border-radius:12px;
            background-color:white;
            font-family:Arial;
             margin:auto;
         }
           .dietaryborder{
              border:2px solid #4DB6AC;
            border-radius:12px;
            background-color:white;
            font-family:Arial;
         }
         .medicalborder{
             border:2px solid #4DB6AC;
            border-radius:12px;
            background-color:white;
            font-family:Arial;

         }
           .content{
             font-size:1.3em;
             font-family:Arial;
             padding-left:80px;
         }
           .rigth{
               float:right;
               width:45%;
               margin-top:60px;
           }
           .left{
               float:left;
           }
           .addbutton{
             background:#4DB6AC;
             border-color:White;
             border:Solid;
             border-radius:10px;
             font-weight:bold;
             font-family:Arial;
             Font-Size:1.3em;
             color:White;
             Height:50px;
             Width:auto;
             margin:5px;
         }
           .loading {
            position: fixed;
            left: 595px;
            top: 350px;
            width: 20%;
            height: 20%;
            z-index: 9999;     
        font-family: Arial;
        font-size: 1.3em;
        z-index: 999;
        text-align:center;
        background-color:white;
        border:2px solid #4DB6AC;
        }
           .textcenter{
               text-align:center;
           }
           .contents{
               font-size:1.3em;
             font-family:Arial;
           }
           .w3-modal{
               top:100px;
           }
           .w3-center{
               background-color:#4DB6AC;
           }
            .w3-green{
            background-color:#4DB6AC;
        }
        .w3-section{
            font-size:1.3em;
            font-family:Arial;
        }
        .w3-light-grey{
             font-size:1.3em;
            font-family:Arial;
        }
        .branddesign{
           font-family:"Kaushan Script","Helvetica Neue",Helvetica,Arial,cursive;
           color:white;
           font-size:3.5em;
       }
        .backdesgin{
            width:45%;
        }
        .generatedesign{
            width:50%;
        }
        .step1{
                border:2px solid #4DB6AC;
                border-radius:20px;
                background-color:#4DB6AC;
                color:white;
                font-size:1.3em;
                font-family:Arial;
                text-align:center;
                width:20%;
                z-index: 3;
               position: relative;
            }
          .step2{
                 border:2px solid #4DB6AC;
                  background-color:#4DB6AC;
                border-radius:20px;
                color:white;
                font-size:1.3em;
                font-family:Arial;
                text-align:center;
                width:20%;
                z-index: 3;
                top:-55px;
                left:455px;
                 position: relative;
            }
          .step3{
                border:2px solid #4DB6AC;
                background-color:#4DB6AC;
                border-radius:20px;
                color:white;
                font-size:1.3em;
                font-family:Arial;
                text-align:center;
                width:20%;
                z-index: 3;
                top:-110px;
                left:915px;
                 position: relative;
            }
            hr{
                color:#4DB6AC;
                z-index: -1;
                margin-top: -136px;
                position: static;
            }
                .subtitle{
             text-align:center;
             clear:both;
         }
              .contentfont{
             font-family:Arial;
             font-size:1.3em;
         }
              .subheaddesign{
            color:#003366;
            font-family: Arial;
            font-weight:bold;
            font-size:2.5em;
         }
          @media (min-width: 768px) {
        .antropometricborder{
            width:50%;
            float:left;
            }
        .dietaryborder{
            width:45%;
            float:right;
        }
          .medicalborder{
              width:50%;
              float:left;
              margin-top:20px;
          }
         }
    </style>
      <script>
        //$(window).load(function () {
        //    $(".loader").fadeOut("slow");
        //})
    </script>
    <div class="container">
        <div id="id01" class="w3-modal" runat="server">
            <div class="w3-modal-content w3-card-8 w3-animate-zoom" style="max-width: 600px">
                <div class="w3-center">
                    <br />
                    <asp:Label ID="brand" CssClass="w3-margin-top w3-circle branddesign" Text="Tasty Chef" runat="server"></asp:Label>
                    <br />
                    &nbsp; 
                </div>
                <div class="w3-container" runat="server">
                    <div class="w3-section">
                        <div class="textcenter">
                              <asp:Label ID="labelre" CssClass="textcenter" Text="Recommeded Recipe is ready for you." runat="server"></asp:Label>
                        </div>      
<%--                        <asp:Button ID="viewnp" CssClass="left addbutton" Text="View Nutrition Profile" runat="server" />--%>       
                         <asp:Button ID="viewrr" CssClass="w3-btn-block w3-green w3-section w3-padding"  Text="View Recommeneded Recipe" OnClick="viewrecommend_Clik" runat="server" />
                    </div>
                </div>
            </div>
        </div>
          <div class="loading" id="load" runat="server">
                      Generating please wait
                       <br />
                    <img src="img/ajax-loader.gif"  />
            </div>
           <div class="step1">
                    Step 1<br />
                    Get Started
        </div>
         <div class="step2" id="s2" runat="server">
                    Step 2<br />
                    Nutrition Assessment
         </div>
         <div class="step3" id="s3" runat="server">
                      Step 3<br />
                    Confirmation
         </div>
        <hr />
        <br />
    <div class="headd">
        <asp:Label ID="Label1" Text="Nutrition Assessment" runat="server"></asp:Label>
    </div>
     &nbsp;
      <div class="subtitle">
             <asp:Label ID="enteremaillbl" CssClass="subheaddesign" Text="Confirmation" runat="server"></asp:Label>
             <br />
             <asp:Label ID="inforlbl" CssClass="contentfont" Text="Our Recommended Recipes will be ready!" runat="server"></asp:Label>
         </div>
        <br />
    <div class="antropometricborder">
             <div class="borderhead">
                 <asp:Label ID="Label4" CssClass="titlee" Text="Anthropometric" runat="server"></asp:Label>
            </div>
            <div class="content">
             <table>
                <tr>
                    <td style="width:187px;">&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="he" Text="Height: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="height" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="we" Text="Weight: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="weight" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="ac" Text="Activity Level: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="activity" runat="server"></asp:Label></td>
                </tr>
                <tr>

                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="bm" Text="BMI: " runat="server"></asp:Label></td>
                    <td>
                        <asp:Label ID="bmi" runat="server"></asp:Label>
                        &nbsp;
                        <asp:Label ID="risk" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="wee" Text="Weight Status: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="weightstatus" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                 </table>
                </div>
        </div>
        <div class="dietaryborder">
                 <div class="borderhead">
                     <asp:Label ID="Label5" Text="Dietary Intake" CssClass="titlee" runat="server"></asp:Label>
            </div>
                <div class="content">
                <table>
                      <tr>
                    <td style="width:187px;">&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="die" Text="Diet Type: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="diet" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="all" Text="Food Allergy: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="allergy" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="av" Text="Food Avoidance: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="avoid" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="me" Text="Meal Frequency: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="meal" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="sn" Text="Snack Frequency: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="snack" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                </table>
                    </div>
            </div>
        <br />
        <div class="medicalborder">
                  <div class="borderhead">
                      <asp:Label ID="Label6" Text="Medical Condition (S)" CssClass="titlee" runat="server"></asp:Label>
            </div>
                <div class="content">
                <table>
                     <tr>
                    <td style="width:187px;">&nbsp;</td>
                </tr>
                      <tr>
                    <td><asp:Label ID="medi" Text="Medical Condition: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="medical" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="glu" Text="Glucose Level: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="glucose" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                </table>
                    </div>
            </div>
        <br />
        <br />
        <br />
        <div class="subtitle">
                    <asp:Button ID="back" CssClass="addbutton backdesgin" Text="Back" runat="server" OnClick="back_Click" />
                    <asp:Button ID="btnSubmit" CssClass="addbutton generatedesign" Text="Generate Recipe" runat="server" OnClick="generate_Click" />
        </div>
        </div>
</asp:Content>
