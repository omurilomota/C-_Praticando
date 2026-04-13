using System;

public class JogoDeHordas
{
    public static void Main(string[] args)
    {
        Jogador jogador = new Jogador();
        Inimigo inimigo = HordaSystem.GerarNovoInimigo();
        int rodadas = 0;
        Random rng = new Random();

        int recorde = BancoDeDados.CarregarRecorde();
        if (recorde > 0)
        {
            Console.WriteLine($"Recorde atual: {recorde} rodadas");
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n=== BATALHA SURVIVAL ===\n");
        Console.ResetColor();

        ArteASCII.DesenharPersonagem();
        Console.WriteLine("   VOCÊ");

        ArteASCII.DesenharInimigo();
        Console.WriteLine("   INIMIGO");

        Console.WriteLine("\nPressione ENTER para começar...");
        Console.ReadLine();

        while (jogador.Vivo)
        {
            rodadas++;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n=== RODADA {rodadas} ===\n");
            Console.ResetColor();

            // Regenerar stamina
            jogador.RegenerarStamina(5);

            // Display stats
            int barra = jogador.Vida * 20 / jogador.VidaMaxima;
            string vidaBarra = new string('█', barra) + new string('░', 20 - barra);
            Console.WriteLine($"Vida: {jogador.Vida}/{jogador.VidaMaxima} [{vidaBarra}]");

            int barraStamina = jogador.Stamina * 20 / jogador.StaminaMaxima;
            if (jogador.StaminaMaxima == 0) barraStamina = 0;
            string staminaBarra = new string('█', barraStamina) + new string('░', 20 - barraStamina);
            Console.WriteLine($"Stamina: {jogador.Stamina}/{jogador.StaminaMaxima} [{staminaBarra}]");

            int barraInim = inimigo.Vida * 20 / inimigo.VidaMaxima;
            string vidaBarraInim = new string('█', barraInim) + new string('░', 20 - barraInim);
            Console.WriteLine($"Vida do Inimigo: {inimigo.Vida}/{inimigo.VidaMaxima} [{vidaBarraInim}]\n");

            // Menu
            Console.WriteLine("Escolha sua ação:");
            Console.WriteLine("1. Atacar");
            Console.WriteLine("2. Fugir");
            Console.WriteLine("3. Lootear");
            Console.WriteLine("4. Descansar");
            Console.WriteLine("5. Usar Poção");
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1": // Atacar
                    CombatSystem.AtacarInimigo(jogador, inimigo);
                    if (!CombatSystem.VerificarMorteInimigo(inimigo.Vida))
                    {
                        LootSystem.GerarLoot(jogador, rng);
                        inimigo = HordaSystem.GerarNovoInimigo();
                    }
                    break;
                case "2": // Fugir
                    if (rng.Next(1, 101) <= 50)
                    {
                        Console.WriteLine("Você fugiu com sucesso!");
                        inimigo = HordaSystem.GerarNovoInimigo();
                    }
                    else
                    {
                        Console.WriteLine("Falhou em fugir!");
                    }
                    break;
                case "3": // Lootear
                    LootSystem.Lootear(jogador, rng);
                    break;
                case "4": // Descansar
                    jogador.RegenerarStamina(20);
                    Console.WriteLine("Você descansou e recuperou stamina.");
                    break;
                case "5": // Usar Poção
                    LootSystem.UsarPocao(jogador);
                    break;
            }

            // Turno do inimigo
            if (jogador.Vivo && inimigo.Vida > 0)
            {
                Arma armaInim = HordaSystem.EscolherArmaInimigo(rng);
                jogador.Vida = CombatSystem.AtacarComArma(armaInim, jogador.Vida);
                jogador.Vivo = CombatSystem.VerificarMorte(jogador.Vida);
            }

            if (!jogador.Vivo)
            {
                Console.WriteLine();
                ArteASCII.DesenharGameOver();
                Console.WriteLine($"\nVocê sobreviveu {rodadas} rodadas!");
                if (rodadas > recorde)
                {
                    BancoDeDados.SalvarRecorde(rodadas);
                    Console.WriteLine("Novo recorde!");
                }
                break;
            }

            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }

        Console.WriteLine("\nFim do jogo!");
    }
}