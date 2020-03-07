## Version

This build is for .netstandart2.1


## Installation

For easy installation use [NuGet](http://docs.nuget.org/docs/start-here/installing-nuget)

```
PM> Install-Package Randy.NET
```

## Usage

Firstly, you need to initialize `GeneratorClient` class with your **GeneratorService** api key

```c#
GeneratorClient client = new GeneratorClient("ffffffff-ffff-ffff-ffff-ffffffffffff");
```
Then you can use necessary method to get the result of true randomness. Client supports sync/async versions of methods

### Available methods

- `GetIntegers`
- `GetIntegerSequences`
- `GetDecimalFractions`
- `GetGaussians`
- `GetStrings`

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

## To do

- [ ] `GetUUIDs` method
- [ ] `GetBlobs` method
- [ ] `GetUsage` method
- [ ] Some integrations tests
- [ ] Signed API
