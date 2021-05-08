FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

COPY . ./

RUN dotnet restore ./infotrack-coding-test/
RUN dotnet restore ./infotrack-coding-test.tests/

RUN dotnet test ./infotrack-coding-test.tests/

RUN dotnet publish ./infotrack-coding-test/. -c Release -o out

FROM microsoft/dotnet:aspnetcore-runtime

EXPOSE 5000

WORKDIR /app/infotrack-coding-test
COPY --from=build-env /app/infotrack-coding-test/out .
ENTRYPOINT ["dotnet", "infotrack-coding-test.dll"]