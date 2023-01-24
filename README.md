# Projeto_SolarEnergy
Projeto de Cadastro de Unidades Solares utilizando Angular no FrontEnd, C# no BackEnd e SQL Server no banco de dados

<h3>🚧 Projeto em desenvolvimento 🚧</h3>

<h2>🛠️ Tecnologias Usadas</h2>  
<ul>
    <li>C#</li>
    <li>dotNet</li>
    <li>Angular</li>
    <li>Typescript</li>
    <li>SQL Server</li>
    <li>HTML</li>
    <li>SASS</li>
    <li>BootStrap</li>
</ul>

<p>Para saber o que fiz até agora:</p>

<ul>
    <li>Abra um terminal onde deseja criar a pasta</li>
</ul>

```bash
# Clone este repositório
$ git clone https://github.com/edmilsondmx/Projeto_SolarEnergy
```

<li>Vá para o arquivo <b style="color:#7b9eeb">appsettings.json</b> dentro do BackEnd e adicione a ConnectionString, seguindo o modelo abaixo 👇<br>

        ```bash
        "ConnectionStrings": {
        "ServerConnection": "Server=localhost\\SQLEXPRESS;Database=SOlarEnergy;Trusted_Connection=True;"
        }
        ```
</li>

<ul>
    <li>Conecte a sua máquina com um SQL Server local e atualize-o rodando no diretório do projeto o comando <code>dotnet ef database update</code></li>
    <li>No terminal entre na pasta ./BackEndSolarEnergy/SolarEnergy.Api e digite:</li>
    <li><code>dotnet run</code></li>
    <li>Abra outro terminal e entre na pasta ./FrontEndSolarEnergy e digite </li>
    <li><code>npm start</code></li>
    <li>A aplicação Front End será aberta na porta:4200</li>
</ul>

```bash
login: admin@email.com
senha: 101010
```


## Autor
Edmilson Gomes 😊