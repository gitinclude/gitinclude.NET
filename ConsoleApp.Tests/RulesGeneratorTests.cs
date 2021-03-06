using Xunit;

namespace Gitinclude.Tests;

public class RulesGeneratorTests
{
    [Theory]
    [InlineData(
@"StrategicProject/SpecificProject1/Method1/doc/*.tex",
    @"StrategicProject/*
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
    @"StrategicProject/*
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
    @"StrategicProject/*
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
@"# whole-line comment on first line
folder/file.txt # comment at the right of a rule
# whole-line comment on last line",
    @"folder/*
!folder/file.txt")]
    public void Test(string includeRules, string ignore)
    {
        var newIgnoreRules = new RulesGenerator().GetIgnoreRulesFromIncludeRules(includeRules);
        Assert.Equal(ignore, newIgnoreRules);
    }
}
