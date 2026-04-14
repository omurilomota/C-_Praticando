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
│   ├── Inimigo.cs  # Dados do inimigo
│   ├── Arma.cs     # Modelo de arma
│   ├── Armadura.cs # Modelo de armadura
│   └── Items.cs   # Modelo base de item
├── Systems/
│   ├── CombatSystem.cs  # Sistema de combate
│   ├── HordaSystem.cs # Geração de inimigos
│   ├── LootSystem.cs  # Sistema de loot
│   └── PowerUp.cs    # Power-ups
├── Utils/
│   └── ArteASCII.cs  # Arte ASCII do jogo
└── Data/
    └── BancoDeDados.cs # Recorde e persistência
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

### Models/Arma.cs / Armadura.cs
- Herdam de Item, adicionam Dano/StaminaCost ou Defesa

### Systems/CombatSystem.cs
- **AtacarComArma()**: Ataque com arte ASCII
- **AtacarInimigo()**: Jogador ataca inimigo
- **AtacarJogador()**: Inimigo ataca jogador (com defesa)
- **CalcularDanoComDefesa()**: Reduz dano pela defesa

### Systems/HordaSystem.cs
- **EnemyType**: Molde para tipos de inimigos
- **GerarNovoInimigo()**: Gera inimigo com progressão de dificuldade
- Tipos: Zumbi, Goblin, Orc, Dragão Pequeno

### Systems/LootSystem.cs
- **Lootear()**: 30% chance, adiciona a listas
- **GerarItemUnico()**: 30% chance, adiciona ao Inventory
- **UsarPocao()**: Cura 10-50 de vida

### Utils/ArteASCII.cs
- Desenhos: Personagem, Inimigo, Game Over, Armas, Poção, Mochila

### Data/BancoDeDados.cs
- Salva/carrega highscore em arquivo texto

## Recursos

- Sistema de inventario com equipamento de armas e armaduras
- Inimigos progressivos (vida +10/rodada, defesa +1/5rodadas)
- Arte ASCII para personagens e objetos
- Recorde salvo em arquivo
- Vida e stamina com barras visuais
- Poções de cura
- 4 tipos de inimigos: Zumbi, Goblin, Orc, Dragão Pequeno
- Loop de menu com validação de entrada