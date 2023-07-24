using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Models;
using Microsoft.AspNetCore.Mvc;

namespace Back.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModels>>BuscarTodos();
        Task <UserModels>BuscarPorId(int id);
        Task<UserModels>Atualizar(UserModels usuario, int id);
        Task<UserModels>Adicionar(UserModels usuario);
        Task<bool>Deletar (int id);

    }
}
