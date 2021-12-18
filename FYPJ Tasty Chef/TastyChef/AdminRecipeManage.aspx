<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdminRecipeManage.aspx.cs" Inherits="TastyChef.AdminRecipeManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(window).load(function () {
            $(".loader").fadeOut("slow");
        })
    </script>
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
        .recordMessage1{
            width:100%;
            float:left;
            text-align:center;
            height:30%;
            margin-top:5%;
        }
    </style>
        <%-- CSS Style for Main Content--%>
    <style>
        .mainContent {
            width: 80%;
            height: 1500px;
            /*border: solid;
            border-color: aqua;*/
            text-align: center;
            margin-top: 2.5%;
            margin-left:10%;
      float:left;
        }
        #mainContent1{
              width: 80%;
            height: 250px;
            /*border: solid;
            border-color: aqua;*/
            text-align: center;
            margin-top: 2.5%;
            margin-left:10%;
            float:left;
        }
        </style>
 <%--   SearchPanel--%>
    <style>
        #searchPanel{
            width:100%;
            height:100%;
              /*border: solid;
            border-color: aqua;*/
            text-align: center;
          
            background-color:white;

        }
        #searchHeading {
            width: 100%;
            height: 20%;
            /*border: solid;
            border-color: aqua;*/
            text-align: center;
               font-family: Arial;
            font-size: 44px;
            color: #003366;
            font-weight: bold;
            display:inline-block;
            margin-top:1%;
        }
          #searchBody {
            width: 100%;
            height: 75%;
            /*border: solid;
            border-color: red;*/
        
        }
        .div{
             color: #4DB6AC
        }
        .leftContent{
              width: 33%;
            height: 60%;
               /*border: solid;
            border-color: purple;*/
            float:left;
            text-align:center;
            margin-top:5%;
   
            
        }
        .searchRecipeNameContent{
                width: 48%;
            height: 30%;
               border: solid;
            border-color: purple;
            float:left;
            text-align:center;
    
        }
          .labelNContent {
            font-family: Arial;
            font-size: 26px;
            color: black;
            font-weight:bold;
        }
            .dropdownlist {
            border-radius: 4px;
            border-color: black;
            border-width: 1.5px;
            height: 35px;
            width: 200px;
            font-size: 20px;
            color: black;
        }
               .tb {
            border-radius: 5px;
            border-color: black;
            border-width: 1.5px;
            font-size: 24px;
            color: black;
            height: 35px;
            width: 350px;
        }
         .searchButton {
            height: 45px;
            width: 100px;
            border-radius: 10px;
            font-size: 20px;
            font-family: Arial;
            background-color: #009999;
            font-weight: bold;
            border: none;
            color: white;
        }
    </style>
    <style>
        #resultPanel{
                width:100%;
            height:auto;
              /*border: solid;
            border-color: aqua;*/
            text-align: center;
       
            background-color:white;
        }
        #resultHeading{
              text-align: center;
               font-family: Arial;
            font-size: 44px;
            color: #003366;
            font-weight: bold;
            display:inline-block;
            height:4%;
            margin-top:1%;

        }
         #resultBody{
               font-family: Arial;
            font-size: 24px;
              color:black;
          
            
            margin-top:1%;
            /*border: solid;
            border-color: aqua;*/
            overflow:auto;
         }
           .labelContent {
            font-family: Arial;
            font-size: 24px;
            color: black;
            font-weight:bold;
        }
                   .viewDetailsButton {
            height: 45px;
            width: 150px;
            border-radius: 10px;
            font-size: 20px;
            font-family: Arial;
            background-color: #009999;
            font-weight: bold;
            border: none;
            color: white;
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
            .auto-style1{
                height:100%;
                width:100%;
            }
            .a{
                height:40px;
                width:150px;
            }
            .b{
                 height:80px;
                width:200px;
            }
             .c{
                 height:80px;
                width:200px;
            }

            </style>
    <div class="loader"></div>
     <div id="headContent">
        <div id="title">
            View Recipes
        </div>
        <div id="titleDescription">
            Comprehend the nature of ingredients and coordinate them into Gorgeous Recipe 
        </div>
        <div id="divider">
            _____________________
        </div>
    </div>
      <div id="mainContent1">
         <div id="searchPanel">
            <div id="searchHeading">
                <asp:Label ID="Label1" runat="server" Text="Search Recipes"></asp:Label>
                <div class="div">
                <hr />
                    </div>
            </div>
            <div id="searchBody">
                 <div class="leftContent">
              
            
                    <asp:TextBox ID="TbSearchIngredientName" runat="server" CssClass="tb" placeholder="Recipe Name"></asp:TextBox>
                    <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="searchButton" OnClick="BtnSearch_Click" />
                </div>
                <div class="leftContent">
                
                   
                    <asp:Label ID="Label2" runat="server" Text="Day Available:" CssClass="labelNContent"></asp:Label>
               
                    <asp:DropDownList ID="DDLSchedule" runat="server" CssClass="dropdownlist" AutoPostBack="True" OnSelectedIndexChanged="DDLSchedule_SelectedIndexChanged">
                          <asp:ListItem Value="0">Please Select</asp:ListItem>
                                 <asp:ListItem>Monday</asp:ListItem>
                                 <asp:ListItem>Tuesday</asp:ListItem>
                                 <asp:ListItem>Wednesday</asp:ListItem>
                                 <asp:ListItem>Thursday</asp:ListItem>
                                 <asp:ListItem>Friday</asp:ListItem>
                                 <asp:ListItem>Saturday</asp:ListItem>
                                 <asp:ListItem>Sunday</asp:ListItem>
                    </asp:DropDownList>
                 </div>
                <div class ="leftContent">
                       <asp:Label ID="Label3" runat="server" Text="Suitable For:" CssClass="labelNContent"></asp:Label>
                    <asp:DropDownList ID="DDLTailorMade" runat="server" CssClass="dropdownlist" AutoPostBack="True" OnSelectedIndexChanged="DDLTailorMade_SelectedIndexChanged">
                          <asp:ListItem Value="0">Please Select</asp:ListItem>
                                 <asp:ListItem>Diabetes</asp:ListItem>
                                 <asp:ListItem>Hypertension</asp:ListItem>
                                 <asp:ListItem>Pregnant Woman</asp:ListItem>
                                 <asp:ListItem>Infrant</asp:ListItem>
                               
                    </asp:DropDownList>
             </div>
              
               
            </div>
           
        </div>
    </div>
    <div id="recordMessage" class="recordMessage1" runat="server">
     <asp:Label ID="LblMessage" runat="server" Text="No Record Found!" CssClass="labelContent" Font-Bold="True" ForeColor="Red"></asp:Label>
        </div>
    <div id="mainContent2" class="mainContent" runat="server">
       
         <div id="resultPanel">
            
             <div id="resultHeading">
                 <asp:Label ID="Label5" runat="server" Text="Search Results"></asp:Label>
                       
             </div>
       <div class="div">
                <hr />
                    </div>
             <div id="resultBody">
                 <asp:DataList ID="DLRecipe" runat="server" Width="100%" RepeatColumns="3" RepeatDirection="Horizontal" EnableTheming="True" CellPadding="8" CellSpacing="10" >
                     <ItemStyle Width="33%" />
                     <ItemTemplate>
                 <table class="auto-style1">
                     <tr>
                         <td colspan="2"><asp:Image ID="ImgRecipe" runat="server" ImageURL='<%# Eval("Image") %>' Height="180" Width="250"/></td>
                     </tr>
                     <tr class="a">
                         <td colspan="2">
                             <asp:Label ID="LblRecipeName" runat="server" Text='<%# Eval("RecipeName") %>' ForeColor="#003366" Font-Bold="True"></asp:Label>
                         </td>
                     </tr>
                     <tr class="c">
                         <td>
                             <asp:Label ID="Label6" runat="server" Text="Cuisine: " CssClass="labelContent"></asp:Label>
                           
                             <asp:Label ID="LblCusineType" runat="server" Text='<%# Eval("Type") %>'></asp:Label></td>
                         <td>
                             <asp:Label ID="Label7" runat="server" Text="Day Available: " CssClass="labelContent"></asp:Label>
                   
                             <asp:Label ID="LblSchdule" runat="server" Text='<%# Eval("Day") %>'></asp:Label></td>
                     </tr>
                     <tr class="b">
                         <td colspan="2"><asp:Label ID="Label8" runat="server" Text="Suitable For: " CssClass="labelContent"></asp:Label>
                             <asp:Label ID="LblTailorMade" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                         </td>
                      
                     </tr>
                     <tr>
                         <td colspan="2">
                             <asp:Button ID="BtnViewDetails" runat="server" Text="View Details" CssClass="viewDetailsButton" OnClick="BtnViewDetails_Click" />
                         </td>
                     </tr>
                 </table>
                         </ItemTemplate>
                     </asp:DataList>
             </div>
            </div>
    </div>
  
</asp:Content>
