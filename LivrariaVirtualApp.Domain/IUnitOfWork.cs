using LivrariaVirtualApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaVirtualApp.Domain
{
    public interface IUnitOfWork
    {
        ILivroRepository LivroRepository { get; }
        IAutorRepository AutorRepository { get; }
        IEditoraRepository EditoraRepository { get; }
        ILivrariaRepository LivrariaRepository { get; }
        IParceiroRepository ParceiroRepository { get; }
        IUtilizadorRepository UtilizadorRepository { get; }

    }
}
