## Version

This build is for .netcore3.0

## Installation

For easy installation use [NuGet](http://docs.nuget.org/docs/start-here/installing-nuget)

```
PM> Install-Package Randy.NET
```

## Usage

Firstly, you need to initialize `GeneratorClient` class with your **GeneratorService** API key

```csharp
GeneratorClient client = new GeneratorClient("ffffffff-ffff-ffff-ffff-ffffffffffff");
```
Then you can use necessary method to get the result of true randomness. Client supports sync/async versions of methods

### Available methods

- `GetIntegers`
- `GetIntegerSequences`
- `GetDecimalFractions`
- `GetGaussians`
- `GetStrings`
- `GetBlobs`
- `GetGuids`
- `GetUsage`

***
- You can check methods' arguments ranges in `summary` or in [random.org documentation](https://api.random.org/json-rpc/2/basic) 
- Available bases for integers: `2`, `8`, `10`, `16`
## Dependencies

- [Automapper](https://automapper.org/) >= 9.0.0

## Third party

- AsyncHelper from AspNetIdentity ([MIT](https://github.com/aspnet/AspNetIdentity/blob/master/License.txt))

## Contribution

If you find a bug, want to suggest an improvement or have a question, feel free to create an issue above

## Support

Part of [random.org](random.org) **[Contributed libraries](https://api.random.org/json-rpc/2/source-code)**

Supported with license by [Jetbrains opensource](jetbrains.com/opensource)

![Jetbrains](https://cdn.jsdelivr.net/npm/@jetbrains/logos@1.1.8/jetbrains/jetbrains.svg)
## To do

- [x] ~~`GetUUIDs` method~~
- [x] ~~`GetBlobs` method~~
- [x] ~~`GetUsage` method~~
- [ ] Arguments checks 
- [ ] Let users pass their ID to methods
- [ ] Some integrations tests
- [ ] Signed API
