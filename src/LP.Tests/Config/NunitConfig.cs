

// dotnet format cannot remove these lines

namespace LP.Tests.Config;

// dotnet format cannot remove these lines

using NUnit.Framework;

public class NunitConfig
{
    [OneTimeSetUp]
    public void Init()
    {
        Environment.CurrentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
    }
}
