using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductDirector Director = new ProductDirector();
            var Builder = new NewCustomerProductBuilder();
            Director.GenerateProduct(Builder);
            var model = Builder.GetModel();

            Console.WriteLine(model.Id);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.DiscountAppleid);
            Console.WriteLine(model.DiscountPrice);
            Console.WriteLine(model.UnitPrice);


            Console.ReadLine();


        }
    }

    class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public bool DiscountAppleid { get; set; }
    }

     abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.DiscountPrice = model.UnitPrice * (decimal)0.9;
            model.DiscountAppleid = true;
        }

        public override void GetProductData()
        {
            model.Id = 1;
            model.ProductName = "Çay";
            model.CategoryName = "İçicek";
            model.UnitPrice = 50;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.DiscountPrice = model.UnitPrice;
            model.DiscountAppleid = false;
        }
        public override void GetProductData()
        {
          
            model.Id = 1;
            model.ProductName = "Çay";
            model.CategoryName = "İçicek";
            model.UnitPrice = 10;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

     class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }

}
