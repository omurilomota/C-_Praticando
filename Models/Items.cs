using System;

public class Item
{
    public string Nome { get; set; }
    public int Value { get; set; }

    public Item(string nome)
    {
        Nome = nome;
        Value = 0;
    }

    public Item(string nome, int value)
    {
        Nome = nome;
        Value = value;
    }
}

public class Arma : Item
{
    public int Dano { get; set; }
    public int CustoStamina { get; set; }

    public Arma(string nome, int dano, int custoStamina) : base(nome)
    {
        Dano = dano;
        CustoStamina = custoStamina;
    }
}

public class Armadura : Item
{
    public int Defesa { get; set; }
    public int BonusVida { get; set; }
    public int BonusStamina { get; set; }

    public Armadura(string nome, int defesa, int bonusVida, int bonusStamina) : base(nome)
    {
        Defesa = defesa;
        BonusVida = bonusVida;
        BonusStamina = bonusStamina;
    }
}