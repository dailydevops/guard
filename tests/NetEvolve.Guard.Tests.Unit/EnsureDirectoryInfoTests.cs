namespace NetEvolve.Guard.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.IO;

[ExcludeFromCodeCoverage]
[UnitTest]
public class EnsureDirectoryInfoTests
{
    [Test]
    [MethodDataSource(nameof(GetExistsData))]
    public void Exists_Theory_Expected(bool throwException, string directoryPath)
    {
        var directory = new DirectoryInfo(directoryPath);
        if (throwException)
        {
            _ = Assert.Throws<DirectoryNotFoundException>(() => _ = Ensure.That(directory).IsNotNull().Exists());
        }
        else
        {
            _ = Ensure.That(directory).IsNotNull().Exists();
        }
    }

    public static TheoryData<bool, string> GetExistsData =>
        new TheoryData<bool, string> { { true, "/does.not.exists/" }, { false, Path.GetTempPath() } };
}
