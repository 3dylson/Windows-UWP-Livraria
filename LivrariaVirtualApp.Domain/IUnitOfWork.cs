using LivrariaVirtualApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaVirtualApp.Domain
{
    public interface IUnitOfWork
    {
        ILivroRepository LivroRepository { get; }

    }
}
