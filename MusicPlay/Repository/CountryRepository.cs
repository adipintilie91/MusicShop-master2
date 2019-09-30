using MusicPlay.Models;
using MusicPlay.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

//ORIGINAL

namespace MusicPlay.Repository
{
    public class CountryRepository
    {

        //injectam containerul ORM
        private MusicPlayModelsDataContext dbContext;
        public CountryRepository()
        {
            this.dbContext = new MusicPlayModelsDataContext();
        }

        //injectam un dbContext pentru a face repository a noastra testabila
        public CountryRepository(MusicPlayModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //map ORM model to Model object- mapper method
        private CountryModel MapDbObjectToModel(Country param) //MapInstrumentToCountriesModel
        {
            var result = new CountryModel();

            if (param != null)
            {
                result.Id = param.Id;
                result.Name = param.Name;

                return result;
            }
            return null;
        }

        // map Model Object to ORM model - mapper method
        private Country MapModelToObject(CountryModel param) //MatCountriesModelToInstrument
        {
            var result = new Country();

            if (param != null)
            {
                result.Id = param.Id;
                result.Name = param.Name;

                return result;
            }
            return null;
        }

        // METHODS: get all orders, get orders by id, insert orders, update order, delete order 
        public List<CountryModel> GetAll()
        {
            var resultList = new List<CountryModel>();

            foreach (var item in dbContext.Countries)
            {
                resultList.Add(MapDbObjectToModel(item));
            }

            //List<int>lista = new List<int>();
            //foreach(int l in lista)
            //{

            //}

            return resultList;
        }

        public CountryModel GetById(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Countries.FirstOrDefault(x => x.Id == ID));
        }

        public void Insert(CountryModel param)
        {
            param.Id = Guid.NewGuid(); // generate new ID for the new record
            dbContext.Countries.InsertOnSubmit(MapModelToObject(param)); //add to ORM layer
            dbContext.SubmitChanges(); // commit to DB
        }

        public void Update(CountryModel param) //Instrument fiind valoarea noua
        {
            //get existing record to update
            Country existingItem = dbContext.Countries.FirstOrDefault(x => x.Id == param.Id); //preluare categorie ce vrei sa o modifici, valoarea veche

            if (existingItem != null)
            {
                //map update values with keeping the ORM object reference
                existingItem.Id = param.Id;
                existingItem.Name = param.Name;

                dbContext.SubmitChanges(); // commit to db
            }
        }

        public void Delete(Guid ID)
        {
            // get existing record to delete
            Country itemToDelete = dbContext.Countries.FirstOrDefault(x => x.Id == ID);

            if (itemToDelete != null)
            {
                dbContext.Countries.DeleteOnSubmit(itemToDelete); // mark for deletion
                dbContext.SubmitChanges(); // commit to DB
            }
        }
        public IEnumerable<SelectListItem> GetCountriesById(Guid id)
        {
            IQueryable<Country> loc = dbContext.Countries.Where<Country>(p => p.Id == id);
            SelectList lst = new SelectList(loc, "Id", "Name");
            return lst;
        }

        public IEnumerable<SelectListItem> GetCountriesList()
        {
            IQueryable<Country> loc = dbContext.Countries.AsQueryable();
            SelectList lst = new SelectList(loc, "Id", "Name");
            return lst;
        }

    }
}