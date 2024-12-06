using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _50_Ders_MVC_Projesi.Models.Entities;

namespace _50_Ders_MVC_Projesi.Controllers
{
    public class ProductController : Controller
    {
        Entities _dbContext=new Entities(); 
        // GET: Product
        public ActionResult Index()
        {
            var values= _dbContext.Products.ToList();   
            return View(values);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBagKategori();
            return View();
        }

        private void ViewBagKategori()
        {
            var kategorilist = _dbContext.Categories.ToList();
            ViewBag.Kategoriler = (from k in kategorilist
                                   select new SelectListItem
                                   {
                                       Text = k.KATEGORIAD,
                                       Value = k.KATEGORIID.ToString(),
                                   }).ToList();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBagKategori();
                return View(product);
            }
            //Definition of product.Category
            product.Category = _dbContext.Categories.Where(c => c.KATEGORIID == product.URUNKATEGORI).FirstOrDefault();
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var product=_dbContext.Products.Find(id);
            _dbContext.Products.Remove(product);    
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBagKategori();
           return View(_dbContext.Products.Find(id));
        } 
        [HttpPost]
        public ActionResult Update(Product product)
        {            
            
            if (!ModelState.IsValid)
            {
                ViewBagKategori();
                return View(product);
            }
            var value= _dbContext.Products.Find(product.URUNID);
            value.URUNAD = product.URUNAD;
            value.MARKA = product.MARKA;
            value.Category = _dbContext.Categories.Where(k => k.KATEGORIID == product.URUNKATEGORI).FirstOrDefault();
            value.URUNKATEGORI = product.URUNKATEGORI;
            value.FIYAT = product.FIYAT;
            value.STOK = product.STOK;
            _dbContext.SaveChanges();
           return RedirectToAction("Index");
        }
    }
}