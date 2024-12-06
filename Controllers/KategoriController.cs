using _50_Ders_MVC_Projesi.Models.Entities;
using System.Linq;
using System.Web.Mvc;
using PagedList;


namespace _50_Ders_MVC_Projesi.Controllers
{
    public class KategoriController : Controller
    {
        Entities _dbContext = new Entities();
        // GET: Kategori
        public ActionResult Index(int? page)
        {
            int pageNumber=page ?? 1;
            int pageSize = 4;
            var values = _dbContext.Categories.ToList().ToPagedList(pageNumber, pageSize);
            return View(values);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            //Le recherche est en fonction de id
            var category = _dbContext.Categories.Find(id);
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");  
        }
        [HttpGet]
        public ActionResult Update(int id) 
        {
            var value= _dbContext.Categories.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult Update(Category category)
        {
            var value= _dbContext.Categories.Find(category.KATEGORIID);
            value.KATEGORIAD= category.KATEGORIAD;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
  
    }
}