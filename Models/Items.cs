using System;

/// <summary>
/// Classe base para todos os itens do jogo.
/// </summary>
public class Item
{
    // Nome do item
    public String Nome { get; set; }
    
    // Valor do item (para possíveis transações futuras)
    public int Value { get; set; }

    /// <summary>
    /// Construtor do item.
    /// Permite criar um item com nome e valor.
    /// </summary>
    /// <param name="nome">Nome do item</param>
    /// <param name="value">Valor do item</param>
    public Item(string nome, int value)
    {
        Nome = nome;              // Define o nome
        this.Value = value;     // Define o valor
    }
}