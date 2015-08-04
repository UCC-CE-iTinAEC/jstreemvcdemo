using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jsTreeMVCDemo.DAL;
using jsTreeMVCDemo.Models;

namespace jsTreeMVCDemo.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryContext db = new CategoryContext();
        // GET: Category
        public ActionResult Index()
        {
            List<CategoriesModel> categoryList = new List<CategoriesModel>();
            categoryList = db.CategoriesModels.ToList();
            var rootCategory = categoryList.Where(x => x.ParentId == 0).FirstOrDefault();

            SetChildren(rootCategory, categoryList);

            return View(rootCategory);
        }

        private void SetChildren(CategoriesModel model, List<CategoriesModel> catList)
        {
            var childs = catList.Where(c => c.ParentId == model.ID).ToList();
            if (childs.Count > 0)
            {
                foreach (var child in childs)
                {
                    SetChildren(child, catList);
                    model.Children.Add(child);
                }
            }
        }
    }
}