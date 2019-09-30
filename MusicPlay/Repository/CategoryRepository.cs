using MusicPlay.Models;
using MusicPlay.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicPlay.Repository
{
    public class CategoryRepository
    {
        //injectam containerul ORM
        private MusicPlayModelsDataContext dbContext;
        public CategoryRepository()
        {
            this.dbContext = new MusicPlayModelsDataContext();
        }

        //injectam un dbContext pentru a face repository a noastra testabila
        public CategoryRepository(MusicPlayModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //map ORM model to Model object- mapper method
        private CategoryModel MapDbObjectToModel(Category dbCategory) //MapCategoryToCategoryModel
        {
            CategoryModel categoryModel = new CategoryModel();

            if (dbCategory != null)
            {
                categoryModel.Id = dbCategory.Id;
                categoryModel.Name = dbCategory.Name;

                return categoryModel;
            }
            return null;
        }

        // map Model Object to ORM model - mapper method
        private Category MapModelToObject(CategoryModel categoryModel) //MatCategoryModelToCategory
        {
            Category dbCategory = new Category();

            if (categoryModel != null)
            {
                dbCategory.Id = categoryModel.Id;
                dbCategory.Name = categoryModel.Name;

                return dbCategory;
            }
            return null;
        }

        // METHODS: get all orders, get orders by id, insert orders, update order, delete order 
        public List<CategoryModel> GetAll()
        {
            List<CategoryModel> categoryList = new List<CategoryModel>();

            foreach (Category category in dbContext.Categories)
            {
                categoryList.Add(MapDbObjectToModel(category));
            }

            //List<int>lista = new List<int>();
            //foreach(int l in lista)
            //{

            //}

            return categoryList;
        }

        public CategoryModel GetById(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Categories.FirstOrDefault(x => x.Id == ID));
        }

        public CategoryModel GetByName(string name)
        {
            return MapDbObjectToModel(dbContext.Categories.FirstOrDefault(x => x.Name == name));
        }

        public void Insert(CategoryModel categoryModel)
        {
            categoryModel.Id = Guid.NewGuid(); // generate new ID for the new record
            dbContext.Categories.InsertOnSubmit(MapModelToObject(categoryModel)); //add to ORM layer
            dbContext.SubmitChanges(); // commit to DB
        }

        public void Update(CategoryModel category) //category fiind valoarea noua
        {
            //get existing record to update
            Category existingCategory = dbContext.Categories.FirstOrDefault(x => x.Id == category.Id); //preluare categorie ce vrei sa o modifici, valoarea veche

            if (existingCategory != null)
            {
                //map update values with keeping the ORM object reference
                existingCategory.Id = category.Id;
                existingCategory.Name = category.Name;

                dbContext.SubmitChanges(); // commit to db
            }
        }

        public void Delete(Guid ID)
        {
            // get existing record to delete
            Category categoryToDelete = dbContext.Categories.FirstOrDefault(x => x.Id == ID);

            if (categoryToDelete != null)
            {
                dbContext.Categories.DeleteOnSubmit(categoryToDelete); // mark for deletion
                dbContext.SubmitChanges(); // commit to DB
            }
        }

    }
}