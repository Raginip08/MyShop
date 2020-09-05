using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MyShop.Core;
using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;

namespace MyShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        IInMemoryRepository<Product> context;
        IInMemoryRepository<ProductCategory> categoryRepository;

        public ProductManagerController(IInMemoryRepository<Product> p, IInMemoryRepository<ProductCategory> pc)
        {
            context = p;
            categoryRepository = pc;
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            ProductCategoryViewModel viewModel = new ProductCategoryViewModel();
            viewModel.product = new Product();
            viewModel.productCategory = categoryRepository.Collection();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);
                context.commit();

                return RedirectToAction("Index");
            }
            
        }

        public ActionResult Edit(Product product)
        {
            Product products = context.Find(product.Id);
            if (products == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductCategoryViewModel viewModel = new ProductCategoryViewModel();
                viewModel.product = products;
                viewModel.productCategory = categoryRepository.Collection();
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product, string Id)
        {
            Product productToEdit = context.Find(product.Id);
            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                else
                {
                    context.Update(product, Id);
                    context.commit();
                    return RedirectToAction("Index");
                }

            }
        }

        public ActionResult Delete(string Id)
        {
            Product product = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Product product = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.commit();
                return RedirectToAction("Index");
            }
        }
    }
}