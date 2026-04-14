using System;

/// <summary>
/// Classe que representa um inimigo no jogo.
/// Armazena atributos como nome, vida, defesa e arma.
/// </summary>
public class Inimigo
{
    public String Nome { get; set; }        // Nome do inimigo (ex: Zumbi, Goblin)
    public int Defesa { get; set; }          // Pontos de defesa do inimigo
    public Arma ArmaPadrao { get; set; }   // Arma que o inimigo usa
    
    public int Vida { get; set; }          // Vida atual do inimigo
    public int VidaMaxima { get; set; }    // Vida máxima do inimigo
    
    // Power-ups ativos do inimigo
    public List<PowerUp> ActivePowerUps { get; set; } = new List<PowerUp>();                                                                                                                                                                 
                                                                                                                                                                                                                                               
    /// <summary>
    /// Atualiza todos os power-ups activos (decrementa duração).
    /// </summary>                                                                                                                                                                                                            
    public void UpdatePowerUps()                                                                                                                                                                                                             
    {                                                                                                                                                                                                                                        
        // Itera sobre uma cópia da lista para permitir remoção
        foreach (var p in ActivePowerUps.ToList())                                                                                                                                                                                           
        {                                                                                                                                                                                                                                    
            p.Duration--;                                                                                                                                                                                                                   
            if (p.Duration <= 0) 
            {
                // Remove o power-up se a duração acabou
                ActivePowerUps.Remove(p);                                                                                                                                                                                   
            }
            else 
            {
                // Caso contrário, aplica o efeito do power-up
                p.Effect(null, this);  // Efeito específico para inimigo                                                                                                                                                       
            }                                                                                                                                                                                                                                    
        }                                                                                                                                                                                                                                     
    } 

    /// <summary>
    /// Construtor padrão do inimigo (valores fallback).
    /// </summary>
    /// <param name="vidaInicial">Vida inicial (padrão: 100)</param>
    public Inimigo(int vidaInicial = 100)
    {
        VidaMaxima = vidaInicial;    // Define vida máxima
        Vida = vidaInicial;        // Define vida atual
        Nome = "Inimigo Genérico"; // Nome padrão (fallback)
        Defesa = 0;                // Sem defesa por padrão
        ArmaPadrao = new Arma("Garras", 10, 0);  // Arma padrão
    }

    /// <summary>
    /// Construtor completo do inimigo com todos os atributos.
    /// </summary>
    /// <param name="nome">Nome do inimigo</param>
    /// <param name="vida">Vida do inimigo</param>
    /// <param name="defesa">Defesa do inimigo</param>
    /// <param name="arma">Arma que o inimigo usa</param>
    public Inimigo(string nome, int vida, int defesa, Arma arma)
    {
        Nome = nome;          // Define o nome
        Vida = vida;         // Define a vida atual
        VidaMaxima = vida;  // Define a vida máxima
        Defesa = defesa;    // Define a defesa
        ArmaPadrao = arma;  // Define a arma
    }
}