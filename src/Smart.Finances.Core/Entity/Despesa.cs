using System.Globalization;

namespace Smart.Finances.Core.Entity
{
    public class Despesa : BaseEntity
    {
        public string Descricao { get; private set; }
        public double Valor { get; private set; }
        public Categoria Categoria { get; private set; }
        public Guid CategoriaId { get; private set; }
        public Usuario Usuario { get; private set; }
        public Guid UsuarioId { get; private set; }
        public bool EhAtivo { get; private set; }
        public int QuantidadeParcela { get; private set; }
        public List<Parcelas> Parcelas { get; private set; }
        public bool EhRecorrente { get; private set; }

        public Despesa(string descricao, double valor, int quantidadeParcela, bool ehRecorrente, Guid categoriaId, Guid usuarioId) : base()
        {
            Descricao = descricao;
            Valor = valor;
            EhAtivo = true;
            QuantidadeParcela = quantidadeParcela;
            EhRecorrente = ehRecorrente;
            CategoriaId = categoriaId;
            UsuarioId = usuarioId;
        }

        public void GerarParcelas(DateTime PrimeiroVencimento)
        {
            var valorParcela = Valor / QuantidadeParcela;
            Parcelas = new List<Parcelas>();
            for (int i = 0; i < QuantidadeParcela; i++)
            {
                Parcelas.Add(new Parcelas(PrimeiroVencimento.AddMonths(1 * i), (1 + i), $"{(i + 1)}/{QuantidadeParcela}", valorParcela, Id));
            }
        }

        public void SetCategoria(Categoria categoria)
        {
            Categoria = categoria;
        }

        public void SetUsuario(Usuario usuario)
        {
            Usuario = usuario;
        }

        public void Inativar()
        {
            EhAtivo = false;
        }

        public string GerarMensagem()
        {
            return @$"Olá!

Você cadastrou uma nova despesa no valor de {Valor.ToString("C2", CultureInfo.CurrentCulture)} com a descrição {Descricao}.
A primeira parcela vence em {Parcelas[0].Vencimento.ToShortDateString()}.
A última parcela vence em {Parcelas[QuantidadeParcela - 1].Vencimento.ToShortDateString()}.
O valor de cada parcela é de R${Parcelas[0].ValorParcela}.

Obrigado por utilizar o Smart Finances!";
        }
    }
}
