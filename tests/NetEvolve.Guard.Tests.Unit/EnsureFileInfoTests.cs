namespace NetEvolve.Guard.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.IO;
using NetEvolve.Extensions.XUnit;
using NetEvolve.Guard;
using Xunit;

[ExcludeFromCodeCoverage]
[UnitTest]
public class EnsureFileInfoTests
{
    [Theory]
    [MemberData(nameof(GetExistsData))]
    public void Exists_Theory_Expected(bool throwException, string filePath)
    {
        var file = new FileInfo(filePath);
        if (throwException)
        {
            _ = Assert.Throws<FileNotFoundException>(
                () => _ = Ensure.That(file).IsNotNull().Exists()
            );
        }
        else
        {
            _ = Ensure.That(file).IsNotNull().Exists();
        }
    }

    public static TheoryData GetExistsData =>
        new TheoryData<bool, string>
        {
            { true, Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()) },
#if NET5_0_OR_GREATER
            { false, typeof(EnsureFileInfoTests).Assembly.Location }
#else
            { false, new System.Uri(typeof(EnsureFileInfoTests).Assembly.CodeBase!).LocalPath }
#endif
        };
}
