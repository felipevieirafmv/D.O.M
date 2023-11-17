using System.Threading.Tasks;
using DomBack.Model;
using DTO;
using DomBack.Model;

namespace DomBack.Services;

public interface IUserService
{
    Task Create(UserData data);
    Task<Usuario> GetByLogin(string Login);
}