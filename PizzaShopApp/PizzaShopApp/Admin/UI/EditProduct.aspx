<%@ Page Title="" Language="C#" MasterPageFile="~/Common/UI/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="PizzaShopApp.Admin.UI.EditProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <table>
        
        <asp:Label runat="server" ID="saveMSG" Text="" ForeColor="Red"></asp:Label>
        <asp:HiddenField runat="server" ID="lblProductId"/>
        <h2>
            <asp:Label ID="lblSaveSuccessOrNot" runat="server" Text="" ForeColor="Blue"></asp:Label>
        </h2>

        <tr>
            <td>
                <asp:Label ID="lblProductName" runat="server" Text="Product Name "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtProductName" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorProductName" runat="server" ErrorMessage="Plesae Provide Product Name " ControlToValidate="txtProductName" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:Label ID="lblNotUniqueProductName" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>

        </tr>
        <tr>
            <td>
                <asp:Label ID="lblProductDescription" runat="server" Text="Product Description"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtProductDescription" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorProductDescription" runat="server" ErrorMessage="Please Provide Product Description" ControlToValidate="txtProductDescription" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblProductPrice" runat="server" Text="Product Price "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtProductPrice" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorProductPrice" runat="server" ErrorMessage="Please Provide Product Price" ControlToValidate="txtProductPrice" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblProductInStock" runat="server" Text="Product In Stock "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtProductInStock" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorProductInStock" runat="server" ErrorMessage="Please Provide Product Price" ControlToValidate="txtProductInStock" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblImageUpload" runat="server" Text="Upload Image"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload" runat="server" />

            </td>
        </tr>
        <tr>
            <td></td>
            <td>

                <asp:Button ID="productUpdateButton" runat="server" Text="Update" OnClick="productUpdateButton_Click" />
            </td>
        </tr>

    </table>

    <a href="AllProducts.aspx">AllProducts.aspx</a>

</asp:Content>
