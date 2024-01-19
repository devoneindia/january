using BlazorCRUD.Context;
using BlazorCRUD.Contracts;
using BlazorCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Services
{
    public class UserManager : IUser
    {
        readonly UserDbContext _dbContext = new UserDbContext();
        public UserManager(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(User user)
        {
            try
            {
                _dbContext.userDetail.Add(user);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                User? user = _dbContext.userDetail.Find(id);
                if (user != null)
                {
                    _dbContext.userDetail.Remove(user);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public User GetUserData(int id)
        {
            try
            {
                User? user = _dbContext.userDetail.Find(id);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public List<User> GetUserDetails()
        {
            try
            {
                return _dbContext.userDetail.ToList();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void UpdateUserDetails(User user)
        {
            try
            {
                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        //public List<User> GetUserDetails() 
        //{
        //    try
        //    {
        //        return _dbContext.userDetail.ToList();
        //    }
        //    catch 
        //    {
        //        throw;
        //    }
        //}
        //public void AddUser(User user)
        //{
        //    try
        //    {
        //        _dbContext.userDetail.Add(user);
        //        _dbContext.SaveChanges();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        //public void UpdateUserDetails(User user)
        //{
        //    try
        //    {
        //        _dbContext.Entry(user).State = EntityState.Modified;
        //        _dbContext.SaveChanges();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        //public User GetUserData(int id)
//        {
//            try
//            {
//                User? user = _dbContext.Users.Find(id);
//                if (user != null)
//                {
//                    return user;
//                }
//                else
//                {
//                    throw new ArgumentNullException();
//}
//            }
//            catch
//            {
//    throw;
//}
//        }
//        //To Delete the record of a particular user
//        public void DeleteUser(int id)
//{
//    try
//    {
//        User? user = _dbContext.Users.Find(id);
//        if (user != null)
//        {
//            _dbContext.Users.Remove(user);
//            _dbContext.SaveChanges();
//        }
//        else
//        {
//            throw new ArgumentNullException();
//        }
//    }
//    catch
//    {
//        throw;
//    }
//}
    }
}
