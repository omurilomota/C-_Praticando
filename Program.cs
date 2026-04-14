using System;
using System.Collections.Generic;
/**
@author: Murilo
@version: 1.0
*/

public class JogoDeHordas
{
    public static void Main(string[] args)
    {
        Jogador jogador = new Jogador();
        int rodadas = 0;
        Inimigo inimigo = HordaSystem.GerarNovoInimigo(rodadas);
        Random rng = new Random();
        bool primeiraRodada = true;

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

            int barraInim = inimigo.VidaMaxima == 0 ? 0 : inimigo.Vida * 20 / inimigo.VidaMaxima;
            string vidaBarraInim = new string('█', barraInim) + new string('░', 20 - barraInim);
            Console.WriteLine($"Inimigo: {inimigo.Nome} (Vida: {inimigo.Vida}/{inimigo.VidaMaxima}) [{vidaBarraInim}]\n");

            // Loot inicial
            if (primeiraRodada)
            {
                Console.WriteLine("===Loot Inicial===");
                Console.WriteLine("Você encontrou 3 itens antes da batalha!");
                for (int i = 0; i < 3; i++)
                {
                    LootSystem.GerarItemUnico(jogador, rng);
                }
                primeiraRodada = false;
                Console.WriteLine("\nPressione ENTER para continuar...");
                Console.ReadLine();
            }

            // Menu
            bool acaoEscolhida = false;
            while (!acaoEscolhida)
            {
                Console.WriteLine("\nEscolha sua ação:");
                Console.WriteLine("1. Atacar");
                Console.WriteLine("2. Fugir");
                Console.WriteLine("3. Lootear");
                Console.WriteLine("4. Descansar");
                Console.WriteLine("5. Usar Poção");
                Console.WriteLine("6. Equipar Item");
                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        CombatSystem.AtacarInimigo(jogador, inimigo);
                        if (!CombatSystem.VerificarMorteInimigo(inimigo.Vida))
                        {
                            LootSystem.GerarItemUnico(jogador, rng);
                            inimigo = HordaSystem.GerarNovoInimigo(rodadas);
                        }
                        acaoEscolhida = true;
                        break;
                    case "2":
                        if (rng.Next(1, 101) <= 50)
                        {
                            Console.WriteLine("Você fugiu com sucesso!");
                            inimigo = HordaSystem.GerarNovoInimigo(rodadas);
                        }
                        else
                        {
                            Console.WriteLine("Falhou em fugir!");
                        }
                        acaoEscolhida = true;
                        break;
                    case "3":
                        LootSystem.Lootear(jogador, rng);
                        acaoEscolhida = true;
                        break;
                    case "4":
                        jogador.RegenerarStamina(20);
                        Console.WriteLine("Você descansou e recuperou stamina.");
                        acaoEscolhida = true;
                        break;
                    case "5":
                        LootSystem.UsarPocao(jogador);
                        acaoEscolhida = true;
                        break;
                    case "6":
                        if (jogador.Inventory.Count == 0)
                        {
                            Console.WriteLine("Nenhum item disponível para equipar.");
                        }
                        else
                        {
                            Console.WriteLine("Escolha um item para equipar:");
                            for (int i = 0; i < jogador.Inventory.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {jogador.Inventory[i].Nome}");
                            }
                            Console.WriteLine("Escolha o número do item:");
                            if (int.TryParse(Console.ReadLine(), out int itemChoice) && itemChoice > 0 && itemChoice <= jogador.Inventory.Count)
                            {
                                jogador.EquiparItem(jogador.Inventory[itemChoice - 1]);
                            }
                            else
                            {
                                Console.WriteLine("Opção inválida!");
                            }
                        }
                        acaoEscolhida = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }

            // Turno do inimigo
            if (jogador.Vivo && inimigo.Vida > 0)
            {
                CombatSystem.AtacarJogador(jogador, inimigo);
                jogador.Vivo = CombatSystem.VerificarMorte(jogador.Vida);
                jogador.UpdatePowerUps();
                inimigo.UpdatePowerUps();
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