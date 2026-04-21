using System;

public static class CombatSystem
{
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

    public static void AtacarInimigo(Jogador jogador, Inimigo inimigo)
    {
        if (jogador.ArmaEquipada == null)
        {
            Console.WriteLine("Você não tem arma equipada!");
            return;
        }

        Arma arma = jogador.ArmaEquipada;

        if (jogador.Stamina < arma.CustoStamina)
        {
            Console.WriteLine("Stamina insuficiente para atacar!");
            return;
        }

        inimigo.Vida = AtacarComArma(arma, inimigo.Vida);
        jogador.Stamina -= arma.CustoStamina;
    }

    public static bool VerificarMorte(int vida)
    {
        if (vida <= 0)
        {
            Console.WriteLine("\n*** Você morreu ***");
            return false;
        }
        return true;
    }

    public static bool VerificarMorteInimigo(int vida)
    {
        if (vida <= 0)
        {
            Console.WriteLine("Inimigo derrotado!");
            return false;
        }
        return true;
    }

    public static void AtacarJogador(Jogador jogador, Inimigo inimigo)
    {
        Arma armaInim = inimigo.ArmaPadrao;
        int danoBase = armaInim.Dano;
        int defesaJogador = jogador.ArmaduraEquipada?.Defesa ?? 0;
        int danoFinal = CalcularDanoComDefesa(danoBase, defesaJogador);
        jogador.Vida -= danoFinal;
        Console.WriteLine($"{inimigo.Nome} atacou e causou {danoFinal} de dano! Você perdeu {danoFinal} de vida.");
    }

    private static int CalcularDanoComDefesa(int danoBase, int defesa)
    {
        // Subtrai a defesa do dano base
        int danoFinal = danoBase - defesa;
        
        // Garante que o dano mínimo seja 0
        return Math.Max(danoFinal, 0);
    }
}