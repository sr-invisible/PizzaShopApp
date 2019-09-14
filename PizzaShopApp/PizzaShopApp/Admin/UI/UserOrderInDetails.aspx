<%@ Page Title="" Language="C#" MasterPageFile="~/Common/UI/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="UserOrderInDetails.aspx.cs" Inherits="PizzaShopApp.Admin.UI.UserOrderInDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        

    <asp:GridView ID="GridViewOdersDetailsById" runat="server" CssClass="table table-hover" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewOdersDetailsById_SelectedIndexChanged">


        <Columns>
            <asp:BoundField DataField="ProductName" HeaderText="Pizza Name "/>
            <asp:BoundField DataField="ProductQuantity" HeaderText="Quantity" />
            <asp:BoundField DataField="ProductTotapPrice" HeaderText="Price" />
        </Columns>
    </asp:GridView>

   
</asp:Content>
