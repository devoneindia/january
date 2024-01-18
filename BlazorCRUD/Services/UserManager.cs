using BlazorCRUD.Contexts;
using BlazorCRUD.Interfaces;
using BlazorCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Services
{
    public class UserManager : IUser
    {
        readonly EmployeeDbContext _dbContext = new();
        public UserManager(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //To Get all user details
        public List<UserDetail> GetUserDetails()
        {
            try
            {
                return _dbContext.UserDetails.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new user record
        public void AddUser(UserDetail user)
        {
            try
            {
                _dbContext.UserDetails.Add(user);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar user
        public void UpdateUserDetails(UserDetail user)
        {
            try
            {
                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular user
        public UserDetail GetUserData(int id)
        {
            try
            {
                UserDetail? user = _dbContext.UserDetails.Find(id);
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
                throw;
            }
        }
        //To Delete the record of a particular user
        public void DeleteUser(int id)
        {
            try
            {
                UserDetail? user = _dbContext.UserDetails.Find(id);
                if (user != null)
                {
                    _dbContext.UserDetails.Remove(user);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}