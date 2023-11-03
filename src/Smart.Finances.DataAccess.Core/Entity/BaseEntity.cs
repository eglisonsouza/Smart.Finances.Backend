namespace Smart.Finances.DataAccess.Core.Entity
{
    public abstract class BaseEntity
    {
        public long Id { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public DateTime AtualizadoEm { get; private set; }


        protected BaseEntity()
        {
            CriadoEm = DateTime.Now;
        }

        protected void Atualizar(long id)
        {
            Id = id;
            AtualizadoEm = DateTime.Now;
        }

        public void Atualizar()
        {
            AtualizadoEm = DateTime.Now;
        }
    }
}
