﻿namespace Smart.Finances.Event.Commands.UsuarioEvent.Commands
{
    public class EditarUsuarioCommand
    {
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
    }
}