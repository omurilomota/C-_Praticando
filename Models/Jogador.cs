using System;
using System.Collections.Generic;

public class Jogador
{
    public int Stamina { get; set; }
    public int StaminaMaxima { get; set; }
    public Arma ArmaAtual { get; set; }
    public List<Arma> Armas { get; set; }
    public List<Armadura> Armaduras { get; set; }
    public int Vida { get; set; }
    public int VidaMaxima { get; set; }
    public int Pocoes { get; set; }
    public bool Vivo { get; set; }
    public List<PowerUp> ActivePowerUps { get; set; } = new List<PowerUp>();
    public List<Item> Inventory {get; set;} = new List<Item>();
    public Arma? EquippedWeapon { get; set; }
    public Armadura? EquippedArmor { get; set; }

    public void EquiparItem(Item item)
    {
        if (item is Arma arma)
        {
            EquippedWeapon = arma;
            ArmaAtual = arma;
        }
        else if (item is Armadura armadura)
        {
            EquippedArmor = armadura;
        }
        Console.WriteLine($"Item: {item.Nome} equipado com sucesso!");
    }

    public void ApplyPowerUp(PowerUp p)
    {
        ActivePowerUps.Add(p);
        p.Effect(this, null);
    }

    public void UpdatePowerUps()
    {
        foreach (var p in ActivePowerUps.ToList())
        {
            p.Duration--;
            if (p.Duration <= 0) ActivePowerUps.Remove(p);
            else p.Effect(this,null);
        }
    }

    public Jogador(int vidaInicial = 100, int staminaInicial = 100)
    {
        VidaMaxima = vidaInicial;
        Vida = vidaInicial;
        Vivo = true;
        StaminaMaxima = staminaInicial;
        Stamina = staminaInicial;
        Armas = new List<Arma> { new Arma("Punhos", 5, 5) };
        ArmaAtual = Armas[0];
        Armaduras = new List<Armadura>();
        Pocoes = 0;
        EquippedWeapon = null;
        EquippedArmor = null;
    }

    public void RegenerarStamina(int quantidade)
    {
        Stamina += quantidade;
        if (Stamina > StaminaMaxima)
        {
            Stamina = StaminaMaxima;
        }
    }

    
}