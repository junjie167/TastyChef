<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerHomeMasterPage.Master" AutoEventWireup="true" CodeBehind="CustomerRegistration.aspx.cs" Inherits="TastyChef.CustomerRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <script>
<!--
$(document).ready(function () {
    $("button").on('click', function () {
        var address = document.getElementById('<%= Postalcode.ClientID %>').value;
		$.ajax({
			url:		'http://gothere.sg/maps/geo',
			dataType:	'jsonp',
			data:		{
				'output'	: 'json',
				'q'			: address,
				'client'	: '',
				'sensor'	: false
			},
			type:	'GET',
			success: function(data) {
				var myString = "";
				
				var status = data.Status;
				
				
				if (status.code == 200) {					
					for (var i = 0; i < data.Placemark.length; i++) {
						var placemark = data.Placemark[i];
						var status = data.Status[i];
						
						myString += placemark.AddressDetails.Country.Thoroughfare.ThoroughfareName + "\n";
						
					}
					
					document.getElementById('<%= add.ClientID %>').innerText = myString;
				    document.getElementById("<%=hfName.ClientID %>").value = document.getElementById('<%= add.ClientID %>').innerText;
				} else if (status.code == 603) {
				    document.getElementById('<%= add.ClientID %>').innerText = "No Record Found";
                     document.getElementById("<%=hfName.ClientID %>").value = document.getElementById('<%= add.ClientID %>').innerText;
				}

			},
			statusCode: {
				404: function() {
					alert('Page not found');
				}
			},
		});
		
		return false;
	});
});
// -->
</script>

