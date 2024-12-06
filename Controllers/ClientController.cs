using _50_Ders_MVC_Projesi.Models.Entities;
using System.Linq;
using System.Web.Mvc;

namespace _50_Ders_MVC_Projesi.Controllers
{
    public class ClientController : Controller
    {
        Entities _dbContext = new Entities();
        // GET: Client
        public ActionResult Index()
        {
            return View(_dbContext.Clients.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Client client)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
            return View();
        }

        public ActionResult Delete(int id)
        {
            var client = _dbContext.Clients.Find(id);
            _dbContext.Clients.Remove(client);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var value= _dbContext.Clients.Find(id);
            return View(value); 
        } 
        [HttpPost]
        public ActionResult Update(Client client)
        {
            var value= _dbContext.Clients.Find(client.MUSTERIID);
            value.MUSTERIAD = client.MUSTERIAD;
            value.MUSTERISOYAD = client.MUSTERISOYAD;   
            _dbContext.SaveChanges();
            return RedirectToAction("Index"); 
        }

    }
}