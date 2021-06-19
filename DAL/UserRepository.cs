using BlueberryPro.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BlueberryPro.DAL
{
    public class UserRepository : IUser
    {

        private readonly IConfiguration configuration;

        public UserRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void Insert(UserModel User)
        {
            try
            {
                //SqlConnection conn = new SqlConnectino();
                using (SqlConnection conn = new SqlConnection(configuration.GetConnectionString("DBConn")))
                {
                    conn.Open();
                     //conn.Execute("insert into tblUser(FullName, Email, Password, Gender) values('"+User.FullName+"', '"+User.Email+"', '"+User.Password+"', '"+User.Gender+"')");

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@FullName", User.FullName);
                    param.Add("@Email", User.Email);
                    param.Add("@Password", User.Password);
                    param.Add("@Gender", User.Gender);
                    conn.Execute("sp_user_insert", param, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<UserModel> List()
        {
            throw new NotImplementedException();
        }

        public UserModel Login(UserModel user)
        {
            using (SqlConnection conn = new SqlConnection(configuration.GetConnectionString("DBConn")))
            {
                conn.Open();
                DynamicParameters param = new DynamicParameters();

                param.Add("@Email", user.Email);
                param.Add("@Password", user.Password);

                var loginData = conn.Query<UserModel>("sp_login", param, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                return loginData;
            }
        }
    }
}
