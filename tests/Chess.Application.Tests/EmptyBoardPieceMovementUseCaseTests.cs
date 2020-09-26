using Chess.Domain;
using FluentAssertions;
using System;
using Xunit;

namespace Chess.Application.Tests
{
    public class EmptyBoardPieceMovementUseCaseTests
    {
        [Theory]
        [InlineData("King D5" ,"E5,E6,D6,C6,C5,C4,D4,E4")]
        [InlineData("Horse E3" , "G4,F5,D5,C4,C2,D1,F1,G2")]
        public void EmptyBoardPieceMovementUseCase_when_given_valid_input_should_produce_valid_output(string request, string responseValueStr)
        {
            var usecase = new EmptyBoardPieceMovementUseCase(new Direction());
            var response = usecase.Execute(request);
            var outcomes = response.Split(",", StringSplitOptions.RemoveEmptyEntries);
            var expectedOutcomes = responseValueStr.Split(",", StringSplitOptions.RemoveEmptyEntries);
            outcomes.Should().Contain(expectedOutcomes);
        }
        [Fact]
        public void EmptyBoardPieceMovementUseCase_when_given_invalid_input_should_throw_exception()
        {
            var usecase = new EmptyBoardPieceMovementUseCase(new Direction());
            Action response =()=> usecase.Execute("King1 D5");
            Assert.ThrowsAny<Exception>(response);
        }
    }
}
