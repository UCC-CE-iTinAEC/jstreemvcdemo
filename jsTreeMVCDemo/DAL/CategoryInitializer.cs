using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using jsTreeMVCDemo.Models;

namespace jsTreeMVCDemo.DAL
{
    public class CategoryInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CategoryContext>
    {
        protected override void Seed(CategoryContext context)
        {
            var category = new List<CategoriesModel>
            {
              new CategoriesModel { CategoryName = "Root", ParentId = 0, ID = 1},
              new CategoriesModel {CategoryName = "Children 1", ParentId = 1, ID = 2},
              new CategoriesModel { CategoryName = "Children 1.1", ParentId = 2, ID = 4  },
              new CategoriesModel { CategoryName = "Children 1.2", ParentId = 2, ID = 5  },
              new CategoriesModel { CategoryName = "Children 2", ParentId = 1, ID = 3},
              new CategoriesModel { CategoryName = "Children 2.1", ParentId = 3, ID = 6  }
            };

            category.ForEach(s => context.CategoriesModels.Add(s));
            context.SaveChanges();
        }
    }
}