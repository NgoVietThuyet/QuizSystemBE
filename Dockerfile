FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# CHỈ copy file csproj và restore (không dùng file .sln)
COPY ["QuizSystemApi.csproj", "./"]
RUN dotnet restore "QuizSystemApi.csproj"

# Copy toàn bộ code còn lại
COPY . .
RUN dotnet publish "QuizSystemApi.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "QuizSystemApi.dll"]