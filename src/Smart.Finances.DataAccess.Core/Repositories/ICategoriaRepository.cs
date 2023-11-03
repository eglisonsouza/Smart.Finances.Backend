﻿using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Core.Repositories
{
    public interface ICategoriaRepository
    {
        Categoria ObterPorId(long sequencialId);
        Categoria Atualizar(Categoria categoria);
    }
}
