using SampleWebApp.Models;

namespace SampleWebApp.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private List<User> _users;

        public List<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.Find(u => u.Id == id);
        }

        public void Add(User entity)
        {
            _users.Add(entity);
        }
    }
}
