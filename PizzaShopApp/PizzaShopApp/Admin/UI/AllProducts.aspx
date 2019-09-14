<%@ Page Title="" Language="C#" MasterPageFile="~/Common/UI/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="AllProducts.aspx.cs" Inherits="PizzaShopApp.Admin.UI.AllProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/style2.css" rel="stylesheet" type="text/css"/>
</asp:Content>






<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <asp:Repeater ID="RepeaterProducts" runat="server" OnItemCommand="RepeaterProducts_ItemCommand">
         
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>


        <ItemTemplate>
            <div class="section group">
		<div class="grid_1_of_4 images_1_of_4">
            <li>

                <a href="../../Users/UI/ProductDetailsPage.aspx?Id=<%#Eval("ProductId") %>">
                    <img src="<%#"data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("ProductImage"))%>" height="200" width="200" />
                </a>
                <div>
                    <h3>Product Name : <%#Eval("ProductName")%></h3>
                    <h4>Product Price : <%#Eval("ProductPrice")%> BDT</h4>
                     <h4>Product In Stock : <%#Eval("ProductInStock")%> </h4>
                    <a href="/Admin/UI/DeleteProduct.aspx?Id=<%#Eval("ProductId") %>">Delete </a>
                    <a href="/Admin/UI/EditProduct.aspx?Id=<%#Eval("ProductId")%>&Name=<%#Eval("ProductName")%>&Price=<%#Eval("ProductPrice")%>&Desc=<%#Eval("ProductDescription")%>&Stock=<%#Eval("ProductInStock")%>   ">Edit</a>
                    
                    

                </div>

            </li>

            </div>
        </div>
        </ItemTemplate>


        <FooterTemplate>
            </ul>
        </FooterTemplate>
        
    </asp:Repeater>
            
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    

</asp:Content>
