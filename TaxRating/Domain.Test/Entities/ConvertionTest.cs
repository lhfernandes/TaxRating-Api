﻿using Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Domain.Test.Entities
{
    public class ConvertionTest
    {

        [Theory]
        [InlineData(1, 1, 0,1)]
        [InlineData(5, 1, 0, 5)]
        [InlineData(5, 1, 0.5, 7.5)]
        public void GetValueConvertedUSDTxSegment(int amount, double txConv, double txSeg,double cresult)
        {
            // Arrange
            var convTest = new ConverterTax(amount, txConv, txSeg);

            // Act
            var result = convTest.Convert();

            // Assert
            result.ValConverted.Should().Be(cresult);
        }
    }
}
