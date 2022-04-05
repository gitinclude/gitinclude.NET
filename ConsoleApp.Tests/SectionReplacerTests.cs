using Xunit;

namespace Gitinclude.ConsoleApp.Tests
{
    public class SectionReplacerTests
    {
        const string _newSectionText =
@"Line A
Line B
Line C";

        [Theory]
        [InlineData(
@"// Something before

# Section START
Line 1
Line 2
# Section END

# Something after",
@"// Something before

# Section START
Line A
Line B
Line C
# Section END

# Something after")]

[InlineData(
@"// No section yet",
@"// No section yet

# Section START
Line A
Line B
Line C
# Section END")]
        [InlineData(
@"# Section START
Line A
Line B
Line C
# Section END",
@"# Section START
Line A
Line B
Line C
# Section END")]
        public void Test(string originalText, string expectedNewText)
        {
            var sectionReplacer = new SectionReplacer(
                sectionOpener: "# Section START",
                sectionCloser: "# Section END");
            var result = sectionReplacer.GetTextWithSection(
                             originalText: originalText,
                             newSectionText: _newSectionText);
            Assert.Equal(expectedNewText, result);
        }
    }
}
