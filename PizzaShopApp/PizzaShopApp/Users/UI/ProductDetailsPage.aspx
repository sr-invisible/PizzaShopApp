<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetailsPage.aspx.cs" Inherits="PizzaShopApp.Common.UI.ProductDetailsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:GridView ID="GridViewSelectedProduct" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">


                <AlternatingRowStyle BackColor="White" />


                <Columns >

                    <asp:BoundField DataField="ProductName" HeaderText="Product Name " />
                    <asp:BoundField DataField="ProductDescription" HeaderText="Product Details " />
                    <asp:BoundField DataField="ProductPrice" HeaderText="Product Price " />
                    <asp:BoundField DataField="ProductInStock" HeaderText="Product In Stock " />

                    <asp:TemplateField HeaderText="Product Image">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Height="200" Width="200"
                                ImageUrl='  <%#"data:Image/png;base64,"+Convert.ToBase64String((byte[])Eval("ProductImage"))%>' />

                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>


            <table>
                <tr>
                    <td>
                        <h2>Numbers Of This Pizza You Want To Buy
                    </h2>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNumberOfProduct" runat="server" OnTextChanged="txtNumberOfProduct_TextChanged" AutoPostBack="True" Height="27px" Width="132px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnProductDetails" runat="server" Text="All Products" OnClick="btnProductDetails_Click" BackColor="#000066" Font-Bold="True" ForeColor="#66FF66" Height="36px" Width="119px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCartDetails" runat="server" Text="Cart Details" OnClick="btnCartDetails_Click" BackColor="#000066" Font-Bold="True" ForeColor="#66FF66" Height="36px" Width="119px" />
                    </td>
                    <td>
                        <asp:Button ID="btnAddToCart" runat="server" Text="Add To Cart" OnClick="btnAddToCart_Click" BackColor="#000066" Font-Bold="True" ForeColor="#66FF66" Height="36px" Width="119px" />
                    </td>
                </tr>

            </table>




        </div>
    </form>
</body>
</html>
