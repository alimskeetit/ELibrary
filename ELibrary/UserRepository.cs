using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ELibrary
{
    public class UserRepository
    {
        ELibrary.AppContext db;

        public UserRepository()
        {

        }

        public UserRepository(ELibrary.AppContext db)
        {
            this.db = db;
        }

        public User Select(int id)
        {
            return db.Users.FirstOrDefault(user => user.Id == id);
        }

        public List<User> SelectAll()
        {
            return db.Users.ToList();
        }

        public void Add(User user)
        {
            db.Add(user);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(db.Users.FirstOrDefault(user => user.Id == id));
            db.SaveChanges();
        }

        public void UpdateName(int id, string name)
        {
            db.Users.FirstOrDefault(user => user.Id == id).Name = name;
            db.SaveChanges();
        }

        public void UpdateEmail(int id, string email)
        {
            db.Users.FirstOrDefault(user => user.Id == id).Email = email;
            db.SaveChanges();
        }

        public int CountOfBooks(int userId)
        {
            var user = db.Users.FirstOrDefault(user => user.Id == userId);
            return user.Books.Count();
        }
    }
}
