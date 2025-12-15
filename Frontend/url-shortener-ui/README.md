# UrlShortenerUi

Este projeto contém o frontend em Angular, responsável por consumir a API backend e apresentar a interface do usuário. A aplicação foi desenvolvida seguindo boas práticas de organização, compatibilidade com navegadores modernos e possibilidade de publicação em IIS.

Gerado com [Angular CLI] version 16.1.8

## Development server

Execute o comando `ng serve` para iniciar um servidor de desenvolvimento. Acesse `http://localhost:4200/`. O aplicativo será recarregado automaticamente se você alterar algum dos arquivos de origem.

## Tecnologias e Versões

Angular: 16.x
Angular CLI: 16.1.8
Node.js: 18.x LTS (recomendado)
npm: 9.x

## Pré-requisitos

Node.js 18 LTS instalado
npm instalado
Angular CLI instalado globalmente: npm install -g @angular/cli@16

## Executar em Ambiente de Desenvolvimento

ng serve

A aplicação ficará disponível em:
http://localhost:4200

## Configuração de Ambiente

As URLs e variáveis de ambiente podem ser configuradas em:
src/environments/

- environment.ts
- environment.prod.ts

Certifique-se de que a URL base da API esteja corretamente configurada para cada ambiente.

## Build para Produção

ng build --configuration production

Os arquivos de build serão gerados em:
dist/<nome-do-projeto>/

## Publicação no IIS

1.  Gere o build de produção:
    ng build --configuration production

2.  Copie o conteúdo da pasta dist/<nome-do-projeto> para um diretório do IIS.

3.  No Internet Information Services (IIS):

- Crie um Site ou Aplicação apontando para a pasta do build
- Garanta que o recurso Static Content esteja habilitado

4.  Adicione o arquivo web.config para suportar rotas do Angular (SPA):

 <?xml version="1.0" encoding="utf-8"?>
   <configuration>
    <system.webServer>
      <rewrite>
        <rules>
          <rule name="Angular Routes" stopProcessing="true">
           <match url=".*" />
            <conditions logicalGrouping="MatchAll">
            <add input="{REQUEST_FILENAME}" matchType="IsFile" negate="true" />
            <add input="{REQUEST_FILENAME}" matchType="IsDirectory" negate="true" />
            </conditions>
            <action type="Rewrite" url="/index.html" />
            </rule>
            </rules>
          </rewrite>
          </system.webServer>
   </configuration>

## Compatibilidade de Navegadores

Google Chrome
Microsoft Edge

## Observações Finais

Para integração completa, consulte o README do backend (.NET).
