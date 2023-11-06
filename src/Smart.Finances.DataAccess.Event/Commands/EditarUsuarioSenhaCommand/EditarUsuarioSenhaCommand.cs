using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Event.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Finances.DataAccess.Event.Commands.EditarUsuarioSenhaCommand
{
    public class EditarUsuarioSenhaCommand
    {
        public long Id { get; set; }
        public string Senha { get; set; }
    }
}
