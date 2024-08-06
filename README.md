# Beauty Express
Sistema de Agendamento e Gerenciamento de Serviços voltados para beleza e estética. A aplicação web permitirá o agendamento de diversos procedimentos estéticos em um estabelecimento específico.

## Sonre o Projeto 
Este repositório é dedicado ao projeto final da disciplina Desenvolvimento FullStack 2024/1 (INF/UFG), ministrada pelos professores Hugo Marciano e Sofia Larissa.

## Ferramentas e Tecnologias
Frontend: Angular / Tailwind

Backend: .Net 8 com EFCore

Banco de Dados: SQL Server

## Diagrama
https://drive.google.com/drive/folders/1ofGKzhdtj3Xel30NbyeeRL5otI9zvP6Q?usp=sharing

## Padrões
- Padrão Repository
- Clean Architecture
- IoC
- DDD

## Usando o projeto 
Primeiramente, dento da pasta infra, temos o arquvio BeautyContext.cs, onde é preciso alterar a string ConexaoBanco.

Com a string de conexão devidamente alterada, por meio do Entity Framework, faremos a migração das estruturas de dados, começando por criar uma migração, abrindo o terminal na pasta "BeautyExpress\Infra":
´
dotnet ef add migration nomedamigracao
´
Lembrando que o o nome da migração você mesmo escolhe, após isso, temos que realmente implementar as mudanças por meio do segundo comando:
´
dotnet ef database update
´
Após isso, iremos rodar o back, por meio de um comando na pasta "BeautyExpress\Web":
´
dotnet run --launch-profile https
´
Por último, inciaremos o projeto Angular, após isso, poderemos acessar o projeto no localhost informado, basta o seguinte comando na pasta "BeautyExpress\Web\webapp\src":
´
ng serve
´
## Atendendo as expectativas
Nosso projeto foi feito com base nas aulas da disciplina Desenvolvimento FullStack 2024/1 (INF/UFG). Conseguindo, no fim, estabelecer o principal objetivo do projeto: A conexão de sucesso entre a página (front) e o banco de dados (back). Um exemplo claro disso é quando criamos um usuário: após inserirmos os dados, podemos conferir no nosso banco que eles estão armazenados e conseguimos ver eles sendo consumidos pelo front quando fazemos o login

## Equipe
Beatriz Batista Guimarães

Icaro Carneiro Caetano
