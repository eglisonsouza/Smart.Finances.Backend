using Smart.Finances.DataAccess.Core.Entity;

namespace Smart.Finances.DataAccess.Event.ViewModels
{
    public class UsuarioViewModel
    {
        public long Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }

        public static UsuarioViewModel FromEntity(Usuario entity)
        {
            return new UsuarioViewModel
            {
                Id = entity.Id,
                Email = entity.Email,
                NomeCompleto = entity.Nome,
                Senha = entity.Senha
            };
        }
    }
}
