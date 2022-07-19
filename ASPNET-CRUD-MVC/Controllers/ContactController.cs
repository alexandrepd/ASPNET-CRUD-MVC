using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_CRUD_MVC.Models;
using ASPNET_CRUD_MVC.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNET_CRUD_MVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _repository;
        public ContactController(IContactRepository repository)
        {
            _repository = repository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<ContactModel> list = _repository.GetAll();
            return View(list);
        }

        public IActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateContact(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(contact);
                return RedirectToAction("Index");
            }

            return View(contact);

        }

        [HttpPost]
        public IActionResult EditContact(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        public IActionResult EditContact(int id)
        {
            ContactModel model = _repository.GetById(id);
            return View(model);
        }


        public IActionResult ConfirmToDeleteContact(int id)
        {
            ContactModel model = _repository.GetById(id);
            return View(model);
        }

        public IActionResult DeleteContact(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
