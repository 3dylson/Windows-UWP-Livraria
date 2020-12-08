using LivrariaVirtualApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaVirtualApp.Domain
{
    public interface IUnitOfWork
    {
        ILivroRepository LivroRepository { get; }
        IBookRepository AutorRepository { get; }
        ICategoryRepository EditoraRepository { get; }
        IOrderRepository LivrariaRepository { get; }
        IParceiroRepository ParceiroRepository { get; }
        IWishlistRepository UtilizadorRepository { get; }

    }
}
