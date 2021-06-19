using BlueberryPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueberryPro.DAL
{
    public interface IUser
    {
        List<UserModel> List();

        void Insert(UserModel User);

        UserModel Login(UserModel user);
    }
}
