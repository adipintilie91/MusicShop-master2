using MusicPlay.Models;
using MusicPlay.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicPlay.Repository
{
    public class OrderRepository
    {
        //injectam containerul ORM
        private MusicPlayModelsDataContext dbContext;
        public OrderRepository()
        {
            this.dbContext = new MusicPlayModelsDataContext();
        }

        //injectam un dbContext pentru a face repository a noastra testabila
        public OrderRepository(MusicPlayModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //map ORM model to Model object- mapper method
        private OrderModel MapDbObjectToModel(Order param) //MapInstrumentToOrderModel
        {
            var result = new OrderModel();

            if (param != null)
            {
                result.Id = param.Id;
                result.CustomerId = param.CustomerId;
                result.DeliveryAddress = param.DeliveryAddress;
                result.Price = param.Price;
                result.StatusType = param.StatusType;

                return result;
            }
            return null;
        }

        // map Model Object to ORM model - mapper method
        private Order MapModelToObject(OrderModel param) //MatOrderModelToInstrument
        {
            var result = new Order();

            if (param != null)
            {
                result.Id = param.Id;
                result.CustomerId = param.CustomerId;
                result.DeliveryAddress = param.DeliveryAddress;
                result.Price = param.Price;
                result.StatusType = param.StatusType;

                return result;
            }
            return null;
        }

        // METHODS: get all orders, get orders by id, insert orders, update order, delete order 
        public List<OrderModel> GetAll()
        {
            var resultList = new List<OrderModel>();

            foreach (var item in dbContext.Orders)
            {
                resultList.Add(MapDbObjectToModel(item));
            }

            //List<int>lista = new List<int>();
            //foreach(int l in lista)
            //{

            //}

            return resultList;
        }

        public OrderModel GetById(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Orders.FirstOrDefault(x => x.Id == ID));
        }

        public void Insert(OrderModel param)
        {
            param.Id = Guid.NewGuid(); // generate new ID for the new record
            dbContext.Orders.InsertOnSubmit(MapModelToObject(param)); //add to ORM layer
            dbContext.SubmitChanges(); // commit to DB
        }

        public void Update(OrderModel param) //Instrument fiind valoarea noua
        {
            //get existing record to update
            Order existingItem = dbContext.Orders.FirstOrDefault(x => x.Id == param.Id); //preluare categorie ce vrei sa o modifici, valoarea veche

            if (existingItem != null)
            {
                //map update values with keeping the ORM object reference
                existingItem.Id = param.Id;
                existingItem.CustomerId = param.CustomerId;
                existingItem.DeliveryAddress = param.DeliveryAddress;
                existingItem.Price = param.Price;
                existingItem.StatusType = param.StatusType;

                dbContext.SubmitChanges(); // commit to db
            }
        }

        public void Delete(Guid ID)
        {
            // get existing record to delete
            Order itemToDelete = dbContext.Orders.FirstOrDefault(x => x.Id == ID);

            if (itemToDelete != null)
            {
                dbContext.Orders.DeleteOnSubmit(itemToDelete); // mark for deletion
                dbContext.SubmitChanges(); // commit to DB
            }
        }

    }
}