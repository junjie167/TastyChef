<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminRecipeDetials.aspx.cs" Inherits="TastyChef.AdminRecipeDetials" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(window).load(function () {
            $(".loader").fadeOut("slow");
        })
    </script>
    <%-- CSS STYLE for Heading--%>
    <style>
        .loader {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url('Images/Loading_icon.gif') 50% 50% no-repeat rgb(249,249,249);
        }

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
        .table{
            text-align:left;
            height:100%;
            width:90%;
            margin-left:5%;
        }
    </style>
    <%-- CSS STYLE for Button Steps--%>
    <style>
        #stepContent {
            width: 100%;
            height: 40px;
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
            float: right;
            text-align: center;
            margin-right:15%;
        }

        #confirmationButton {
            /*border: solid;
            border-color: red;*/
            width: 8%;
            height: 95%;
            float: right;
            text-align: center;
        }

        .stepButton {
            height: 70px;
            width: 180px;
            border-radius: 10px;
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
            width: 90%;
            height: 4000px;
            /*border: solid;
            border-color: aqua;*/
            text-align: center;
            margin-top: 2.5%;
            margin-left: 5%;
        }

        #content {
            height: 4000px;
            width: 80%;
            margin-left: 10%;
            /*border: solid;
            border-color: #E3E3E3;*/
        }

        #nextButtonContent {
            /*border: solid;
            border-color: aqua;*/
            width: 10%;
            height: 100px;
            margin-left: 80%;
            text-align: right;
            margin-top: 1.5%;
        }

        .nextButton {
            height: 55px;
            width: 200px;
            border-radius: 10px;
            font-size: 26px;
            font-family: Arial;
            background-color: #009999;
            font-weight: bold;
            border: none;
            color: white;
        }
    </style>
    <%-- CSS Style for Basic Content--%>
    <style>
        #basicDetailsContent {
            height: 11.5%;
            width: 100%;
            /*border: solid;
            border-color: #E3E3E3;*/
            background-color: white;
        }

        #basicDetailHeadingContent {
            /*border: solid;
            border-color: red;*/
            /*background-color: #4DB6AC;*/
            width: 100%;
            height: 25%;
            border-top-left-radius: 10px;
            border-top-right-radius: 10px;
            text-align: center;
            font-family: Arial;
            font-size: 3em;
            color: #003366;
            font-weight: bold;
            display: inline-block;
        }

        #basicDetailHeading {
            margin-top: 1.5%;
        }

        #basicDetailLeftContent {
            /*border: solid;
            border-color: red;*/
            height: 60%;
            width: 70%;
            float: left;
            background-color: white;
        }

        #basicDetailRightContent {
            /*border: solid;
            border-color: red;*/
            height: 60%;
            width: 29%;
            float: left;
            background-color: white;
        }

        #imageContent {
            /*border: solid;
            border-color: aqua;*/
            height: 54%;
            text-align: center;
            margin-top: 4%;
        }

        .labelContent {
            font-family: Arial;
            font-weight: bold;
            font-size: 30px;
            color: Black;
        }

        .dataContent {
            font-family: Arial;
            font-size: 30px;
            color: black;
        }

        #detailContent {
            height: 100%;
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
            width: 250px;
        }

     

        .bigButton {
            height: 55px;
            width: 250px;
            border-radius: 15px;
            font-size: 26px;
            font-family: Arial;
            background-color: #009999;
            font-weight: bold;
            border: none;
            color: white;
        }

        .backButtonContent {
            width: 20%;
            height: 15%;
            /*border: solid;
            border-color: red;*/
            float: right;
        }

        .nutritionDataContent {
            font-family: Arial;
            font-size: 22px;
            color: black;
        
        }
    </style>
    <%-- CSS Style for Ingredients Content--%>
    <style>
        #ingredientContent {
            height: 20%;
            width: 100%;
            margin-top: 2.5%;
            /*border: solid;
            border-color: #E3E3E3;*/
            background-color: white;
        }

        #ingredeientHeadingContent {
            /*background-color: #4DB6AC;*/
            width: 100%;
            height: 10%;
            border-top-left-radius: 10px;
            border-top-right-radius: 10px;
            text-align: center;
            font-family: Arial;
            font-size: 3em;
            color: Black;
            font-weight: bold;
            display: inline-block;
        }

       

        #ingredientBodyContent {
            height: 90%;
            width: 100%;
            /*border: solid;
            border-color: red;*/
            background-color: white;
        }

        #ingredientLeftContent {
            height: 100%;
            width: 40%;
            float: left;
            /*border: solid;
            border-color: #E3E3E3;*/
            margin-left: 4%;
         
        }

        #ingredientRightContent {
            height: 100%;
            width: 50%;
            float: left;
            /*border: solid;
            border-color: #E3E3E3;*/
            margin-left: 2.5%;
        
        }

        #Step2backButtonContent {
            width: 20%;
            height: 8%;
            /*border: solid;
            border-color: red;*/
            float: right;
         
        }

        #nutritionContent {
            width: 100%;
            height: 85%;
        }

        #nutritionHeading {
            width: 100%;
            height: 15%;
            /*background-color: #4DB6AC;*/
            float: left;
        }

        #nutritionHeadingDetails {
            text-align: center;
            font-family: Arial;
            font-size: 3em;
            color: #003366;
            margin-top: 1.5%;
            font-weight: bold;
        }

        #loiHeading {
            width: 100%;
            height: 15%;
            /*background-color: #4DB6AC;*/
            float: left;
        }

        #caption {
            font-size: 3em;
            font-family: Arial;
            /*background-color: #4DB6AC;*/
            color: #003366;
            text-align: center;
            font-weight: bold;
            height: 12%;
            width: 100%;
            float: left;
            margin-top: 2.5%;
        }

        .d {
            width: 90%;
            margin-left: 5%;
        }

        #GVContent {
            height: 80%;
            width: 100%;
            overflow: auto;
        }

        .Grid1 {
            width: 100%;
            height: 80%;
            font-family: Arial;
            font-size: 18px;
            color: black;
            float: left;
            overflow:auto;
        }

            .Grid1 td {
                padding: 20px;
                text-align: center;
                font-weight: bold;
                font-size: 22px;
                /*height: 30px;
                width: 120px;*/
            }

                .Grid1 td .pgr {
                    height: 10px;
                    width: 250px;
                }

            .Grid1 .pgr a {
                color: Gray;
                text-decoration: none;
                height: 10px;
            }


        </style>
    <%-- CSS Style for Cooking Instruction Content--%>
    <style>
        #cookingInstructionContent {
            height: 25%;
            width: 100%;
            margin-top: 2.5%;
            /*border: solid;
            border-color: #E3E3E3;*/
            background-color: white;
        }

        #cookingInstructionHeadContent {
            height: 6%;
            width: 100%;
            background-color: White;
       
            text-align: center;
              font-family: Arial;
            font-size: 3em;
            color: Black;
            font-weight: bold;
            display: inline-block;
        }

        #cookingInstructionHeadDetails {
            margin-top: 1.5%;
              color: #003366;
        }

        #cookingInstructionBodyContent {
            height: 77.5%;
            width: 90%;
            /*border: solid;
            border-color: red;*/
            margin-left: 5%;
            margin-top:5%;
          
        }

        #step3BackButton {
            width: 20%;
            height: 5%;
            /*border: solid;
            border-color: red;*/
            float: right;
        }

        .image {
            height: 120px;
            width: 150px;
        }
        .overFlow{
            overflow:auto;
            height:90%;
        }
    </style>
    <%-- CSS Style for Cooking Equipments Content--%>
    <style>
        #cookingEquipmentContent {
            height: 400px;
            width: 100%;
            margin-top: 2.5%;
            /*border: solid;
            border-color: #E3E3E3;*/
            background-color: white;
        }

        #cookingEquipmentHeadingContent {
            height: 20%;
            width: 100%;
            background-color: White;
            border-top-left-radius: 10px;
            border-top-right-radius: 10px;
            text-align: center;
            font-family: Arial;
            font-size: 3em;
            color: Black;
            font-weight: bold;
            display: inline-block;
        }

        #cookingEquipmentHeadingDetails {
            margin-top: 1.5%;
             color: #003366;
        }


        #cookingEquipmentBodyContent {
            height: 60%;
            width: 100%;
            /*border: solid;
            border-color: red;*/
            overflow: auto;
        }

        #step4BackButton {
            width: 20%;
            height: 5%;
            /*border: solid;
            border-color: red;*/
            float: right;
        }
        #gbButton{
            width:27.5%;
            margin-top:1.5%;
            float:right;
            /*border: solid;
            border-color: red;*/
        }
        .Grid2 {
            width: 100%;
            height: 100%;
            font-family: Arial;
            font-size: 30px;
            color: black;
            float: left;
        }



            /*.Grid1 th {
                font-size: 30px;
                font-family: Arial;
                background-color: #4DB6AC;
                color: White;
                height: 60px;
                text-align: left;
                font-weight: bold;
            }*/

            .Grid2 td {
                padding: 20px;
                text-align: center;
                font-weight: bold;
                font-size: 30px;
                /*height: 30px;
                width: 120px;*/
            }

                .Grid2 td .pgr {
                    height: 10px;
                    width: 250px;
                }

            .Grid2 .pgr a {
                color: Gray;
                text-decoration: none;
                height: 10px;
            }
    </style>
    <%--CSS Style for Assigned Day--%>
    <style>
        #assignedDayContent {
            height: 15%;
            width: 100%;
            margin-top: 2.5%;
            /*border: solid;
            border-color: #E3E3E3;*/
            background-color: white;
        }

        #assignDayHeading {
            height: 13.5%;
            width: 100%;
            background-color: White;
            border-top-left-radius: 10px;
            border-top-right-radius: 10px;
            text-align: center;
            font-family: Arial;
            font-size: 3em;
            color: Black;
            font-weight: bold;
            display: inline-block;
        }

        #assignDayHeadingDetails {
            margin-top: 1.5%;
             color: #003366;
        }

        .HeadingContent {
            border-color: #4DB6AC;
            background-color: #4DB6AC;
            width: 100%;
            height: 75px;
            border-top-left-radius: 10px;
            border-top-right-radius: 10px;
            text-align: center;
            font-family: Arial;
            font-size: 38px;
            color: #003366;
            font-weight: bold;
            display: inline-block;
        }

        .head {
            height: 22.5%;
            width: 100%;
            /*border: solid;
            border-color: red;*/
            text-align: left;
        }
          .head1 {
            height: 24.5%;
            width: 100%;
            /*border: solid;
            border-color: red;*/
            text-align: left;
        }

        .body {
            height: 75%;
            width: 100%;
            /*border: solid;
            border-color: red;*/
            text-align: left;
            overflow: auto;
        }
        
        .body1 {
            height: 73%;
            width: 100%;
            /*border: solid;
            border-color: red;*/
            text-align: left;
            overflow: auto;
        }
        .Part {
            /*border: solid;
            border-color: aqua;*/
            height: 30%;
            margin-top: 4.5%;
            width: 49%;
            float:left;
        }
        .Part1 {
            /*border: solid;
            border-color: aqua;*/
            height: 40%;
            margin-top: 4.5%;
            width: 100%;
            float:left;
        }
        #assignDayBody {
            height: 75%;
            width: 80%;
            margin-left: 10%;
            /*border: solid;
            border-color: red;*/
        }

        #step5BackButton {
            width: 20%;
            height: 5%;
            /*border: solid;
            border-color: red;*/
            float: right;
        }

        .Grid {
            width: 100%;
            height: 80%;
            font-family: Arial;
            font-size: 30px;
            color: black;
            float: left;
        }

            .Grid td {
                padding: 20px;
                text-align: left;
            
                font-size: 30px;
                /*height: 30px;
                width: 120px;*/
            }

                .Grid td .pgr {
                    height: 10px;
                    width: 250px;
                }

            .Grid .pgr a {
                color: Gray;
                text-decoration: none;
                height: 10px;
            }
    </style>
    <%--CSS Style for Nutrition Group--%>
    <style>
        #NutritionGroupContent {
            height: 8%;
            width: 100%;
            margin-top: 2.5%;
            border: solid;
            border-color: #E3E3E3;
        }

        #nutritonGroupHeading {
            height: 16%;
            width: 100%;
            background-color: #4DB6AC;
        }

        #nutritonGroupHeadingDetails {
            text-align: left;
            font-family: Arial;
            font-size: 34px;
            color: white;
            font-weight: bold;
            float: left;
            margin-top: 1.5%;
        }

        #nutritonGroupBody {
            height: 70%;
            width: 100%;
        }

        #step6BackButton {
            width: 20%;
            height: 5%;
            /*border: solid;
            border-color: red;*/
            float: right;
        }

        .auto-style8 {
            height: 26px;
        }
        .auto-style9 {
            height: 30px;
        }
             .dropdownlist {
            border-radius: 4px;
            border-color: black;
            border-width: 1.5px;
            height: 40px;
            width: 200px;
            font-size: 30px;
            color: black;
        }
    </style>
    <div class="loader"></div>
    <div id="headContent">
        <div id="title">
            View Recipe
        </div>
        <div id="titleDescription">
            Comprehend the nature of ingredients and coordinate them into Gorgeous Recipe 
        </div>
        <div id="divider">
            _____________________
        </div>
    </div>
    <div id="stepContent">
   
        <div id="step5Button">
            <asp:Button ID="BtnStep5" runat="server" Text="Edit Day Available" CssClass="bigButton" OnClick="BtnStep5_Click" BackColor="#009999" Height="65px" Width="250px" ForeColor="White" />
        </div>

        <div id="confirmationButton">
            <asp:Button ID="BtnConfirmation" runat="server" Text="Back" CssClass="bigButton" BackColor="#009999" ForeColor="White" Height="65px" Width="100px" OnClick="BtnConfirmation_Click" />
        </div>
    </div>
    <div id="mainContent">
        <div id="content">
            <div id="basicDetailsContent">
                <div id="basicDetailHeadingContent">
                    <div id="basicDetailHeading">
                        Basic Details
                         <div class="d">
                             <hr />
                         </div>
                    </div>
                </div>
                <div id="basicDetailLeftContent">
                    <div id="detailContent">

                        <table id="table">
                            <tr>
                                <td class="auto-style4">
                                    <asp:Label ID="Label2" runat="server" Text="Name:" CssClass="labelContent"></asp:Label>
                                </td>
                                <td class="auto-style7">
                                    <asp:Label ID="LblRecipeName" runat="server" CssClass="dataContent"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Duration:" CssClass="labelContent"></asp:Label></td>
                                <td>
                                    <asp:Label ID="LblDuration" runat="server" CssClass="dataContent"></asp:Label><asp:Label ID="Label8" runat="server" Text="-mins" CssClass="dataContent"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">
                                    <asp:Label ID="Label3" runat="server" Text="Type:" CssClass="labelContent"></asp:Label></td>
                                <td class="auto-style7">
                                    <asp:Label ID="LblRecipeType" runat="server" CssClass="dataContent"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label33" runat="server" Text="Cooking Type:" CssClass="labelContent"></asp:Label></td>
                                <td>
                                    <asp:Label ID="LblCookingType" runat="server" CssClass="dataContent"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="auto-style4">
                                    <asp:Label ID="Label4" runat="server" Text="Serves:" CssClass="labelContent"></asp:Label></td>
                                <td class="auto-style7">
                                    <asp:Label ID="LblServes" runat="server" CssClass="dataContent"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label41" runat="server" Text="Chef:" CssClass="labelContent"></asp:Label></td>
                                <td>
                                    <asp:Label ID="LblFounder" runat="server" CssClass="dataContent"></asp:Label></td>
                            </tr>
                        </table>

                    </div>

                </div>
                <div id="basicDetailRightContent">
                    <div id="imageContent">

                        <asp:Image ID="ImgRecipe" runat="server" Height="180px" Width="210px" />
                    </div>

                </div>
             <%--   <div class="backButtonContent">
                    <asp:Button ID="Button1" runat="server" Text="Go back to Step 1" CssClass="bigButton" OnClick="Button1_Click" />
                </div>--%>
            </div>
            <div id="ingredientContent">
              
                <div id="ingredientBodyContent">
                    <div id="ingredientLeftContent">
                        <div id="loiHeading">
                            <div id="caption">
                                List of Ingredients
                            <div class="d">
                                <hr />
                            </div>
                            </div>
                        </div>
                        <div id="GVContent">
                            <asp:GridView ID="GVSelectedIngredient" runat="server" AutoGenerateColumns="False" CssClass="Grid1" CellPadding="2" GridLines="None" DataKeyNames="IngredientName" AutoPostBack="true" PageSize="11">
                                <Columns>
                                    <asp:BoundField DataField="Quantity" />
                                    <asp:BoundField DataField="Measurement" />
                                    <asp:BoundField DataField="IngredientName" ReadOnly="True" ShowHeader="false" />
                                </Columns>

                            </asp:GridView>
                        </div>

                    </div>
                    <div id="ingredientRightContent">
                        <div id="nutritionHeading">
                            <div id="nutritionHeadingDetails">
                                Nutrition Facts
                                 <div class="d">
                                     <hr />
                                 </div>
                            </div>
                        </div>
                        <div id="nutritionContent">

             

                            <table class="table">
                                <tr>
                                    <td>    <asp:Label ID="Label45" runat="server" CssClass="nutritionDataContent" Text="Total Calories:" Font-Bold="True" ></asp:Label>
                                        <asp:Label ID="LblTotalCalories" runat="server" CssClass="nutritionDataContent" Text="Label" Font-Bold="True"></asp:Label>
                                        <asp:Label ID="LblTotalCalories0" runat="server" CssClass="nutritionDataContent" Text="Kcal" Font-Bold="True"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td><hr /></td>
                                </tr>
                                <tr>
                                    <td> <asp:Label ID="Label38" runat="server" CssClass="nutritionDataContent" Text="Total Fat:" Font-Bold="True"></asp:Label>
                                        <asp:Label ID="LblTotalFat" runat="server" CssClass="nutritionDataContent" Text="Label" Font-Bold="True"></asp:Label>
                                        <asp:Label ID="LblTotalFat0" runat="server" CssClass="nutritionDataContent" Text="grams" Font-Bold="True"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="auto-style8"><asp:Label ID="Label36" runat="server" CssClass="nutritionDataContent" Text="Saturated Fat:"></asp:Label>
                                        <asp:Label ID="LblSaturatedFat" runat="server" CssClass="nutritionDataContent" Text="Label"></asp:Label>
                                        <asp:Label ID="LblSaturatedFat0" runat="server" CssClass="nutritionDataContent" Text="grams"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="Label34" runat="server" CssClass="nutritionDataContent" Text="Trans Fat:"></asp:Label>
                                        <asp:Label ID="LblTransFat" runat="server" CssClass="nutritionDataContent" Text="Label"></asp:Label>
                                        <asp:Label ID="LblTransFat0" runat="server" CssClass="nutritionDataContent" Text="grams"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><hr /></td>
                                </tr>
                                <tr>
                                    <td>  <asp:Label ID="Label30" runat="server" Text="Cholesterol:" CssClass="nutritionDataContent" Font-Bold="False"></asp:Label>
                                        <asp:Label ID="LblCholesterol" runat="server" CssClass="nutritionDataContent" Text="Label"></asp:Label>
                                        <asp:Label ID="LblCholesterol0" runat="server" CssClass="nutritionDataContent" Text="mg"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td><hr /></td>
                                </tr>
                                <tr>
                                    <td>   <asp:Label ID="Label29" runat="server" Text="Sodium:" CssClass="nutritionDataContent" Font-Bold="False" ></asp:Label>
                                        <asp:Label ID="LblSodium" runat="server" CssClass="nutritionDataContent" Text="Label"></asp:Label>
                                        <asp:Label ID="LblSodium0" runat="server" CssClass="nutritionDataContent" Text="mg"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td><hr /></td>
                                </tr>
                                <tr>
                                    <td class="auto-style9">  <asp:Label ID="Label44" runat="server" CssClass="nutritionDataContent" Text="Carbohydrates:" Font-Bold="True"></asp:Label>
                                        <asp:Label ID="LblCarbohydrates" runat="server" CssClass="nutritionDataContent" Text="Label" Font-Bold="True"></asp:Label>
                                        <asp:Label ID="LblCarbohydrates0" runat="server" CssClass="nutritionDataContent" Text="grams" Font-Bold="True"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>  <asp:Label ID="Label42" runat="server" CssClass="nutritionDataContent" Text="Dietary Fiber:"></asp:Label>
                                        <asp:Label ID="LblDietaryFiber" runat="server" CssClass="nutritionDataContent" Text="Label"></asp:Label>
                                        <asp:Label ID="LblDietaryFiber0" runat="server" CssClass="nutritionDataContent" Text="grams"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td> <asp:Label ID="Label40" runat="server" CssClass="nutritionDataContent" Text="Sugar:"></asp:Label>
                                        <asp:Label ID="LblSugar" runat="server" CssClass="nutritionDataContent" Text="Label"></asp:Label>
                                        <asp:Label ID="LblSugar0" runat="server" CssClass="nutritionDataContent" Text="grams"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td><hr /></td>
                                </tr>
                                <tr>
                                    <td>  <asp:Label ID="Label28" runat="server" Text="Proteins:" CssClass="nutritionDataContent" Font-Bold="True"></asp:Label>
                                        <asp:Label ID="LblProteins" runat="server" CssClass="nutritionDataContent" Text="Label" Font-Bold="True"></asp:Label>
                                        <asp:Label ID="LblProteins0" runat="server" CssClass="nutritionDataContent" Text="grams" Font-Bold="True"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td><hr /></td>
                                </tr>
                            </table>

                        </div>
                    </div>

                </div>
              <%--  <div id="Step2backButtonContent">
                    <asp:Button ID="Button2" runat="server" Text="Go back to step 2" CssClass="bigButton" OnClick="Button2_Click" />
                </div>--%>
            </div>
            <div id="cookingInstructionContent">
                <div id="cookingInstructionHeadContent">
                    <div id="cookingInstructionHeadDetails">
                        Cooking Instruction
                          <div class="d">
                             <hr />
                         </div>
                    </div>
                </div>
                <div id="cookingInstructionBodyContent">
                 

                    <table class="auto-style1">
                        <tr>
                            <td style="width:250px;text-align:center">
                                <asp:Label ID="Label" runat="server" Font-Bold="True" Text="Steps" Font-Size="30px" ForeColor="Black" Font-Names="Arial"></asp:Label>
                            </td>
                            <td style="text-align:left;">
                                <asp:Label runat="server" CssClass="labelContent" Font-Bold="True" Text="Instructions" Font-Size="30px" ForeColor="Black" Font-Names="Arial"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <div class="overFlow">
                    <asp:GridView ID="GVCookingInstruction" runat="server" AutoGenerateColumns="False" CssClass="Grid1" CellPadding="2" GridLines="None" AutoPostBack="true" >
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>

                                    <table class="auto-style1" >
                                        <tr>
                                            <td style="width:180px;text-align:center">
                                                <asp:Label ID="LblStep" runat="server" Text='<%# Eval("stepNumber") %>' Font-Size="30px" Font-Bold="False"></asp:Label>
                                            </td>
                                            <td style ="text-align:left;">
                                                <asp:Label ID="LblCookingInstruction" runat="server" Text='<%# Eval("stepInstruction") %>' Font-Size="30px" Font-Bold="False"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>

                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>
                 
