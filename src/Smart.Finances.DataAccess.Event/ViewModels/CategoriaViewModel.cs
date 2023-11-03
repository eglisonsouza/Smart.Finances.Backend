using Smart.Finances.DataAccess.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Finances.DataAccess.Event.ViewModels
{
    public class CategoriaViewModel
    {
        public Guid Id { get; set; }
        public long SequencialId { get; set; }
        public string? Descricao { get; set; }
        public bool EhAtivo { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }

        public static CategoriaViewModel FromEntity(Categoria entity)
        {
            return new CategoriaViewModel
            {
                Id = entity.Id,
                SequencialId = entity.SequencialId,
                Descricao = entity.Descricao,
                EhAtivo = entity.EhAtivo,
                CriadoEm = entity.CriadoEm,
                AtualizadoEm = entity.AtualizadoEm
            };
        }
    }
}
