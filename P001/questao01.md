# Questao 01 - Configuração do Ambiente
## Problema: 
Como você pode verificar se o .NET SDK está corretamente instalado em seu sistema? Em um arquivo de texto ou Markdown, liste os comandos que podem ser usados para verificar a(s) versão(ões) do .NET SDK instalada(s), como remover e atualizar.

## Resposta:
Para verificar se o .NET SDK está corretamente instalado em nosso sistema, podemos abrir um prompt de comando e executar o comando "dotnet" (sem as aspas). Isso verificará se o .NET está instalado corretamente e pronto para uso. 

Lista de comandos:
- Verificar a versão do .NET SDK em uso:
```bash
dotnet --version
```
- Listar todas as versões do .NET SDK instaladas:
```bash
dotnet --list-sdks
```
- Remover uma versão específica do .NET SDK:
```bash
dotnet --uninstall-sdk <version>
```

Para atualizar o .NET SDK, verifique qual versão está instalada em seu dispositvo e acesse https://dotnet.microsoft.com/pt-br/download para instalar outra versão de sua preferência.

Para verificar outros comandos .NET, no prompt de comando use: 
```bash
dotnet --help
```