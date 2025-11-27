using System.Collections.ObjectModel;

using TRPO_pr12.Data;

namespace TRPO_pr12.Service
{
    public class UsersServise
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;

        public ObservableCollection<User> Users { get; set; } = new();

        public UsersServise()
        {
            GetAll();
        }

        public void Add(User? user)
        {
            var _user = new User
            {
                Id = user.Id,
                Login = user.Login,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                CreatedAt = user.CreatedAt
            };
            _db.Add(_user);
            Commit();
            Users.Add(_user);
        }

        public int Commit() => _db.SaveChanges();

        public void GetAll()
        {
            var users = _db.Users.ToList();
            Users.Clear();
            foreach(var user in users)
            {
                Users.Add(user);
            }
        }

        public void Remove(User user)
        {
            _db.Remove<User>(user);
            if (Commit() > 0)
                if (Users.Contains(user))
                    Users.Remove(user);
        }
    }
}
