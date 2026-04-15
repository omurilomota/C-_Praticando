using System;
using System.Collections.Generic;

/// <summary>
/// Classe que representa o jogador do jogo.
/// Armazena atributos como vida, stamina, inventário e itens equipped.
/// </summary>
public class Jogador
{
    // Atributos do jogador
    public int Stamina { get; set; }          // Stamina atual
    public int StaminaMaxima { get; set; }    // Stamina máxima
    public Arma ArmaAtual { get; set; }       // Arma que o jogador está usando atualmente
    public List<Arma> Armas { get; set; }   // Lista de armas adquiridas
    public List<Armadura> Armaduras { get; set; } // Lista de armaduras adquiridas
    public int Vida { get; set; }            // Vida atual
    public int VidaMaxima { get; set; }      // Vida máxima
    public int Pocoes { get; set; }        // Quantidade de poções disponíveis
    public bool Vivo { get; set; }         // Indica se o jogador está vivo
    
    // Power-ups ativos do jogador
    public List<PowerUp> ActivePowerUps { get; set; } = new List<PowerUp>();
    
    // Inventário do jogador (itens para equipar)
    public List<Item> Inventory {get; set;} = new List<Item>();
    
    // Item atualmente equipado
    public Arma? EquippedWeapon { get; set; }     // Arma equipada
    public Armadura? EquippedArmor { get; set; } // Armadura equipada

    /// <summary>
    /// Equipa um item (arma ou armadura) do inventário.
    /// </summary>
    /// <param name="item">Item a ser equipado</param>
    public void EquiparItem(Item item)
    {
        // Verifica se o item é uma arma
        if (item is Arma arma)
        {
            EquippedWeapon = arma;  // Define a arma equipada
            ArmaAtual = arma;     // Define como arma atual
        }
        // Verifica se o item é uma armadura
        else if (item is Armadura armadura)
        {
            EquippedArmor = armadura;  // Define a armadura equipada
        }
        Console.WriteLine($"Item: {item.Nome} equipado com sucesso!");
    }

    /// <summary>
    /// Aplica um power-up ao jogador.
    /// </summary>
    /// <param name="p">Power-up a ser aplicado</param>
    public void ApplyPowerUp(PowerUp p)
    {
        ActivePowerUps.Add(p);  // Adiciona à lista de power-ups
        p.Effect(this, null);    // Aplica o efeito do power-up
    }

    /// <summary>
    /// Atualiza todos os power-ups activos (decrementa duração).
    /// </summary>
    public void UpdatePowerUps()
    {
        // Itera sobre uma cópia da lista para permitir remoção
        foreach (var p in ActivePowerUps.ToList())
        {
            p.Duration--;  // Decrementa a duração
            if (p.Duration <= 0)
            {
                // Remove o power-up se a duração acabou
                ActivePowerUps.Remove(p);
            }
            else
            {
                // Caso contrário, aplica o efeito novamente
                p.Effect(this,null);
            }
        }
    }

    /// <summary>
    /// Construtor do jogador com valores padrão.
    /// </summary>
    /// <param name="vidaInicial">Vida inicial (padrão: 100)</param>
    /// <param name="staminaInicial">Stamina inicial (padrão: 100)</param>
    public Jogador(int vidaInicial = 100, int staminaInicial = 100)
    {
        VidaMaxima = vidaInicial;    // Define vida máxima
        Vida = vidaInicial;        // Define vida atual
        Vivo = true;                // Jogador começa vivo
        StaminaMaxima = staminaInicial;  // Define stamina máxima
        Stamina = staminaInicial;        // Define stamina atual
        
        // Cria a lista de armas com uma arma inicial (Punhos)
        Armas = new List<Arma> { new Arma("Punhos", 5, 5) };
        ArmaAtual = Armas[0];      // Define arma atual
        
        Armaduras = new List<Armadura>();  // Lista de armaduras vazia
        Pocoes = 0;                 // Nenhuma poção no início
        EquippedWeapon = null;        // Nenhuma arma equipada
        EquippedArmor = null;        // Nenhuma armadura equipada
    }

    /// <summary>
    /// Regenera stamina do jogador.
    /// </summary>
    /// <param name="quantidade">Quantidade de stamina a recuperar</param>
    public void RegenerarStamina(int quantidade)
    {
        Stamina += quantidade;  // Adiciona stamina
        if (Stamina > StaminaMaxima)
        {
            // Limita ao valor máximo
            Stamina = StaminaMaxima;
        }
    }
    
}