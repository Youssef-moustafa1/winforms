// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel;

namespace System.Drawing.Printing.Tests;

public class PrinterResolutionTests
{
    [Fact]
    public void Ctor_Default()
    {
        PrinterResolution resolution = new();
        Assert.Equal(PrinterResolutionKind.Custom, resolution.Kind);
        Assert.Equal(0, resolution.X);
        Assert.Equal(0, resolution.Y);
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(1)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MinValue)]
    public void X_Value_ReturnsExpected(int value)
    {
        PrinterResolution resolution = new()
        {
            X = value
        };
        Assert.Equal(value, resolution.X);

        // Set same.
        resolution.X = value;
        Assert.Equal(value, resolution.X);
    }

    [Theory]
    [InlineData(int.MaxValue)]
    [InlineData(1)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MinValue)]
    public void Y_Value_ReturnsExpected(int value)
    {
        PrinterResolution resolution = new()
        {
            Y = value
        };
        Assert.Equal(value, resolution.Y);

        // Set same.
        resolution.Y = value;
        Assert.Equal(value, resolution.Y);
    }

    [Theory]
    [InlineData(PrinterResolutionKind.Custom)]
    [InlineData(PrinterResolutionKind.Draft)]
    [InlineData(PrinterResolutionKind.High)]
    [InlineData(PrinterResolutionKind.Low)]
    [InlineData(PrinterResolutionKind.Medium)]
    public void Kind_Set_GetReturnsExpected(PrinterResolutionKind value)
    {
        PrinterResolution resolution = new()
        {
            Kind = value
        };
        Assert.Equal(value, resolution.Kind);

        // Set same.
        resolution.Kind = value;
        Assert.Equal(value, resolution.Kind);
    }

    [Theory]
    [InlineData(PrinterResolutionKind.Custom + 1)]
    [InlineData(PrinterResolutionKind.High - 1)]
    public void Kind_SetInvalid_ThrowsInvalidEnumArgumentException(PrinterResolutionKind value)
    {
        PrinterResolution resolution = new();
        Assert.Throws<InvalidEnumArgumentException>("value", () => resolution.Kind = value);
    }

    public static IEnumerable<object[]> ToString_TestData()
    {
        yield return new object[] { new PrinterResolution(), "[PrinterResolution X=0 Y=0]" };
        yield return new object[] { new PrinterResolution { X = -1, Y = -2 }, "[PrinterResolution X=-1 Y=-2]" };
        yield return new object[] { new PrinterResolution { Kind = PrinterResolutionKind.High }, "[PrinterResolution High]" };
        yield return new object[] { new PrinterResolution { X = 1, Y = 2, Kind = PrinterResolutionKind.High }, "[PrinterResolution High]" };
    }

    [Theory]
    [MemberData(nameof(ToString_TestData))]
    public void ToString_Invoke_ReturnsExpected(PrinterResolution resolution, string expected)
    {
        Assert.Equal(expected, resolution.ToString());
    }
}
