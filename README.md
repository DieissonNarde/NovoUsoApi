# NovoUsoApi

API REST desenvolvida em ASP.NET Core para gerenciamento de anúncios, lances, fotos, categorias e contratos de itens.

## Tecnologias

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- JWT para autenticação
- Swagger / OpenAPI

## Funcionalidades

- Cadastro e login de usuários
- Criação, edição, listagem e remoção de itens
- Gerenciamento de categorias
- Criação e manutenção de lances
- Gerenciamento de fotos dos itens
- Gerenciamento de contratos de item
- Paginação na listagem de itens

## Requisitos

- .NET SDK 10 instalado
- PostgreSQL em execução
- Banco de dados criado

## Configuração

O projeto usa a string de conexão definida em `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "User ID=postgres;Password=postgres123;Host=localhost;Port=5432;Database=novouso;Pooling=true;Connection Lifetime=0;"
}
```

Se necessário, ajuste:

- `User ID`
- `Password`
- `Host`
- `Port`
- `Database`

Também existe configuração de JWT em `appsettings.json`:

```json
"Jwt": {
  "Issuer": "NovoUsoApi",
  "Audience": "NovoUsoApiClient",
  "SecretKey": "YourSuperSecretKeyForJwtTokenGeneration"
}
```

## Como executar

1. Restaure os pacotes:

```bash
dotnet restore
```

2. Aplique as migrations no banco:

```bash
dotnet ef database update
```

3. Rode a aplicação:

```bash
dotnet run
```

## URLs locais

O arquivo `Properties/launchSettings.json` define os seguintes endereços de desenvolvimento:

- HTTP: `http://localhost:5134`
- HTTPS: `https://localhost:7038`

## Swagger

Em ambiente de desenvolvimento, o Swagger é habilitado automaticamente. Depois de subir a API, acesse:

```text
https://localhost:7038/swagger
```

ou

```text
http://localhost:5134/swagger
```

## CORS

A API permite requisições do frontend em:

```text
http://127.0.0.1:5500
```

## Endpoints principais

### Usuários

- `POST /api/User` - cadastrar usuário
- `POST /api/User/login` - autenticar usuário e gerar token JWT

### Itens

- `GET /api/Item` - listar itens com paginação
- `GET /api/Item/{id}` - buscar item por id
- `POST /api/Item` - criar item
- `PUT /api/Item` - atualizar item
- `DELETE /api/Item/{id}` - remover item

### Categorias

- `GET /api/Category` - listar categorias
- `GET /api/Category/{id}` - buscar categoria por id

### Lances

- `GET /api/Bid` - listar lances
- `GET /api/Bid/{id}` - buscar lance por id
- `POST /api/Bid` - criar lance
- `PUT /api/Bid` - atualizar lance
- `DELETE /api/Bid/{id}` - remover lance

### Fotos de itens

- `GET /api/ItemPhoto` - listar fotos
- `GET /api/ItemPhoto/{id}` - buscar foto por id
- `POST /api/ItemPhoto` - adicionar foto
- `PUT /api/ItemPhoto` - atualizar foto
- `DELETE /api/ItemPhoto/{id}` - remover foto

### Contratos de item

- `GET /api/ItemAgreement` - listar contratos
- `GET /api/ItemAgreement/{id}` - buscar contrato por id
- `POST /api/ItemAgreement` - criar contrato
- `PUT /api/ItemAgreement` - atualizar contrato

## Estrutura do projeto

- `Controllers/` - endpoints HTTP
- `Services/` - regra de negócio
- `Repositories/` - acesso aos dados
- `Data/` - contexto e configurações do EF Core
- `DTOs/` - objetos de entrada e saída
- `Models/` - entidades do domínio
- `Migrations/` - histórico de migrations

## Observações

- A API usa middleware próprio de tratamento de exceções.
- Arquivos estáticos e uploads são servidos via `wwwroot` e `uploads`.
- A listagem de itens inclui cabeçalhos de paginação.
