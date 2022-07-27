using System;
using System.Collections.Generic;
using ASPNET_CRUD_MVC.Models;
using ASPNET_CRUD_MVC.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_CRUD_MVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<UserModel> listUsers = _repository.GetAll();
            return View(listUsers);
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel userModel)
        {
            UserModel userDb = _repository.GetByLogin(userModel.Name);
            if (userDb != null &&
                userDb.Name == userModel.Name && userDb.Password == userModel.Password)
            {

                TempData["SucessMessage"] = "User authenticate";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = $"User not found or password wrong";
                return RedirectToAction("Index");
            }
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(UserModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Add(userModel);
                    TempData["SucessMessage"] = "User was stored successfully";
                    return RedirectToAction("Index");
                }


                return View(userModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"We have a problem during process to create a user. Details {ex.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}

