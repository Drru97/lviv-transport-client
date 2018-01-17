.NET client library for Lviv Transport (LvivAvtodor) services
====================================

## Description

This library brings the [LvivAvtodor services](https://lad.lviv.ua/) to your .NET application.

## Support

Since it's first alpha version odf the library, proper testing should be done ensure it's stable enough to use in real production applications. 

If you find a bug, or have a feature suggestion, please [open an issue](https://github.com/Drru97/lviv-transport-client/issues/new). 

The library is not endorsed by LvivAvtodor.

## Requirements

  - .NET Standard 1.1 compatible framework (e.g. .NET Framework 4.5+ or .NET Core 1.0+)

## Installation

### Cloning sources

```bash
git clone https://github.com/Drru97/lviv-transport-client.git
```

### Building

```bash
dotnet build 
```

### Running tests

```bash
dotnet test ./test/LvivTransport.Client.Tests/LvivTransport.Client.Tests.csproj
```

## Usage

```csharp

// add required namespaces
using LvivTransport.Client.Core;
using LvivTransport.Client.Core.Request;

// getting the client
var client = new LvivTransportService();

// creating request for getting all routes
var routesRequest = new RoutesRequest();

// getting the routes
var routes = client.GetResponse(routesRequest);

// creating request for getting stop with id = 18
var stopRequest = new StopsRequest(18);

// getting specified stop
var stop = client.GetResponse(stopRequest);

// disposing resources
client.Dispose();

```
