# Coin selector

Please find the project Coin selector wich allows to create User assign cryptocurrency with current prices.

## Prerequisites

.Net 6
VisualStudio 2022
NodeJs v17.3.1
Angular 13.1.4

## Build and Start Application

### Backend

#### Command line

From solution folder please execute following commands:

For building application:

```
dotnet build CoinSelector.sln
```

For running all unit tests:

```
dotnet test CoinSelector.UnitTests
```

For running Application please execute command

```
dotnet run  --project CoinSelector.Api
```

Please open browser and navigate to https://localhost:7145/swagger

#### VisualStudio 2022

Please open solution in VisualStudio and rebuild.

For running test: open test explorer and run all tests.

For running project - hit F5, after that default browser will be opeened and you will be redirected to https://localhost:7145/swagger

### Frontend

from folder 'coin-selector' execute following commands

For load and install all dependencies

```
npm install
```

For load and install all dependencies

```
npm install
```

For run application

```
npm start
```

After that open browser and navigate to URL http://localhost:4200

## Database

Please note the application required acces to the instance of SqlServer mssqllocaldb, if you don't have that instabce installed, please remove Connection string from appsettings.Development.json file.

This will allow to use inmemory database instead.