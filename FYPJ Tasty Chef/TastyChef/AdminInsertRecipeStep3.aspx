<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminInsertRecipeStep3.aspx.cs" Inherits="TastyChef.AdminInsertRecipeStep3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="myControls" Namespace="TastyChef.DAL" Assembly="TastyChef" %>

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
        .edit{
            height:100%;
            width:100%;
           
            border:1px solid black;
                border-top-left-radius: 5px;
            border-top-right-radius: 5px;
                 border-bottom-left-radius: 5px;
            border-bottom-right-radius: 5px;
            display:block;
                font-size:30px;
            /*border: solid;
            border-color: aqua;*/
        
        }
        .edit input{
            font-size:30px;
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
            width: 70%;
            margin-left: 15%;
            height: 900px;
            /*border: solid;
            border-color: aqua;*/
            text-align: center;
            margin-top: 2.5%;
            /*border: 2px solid #4DB6AC;
            background-color: White;
            border-radius: 12px;*/
        }

        #recipeHeading {
            /*border: groove;
            border-color: #E3E3E3;*/
            width: 100%;
            height: 10%;
            text-align: center;
            font-family: Arial;
            font-size: 48px;
            font-weight: bold;
            margin-top: 1.5%;
            color: #003366;
        }


        #nextButtonContent {
            /*border: solid;
            border-color: aqua;*/
            width: 18%;
            height: 100px;
            margin-right: 10%;
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
            margin-right: 2%;
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
    </style>
    <%-- CSS Style for Cooking Instruction Content--%>
    <style>
        #cookingInstructionsContent {
            /*border: solid;
            border-color: red;*/
            width: 80%;
            height: 100%;
            margin-left: 10%;
          
            background-color: White;
           
        }

        #basicDetailContent {
            width: 80%;
            height: 100%;
            margin-left: 10%;
        }

        #basicDetailHeadingContent {
            /*border: solid;
            border-color: aqua;*/
            border-color: #4DB6AC;
            background-color: white;
            width: 100%;
            height: 15%;
           float:left;
           
         
        }

        #basicDetailHeading {
            /*border: solid;
            border-color: aqua;*/
            text-align: center;
            font-family: Arial;
            font-size: 3em;
            color:#003366;
            font-weight: bold;
           margin-top:2%;
            height:50%;
            width:100%;
            float:left;
        }

        #cookingInstructionMainContent {
            /*border: groove;
            border-color: purple;*/
            height: 10%;
            width: 90%;
            margin-left:5%;
            float: left;
            /*border: 2px solid #4DB6AC;
            background-color: White;
            border-radius: 12px*/
        }

        #cookingInstructionLeftContent {
            height: 10%;
            width: 65%;
            float: left;
            /*border: groove;
            border-color: navy;*/
             margin-left:5%;
            width: 90%;
        }

        #centerContent {
            /*border: groove;
            border-color: navy;*/
            height: 80%;
            width: 99%;
            float: right;
        }

        #imageContent {
            /*border: solid;
            border-color: aqua;*/
            height: 100%;
            text-align: left;
     width:100%;
        }

        .labelContent {
            font-family: Arial;
            font-size: 30px;
            color: black;
        }

        .tb {
            border-radius: 5px;
            border-color: grey;
            border-width: 2.5px;
            font-size: 20px;
            color: black;
            height: 200px;
            width: 450px;
        }

        .tbNumber {
            border-radius: 5px;
            border-color: lightgrey;
            border-width: 1.5px;
            font-size: 20px;
            color: black;
            height: 35px;
            width: 250px;
        }

        .auto-style4 {
            width: 100%;
            height: 100%;
        }

        .auto-style5 {
            text-align: left;
        }

        .dropdownlist {
            border-radius: 4px;
            border-color: black;
            border-width: 1.5px;
            height: 40px;
            width: 100px;
            font-size: 22px;
            color: grey;
        }

        #editorContent {
            /*border: solid;
            border-color: aqua;*/
            height: 80%;
            text-align: left;
            float: left;
            width: 90%;
            margin-left:5%;
        }

        #editor {
            /*border: 1px solid #4DB6AC;
            box-shadow: 5px 5px #4DB6AC;*/
              border-top-left-radius: 5px;
            border-top-right-radius:5px;
            font-size:30px;
            height:80%;
        }
        .e{
              border-top-left-radius: 5px;
            border-top-right-radius: 5px;
             border-bottom-left-radius: 5px;
            border-bottom-right-radius: 5px;
              border: 1px solid Black;
        }
      
        #saveButton {
            text-align: right;
            margin-top: 2%;
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
            <asp:Button ID="BtnStep3" runat="server" Text="Step 3" CssClass="stepButton" BackColor="#009999" ForeColor="White" />
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
        <div id="recipeHeading">
            <asp:Label ID="LblRecipeName" runat="server" Text="(Recipe Name)"></asp:Label>
        </div>
        <div id="cookingInstructionsContent">
            <div id="basicDetailHeadingContent">
                <div id="basicDetailHeading">
                    Cooking Instruction
                </div>

                 <div class="d">
                             <hr />
                         </div>
            </div>
            <div id="centerContent">
                <div id="cookingInstructionLeftContent">
                    <div id="imageContent">
                        <asp:Label ID="LblInstruction" runat="server" CssClass="labelContent" Text="Paste the cooking instuction below and " Font-Bold="True" ForeColor="Black" Font-Size="25px"></asp:Label>
                 
                           <asp:Label ID="Label3" runat="server" CssClass="labelContent" Text="click save" Font-Bold="True" ForeColor="Red" Font-Size="25px"></asp:Label>
                          <asp:Label ID="Label4" runat="server" CssClass="labelContent" Text=" to store your work." Font-Bold="True" ForeColor="Black" Font-Size="25px"></asp:Label>
                    </div>
                </div>
                <div id="cookingInstructionMainContent">

                    <table class="auto-style4">
                        <tr>
                            <td class="auto-style5">
                                <%--   <asp:Label ID="Label3" runat="server" Text="Image Upload" CssClass="labelContent"></asp:Label>
                                <br />
                                <asp:FileUpload ID="FileUploadCookingInstructionImage" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Large" />
                                <br />
                                180 x 210
                    <br />
                                <asp:Image ID="ImgCookingInstrucion" runat="server" Height="180px" Width="210px" />--%>

                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Steps:" CssClass="labelContent"></asp:Label>


                                <asp:DropDownList ID="DDlStep" runat="server" CssClass="dropdownlist" AutoPostBack="True" OnSelectedIndexChanged="DDlStep_SelectedIndexChanged">
                                </asp:DropDownList>
                                <br />
                               
                                <br />

                            </td>

                        </tr>

                    </table>

                </div>
                
                <div id="editorContent">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Instruction:" CssClass="labelContent"></asp:Label>
                    <br />
                    <br />
                    <div id="editor">
                      
                        <%--<cc1:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server"></cc1:ToolkitScriptManager>
                        <cc2:Editor ID="Editor1" runat="server" />--%>
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <myControls:CustomEditor ID="Editor1" 
                         
                            runat="server" CssClass="e" placeholder="Paste Here" />
                         <asp:Label ID="LblErrorMessage" runat="server" Font-Size="24px" Visible="False" ForeColor="Red" Font-Bold="True"></asp:Label>
                    </div>
                    <div id="saveButton">
                        <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="nextButton" OnClick="BtnUpdate_Click" Visible="False" />
                        <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="nextButton" OnClick="BtnSave_Click" ValidationGroup="b" />
                    </div>
                </div>
            </div>
        </div>
        <div id="nextButtonContent">
            <asp:Button ID="BtnStep3Next" runat="server" Text="Proceed to Step 4" CssClass="nextButtonNext" OnClick="BtnStep3Next_Click" />


        </div>
        <div id="backButtonContent">
            <asp:Button ID="Button1" runat="server" Text="Back" CssClass="nextButton" OnClick="Button1_Click" />
        </div>
    </div>
</asp:Content>
