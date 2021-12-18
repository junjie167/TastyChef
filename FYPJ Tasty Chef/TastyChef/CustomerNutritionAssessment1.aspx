<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.Master" AutoEventWireup="true" CodeFile="CustomerNutritionAssessment1.aspx.cs" Inherits="TastyChef.CustomerNutritionAssessment1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="css/CustomerNutritionAssessment.css" rel="stylesheet" />
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
    font-size:1.3em;
    border-radius: 6px;
    padding: 8px 0;
    position: absolute;
    z-index: 1;
    bottom: 125%;
    left: -960%;
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
             font-family:Arial;
             Font-Size:1em;
             color:White;
             Height:50px;
             Width:125px;
  }
.right{
    float:right;
}
/*.margin-alignment{
    text-align:right;
}*/
.borderspace{
    border-spacing:20px 0;
    border-collapse:separate;
}


        .auto-style1 {
            height: 25px;
        }
        
        .hintimg{
            margin-bottom:13px;
        }

        .borderouter{
            border:2px solid #4DB6AC;
            border-radius:12px;
            width:100%;
            background-color:white;
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
             font-size:2.5em;
            font-weight:bold;
            font-family:Arial;
            display:inline-block;
        }

        .textbx{
            width:15%;
        }
        .texttb{
            width:50px;
        }
        .headd{
            color:#003366;
            text-align:center;
            font-size:3.5em;
            font-weight:bold;
        }
        Label{
            font-weight:normal;
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
        .textcenter{
            text-align:center;
        }

    </style>
    <script>
function ValidateCheckBoxList(sender, args) {
        var checkBoxList = document.getElementById("<%=allergies.ClientID %>");
        var checkboxes = checkBoxList.getElementsByTagName("input");
        var isValid = false;
        for (var i = 0; i < checkboxes.length; i++) {
            if (checkboxes[i].checked) {
                isValid = true;
                break;
            }
        }
        args.IsValid = isValid;
}
        function ValidateCheckBoxList2(sender, args) {
        var checkBoxList = document.getElementById("<%=avoid.ClientID %>");
        var checkboxes = checkBoxList.getElementsByTagName("input");
        var isValid = false;
        for (var i = 0; i < checkboxes.length; i++) {
            if (checkboxes[i].checked) {
                isValid = true;
                break;
            }
        }
        args.IsValid = isValid;
        }
        function ValidateCheckBoxList3(sender, args) {
        var checkBoxList = document.getElementById("<%=CBLMedicalCondition.ClientID %>");
        var checkboxes = checkBoxList.getElementsByTagName("input");
        var isValid = false;
        for (var i = 0; i < checkboxes.length; i++) {
            if (checkboxes[i].checked) {
                isValid = true;
                break;
            }
        }
        args.IsValid = isValid;
        }
         function ValidateCheckBoxList4(sender, args) {
             var radiobutton1 = document.getElementById("<%=sedentary.ClientID %>");
             var radiobutton2 = document.getElementById("<%=lightly.ClientID%>");
             var radiobutton3 = document.getElementById("<%=moderate.ClientID%>");
             var radiobutton4 = document.getElementById("<%=veryactive.ClientID%>");
             var radiobutton5 = document.getEleme5ntById("<%=extreme.ClientID%>");
       
             var isValid = false;
             if (radiobutton1.checked) {
                 isValid = true;
             } else {
                 args.IsValid = isValid;
             }
       
       
    }
    </script>
      <asp:ScriptManager EnablePartialRendering="true"
 ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="sub" />
        </Triggers>
        <ContentTemplate>
 
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
                              <asp:Label ID="labelre" CssClass="textcenter" Text="Updated Recommeded Recipes is ready for you." runat="server"></asp:Label>
                        </div>      
<%--                        <asp:Button ID="viewnp" CssClass="left addbutton" Text="View Nutrition Profile" runat="server" />--%>       
                    </div>
                      <asp:Button ID="viewrr" CssClass="w3-btn-block w3-green w3-section w3-padding"  Text="View Recommeneded Recipe" OnClick="viewrecommend_Clik" runat="server" />
                </div>
            </div>
        </div>
          <div class="loading" id="load" runat="server">
                      Re-Generating Recipe</br>
                      please wait
                       <br />
                    <img src="img/ajax-loader.gif"  />
            </div>
         <div class="step1" id="s1" runat="server">
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
        <div id="hrr" runat="server">
            <hr />
        </div>
        <br />
         <div class="headd">
             <asp:Label ID="Label12"  Text="Nutrition Assessment" runat="server"></asp:Label>
            </div>
          &nbsp;
            <div class="subtitle" id="subtitlehead" runat="server">
             <asp:Label ID="inforlbl" CssClass="contentfont" Text="Having better understanding about you is one of our jobs as to serve you better." runat="server"></asp:Label>
         </div>
        <br />
            <div class="borderouter">
                <div  class="borderhead">
                    <asp:Label ID="Label13" CssClass="titlee" Text="Anthropometric" runat="server"></asp:Label>
                        <div class="popup" onmouseover="myFunction()" >
                             <asp:Image ID="questionn" CssClass="hintimg" runat="server" ImageUrl="~/img/information.png" Width="26px" Height="26px" />
                         <span class="popuptext" id="myPopup">
                             Having to know your body height, body weight and activity level, we can help you to calculate your Body Mass Index and your daily calories intake.
                             The purpose of calculating is to better evaluate your current nutrition status.
                         </span>                            
                        </div>                 
                </div>
                <div class="content">
                <table class="borderspace" runat="server">
                    <tr>
                        <td style="width:260px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td >
                            <asp:RegularExpressionValidator ID="regsalary" ControlToValidate="height" ForeColor="Red" Text="*Must be positive numerical" ValidationExpression="^\d+$" SetFocusOnError="true" runat="server"></asp:RegularExpressionValidator>
                            <br />
                            <asp:Label ID="h"  Text="Height: " runat="server"></asp:Label>
                            <asp:TextBox ID="height" CssClass="texttb" runat="server"></asp:TextBox>cm  
                            <asp:RequiredFieldValidator ID="requirefield" ControlToValidate="height" ForeColor="Red" ErrorMessage="*" ValidationGroup="see" runat="server"></asp:RequiredFieldValidator>    
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="weight" ForeColor="Red" Text="*Must be positive numerical" ValidationExpression="^\d+$" SetFocusOnError="true" runat="server"></asp:RegularExpressionValidator>
                            <br />
                            <asp:Label ID="Label6" Text="Weight: " runat="server"></asp:Label>
                            <asp:TextBox ID="weight" CssClass="texttb" runat="server"></asp:TextBox>kg
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="weight" ForeColor="Red" ErrorMessage="*" ValidationGroup="see" runat="server"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                             <asp:Label ID="activity"  CssClass="margin-alignment" Text="Activity Level: " runat="server"></asp:Label>
                             <asp:CustomValidator ID="CustomValidator4" ErrorMessage="*" ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList4" runat="server" ValidationGroup="s" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
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
                                         <asp:RadioButton ID="sedentary"  GroupName="level" runat="server" />       
                                     </td>
                                     <td style="text-align:center">
                                         <asp:RadioButton ID="lightly" GroupName="level" runat="server" />
                                      </td>
                                      <td style="text-align:center">
                                         <asp:RadioButton ID="moderate" GroupName="level" runat="server" />
                                      </td>
                                      <td style="text-align:center">
                                         <asp:RadioButton ID="veryactive" GroupName="level" runat="server" />
                                      </td>
                                      <td style="text-align:center">
                                          <asp:RadioButton ID="extreme" GroupName="level" runat="server" />
                                      </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                    </div>
            </div>
            <br />
            <br />
            <div class="borderouter" >
                <div class="borderhead">
                    <asp:Label ID="Label28" CssClass="titlee" Text="Dietary Intake" runat="server"></asp:Label>
                      <div class="popup" onmouseover="myFunction1()" >
                             <asp:Image ID="Image1" CssClass="hintimg" runat="server" ImageUrl="~/img/information.png" Width="26px" Height="26px" />
                         <span class="popuptext" id="myPopup1">
                             Dietary assessment is an assessment to have a better understanding about your diet intake. You have to provide us the following information
                             as to better plan your meal or recommend recipe.
                      </span>                            
                     </div>
                </div>
                <div class="content">
                <table class="borderspace" runat="server">
                    <tr>
                        <td style="width:260px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="diet" Text="Diet Type: " runat="server"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="diettype" runat="server">
                                 <asp:ListItem>Please Select</asp:ListItem>
                                 <asp:ListItem>None</asp:ListItem>
                                 <asp:ListItem>Vegetarian</asp:ListItem>
                                 <asp:ListItem>Vegan</asp:ListItem> 
                                 <asp:ListItem>Atkins/Ketogenic</asp:ListItem>                       
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="diettype" InitialValue="Please Select" ForeColor="Red" ErrorMessage="*" ValidationGroup="see" runat="server"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="foodallergy" Text="Food Allergy: " runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:CustomValidator ID="CustomValidator1" ErrorMessage="*" ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList" runat="server" ValidationGroup="se" />
                            <asp:CheckBoxList ID="allergies" CssClass="fontweight" runat="server" RepeatDirection="Horizontal" DataTextField="allengyies"  CellPadding="5" CellSpacing="5" AutoPostBack="true" OnSelectedIndexChanged="allergies_SelectedIndexChanged" >
                                        <%--<asp:ListItem Text="Fish" Value="Fish" runat="server"></asp:ListItem>
                                        <asp:ListItem Text="Shellfish" Value="Shellfish" runat="server"></asp:ListItem>
                                        <asp:ListItem Text="Peanuts" Value="Peanuts" runat="server">Peanut</asp:ListItem>
                                        <asp:ListItem Text="Tree nuts" Value="Tree nuts" runat="server"></asp:ListItem>--%>
                             </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="foodavoid" Text="Food Avoidance: " runat="server"></asp:Label>
                        </td>
                        <td>
                             <asp:CustomValidator ID="CustomValidator2" ErrorMessage="*" ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList2" runat="server" ValidationGroup="se" />
                            <asp:CheckBoxList ID="avoid" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="avoid_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Text="None" Value="None" runat="server"></asp:ListItem>
                                        <asp:ListItem Text="Beef" Value="Beef" runat="server">Beef</asp:ListItem>
                                        <asp:ListItem>Cheese</asp:ListItem>
                                        <asp:ListItem>Mutton</asp:ListItem>
                                        <asp:ListItem>Onion</asp:ListItem>
                             </asp:CheckBoxList>
                            <asp:CheckBox ID="otherck" Text="Others" runat="server" OnCheckedChanged="otherck_CheckedChanged" AutoPostBack="true" />
                            <asp:TextBox ID="otheravoid" runat="server"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="otheravoid" ForeColor="Red" ErrorMessage="*" ValidationGroup="see" runat="server"></asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="regfname" ControlToValidate="otheravoid" ForeColor="Red" Text="*Must be in alphabetical" ValidationExpression="^[a-zA-Z''-'\s]{1,100}$" SetFocusOnError="true" runat="server"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="frequency" Text="Frequency of Meals per day: " runat="server"></asp:Label></td>
                        <td>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="mealfrequency" ForeColor="Red" Text="*Must be positive numerical" ValidationExpression="^\d+$" SetFocusOnError="true" runat="server"></asp:RegularExpressionValidator>
                            <br />
                            <asp:TextBox ID="mealfrequency" CssClass="textbx" runat="server"></asp:TextBox>times
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="mealfrequency" ForeColor="Red" ErrorMessage="*" ValidationGroup="see" runat="server"></asp:RequiredFieldValidator>    
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="freq" Text="Frequency of Snacks per day: " runat="server"></asp:Label></td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="snackfrequency" ForeColor="Red" Text="*Must be positive numerical" ValidationExpression="^\d+$" SetFocusOnError="true" runat="server"></asp:RegularExpressionValidator>
                            <br />
                            <asp:TextBox ID="snackfrequency" CssClass="textbx" runat="server"></asp:TextBox>times
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="snackfrequency" ForeColor="Red" ErrorMessage="*" ValidationGroup="see" runat="server"></asp:RequiredFieldValidator>    
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                    </div>
            </div>
            <br />
            <br />
            <div class="borderouter" id="db" runat="server">
                <div class="borderhead">
                    <asp:Label ID="Label30" CssClass="titlee" Text="Medical Condition (s)" runat="server"></asp:Label>
                    <div class="popup" onmouseover="myFunction2()" >
                     <asp:Image ID="Image2" CssClass="hintimg" runat="server" ImageUrl="~/img/information.png" Width="26px" Height="26px" />
                     <span class="popuptext" id="myPopup2">
                             Having to know your current medical condition is essential for us as it can help us better in recomending recipe to you
                             in accodance to your medical condition.
                     </span>                            
                     </div>
                </div>
                <div class="content">
                <table class="borderspace" runat="server">
                    <tr>
                        <td style="width:260px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="dm" Text="Diagnosed Medical Condition: " runat="server"></asp:Label>
                        </td>
                        <td>
                             <asp:CustomValidator ID="CustomValidator3" ErrorMessage="*" ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList3" runat="server" ValidationGroup="se" />
                            <asp:CheckBoxList ID="CBLMedicalCondition" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="CBLMedicalCondition_SelectedIndexChanged" >
                                <asp:ListItem Text="None" Value="None" runat="server"></asp:ListItem>
                                <asp:ListItem Text="Diabetes" Value="Diabetes" runat="server"></asp:ListItem>
                                <asp:ListItem Text="Hypertension" Value="Hypertension" runat="server"></asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="glu" Text="Glucose level: " runat="server"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="glucose" CssClass="textbx" runat="server"></asp:TextBox>
                            <asp:Label ID="unit" Text="mmol/L" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1"><asp:Label ID="gl" Text="Blood Pressure: " runat="server"></asp:Label></td>
                        <td class="auto-style1">
                            <asp:TextBox ID="bloodpressure" runat="server"></asp:TextBox>
                            <asp:Label ID="mmHg" Text="mmHg" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                    </div>
            </div>
            <br />
            <br />
        <div class="subtitle">
            <asp:Button ID="back" CssClass="addbutton" Text="Back" OnClick="back_click" runat="server" />
             <asp:Button ID="sub" CssClass="addbutton" Text="Continue" ValidationGroup="see"  runat="server" OnClick="sub_Click" />
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
function myFunction2() {
    var popup = document.getElementById("myPopup2");
    popup.classList.toggle("show");
}
</script>
                    </ContentTemplate>
                  </asp:UpdatePanel>
</asp:Content>
