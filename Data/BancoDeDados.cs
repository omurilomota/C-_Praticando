using System;
using System.IO;

public static class BancoDeDados
{
    private static string filePath = "highscore.txt";

    public static void SalvarRecorde(int rodadas)
    {
        try
        {
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
            if (File.Exists(filePath))
            {
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