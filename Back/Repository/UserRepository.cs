using Back.Data;
using Back.Models;
using Back.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly DatabaseContext _databaseContext;
            public UserRepository(DatabaseContext context)
            {
                _databaseContext = context;
            }

        public  async Task<List<UserModels>> BuscarTodos()
        {
             return await _databaseContext.Users.ToListAsync();

        }

        public async Task<UserModels> BuscarPorId(int id)
        {
           return await _databaseContext.Users.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<UserModels> Atualizar(UserModels usuario, int id)
        {
            UserModels usuarioPorId = await BuscarPorId(id);
            if(usuarioPorId == null)
            {
                usuarioPorId.Name = usuario.Name;
                usuarioPorId.Email = usuario.Email;
                usuarioPorId.Phone = usuario.Phone;
                usuarioPorId.Address = usuario.Address;

            }
            await _databaseContext.Users.AddAsync(usuario);
            await _databaseContext.SaveChangesAsync();
            return (usuario);
        }


        public async Task<UserModels> Adicionar(UserModels usuario)
        {
            if(usuario.Id == 0)
            {
               int maxId = await _databaseContext.Users.MaxAsync(x => x.Id);
               usuario.Id = maxId + 1;
            }
            await _databaseContext.Users.AddAsync(usuario);
            await _databaseContext.SaveChangesAsync();
            return (usuario);
        }



        public async Task<bool> Deletar(int id)
        {
            UserModels usuarioPorId = await BuscarPorId(id);
            if(usuarioPorId == null)
            {
               throw new ArgumentException($"O Id: {id} não Foi encontrado na base de dados");
            }
            _databaseContext.Users.Remove(usuarioPorId);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
    }
}
