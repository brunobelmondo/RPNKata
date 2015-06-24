namespace Tests

open NUnit.Framework

[<TestFixture>]
type RPNTests() = 
    [<Test>]
    member x.Should_return_number_when_only_one_number() =
        Assert.AreEqual(5, RPN.RPN.Compute "5")

    [<TestCase("20 5 /", Result = 4)>]
    [<TestCase("20 5 +", Result = 25)>]
    [<TestCase("20 5 -", Result = 15)>]
    [<TestCase("20 5 *", Result = 100)>]
    member x.Should_return_result_when_two_numbers_and_one_operator input =
        RPN.RPN.Compute input

    [<TestCase("4 2 + 3 -", Result = 3)>]
    [<TestCase("3 5 8 * 7 + *", Result = 141)>]
    member x.Should_return_result_when_complex_operation input =
        RPN.RPN.Compute input
