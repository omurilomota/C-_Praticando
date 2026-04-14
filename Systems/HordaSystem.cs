using System;
using System.Collections.Generic;

/// <summary>
/// Sistema responsável por gerar e gerenciar os inimigos do jogo.
/// </summary>
public static class HordaSystem
{
    // Lista de tipos de inimigos disponíveis no jogo
    public static List<EnemyType> TiposInimigos = new List<EnemyType>
    {
        // Zumbi: vida/base 100, defesa 10, arma Garras
        new EnemyType("Zumbi", 100, 10, new Arma("Garras", 10, 5)),
        
        // Goblin: vida 80, defesa 15, arma Faca Enferrujada
        new EnemyType("Goblin", 80, 15, new Arma("Faca Enferrujada", 15, 10)),
        
        // Orc: vida 120, defesa 20, arma Clava
        new EnemyType("Orc", 120, 20, new Arma("Clava", 50, 20)),
        
        // Dragão Pequeno: vida 150, defesa 25, arma Sopro de fogo
        new EnemyType("Dragão Pequeno", 150, 25, new Arma("Sopro de fogo", 80, 30))
    };
    

    /// <summary>
    /// Escolhe uma arma aleatória para o inimigo (atualmente não usado).
    /// </summary>
    /// <param name="rng">Gerador de números aleatórios</param>
    /// <returns>Arma escolhida</returns>
    public static Arma EscolherArmaInimigo(Random rng)
    {
        return new Arma("Garras", 10, 0);
    }

    /// <summary>
    /// Gera um novo inimigo aleatório baseado na rodada atual.
    /// A dificuldade aumenta a cada rodada.
    /// </summary>
    /// <param name="rodadaAtual">Número da rodada atual</param>
    /// <returns>Novo inimigo criado</returns>
    public static Inimigo GerarNovoInimigo(int rodadaAtual = 1)
    {
        Random rng = new Random();
        
        // Escolhe um tipo de inimigo aleatório da lista
        EnemyType tipoEscolhido = TiposInimigos[rng.Next(TiposInimigos.Count)];
        
        // Aumenta a vida do inimigo (+10 por rodada)
        int vidaAjustada = tipoEscolhido.VidaBase + (rodadaAtual * 10);
        
        // Aumenta a defesa do inimigo (+1 a cada 5 rodadas)
        int defesaAjustada = tipoEscolhido.DefesaBase + (rodadaAtual / 5);
        
        // Cria e retorna o novo inimigo
        return new Inimigo(tipoEscolhido.Nome, vidaAjustada, defesaAjustada, tipoEscolhido.ArmaPadrao);
    }
}

/// <summary>
/// Classe que representa um tipo de inimigo (molde).
/// </summary>
public class EnemyType
{
    public String Nome { get; set; }        // Nome do tipo
    public int VidaBase { get; set; }    // Vida base
    public int DefesaBase { get; set; } // Defesa base
    public Arma ArmaPadrao { get; set; } // Arma padrão

    /// <summary>
    /// Construtor do tipo de inimigo.
    /// </summary>
    /// <param name="nome">Nome do tipo</param>
    /// <param name="vida">Vida base</param>
    /// <param name="defesa">Defesa base</param>
    /// <param name="arma">Arma padrão</param>
    public EnemyType(string nome, int vida, int defesa, Arma arma)
    {
        Nome = nome;
        VidaBase = vida;
        DefesaBase = defesa;
        ArmaPadrao = arma;
    }
}