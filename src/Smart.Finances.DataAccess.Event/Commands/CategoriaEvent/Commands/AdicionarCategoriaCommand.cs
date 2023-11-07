﻿using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Event.Commands.CategoriaEvent.Commands
{
    public class AdicionarCategoriaCommand
    {
        public string? Descricao { get; set; }

        public Categoria ToEntity()
        {
            return new Categoria(Descricao!);
        }
    }
}
