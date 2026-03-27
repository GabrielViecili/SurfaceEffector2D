# 🦕 Runner 2D — Estilo Dino Chrome

Jogo de corrida infinita 2D desenvolvido na Unity. O personagem corre automaticamente enquanto obstáculos surgem à sua frente. O jogador pressiona **Espaço** para pular — com suporte a **duplo pulo**. A dificuldade aumenta progressivamente conforme o tempo passa.

---

## ⚙️ Função da Unity utilizada: Surface Effector 2D

O projeto usa o **Surface Effector 2D** como peça central da mecânica de movimento.

Em vez de mover o personagem pela tela, o chão é configurado como uma "esteira" que empurra tudo o que está sobre ele para a direita — criando a ilusão de que o personagem está correndo.

**Como foi usado:**
- Um objeto `Ground` (Sprite Square alongado) recebe um `Box Collider 2D` com o checkbox **"Used By Effector"** marcado.
- O componente `Surface Effector 2D` é adicionado a esse objeto com `Speed = 6`.
- O `GameManager` guarda uma referência direta ao `SurfaceEffector2D` e aumenta o valor de `speed` a cada fase, acelerando a "esteira" e tornando o jogo mais difícil.
- Os obstáculos leem essa mesma velocidade em tempo real via script (`ObstacleMover.cs`) para se mover sincronizados com o chão.

---

## 🗂️ Scripts do projeto

| Script | Responsabilidade |
|---|---|
| `PlayerController.cs` | Controla o pulo (duplo pulo) e detecta colisão com obstáculos |
| `GameManager.cs` | Gerencia pontuação, velocidade progressiva e estado do jogo |
| `ObstacleSpawner.cs` | Gera obstáculos em intervalos aleatórios que diminuem com a velocidade |
| `ObstacleMover.cs` | Move cada obstáculo sincronizado com a velocidade da esteira |

---

## 👥 Integrantes

- Alan Scheibler - 1130556
- Bruno Benevenuto - 1129601
- Gabriel Viecili - 1135192
- Pedro H. De Bortoli - 1129494
