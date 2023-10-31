namespace Smart.Finances.DataAccess.Core.Entity
{
    public abstract class BaseEntity
    {
        public long Id { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public DateTime AtualizadoEm { get; private set; }
    }
}
