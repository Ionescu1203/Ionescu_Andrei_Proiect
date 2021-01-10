using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ionescu_Andrei_Proiect.Data;


namespace Ionescu_Andrei_Proiect.Models
{
    public class ProductCategoriesPageModel : PageModel
    {
        public List<SpecificCategoryData> SpecificCategoryDataList;
        public void PopulateSpecificCategoryData(Ionescu_Andrei_ProiectContext context,
        Product product)
        {
            var allCategories = context.Category;
            var productCategories = new HashSet<int>(
            product.ProductCategories.Select(c => c.ProductID));
            SpecificCategoryDataList = new List<SpecificCategoryData>();
            foreach (var cat in allCategories)
            {
                SpecificCategoryDataList.Add(new SpecificCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = productCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateProductCategories(Ionescu_Andrei_ProiectContext context,
        string[] selectedCategories, Product productToUpdate)
        {
            if (selectedCategories == null)
            {
                productToUpdate.ProductCategories = new List<ProductCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var productCategories = new HashSet<int>
            (productToUpdate.ProductCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!productCategories.Contains(cat.ID))
                    {
                        productToUpdate.ProductCategories.Add(
                        new ProductCategory
                        {
                            ProductID = productToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (productCategories.Contains(cat.ID))
                    {
                        ProductCategory courseToRemove
                        = productToUpdate
                        .ProductCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
