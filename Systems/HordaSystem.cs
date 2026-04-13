using System;
using System.Collections.Generic;

public static class HordaSystem
{
    public static List<Arma> ArmasDisponiveis = new List<Arma>
    {
        new Arma("Espada", 10, 5),
        new Arma("Revolver", 15, 10),
        new Arma("Granada", 50, 20),
        new Arma("Sniper", 80, 30)
    };

    public static Arma EscolherArmaInimigo(Random rng)
    {
        return ArmasDisponiveis[rng.Next(ArmasDisponiveis.Count)];
    }

    public static Inimigo GerarNovoInimigo()
    {
        return new Inimigo();
    }
}