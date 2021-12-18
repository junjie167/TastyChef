<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.Master" AutoEventWireup="true" CodeBehind="CustomerPersonalDetails1.aspx.cs" Inherits="TastyChef.CustomerPersonalDetails1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
         .borderouter{
            border:2px solid #4DB6AC;
            border-radius:12px;
            width:100%;
            background-color:white;
            font-family:Arial;
        }
         .nutritionborder{
              border:2px solid #4DB6AC;
            border-radius:12px;
            width:100%;
            background-color:white;
            font-family:Arial;
            float:right;
             margin:auto;
             width:60%;
         }
         .deliveryborder{
              border:2px solid #4DB6AC;
            border-radius:12px;
            width:100%;
            background-color:white;
            font-family:Arial;
            overflow:hidden;
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
            display:inline-block;
        }
         .headd{
             color:#003366;
            text-align:center;
            font-family: Arial;
                font-weight:bold;
            font-size:3.5em;
         }
         h4{
            text-decoration:underline;
            font-weight:bold;
        }
         h1{
             font-size:4.5em;
         }
         .buttondesign{
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
             float:right;
             margin:5px;
         }
          .buttondesign1{
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
             float:right;
             margin:5px;
         }
         .Canceldesign{
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
         .noticedesign{
             font-size:1.5em;
             font-weight:bold;
         }
         .antropometricborder{
                border:2px solid #4DB6AC;
            border-radius:12px;
            background-color:white;
            font-family:Arial;
            float:right;
             margin:auto;
             width:60%;
         }
         .dietaryborder{
              border:2px solid #4DB6AC;
            border-radius:12px;
            float:right;
             margin-top:20px;
             width:60%;
            background-color:white;
            font-family:Arial;
         }
         .medicalborder{
             border:2px solid #4DB6AC;
            border-radius:12px;
            float:right;
             margin-top:20px;
             width:60%;
            background-color:white;
            font-family:Arial;
         }
         .db2{
             clear:both;
         }
         .content{
             font-size:1.3em;
             font-family:Arial;
         }
         label{
             font-weight:normal;
         }
         .fontbold{
             font-weight:bold;
         }
         @media (min-width: 768px) {
         .borderouter{
             float:left;
             width:35%;
         }
         .borderouters{
             float:left;
             width:25%;
         }
         table{
             margin-left:30px;
         }
         .deliveryborder{
            margin-top:480px;
             width:35%;
         }
        }
    </style>
    <script>
<!--
$(document).ready(function () {
    $("button").on('click', function () {
        var address = document.getElementById('<%= postalcode.ClientID %>').value;
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
    <div class="container">
        <div class="headd">
            <asp:Label ID="Label1" Text="Personal Profile" runat="server"></asp:Label>
        </div>
        <br />
        <div class="borderouter">
            <div class="borderhead">
                <asp:Label ID="Label2" CssClass="titlee" Text="Basic Details" runat="server"></asp:Label>
            </div>
            <asp:PlaceHolder ID="notedit" runat="server">
            <div class="content">
            <table>
                <tr>
                    <td style="width:85px;">&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="na" CssClass="fontbold" Text="Name: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="name" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="ag" CssClass="fontbold" Text="Age: " runat="server"></asp:Label></td>
                    <td>
                        <asp:label id="age" runat="server"></asp:label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="d" CssClass="fontbold" Text="Date of Birth: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="dob" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="gen" CssClass="fontbold" Text="Gender: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="gender" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="mo" CssClass="fontbold" Text="Tel: " runat="server"></asp:Label></td>
                    <td colspan="2"><asp:Label ID="mobile" runat="server"></asp:Label>
                                    <br />
                                    <asp:Label ID="home" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="addlbl" CssClass="fontbold" Text="Billing Address: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="billingadd" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="em" CssClass="fontbold" Text="Email: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="emails" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="editpanel" runat="server">
                <div class="content">
                <table>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="fn" CssClass="fontbold" Text="First Name: " runat="server"></asp:Label></td>
                        <td><asp:TextBox ID="firstname" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="require1" ErrorMessage="*" ForeColor="Red" runat="server" ControlToValidate="firstname" ValidationGroup="s"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regfname" ControlToValidate="firstname" ForeColor="Red" Text="*Must be in alphabetical" ValidationExpression="^[a-zA-Z''-'\s]{1,100}$" SetFocusOnError="true" runat="server"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="ln" CssClass="fontbold" Text="Last Name: " runat="server"></asp:Label></td>
                        <td><asp:TextBox ID="lastname" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="*" ForeColor="Red" runat="server" ControlToValidate="lastname" ValidationGroup="s"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="lastname" ForeColor="Red" Text="*Must be in alphabetical" ValidationExpression="^[a-zA-Z''-'\s]{1,100}$" SetFocusOnError="true" runat="server"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="dd" CssClass="fontbold" Text="Date of Birth: " runat="server"></asp:Label></td>
                        <td><asp:TextBox ID="dateofbirth" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="*" ForeColor="Red" runat="server" ControlToValidate="dateofbirth" ValidationGroup="s"></asp:RequiredFieldValidator>
<%--                     <asp:RangeValidator ID="regDOB" ControlToValidate="dateofbirth" Text="*Must not be in future date and according to the formate given" ForeColor="Red" SetFocusOnError="true" Type="Date" runat="server" MinimumValue="01/01/1920"></asp:RangeValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="geee" CssClass="fontbold" Text="Gender: " runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="gende" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Female</asp:ListItem>
                                <asp:ListItem>Male</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="telephone" CssClass="fontbold" Text="Tel: " runat="server"></asp:Label></td>
                        <td colspan="2">
                            <asp:TextBox ID="moo" runat="server"></asp:TextBox><asp:Label ID="mobileunit" Text=" (Hp)" runat="server"></asp:Label>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="*" ForeColor="Red" runat="server" ControlToValidate="moo" ValidationGroup="s"></asp:RequiredFieldValidator>
                            &nbsp;
                            <asp:TextBox ID="hoo" runat="server"></asp:TextBox><asp:Label ID="houseunit" Text=" (Home)" runat="server"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="*" ForeColor="Red" runat="server" ControlToValidate="hoo" ValidationGroup="s"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="po1" CssClass="fontbold" Text="Postal Code" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="postalcode" MaxLength="6" runat="server"></asp:TextBox>
                             <button class="buttondesign1">Get</button>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="adddd" CssClass="fontbold" Text="Address: " runat="server"></asp:Label></td>
                        <td><asp:Label ID="add" runat="server"></asp:Label><asp:HiddenField ID= "hfName" runat= "server" /></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                          <td><asp:Label ID="unit" CssClass="fontbold" Text="Unit Number: " runat="server"></asp:Label></td>
                        <td><asp:TextBox ID="unitnumber" runat="server"></asp:TextBox></td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ErrorMessage="*" ForeColor="Red" runat="server" ControlToValidate="unitnumber" ValidationGroup="s"></asp:RequiredFieldValidator>
                    </tr>
                      <tr>
                    <td>&nbsp;</td>
                </tr>
                    <tr>
                        <td><asp:Label ID="ema" CssClass="fontbold" Text="Email: " runat="server"></asp:Label></td>
                        <td><asp:TextBox ID="emailaddress" runat="server" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                 
                </table>
                    </div>
                <asp:Button ID="cancel" CssClass="Canceldesign" Text="Cancel" OnClick="Cancel_Click" runat="server" />
            </asp:PlaceHolder>
             <asp:Button ID="edit" CssClass="buttondesign" ValidationGroup="s"  Text="Edit" runat="server" OnClick="edit_Click" />
               <br />
        </div>
        <asp:PlaceHolder ID="healthpanel" runat="server">
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
                    <td><asp:Label ID="he" CssClass="fontbold" Text="Height: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="height" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="we" CssClass="fontbold" Text="Weight: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="weight" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="ac" CssClass="fontbold" Text="Activity Level: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="activity" runat="server"></asp:Label></td>
                </tr>
                <tr>

                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="bm" CssClass="fontbold" Text="BMI: " runat="server"></asp:Label></td>
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
                    <td><asp:Label ID="wee" CssClass="fontbold"  Text="Weight Status: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="weightstatus" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                 </table>
                </div>
                            <br />
                  <asp:Button ID="Button2" CssClass="buttondesign" Text="Edit" OnClick="edit2_click" runat="server" />

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
                    <td><asp:Label ID="die" CssClass="fontbold" Text="Diet Type: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="diet" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="all" CssClass="fontbold" Text="Food Allergy: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="allergy" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="av" CssClass="fontbold" Text="Food Avoidance: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="avoid" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="me" CssClass="fontbold" Text="Meal Frequency: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="meal" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="sn" CssClass="fontbold" Text="Snack Frequency: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="snack" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                </table>
                    </div>
                  <br />
                  <asp:Button ID="Button1" CssClass="buttondesign" Text="Edit" OnClick="edit3_click" runat="server" />

            </div>
            <br />
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
                    <td><asp:Label ID="medi" CssClass="fontbold" Text="Medical Condition: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="medical" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Label ID="glu" CssClass="fontbold" Text="Glucose Level: " runat="server"></asp:Label></td>
                    <td><asp:Label ID="glucose" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                </table>
                    </div>
                <br />
                  <asp:Button ID="edit2" CssClass="buttondesign" Text="Edit" OnClick="edit4_click" runat="server" />
            </div>
            </asp:PlaceHolder>
         <asp:PlaceHolder ID="nothealthpanel" runat="server">
        <div class="nutritionborder">
                             <div class="borderhead">
                                 <asp:Label ID="Label7" Text="Nutrition Assessment" runat="server" CssClass="titlee"></asp:Label>
            </div>
            <br />    
                <asp:Label ID="notice" CssClass="noticedesign" Text="Please fill up your nutrition assessment before you can view your health details." runat="server"></asp:Label>
                <br />
                <asp:Button ID="proceed" CssClass="buttondesign" Text="Proceed" OnClick="proceed_Click" runat="server" />
            </div>
            </asp:PlaceHolder>
           <%-- <div class="deliveryborder" id="db" runat="server">
            <div class="borderhead">
                <asp:Label ID="Label9" Text="Address(es)" CssClass="titlee" runat="server"></asp:Label>
            </div>
                <br />
            <asp:PlaceHolder ID="deliverypanel" runat="server">
                <div class="content">
                <asp:GridView ID="GridView1" CellSpacing="5" Width="365px" runat="server" EmptyDataText="No Record Found" AutoGenerateColumns="false"  ViewStateMode="Enabled">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="address8"  Text='<%#Eval("Address")%>' runat="server"></asp:Label>
                                #<asp:Label ID="unitnumber" Text='<%#Eval("UnitNumber") %>' runat="server"></asp:Label>
                                <br />
                                Singapore(<asp:Label ID="postall" Text='<%#Eval("PostalCode") %>' runat="server"></asp:Label>)
                                <asp:Label ID="deliveryid" Visible="false" Text='<%#Eval("Id") %>' runat="server"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;
                                <asp:ImageButton ID="addressedit" ImageUrl="~/img/editicon.jpg" Width="16px" OnClick="addressedit_Click" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" runat="server" />
                                <asp:ImageButton ID="addressremove" ImageUrl="~/img/deleteicon.png" Width="16px" OnClick="removeaddress" runat="server" />
                                <br />
                                <hr />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                    </div>
                <br />
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="deliveryaddtion" runat="server">
                <div class="content">
                <hr id="headline" runat="server" />
                <h4 id="addresshead" runat="server" style="text-align:center;">Add New Address</h4>
                <table>
                    <tr>
                        <td style="width:78px;">&nbsp;</td>
                        <td></td>
                    </tr>
                       <tr>
                        <td><asp:Label ID="po" Text="Postal Code: " runat="server"></asp:Label></td>
                        <td><asp:TextBox ID="postalcode" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="*" ForeColor="Red" runat="server" ControlToValidate="postalcode" ValidationGroup="s"></asp:RequiredFieldValidator>
                            <button class="buttondesign1">Get</button>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="adddd" Text="Address: " runat="server"></asp:Label></td>
                        <td><asp:Label ID="newaddress" runat="server"></asp:Label><asp:HiddenField ID= "hfName" runat= "server" /></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="unit" Text="Unit Number: " runat="server"></asp:Label></td>
                        <td><asp:TextBox ID="unitnumber" runat="server"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ErrorMessage="*" ForeColor="Red" runat="server" ControlToValidate="unitnumber" ValidationGroup="s"></asp:RequiredFieldValidator>
                            <asp:Label ID="delivery" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                </div>
                <asp:Button ID="addcancel" CssClass="Canceldesign" Text="Cancel" OnClick="addcancel_Click" runat="server" />
            </asp:PlaceHolder>
                <asp:Button ID="adddelivery" CssClass="addbutton" ValidationGroup="s" Text="Add New Address" runat="server" OnClick="adddelivery_Click" />
                <br />
        </div>--%>
    </div>
      
    
           

</asp:Content>
