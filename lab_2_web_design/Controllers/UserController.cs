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
using lab_2_web_design.Services;

namespace lab_2_web_design.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IRepository _dataRepository;
        private IUser _userService;

        public UserController(IRepository dataRepository, IUser userService)
        {
            _dataRepository = dataRepository;
            _userService = userService;
        }
        // GET: User
        public ActionResult Index()
        {
            var users = _dataRepository.GetAllUsers();
            foreach(User user in users)
            {
                user.hasYarn = _userService.UserhasYarn(user);
            }
            return View(users);            
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _dataRepository.getUser(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,FirstName,LastName,EmailAdress,hasYarn")] User user)
        {
            if (ModelState.IsValid)
            {
                _dataRepository.addUser(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _dataRepository.getUser(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,FirstName,LastName,EmailAdress")] User user)
        {
            if (ModelState.IsValid)
            {
                _dataRepository.updateUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _dataRepository.getUser(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            _dataRepository.removeUser(user);
            return RedirectToAction("Index");
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = _dataRepository.getUser(id);
            return RedirectToAction("Index");
        }
        

    }
}