<%--     <link href="css/CustomerRegistration.css" rel="stylesheet" />--%>
    <style>
        .floatleft{
            float:left;
        }
         .headd{
              color:#003366;
            text-align:center;
            font-family: Arial;           
            font-weight:bold;
            font-size:3.5em; 
             clear:both;
             margin-top:18px;
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
         .subtitle{
             text-align:center;
             clear:both;
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
           .padding{
               padding-left:224px;
           }
            .borderhead{
            background-color:#4DB6AC;
            text-align:center;
            margin-top:0px;
            font-size:1.3em;
            color:#003366;
            font-family:Arial;
            font-weight:bold;
            border-top-left-radius:10px;
            border-top-right-radius:10px;
        }
            .borderouter1{
                border:2px solid #4DB6AC;
            border-radius:12px;
            background-color:white;
            font-family:Arial;
             margin:auto;
             float:left;
             width:30%;
            }
            .borderouter2{
                   border:2px solid #4DB6AC;
            border-radius:12px;
            background-color:white;
            font-family:Arial;
             margin:auto;
             width:30%;
            }
            .borderouter3{
                   border:2px solid #4DB6AC;
            border-radius:12px;
            background-color:white;
            font-family:Arial;
             margin:auto;
             float:right;
             width:30%;
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
            .step4{
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
                left:915px;
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
                top:-110px;
                left:300px;
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
                top:-165px;
                left:610px;
                 position: relative;
            }
            hr{
                color:#4DB6AC;
                z-index: -1;
                margin-top: -190px;
                position: static;
            }
            .backgroundcolor{
                background-color:white;
            }
             .loading {
            position: fixed;
            left: 620px;
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
               top:50px;
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
        Label{
            font-weight:normal;
        }
        .width{
            width:330px;
        }
    </style>
    <script>
        function Passstrength() {
            var pass = document.getElementById('<%= password.ClientID %>').value;
            var num = pass.length;
            if ( num < 4) {
                document.getElementById('<%= passstrength.ClientID %>').innerText = "Strength: Weak";
            } else if (num >= 4 && num < 6) {
                document.getElementById('<%= passstrength.ClientID %>').innerText = "Strength: Moderate";
            } else {
                document.getElementById('<%= passstrength.ClientID %>').innerText = "Strength: Strong";
            }
        }
    </script>
    <section>
        <div  class="container">
             <div id="id02" class="w3-modal" runat="server">
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
                              <asp:Label ID="labelre" CssClass="textcenter" Text="You have successfully create an account" runat="server"></asp:Label>
                        </div>
                    </div>
                        <asp:Button ID="viewrr" CssClass="w3-btn-block w3-green w3-section w3-padding"  Text="Login" OnClick="login_click"  runat="server" /> 
                        <asp:Button ID="Button3" CssClass="w3-btn-block w3-green w3-section w3-padding"  Text="Home"  runat="server" />      
                </div>
            </div>
        </div>
            <div class="floatright">
              
                 <div class="step1">
                    Step 1<br />
                    Email
                </div>
                 <div class="step4" id="s4" runat="server">
                    Step 4<br />
                    Confirmation 
                </div>
                <div class="step2" id="s2" runat="server">
                    Step 2<br />
                    Personal Information
                </div>
                <div class="step3" id="s3" runat="server">
                      Step 3<br />
                    Delivery Information
                </div>
                <hr />
                <br />
                 <div class="headd">
                     <asp:Label ID="headlbl" Text="Registration" runat="server"></asp:Label>
            </div>
             &nbsp;
            <div class="content">
                <div class="loading" id="load" runat="server">
                      Creating Account<br />
                        please wait
                       <br />
                    <img src="img/ajax-loader.gif"  />
                    </div>
                <asp:PlaceHolder ID="emailholder" runat="server">
                    <div class="backgroundcolor">
                    <div class="subtitle">
                        <asp:Label ID="enteremaillbl" CssClass="subheaddesign" Text="Enter Your Email Address" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="inforlbl" CssClass="contentfont" Text="Enjoy Fresh, Pre-Prepared Ingredients and chef recipes delivery right to your doorstep!" runat="server"></asp:Label>
                    </div>
                    <br />
                    <div class="padding">
                    <asp:Label ID="emaillbl" CssClass="contentfont" Text="Email Address: " runat="server"></asp:Label>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="*" ForeColor="Red" runat="server" ControlToValidate="email" ValidationGroup="ss"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regEmail" ControlToValidate="email" Text="*Invalid email formated" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" runat="server" SetFocusOnError="True"></asp:RegularExpressionValidator>
                    <br />
                    <asp:TextBox ID="email" CssClass="contentfont" placeholder="Email Address" runat="server"></asp:TextBox>
                    &nbsp;
                     <asp:Label ID="emailerror"  ForeColor="Red" Visible="false" runat="server" ></asp:Label>                
                    <asp:Button ID="continue" CssClass="addbutton" Text="Continue" OnClick="continue_Click" ValidationGroup="ss" runat="server" />
                    </div>
                    </div>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="personalholder" runat="server">
                    <div class="backgroundcolor">
                    <div class="subtitle">
                        <asp:Label ID="Label1" CssClass="subheaddesign" Text="Enter Your Personal Information" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label2" CssClass="contentfont" Text="Your Personal Information let us know you better!" runat="server"></asp:Label>
                    </div>
                    <br />
                    <div class="padding">
                    <table >
                         <tr>
                <td style="width:257px;">&nbsp;</td>
            </tr>
            <tr>
                <td><asp:Label ID="fname"  CssClass="contentfont" Text="First Name: " runat="server"></asp:Label></td>
                <td><asp:TextBox  CssClass="contentfont" ID="firstname" placeholder="First Name" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="require1" ErrorMessage="*" ForeColor="Red" runat="server" ControlToValidate="firstname" ValidationGroup="se"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regfname" ControlToValidate="firstname" ForeColor="Red" Text="*Must be in alphabetical" ValidationExpression="^[a-zA-Z''-'\s]{1,100}$" SetFocusOnError="true" runat="server"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><asp:Label ID="lname"  CssClass="contentfont" Text="Last Name: " runat="server"></asp:Label></td>
                <td><asp:TextBox ID="lastname"  CssClass="contentfont" placeholder="Last Name" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="*" ForeColor="Red" runat="server" ControlToValidate="lastname" ValidationGroup="se"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="reglname" ControlToValidate="lastname" ForeColor="Red" Text="*Must be in alphabetical" ValidationExpression="^[a-zA-Z''-'\s]{1,100}$" SetFocusOnError="true" runat="server"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><asp:Label ID="gen"  CssClass="contentfont width"  Text="Gender: " runat="server"></asp:Label></td>
                <td>
                    <asp:RadioButtonList ID="gender"  CssClass="contentfont" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem>Male</asp:ListItem>
                                            <asp:ListItem>Female</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="*" ForeColor="Red" runat="server" ControlToValidate="gender" ValidationGroup="se"></asp:RequiredFieldValidator>  
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><asp:Label ID="dateofbirth"  CssClass="contentfont" Text="Date of Birth: " runat="server"></asp:Label></td>
                <td><asp:TextBox ID="DOB"  CssClass="contentfont" placeholder="(dd/mm/yyyy)" runat="server" ></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="*" ForeColor="Red" runat="server" ControlToValidate="DOB" ValidationGroup="se"></asp:RequiredFieldValidator>
                     <asp:RangeValidator ID="regDOB" ControlToValidate="DOB" Text="*Must not be in future date and according to the formate given" ForeColor="Red" SetFocusOnError="true" Type="Date" runat="server" MinimumValue="01/01/1920"></asp:RangeValidator>
                </td>      
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><asp:Label ID="mn"  CssClass="contentfont" Text="Mobile Number: " runat="server"></asp:Label></td>
                <td><asp:TextBox ID="mobilenumber"  CssClass="contentfont" placeholder="Mobile Number" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="*" ForeColor="Red" runat="server" ControlToValidate="mobilenumber" ValidationGroup="se"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regmobile" ForeColor="Red" ControlToValidate="mobilenumber" Text="*Invalid Phone Number" ValidationExpression="^[89]\d{7}$" SetFocusOnError="true" runat="server"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><asp:Label ID="hm"  CssClass="contentfont" Text="House Number: " runat="server"></asp:Label></td>
                <td><asp:TextBox ID="housenumber"  CssClass="contentfont" placeholder="House Number" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="reghome" ForeColor="Red" ControlToValidate="housenumber" Text="*Invalid Home Number" ValidationExpression="^[6]\d{7}$" SetFocusOnError="true" runat="server"></asp:RegularExpressionValidator>
                </td>
            </tr>
                         <tr>
                <td>&nbsp;</td>
            </tr>
                        <tr>
                <td><asp:Label ID="pass" CssClass="contentfont" Text="Password: " runat="server"></asp:Label></td>
                <td><asp:TextBox ID="password" CssClass="contentfont" placeholder="Password" TextMode="Password"  runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ErrorMessage="*" ForeColor="Red" runat="server" ControlToValidate="password" ValidationGroup="se"></asp:RequiredFieldValidator>
                    <asp:Label ID="passstrength" ForeColor="Red" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><asp:Label ID="retype" CssClass="contentfont" Text="Retype Password: " runat="server"></asp:Label></td>
                <td><asp:TextBox ID="retypePass" CssClass="contentfont" placeholder="Retype Password" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ErrorMessage="*" ForeColor="Red" runat="server" ControlToValidate="retypePass" ValidationGroup="se"></asp:RequiredFieldValidator>
                    <asp:Label ID="retypeerror" ForeColor="Red" Visible="false" runat="server"></asp:Label>
                </td>
            </tr> 
                    </table>
                        </div>
                    <br />
                    <div class="subtitle">
                    <asp:Button ID="back1" CssClass="addbutton" Text="Back" OnClick="back_Click" runat="server" />
                    <asp:Button ID="continue2" CssClass="addbutton" Text="Continue" OnClick="continue2_Click" ValidationGroup="se" runat="server" />
                    </div>
                        </div>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="deliveryholder" runat="server">
                    <div class="backgroundcolor">
                     <div class="subtitle">
                        <asp:Label ID="Label3" CssClass="subheaddesign" Text="Enter Your Billing Address" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label4" CssClass="contentfont" Text="Our Ingredients are deliveried in boxes so food stay fresh when its arrives." runat="server"></asp:Label>
                    </div>
                    <br />
                    <div class="padding">
                        <table>
                            <tr>
                <td><asp:Label ID="pc" CssClass="contentfont" Text="Postal Code: " runat="server"></asp:Label></td>
                <td><asp:TextBox ID="Postalcode" CssClass="contentfont" placeholder="Postal Code" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ErrorMessage="*" ForeColor="Red" runat="server" ControlToValidate="PostalCode" ValidationGroup="sss"></asp:RequiredFieldValidator>
                    <button class="addbutton">Get Address</button></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><asp:Label ID="address" CssClass="contentfont" Text="Delivery Address: " runat="server"></asp:Label></td>
                <td><asp:Label ID="add" CssClass="contentfont" runat="server"></asp:Label></td>
                <td><asp:HiddenField ID = "hfName" runat = "server" /></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><asp:Label ID="unit" CssClass="contentfont" Text="Unit Number: " runat="server"></asp:Label></td>
                <td><asp:TextBox ID="UnitNumber" CssClass="contentfont" placeholder="Unit Number" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ErrorMessage="*" ForeColor="Red" runat="server" ControlToValidate="UnitNumber" ValidationGroup="sss"></asp:RequiredFieldValidator>
                </td>
            </tr>
                        </table>
                    </div>
                    <br />
                    <div class="subtitle">
                        <asp:Button ID="back2" CssClass="addbutton" Text="Back" OnClick="back2_Click" runat="server" />
                        <asp:Button ID="continue3" CssClass="addbutton" Text="Continue" OnClick="continue3_Click" ValidationGroup="sss" runat="server" />
                    </div>
                        </div>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="confirmationholder" runat="server">
                    <div class="backgroundcolor">
                     <div class="subtitle">
                        <asp:Label ID="Label5" CssClass="subheaddesign" Text="Confirmation" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label6" CssClass="contentfont" Text="Become one of our customer to enjoy our services provided to you!" runat="server"></asp:Label>
                    </div>
                        <br />
                        <div class="padding">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl1" CssClass="contentfont" Text="Email Address: " runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="conemail" CssClass="contentfont" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl2" CssClass="contentfont" Text="First Name: " runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="confname" CssClass="contentfont" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl3" CssClass="contentfont" Text="Last Name: " runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="conlast" CssClass="contentfont" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl4" CssClass="contentfont" Text="Gender: " runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="congender" CssClass="contentfont" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl5" CssClass="contentfont" Text="Date of Birth: " runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="condob" CssClass="contentfont" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl6" CssClass="contentfont" Text="Tel: " runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="conmobile" CssClass="contentfont" runat="server"></asp:Label>
                                        <br />
                                        <asp:Label ID="conhouse" CssClass="contentfont" runat="server"></asp:Label> 
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl7" CssClass="contentfont" Text="Billing Address: " runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="conadd" CssClass="contentfont" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />
                         <div class="subtitle">
                        <asp:Button ID="Button1" CssClass="addbutton" Text="Back" OnClick="back3_Click" runat="server" />
                        <asp:Button ID="Button2" CssClass="addbutton" Text="Create Account" OnClick="CreateAccount_Click" ValidationGroup="sss" runat="server" />
                    </div>
                    </div>
                </asp:PlaceHolder>
               <%-- <asp:PlaceHolder ID="nutritionholder" runat="server">
                    <div class="subtitle">
                        <asp:Label ID="Label5" CssClass="subheaddesign" Text="Proceed to Nutrition Assessement" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label6" CssClass="contentfont" Text="Better Understand Your Macronutrients intake and let us recommend recipe to you!" runat="server"></asp:Label>
                    </div>
                    <br />
                    <div class="borderouter1">
                        <div class="borderhead">
                            <asp:Label ID="antolbl" Text="Antropometric" runat="server"></asp:Label>
                        </div>
                        <br />
                        <div class="contentfont">
                            It is the measurement of your body height and weight based on age and gender.
                            <br />
                        </div>
                        <br />
                    </div>
                      <div class="borderouter3">
                        <div class="borderhead">
                            <asp:Label ID="Label8" Text="Medical Condition (S)" runat="server"></asp:Label>
                        </div>
                          <br />
                        <div class="contentfont">
                            Better understanding our Customer medical Condition so that we can recommend recipes better.
                            <br />
                        </div>
                          <br />
                    </div>
                    <div class="borderouter2">
                        <div class="borderhead">
                            <asp:Label ID="Label7" Text="Dietary Intake" runat="server"></asp:Label>
                        </div>
                        <br />
                        <div class="contentfont">
                            Better understanding of our Customer diet intake and their preference.
                        </div>
                        <br />
                    </div>
                    <br />
                    <br />
                    <div class="subtitle">
                        <asp:Button ID="Next" CssClass="addbutton" Text="Login" runat="server" OnClick="Next_Click" />
                        <asp:Button ID="proceed" CssClass="addbutton"  Text="Proceed to Nutrition Assessment" OnClick="proceed1_Click" runat="server" />
                    </div>
                </asp:PlaceHolder>--%>
            </div>
            </div>
           
    </div>
    </section>
    
</asp:Content>