</div>                 

                </div>
               <%-- <div id="step3BackButton">
                    <asp:Button ID="Button3" runat="server" Text="Go back to step 3" CssClass="bigButton" OnClick="Button3_Click" />
                </div>--%>

            </div>
            <div id="cookingEquipmentContent">
                <div id="cookingEquipmentHeadingContent">
                    <div id="cookingEquipmentHeadingDetails">
                        Cookware Required
                         <div class="d">
                             <hr />
                         </div>
                    </div>
                </div>
                <div id="cookingEquipmentBodyContent">

                    <asp:GridView ID="GVCookingEquipmentSelection" runat="server" CaptionAlign="Left" AutoGenerateColumns="False" CssClass="Grid2" CellPadding="0" PageSize="6" GridLines="None">
                        <Columns>

                            <asp:BoundField DataField="Name" ReadOnly="True" ShowHeader="False" />

                        </Columns>

                        <PagerStyle BackColor="White" CssClass="pgr" />

                    </asp:GridView>

                </div>
           <%--     <div id="step4BackButton">
                    <asp:Button ID="Button4" runat="server" Text="Go back to step 4" CssClass="bigButton" OnClick="Button4_Click" />
                </div>--%>
            </div>
            <div id="assignedDayContent">
                <div id="assignDayHeading">
                    <div id="assignDayHeadingDetails">
                        Remarks
                           <div class="d">
                             <hr />
                         </div>
                    </div>
                </div>
                <div id="assignDayBody">
                    <div class="Part">
                        <div class="head">
                            <asp:Label ID="LblAllergens" runat="server" Text="Allergens" CssClass="labelContent"></asp:Label>
                            <br />
                            <br />
                        </div>
                        <div class="body">
                            <asp:GridView ID="GVAllergens" runat="server" AutoGenerateColumns="False" CssClass="Grid" CellPadding="2" GridLines="None" Visible="False">
                                <Columns>
                                    <asp:BoundField DataField="FoodAllergyName" />
                                </Columns>
                            </asp:GridView>
                            <br />
                            <br />
                              <asp:Label ID="LblAllergen" runat="server" CssClass="labelContent" Font-Bold="False" Font-Size="30px"></asp:Label>
                        </div>
                    </div>
                    <div class="Part">
                        <div class="head">
                            <asp:Label ID="LblTailored" runat="server" Text="Suitable For" CssClass="labelContent"></asp:Label>
                            <br />
                            <br />
                        </div>
                        <div class="body">
                            <asp:GridView ID="GVMedicalCondition" runat="server" AutoGenerateColumns="False" CssClass="Grid" CellPadding="2" GridLines="None" Visible="False">
                                <Columns>
                                    <asp:BoundField DataField="TagsMedicalCondition" />
                                </Columns>
                            </asp:GridView>
                            <br />
                            <br />
                            <asp:Label ID="LblMedicalCondition" runat="server" CssClass="labelContent" Font-Bold="False" Font-Size="30px"></asp:Label>
                        </div>
                    </div>
                    <div class="Part1">
                        <div class="head1">
                            <asp:Label ID="LblRecipeSchedule" runat="server" Text="Day Available" CssClass="labelContent"></asp:Label></div>
                        <div class="body1">
                            <br />
                            <br />
                          
                            <asp:DropDownList ID="DDLSchedule" runat="server" CssClass="dropdownlist">
                               
                                 <asp:ListItem Value="1">Monday</asp:ListItem>
                                 <asp:ListItem Value="2">Tuesday</asp:ListItem>
                                 <asp:ListItem Value="3">Wednesday</asp:ListItem>
                                 <asp:ListItem Value="4">Thursday</asp:ListItem>
                                 <asp:ListItem Value="5">Friday</asp:ListItem>
                                 <asp:ListItem Value="6">Saturday</asp:ListItem>
                                 <asp:ListItem Value="7">Sunday</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="Label5" runat="server" Width="10px" ></asp:Label>
                            <asp:Label ID="LblSchedule" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="30px" ForeColor="Black">*Select the recipe new Available Day and click the Update Button</asp:Label>
                        </div>
                       
                    </div>
                       
                </div>
                <div id="step5BackButton">
                    <asp:Button ID="Button5" runat="server" Text="Update" CssClass="bigButton" Width="150px" OnClick="Button5_Click" />
                </div>
            </div>
         <div id="gbButton">
                    <asp:Button ID="Button1" runat="server" Text="Go Back to Search Recipes" CssClass="bigButton" Width="375px" OnClick="Button1_Click1" />
                </div>
        </div>

    </div>
</asp:Content>
