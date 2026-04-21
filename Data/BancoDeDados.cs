using System;
using System.IO;

public static class BancoDeDados
{
    // Nome do arquivo onde o recorde é salvo
    private static string filePath = "highscore.txt";

    public static void SalvarRecorde(int rodadas)
    {
        try
        {
            // Escreve o valor em formato de texto
            File.WriteAllText(filePath, rodadas.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao salvar recorde: {e.Message}");
        }
    }

    public static int CarregarRecorde()
    {
        try
        {
            // Verifica se o arquivo existe
            if (File.Exists(filePath))
            {
                // Lê o conteúdo e converte para inteiro
                string content = File.ReadAllText(filePath);
                return int.Parse(content);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro ao carregar recorde: {e.Message}");
        }
        return 0;
    }
}