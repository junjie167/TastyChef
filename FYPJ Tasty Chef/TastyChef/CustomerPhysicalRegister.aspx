<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.Master" AutoEventWireup="true" CodeBehind="CustomerPhysicalRegister.aspx.cs" Inherits="TastyChef.CustomerPhysicalRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/CustomerNutritionAssessment.css" rel="stylesheet" />
<%--     <link href="css/CustomerRegistration.css" rel="stylesheet" />--%>
    <style>
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
    margin-left: -80px;
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

.e{
            background:#4DB6AC;
             border-color:White;
             border:Solid;
             font-weight:bold;
             font-family:Harrington;
             Font-Size:x-large;
             color:White;
             Height:50px;
             Width:125px;
  }

.imaggg{
    width:150px;
    display:inline;
}
    </style>
        <div class="container">
              <div class="headd">
                <h1>Nutrition Assessment</h1>
            </div>
             &nbsp;
             &nbsp;
            <div class="progressb">
                <nav>
                    <ul class="progressbar">
                        <li class="actived">Physical Profile</li>
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
                         <th><h2>Physical Profile</h2></th>
                     </tr>
                       <tr>
                <td>&nbsp;</td>
            </tr>
                     <tr>
                         <td><asp:Label ID="h" Text="Height" runat="server"></asp:Label></td>
                         <td><asp:TextBox ID="height" runat="server"></asp:TextBox>cm</td>
                     </tr>
                     <tr>
                         <td>&nbsp;</td>
                     </tr>
                     <tr>
                         <td><asp:Label ID="w" Text="Weight: " runat="server"></asp:Label></td>
                         <td><asp:TextBox ID="weight" runat="server"></asp:TextBox>kg</td>
                     </tr>
                     <tr>
                         <td>&nbsp;</td>
                     </tr>
                     <tr>
                         <td>
                         <div class="popup" onmouseover="myFunction()" >
                             <asp:Image ID="questionn" runat="server" ImageUrl="~/img/questionmark.png" Width="26px" Height="26px" />
                         <span class="popuptext" id="myPopup">Sedentary: Little or no exercise.<br />
                             Lightly Active: Light exercise/sports 1-3 days per week.<br />
                             Moderately Active: Moderate exercise/sports 6-7 days per week.<br />
                             Very Active: Hard exercise every day or exercise 2 times a day.<br />
                             Extra Active: Hard exercise 2 or more times per day.
                         </span>
                             
                         </div>
                             <asp:Label ID="activity" Text="Activity Level: " runat="server" ></asp:Label></td>
                     
                             <td>
                                 <table>
                                     <tr>
                                         <td style="text-align:center;"> <img src="img/sedantary.png" alt="img2"  style="width:150px;"/></td>
                                          <td style="text-align:center;"><img src="img/lightlyactive.png" alt="img2"  style="width:150px;"/></td>
                                          <td style="text-align:center;"><img src="img/walk.png" alt="img2"  style="width:150px;"/></td>
                                         <td style="text-align:center;"><img src="img/running.png" alt="img2"  style="width:150px;"/></td>
                                         <td style="text-align:center;"><img src="img/extremactive.png" alt="img2"  style="width:150px;"/></td>
                                     </tr>
                                     <tr>
                                         <td style="text-align:center;"><asp:Label ID="label1" Text="Little or no exercise." runat="server"></asp:Label></td>
                                         <td style="text-align:center;"><asp:Label ID="label2" Text="Light exercise/sports 1 to 3 days per week." runat="server"></asp:Label></td>
                                         <td style="text-align:center;"><asp:Label ID="label3" Text="Moderate exercise/sports 6 to 7 days per week." runat="server"></asp:Label></td>
                                         <td style="text-align:center;"><asp:Label ID="label4" Text="Hard exercise every day or exercise 2 times a day." runat="server"></asp:Label></td>
                                         <td style="text-align:center;"><asp:Label ID="label5" Text="Hard exercise 2 or more times per day." runat="server"></asp:Label></td>
                                     </tr>
                                     <tr>
                                         <td style="text-align:center">
                                         <asp:RadioButton ID="sedentary" runat="server" />       
                                         </td>
                                         <td style="text-align:center">
                                             <asp:RadioButton ID="lightly" runat="server" />
                                         </td>
                                         <td style="text-align:center">
                                             <asp:RadioButton ID="moderate" runat="server" />
                                         </td>
                                         <td style="text-align:center">
                                             <asp:RadioButton ID="vertactive" runat="server" />
                                         </td>
                                         <td style="text-align:center">
                                             <asp:RadioButton ID="extreme" runat="server" />
                                         </td>
                                     </tr>
                                 </table>
                             </td>
                     </tr>
                       <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
                     <tr>
                         <td><asp:Button ID="Next" CssClass="e" Text="Next" runat="server" OnClick="Next_Click" /></td>
                     </tr>
                 </table>
                 </div>          
        </div>
    <script>
// When the user clicks on div, open the popup
function myFunction() {
    var popup = document.getElementById("myPopup");
    popup.classList.toggle("show");
}
</script>
</asp:Content>
