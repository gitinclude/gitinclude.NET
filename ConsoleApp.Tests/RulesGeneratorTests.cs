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
        public void Test(string include, string ignore)
        {
            Assert.Equal(ignore, new RulesGenerator().GetIgnoreRulesFromIncludeRules(include));
        }
    }
}