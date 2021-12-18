<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminInsertRecipeStep1.aspx.cs" Inherits="TastyChef.AdminInsertRecipeStep1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(window).load(function () {
            $(".loader").fadeOut("slow");
        })
    </script>
    <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=ImgRecipe.ClientID%>').prop('src', e.target.result)
                        .width(210)
                        .height(180);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }
            function checknegative1(str) {
                if (parseFloat(document.getElementById(str.id).value) < 0) {
                    document.getElementById(str.id).value = "";
                    document.getElementById(str.id).focus();
                    alert('Negative Values Not allowed');
                    return false;
                }
            }
    </script>
    <%-- CSS STYLE for Heading--%>
    <style>
        #headContent {
            width: 100%;
            height: 100px;
            /*border: solid;
            border-color: aqua;*/
            text-align: center;
            margin-top: 0.5%;
        }

        #title {
            font-family: Arial;
            font-size: 42px;
            color: black;
            font-weight: bold;
        }

        #titleDescription {
            font-family: Arial;
            font-size: 28px;
            color: grey;
        }

        #divider {
            color: black;
        }
    </style>
    <%-- CSS STYLE for Button Steps--%>
    <style>
        #stepContent {
            width: 100%;
            height: 80px;
            /*border: solid;
            border-color: aqua;*/
            margin-top: 2.5%;
        }

        #step1Button {
            /*border: solid;
            border-color: red;*/
            width: 12%;
            height: 95%;
            float: left;
            text-align: center;
            margin-left: 14.5%;
        }

        #step2Button {
            /*border: solid;
            border-color: red;*/
            width: 12%;
            height: 95%;
            float: left;
            text-align: center;
        }

        #step3Button {
            /*border: solid;
            border-color: red;*/
            width: 12%;
            height: 95%;
            float: left;
            text-align: center;
        }

        #step4Button {
            /*border: solid;
            border-color: red;*/
            width: 12%;
            height: 95%;
            float: left;
            text-align: center;
        }

        #step5Button {
            /*border: solid;
            border-color: red;*/
            width: 12%;
            height: 95%;
            float: left;
            text-align: center;
        }

        #confirmationButton {
            /*border: solid;
            border-color: red;*/
            width: 12%;
            height: 95%;
            float: left;
            text-align: center;
        }

        .stepButton {
            height: 70px;
            width: 180px;
            border-radius: 28px;
            font-size: 24px;
            font-family: Arial;
            background-color: #E3E3E3;
            font-weight: bold;
            border: none;
        }
    </style>

    <%-- CSS Style for Main Content--%>
    <style>
        #mainContent {
            width: 75%;
            height: 700px;
            /*border: solid;
            border-color: aqua;*/
            text-align: center;
            margin-top: 2.5%;
            margin-left: 10%;
        }

        #nextButtonContent {
            /*border: solid;
            border-color: aqua;*/
            width: 23.5%;
            height: 100px;
            margin-right: 5%;
            text-align: right;
            margin-top: 1.5%;
            float: right;
        }

        #backButtonContent {
            /*border: solid;
            border-color: aqua;*/
            width: 10%;
            height: 100px;
            text-align: right;
            margin-top: 1.5%;
            float: right;
            margin-right:1.5%;
        }


        .nextButton {
            height: 55px;
            width: 125px;
            border-radius: 10px;
            font-size: 26px;
            font-family: Arial;
            background-color: #009999;
            font-weight: bold;
            border: none;
            color: white;
        }
          .nextButtonNext {
            height: 55px;
           width: 350px;
            border-radius: 10px;
            font-size: 26px;
            font-family: Arial;
            background-color: #009999;
            font-weight: bold;
            border: none;
            color: white;
        }
    </style>
    <%--CSS Style for Basic Details Content--%>
    <style>
         .d {
            width: 90%;
            margin-left: 5%;
        }
        #basicDetailContent {
            /*border: 2px solid #4DB6AC;*/
            width: 80%;
            height: 500px;
            margin-left: 15%;
            background-color: White;
      
        }

        #basicDetailHeadingContent {
         
            background-color: white;
            width: 100%;
            height: 12%;
          
       
        }

        #basicDetailHeading {
            text-align: center;
            font-family: Arial;
            font-size: 3em;
            color: #003366;
            font-weight: bold;
            display:inline-block;
            height:90%;
             margin-top:1.5%;
          
        }

        #basicDetailLeftContent {
            /*border: solid;
            border-color: red;*/
            height: 84%;
            width: 45%;
            float: left;
            margin-left:3%;
            margin-top:1.5%;
        }

        #basicDetailRightContent {
            /*border: solid;
            border-color: red;*/
            height: 84%;
            width: 47%;
            float: right;
            margin-top:1.5%;
        }

        #imageContent {
            /*border: solid;
            border-color: aqua;*/
            height: 45%;
            text-align: left;
            margin-top: 3%;
            float:left;
            width:30%;
            
        }
        #img{
             /*border: solid;
            border-color: aqua;*/
            height: 45%;
            text-align: left;
            margin-top: 3%;
            float:left;
            width:45%;
            margin-left:5%;
        }
        #recipeFounderContent {
            height: 15%;
            text-align: left;
            margin-top: 1%;
            width:100%;
            float:left;
            /*border: solid;
            border-color: aqua;*/
        }

        #cookingTypeContent {
            height: 15%;
            text-align: left;
            margin-top: 1%;
            float:left;
            width:100%;
            /*border: solid;
            border-color: aqua;*/
        }

        .labelContent {
            font-family: Arial;
            font-weight: bold;
            font-size: 30px;
            color: black;
        }

        #detailContent {
            height: 84%;
            text-align: left;
            /*border: solid;
            border-color: red;*/
            width: 90%;
            float: right;
        }

        #table {
            height: 100%;
            width: 100%;
            /*border: solid;
            border-color: aqua;*/
        }

        .tb {
            border-radius: 5px;
            border-color: lightgrey;
            border-width: 1.5px;
            font-size: 20px;
            color: black;
            height: 35px;
            width: 275px;
        }

        .auto-style4 {
            width: 110px;
        }

        .dropdownlist {
            border-radius: 4px;
            border-color: black;
            border-width: 1.5px;
            height: 35px;
            width: 195px;
            font-size: 20px;
            color: black;
        }

        .auto-style5 {
            height: 10px;
        }

    </style>
    <%--    <div class="loader">
          </div>--%>

     

    <div id="headContent">
        <div id="title">
           Create Recipe
        </div>
        <div id="titleDescription">
            Comprehend the nature of ingredients and coordinate them into Gorgeous Recipe 
        </div>
        <div id="divider">
            _____________________
        </div>
    </div>
    <div id="stepContent">
        <div id="step1Button">
            <asp:Button ID="BtnStep1" runat="server" Text="Step 1" CssClass="stepButton" BackColor="#009999" ForeColor="White" />
        </div>
        <div id="step2Button">
            <asp:Button ID="BtnStep2" runat="server" Text="Step 2" CssClass="stepButton" />
        </div>
        <div id="step3Button">
            <asp:Button ID="BtnStep3" runat="server" Text="Step 3" CssClass="stepButton" />
        </div>
        <div id="step4Button">
            <asp:Button ID="BtnStep4" runat="server" Text="Step 4" CssClass="stepButton" />
        </div>
        <div id="step5Button">
            <asp:Button ID="BtnStep5" runat="server" Text="Step 5" CssClass="stepButton" />
        </div>

        <div id="confirmationButton">
            <asp:Button ID="BtnConfirmation" runat="server" Text="Confirmation" CssClass="stepButton" />
        </div>
    </div>
    <div id="mainContent">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="basicDetailContent">
            <div id="basicDetailHeadingContent">
                <div id="basicDetailHeading">
                   Recipe Details
                  
                </div>
                  <div class="d">
                             <hr />
                         </div>
            </div>
            <div id="basicDetailLeftContent">
                <div id="detailContent">

                    <table id="table">
                        <tr>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <td class="auto-style4">
                                        <asp:Label ID="Label2" runat="server" Text="Name" CssClass="labelContent"></asp:Label>
                                    </td>
                                    <td style="height:150px;">
                                        <asp:TextBox ID="TbRecipeName" runat="server" CssClass="tb" AutoPostBack="True" OnTextChanged="TbRecipeName_TextChanged"></asp:TextBox>
                                          <asp:Button ID="BtnCheck" runat="server" Text="Check" Width="67" Height="40" Font-Size="18px" />
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*Required" Font-Size="20px" ForeColor="Red" ControlToValidate="TbRecipeName" Font-Bold="True" ValidationGroup="a"></asp:RequiredFieldValidator>
                                      
                                        <asp:Label ID="LblErrorMessage" runat="server" Font-Size="20px" ForeColor="Red" Font-Bold="True"></asp:Label>
                                        <br />
                                      
                                    </td>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </tr>
                        <tr>
                            <td class="auto-style4">
                                <asp:Label ID="Label3" runat="server" Text="Type" CssClass="labelContent"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="DDLType" runat="server" CssClass="dropdownlist" Width="120px">
                                    <asp:ListItem Value="Asian">Asian</asp:ListItem>
                                    <asp:ListItem Value="Western">Western</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">
                                <asp:Label ID="Label4" runat="server" Text="Serves" CssClass="labelContent"></asp:Label>;</td>
                            <td>
                                <asp:TextBox ID="TbServes" runat="server" TextMode="Number" CssClass="tb" onblur="checknegative1(this)" Width="50px">1</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">
                                <asp:Label ID="Label5" runat="server" Text="Duration" CssClass="labelContent"></asp:Label>;</td>
                            <td>
                                <asp:TextBox ID="TbCookingTime" runat="server" TextMode="Number" CssClass="tb" Width="50px" onblur="checknegative1(this)">10</asp:TextBox>
                                <asp:Label ID="Label6" runat="server" Text="Mins" Font-Size="X-Large" ForeColor="Black"></asp:Label>
                                <br />
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Range allow 10 to 30 minutes" ControlToValidate="TbCookingTime"  MinimumValue="10"
           MaximumValue="30"
           Type="Integer"
           EnableClientScript="false" ForeColor="Red" ValidationGroup="a" Font-Bold="True" Font-Size="20px"></asp:RangeValidator>
                            </td>
                        </tr>
                    </table>

                </div>

            </div>
            <div id="basicDetailRightContent">
                <div id="imageContent">
                    <asp:Label ID="Label1" runat="server" Text="Image" CssClass="labelContent"></asp:Label>
                    <br />
                    <br />
                    <asp:FileUpload ID="FileUploadRecipeImage" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="X-Large" onchange="ShowImagePreview(this);" Width="140px" />
                    <asp:Label ID="LblFileName" runat="server" Visible="False" Font-Size="20px"></asp:Label>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Only picture files are allowed" Font-Size="20px" ForeColor="Red" ControlToValidate="FileUploadRecipeImage" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$" Font-Bold="True" ValidationGroup="a"></asp:RegularExpressionValidator>
                    <br />
                   
                  
                </div>
                <div id="img">
                      <asp:Image ID="ImgRecipe" runat="server" Height="180px" Width="210px" />
                </div>
                <div id="cookingTypeContent">
                    <asp:Label ID="Label8" runat="server" Text="Cooking Type: " CssClass="labelContent"></asp:Label>
                    <asp:DropDownList ID="DDLCookingType" runat="server" CssClass="dropdownlist">
                        <asp:ListItem>Please Select</asp:ListItem>
                    
                        <asp:ListItem>Steaming</asp:ListItem>
                        <asp:ListItem>Grilling</asp:ListItem>
                     
                        <asp:ListItem>Boiling</asp:ListItem>
                        <asp:ListItem>Stewing</asp:ListItem>
                        <asp:ListItem>Stir-Frying</asp:ListItem>
                
                    </asp:DropDownList>
                </div>
                <div id="recipeFounderContent">
                    <asp:Label ID="Label7" runat="server" Text="Chef: " CssClass="labelContent"></asp:Label>
                    <asp:TextBox ID="TbRecipeFounder" runat="server" CssClass="tb"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*Required" Font-Size="20px" ForeColor="Red" ControlToValidate="TbRecipeFounder" Font-Bold="True" ValidationGroup="a"></asp:RequiredFieldValidator>
                </div>


            </div>

        </div>
        <div id="nextButtonContent">
            <asp:Button ID="BtnStep1Next" runat="server" Text="Proceed to Step 2" CssClass="nextButtonNext" OnClick="BtnStep1Next_Click" ValidationGroup="a" />


        </div>
        <div id="backButtonContent">
            <asp:Button ID="Button1" runat="server" Text="Back" CssClass="nextButton" OnClick="Button1_Click" />
        </div>


    </div>
</asp:Content>
