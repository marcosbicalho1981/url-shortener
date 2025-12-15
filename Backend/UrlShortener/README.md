# URL Shortener – Desafio Técnico (.NET)

## Objetivo

Implementar um encurtador de URLs simples para demonstrar organização de código, 
decisões técnicas e clareza de comunicação, conforme proposto no desafio.

## Como rodar o projeto

### Opção 1 – Executar pelo Visual Studio (recomendado)

1. Abra o arquivo `UrlShortener.sln` no Visual Studio
2. Defina o projeto UrlShortener.Api como Startup Project
3. Pressione F5 ou clique em Run
4. A aplicação será iniciada e o navegador abrirá automaticamente

O Swagger estará disponível em `/swagger`.


### Opção 2 – Executar pelo terminal

Pré-requisitos

* .NET 6+

```bash
dotnet restore
dotnet run --project UrlShortener.Api
```

A API ficará disponível em `https://localhost:5001`.


## Endpoints

### Criar URL encurtada

`POST /api/url`

```json
{
  "originalUrl": "https://www.topazevolution.com/",
  "alias": "topaz"
}
```

* `alias` é opcional
* Caso não informado, um código curto é gerado automaticamente


### Redirecionamento

`GET /{code}`

Redireciona para a URL original associada ao código informado.

Observação sobre o Swagger

Este endpoint retorna um redirect HTTP (302). 
O Swagger UI não segue redirecionamentos automaticamente, podendo exibir a mensagem 
"Failed to fetch" mesmo com a API funcionando corretamente.

Para validar o redirecionamento:

* Acesse a URL diretamente pelo navegador (`https://localhost:{porta}/{code}`), ou
* Utilize ferramentas como Postman


### Redirecionamento

`GET /{code}`

Redireciona para a URL original associada ao código informado.

## Arquitetura

O projeto foi organizado em camadas para separar responsabilidades:

Api: Controllers e entrada HTTP
Application: Regras de negócio e serviços
Domain: Modelos de domínio
Infrastructure: Persistência e detalhes técnicos

## Controle de concorrência

A criação de URLs é serializada utilizando `SemaphoreSlim`, 
garantindo que apenas uma requisição seja processada por vez, conforme exigido no desafio, 
sem bloqueio de threads.


## Persistência

Foi utilizada persistência em memória com `ConcurrentDictionary`, 
suficiente para o escopo do desafio e fácil de substituir por banco de dados futuramente.


## Trade-offs

* Persistência em memória
* Sem autenticação
* Sem rate limit

## Melhorias futuras

* Persistência em banco de dados com Entity Framework
* Cache com Redis
* Validações adicionais com Fluent Validation
* Criação de filtros para capturar as exceptions
* Implementação de rate limiting e segurança
* Uso de container (Docker).
* Pipeline simples de CI/CD (mesmo local).


## Testes unitários

* Foram incluídos dois testes

1. Validar a criação de URLs quando o alias não for fornecido.
2. Não permitir criar duas URLs com o mesmo alias

