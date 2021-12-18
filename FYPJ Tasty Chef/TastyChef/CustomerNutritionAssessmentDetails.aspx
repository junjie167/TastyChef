<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.Master" AutoEventWireup="true" CodeBehind="CustomerNutritionAssessmentDetails.aspx.cs" Inherits="TastyChef.CustomerNutritionAssessmentDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
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
                background-color:white;
                border-radius:20px;
                color:black;
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
                background-color:white;
                border-radius:20px;
                color:black;
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
         .headd{
              color:#003366;
            text-align:center;
            font-family: Arial;           
            font-weight:bold;
            font-size:3.5em; 
             clear:both;
         }
        .subtitle{
             text-align:center;
             clear:both;
         }
         .subheaddesign{
            color:#003366;
            font-family: Arial;
            font-weight:bold;
            font-size:2.5em;
         }
         .contentfont{
             font-family:Arial;
             font-size:1.3em;
         }
         .antropometricborder{
            border:2px solid #4DB6AC;
            border-radius:12px;
            background-color:white;
            font-family:Arial;
             margin:auto;
             float:left;
             width:30%;
             height:170px;
         }
         .medicalconditionborder{
            border:2px solid #4DB6AC;
            border-radius:12px;
            background-color:white;
            font-family:Arial;
             margin:auto;
             float:right;
             width:30%;
             height:170px;
         }
         .dietborder{
             border:2px solid #4DB6AC;
            border-radius:12px;
            background-color:white;
            font-family:Arial;
             margin:auto;
             width:30%;
             height:170px;
         }
          .borderhead{
            background-color:#4DB6AC;
            text-align:center;
            margin-top:0px;
            font-size:2.5em;
            color:#003366;
            font-family:Arial;
            font-weight:bold;
            border-top-left-radius:10px;
            border-top-right-radius:10px;
        }
       .padding{
               padding-left:20px;
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
          .backgroundcolor{
              background-color:white;
          }
    </style>
    <div class="container">
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
            <asp:Label ID="headlbl" Text="Nutrition Assessment" runat="server"></asp:Label>
        </div>
        &nbsp;
        <asp:PlaceHolder ID="startedholder" runat="server">
         <div class="subtitle">
             <asp:Label ID="enteremaillbl" CssClass="subheaddesign" Text="Get Started !" runat="server"></asp:Label>
             <br />
             <asp:Label ID="inforlbl" CssClass="contentfont" Text="Record your nutrition assessment to recommend recipes just for you!" runat="server"></asp:Label>
         </div>
        <br />
        <div class="antropometricborder">
             <div class="borderhead">
                   <asp:Label ID="antolbl" Text="Antropometric" runat="server"></asp:Label>
            </div>
            <br />
            <div class="padding">
                <div class="contentfont">
                     It is the measurement of our body height and weight based on age and gender for calculation of BMI.
                </div>
            </div>
        </div>
        <div class="medicalconditionborder">
            <div class="borderhead">
                <asp:Label ID="melbl" Text="Medical Condition" runat="server"></asp:Label>
            </div>
            <br />
            <div class="padding">
                <div class="contentfont">
                    It is evaluation of an individual's health status.
                </div>
            </div>
        </div>
        <div class="dietborder">
            <div class="borderhead">
                <asp:Label ID="dielbl" Text="Dietary Intake" runat="server"></asp:Label>
            </div>
            <br />
            <div class="padding">
                <div class="contentfont">
                    It is refer to the daily eating patterns of an individual, inclucding diet type, food allergies and food avoidance.
                </div>
            </div>
        </div>
        <br />
         <div class="subtitle">
             <asp:Button ID="Button1" CssClass="addbutton" Text="Proceed to Nutrition Assessment" OnClick="continue_click"  runat="server" />
         </div>
        </asp:PlaceHolder>
    </div>
</asp:Content>
