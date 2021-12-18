<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.Master" AutoEventWireup="true" CodeBehind="CustomerNutritionProfile.aspx.cs" Inherits="TastyChef.CustomerNutritionProfile" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
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
        .borderouter{
            border:2px solid #4DB6AC;
            border-radius:12px;
            width:100%;
            background-color:white;
            font-family:Arial;
        }

         h1{
             color:#003366;
            text-align:center;
            font-family: Arial;
            font-size:4.5em;
        }
        .borderhead{
            background-color:#4DB6AC;
            text-align:center;
            margin-top:0px;
            border-top-left-radius:10px;
            border-top-right-radius:10px;
        }
        .titlee{
            color:#003366;
            font-weight:bold;
            font-size:2.5em;
            display:inline-block;
        }
        .macros{
            border:2px solid #4DB6AC;
            border-radius:12px;
            height:420px;
            background-color:white;
        }
        
        .recommendborder{
             border:2px solid #4DB6AC;
            border-radius:12px;
            width:50%;
            margin-top:180px;
            background-color:white;
        }
        .chartt{
            width:100%;
        }

        .e{
            background:#4DB6AC;
             border-color:White;
             border:Solid;
             font-weight:bold;
             font-family:Arial;
             Font-Size:1.3em;
             color:White;
             Height:50px;
             Width:100%;
             border-radius:10px;
        }
        .table3{
            margin-left:24px;
            font-family:Arial;
            font-size:1.3em;
        }
        .table1{
            margin-left:24px;
        }
        /*.table1 td{
            width:25%;
        }*/
        h4{
            text-decoration:underline;
            font-weight:bold;
        }
@media (min-width: 768px) {
  .table1{
       margin-left:200px;
       margin-right:200px;
  }
}
@media (min-width: 768px) {
  .table1{
       margin-left:200px;
       margin-right:200px;
  }
  .e{
      margin-top:35px;
  }
}
@media (min-width: 768px) {
  .table3{
       padding:18px;
       padding-top:15px
  }
  .macros{
      float:left;
      width:50%;
  }
  .macroschart{
            width:50%;
            float:right;
        }
}
.right{
    float:right;
}
.left{
    float:left;
}
.setwidth{
    width:50%;
}
    .popup {
    position: relative;
    display: inline-block;
    cursor: pointer;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
}

/* The actual popup */
.popup .popuptext {
    visibility: hidden;
    width: 478px;
    background-color: #4DB6AC;
    color: #fff;
    border-radius: 6px;
    padding: 8px 0;
    position: absolute;
    z-index: 1;
    bottom: 125%;
    left: 50%;
    margin-left: -345px;
}

/* Popup arrow */
.popup .popuptext::after {
    content: "";
    position: absolute;
    top: 100%;
    left: 50%;
    margin-left: -5px;
    border-width: 5px;
    border-style: solid;
    border-color: #555 transparent transparent transparent;
}

/* Toggle this class - hide and show the popup */
.popup .show {
    visibility: visible;
    -webkit-animation: fadeIn 1s;
    animation: fadeIn 1s;
}

/* Add animation (fade in the popup) */
@-webkit-keyframes fadeIn {
    from {opacity: 0;} 
    to {opacity: 1;}
}

