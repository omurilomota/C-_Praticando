/// <summary>
/// Classe que representa um power-up temporário.
/// </summary>
public class PowerUp
{
    public string Name { get; set; }      // Nome do power-up
    public int Duration { get; set; }    // Duração em rodadas
    public Action<Jogador?, Inimigo?> Effect { get; set; }  // Efeito do power-up
}