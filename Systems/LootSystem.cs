using System;

/// <summary>
/// Sistema responsável por gerenciar loot e itens do jogo.
/// </summary>
public static class LootSystem
{
    /// <summary>
    /// jogador busca itens no mapa (30% de chance).
    /// Adiciona itens às listas de armas/armaduras.
    /// </summary>
    /// <param name="jogador">Jogador que vai receber o loot</param>
    /// <param name="rng">Gerador de números aleatórios</param>
    public static void Lootear(Jogador jogador, Random rng)
    {
        // 30% chance de encontrar algo
        if (rng.Next(1, 101) <= 30) 
        {
            // Escolhe um tipo aleatório: 1=Arma, 2=Armadura, 3=Poção
            int tipo = rng.Next(1, 4); 
            switch (tipo)
            {
                case 1: // Arma
                    Arma novaArma = GerarArmaAleatoria(rng);
                    jogador.Armas.Add(novaArma);
                    Console.WriteLine($"Você encontrou uma {novaArma.Nome} (+{novaArma.Dano} dano, custo {novaArma.StaminaCost} stamina)!");
                    break;
                case 2: // Armadura
                    Armadura novaArmadura = GerarArmaduraAleatoria(rng);
                    jogador.Armaduras.Add(novaArmadura);
                    Console.WriteLine($"Você encontrou uma {novaArmadura.Nome} (+{novaArmadura.Defesa} defesa)!");
                    break;
                case 3: // Poção
                    jogador.Pocoes++;
                    Console.WriteLine("Você encontró uma poção de cura!");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Nada encontrado nessa busca.");
        }
    }
    
    /// <summary>
    /// Gera um único item aleatório para o jogador (30% de chance).
    /// Usado para loot após matar inimigo.
    /// </summary>
    /// <param name="jogador">Jogador que vai receber o item</param>
    /// <param name="rng">Gerador de números aleatórios</param>
    public static void GerarItemUnico(Jogador jogador, Random rng)
    {
        // 30% chance de loot
        if (rng.Next(1, 101) <= 30) 
        {
            // Escolhe um tipo aleatório: 1=Arma, 2=Armadura, 3=Poção
            int tipo = rng.Next(1, 4); 
            switch (tipo)
            {
                case 1: // Arma - adiciona ao inventário
                    Arma novaArma = GerarArmaAleatoria(rng);
                    jogador.Inventory.Add(novaArma);
                    Console.WriteLine($"Você encontrou uma {novaArma.Nome} (+{novaArma.Dano} dano, custo {novaArma.StaminaCost} stamina)!");
                    break;
                case 2: // Armadura - adiciona ao inventário
                    Armadura novaArmadura = GerarArmaduraAleatoria(rng);
                    jogador.Inventory.Add(novaArmadura);
                    Console.WriteLine($"Você encontrou uma {novaArmadura.Nome} (+{novaArmadura.Defesa} defesa)!");
                    break;
                case 3: // Poção - incrementa contador
                    jogador.Pocoes++;
                    Console.WriteLine("Você encontrou uma poção de cura!");
                    break;
        }
        }
        else
        {
            Console.WriteLine("Nada encontrado nessa rodada.");
        }
    }

    /// <summary>
    /// Gera uma arma aleatória com nome e atributos randômicos.
    /// </summary>
    /// <param name="rng">Gerador de números aleatórios</param>
    /// <returns>Nova arma gerada</returns>
    private static Arma GerarArmaAleatoria(Random rng)
    {
        // Nomes possíveis de armas
        string[] nomes = { "Espada Melhorada", "Revolver Velho", "Granada Potente", "Sniper Básico" };
        
        // Dano entre 10 e 50
        int dano = rng.Next(10, 51);
        
        // Stamina entre 5 e 20
        int stamina = rng.Next(5, 21);
        
        return new Arma(nomes[rng.Next(nomes.Length)], dano, stamina);
    }

    /// <summary>
    /// Gera uma armadura aleatória com nome e defesa randômicos.
    /// </summary>
    /// <param name="rng">Gerador de números aleatórios</param>
    /// <returns>Nova armadura gerada</returns>
    private static Armadura GerarArmaduraAleatoria(Random rng)
    {
        // Nomes possíveis de armaduras
        string[] nomes = { "Armadura Leve", "Armadura Pesada", "Escudo" };
        
        // Defesa entre 5 e 20
        int defesa = rng.Next(5, 21);
        
        return new Armadura(nomes[rng.Next(nomes.Length)], defesa);
    }

    /// <summary>
    /// Usa uma poção para curar o jogador.
    /// </summary>
    /// <param name="jogador">Jogador que vai usar a poção</param>
    public static void UsarPocao(Jogador jogador)
    {
        // Verifica se o jogador tem poções
        if (jogador.Pocoes > 0)
        {
            jogador.Pocoes--;  // Remove uma poção
            
            // Cura entre 10 e 50 pontos
            Random random = new Random();
            int cura = random.Next(10, 51);
            
            // Adiciona a cura
            jogador.Vida += cura;
            
            // Limita ao máximo
            if (jogador.Vida > jogador.VidaMaxima) jogador.Vida = jogador.VidaMaxima;
            
            Console.WriteLine($"Você usou uma poção e recuperou {cura} de vida!");
        }
        else
        {
            Console.WriteLine("Você não tem poções!");
        }
    }
}