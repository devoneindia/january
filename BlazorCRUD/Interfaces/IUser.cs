using BlazorCRUD.Models;
namespace BlazorCRUD.Interfaces
{
    public interface IUser
    {
        public List<UserDetail> GetUserDetails();
        public void AddUser(UserDetail user);
        public void UpdateUserDetails(UserDetail user);
        public UserDetail GetUserData(int id);
        public void DeleteUser(int id);
    }

}

