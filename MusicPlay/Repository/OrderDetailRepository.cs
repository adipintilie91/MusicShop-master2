using MusicPlay.Models;
using MusicPlay.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicPlay.Repository
{
    public class OrderDetailRepository
    {
        //injectam containerul ORM
        private MusicPlayModelsDataContext dbContext;
        public OrderDetailRepository()
        {
            this.dbContext = new MusicPlayModelsDataContext();
        }

        //injectam un dbContext pentru a face repository a noastra testabila
        public OrderDetailRepository(MusicPlayModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //map ORM model to Model object- mapper method
        private OrderDetailModel MapDbObjectToModel(OrderDetail param) //MapInstrumentToOrderModel
        {
            var result = new OrderDetailModel();

            if (param != null)
            {
                result.Id = param.Id;
                result.OrderId = param.OrderId;
                result.ProductDetailId = param.ProductDetailsId;
                result.UnitPrice = param.UnitPrice;
                result.Quantity = param.Quantity;
                result.Discount = param.Discount;
                result.DateOrdered = param.DateOrdered;

                return result;
            }
            return null;
        }

        // map Model Object to ORM model - mapper method
        private OrderDetail MapModelToObject(OrderDetailModel param) //MatOrderModelToInstrument
        {
            var result = new OrderDetail();

            if (param != null)
            {
                result.Id = param.Id;
                result.OrderId = param.OrderId;
                result.ProductDetailsId = param.ProductDetailId;
                result.UnitPrice = param.UnitPrice;
                result.Quantity = param.Quantity;
                result.Discount = param.Discount;
                result.DateOrdered = param.DateOrdered;

                return result;
            }
            return null;
        }

        // METHODS: get all orders, get orders by id, insert orders, update order, delete order 
        public List<OrderDetailModel> GetAll()
        {
            var resultList = new List<OrderDetailModel>();

            foreach (var item in dbContext.OrderDetails)
            {
                resultList.Add(MapDbObjectToModel(item));
            }

            //List<int>lista = new List<int>();
            //foreach(int l in lista)
            //{

            //}

            return resultList;
        }

        public OrderDetailModel GetById(Guid ID)
        {
            return MapDbObjectToModel(dbContext.OrderDetails.FirstOrDefault(x => x.Id == ID));
        }

        public void Insert(OrderDetailModel param)
        {
            param.Id = Guid.NewGuid(); // generate new ID for the new record
            dbContext.OrderDetails.InsertOnSubmit(MapModelToObject(param)); //add to ORM layer
            dbContext.SubmitChanges(); // commit to DB
        }

        public void Update(OrderDetailModel param) //Instrument fiind valoarea noua
        {
            //get existing record to update
            OrderDetail existingItem = dbContext.OrderDetails.FirstOrDefault(x => x.Id == param.Id); //preluare categorie ce vrei sa o modifici, valoarea veche

            if (existingItem != null)
            {
                //map update values with keeping the ORM object reference
                existingItem.Id = param.Id;
                existingItem.OrderId = param.OrderId;
                existingItem.ProductDetailsId = param.ProductDetailId;
                existingItem.UnitPrice = param.UnitPrice;
                existingItem.Quantity = param.Quantity;
                existingItem.Discount = param.Discount;
                existingItem.DateOrdered = param.DateOrdered;

                dbContext.SubmitChanges(); // commit to db
            }
        }

        public void Delete(Guid ID)
        {
            // get existing record to delete
            OrderDetail itemToDelete = dbContext.OrderDetails.FirstOrDefault(x => x.Id == ID);

            if (itemToDelete != null)
            {
                dbContext.OrderDetails.DeleteOnSubmit(itemToDelete); // mark for deletion
                dbContext.SubmitChanges(); // commit to DB
            }
        }

    }
}