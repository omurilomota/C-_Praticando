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

## Recursos

- Sistema de inventario com equipamento de armas e armaduras
- Inimigos progressivos (vida e defesa aumentam por rodada)
- Arte ASCII para personagens e objetos
- Recorde salvo em arquivo
- Vida e stamina com barras visuais
- Poções de cura
- 4 tipos de inimigos: Zumbi, Goblin, Orc, Dragão Pequeno