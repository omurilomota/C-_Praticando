# Batalha Survival

Um jogo de sobrevivência em texto feito em C# (.NET 8).

## Como Jogar

1. Compile e execute o projeto:
   ```bash
   dotnet run
   ```

2. Use o menu para escolher ações:
   - **1. Atacar** - Ataca o inimigo
   - **2. Fugir** - Tenta fugir (50% de chance)
   - **3. Lootear** - Busca itens pelo mapa
   - **4. Descansar** - Recupera stamina
   - **5. Usar Poção** - Cura a vida
   - **6. Equipar Item** - Equipa itens do inventário

3. Sobrevida tantas rodadas quanto possível!

## Estrutura do Projeto

```
C#_Praticando/
├── Program.cs          # Main do jogo
├── Models/
│   ├── Jogador.cs    # Dados do jogador
│   ├── Inimigo.cs    # Dados do inimigo
│   └── Items.cs      # Modelos de Item, Arma e Armadura
├── Systems/
│   ├── CombatSystem.cs  # Sistema de combate
│   ├── HordaSystem.cs   # Geração de inimigos
│   ├── LootSystem.cs    # Sistema de loot
│   └── PowerUp.cs       # Power-ups
├── Utils/
│   └── ArteASCII.cs     # Arte ASCII do jogo
└── Data/
    └── BancoDeDados.cs  # Recorde e persistência
```

## Documentação dos Arquivos

### Program.cs
- **Main**: Loop principal do jogo, menu de ações, sistema de rodadas
- Contém: inicialização, regeneração de stamina, barras visuais, loot inicial (3 itens), turn-based combat

### Models/Jogador.cs
- **Jogador**: Classe do jogador com vida, stamina, inventário, equipamentos
- Métodos: EquiparItem(), ApplyPowerUp(), UpdatePowerUps(), RegenerarStamina()

### Models/Inimigo.cs
- **Inimigo**: Classe do inimigo com nome, vida, defesa, arma
- Construtores: padrão (fallback) e completo (usado por HordaSystem)
- Método: UpdatePowerUps() para gerenciar power-ups ativos

### Models/Items.cs
- **Item**: Classe base para todos os itens do jogo
- **Arma**: Item equipável que adiciona dano e custo de stamina
- **Armadura**: Item equipável que adiciona defesa, vida e stamina bônus

### Systems/CombatSystem.cs
- **AtacarComArma()**: Ataque com arte ASCII
- **AtacarInimigo()**: Jogador ataca inimigo (consome stamina)
- **AtacarJogador()**: Inimigo ataca jogador (com defesa)
- **CalcularDanoComDefesa()**: Reduz dano pela defesa
- **VerificarMorte()/VerificarMorteInimigo()**: Checa condições de vitória/derrota

### Systems/HordaSystem.cs
- **EnemyType**: Molde para tipos de inimigos
- **GerarNovoInimigo()**: Gera inimigo com progressão de dificuldade
- Progressão: +10 vida por rodada, +1 defesa a cada 5 rodadas
- Tipos: Zumbi, Goblin, Orc, Dragão Pequeno

### Systems/LootSystem.cs
- **Lootear()**: 30% chance, adiciona a listas de equipamentos
- **GerarItemUnico()**: 30% chance, adiciona ao Inventory (inventário)
- **UsarPocao()**: Cura 10-50 de vida

### Systems/PowerUp.cs
- **PowerUp**: Representa buffs temporários com nome, duração e efeito

### Utils/ArteASCII.cs
- Desenhos: Personagem, Inimigo, Game Over, armas, poção, mochila

### Data/BancoDeDados.cs
- Salva/carrega highscore em arquivo texto (highscore.txt)

## Recursos

- Sistema de inventário com equipamento de armas e armaduras
- Inimigos progressivos (vida +10/rodada, defesa +1/5 rodadas)
- Arte ASCII para personagens e objetos
- Recorde salvo em arquivo
- Vida e stamina com barras visuais
- Poções de cura
- 4 tipos de inimigos: Zumbi, Goblin, Orc, Dragão Pequeno
- Loop de menu com validação de entrada
- Power-ups temporários (sistema preparado)
