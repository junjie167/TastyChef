<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminInsertRecipeStep2.aspx.cs" Inherits="TastyChef.AdminInsertRecipeStep2" %>

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
            height: 1500px;
            /*border: solid;
            border-color: aqua;*/
            text-align: center;
            margin-top: 2.5%;
            margin-left: 20%;
        }

        #nextButtonContent {
            /*border: solid;
            border-color: aqua;*/
            width: 18%;
            height: 100px;
            margin-right: 20%;
            text-align: right;
            margin-top: 0.5%;
            float: right;
        }

        #backButtonContent {
            /*border: solid;
            border-color: aqua;*/
            width: 10%;
            height: 100px;
            text-align: right;
            margin-top: 0.5%;
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
            width: 350px;
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
        #topLeftContent {
            /*border: groove;
            border-color: #E3E3E3;*/
            height: 85%;
            width: 35%;
            float: left;
            margin-left:5%;
          
        }


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
            font-size: 25px;
            color: black;
        }


        .tb {
            border-radius: 5px;
            border-color: black;
            border-width: 1.5px;
            font-size: 20px;
            color: black;
            height: 35px;
            width: 300px;
        }

        .dropdownlist {
            border-radius: 4px;
            border-color: black;
            border-width: 1.5px;
            height: 35px;
            width: 300px;
            font-size: 20px;
            color: black;
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
            height: 500px;
            width: 100%;
             /*border: 2px solid #4DB6AC;*/
                background-color: White;
            
        }
             .bottomContent{
            
            width: 100%;
            height: 900px;
             /*border: 2px solid #4DB6AC;
              
            border-radius: 12px;*/
              background-color: White;
            margin-top:7.5%;
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
            margin-top:1.5%;
        }
        #topRightContent {
            /*border: groove;
            border-color: #E3E3E3;*/
            height: 85%;
            width: 58%;
            float: left;
          
        }

        #ingredientSelectionContent {
            /*border: groove;
            border-color: #E3E3E3;*/
            height: 77%;
            width: 95%;
           
            margin-top: -15.5%;
            overflow:auto;
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
            border: 2px solid #4DB6AC;
              
            border-radius: 12px;
        }



            .Grid th {
                font-size: 30px;
                font-family: Arial;
                background-color: #4DB6AC;
                color: White;
                height: 60px;
                text-align: left;
                font-weight: bold;
            }

            .Grid td {
                padding: 1px;
                text-align: left;
                font-weight: bold;
                font-size: 20px;
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
              /*border: 1px solid #4DB6AC;
            box-shadow: 5px 5px #4DB6AC;
           
            border-radius:10px;*/
            height: 80%;
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
    </style>
    <%--CSS Style for bottomRightContent--%>
    <style>
        #selectedIngredientContent {
            /*border: groove;
            border-color: red;*/
            height: 100%;
            width: 100%;
            float: left;
              overflow: auto;
            
       
        }

        .auto-style4 {
            width: 100%;
            height: 100%;
        }
        .Grid1 {
         
            width: 100%;
            height: 100%;
            font-family: Arial;
            font-size: 18px;
            color: black;
  
            
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

            .Grid1 td {
                padding: 1px;
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
            .Grid1 caption{
                 font-size: 36px;
                font-family: Arial;
                background-color: White;
                color: #003366;
                height: 60px;
                text-align: center;
                font-weight: bold;
            }


            .Grid1 .pgr table {
                text-align: "left";
                height: 10px;
                width: 70px;
            }

            .Grid1 .pgr a:hover {
                color: #4DB6AC;
                text-decoration: none;
            }
              .d {
            width: 90%;
            margin-left: 5%;
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
            <asp:Button ID="BtnStep2" runat="server" Text="Step 2" CssClass="stepButton" BackColor="#009999" ForeColor="White" />
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
    <div id="recipeHeading">
        <asp:Label ID="LblRecipeName" runat="server" ForeColor="#003366"></asp:Label>
    </div>
    <div id="mainContent">
        <div class="topContent">
             <div class="HeadingContent">
                &nbsp;<asp:Label ID="Label1" runat="server" Text="Specify " ForeColor="#003366" Font-Bold="True"></asp:Label>
          
                <asp:Label ID="Label2" runat="server" Text=" Ingredients" ForeColor="#003366" Font-Bold="True"></asp:Label>
            </div>
            <div class="d">
                             <hr />
                         </div>
        <div id="topLeftContent">
           

         
            <div id="searchContent">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <table class="auto-style4">
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text=" Search by Ingredient Name" CssClass="labelContent"></asp:Label>
                            <br />
                            <br />
                            <asp:TextBox ID="TbSearchIngredientName" runat="server" CssClass="tb" placeholder="Ingredient Name"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Search by Category" CssClass="labelContent"></asp:Label>
                            <br />
                            <br />
                            <asp:DropDownList ID="DDlIngredientsCategory" runat="server" CssClass="dropdownlist">
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
                        <td>

                            <asp:Button ID="BtnFindIngredients" runat="server" Text="Search Ingredients" CssClass="bigButton" OnClick="BtnFindIngredients_Click" />
                        </td>
                    </tr>
                </table>

            </div>
        </div>
        <div id="topRightContent">

            <div id="continueEndButtonContent" visible="True">
                <asp:Label ID="LblNoRecordFound" runat="server" Visible="False" Text="No Ingredients Found!" Font-Bold="True" Font-Size="XX-Large" ForeColor="Red"></asp:Label>
                <br />
                <asp:Label ID="LblClick" runat="server" Text="Click " CssClass="labelContent" Visible="False" Font-Bold="True" ForeColor="#003366"></asp:Label>
                <asp:LinkButton ID="LBAddNewIngredient" runat="server" CssClass="labelContent" Visible="False" OnClick="LBAddNewIngredient_Click">New Ingredients</asp:LinkButton>

                <asp:Label ID="LblClick2" runat="server" Text="to add new ingredients into our Recipe Repository " CssClass="labelContent" Visible="False" ForeColor="Red"></asp:Label>
                <br />
                <br />
                <br />
                <asp:Button ID="BtnContinue" runat="server" Text="Add More Ingredients" CssClass="nextButton" Width="360px" Visible="False" OnClick="BtnContinue_Click" />

                <br />
                <br />
                <asp:Label ID="Lblingredient" runat="server" Text="Scroll down to view selected ingredients " Visible="False" Font-Bold="True" Font-Size="30px" ForeColor="#003366"></asp:Label>

            </div>
            <div id="ingredientSelectionContent">

                <asp:GridView ID="GVIngredientSelection" runat="server" CaptionAlign="Left" AutoGenerateColumns="False" CssClass="Grid" AllowPaging="True" CellPadding="0" PageSize="3" OnSelectedIndexChanged="GVIngredientSelection_SelectedIndexChanged" GridLines="Horizontal">
                    <Columns>
                        <asp:ImageField DataImageUrlField="Image" HeaderText="Result">
                            <ControlStyle Height="90px" Width="120px"></ControlStyle>
                        </asp:ImageField>
                        <asp:BoundField DataField="IngredientName" ReadOnly="True" />
                         
                        <asp:TemplateField>
                            <ItemTemplate>

                                <asp:TextBox ID="TbIngredientQty" runat="server" Height="35" Width="40" TextMode="Number" CssClass="tb" onblur="checknegative1(this)" CausesValidation="True" ValidationGroup="a"></asp:TextBox>
                                <asp:Label ID="LblMeasurement" runat="server" Text='<%# Eval("Measurement")%>' ></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="TbIngredientQty" Font-Bold="True" ValidationGroup="a"></asp:RequiredFieldValidator>
                            </ItemTemplate>
                        </asp:TemplateField>


                     
                        

                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/SelectButton.PNG" ShowSelectButton="True" ValidationGroup="a" CausesValidation="True" />
                    </Columns>

                    <PagerStyle BackColor="White" CssClass="pgr" />

                </asp:GridView>

            </div>

        </div>
            </div>
       
      
        <div class="bottomContent">
              <div class="HeadingContent">
                &nbsp;<asp:Label ID="Label6" runat="server" Text=" List of Ingredients" Font-Bold="True"></asp:Label>
            </div>
              <div class="d">
                             <hr />
                         </div>
        <div id="bottomLeftContent">
            

            <div id="selectedIngredientContent">

                <asp:GridView ID="GVSelectedIngredient" runat="server" AutoGenerateColumns="False" CssClass="Grid1" CellPadding="2" GridLines="None" DataKeyNames="IngredientName" AutoPostBack="true" PageSize="11" OnSelectedIndexChanged="GVSelectedIngredient_SelectedIndexChanged">
                    <Columns>
                      
                       
                        <asp:TemplateField>
                            <ItemTemplate>

                                <asp:TextBox ID="TbIngredientQty" runat="server" Height="30" Width="80" TextMode="Number" CssClass="tb" Text='<%# Eval("Quantity")%>' onblur="checknegative1(this)"></asp:TextBox>

                            </ItemTemplate>
                        </asp:TemplateField>


                     
                         <asp:BoundField DataField="Measurement" />


                     
                         <asp:BoundField DataField="IngredientName"  ReadOnly="True" ShowHeader="false"/>
                        
                       
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/RemoveButton.PNG" ShowSelectButton="True" />

                        
                       
                    </Columns>
                    
                </asp:GridView>
              
            </div>

        </div>

    </div>
        </div>

    <div id="nextButtonContent">
        <asp:Button ID="BtnStep2Next" runat="server" Text="Proceed to Step 3" CssClass="nextButtonNext" OnClick="BtnStep1Next_Click" />


    </div>
    <div id="backButtonContent">
        <asp:Button ID="Button1" runat="server" Text="Back" CssClass="nextButton" OnClick="Button1_Click" />
    </div>
</asp:Content>
