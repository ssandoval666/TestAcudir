using AcudirTes2.Helpers;
using AcudirTes2.Models;

namespace AcudirTes2.Services
{
    public interface IPeopleService
    {
        IEnumerable<People> GetAll();
        People GetById(int id);
        People GetShuffle();
        void Delete(int id);
    }

    public class PeopleService : IPeopleService
    {
        private DataContext _context;

        public PeopleService(DataContext context)
        {
            _context = context;
        }        

        IEnumerable<People> IPeopleService.GetAll()
        {
            return _context.People;
        }

        People IPeopleService.GetById(int id)
        {
            var user = _context.People.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        People IPeopleService.GetShuffle()
        {
            var user = _context.People;
            return user.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
        }

        void IPeopleService.Delete(int id)
        {
            var user = _context.People.Find(id);

            if (user != null)
            {
                //_context.People.Remove(user);
                user.Activo = false;
                _context.SaveChanges();
            }
            else throw new KeyNotFoundException("User not found");
        }
    }
}
