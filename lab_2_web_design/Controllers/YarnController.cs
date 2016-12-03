using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lab_2_web_design.Data;
using lab_2_web_design.Models;

namespace lab_2_web_design.Controllers
{
    [Authorize]
    public class YarnController : Controller
    {
        private readonly IRepository _dataRepository;

        public YarnController(IRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: Yarns
        public ActionResult Index()
        {
            var yarn = _dataRepository.GetAllYarn();
            return View(yarn);
        }

        // GET: Yarns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yarn yarn = _dataRepository.getYarn(id.Value);
            if (yarn == null)
            {
                return HttpNotFound();
            }
            return View(yarn);
        }

        // GET: Yarns/Create
        public ActionResult Create()
        {
            GetUserList();
            return View();
        }

        // POST: Yarns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YarnId,ColorName,BrandName,Skeins,YarnType")] Yarn yarn, List<int> UserIds)
        {
            if (ModelState.IsValid)
            {
                yarn.Users = new List<User>();
                foreach (var userId in UserIds)
                {
                    yarn.Users.Add(new User
                    {
                        UserId = userId, hasYarn=true
                    });
                }

                _dataRepository.addYarn(yarn);

                return RedirectToAction("Index");
            }

            return View(yarn);
        }

        // GET: Yarns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yarn yarn = _dataRepository.getYarn(id.Value);
            if (yarn == null)
            {
                return HttpNotFound();
            }
            return View(yarn);
        }

        // POST: Yarns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YarnId,ColorName,BrandName,Skeins,YarnType")] Yarn yarn)
        {
            if (ModelState.IsValid)
            {
                _dataRepository.updateYarn(yarn);
                return RedirectToAction("Index");
            }
            return View(yarn);
        }

        // GET: Yarns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yarn yarn = _dataRepository.getYarn(id.Value);
            if (yarn == null)
            {
                return HttpNotFound();
            }
            return View(yarn);
        }

        // POST: Yarns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yarn yarn = _dataRepository.getYarn(id);
            _dataRepository.removeYarn(yarn);
            return RedirectToAction("Index");
        }
        private void GetUserList()
        {
            var users = _dataRepository.GetAllUsers();
            ViewBag.UserList = new MultiSelectList(users, "UserId", "FirstName");
        }
        
    }
}
