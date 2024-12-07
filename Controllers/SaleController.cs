using _50_Ders_MVC_Projesi.Models.Entities;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace _50_Ders_MVC_Projesi.Controllers
{
    public class SaleController : Controller
    {
        Entities _dbContext = new Entities(); 
        // GET: Sale
        public ActionResult Index()
        {
            
            return View(_dbContext.Sales.ToList());
        }
        private void ViewBagProduct()
        {
            var products = _dbContext.Products.ToList();
            ViewBag.Produits = (from p in products
                                select new SelectListItem
                                {
                                    Text = p.URUNAD,
                                    Value = p.URUNID.ToString(),
                                }).ToList();
        }
        private void ViewBagClient()
        {
            var clients = _dbContext.Clients.ToList();
            ViewBag.Clients = (from c in clients
                                select new SelectListItem
                                {
                                    Text = c.MUSTERIAD+ " " +c.MUSTERISOYAD,
                                    Value = c.MUSTERIID.ToString(),
                                }).ToList();     
        }
        [HttpGet]
        public PartialViewResult Create()
        {
            ViewBagClient();
            ViewBagProduct();

            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Sale sale)
        {
          
            sale.Product= _dbContext.Products.Where( p=>p.URUNID==sale.URUN).FirstOrDefault();
            int count = (int)sale.Product.STOK;
            if(count< sale.ADET)
            {
                ViewBagClient();
                ViewBagProduct();
                ModelState.AddModelError("", $"Stokta sadece {count} adeti vardır. Lütfen tekrar deneyin");
                return RedirectToAction("Index");
            }
            sale.Client= _dbContext.Clients.Where(p=>p.MUSTERIID==sale.MUSTERI).FirstOrDefault();
            //Update stok prduct
            var product= _dbContext.Products.Find(sale.Product.URUNID);
            int? newStok = (int)product.STOK -(int) sale.ADET;
            product.STOK =(byte)newStok; 
            _dbContext.Sales.Add(sale);
            _dbContext.SaveChanges();   
            return RedirectToAction("Index");
        }
    }
}