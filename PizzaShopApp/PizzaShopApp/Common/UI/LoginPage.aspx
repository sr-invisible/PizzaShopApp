<%@ Page Title="" Language="C#" MasterPageFile="~/Common/UI/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="PizzaShopApp.Common.UI.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
       .main_regi {
           background-color: #dddfe2;
           width: 490px;
           height: 200px;
           margin-left: auto;
           margin-right: auto;
           margin-top: 25px;
           margin-bottom: 25px;
       }
       .header_regi {
           background-color: black;
           width: 490px;
           height: auto;
           color: greenyellow;
           font-size: 30px;
           font-weight: bold;
           text-align: center;
       }
          .style1
    {
        width: 490px;
        text-align:left;
    }
        .auto-style2 {
            width: 229px;
        }
        .auto-style3 {
            text-align: right;
            color: #fff;
            font-size: 20px;
            height: 35px;
            width: 29px;
        }
        .auto-style4 {
            width: 192px;
        }
        .auto-style5 {
            width: 205px;
        }
   </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class="main_regi">
        <div class="header_regi">
            Login Form
        </div> <br/>
            <table>
                <asp:Label ID="lblerrorMessage" runat="server" Text=""></asp:Label>
           <tr>
               <td></td>
           </tr>
           <tr>
               <td>
                   <table class="style1">
                       <tr>
                           <td class="auto-style3"></td>
                           <td class="auto-style4">
                               Email :
                           </td>
                           <td class="auto-style5">
                               <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox> 
                           </td>
                           <td>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="Please Enter Email" ControlToValidate="txtEmail" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                           </td>
                       </tr>
                       <tr>
                           <td class="auto-style3"></td>
                           <td class="auto-style4">
                               Password :
                           </td>
                           <td class="auto-style5">
                               <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" style="margin-left: 0px"></asp:TextBox>
                           </td>
                           <td class="auto-style2">
                               <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Please Enter Password" ControlToValidate="txtPassword" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                           </td>
                       </tr>
                       <tr>
                           <td class="auto-style3"></td>
                           <td class="auto-style4"></td>
                           <td class="auto-style5">
                               <asp:Button ID="loginButton" runat="server" Text="Log In" OnClick="loginButton_Click1" />
                           </td>
                       </tr>
                       <tr>
                           <td class="auto-style3"></td>
                           <td class="auto-style4"></td>
                           <td class="auto-style5">
                              Forget Password Click 
                             <asp:LinkButton ID="lbtnForgetPwd" runat="server" PostBackUrl="~/Common/UI/ForgetPassword.aspx">Here</asp:LinkButton>
                           </td>
                       </tr>
                   </table>
               </td>
           </tr>
           <tr>
               <td></td>
           </tr>
       </table>
       </div>
</asp:Content>
