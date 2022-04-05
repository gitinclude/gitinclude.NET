using Xunit;

namespace Gitinclude.ConsoleApp.Tests
{
    public class RulesGeneratorTests
    {
        [Theory]
        [InlineData(
@"StrategicProject/SpecificProject1/Method1/doc/*.tex",
        @"*
!StrategicProject/
StrategicProject/*
!StrategicProject/SpecificProject1/
StrategicProject/SpecificProject1/*
!StrategicProject/SpecificProject1/Method1/
StrategicProject/SpecificProject1/Method1/*
!StrategicProject/SpecificProject1/Method1/doc/
StrategicProject/SpecificProject1/Method1/doc/*
!StrategicProject/SpecificProject1/Method1/doc/*.tex")]
        [InlineData(
@"StrategicProject/SpecificProject1/Method1/doc/*.tex
StrategicProject/SpecificProject1/Method1/doc/*.lyx",
        @"*
!StrategicProject/
StrategicProject/*
!StrategicProject/SpecificProject1/
StrategicProject/SpecificProject1/*
!StrategicProject/SpecificProject1/Method1/
StrategicProject/SpecificProject1/Method1/*
!StrategicProject/SpecificProject1/Method1/doc/
StrategicProject/SpecificProject1/Method1/doc/*
!StrategicProject/SpecificProject1/Method1/doc/*.lyx
!StrategicProject/SpecificProject1/Method1/doc/*.tex")]
        [InlineData(
@"StrategicProject/SpecificProject1/Method1/doc/*.tex
StrategicProject/SpecificProject1/Method1/doc/*.lyx
StrategicProject/readme.md", 
        @"*
!StrategicProject/
StrategicProject/*
!StrategicProject/readme.md
!StrategicProject/SpecificProject1/
StrategicProject/SpecificProject1/*
!StrategicProject/SpecificProject1/Method1/
StrategicProject/SpecificProject1/Method1/*
!StrategicProject/SpecificProject1/Method1/doc/
StrategicProject/SpecificProject1/Method1/doc/*
!StrategicProject/SpecificProject1/Method1/doc/*.lyx
!StrategicProject/SpecificProject1/Method1/doc/*.tex")]
        [InlineData(
@".gitinclude
folder/file.txt
readme.md",
        @"*
!.gitinclude
!readme.md
!folder/
folder/*
!folder/file.txt")]
        [InlineData(
@"# whole-line comment on first line
.gitinclude # comment at the right of a rule
folder/file.txt
#comment between rules
readme.md
# whole-line comment on last line",
        @"*
!.gitinclude
!readme.md
!folder/
folder/*
!folder/file.txt")]
        public void Test(string includeRules, string ignore)
        {
            var newIgnoreRules = new RulesGenerator().GetIgnoreRulesFromIncludeRules(includeRules);
            Assert.Equal(ignore, newIgnoreRules);
        }
    }
}