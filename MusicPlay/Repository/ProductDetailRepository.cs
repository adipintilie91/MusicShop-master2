using MusicPlay.Models;
using MusicPlay.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MusicPlay.Repository
{
    public class ProductDetailRepository
    {
        //injectam containerul ORM
        private MusicPlayModelsDataContext dbContext;
        public ProductDetailRepository()
        {
            this.dbContext = new MusicPlayModelsDataContext();
        }

        //injectam un dbContext pentru a face repository a noastra testabila
        public ProductDetailRepository(MusicPlayModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //map ORM model to Model object- mapper method
        private ProductDetailModel MapDbObjectToModel(ProductDetail param) //MapInstrumentToOrderModel
        {
            var result = new ProductDetailModel();

            if (param != null)
            {
                result.Id = param.Id;
                result.ProductId = param.ProductId;
                result.CountryId = param.CountryId;
                result.Price = param.Price;
                result.Name = param.Name;
                result.YearOfProduction = param.YearOfProduction;
                result.Manufacturer = param.Manufacturer;
                result.Description = param.Description;
                result.CreationDate = param.CreationDate;

                return result;
            }
            return null;
        }

        // map Model Object to ORM model - mapper method
        private ProductDetail MapModelToObject(ProductDetailModel param) //MatOrderModelToInstrument
        {
            var result = new ProductDetail();

            if (param != null)
            {
                result.Id = param.Id;
                result.ProductId = param.ProductId;
                result.CountryId = param.CountryId;
                result.Price = param.Price;
                result.Name = param.Name;
                result.YearOfProduction = param.YearOfProduction;
                result.Manufacturer = param.Manufacturer;
                result.Description = param.Description;
                result.CreationDate = param.CreationDate;

                return result;
            }
            return null;
        }

        // METHODS: get all orders, get orders by id, insert orders, update order, delete order 
        public List<ProductDetailModel> GetAll()
        {
            var resultList = new List<ProductDetailModel>();

            foreach (var item in dbContext.ProductDetails)
            {
                resultList.Add(MapDbObjectToModel(item));
            }

            //List<int>lista = new List<int>();
            //foreach(int l in lista)
            //{

            //}

            return resultList;
        }

        public ProductDetailModel GetById(Guid ID)
        {
            return MapDbObjectToModel(dbContext.ProductDetails.FirstOrDefault(x => x.Id == ID));
        }

        public void Insert(ProductDetailModel param)
        {
            param.Id = Guid.NewGuid(); // generate new ID for the new record
            dbContext.ProductDetails.InsertOnSubmit(MapModelToObject(param)); //add to ORM layer
            dbContext.SubmitChanges(); // commit to DB
        }

        public void Update(ProductDetailModel param) //Instrument fiind valoarea noua
        {
            //get existing record to update
            ProductDetail existingItem = dbContext.ProductDetails.FirstOrDefault(x => x.Id == param.Id); //preluare categorie ce vrei sa o modifici, valoarea veche

            if (existingItem != null)
            {
                //map update values with keeping the ORM object reference
                existingItem.Id = param.Id;
                existingItem.ProductId = param.ProductId;
                existingItem.CountryId = param.CountryId;
                existingItem.Price = param.Price;
                existingItem.Name = param.Name;
                existingItem.YearOfProduction = param.YearOfProduction;
                existingItem.Manufacturer = param.Manufacturer;
                existingItem.Description = param.Description;
                existingItem.CreationDate = param.CreationDate;

                dbContext.SubmitChanges(); // commit to db
            }
        }

        public void Delete(Guid ID)
        {
            // get existing record to delete
            ProductDetail itemToDelete = dbContext.ProductDetails.FirstOrDefault(x => x.Id == ID);

            if (itemToDelete != null)
            {
                dbContext.ProductDetails.DeleteOnSubmit(itemToDelete); // mark for deletion
                dbContext.SubmitChanges(); // commit to DB
            }
        }

        public IEnumerable<SelectListItem> GetProductDetailsByProduct(Guid idProduct)
        {
            IQueryable<ProductDetail> loc = dbContext.ProductDetails.Where<ProductDetail>(p => p.ProductId == idProduct);
            SelectList lst = new SelectList(loc, "Id", "Name");
            return lst;
        }
    }
}