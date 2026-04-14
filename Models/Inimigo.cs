using System;

public class Inimigo
{
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
    }
}