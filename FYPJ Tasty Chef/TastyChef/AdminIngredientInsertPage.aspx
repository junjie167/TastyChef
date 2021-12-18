<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminIngredientInsertPage.aspx.cs" Inherits="TastyChef.AdminIngredientInsertPage" %>

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
                    $('#<%=ImgIngredients.ClientID%>').prop('src', e.target.result)
                        .width(180)
                        .height(150);
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
        }

        #titleDescription {
            font-family: Arial;
            font-size: 28px;
            color: grey;
        }

        #divider {
            color: black;
        }
           .loader {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url('Images/Loading_icon.gif') 50% 50% no-repeat rgb(249,249,249);
        }
    </style>
    <%--CSS Style for Main Content--%>
    <style>
        #mainContent {
            width: 80%;
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
            width: 15%;
            height: 100px;
            margin-left: 75%;
            text-align: right;
        }

        .nextButton {
            height: 55px;
            width: 250px;
            border-radius: 10px;
            font-size: 26px;
            font-family: Arial;
            background-color: #009999;
            font-weight: bold;
            border: none;
            color: white;
        }
             .ComputeButton {
            height: 45px;
            width: 160px;
            border-radius: 10px;
            font-size: 16px;
            font-family: Arial;
            background-color: White;
            font-weight: bold;
            border:solid;
            border-color:black;
            color: black;
        }
    </style>
    <%--  CSS Style for Left Content--%>
    <style>
        #leftContent {
            border: solid;
            border-color: #E3E3E3;
            width: 49%;
            height: 100%;
            float: left;
            background-color:white;
        }

        #leftContentHeading {
            background-color: #4DB6AC;
            width: 100%;
            height: 10%;
        }

        #leftContentHeadingDetails {
            text-align: left;
            font-family: Arial;
            font-size: 34px;
            color: white;
            font-weight: bold;
            float: left;
            margin-top: 1.5%;
        }

        #leftContentBody {
            /*border: solid;
            border-color: red;*/
            width: 95%;
            height: 90%;
            margin-left: 2.5%;
            background-color:white;
        }

        .auto-style4 {
            width: 100%;
            height: 100%;
        }

        .tb {
            border-radius: 5px;
            border-color: black;
            border-width: 1.5px;
            font-size: 20px;
            color: black;
            height: 35px;
            width: 250px;
        }

        .labelContent {
            font-family: Arial;
            font-size: 26px;
            color: black;
        }

        .dropdownlist {
            border-radius: 4px;
            border-color: black;
            border-width: 1.5px;
            height: 35px;
            width: 200px;
              font-size: 20px;
            font-family: Arial;
            color: black;
        }
    </style>
    <%--  CSS Style for Right Content--%>
    <style>
        #rightContent {
            border: solid;
            border-color: #E3E3E3;
            width: 49%;
            height: 70%;
            float: right;
            background-color:white;
           
        }

        #rightContentHeading {
            background-color: #4DB6AC;
            width: 100%;
            height: 13.5%;
        }

        #rightContentHeadingDetails {
            text-align: left;
            font-family: Arial;
            font-size: 28px;
            color: white;
            font-weight: bold;
            float: left;
            margin-top: 1.5%;
        }

        #rightContentBody {
            /*border: solid;
            border-color: red;*/
            width: 100%;
            height: 87.5%;
            background-color:white;
        }

        .tb2 {
            border-radius: 5px;
            border-color: lightgrey;
            border-width: 1.5px;
            font-size: 20px;
            color: black;
            height: 30px;
            width: 60px;
        }

        .nutritionDataContent {
            font-family: Arial;
            font-size: 22px;
            color: black;
        }


        .auto-style5 {
            text-align: left;
        }

        .auto-style6 {
            border-radius: 5px;
            border-color: lightgrey;
            border-width: 1.5px;
            font-size: 20px;
            color: black;
            width: 55px;
        }

        .auto-style7 {
            border-radius: 5px;
            border-color: lightgrey;
            border-width: 1.5px;
            font-size: 20px;
            color: black;
            height: 30px;
            width: 55px;
            margin-bottom: 7px;
        }
        .tb1{
            font-size:18px;
            font-family:Arial;
        }
    </style>
          <div class="loader"></div>
    <div id="headContent">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="title">
            Add New Ingredients
        </div>
        <div id="titleDescription">
            Comprehend the nature of ingredients and coordinate them into Gorgeous Recipe 
        </div>
        <div id="divider">
            _____________________
        </div>
    </div>
    <div id="mainContent">
        <div id="leftContent">
            <div id="leftContentHeading">
                <div id="leftContentHeadingDetails">
                    Basic Information
                </div>
            </div>
            <div id="leftContentBody">

                <table class="auto-style4">
                    <tr>
                        <td class="auto-style5">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="Label1" runat="server" Text="Ingredient Name" CssClass="labelContent"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="TbIngredientsName" runat="server" CssClass="tb" AutoPostBack="True" OnTextChanged="TbIngredientsName_TextChanged"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*Required" Font-Size="Medium" ForeColor="Red" ControlToValidate="TbIngredientsName" ValidationGroup="a"></asp:RequiredFieldValidator>

                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                        <ProgressTemplate>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Loading_icon.gif" Width="50px" Height="50px" />

                                        </ProgressTemplate>
                                    </asp:UpdateProgress>

                                    <asp:Label ID="LblErrorMessage" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="auto-style5">
                            <asp:Label ID="Label2" runat="server" Text="Category" CssClass="labelContent"></asp:Label>
                            <br />
                            <asp:DropDownList ID="DDLCategory" runat="server" CssClass="dropdownlist">
                                <asp:ListItem Text="Please Select" Value="0">Please Select</asp:ListItem>
                                <asp:ListItem Value="Diary">Diary</asp:ListItem>
                                <asp:ListItem>Diary Alternatives</asp:ListItem>
                                <asp:ListItem>Meat</asp:ListItem>
                                <asp:ListItem>Fish</asp:ListItem>
                                <asp:ListItem>Seafood</asp:ListItem>
                                <asp:ListItem>Fruits</asp:ListItem>
                                <asp:ListItem>Spices</asp:ListItem>
                                <asp:ListItem>Baking&Grains</asp:ListItem>
                                <asp:ListItem>Added Sweeteners</asp:ListItem>
                                <asp:ListItem>Seasoning</asp:ListItem>
                                <asp:ListItem>Nuts</asp:ListItem>
                                <asp:ListItem>Condiments</asp:ListItem>
                                <asp:ListItem>Dessert&Snacks</asp:ListItem>
                                <asp:ListItem>Soup</asp:ListItem>
                                <asp:ListItem>Legumes</asp:ListItem>
                                <asp:ListItem>Sauces</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:Label ID="Label3" runat="server" Text="Image:" CssClass="labelContent"></asp:Label>
                            <asp:FileUpload ID="FileUploadImage" runat="server" onchange="ShowImagePreview(this);" Width="230px" ViewStateMode="Enabled" />
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Only picture files are allowed" Font-Size="Small" ForeColor="Red" ControlToValidate="FileUploadImage" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$" ValidationGroup="a"></asp:RegularExpressionValidator>
                            <br />


                            <asp:Image ID="ImgIngredients" runat="server" Height="120px" Width="150px" BorderStyle="None" />
                        </td>
                        <td class="auto-style5"><asp:Label ID="Label6" runat="server" Text="Measurement" CssClass="labelContent"></asp:Label>
                            <br />
                             <asp:DropDownList ID="DDlMeasure" runat="server" CssClass="dropdownlist" Width="100px">
                                       <asp:ListItem Text="Please Select" Value="0">-Select-</asp:ListItem>
                                    <asp:ListItem >quantity</asp:ListItem>
                                <asp:ListItem >grams</asp:ListItem>
                                <asp:ListItem>ml</asp:ListItem>
                                     <asp:ListItem>tbsp</asp:ListItem>
                                         <asp:ListItem>tsp</asp:ListItem>
                                </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:Label ID="Label5" runat="server" Text="Remarks" CssClass="labelContent"></asp:Label><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" Font-Size="Medium" ForeColor="Red" ControlToValidate="TbRemarks" ValidationGroup="a"></asp:RequiredFieldValidator><br />
                            <asp:TextBox ID="TbRemarks" TextMode="MultiLine" runat="server" CssClass="tb1" ControlToValidate="TbRemarks" Height="180px" Width="400px"></asp:TextBox>
                        </td>
                        <td class="auto-style5">&nbsp;</td>
                    </tr>
                </table>

            </div>
        </div>
        <div id="rightContent">
            <div id="rightContentHeading">
                <div id="rightContentHeadingDetails">
                    Nutrition Information Per (Qty/Tsp/Tbsp/Ml/Grams)
                </div>
            </div>
            <div id="rightContentBody">

                <table class="auto-style4">
                    <tr>
                        <td class="auto-style5">

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required" Font-Size="Medium" ForeColor="Red" ControlToValidate="TbProteins" ValidationGroup="a"></asp:RequiredFieldValidator>
                            <br class="auto-style39" />
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:Label runat="server" Text="Proteins" CssClass="nutritionDataContent"></asp:Label>

                                    <asp:TextBox ID="TbProteins" runat="server" CssClass="tb2" onblur="checknegative1(this)" placeholder="grams"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TbProteins"
    ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^[0-9]\d*(\.\d+)?$" ValidationGroup="a">        </asp:RegularExpressionValidator>
                        </td>
                        <td class="auto-style5">

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Required" Font-Size="Medium" ForeColor="Red" ControlToValidate="TbSodium" ValidationGroup="a"></asp:RequiredFieldValidator>
                            <br class="auto-style39" />
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="Label7" runat="server" Text="Sodium" CssClass="nutritionDataContent"></asp:Label>
                                    <asp:TextBox ID="TbSodium" runat="server" CssClass="tb2" placeholder="mg" onblur="checknegative1(this)" ></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TbSodium"
    ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^[0-9]\d*(\.\d+)?$" ValidationGroup="a">    </asp:RegularExpressionValidator>
                        </td>
                        <td class="auto-style5">

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*Required" Font-Size="Medium" ForeColor="Red" ControlToValidate="TbCholesterol" ValidationGroup="a"></asp:RequiredFieldValidator>
                            <br class="auto-style39" />
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="Label8" runat="server" Text="Cholesterol" CssClass="nutritionDataContent"></asp:Label>
                                    <asp:TextBox ID="TbCholesterol" runat="server" CssClass="tb2" placeholder="mg" onblur="checknegative1(this)"></asp:TextBox>&nbsp;
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TbCholesterol"
    ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^[0-9]\d*(\.\d+)?$" ValidationGroup="a">    </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" Font-Size="Medium" ForeColor="Red" ControlToValidate="TbSaturatedFat" ValidationGroup="a" placeholder="grams"></asp:RequiredFieldValidator>
                            <br class="auto-style39" />
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="Label9" runat="server" Text="Saturated" CssClass="nutritionDataContent"></asp:Label>
                                    <asp:TextBox ID="TbSaturatedFat" runat="server" CssClass="tb2" onblur="checknegative1(this)" placeholder="grams"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TbSaturatedFat"
    ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^[0-9]\d*(\.\d+)?$" ValidationGroup="a">    </asp:RegularExpressionValidator>
                        </td>
                        <td class="auto-style5">

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Required" Font-Size="Medium" ForeColor="Red" ControlToValidate="TbTrans" ValidationGroup="a"></asp:RequiredFieldValidator>
                            <br class="auto-style39" />
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="Label10" runat="server" Text="Trans" CssClass="nutritionDataContent"></asp:Label>
                                    <asp:TextBox ID="TbTrans" runat="server"  CssClass="tb2" onblur="checknegative1(this)" placeholder="grams"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TbTrans"
    ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^[0-9]\d*(\.\d+)?$" ValidationGroup="a">    </asp:RegularExpressionValidator>
                        </td>
                        <td class="auto-style5">

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Required" Font-Size="Medium" ForeColor="Red" ControlToValidate="TbTotalFat" ValidationGroup="a"></asp:RequiredFieldValidator>
                            <br class="auto-style39" />
                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="Label11" runat="server" Text="Total Fat" CssClass="nutritionDataContent"></asp:Label>
                                    <asp:TextBox ID="TbTotalFat" runat="server" CssClass="tb2" onblur="checknegative1(this)" placeholder="grams"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="TbTotalFat"
    ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^[0-9]\d*(\.\d+)?$" ValidationGroup="a">    </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required" Font-Size="Medium" ForeColor="Red" ControlToValidate="TbSugar" ValidationGroup="a"></asp:RequiredFieldValidator>
                            <br class="auto-style39" />
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>

                                    <asp:Label ID="Label12" runat="server" Text="Sugar" CssClass="nutritionDataContent"></asp:Label>
                                    <asp:TextBox ID="TbSugar" runat="server" CssClass="tb2" onblur="checknegative1(this)" placeholder="grams"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="TbSugar"
    ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^[0-9]\d*(\.\d+)?$" ValidationGroup="a">    </asp:RegularExpressionValidator>
                        </td>
                        <td class="auto-style5">

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*Required" Font-Size="Medium" ForeColor="Red" ControlToValidate="TbDietaryFiber" ValidationGroup="a"></asp:RequiredFieldValidator>
                            <br class="auto-style39" />
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="Label13" runat="server" Text="Dietary Fiber" CssClass="nutritionDataContent"></asp:Label>
                                    <asp:TextBox ID="TbDietaryFiber" runat="server" CssClass="tb2" onblur="checknegative1(this)" placeholder="grams"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="TbDietaryFiber"
    ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^[0-9]\d*(\.\d+)?$" ValidationGroup="a">    </asp:RegularExpressionValidator>
                        </td>
                        <td class="auto-style5">

                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="Label14" runat="server" Text="Carbohydrates" CssClass="nutritionDataContent"></asp:Label>
                                    <asp:TextBox ID="TbTotalCarbohydrates" runat="server" CssClass="tb2" onblur="checknegative1(this)" placeholder="grams"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*Required" Font-Size="Medium" ForeColor="Red" ControlToValidate="TbTotalCarbohydrates" ValidationGroup="a"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="TbTotalCarbohydrates"
    ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^[0-9]\d*(\.\d+)?$" ValidationGroup="a">    </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            
                            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                <ContentTemplate>
   
                                    <asp:Label ID="LblTotalCalories" runat="server" Font-Size="XX-Large" ForeColor="Black" Visible="False"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            &nbsp;</td>
                        <td>
</td>
                        <td><asp:Button ID="BtnComputeCalories" runat="server" Text="Compute Calories" CssClass="ComputeButton" OnClick="BtnComputeCalories_Click" ValidationGroup="a" /></td>
                    </tr>
                </table>

            </div>
        </div>
    </div>
    <div id="nextButtonContent">
        <asp:Button ID="BtnSubmit" runat="server" CssClass="nextButton" Text="Create Ingredient" OnClick="BtnSubmit_Click" ValidationGroup="a" />
    </div>
</asp:Content>
