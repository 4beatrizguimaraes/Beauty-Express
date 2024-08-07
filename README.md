# Beauty Express
Sistema de Agendamento e Gerenciamento de Serviços voltados para beleza e estética. A aplicação web permitirá o agendamento de diversos procedimentos estéticos em um estabelecimento específico.

## Sonre o Projeto 
Este repositório é dedicado ao projeto final da disciplina Desenvolvimento FullStack 2024/1 (INF/UFG), ministrada pelos professores Hugo Marciano e Sofia Larissa.

## Ferramentas e Tecnologias
Frontend: Angular /Typescript/ Tailwind

Backend: .Net 8 com EFCore

Banco de Dados: SQL Server

## Diagrama
https://drive.google.com/drive/folders/1ofGKzhdtj3Xel30NbyeeRL5otI9zvP6Q?usp=sharing

## Padrões
- Padrão Repository
- Clean Architecture
- IoC
- DDD

## Executando o projeto 
Requisitos de instalações:
- Angular CLI
- Node.js
- .NET Core SDK
- Visual Studio Community 2022
- SQL Server
  
Para executar o projeto, clone o repositório em sua máquina local. Abra a pasta do projeto e clique sobre o arquivo "BeautyExpress.sln". O Visual Studio será aberto automaticamente com o projeto carregado.

Configure o banco de dados. Para isso, obtenha o caminho do servidor do seu banco SQL Server

`
(Ex.: DESKTOP-NQ31Q0H\\SQLEXPRESS).
`

Em seguida, dentro do Visual Studio, abra a pasta "Infra", localize o arquivo "BeautyContext.cs" e abra-o. 
Na linha 14, altere o server colando o caminho do servidor do seu banco obtido anteriormente.

`
Ex.: private readonly string ConexaoBanco = "Server=COLOQUE_AQUI_O_CAMINHO_DO_SEU_BANCO;Database=BeautyExpress;Integrated Security = SSPI; TrustServerCertificate=True";
`

Configure a inicialização do projeto Backend. No Visual Studio, existe uma seta verde preenchida na barra de tarefas superior. Abrindo as opções de listagem, vá até 'Configurar Projetos de Inicialização' > Único Projeto de Inicialização > Selecione "Web". Aplique a alteração e clique em OK. 
Execute o backend clicando novamente na seta verde que agora deve ter o texto "https". 

Após iniciar o backend, precisamos fazer uma inserção de dados iniciais, rodando manualmente o script de inicialização no Banco de dados. O script está dentro do projeto em "...\Beauty-Express\Infra\script inicializacao.sql". Execute ele no banco de dados que já estará criado.

Configure e inicialize o Frontend. Abra o terminal, navegue pelo caminho "Beauty-Express\Web" e execute:

`
dotnet run --launch-profile https
`

Em seguida, navegue pelo caminho "Beauty-Express\Web\webapp\src". Para instalar as dependências, dentro de "src" execute:

`
npm install 
`

Depois, para iniciar o servidor de desenvolvimento do Angular, execute no mesmo diretório:

`
ng serve
`  

Será exibido o local onde a aplicação está sendo executada. Copie o caminho e cole em seu navegador. A aplicação será exibida. 

Para iniciar, faça seu cadastro, em seguida o Login, e por fim seus agendamentos. 


## Atendendo as expectativas
Nosso projeto foi feito com base nas aulas da disciplina Desenvolvimento FullStack 2024/1 (INF/UFG). Conseguindo, no fim, estabelecer o principal objetivo do projeto: A conexão de sucesso entre a página (front) e o banco de dados (back). Um exemplo claro disso é quando criamos um usuário: após inserirmos os dados, podemos conferir no nosso banco que eles estão armazenados e conseguimos ver eles sendo consumidos pelo front quando fazemos o login

## Equipe
Beatriz Batista Guimarães

Icaro Carneiro Caetano
