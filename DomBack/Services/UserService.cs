using System.Threading.Tasks;
using DomBack.Model;
using System.Linq;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DomBack.Services;

public class UserService : IUserService
{
    DomdbContext ctx;
    public UserService(DomdbContext ctx)
        => this.ctx = ctx;
    public async Task Create(UserData data)
    {
        Usuario usuario = new Usuario();
        usuario.Nome = data.Login;
        usuario.Senha = data.Password;
        usuario.Salt = "?????";

        this.ctx.Add(usuario);
        await this.ctx.SaveChangesAsync();
    }

    public async Task<Usuario> GetByLogin(string login)
    {
        var query =
            from u in this.ctx.Usuarios
            where u.Nome == login
            select u;
        
        return await query.FirstOrDefaultAsync();
    }
}