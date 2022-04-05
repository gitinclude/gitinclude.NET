using Xunit;
using Moq;
using System.IO;

namespace Gitinclude.Tests;

public class GitignoreUpdatorTests
{
    [Fact]
    public void NewFile()
    {
        var fileChanger = new Mock<IFileChanger>();
        fileChanger.Setup(x => x.Exists(It.IsAny<string>())).Returns(false);

        var updator = new GitignoreUpdator(
            rulesGenerator: Mock.Of<RulesGenerator>(x => x.GetIgnoreRulesFromIncludeRules(It.IsAny<string>()) == "Mock rules"),
            sectionReplacer: new SectionReplacer("# START", "# END"),
            fileChanger: fileChanger.Object);

        updator.Update("folder");
        fileChanger.Verify(x => x.WriteAllText(Path.Combine("folder", ".gitignore"),
@"# START
Mock rules
# END"));
    }

    [Fact]
    public void UpdateFile()
    {
        var fileChanger = new Mock<IFileChanger>();
        fileChanger.Setup(x => x.Exists(It.IsAny<string>())).Returns(true);
        fileChanger.Setup(x => x.ReadAllText(It.IsAny<string>())).Returns(
@"Hello!

# START
Old rules
# END

Bye!");

        var updator = new GitignoreUpdator(
            rulesGenerator: Mock.Of<RulesGenerator>(x => x.GetIgnoreRulesFromIncludeRules(It.IsAny<string>()) == "New rules"),
            sectionReplacer: new SectionReplacer("# START", "# END"),
            fileChanger: fileChanger.Object);

        updator.Update("folder");
        fileChanger.Verify(x => x.WriteAllText(Path.Combine("folder", ".gitignore"),
@"Hello!

# START
New rules
# END

Bye!"));
    }
}
