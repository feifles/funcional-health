# funcional-health
Teste para Funcional Health


Realizando o desafio https://github.com/funcional-health/challenge/blob/master/csharp.md

Projeto simulando um caixa eletrônico com operações de depositar, sacar e ver saldo.

Aplicação RESTful com mapeamento de objetos e implementando padrão de repositório.

Contém testes unitários feitos com XUnit.


## Valores inseridos no banco através do method Seed
1. INSERT INTO ContasCorrentes (AccountNumber, Balance) VALUES ('123456', 1000)
2. INSERT INTO ContasCorrentes (AccountNumber, Balance) VALUES ('654321', 100)
3. INSERT INTO ContasCorrentes (AccountNumber, Balance) VALUES ('567890', 320)


# Como rodar?

1 - Altere o connection string em appsettings.json.
Exemplo: 

```"Default": "Data Source=MYMACHINE; database=MYDATABASE; User ID=USER;Password=PASSWORD;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" ```

2 - Execute as migrações:
    Visual Studio:
    ``` update-database ```
    CLI .NET Core: 
    ``` dotnet ef database update ```
    

     
Só isso! Aproveite =D
