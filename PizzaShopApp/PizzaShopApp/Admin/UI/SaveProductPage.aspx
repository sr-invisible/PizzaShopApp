<%@ Page Title="" Language="C#" MasterPageFile="~/Common/UI/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="SaveProductPage.aspx.cs" Inherits="PizzaShopApp.Admin.UI.SaveProductPage" %>

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
            Add Product
        </div> <br/>
            <table>
                <h2>
            <asp:Label ID="lblSaveSuccessOrNot" runat="server" Text="" ForeColor="Blue"></asp:Label>
        </h2>
           <tr>
               <td></td>
           </tr>
           <tr>
               <td>
                   <table class="style1">
                       <tr>
                           <td class="auto-style3"></td>
                           <td class="auto-style1">
                               <asp:Label ID="lblProductName" runat="server" Text="Product Name "></asp:Label>
                           </td>
                           <td class="auto-style2" >
                               <asp:TextBox ID="txtProductName" runat="server" AutoPostBack="True" OnTextChanged="txtProductName_TextChanged"></asp:TextBox>
                           </td>
                           <td>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidatorProductName" runat="server" ErrorMessage="Plesae Provide Product Name " ControlToValidate="txtProductName" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:Label ID="lblNotUniqueProductName" runat="server" Text="" ForeColor="Red"></asp:Label>
                           </td>
                       </tr>
                       <tr>
                           <td class="auto-style3"></td>
                           <td class="auto-style1">
                               <asp:Label ID="lblProductDescription" runat="server" Text="Product Description"></asp:Label>
                           </td>
                           <td class="auto-style2">
                                <asp:TextBox ID="txtProductDescription" runat="server"></asp:TextBox>
                           </td>
                           <td>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidatorProductDescription" runat="server" ErrorMessage="Please Provide Product Description" ControlToValidate="txtProductDescription" ForeColor="Red"></asp:RequiredFieldValidator>
                           </td>
                       </tr>
                       <tr>
                           <td class="auto-style3"></td>
                           <td class="auto-style1">
                               <asp:Label ID="lblProductPrice" runat="server" Text="Product Price "></asp:Label>
                           </td>
                           <td class="auto-style2">
                                <asp:TextBox ID="txtProductPrice" runat="server"></asp:TextBox>
                           </td>
                           <td>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidatorProductPrice" runat="server" ErrorMessage="Please Provide Product Price" ControlToValidate="txtProductPrice" ForeColor="Red"></asp:RequiredFieldValidator>
                           </td>
                       </tr>
                       <tr>
                           <td class="auto-style3"></td>
                           <td class="auto-style1">
                              <asp:Label ID="lblProductInStock" runat="server" Text="Product In Stock "></asp:Label>
                           </td>
                           <td class="auto-style2">
                               <asp:TextBox ID="txtProductInStock" runat="server"></asp:TextBox>
                           </td>
                           <td>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidatorProductInStock" runat="server" ErrorMessage="Please Provide Product Price" ControlToValidate="txtProductInStock" ForeColor="Red"></asp:RequiredFieldValidator>
                           </td>
                       </tr>
                       
                       <tr>
                           <td class="auto-style3"></td>
                           <td class="auto-style1" >
                              <asp:Label ID="lblImageUpload" runat="server" Text="Upload Image"></asp:Label>
                           </td>
                           <td class="auto-style2">
                               <asp:FileUpload ID="FileUpload" runat="server" />
                           </td>
                           <td>
                               
                           </td>
                       </tr>
                       <tr>
                           <td class="auto-style3"></td>
                           <td class="auto-style1"></td>
                           <td class="auto-style2">
                               <asp:Button ID="productSaveButton" runat="server" Text="Save" OnClick="productSaveButton_Click" />
                           </td>
                       </tr>
                   </table>
               </td>
           </tr>
           <tr>
               <td></td>
           </tr>
       </table>


    <a href="AllProducts.aspx">AllProducts</a>

</div>


</asp:Content>
