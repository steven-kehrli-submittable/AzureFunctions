# HelloWorld .NET 7.0 Isolated

This is a .NET 7.0 isolated version of the HelloWorld Azure Function.

There is a problem with the Visual Studio template to create an isolated Azure Function. It does not include all dependencies.

Instead, this function was created with the [command line](https://learn.microsoft.com/en-us/azure/azure-functions/create-first-function-cli-csharp?tabs=azure-cli%2Cisolated-process)

```
func init HelloWorld7 --worker-runtime dotnet-isolated --target-framework net7.0

cd HelloWorld7

func new --name HelloWorld7 --template "HTTP trigger" --authlevel "anonymous"
```
