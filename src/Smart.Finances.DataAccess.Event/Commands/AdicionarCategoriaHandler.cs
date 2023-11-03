using Smart.Finances.DataAccess.Core.Common.Events;
using Smart.Finances.DataAccess.Event.ViewModels;
using Smart.Finances.DataAccess.Infra.Persistence.Configurations;

namespace Smart.Finances.DataAccess.Event.Commands
{
    public class AdicionarCategoriaHandler : IRequestHandler<AdicionarCategoriaCommand, CategoriaViewModel>
    {
        private readonly SqlServerDbContext _context;

        public AdicionarCategoriaHandler(SqlServerDbContext context)
        {
            _context = context;
        }

        public Task<CategoriaViewModel> Handle(AdicionarCategoriaCommand request)
        {
            var result = _context.AddAsync(request.ToEntity());
            _context.SaveChanges();
            return Task.FromResult(CategoriaViewModel.FromEntity(result.Result.Entity));
        }
    }
}
