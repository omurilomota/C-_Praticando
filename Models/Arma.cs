using System;

public class Arma : Item
{

    public int Dano { get; set; }

    public int StaminaCost { get; set; }

    public Arma(string nome, int dano, int staminaCost) : base(nome, 0)
    {
        Dano = dano;
        StaminaCost = staminaCost;
    }
}