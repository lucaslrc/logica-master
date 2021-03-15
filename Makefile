start:
	dotnet restore
	dotnet clean
	dotnet test --collect:"XPlat Code Coverage"
	dotnet run --project ./logica/logica.csproj