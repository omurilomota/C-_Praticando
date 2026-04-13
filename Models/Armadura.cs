using System;

public class Armadura
{
    public string Nome { get; set; }
    public int Defesa { get; set; }

    public Armadura(string nome, int defesa)
    {
        Nome = nome;
        Defesa = defesa;
    }
}