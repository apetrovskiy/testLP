



namespace LP.Tests;

using NUnit.Framework;

public class NunitConfig
{
    [OneTimeSetUp]
    public void Init()
    {
        Environment.CurrentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
    }
}
