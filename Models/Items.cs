using System;

public class Item
{
    public String Nome { get; set; }
    public int Value { get; set; }

    // Com esse construtor, quando eu criar um item, ele já espera por nome e valor, ou seja, economiza linhas de código.
    public Item(string nome, int value)
    {
        Nome = nome;
        this.Value = Value;
    }
}