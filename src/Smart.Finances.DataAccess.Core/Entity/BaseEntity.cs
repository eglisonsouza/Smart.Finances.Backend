namespace Smart.Finances.DataAccess.Core.Entity
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
        public long SequencialId { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public DateTime AtualizadoEm { get; private set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CriadoEm = DateTime.Now;
        }
    }
}
