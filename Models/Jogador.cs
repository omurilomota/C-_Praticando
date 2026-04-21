using System;
using System.Collections.Generic;
using System.Linq;

public class Jogador
{
    // Atributos base
    public int Vida { get; set; }
    
    public int VidaMaxima { get; set; }
    public int Stamina { get; set; }
    public int StaminaMaxima { get; set; }
    public int DanoBase { get; private set; }      // Dano sem armas
    public int DanoTotal => DanoBase + (ArmaEquipada?.Dano ?? 0);
    public int Pocoes { get; set; }
    public bool Vivo { get; set; }

    // Equipamentos atuais
    public Arma ArmaEquipada { get; private set; }
    public Armadura ArmaduraEquipada { get; private set; }

    // Inventários
    public List<Arma> Armas { get; private set; }
    public List<Armadura> Armaduras { get; private set; }
    public List<Item> Inventory { get; private set; }

    // Power-ups ativos
    public List<PowerUp> ActivePowerUps { get; private set; }

    public Jogador(int vidaInicial = 100, int staminaInicial = 100)
    {
        Vida = vidaInicial;
        VidaMaxima = vidaInicial;
        Stamina = staminaInicial;
        StaminaMaxima = staminaInicial;
        DanoBase = 10;
        Pocoes = 3;
        Vivo = true;

        ArmaEquipada = null;
        ArmaduraEquipada = null;

        Armas = new List<Arma> { new Arma("Punhos", 5, 0) }; // arma padrão
        Armaduras = new List<Armadura>();
        Inventory = new List<Item>();
        ActivePowerUps = new List<PowerUp>();
    }

    public void EquiparArma(Arma novaArma)
    {
        if (ArmaEquipada != null)
        {
            DanoBase -= ArmaEquipada.Dano;
        }

        ArmaEquipada = novaArma;
        DanoBase += novaArma.Dano;
        Console.WriteLine($"Arma equipada: {novaArma.Nome} (+{novaArma.Dano} de dano)");
    }

    public void EquiparArmadura(Armadura novaArmadura)
    {
        if (ArmaduraEquipada != null)
        {
            // Remove bônus da armadura antiga
            VidaMaxima -= ArmaduraEquipada.BonusVida;
            StaminaMaxima -= ArmaduraEquipada.BonusStamina;
            if (Vida > VidaMaxima) Vida = VidaMaxima;
            if (Stamina > StaminaMaxima) Stamina = StaminaMaxima;
        }

        ArmaduraEquipada = novaArmadura;
        VidaMaxima += novaArmadura.BonusVida;
        StaminaMaxima += novaArmadura.BonusStamina;
        Vida += novaArmadura.BonusVida;
        Stamina += novaArmadura.BonusStamina;

        Console.WriteLine($"Armadura equipada: {novaArmadura.Nome} (+{novaArmadura.BonusVida} vida, +{novaArmadura.BonusStamina} stamina)");
    }

    public void EquiparItem(Item item)
    {
        if (item is Arma arma)
        {
            EquiparArma(arma);
            Armas.Add(arma);
        }
        else if (item is Armadura armadura)
        {
            EquiparArmadura(armadura);
            Armaduras.Add(armadura);
        }
        else
        {
            Console.WriteLine("Item não pode ser equipado.");
            return;
        }

        Inventory.Remove(item);
    }

    public void MostrarStatus()
    {
        Console.WriteLine("\n=== STATUS DO JOGADOR ===");
        Console.WriteLine($"❤️ Vida: {Vida}/{VidaMaxima}");
        Console.WriteLine($"⚡ Stamina: {Stamina}/{StaminaMaxima}");
        Console.WriteLine($"⚔️ Dano: {DanoTotal}");
        Console.WriteLine($"🧪 Poções: {Pocoes}");
        Console.WriteLine($"🗡️ Arma: {(ArmaEquipada?.Nome ?? "Nenhuma")}");
        Console.WriteLine($"🛡️ Armadura: {(ArmaduraEquipada?.Nome ?? "Nenhuma")}");
        Console.WriteLine("==========================\n");
    }

    public void RegenerarStamina(int quantidade)
    {
        Stamina = Math.Min(Stamina + quantidade, StaminaMaxima);
        Console.WriteLine($"Você recuperou {quantidade} de stamina. Stamina atual: {Stamina}/{StaminaMaxima}");
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
            if (p.Duration <= 0)
                ActivePowerUps.Remove(p);
            else
                p.Effect(this, null);
        }
    }
}