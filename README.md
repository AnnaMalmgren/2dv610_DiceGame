# 2dv610_DiceGame

DiceGame is a simple console application where the user can enter how many dice they want in the game and then guess what score will be rolled.

To run the application locate to the DiceGame folder, `cd DiceGame` from root folder, and run `dotnet run`.

The application is written in C#, in IDE visualstudio code, using a TDD approach.

## Testing Tools

### Unit Testing Framework

Unit testing framework used is [xUnit](https://xunit.net/).

To run all unit tests locate to the DiceGameTests folder, `cd DiceGameTests` from root, and run `dotnet test`

### Mocking Library

Mocking framwork used is [Moq](https://github.com/moq/moq4).


### Coverage tool

Coverage tool used is [Coverlet](https://github.com/tonerdo/coverlet/blob/master/Documentation/MSBuildIntegration.md).

To run all tests with coverage locate to DiceGameTests folder, `cd DiceGameTests` from root, and run `dotnet test /p:CollectCoverage=true` or `dotnet test -p:CollectCoverage=true`.


## Test coverage of project (Main method not included)

![coverage](https://user-images.githubusercontent.com/42740175/69829928-74716d00-1222-11ea-95eb-4447830ee36e.png)
