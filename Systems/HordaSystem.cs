using System;
using System.Collections.Generic;

public static class HordaSystem
{
    public static List<EnemyType> TiposInimigos = new List<EnemyType>
    {
        new EnemyType("Zumbi", 100, 10, new Arma("Garras", 10, 5)),
        new EnemyType("Goblin", 80, 15, new Arma("Faca Enferrujada", 15, 10)),
        new EnemyType("Orc", 120, 20, new Arma("Clava", 50, 20)),
        new EnemyType("Dragão Pequeno", 150, 25, new Arma("Sopro de fogo", 80, 30))
    };

    public static Inimigo GerarNovoInimigo(int rodadaAtual = 1)
    {
        Random rng = new Random();
        EnemyType tipoEscolhido = TiposInimigos[rng.Next(TiposInimigos.Count)];
        int vidaAjustada = tipoEscolhido.VidaBase + (rodadaAtual * 10);
        int defesaAjustada = tipoEscolhido.DefesaBase + (rodadaAtual / 5);
        return new Inimigo(tipoEscolhido.Nome, vidaAjustada, defesaAjustada, tipoEscolhido.ArmaPadrao);
    }
}

public class EnemyType
{
    public string Nome { get; set; }
    public int VidaBase { get; set; }
    public int DefesaBase { get; set; }
    public Arma ArmaPadrao { get; set; }

    public EnemyType(string nome, int vida, int defesa, Arma arma)
    {
        Nome = nome;
        VidaBase = vida;
        DefesaBase = defesa;
        ArmaPadrao = arma;
    }
}
