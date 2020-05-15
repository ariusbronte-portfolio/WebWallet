FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS publish
COPY [".", "./"]
RUN dotnet publish "./src/WebWallet.WebApi/WebWallet.WebApi.csproj" -c Release -o /app/publish

FROM publish AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebWallet.WebApi.dll"]