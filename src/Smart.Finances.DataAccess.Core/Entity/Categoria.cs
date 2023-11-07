namespace Smart.Finances.DataAccess.Core.Entity
{
    public class Categoria : BaseEntity
    {
        public string Descricao { get; private set; }
        public bool EhAtivo { get; private set; }

        public Categoria(string descricao) : base()
        {
            Descricao = descricao;
            EhAtivo = true;
        }

        public void Atualizar(string? descricao)
        {
            base.Atualizar();
            Descricao = descricao!;
        }
    }
}
