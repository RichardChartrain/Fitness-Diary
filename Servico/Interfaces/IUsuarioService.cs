﻿using FitnessDiary.Entidades;

namespace FitnessDiary.Servico.Implementacoes
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> GetUsuarioAsync();
        Task<Usuario> GetUsuarioByIdAsync(int usuarioId);
        Task AddUsuarioAsync(Usuario usuario);
        Task UpdateUsuarioAsync(Usuario usuario);
        Task DeleteUsuarioAsync(Usuario usuario);
    }
}
