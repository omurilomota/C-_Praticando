public class PowerUp
{
    public string Name { get; set;}
    public int Duration { get; set;}
    public Action<Jogador?, Inimigo?> Effect { get; set;}
}