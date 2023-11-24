namespace Smart.Finances.Core.Utils.MessageError
{
    public static class MessageError
    {
        public const string IdIsRequired = "O Id é obrigatório.";
        public const string DescriptionIsRequired = "A descrição é obrigatória.";
        public const string ValueRange = $"O valor deve ser maior que 0.";
        public const string CategoryIdIsRequired = "O id da categoria é obrigatório.";
        public const string UserIdIsRequired = "O id do usuário é obrigatório.";
        public const string UserEmailIsRequired = "O email do usuário é obrigatório.";
        public const string QuantityRange = "A quantidade de parcelas deve ser maior ou igual a 0.";
        public const string IsMonthyRequired = "Define se a divida é mensal ou extra.";
        public const string FirstDueIsRequired = "A data de vencimento da primeira parcela é obrigatória.";
        public const string InstallmentIdIsRequired = "O id da parcela é obrigatório.";
        public const string ExpenseIdIsRequired = "O id da despesa é obrigatório.";
        public const string ReferenceMonthIsRequired = "O mês de referência é obrigatório.";
        public const string NameIsRequired = "O nome é obrigatório.";
        public const string PasswordIsRequired = "A senha é obrigatória.";
        public const string LoginInvalid = "Usuário ou senha inválidos";
        public const string CategoryNotFound = "Categoria não encontrada.";
        public const string ExpenseNotFound = "Despesa não encontrada.";
        public const string InstallmentNotFound = "Parcela não encontrada.";
        public const string UserNotFound = "Usuário não encontrado.";
    }
}
