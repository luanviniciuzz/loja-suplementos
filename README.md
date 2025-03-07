<h1 align="center" style="font-weight: bold;">Loja de Suplementos 💻</h1>

<p align="center">
 <a href="#tech">Tecnologias</a> • 
 <a href="#started">Inicializando</a> • 
  <a href="#routes">API Endpoints</a> •
 <a href="#acess">Acessando</a> •
</p>

<p align="center">
    <b>Projeto para gerenciar uma loja de suplementos</b>
</p>

<h2 id="technologies">💻 Tecnologias</h2>

- C#
- ASP.NET
- SQL SERVER
- AWS RDS
- Docker

  Como padrão de projeto utilizei os conceitos do Repository Pattern para facilitar o encapsulamento
  da lógica de acesso dos dados e controlar a injeção de dependências.

  <h3>Modelagem do banco de dados</h3>
  <img src="edr.png" alt="Exemplo imagem">


<h2 id="started">🚀 Inicializando</h2>

Rodando o projeto localmente

<h3>Pré requisitos</h3>

Tecnologias necessárias

- [SQL SERVER](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [Git](https://git-scm.com/downloads)
- [.NET SDK](https://dotnet.microsoft.com/pt-br/download/visual-studio-sdks) 8.0+
- [Docker](https://www.docker.com/)
  
<h3>Clonando</h3>

Para clonar o projeto na sua máquina

```bash
git clone https://github.com/luanviniciuzz/loja-suplementos.git
```

Restaure as dependencias
```bash
dotnet restore
```

No terminal da aplicação rodar o camando abaixo depois de se conectar ao banco de dados local
```bash
update-database
```
Compile o projeto:
```bash
dotnet-build
```

<h2 id="routes">📍 API Endpoints</h2>

Para acessar a API do desafio das vagoais
Local host: https://localhost:7289/swagger/index.html

| route               | description                                          
|----------------------|-----------------------------------------------------
| <kbd>POST /api</kbd>     | Encontra a primeira vogal a partir de uma string

<h2 id="acess">💻 Acessando o projeto</h2>

O projeto foi hospedado usando a plataforma Render para a aplicação feita em ASP.NET Core
e foi criado um banco de dados na AWS para se conectar a aplicação

<p>API: https://loja-suplementos-1rml.onrender.com/swagger/index.html</p>
<p>Sistema web: https://loja-suplementos-1rml.onrender.com</p>

