using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Community2.Models;
using System.Data;
namespace Community2.Controllers
{
    public class AdminController : Controller
    {

        //
        // GET: /Admin/
        Database1Entities7 ctx = new Database1Entities7();
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
            {
                return View();
            }
            else
                return RedirectToAction("/Main");
        }
        public void Logout()
        {
            Session["Admin"] = null;
            Response.Redirect("/Admin/Main");
        }
        public ActionResult userview()
        {
            if (Session["Admin"] != null)
            {
                List<user> list = ctx.users.ToList();
                return View(list);
            }
            else
                return RedirectToAction("/Index");
        }
        public ActionResult addAdmin()
        {
            if (Session["Admin"] != null)
            {
            return View();
            }
            else
                return RedirectToAction("/Index");
        }
        public void saveadmin(admin a)
        {
            ctx.admins.Add(a);
            try
            {
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Response.Redirect("/Admin/Main");
        }
        public void saveworker(worker_Portfolio a)
        {
            ctx.worker_Portfolio.Add(a);
            try
            {
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Response.Redirect("/Admin/Main");
        }
        public void SaveService(service a)
        {
            ctx.services.Add(a);
            try
            {
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Response.Redirect("/Admin/Main");
        }
        public void SavePromotion(promotion a)
        {
            ctx.promotions.Add(a);
            try
            {
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Response.Redirect("/Admin/Main");
        }
        public ActionResult createWorker()
        {
            if (Session["Admin"] != null)
            {
            return View();
            }
            else
                return RedirectToAction("/Index");
        }

        [HttpPost]
        public ActionResult addworker(worker_Portfolio worker)
        {
            if (Session["Admin"] != null)
            {
            if (ctx.worker_Portfolio.Any(x => x.cnic == worker.cnic))
            {
                ViewBag.message = "CNIC number already exist";
                ViewBag.s = "failed";
                return View();
            }
            else
            {

                ctx.worker_Portfolio.Add(worker);
                ctx.SaveChanges();
                ViewBag.message2 = "You are Successfully Registered";
                ViewBag.s = "Success";
                return View();
            }
            }
            else
                return RedirectToAction("/Index");
        }
        public ActionResult viewWorker()
        {
            if (Session["Admin"] != null)
            {
            List<worker_Portfolio> list = ctx.worker_Portfolio.ToList();
            return View(list);
            }
            else
                return RedirectToAction("/Index");
        }
        public ActionResult addService()
        {
            if (Session["Admin"] != null)
            {
            return View();
                 }
            else
                return RedirectToAction("/Index");
        }
        public ActionResult viewService()
        {
            if (Session["Admin"] != null)
            {
            List<service> list = ctx.services.ToList();
            return View(list);
            }
            else
                return RedirectToAction("/Index");
        }
        public ActionResult addPromotion()
        {        
            if (Session["Admin"] != null)
            {
            return View();
             }
            else
                return RedirectToAction("/Index");
        }
        public ActionResult viewPromotion()
        {
if (Session["Admin"] != null)
            {
            List<promotion> list = ctx.promotions.ToList();
            return View(list);
     }
            else
                return RedirectToAction("/Index");
        }
        public void addUser(user_request request)
        {
            /*if (ctx.user_request.Any(x => x.cnic == request.cnic))
            {
                ViewBag.message = "CNIC number already exist";
                ViewBag.s = "failed";
                return View();
            }
            else
            {*/

            ctx.user_request.Add(request);
            ctx.SaveChanges();
            ViewBag.message2 = "You are Successfully Registered";
            ViewBag.s = "Success";
            Response.Redirect("/Home/Main");
        }

        public void UserRegister(user_request req)
        {
            ctx.user_request.Add(req);
            ctx.SaveChanges();
            List<user_request> list = ctx.user_request.ToList();
            Response.Redirect("/Home/Main");
        }
        public ActionResult UserRegistration()
        {
            if (Session["Admin"] != null)
            {
            IEnumerable<user_request> list = ctx.user_request.ToList();
            return View(list);
                }
            else
                return RedirectToAction("/Index");
        }
        [HttpPost]
        public void validateSignIn(admin admin)
        {
            if (ctx.admins.Any(x => x.username.Equals(admin.username) && x.passwod.Equals(admin.passwod)))
            {
                Session["Admin"] = "Admin";
                Response.Redirect("/Admin/Main");
               
            }
            else
            {
                
                
                Response.Redirect("/Admin/Index");
              
            }
        }
    
    public ActionResult Main()
        {
        if (Session["Admin"] != null)
            {
            return View();
            }
            else
                return RedirectToAction("/Index");
        }

    public ActionResult DeleteUser(int id)
        {
        if (Session["Admin"] != null)
        {
            user user = ctx.users.First(x => x.Id.Equals(id));
            ctx.users.Remove(user);
            ctx.SaveChanges();
            return RedirectToAction("userview");
        }
        else
            return RedirectToAction("Index");
        }
    public ActionResult DeleteService(int id)
    {
        if (Session["Admin"] != null)
        {
            service ser = ctx.services.First(x => x.Id.Equals(id));
            ctx.services.Remove(ser);
            ctx.SaveChanges();
            return RedirectToAction("viewService");
        }
        else
            return RedirectToAction("Index");
    }
    public ActionResult DeletePromotion(int id)
    {
        if (Session["Admin"] != null)
        {
            promotion pro = ctx.promotions.First(x => x.Id.Equals(id));
            ctx.promotions.Remove(pro);
            ctx.SaveChanges();
            return RedirectToAction("viewPromotion");
        }
        else
            return RedirectToAction("Index");
    }
    public ActionResult DeleteWorker(int id)
    {
        if (Session["Admin"] != null)
        {
            worker_Portfolio worker = ctx.worker_Portfolio.First(x => x.Id.Equals(id));
            ctx.worker_Portfolio.Remove(worker);
            ctx.SaveChanges();
            return RedirectToAction("viewWorker");
        }
        else
            return RedirectToAction("Index");
    }
    public ActionResult EditUser(int id)
    {
        if (Session["Admin"] != null)
        {
            user u = ctx.users.First(x => x.Id.Equals(id));
            return View(u);
        }
        else
            return RedirectToAction("/Index");

    }
    public ActionResult EditService(int id)
    {
        if (Session["Admin"] != null)
        {
            service ser = ctx.services.First(x => x.Id.Equals(id));
            return View(ser);
        }
        else
            return RedirectToAction("/Index");

    }
    public ActionResult EditPromotion(int id)
    {
        if (Session["Admin"] != null)
        {
             promotion pro = ctx.promotions.First(x => x.Id.Equals(id));
            return View(pro);
        }
        else
            return RedirectToAction("/Index");

    }
    public ActionResult EditWorker(int id)
    {
        if (Session["Admin"] != null)
        {
            worker_Portfolio worker = ctx.worker_Portfolio.First(x => x.Id.Equals(id));
            return View(worker);
        }
        else
            return RedirectToAction("/Index");

    }
    public ActionResult EditUserinDb(user User)
    {
        if (Session["Admin"] != null)
        {
            user u = ctx.users.FirstOrDefault(x => x.Id == User.Id);
            u.cnic = User.cnic;
            u.contact = User.contact;
            u.address = User.address;
            ctx.SaveChanges();
            return RedirectToAction("userview");
        }
        else
            return RedirectToAction("Index");
    }
    public ActionResult EditServiceinDb(service Service)
    {
        if (Session["Admin"] != null)
        {
            service ser = ctx.services.FirstOrDefault(x => x.Id == Service.Id);
            ser.service_type = Service.service_type;
            ser.no_of_workers = Service.no_of_workers;
            ser.description = Service.description;
            ctx.SaveChanges();
            return RedirectToAction("viewService");
        }
        else
            return RedirectToAction("Index");
    }
    public ActionResult EditPromotioninDb(promotion Promotion)
    {
        if (Session["Admin"] != null)
        {
            promotion pro = ctx.promotions.FirstOrDefault(x => x.Id == Promotion.Id);
            pro.subject = Promotion.subject;
            pro.description = Promotion.description;
            ctx.SaveChanges();
            return RedirectToAction("viewPromotion");
        }
        else
            return RedirectToAction("Index");
    }
    public ActionResult EditWorkerinDb(worker_Portfolio worker)
    {
        if (Session["Admin"] != null)
        {
            worker_Portfolio w = ctx.worker_Portfolio.FirstOrDefault(x => x.Id == worker.Id);
            w.name = worker.name;
            w.cnic = worker.cnic;
            w.contact1 = worker.contact1;
            w.contact2 = worker.contact2;
            w.address = worker.address;
            w.experience_ = worker.experience_;
            //ctx.Entry(worker) = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
            return RedirectToAction("viewWorker");
        }
        else 
            return RedirectToAction("Index");

    }




    }

}