using System;

public class Inimigo
{
    public String Nome { get; set; }
    public int Defesa { get; set; }
    public Arma ArmaPadrao { get; set; } // um espaço (uma variável) que pode GUARDAR objetos do tipo Arma, e chamaremos esse espaço de ArmaPadrao.
    public int Vida { get; set; }
    public int VidaMaxima { get; set; }
    public List<PowerUp> ActivePowerUps { get; set; } = new List<PowerUp>();                                                                                                                                                                 
                                                                                                                                                                                                                                              
     public void UpdatePowerUps()                                                                                                                                                                                                             
     {                                                                                                                                                                                                                                        
         foreach (var p in ActivePowerUps.ToList())                                                                                                                                                                                           
         {                                                                                                                                                                                                                                    
             p.Duration--;                                                                                                                                                                                                                    
             if (p.Duration <= 0) ActivePowerUps.Remove(p);                                                                                                                                                                                   
             else p.Effect(null, this);  // Adjust for enemy-specific effects if needed                                                                                                                                                       
         }                                                                                                                                                                                                                                    
     } 

    public Inimigo(int vidaInicial = 100)
    {
        VidaMaxima = vidaInicial;
        Vida = vidaInicial;
        Nome = "Inimigo Genérico"; // Fallback ( quando nada é colocado, isso aparece )
        Defesa = 0;
        ArmaPadrao = new Arma("Garras", 10, 0);
    }

    public Inimigo(string nome, int vida, int defesa, Arma arma)
    {
        Nome = nome;
        Vida = vida;
        VidaMaxima = vida;
        Defesa = defesa;
        ArmaPadrao = arma;
    }
}