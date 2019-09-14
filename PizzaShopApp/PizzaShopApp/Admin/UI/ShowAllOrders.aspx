<%@ Page Title="" Language="C#" MasterPageFile="~/Common/UI/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="ShowAllOrders.aspx.cs" Inherits="PizzaShopApp.Admin.UI.ShowAllOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>

    <table class="table table-striped">
        <tr>
            <td>User Name </td>
            <td>Address </td>
            <td>Date</td>
            <td>Total Price</td>
        </tr>

        <asp:Repeater ID="RepeaterOrderRecourds" runat="server">


            <ItemTemplate>
                <tr>
                    <td><%#Eval("UserName")%></td>
                    <td><%#Eval("Address")%></td>
                    <td><%#Eval("DateTime")%></td>
                    <td><%#Eval("TotalPrice")%></td>
                    <td>

                        <a href="UserOrderInDetails.aspx?Id=<%#Eval("OrderId") %>">Details</a>
                    </td>
                    
                </tr>

            </ItemTemplate>

        </asp:Repeater>





    </table>
    </div>
</asp:Content>
