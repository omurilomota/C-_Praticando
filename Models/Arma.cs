using System;

/// <summary>
/// Classe que representa uma arma no jogo.
/// Herda de Item e adiciona atributos de dano e custo de stamina.
/// </summary>
public class Arma : Item
{
    // Dano causado pela arma
    public int Dano { get; set; }

    // Custo de stamina para usar a arma
    public int StaminaCost { get; set; }

    /// <summary>
    /// Construtor da arma.
    /// </summary>
    /// <param name="nome">Nome da arma</param>
    /// <param name="dano">Dano causado</param>
    /// <param name="staminaCost">Custo de stamina</param>
    public Arma(string nome, int dano, int staminaCost) : base(nome, 0)
    {
        Nome = nome;          // Define o nome
        Dano = dano;         // Define o dano
        StaminaCost = staminaCost;  // Define o custo de stamina
    }
}