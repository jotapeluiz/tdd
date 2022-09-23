# README

Projeto didático para apresentar TDD com C# usando xUnit e Moq.

## Números Romanos

O intuito desse projeto é apresentar o básico sobre TDD e o xUnit.

Criados e usados na Roma Antiga são representados por sete diferentes símbolos:

 - I: 1
 - V: 5
 - X: 10
 - L: 50
 - C: 100
 - D: 500
 - M: 1000

 Os demais números são uma combinação dos valores mostrados acima.

## Regras

As regras para se combinar esses símbolos são as seguintes:

 - Algarismos de menor ou igual valor à direita são somados ao de maior valor. Exemplo: II representa 2 (1 + 1) e XV representa 15 (10 + 5).
 - Algarismos de menor ou igual valor à esquerda são subtraídos ao de maior valor. Exemplo: XC representa 90 (100 - 10).
 - Um algarismo não pode repetir mais do que 3 vezes, portanto 4 em algarismos romanos é IV e não IIII.

## Sistema de Vendas

Projeto que simula de uma forma bem simples um sistema de vendas. Seu intuito é apresentar o básico sobre Moq.

 ## Rodar os Testes

 No visual studio acesse o menu Teste -> Gerenciador de Testes:

 ![menu](https://user-images.githubusercontent.com/43329190/191805651-9b44fa88-3515-4fdf-b8f4-f8be1570cb55.png)

Com a janela de testes aberta basta clicar em **Executar Tudo** para ver seu funcionamento:

![test explorer](https://user-images.githubusercontent.com/43329190/191807337-8050d3a9-9b3e-48d4-899c-df57ca7d9535.png)