@keyframes fadeIn {
    from {opacity: 0;}
    to {opacity:1 ;}
}
 .hintimg{
            margin-bottom:13px;
        }
        .auto-style1 {
            height: 23px;
        }
    </style>


        <div class="container">
             <div class="headd">
                 <asp:Label ID="label2" Text="Nutrition Profile" runat="server"></asp:Label>
            </div>
             &nbsp;
             &nbsp;
            <div class="content">
                <div class="macros">
                    <div class="borderhead">
                        <asp:Label ID="Label3" CssClass="titlee" Text="Macronutrients" runat="server"></asp:Label>
                              <div class="popup" onmouseover="myFunction()" >
                             <asp:Image ID="questionn" CssClass="hintimg" runat="server" ImageUrl="~/img/information.png" Width="26px" Height="26px" />
                         <span class="popuptext" id="myPopup">
                             Having to know your body height, body weight and activity level, we can help you to calculate your Body Mass Index and your daily calories intake.
                             The purpose of calculating is to better evaluate your current nutrition status.
                         </span>                            
                         </div>  
                    </div>
                    <div class="table3">
                         <table>
                                 <tr style="height:75px;">
                            <td style="width:230px;"><asp:Label ID="Label5" Text="Recommended " runat="server" Font-Bold="True" Font-Underline="True"></asp:Label></td>
                            <td >
                            </td>
                        </tr>
                        <tr>
                            <td style="width:230px;"><asp:Label ID="ca" Text="Daily Calories intake: " runat="server" Font-Bold="True"></asp:Label></td>
                            <td ><asp:Label ID="calories" Text="" runat="server"></asp:Label>
                                                      <asp:Label ID="label1" Text="Kcal" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1"><asp:Label ID="pro" Text="Daily Proteins: " runat="server" Font-Bold="True"></asp:Label></td>
                            <td class="auto-style1"><asp:Label ID="protein" Text="" runat="server"></asp:Label>
                                <asp:Label ID="protei" Text="gram" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Fa" Text="Daily Fats: " runat="server" Font-Bold="True"></asp:Label></td>
                            <td><asp:Label ID="fats" Text="" runat="server"></asp:Label>
                                <asp:Label ID="f" Text="gram" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="carb" Text="Daily Carbohydrates: " runat="server" Font-Bold="True"></asp:Label></td>
                            <td><asp:Label ID="carbohydrate" Text="" runat="server"></asp:Label>
                                <asp:Label ID="c" Text="gram" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    </div>
                   
                </div>
                <div class="macroschart">
                    <div style="text-align:center;margin-right:-25px;">
                        <asp:Label ID="Label4" CssClass="titlee" Text="Daily Percentage Intake" runat="server"></asp:Label>
                    </div>                 
                    <asp:Chart ID="Chart1" Height="400px" Width="600px" runat="server" BackColor="#FFF3EA" BackImageTransparentColor="#FFF3EA" BorderlineColor="Transparent" EnableViewState="True">
                        <Titles>
                            <%--<asp:Title Text="Macronutrient Percentage" BackColor="GhostWhite" Font="Arial, 18.72px, style=Bold" ForeColor="#003366"></asp:Title>--%>
                        </Titles>
                        <BorderSkin BackColor="Transparent" PageColor="#FFF3EA"/>
                        <Series>
                            <asp:Series ChartType="Pie" Name="ChartArea1"  IsValueShownAsLabel="true" Label="#PERCENT{P0}"  Font="Arial, 20px">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BackColor="#FFF3EA" Area3DStyle-Enable3D="true" Area3DStyle-Inclination="10" Area3DStyle-IsClustered="false">
                                <Area3DStyle Enable3D="true" Inclination="10" />
                            </asp:ChartArea>
                        </ChartAreas>
                        <Legends>
                            <asp:Legend Alignment="center" BackColor="#FFF3EA" LegendStyle="Row" Name="Default" Docking="bottom" Font="Arial , 17px"  IsTextAutoFit="False"></asp:Legend> 
                        </Legends>
                    </asp:Chart>
                    
                </div>
                <br />
                <br />
                <div class="setwidth">
                    <asp:Button ID="printpdf"  CssClass="e left" Text="Download As PDF" runat="server" OnClientClick="return true;" OnClick="downloadpdf_Click"></asp:Button>
                </div> 
            </div>
        </div>

<script>
    // When the user clicks on div, open the popup
    function myFunction() {
        var popup = document.getElementById("myPopup");
        popup.classList.toggle("show");
    }
    function myFunction1() {
        var popup = document.getElementById("myPopup1");
        popup.classList.toggle("show");
    }
</script>
 </asp:Content>
