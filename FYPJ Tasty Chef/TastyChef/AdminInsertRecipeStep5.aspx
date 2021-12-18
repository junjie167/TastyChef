<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminInsertRecipeStep5.aspx.cs" Inherits="TastyChef.AdminInsertRecipeStep5" %>

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
            height: 750px;
            /*border: solid;
            border-color: aqua;*/
            text-align: center;
            margin-top: 2.5%;
            margin-left: 20%;
        }

        #recipeHeading {
            width: 100%;
            height: 15%;
            text-align: center;
            font-family: Arial;
            font-size: 3em;
            font-weight: bold;
            margin-top: 1.5%;
        }

        #nextButtonContent {
            /*border: solid;
            border-color: aqua;*/
             width: 14%;
            height: 60px;
      margin-right:22.5%;
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
            margin-right:1%;
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
    </style>
    <%-- CSS Style for Available Day Content--%>
    <style>
      

        .labelContent {
            font-family: Arial;
            font-weight: bold;
            font-size: 30px;
            color: black;
        }
            .instructionContent {
            font-family: Arial;
    
            font-size: 24px;
            color: black;
        }
        .dropdownlist {
            border-radius: 4px;
            border-color: lightgrey;
            border-width: 2px;
            height: 35px;
            width: 200px;
            font-size: 22px;
            color: black;
        }
          .topContent{
            height: 100%;
            width: 100%;
            
                background-color:White;
            border-radius: 12px;
        }
        

        .HeadingContent {
           
            background-color: white;
            width: 100%;
            height: 75px;
     margin-top:2%;
             text-align: center;
            font-family: Arial;
            font-size: 3em;
            color: #003366;
            font-weight: bold;
            display:inline-block;
        }
        .BodyContent{
             /*border: solid;
            border-color: aqua;*/
             width: 90%;
             height:88%;
             margin-left:4%;

        }
        .Part{
             /*border: solid;
            border-color: aqua;*/
            height:30%;
            margin-top:1%;
            width:100%;

        }
        .head{
            height:30%;
            width:100%;
             /*border: solid;
            border-color: red;*/
            text-align:left;
            
        }
        .body{
            height:70%;
              width:100%;
              /*border: solid;
            border-color: red;*/
             text-align:left;
        }
        .d {
            width: 90%;
            margin-left: 5%;
        }
        
       
    </style>
    <%-- CSS Style for Nutrition Group Content--%>
    <style>
    

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

        .checkBox {
            font-size: 30px;
            font-family: Arial;
            color: black;
        }
        .checkBox input {
            height:22px;
            width:22px;
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
            <asp:Button ID="BtnStep4" runat="server" Text="Step 4" CssClass="stepButton" />
        </div>
        <div id="step5Button">
            <asp:Button ID="BtnStep5" runat="server" Text="Step 5" CssClass="stepButton" BackColor="#009999" ForeColor="White" />
        </div>

        <div id="confirmationButton">
            <asp:Button ID="BtnConfirmation" runat="server" Text="Confirmation" CssClass="stepButton" />
        </div>
    </div>
      <div id="recipeHeading">
            <asp:Label ID="LblRecipeName" runat="server" Text="(Recipe Name)" ForeColor="#003366"></asp:Label>
        </div>
    <div id="mainContent">
      <div class="topContent">
          <div class ="HeadingContent">
                &nbsp;<asp:Label ID="Label1" runat="server" Text="Remarks" Font-Bold="True"></asp:Label>
          </div>
            <div class="d">
                             <hr />
                         </div>
          <div class="BodyContent">
              <div class="Part">
                  <div class="head">
                  
                      <asp:Label ID="LblAllergens" runat="server" Text="Allergens" CssClass="labelContent" ></asp:Label>
                  </div>
                  <div class="body">
                      <asp:CheckBoxList ID="CBLAllergens" runat="server" CssClass="checkBox" RepeatDirection="Horizontal" CellPadding="10">
               
                      </asp:CheckBoxList>
                  </div>
              </div>
              <hr />
              <div class="Part">
                  <div class="head">
                         
                      <asp:Label ID="LblTailored" runat="server" Text="Suitable For" CssClass="labelContent" ></asp:Label>
                  </div>  
                   <div class="body">
                             <asp:CheckBoxList ID="CBLMedicalCondition" runat="server" CssClass="checkBox" RepeatDirection="Horizontal" CellPadding="20" CellSpacing="2">
                    
                        <asp:ListItem>Diabetes</asp:ListItem>
                                 <asp:ListItem>Hypertension</asp:ListItem>
                                 <asp:ListItem>Pregnant Women</asp:ListItem>
                                 <asp:ListItem>Infant</asp:ListItem>
                      </asp:CheckBoxList>
                  </div>
              </div>
              <hr />
              <div class="Part">
                  <div class="head">
                        
                      <asp:Label ID="LblRecipeSchedule" runat="server" Text="Day Available" CssClass="labelContent" ></asp:Label>
                  </div>
                     <div class="body">
                         <asp:DropDownList ID="DDLRecipeSchedule" runat="server" CssClass="dropdownlist">
                               <asp:ListItem>Please Select</asp:ListItem>
                                 <asp:ListItem>Monday</asp:ListItem>
                                 <asp:ListItem>Tuesday</asp:ListItem>
                                 <asp:ListItem>Wednesday</asp:ListItem>
                                 <asp:ListItem>Thursday</asp:ListItem>
                                 <asp:ListItem>Friday</asp:ListItem>
                                 <asp:ListItem>Saturday</asp:ListItem>
                                 <asp:ListItem>Sunday</asp:ListItem>
                         </asp:DropDownList>
                         <asp:Label ID="LblErrorMessage1" runat="server" Text="*Select a Day" ForeColor="Red" Visible="False" Font-Names="Arial" Font-Size="20px" Font-Bold="True"></asp:Label>
                         <br />
                         <br />
                         <asp:Label ID="LblNote" runat="server" Text="Note:" CssClass="labelContent" Font-Bold="True" Font-Size="25px"></asp:Label>
                         <asp:Label ID="LblRecipeScheduleInstuction" runat="server" Text="Changing of day is available at the View Recipe." CssClass="labelContent" Font-Bold="False" Font-Size="25px"></asp:Label>
                  </div>
              </div>
          </div>
      </div>
       
    </div>
    <div id="nextButtonContent">
        <asp:Button ID="BtnStep1Next" runat="server" Text="Proceed to Confirmation" CssClass="nextButtonNext" OnClick="BtnStep1Next_Click" />


    </div>
    <div id="backButtonContent">
        <asp:Button ID="Button1" runat="server" Text="Back" CssClass="nextButton" OnClick="Button1_Click" />
    </div>
</asp:Content>
