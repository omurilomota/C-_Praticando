using System;

public static class CombatSystem
{
    public static int AtacarComArma(Arma arma, int vidaAlvo)
    {
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
        Console.WriteLine($"Ataque com {arma.Nome}! -{arma.Dano} de vida");
        vidaAlvo -= arma.Dano;
        if (vidaAlvo < 0) vidaAlvo = 0;
        return vidaAlvo;
    }

    public static void AtacarInimigo(Jogador jogador, Inimigo inimigo)
    {
        int damage = 10;
        Arma armaUsada = jogador.EquippedWeapon ?? jogador.ArmaAtual;
        if (jogador.Stamina >= armaUsada.StaminaCost)
        {
            inimigo.Vida = AtacarComArma(armaUsada, inimigo.Vida);
            jogador.Stamina -= armaUsada.StaminaCost;
            Console.WriteLine($"Ataque com {armaUsada.Nome}! -{armaUsada.Dano} de vida");
        }
        else
        {
            Console.WriteLine("Stamina insuficiente para atacar!");
        }
        if(jogador.EquippedWeapon != null)
        {
            damage += jogador.EquippedWeapon.Dano;
        }
        inimigo.Vida -= damage;
        Console.WriteLine($"Você atacou e causou {damage} de dano!");
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
}