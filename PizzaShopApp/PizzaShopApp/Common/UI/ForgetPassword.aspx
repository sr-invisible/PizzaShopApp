﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Common/UI/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="PizzaShopApp.Common.UI.ForgetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">  
.style1  
{  
width: 225px;  
}  
.style2  
{  
width: 155px;  
}  
.style6  
{  
text-align: left;  
font-size: large;  
text-decoration: underline;  
color: #0000FF;  
}  
  
        </style>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>  
                <table style ="width:100%;">  
                    <caption class ="style6">  
                        <strong>ForgetPassword:</strong>  
                    </caption>  
                    <tr>  
                        <td class="style1">  
   
                        </td>  
                        <td class="style2">  
   
                        </td>  
                        <td>  
 </td>  
                        <td>  
 </td>  
                    </tr>  
                    <tr>  
                        <td class="style1">  
   
                        </td>  
                        <td class="style2">  
EmailId:  
                        </td>  
                        <td>  
                            <asp:TextBox ID="TextBox1"runat="server"> </asp:TextBox>  
                        </td>  
                        <td>  
 </td>  
                    </tr>  
                    <tr>  
                        <td class="style1">  
   
                        </td>  
                        <td class="style2">  
   
                        </td>  
                        <td>  
 </td>  
                        <td>  
 </td>  
                    </tr>  
                    <tr>  
                        <td class="style1">  
                            <asp:Label ID="lbmsg"runat="server">  
                            </asp:Label>  
                        </td>  
                        <td class="style2">  
                            <asp:LinkButton ID="LinkButton1"runat="server"onclick="LinkButton1_Click">Back to Login  
                            </asp:LinkButton>  
                        </td>  
                        <td>  
                            <asp:Button ID="Button1"runat="server"onclick="Button1_Click"Text="Submit"/>  
                        </td>  
                        <td>  
 </td>  
                    </tr>  
                </table>  
            </div>
</asp:Content>
