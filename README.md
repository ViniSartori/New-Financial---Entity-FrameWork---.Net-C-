O Financeiro é uma API desenvolvida em .NET 9 (C#) para o gerenciamento de lançamentos financeiros, com suporte a cadastro, edição, exclusão e cálculo automático de saldo.

O sistema foi construído seguindo boas práticas de arquitetura em camadas (Repository Pattern + Service Layer), utilizando Entity Framework Core com SQLite para persistência de dados.

A solução segue o padrão abaixo:

📁 Financeiro
 ┣ 📂 Controllers        → Endpoints REST da API
 ┣ 📂 Services           → Regras de negócio
 ┣ 📂 Repositories       → Acesso a dados (Repository Pattern)
 ┣ 📂 Models             → Entidades e DTOs
 ┣ 📂 Data               → Contexto do EF Core (FinanceiroContext)
 ┣ 📂 Migrations         → Migrações geradas pelo EF
 ┗ 📜 Program.cs         → Ponto de entrada da aplicação

 Tecnologia	Descrição
💻 .NET 9 (C#)	Framework principal
🗃️ Entity Framework Core	ORM para persistência de dados
💾 SQLite	Banco de dados leve e embarcado
🔄 Dapper (opcional)	Para consultas performáticas futuras
🌐 Swagger UI	Documentação interativa dos endpoints

✅ Cadastrar lançamentos financeiros
✅ Editar lançamentos existentes
✅ Excluir lançamentos
✅ Buscar lançamentos filtrando por data e histórico
✅ Calcular saldo atual (somando créditos e débitos)

Injeção de Dependência (Dependency Injection)

Repository Pattern

Service Layer Pattern

Entity Framework Migrations

Async/Await para operações assíncronas
