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
        [InlineData("pawn A1", "B1")]
        public void EmptyBoardPieceMovementUseCase_when_given_valid_input_should_produce_valid_output(string request, string responseValueStr)
        {
            var usecase = new EmptyBoardPieceMovementUseCase(new Direction());
            var response = usecase.Execute(request);
            var outcomes = response.Split(",", StringSplitOptions.RemoveEmptyEntries);
            var expectedOutcomes = responseValueStr.Split(",", StringSplitOptions.RemoveEmptyEntries);
            outcomes.Should().Contain(expectedOutcomes);
        }
        [Theory]
        [InlineData("King1 D5")]
        [InlineData("King D9")]
        [InlineData("King D9 d7")]
        [InlineData("D9 King")]
        public void EmptyBoardPieceMovementUseCase_when_given_invalid_input_should_throw_exception(string input)
        {
            var usecase = new EmptyBoardPieceMovementUseCase(new Direction());
            Action response =()=> usecase.Execute(input);
            Assert.ThrowsAny<BadRequestException>(response);
        }
    }
}
