using System;

/// <summary>
/// Classe que representa uma armadura no jogo.
/// Herda de Item e adiciona atributo de defesa.
/// </summary>
public class Armadura : Item
{
    // Pontos de defesa da armadura
    public int Defesa { get; set; }

    /// <summary>
    /// Construtor da armadura.
    /// </summary>
    /// <param name="nome">Nome da armadura</param>
    /// <param name="defesa">Pontos de defesa</param>
    public Armadura(string nome, int defesa) : base(nome, 0)
    {
        Nome = nome;     // Define o nome
        Defesa = defesa; // Define a defesa
    }
}