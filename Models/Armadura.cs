using System;

public class Armadura : Item
{
    public int Defesa { get; set; }

    public Armadura(string nome, int defesa) : base(nome, 0)
    {
        Nome = nome;
        Defesa = defesa;
    }
}