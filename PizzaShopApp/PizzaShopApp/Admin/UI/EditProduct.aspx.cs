using PizzaShopApp.Common.BLL;
using PizzaShopApp.Common.Models.Data;
using System;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace PizzaShopApp.Admin.UI
{
    public partial class EditProduct : System.Web.UI.Page
    {

        private ProductManager _productManager = new ProductManager();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                saveMSG.Text = "";
                ViewState["ProductId"] = Request.QueryString["Id"];
                txtProductName.Text = Request.QueryString["Name"];
                txtProductPrice.Text = Request.QueryString["Price"];
                txtProductDescription.Text = Request.QueryString["Desc"];
                txtProductInStock.Text = Request.QueryString["Stock"];
            }

        }


        protected void productUpdateButton_Click(object sender, EventArgs e)
        {

            var product = GetAllInfo();

            string savedMSG = null;
            if (_productManager.UpdateProduct(product))
            {

                Response.Redirect("AllProducts.aspx");
            }
            else
            {
                saveMSG.Text = "Failed To Update Product Details";
            }





        }

        private Product GetAllInfo()
        {
            Product product = new Product();
            int id = 0;
            try
            {
                id = Convert.ToInt32(ViewState["ProductId"]);
            }
            catch (Exception ee)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "Invalid Product", "Please Do Not Messupwith This URL");
            }

            product.ProductId = id;

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
                product.ProductImage = new byte[] { 0 };
            }


            return product;

        }
    }
}