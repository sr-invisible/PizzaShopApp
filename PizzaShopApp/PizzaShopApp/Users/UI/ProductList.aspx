<%@ Page Title="" Language="C#" MasterPageFile="~/Common/UI/MasterPage/Default.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="PizzaShopApp.Common.UI.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/style2.css" rel="stylesheet" type="text/css"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
    <br />
    <asp:Label ID="lblSearchByProductName" runat="server" Text="Type Product Name And Press Enter To Find The Product : " Font-Bold="True" ForeColor="#00CC99"></asp:Label>
    <asp:TextBox ID="txtSearchByProductName" runat="server" AutoPostBack="True" OnTextChanged="txtSearchByProductName_TextChanged" Width="213px"></asp:TextBox><br />
    <br/>
    <br/>

    <asp:Repeater ID="RepeaterForAllProducts" runat="server" OnItemCommand="RepeaterForAllProducts_ItemCommand">
        
        
        <HeaderTemplate>
            <ul style="list-style: none">
        </HeaderTemplate>


        <ItemTemplate>
             <div class="section group">
		<div class="grid_1_of_4 images_1_of_4">
            <li>

                <a href="/Users/UI/ProductDetailsPage.aspx?Id=<%#Eval("ProductId") %>">
                    <img src="<%#"data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("ProductImage"))%> " height="200" width="200" style="border-radius: 10px;border-color: brown " />
                </a>
                <div>
                    <h6 style="color: blueviolet">Pizza Name : <%#Eval("ProductName")%></h6>
                    <h5 style="color:brown">Price : <%#Eval("ProductPrice")%> BDT</h5>
                    <a href="/Users/UI/ProductDetailsPage.aspx?Id=<%#Eval("ProductId") %>" class="btn btn-primary btn-sm" >Details</a>
                </div>

                 
            </li>
             </div>
        </div>
        </ItemTemplate>



        <FooterTemplate>
            </ul>
        </FooterTemplate>

    </asp:Repeater>
    
    </div>
    

</asp:Content>
