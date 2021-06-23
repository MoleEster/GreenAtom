using GreenAtom.Data.Interfaces;
using GreenAtom.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;


namespace GreenAtom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController:Controller
    {
        private IAllProducts Products { get; set; }

        public ProductsController(IBaseInterface<Product> Products)
        {
            this.Products = (IAllProducts)Products;
        }
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(Products.GetAllProducts);
        }
        [HttpPost]
        public JsonResult Post(Product product)
        {
            bool success = true;
            Product product_ = Products.Get(product.Id);
            try
            {
                if (product_ != null)
                {
                    product_ = Products.Edit(product);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception ex)
            {
                success = false;
                return new JsonResult(ex.Message);
            }
            return success ? new JsonResult($"Product {product.Id} updated") : new JsonResult("Document was not updated");
        }
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            Product product = Products.Get(id);
            try
            {
                if (product != null)
                {
                    Products.Delete(id);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
            return RedirectToAction("Get");
        }
        public JsonResult Create(Product product)
        {
            bool success = true;
            Product product_ = product;
            try
            {
                if (product_ != null && !Products.GetAllProducts.Contains(product_))
                {
                    Products.Add(product_);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception ex)
            {
                success = false;
                return new JsonResult(ex.Message);
            }
            return success ? new JsonResult($"Product {product_.Name} was created") : new JsonResult("Document was not deleted");
        }
    }
}