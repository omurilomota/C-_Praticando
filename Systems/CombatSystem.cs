using System;

/// <summary>
/// Sistema responsável por todas as lógicas de combate.no jogo.
/// </summary>
public static class CombatSystem
{
    /// <summary>
    /// Executa um ataque com uma arma específica.alvo.
    /// </summary>
    /// <param name="arma">Arma usada no ataque</param>
    /// <param name="vidaAlvo">Vida atual do alvo</param>
    /// <returns>Vida restantes do alvo após o ataque</returns>
    public static int AtacarComArma(Arma arma, int vidaAlvo)
    {
        // Desenha a arte ASCII conforme o tipo de arma
        switch (arma.Nome)
        {
            case "Espada":
                ArteASCII.DesenharEspada();
                break;
            case "Revolver":
                ArteASCII.DesenharRevolver();
                break;
            case "Granada":
                ArteASCII.DesenharGranada();
                break;
            case "Sniper":
                ArteASCII.DesenharSniper();
                break;
            default:
                Console.WriteLine($"Ataque com {arma.Nome}");
                break;
        }
        
        // Calcula o dano causado
        Console.WriteLine($"Ataque com {arma.Nome}! -{arma.Dano} de vida");
        vidaAlvo -= arma.Dano;
        
        // Garante que a vida não fique negativa
        if (vidaAlvo < 0) vidaAlvo = 0;
        
        return vidaAlvo;
    }

    /// <summary>
    /// Jogador ataca o inimigo.
    /// </summary>
    /// <param name="jogador">Jogador que está atacando</param>
    /// <param name="inimigo">Inimigo que recebe o ataque</param>
    public static void AtacarInimigo(Jogador jogador, Inimigo inimigo)
    {
        // Dano base do ataque
        int damage = 10;
        
        // Usa a arma equipada, ou a arma atual se nenhuma estiver equipada
        Arma armaUsada = jogador.EquippedWeapon ?? jogador.ArmaAtual;
        
        // Verifica se o jogador tem stamina suficiente
        if (jogador.Stamina >= armaUsada.StaminaCost)
        {
            // Executa o ataque
            inimigo.Vida = AtacarComArma(armaUsada, inimigo.Vida);
            jogador.Stamina -= armaUsada.StaminaCost;
            Console.WriteLine($"Ataque com {armaUsada.Nome}! -{armaUsada.Dano} de vida");
        }
        else
        {
            Console.WriteLine("Stamina insuficiente para atacar!");
        }
        
        // Adiciona dano extra se tiver arma equipada
        if(jogador.EquippedWeapon != null)
        {
            damage += jogador.EquippedWeapon.Dano;
        }
        
        // Aplica o dano adicional
        inimigo.Vida -= damage;
        Console.WriteLine($"Você atacou e causou {damage} de dano!");
        
        // Segundo ataque com arma atual (se tiver stamina)
        if (jogador.Stamina >= jogador.ArmaAtual.StaminaCost)
        {
            inimigo.Vida = AtacarComArma(jogador.ArmaAtual, inimigo.Vida);
            jogador.Stamina -= jogador.ArmaAtual.StaminaCost;
        }
        else
        {
            Console.WriteLine("Stamina insuficiente para atacar!");
        }
    }

    /// <summary>
    /// Verifica se o jogador morreu.
    /// </summary>
    /// <param name="vida">Vida atual do jogador</param>
    /// <returns>True se o jogador ainda estiver vivo, False se morreu</returns>
    public static bool VerificarMorte(int vida)
    {
        if (vida <= 0)
        {
            Console.WriteLine("\n*** Você morreu ***");
            return false;
        }
        return true;
    }

    /// <summary>
    /// Verifica se o inimigo morreu.
    /// </summary>
    /// <param name="vida">Vida atual do inimigo</param>
    /// <returns>True se o inimigo ainda estiver vivo, False se morreu</returns>
    public static bool VerificarMorteInimigo(int vida)
    {
        if (vida <= 0)
        {
            Console.WriteLine("Inimigo derrotado!");
            return false;
        }
        return true;
    }

    /// <summary>
    /// Inimigo ataca o jogador.
    /// </summary>
    /// <param name="jogador">Jogador que recebe o ataque</param>
    /// <param name="inimigo">Inimigo que está atacando</param>
    public static void AtacarJogador(Jogador jogador, Inimigo inimigo)
    {
        // Obtém a arma do inimigo
        Arma armaInim = inimigo.ArmaPadrao;
        
        // Dano base da arma
        int danoBase = armaInim.Dano;
        
        // Calcula o dano final subtraindo a defesa do jogador
        int danoFinal = CalcularDanoComDefesa(danoBase, jogador.EquippedArmor?.Defesa ?? 0);
        
        // Aplica o dano ao jogador
        jogador.Vida -= danoFinal;
        Console.WriteLine($"{inimigo.Nome} atacou e causou {danoFinal} de dano! Você perdeu {danoFinal} de vida.");
    }

    /// <summary>
    /// Calcula o dano considerando a defesa do alvo.
    /// </summary>
    /// <param name="danoBase">Dano base do ataque</param>
    /// <param name="defesa">Defesa do alvo</param>
    /// <returns>Dano final após aplicar a defesa</returns>
    private static int CalcularDanoComDefesa(int danoBase, int defesa)
    {
        // Subtrai a defesa do dano base
        int danoFinal = danoBase - defesa;
        
        // Garante que o dano mínimo seja 0
        return Math.Max(danoFinal, 0);
    }
}