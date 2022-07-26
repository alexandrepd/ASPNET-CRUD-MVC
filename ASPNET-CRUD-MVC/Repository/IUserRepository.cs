using System;
using System.Collections.Generic;
using ASPNET_CRUD_MVC.Models;

namespace ASPNET_CRUD_MVC.Repository
{
    public interface IUserRepository
    {
        UserModel Add(UserModel userModel);
        UserModel GetByLogin(String login);
        UserModel Update(UserModel userModel);
        bool Delete(String login);

        List<UserModel> GetAll();
    }
}

