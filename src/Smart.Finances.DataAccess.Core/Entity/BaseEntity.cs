namespace Smart.Finances.Core.Entity
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public DateTime AtualizadoEm { get; private set; }


        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CriadoEm = DateTime.Now;
        } 

        public void Atualizar()
        {
            AtualizadoEm = DateTime.Now;
        }
    }
}
