<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminInsertRecipeStep4.aspx.cs" Inherits="TastyChef.AdminInsertRecipeStep4" %>
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
            font-weight:bold;
        }

        #titleDescription {
            font-family: Arial;
            font-size: 28px;
            color: grey;
        }

        #divider {
            color: black;
        }
        #errorMessageContent{
            text-align:right;
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
            width: 60%;
            height: 820px;
            /*border: solid;
            border-color: aqua;*/
            text-align: center;
            margin-top: 2.5%;
            margin-left: 20%;
        }

        #nextButtonContent {
            /*border: solid;
            border-color: aqua;*/
            width: 20%;
            height: 60px;
         
            text-align: right;
       
            float: right;
        }

        #backButtonContent {
            /*border: solid;
            border-color: aqua;*/
            width: 10%;
            height: 60px;
            text-align: right;
              margin-right: 2%;
            float: right;
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
            width: 250px;
            border-radius: 10px;
            font-size: 26px;
            font-family: Arial;
            background-color: #009999;
            font-weight: bold;
            border: none;
            color: white;
        }

        #recipeHeading {
            /*border: groove;
            border-color: #E3E3E3;*/
            width: 100%;
            height: 15%;
            text-align: center;
            font-family: Arial;
            font-size: 48px;
            font-weight: bold;
            margin-top: 1.5%;
            /*background-color:white;*/
        }

        .part {
            /*border: groove;
            border-color: #E3E3E3;*/
            width: 100%;
            text-align: center;
            font-family: Arial;
            font-size: 36px;
            font-weight: bold;
            color: black;
        }

        #hr {
            width: 100%;
            float: left;
            height:100px;
            /*border: groove;
            border-color: #E3E3E3;*/
        }
    </style>
    <%--CSS Style for Top Left Content--%>
    <style>
        


        #searchContent {
            width: 90%;
            height: 80%;
            margin-left: 5%;
            border: 1px solid #4DB6AC;
            box-shadow: 5px 5px #4DB6AC;
            float: left;
          margin-top:5%;
            background-color:white;
                 border-radius: 10px;
        }

        .labelContent {
            font-family: Arial;
            font-size: 24px;
            color: black;
        }


        .tb {
            border-radius: 5px;
            border-color: lightgrey;
            border-width: 1.5px;
            font-size: 20px;
            color: black;
            height: 35px;
            width: 300px;
        }

        .dropdownlist {
            border-radius: 4px;
            border-color: lightgrey;
            border-width: 1.5px;
            height: 35px;
            width: 300px;
            font-size: 20px;
            color: grey;
        }

        .bigButton {
            height: 55px;
            width: 300px;
            border-radius: 20px;
            font-size: 26px;
            font-family: Arial;
            background-color: #009999;
            font-weight: bold;
            border: none;
            color: white;
        }
    </style>
    <%--CSS Style for topRightContent--%>
    <style>
        .topContent{
            height: 100%;
            width: 100%;
             /*border: 2px solid #4DB6AC;*/
                background-color: White;
            /*border-radius: 12px;*/
        }
        

        .HeadingContent {
            border-color: #4DB6AC;
            background-color: White;
            width: 100%;
            height: 75px;
        
             text-align: center;
            font-family: Arial;
            font-size: 3em;
            color: #003366;
            font-weight: bold;
            display:inline-block;
            margin-top:2%;
        }
 #topLeftContent {
            /*border: groove;
            border-color: #E3E3E3;*/
            height: 88%;
            width: 90%;
            float: left;
            margin-left:5%;
          
        }

        #ingredientSelectionContent {
            /*border: groove;
            border-color: #E3E3E3;*/
            height: 100%;
            width: 100%;
           
        margin-top:1%;
            overflow:auto;
        }
        #instructionContent{
             height: 5%;
            width: 100%;
            margin-top:2%;
        }

        #addNewIngredientButtonContent {
            /*border: groove;
            border-color: #E3E3E3;*/
            width: 50%;
            float: right;
            height: 12%;
            text-align: right;
        }

        .Grid {
            width: 100%;
            height: 70%;
            font-family: Arial;
            font-size: 18px;
            color: black;
            /*border: 2px solid #4DB6AC;
              
            border-radius: 12px;*/
        }




            .Grid td {
                padding: 1px;
                text-align: left;
                font-weight: bold;
                font-size: 30px;
                /*height: 100px;*/
                width: 150px;
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


            .Grid .pgr table {
                text-align: "left";
                height: 10px;
                width: 70px;
            }

            .Grid .pgr a:hover {
                color: #4DB6AC;
                text-decoration: none;
            }

        #continueEndButtonContent {
            height: 15%;
            width: 100%;
            /*border: groove;
            border-color: #E3E3E3;*/
            margin-top: 10%;
            text-align: center;
        }
    </style>
    <%--CSS Style for bottomLeftContent--%>
    <style>
        #bottomLeftContent {
              border: 1px solid #4DB6AC;
            box-shadow: 5px 5px #4DB6AC;
           
            border-radius:10px;
            height: 86%;
            width: 80%;
            float: left;
            margin-left:10%;
            background-color:white;
            margin-top:2%;
        }

        #nutritionFactContent {
            /*Cannot comment*/
            border: groove;
            border-color: #E3E3E3;
            border-width: 1px;
            height: 100%;
            width: 94%;
            margin-right: 3%;
        }

        #headingContent {
            /*border: groove;
            border-color: #E3E3E3;*/
            height: 9.5%;
            width: 100%;
            font-size: 34px;
            font-family: Arial;
            background-color: #4DB6AC;
            color: White;
            text-align: center;
        }

        #nutritionFactMainContent {
            /*border: groove;
            border-color: red;*/
            height: 88%;
            width: 100%;
        }

        .labelNContent {
            font-family: Arial;
            font-size: 18px;
            color: black;
        }

        .labelGramsContent {
            font-family: Arial;
            font-size: 18px;
            color: black;
            font-weight: bold;
        }
         .mychk input
    {
          height:18px;
          width:18px;
    }
    </style>
   
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
                .d {
            width: 90%;
            margin-left: 5%;
        }

            </style>
    <div class="loader"></div>
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
            <asp:Button ID="BtnStep1" runat="server" Text="Step 1" CssClass="stepButton" />
        </div>
        <div id="step2Button">
            <asp:Button ID="BtnStep2" runat="server" Text="Step 2" CssClass="stepButton" />
        </div>
        <div id="step3Button">
            <asp:Button ID="BtnStep3" runat="server" Text="Step 3" CssClass="stepButton" />
        </div>
        <div id="step4Button">
            <asp:Button ID="BtnStep4" runat="server" Text="Step 4" CssClass="stepButton"  BackColor="#009999" ForeColor="White"/>
        </div>
        <div id="step5Button">
            <asp:Button ID="BtnStep5" runat="server" Text="Step 5" CssClass="stepButton" />
        </div>

        <div id="confirmationButton">
            <asp:Button ID="BtnConfirmation" runat="server" Text="Confirmation" CssClass="stepButton" />
        </div>
    </div>
    <div id="recipeHeading">
        <asp:Label ID="LblRecipeName" runat="server" ForeColor="#003366"></asp:Label>
    </div>
    <div id="mainContent">
        <div class="topContent">
             <div class="HeadingContent">
                &nbsp;<asp:Label ID="Label1" runat="server" Text="Specify Cookware " ForeColor="black" Font-Bold="True"></asp:Label>
          
                
            </div>
                        <div class="d">
                             <hr />
                         </div>
        <div id="topLeftContent">
           

