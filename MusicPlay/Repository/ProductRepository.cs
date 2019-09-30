using MusicPlay.Models;
using MusicPlay.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MusicPlay.Repository
{
    public class ProductRepository
    {
        //injectam containerul ORM
        private MusicPlayModelsDataContext dbContext;
        public ProductRepository()
        {
            this.dbContext = new MusicPlayModelsDataContext();
        }

        //injectam un dbContext pentru a face repository a noastra testabila
        public ProductRepository(MusicPlayModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //map ORM model to Model object- mapper method
        private ProductModel MapDbObjectToModel(Product dbProduct) //MapInstrumentToInstrumentsModel
        {
            ProductModel product = new ProductModel();

            if (dbProduct != null)
            {
                product.Id = dbProduct.Id;
                product.CategoryId = dbProduct.CategoryId;
                product.Name = dbProduct.Name;

                return product;
            }
            return null;
        }

        // map Model Object to ORM model - mapper method
        private Product MapModelToObject(ProductModel productModel) //MatInstrumentsModelToInstrument
        {
            Product dbProduct = new Product();

            if (productModel != null)
            {
                dbProduct.Id = productModel.Id;
                dbProduct.Name = productModel.Name;
                dbProduct.CategoryId = productModel.CategoryId;

                return dbProduct;
            }
            return null;
        }

        // METHODS: get all orders, get orders by id, insert orders, update order, delete order 
        public List<ProductModel> GetAll()
        {
            List<ProductModel> productsList = new List<ProductModel>();

            foreach (Product product in dbContext.Products)
            {
                productsList.Add(MapDbObjectToModel(product));
            }

            //List<int>lista = new List<int>();
            //foreach(int l in lista)
            //{

            //}

            return productsList;
        }

        public ProductModel GetById(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Products.FirstOrDefault(x => x.Id == ID));
        }



        public void Insert(ProductModel param)
        {
            param.Id = Guid.NewGuid(); // generate new ID for the new record
            dbContext.Products.InsertOnSubmit(MapModelToObject(param)); //add to ORM layer
            dbContext.SubmitChanges(); // commit to DB
        }

        public void Update(ProductModel param) //Instrument fiind valoarea noua
        {
            //get existing record to update
            Product existingProduct = dbContext.Products.FirstOrDefault(x => x.Id == param.Id); //preluare categorie ce vrei sa o modifici, valoarea veche

            if (existingProduct != null)
            {
                //map update values with keeping the ORM object reference
                existingProduct.Id = param.Id;
                existingProduct.Name = param.Name;

                dbContext.SubmitChanges(); // commit to db
            }
        }

        public void Delete(Guid ID)
        {
            // get existing record to delete
            Product productToDelete = dbContext.Products.FirstOrDefault(x => x.Id == ID);

            if (productToDelete != null)
            {
                dbContext.Products.DeleteOnSubmit(productToDelete); // mark for deletion
                dbContext.SubmitChanges(); // commit to DB
            }
        }

        //extrage lista de produse (dropdown)
        public IEnumerable<SelectListItem> GetProductsList()
        {
            var productsList = new List<ProductModel>();

            foreach (Product product in dbContext.Products)
            {
                productsList.Add(MapDbObjectToModel(product));
            }

            IQueryable<ProductModel> loc = productsList.AsQueryable();
            SelectList lst = new SelectList(loc, "Id", "Name");
            return lst;
        }
        //extrage lista de tari (dropdown)



    }
}