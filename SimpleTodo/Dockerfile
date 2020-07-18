#Get the SDK image from microsoft and create a layer called build
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

#Set its work dir to /src
WORKDIR /src

#Copy the C# project file
COPY SimpleTodo.csproj .

RUN dotnet restore
COPY . .
RUN dotnet publish -c release -o /app

#Get the aspnet image from microsoft and run as its own layer
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

#run the simple todo dll
WORKDIR /app

# we copy all the files we made from the build stage into the current layer
COPY --from=build /app .

#We need to add this for so the app will know to use localhost by default
ENV ASPNETCORE_URLS=http://+:5000

# we run the app in the current layer
ENTRYPOINT ["dotnet", "SimpleTodo.dll"]