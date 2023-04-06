# Choose an Azure compute service

## Azure Functions

From [Choose an Azure compute service](https://learn.microsoft.com/en-us/azure/architecture/guide/technology-choices/compute-decision-tree)

Following the flowchart leads us to [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview)
- Build new
- **No** Do you require full control?
- **No** HPC workload?
- **No** Using Spring Boot apps?
- **Yes** Event-driven workload with short-lived processes?

## Quickstart - HelloWorld API

[Quickstart: Create your first C# function in Azure using Visual Studio](https://learn.microsoft.com/en-us/azure/azure-functions/functions-create-your-first-function-visual-studio?tabs=in-process)

### Results

The above quickstart successfully built and deployed the HelloWorld API: [https://helloworld7-submittable.azurewebsites.net/api/HelloWorld7](https://helloworld7-submittable.azurewebsites.net/api/HelloWorld7).

The Azure Portal was used to first create the new Azure Function resource (instead of through Visual Studio). This should be the same as Terraform creating the Azure Function and then Visual Studio / Visual Studio Code / Github deploying the function.
