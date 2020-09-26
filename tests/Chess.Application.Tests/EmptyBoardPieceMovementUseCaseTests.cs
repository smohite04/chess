using Chess.Domain;
using FluentAssertions;
using System;
using Xunit;

namespace Chess.Application.Tests
{
    public class EmptyBoardPieceMovementUseCaseTests
    {
        [Fact]
        public void EmptyBoardPieceMovementUseCase_when_given_valid_input_should_produce_valid_output()
        {
            var usecase = new EmptyBoardPieceMovementUseCase(new Direction());
            var response = usecase.Execute("King D5");
            var outcomes = response.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            outcomes.Should().Contain(new string[] { "E5", "E6", "D6", "C6", "C5", "C4", "D4", "E4" });
        }
        [Fact]
        public void EmptyBoardPieceMovementUseCase_when_given_invalid_input_should_throw_exception()
        {
            var usecase = new EmptyBoardPieceMovementUseCase(new Direction());
            Action response =()=> usecase.Execute("King1 D5");
            Assert.Throws<Exception>(response);
        }
    }
}
