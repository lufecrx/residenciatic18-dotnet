# Questao 01 - Configura��o do Ambiente
## Problema: 
Como voc� pode verificar se o .NET SDK est� corretamente instalado em seu sistema? Em um arquivo de texto ou Markdown, liste os comandos que podem ser usados para verificar a(s) vers�o(�es) do .NET SDK instalada(s), como remover e atualizar.

## Resposta:
Para verificar se o .NET SDK est� corretamente instalado em nosso sistema, podemos abrir um prompt de comando e executar o comando "dotnet" (sem as aspas). Isso verificar� se o .NET est� instalado corretamente e pronto para uso. 

Lista de comandos:
- Verificar a vers�o do .NET SDK em uso:
```bash
dotnet --version
```
- Listar todas as vers�es do .NET SDK instaladas:
```bash
dotnet --list-sdks
```
- Remover uma vers�o espec�fica do .NET SDK:
```bash
dotnet --uninstall-sdk <version>
```

Para atualizar o .NET SDK, verifique qual vers�o est� instalada em seu dispositvo e acesse https://dotnet.microsoft.com/pt-br/download para instalar outra vers�o de sua prefer�ncia.

Para verificar outros comandos .NET, no prompt de comando use: 
```bash
dotnet --help
```