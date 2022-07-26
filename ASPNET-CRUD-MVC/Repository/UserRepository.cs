using System;
using System.Collections.Generic;
using System.Linq;
using ASPNET_CRUD_MVC.Data;
using ASPNET_CRUD_MVC.Models;

namespace ASPNET_CRUD_MVC.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;
        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public UserModel Add(UserModel userModel)
        {
            userModel.CreatedTimestamp = DateTime.Now;
            _databaseContext.User.Add(userModel);
            _databaseContext.SaveChanges();
            return userModel;
        }

        public bool Delete(String login)
        {
            UserModel userDb = GetByLogin(login);
            if (userDb == null) throw new System.Exception("error during User delete");

            _databaseContext.User.Remove(userDb);
            _databaseContext.SaveChanges();
            return true;
        }

        public List<UserModel> GetAll()
        {
            return _databaseContext.User.ToList();
        }

        public UserModel GetByLogin(String login)
        {
            return _databaseContext.User.FirstOrDefault(a => a.Name == login);
        }

        public UserModel Update(UserModel userModel)
        {
            UserModel userDb = GetByLogin(userModel.Name);
            if (userDb == null) throw new System.Exception("error during user update");


            userDb.Name = userModel.Name;
            userDb.Email = userModel.Email;
            userDb.Password = userModel.Password;
            _databaseContext.User.Update(userDb);
            _databaseContext.SaveChanges();
            return userModel;
        }


    }
}

