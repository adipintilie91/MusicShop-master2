using MusicPlay.Models;
using MusicPlay.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;



namespace MusicPlay.Repository
{
    public class CustomerRepository
    {
        //injectam containerul ORM
        private MusicPlayModelsDataContext dbContext;
        public CustomerRepository()
        {
            this.dbContext = new MusicPlayModelsDataContext();
        }

        //injectam un dbContext pentru a face repository a noastra testabila
        public CustomerRepository(MusicPlayModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //map ORM model to Model object- mapper method
        private CustomerModel MapDbObjectToModel(Customer param) //MapInstrumentToCustomersModel
        {
            var result = new CustomerModel();

            if (param != null)
            {
                result.Id = param.Id;
                result.CountryId = param.CountryId;
                result.FirstName = param.FirstName;
                result.LastName = param.LastName;
                result.Email = param.Email;
                result.Password = param.Password;
                result.PasswordAttempts = param.PasswordAttempts;
                result.IsActive = param.IsActive;

                return result;
            }
            return null;
        }

        // map Model Object to ORM model - mapper method
        private Customer MapModelToObject(CustomerModel param) //MatCustomersModelToInstrument
        {
            var result = new Customer();

            if (param != null)
            {
                result.Id = param.Id;
                result.CountryId = param.CountryId;
                result.FirstName = param.FirstName;
                result.LastName = param.LastName;
                result.Email = param.Email;
                result.Password = param.Password;
                result.PasswordAttempts = param.PasswordAttempts;
                result.IsActive = param.IsActive;

                return result;
            }
            return null;
        }

        // METHODS: get all orders, get orders by id, insert orders, update order, delete order 
        public List<CustomerModel> GetAll()
        {
            var resultList = new List<CustomerModel>();

            foreach (var item in dbContext.Customers)
            {
                resultList.Add(MapDbObjectToModel(item));
            }

            //List<int>lista = new List<int>();
            //foreach(int l in lista)
            //{

            //}

            return resultList;
        }

        public CustomerModel GetById(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Customers.FirstOrDefault(x => x.Id == ID));
        }

        public void Insert(CustomerModel param)
        {
            param.Id = Guid.NewGuid(); // generate new ID for the new record
            dbContext.Customers.InsertOnSubmit(MapModelToObject(param)); //add to ORM layer
            dbContext.SubmitChanges(); // commit to DB
        }

        public void Update(CustomerModel param) //Instrument fiind valoarea noua
        {
            //get existing record to update
            Customer existingItem = dbContext.Customers.FirstOrDefault(x => x.Id == param.Id); //preluare categorie ce vrei sa o modifici, valoarea veche

            if (existingItem != null)
            {
                //map update values with keeping the ORM object reference
                existingItem.Id = param.Id;
                existingItem.CountryId = param.CountryId;
                existingItem.LastName = param.LastName;
                existingItem.Email = param.Email;
                existingItem.Password = param.Password;
                existingItem.PasswordAttempts = param.PasswordAttempts;
                existingItem.IsActive = param.IsActive;

                dbContext.SubmitChanges(); // commit to db
            }
        }

        public void Delete(Guid ID)
        {
            // get existing record to delete
            Customer itemToDelete = dbContext.Customers.FirstOrDefault(x => x.Id == ID);

            if (itemToDelete != null)
            {
                dbContext.Customers.DeleteOnSubmit(itemToDelete); // mark for deletion
                dbContext.SubmitChanges(); // commit to DB
            }
        }

    }
}