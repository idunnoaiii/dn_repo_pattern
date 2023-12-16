dotnet ef migrations add "init ef core migration" --starup-project "../Repository.Api/Repository.Api.csproj"

dotnet ef database update --startup-project "../Repository.Api"