using System;

public class Inimigo
{
    public int Vida { get; set; }
    public int VidaMaxima { get; set; }

    public Inimigo(int vidaInicial = 100)
    {
        VidaMaxima = vidaInicial;
        Vida = vidaInicial;
    }
}