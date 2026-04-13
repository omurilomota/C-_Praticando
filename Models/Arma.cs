using System;

public class Arma
{
    public string Nome { get; set; }

    public int Dano { get; set; }

    public int StaminaCost { get; set; }

    public Arma(string nome, int dano, int staminaCost)
    {
        Nome = nome;
        Dano = dano;
        StaminaCost = staminaCost;
    }
}