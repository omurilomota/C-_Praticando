using System;

public class Inimigo
{
    public String Nome { get; set; }        // Nome do inimigo (ex: Zumbi, Goblin)
    public int Defesa { get; set; }          // Pontos de defesa do inimigo
    public Arma ArmaPadrao { get; set; }   // Arma que o inimigo usa
    
    public int Vida { get; set; }          // Vida atual do inimigo
    public int VidaMaxima { get; set; }    // Vida máxima do inimigo
    
    // Power-ups ativos do inimigo
    public List<PowerUp> ActivePowerUps { get; set; } = new List<PowerUp>();                                                                                                                                                                 
                                                                                                                                                                                                                                               
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

    public Inimigo(int vidaInicial = 100)
    {
        VidaMaxima = vidaInicial;    // Define vida máxima
        Vida = vidaInicial;        // Define vida atual
        Nome = "Inimigo Genérico"; // Nome padrão (fallback)
        Defesa = 0;                // Sem defesa por padrão
        ArmaPadrao = new Arma("Garras", 10, 0);  // Arma padrão
    }

    public Inimigo(string nome, int vida, int defesa, Arma arma)
    {
        Nome = nome;          // Define o nome
        Vida = vida;         // Define a vida atual
        VidaMaxima = vida;  // Define a vida máxima
        Defesa = defesa;    // Define a defesa
        ArmaPadrao = arma;  // Define a arma
    }
}