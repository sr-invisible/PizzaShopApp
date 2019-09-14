<%@ Page Title="" Language="C#" MasterPageFile="~/Common/UI/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="RegistrationPage.aspx.cs" Inherits="PizzaShopApp.Common.UI.RegistrationPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
       .main_regi {
           background-color: #dddfe2;
           width: 600px;
           height: 450px;
           margin-left: auto;
           margin-right: auto;
           margin-top: 25px;
           margin-bottom: 25px;
       }
       .header_regi {
           background-color: black;
           width: 600px;
           height: auto;
           color: greenyellow;
           font-size: 30px;
           font-weight: bold;
           text-align: center;
       }
          .style1
    {
        width: 600px;
        text-align:left;
    }
    .auto-style1 {
            width: 131px;
        }
        .auto-style2 {
            width: 229px;
        }
        .auto-style3 {
            text-align: right;
            color: #fff;
            font-size: 20px;
            height: 35px;
            width: 67px;
        }
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main_regi">
        <div class="header_regi">
            Registration Form
        </div> <br/>
            <table>
                <asp:Label ID="lblMSG" runat="server" Text="" ForeColor="Blue"></asp:Label>
           <tr>
               <td></td>
           </tr>
           <tr>
               <td>
                   <table class="style1">
                       <tr>
                           <td class="auto-style3"></td>
                           <td class="auto-style1">
                               Name :
                           </td>
                           <td class="auto-style2" >
                               <asp:TextBox ID="txtUserName" runat="server" Height="23px"></asp:TextBox> 
                           </td>
                           <td>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ErrorMessage="Please Enter Your Name" ControlToValidate="txtUserName" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                           </td>
                       </tr>
                       <tr>
                           <td class="auto-style3"></td>
                           <td class="auto-style1">
                               Email :
                           </td>
                           <td class="auto-style2">
                               <asp:TextBox ID="txtEmail" runat="server" AutoPostBack="True" OnTextChanged="txtEmail_TextChanged" Height="23px"></asp:TextBox>
                           </td>
                           <td>
                               <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ErrorMessage="Invalid Email Address" ControlToValidate="txtEmail" ForeColor="#CC0000" ValidationExpression="^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$"></asp:RegularExpressionValidator>
                           </td>
                       </tr>
                       <tr>
                           <td class="auto-style3"></td>
                           <td class="auto-style1"></td>
                           <td class="auto-style2">
                               <asp:Label ID="lblmsgEmail" runat="server" Text="" ForeColor="red"></asp:Label>
                           </td>
                       </tr>
                       <tr>
                           <td class="auto-style3"></td>
                           <td class="auto-style1">
                               Password :
                           </td>
                           <td class="auto-style2">
                               <asp:TextBox ID="txtPassword" runat="server" Height="23px" TextMode="Password"></asp:TextBox>
                           </td>
                           <td>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Password" ControlToValidate="txtpassword" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                           </td>
                       </tr>
                       <tr>
                           <td class="auto-style3"></td>
                           <td class="auto-style1">
                               Confirm Password :
                           </td>
                           <td class="auto-style2">
                               <asp:TextBox ID="txtConfirmPassword" runat="server" Height="23px" TextMode="Password"></asp:TextBox>
                           </td>
                           <td>
                               <asp:CompareValidator ID="CompareValidatorPassword" runat="server" ErrorMessage="Password Did Not match" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ForeColor="#CC0000"></asp:CompareValidator>
                           </td>
                       </tr>
                       
                       <tr>
                           <td class="auto-style3"></td>
                           <td class="auto-style1" >
                               Address :
                           </td>
                           <td class="auto-style2">
                               <asp:TextBox ID="txtAddress" runat="server" Height="23px"></asp:TextBox>
                           </td>
                           <td>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server" ErrorMessage="Please Enter Your Address" ControlToValidate="txtAddress" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                           </td>
                       </tr>
                       <tr>
                           <td class="auto-style3"></td>
                           <td class="auto-style1"></td>
                           <td class="auto-style2">
                               <asp:CheckBox ID="cbxCondition" runat="server" Checked="True" /> I agree <asp:LinkButton ID="lbtnTermsCondition" runat="server">Terms &amp; Conditions</asp:LinkButton>
                           </td>
                       </tr>
                       <tr>
                           <td class="auto-style3"></td>
                           <td class="auto-style1"></td>
                           <td class="auto-style2">
                               <asp:Button ID="RegisterButthon" runat="server" Text="Create Account" Height="28px" OnClick="RegisterButthon_Click1" />
                           </td>
                       </tr>
                       <tr>
                           <td class="auto-style3"></td>
                           <td class="auto-style1"></td>
                           <td class="auto-style2">
                               Already Register, please login
                             <asp:LinkButton ID="lbtnLogin" runat="server" CausesValidation="False" Font-Underline="True" PostBackUrl="LoginPage.aspx">Here</asp:LinkButton>
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