<%--            <div id="instructionContent">
                <asp:Label ID="LblInstruction" runat="server" Text="Select the required Cookware and proceed to Step 5" CssClass="labelContent" Font-Bold="True" Font-Size="XX-Large" ForeColor="#003366"></asp:Label>
            </div>--%>
            <div id="ingredientSelectionContent">

                <asp:GridView ID="GVCookingEquipmentSelection" runat="server" CaptionAlign="Left" AutoGenerateColumns="False" CssClass="Grid" CellPadding="0" PageSize="6" GridLines="Horizontal">
                    <Columns>
                        <asp:ImageField DataImageUrlField="Image" ShowHeader="False">
                            <ControlStyle Height="90px" Width="120px"></ControlStyle>
                        </asp:ImageField>
                        <asp:BoundField DataField="Name" ReadOnly="True" ShowHeader="False" />
  
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:CheckBox ID="CBSelect" runat="server" CssClass="mychk" />
                            </ItemTemplate>
                        </asp:TemplateField>
  
                    </Columns>

                    <PagerStyle BackColor="White" CssClass="pgr" />

                </asp:GridView>
                <div id="errorMessageContent">
                 <asp:Label ID="LblErrorMessage" runat="server" Font-Bold="True" Font-Size="20px" ForeColor="Red" Text="*Select required Cookware" Font-Names="Arial" Visible="False"></asp:Label>

                </div>
            </div>
           
     
            </div>
        <div id="nextButtonContent">
        <asp:Button ID="BtnStep2Next" runat="server" Text="Proceed to Step 5" CssClass="nextButtonNext" OnClick="BtnStep2Next_Click"/>


    </div>
    <div id="backButtonContent">
        <asp:Button ID="Button1" runat="server" Text="Back" CssClass="nextButton"/>
    </div>
      </div>
     

    </div>

   
   
</asp:Content>
