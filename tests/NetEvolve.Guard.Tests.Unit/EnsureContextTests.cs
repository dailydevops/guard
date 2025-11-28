namespace NetEvolve.Guard.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using NetEvolve.Extensions.TUnit;

[ExcludeFromCodeCoverage]
[UnitTest]
public sealed class EnsureContextTests
{
    [Test]
    public async Task ToT_WithValueType_Expected()
    {
        var value = 42;
        var context = Ensure.That(value);

        var result = context.ToT();

        _ = await Assert.That(result).IsEqualTo(value);
    }

    [Test]
    public async Task ToT_WithReferenceType_Expected()
    {
        var value = "test string";
        var context = Ensure.That(value);

        var result = context.ToT();

        _ = await Assert.That(result).IsEqualTo(value);
    }

    [Test]
    public async Task ToT_WithNullableValueType_WithValue_Expected()
    {
        int? value = 42;
        var context = Ensure.That(value);

        var result = context.ToT();

        _ = await Assert.That(result).IsEqualTo(value);
    }

    [Test]
    public async Task ToT_WithNullableValueType_WithNull_Expected()
    {
        int? value = null;
        var context = Ensure.That(value);

        var result = context.ToT();

        _ = await Assert.That(result).IsNull();
    }

    [Test]
    public async Task ToT_WithNullReferenceType_Expected()
    {
        string? value = null;
        var context = Ensure.That(value);

        var result = context.ToT();

        _ = await Assert.That(result).IsNull();
    }

    [Test]
    public async Task ToT_WithDecimal_Expected()
    {
        var value = 123.45m;
        var context = Ensure.That(value);

        var result = context.ToT();

        _ = await Assert.That(result).IsEqualTo(value);
    }

    [Test]
    public async Task ToT_WithDouble_Expected()
    {
        var value = 123.45;
        var context = Ensure.That(value);

        var result = context.ToT();

        _ = await Assert.That(result).IsEqualTo(value);
    }

    [Test]
    public async Task ToT_WithBoolean_Expected()
    {
        var value = true;
        var context = Ensure.That(value);

        var result = context.ToT();

        _ = await Assert.That(result).IsEqualTo(value);
    }

    [Test]
    public async Task ToT_WithDateTime_Expected()
    {
        var value = new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc);
        var context = Ensure.That(value);

        var result = context.ToT();

        _ = await Assert.That(result).IsEqualTo(value);
    }

    [Test]
    public async Task ToT_WithGuid_Expected()
    {
        var value = Guid.NewGuid();
        var context = Ensure.That(value);

        var result = context.ToT();

        _ = await Assert.That(result).IsEqualTo(value);
    }

    [Test]
    public async Task ToT_WithComplexObject_Expected()
    {
        var value = new TestObject { Id = 1, Name = "Test" };
        var context = Ensure.That(value);

        var result = context.ToT();

        _ = await Assert.That(result).IsEqualTo(value);
    }

    [Test]
    public async Task ToT_ImplicitConversion_WithValueType_Expected()
    {
        var value = 42;
        var context = Ensure.That(value);

        int result = context;

        _ = await Assert.That(result).IsEqualTo(value);
    }

    [Test]
    public async Task ToT_ImplicitConversion_WithReferenceType_Expected()
    {
        var value = "test string";
        var context = Ensure.That(value);

        string? result = context;

        _ = await Assert.That(result).IsEqualTo(value);
    }

    private sealed class TestObject
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
