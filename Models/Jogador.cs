using System;
using System.Collections.Generic;

public class Jogador
{
    public int Stamina { get; set; }
    public int StaminaMaxima { get; set; }
    public Arma ArmaAtual { get; set; }
    public List<Arma> Armas { get; set; }
    public List<Armadura> Armaduras { get; set; }
    public int Vida { get; set; }
    public int VidaMaxima { get; set; }
    public int Pocoes { get; set; }
    public bool Vivo { get; set; }

    public Jogador(int vidaInicial = 100, int staminaInicial = 100)
    {
        VidaMaxima = vidaInicial;
        Vida = vidaInicial;
        Vivo = true;
        StaminaMaxima = staminaInicial;
        Stamina = staminaInicial;
        Armas = new List<Arma> { new Arma("Punhos", 5, 5) };
        ArmaAtual = Armas[0];
        Armaduras = new List<Armadura>();
        Pocoes = 0;
    }

    public void RegenerarStamina(int quantidade)
    {
        Stamina += quantidade;
        if (Stamina > StaminaMaxima)
        {
            Stamina = StaminaMaxima;
        }
    }
}