using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using jsTreeMVCDemo.Models;

namespace jsTreeMVCDemo.DAL
{
     public class CategoryContext : DbContext
    {
        public CategoryContext() : base("CategoryContext")
        {
        }

        public DbSet<CategoriesModel> CategoriesModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
