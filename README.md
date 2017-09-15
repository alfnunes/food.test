# food.test
Startup Lanche

# Rodando o projeto

 1 - Executar dentro do powershell o script run.ps1 que está na raiz do projeto.
 2 - Ele fará com que inicie o containner do Nginx + web + Api
 3 - Api estará rodando na porta 81 e a aplicação web na porta 80
 4 - Adicionei collection do postman para realizar os testes.
 5 - para olhar a documentação dos endpoints: http://localhost:81/swagger
 6 - Relatório do projeto

# food.api (BackEnd AspNet Core 2.0)

Projeto pode ser rodado no vs2017 ou com dotnet run dentro da pasta onde contém a solution.
Documentação da api rodando direto do kestrel ou VS, porta padrão 5000 setado no program.cs:

# food.web (Front End NodeJS)

 Rodar npm install
 
 depois nodemon ./app.js
