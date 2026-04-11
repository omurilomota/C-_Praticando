using System;

public class HelloWorld
{
    public static void Main(string[] args)  // Mudado de Program para Main
    {
        int vida_Per = 100;
		bool vivo = true;
        
        Console.WriteLine("Sistema gerenciamento de dano \n");

		while (vivo) 
		{
		Console.WriteLine($"\n--- Vida atual: {vida_Per} ---");
        Console.WriteLine("Você recebeu dano de qual arma? \n");
        Console.WriteLine("1 - Espada, 2 - Revólver, 3 - Granada, 4 - Sniper");
		Console.WriteLine("0 - Sair do jogo");
        
        if (int.TryParse(Console.ReadLine(), out int option))
        {
			if(option == 0)
			{
				Console.WriteLine("Você fugiu do jogo! Covarde!");
				break;
			}
            vida_Per = CalcularDano(option, vida_Per);
            vivo = VerificarMorte(vida_Per);
        
			if (!vivo)
			{
				Console.WriteLine("Game Over!");
			}
		}
        else
        {
            Console.WriteLine("Entrada inválida! Digite um número.");
        }
    }
	Console.WriteLine("Fim do jogo!");
	}
    public static int CalcularDano(int option, int vida_Per)  // Adicionado int como retorno
    {
        switch (option)    
        {
            case 1:
                Console.WriteLine("Você foi atingido por uma ESPADA! -10 de vida");
                return vida_Per - 10;
            case 2:
                Console.WriteLine("Você foi atingido por um REVÓLVER! -15 de vida");
                return vida_Per - 15;
            case 3:
                Console.WriteLine("Você foi atingido por uma GRANADA! -50 de vida");
                return vida_Per - 50;
            case 4:
                Console.WriteLine("Você foi atingido por um SNIPER! -80 de vida");
                return vida_Per - 80;
            default:
                Console.WriteLine("Opção inválida/desconhecida. Nenhum dano causado.");
                return vida_Per;
        }
    }
    
    public static bool VerificarMorte(int vida_Per)
    {
        switch(vida_Per)
        {
            case <= 0:
            Console.WriteLine("\n*** Você morreu ***");
            return false;
            
            case > 0:
            return true;
        }

    }
}