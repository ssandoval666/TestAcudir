using AcudirTes2.Helpers;
using AcudirTes2.Models;
using CryptoHelper;

namespace AcudirTes2.Services
{
    public interface IUsuarioService
    {
        bool ValidarUsuario(string UserName, string spassword);
    }

    public class UsuarioService : IUsuarioService
    {
        private DataContext _context;

        public UsuarioService(DataContext context)
        {
            _context = context;
        }        
       
        bool IUsuarioService.ValidarUsuario(string UserName, string spassword)
        {
            var user = _context.Usuario.Where(x => x.UserName == UserName).FirstOrDefault();
            if (user != null)
            {
                return Crypto.VerifyHashedPassword(user.Password, spassword);
            }
            return false ;
            
        }
    }
}
