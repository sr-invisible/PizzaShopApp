<%@ Page Title="" Language="C#" MasterPageFile="~/Common/UI/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="CartItems.aspx.cs" Inherits="PizzaShopApp.Users.UI.CartItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/style2.css" rel="stylesheet" type="text/css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:Repeater ID="RepeaterForAllSelectedCartProduct" runat="server" >
         <HeaderTemplate>
            <ul style="list-style: none">
        </HeaderTemplate>


        <ItemTemplate>
             <div class="section group">
		<div class="grid_1_of_4 images_1_of_4">
            <li>

                <div>
                    <img src="<%#"data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("Product.ProductImage"))%>" height="200" width="200" />
                    <h3>Product Name : <%#Eval("Product.ProductName")%></h3>
                    <h4>Quantity : <%#Eval("Quantity")%> </h4>
                    <h4>Total Price : <%#Eval("TotalPrice")%> BDT</h4>
                   
                    <a href="RemoveProductFromCard.aspx?Id=<%#Eval("Product.ProductId")%>" >Remove</a>
                </div>
            </li>
              <asp:Button ID="btnCancelCookie" runat="server" Text="Cancel" OnClick="btnCancelCookie_Click" />
    
    <a href="Order.aspx">Make Order</a>
            </div>
        </div>

        </ItemTemplate>



        <FooterTemplate>
            </ul>
        </FooterTemplate>


    </asp:Repeater>


  

</asp:Content>
