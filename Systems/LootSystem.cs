using System;

public static class LootSystem
{
    public static void Lootear(Jogador jogador, Random rng)
    {
        if (rng.Next(1, 101) <= 30) // 30% chance de loot
        {
            int tipo = rng.Next(1, 4); // 1: Arma, 2: Armadura, 3: Poção
            switch (tipo)
            {
                case 1:
                    Arma novaArma = GerarArmaAleatoria(rng);
                    jogador.Armas.Add(novaArma);
                    Console.WriteLine($"Você encontrou uma {novaArma.Nome} (+{novaArma.Dano} dano, custo {novaArma.StaminaCost} stamina)!");
                    break;
                case 2:
                    Armadura novaArmadura = GerarArmaduraAleatoria(rng);
                    jogador.Armaduras.Add(novaArmadura);
                    Console.WriteLine($"Você encontrou uma {novaArmadura.Nome} (+{novaArmadura.Defesa} defesa)!");
                    break;
                case 3:
                    jogador.Pocoes++;
                    Console.WriteLine("Você encontrou uma poção de cura!");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Nada encontrado nessa busca.");
        }
    }
    // Corrigir lógica de loot
    public static void GerarLoot(Jogador jogador, Random rng)
    {
        Lootear(jogador, rng);
        Item loot =  jogador.Armas[rng.Next(jogador.Armas.Count)];
        jogador.Inventory.Add(loot);
        Console.WriteLine($"Você recebeu: {loot.Nome}");
    }

    private static Arma GerarArmaAleatoria(Random rng)
    {
        string[] nomes = { "Espada Melhorada", "Revolver Velho", "Granada Potente", "Sniper Básico" };
        int dano = rng.Next(10, 51);
        int stamina = rng.Next(5, 21);
        return new Arma(nomes[rng.Next(nomes.Length)], dano, stamina);
    }

    private static Armadura GerarArmaduraAleatoria(Random rng)
    {
        string[] nomes = { "Armadura Leve", "Armadura Pesada", "Escudo" };
        int defesa = rng.Next(5, 21);
        return new Armadura(nomes[rng.Next(nomes.Length)], defesa);
    }

    public static void UsarPocao(Jogador jogador)
    {
        if (jogador.Pocoes > 0)
        {
            jogador.Pocoes--;
            Random random = new Random();
            int cura = random.Next(10, 51);
            jogador.Vida += cura;
            if (jogador.Vida > jogador.VidaMaxima) jogador.Vida = jogador.VidaMaxima;
            Console.WriteLine($"Você usou uma poção e recuperou {cura} de vida!");
        }
        else
        {
            Console.WriteLine("Você não tem poções!");
        }
    }
}