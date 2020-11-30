FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# FROM node:10-alpine as build-node
# WORKDIR /clientApp
# COPY LoanGames.Web/clientApp/package.json .
# COPY LoanGames.Web/clientApp/package-lock.json .
# RUN npm install
# #COPY ["LoanGames.Web/clientApp", "./"] 
# RUN npm run build  

FROM  mcr.microsoft.com/dotnet/sdk:3.1 AS build
ENV BuildingDocker true
WORKDIR /src
COPY ["LoanGames.Web/LoanGames.Web.csproj", "LoanGames.Web/"]
RUN dotnet restore "./LoanGames.Web/LoanGames.Web.csproj"
COPY . .
WORKDIR "/src/LoanGames.Web"
RUN dotnet build "LoanGames.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LoanGames.Web.csproj" -c Release -o /app/publish

#Vue build
FROM node as nodebuilder
# set working directory
RUN mkdir /app
WORKDIR /app
# add `/app/node_modules/.bin` to $PATH
ENV PATH /app/node_modules/.bin:$PATH
# install and cache app dependencies
COPY LoanGames.Web/clientapp/package.json /app/package.json
RUN npm install
RUN npm install @vue/cli
# add app
COPY LoanGames.Web/clientapp/. /app
RUN npm run build
#End Vue build


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=nodebuilder /app/dist/. /app/ClientApp/dist/
ENTRYPOINT ["dotnet", "LoanGames.Web.dll"]