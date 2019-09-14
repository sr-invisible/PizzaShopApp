using PizzaShopApp.Common.BLL;
using PizzaShopApp.Common.Models.Data;
using System;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace PizzaShopApp.Admin.UI
{
    public partial class SaveProductPage : System.Web.UI.Page
    {

        private ProductManager _productManager = new ProductManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblNotUniqueProductName.Text = "";

        }


        protected void productSaveButton_Click(object sender, EventArgs e)
        {

            var product = GetAllInfo();

            string savedMSG = null;
            if (!_productManager.IsExists(txtProductName.Text) && product.ProductPrice >= 0 && product.ProductImage != null && product.ProductInStock >= 0)
            {
                savedMSG = _productManager.SaveProduct(product);

            }
            else
            {
                savedMSG = "Failed To Save Product";
            }

            lblSaveSuccessOrNot.Text = savedMSG;
        }


        private Product GetAllInfo()
        {
            Product product = new Product();

            product.ProductName = txtProductName.Text;

            product.ProductDescription = txtProductDescription.Text;
            product.ProductInStock = Convert.ToInt32(txtProductInStock.Text);

            try
            {
                product.ProductPrice = Convert.ToInt64(txtProductPrice.Text);
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Invalid Numbe Input ", "<script>alert('Please Enter Number')</script>");
            }

            HttpPostedFile httpPostedFile = FileUpload.PostedFile;

            string fileNmae = Path.GetFileName(httpPostedFile.FileName);
            string fileExtenction = Path.GetExtension(fileNmae);

            if (
                fileExtenction.ToLower() == ".jpg"
              || fileExtenction.ToLower() == ".bmp"
              || fileExtenction.ToLower() == ".png"
              || fileExtenction.ToLower() == ".gif"
                )
            {

                Stream stream = httpPostedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                product.ProductImage = bytes;
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Invalid File", "<script>alert('Please Upload Image Type File like jpg , png , gif  or bmp')</script>");
            }
            return product;
        }





        protected void txtProductName_TextChanged(object sender, EventArgs e)
        {

            if (_productManager.IsExists(txtProductName.Text))
            {
                lblNotUniqueProductName.Text = "This Product Name Alreay Exists";
            }

        }








    }
}