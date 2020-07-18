using System.Collections.Generic;
using Xunit;

namespace Kryptos4
{
    public class DecryptCommandHandlerTest
    {
        [Fact]
        public void Solve_WhenSolvingKryptos1_SolutionIsCorrect()
        {
            var factory = new DecryptCommandFactory(
                new List<string> {"EMUFPHZLRFAXYUSDJKZLDKRNSHGNFIVJYQTQUXQBQVYUVLLTREVJYQTMKYRDMFD"},
                "KRYPTOSABCDEFGHIJLMNQUVWXZ",
                "PALIMPSEST"
            );
            var command = factory.GetNextCommand();
            var handler = new DecryptCommandHandler();
            
            var result = handler.Solve(command);

            Assert.Equal(
                "BETWEENSUBTLESHADINGANDTHEABSENCEOFLIGHTLIESTHENUANCEOFIQLUSION",
                result.solution
            );
        }

        [Fact]
        public void Solve_WhenSolvingKryptos2_SolutionIsCorrect()
        {
            var factory = new DecryptCommandFactory(
                new List<string> {"VFPJUDEEHZWETZYVGWHKKQETGFQJNCEGGWHKK?DQMCPFQZDQMMIAGPFXHQRLGTIMVMZJANQLVKQEDAGDVFRPJUNGEUNAQZGZLECGYUXUEENJTBJLBQCRTBJDFHRRYIZETKZEMVDUFKSJHKFWHKUWQLSZFTIHHDDDUVH?DWKBFUFPWNTDFIYCUQZEREEVLDKFEZMOQQJLTTUGSYQPFEUNLAVIDXFLGGTEZ?FKZBSFDQVGOGIPUFXHHDRKFFHQNTGPUAECNUVPDJMQCLQUMUNEDFQELZZVRRGKFFVOEEXBDMVPNFQXEZLGREDNQFMPNZGLFLPMRJQYALMGNUVPDXVKPDQUMEBEDMHDAFMJGZNUPLGEWJLLAETG"},
                "KRYPTOSABCDEFGHIJLMNQUVWXZ",
                "ABSCISSA"
            );
            var command = factory.GetNextCommand();
            var handler = new DecryptCommandHandler();
            
            var result = handler.Solve(command);
            
            Assert.Equal(
                "ITWASTOTALLYINVISIBLEHOWSTHATPOSSIBLE?THEYUSEDTHEEARTHSMAGNETICFIELDXTHEINFORMATIONWASGATHEREDANDTRANSMITTEDUNDERGRUUNDTOANUNKNOWNLOCATIONXDOESLANGLEYKNOWABOUTTHIS?THEYSHOULDITSBURIEDOUTTHERESOMEWHEREXWHOKNOWSTHEEXACTLOCATION?ONLYWWTHISWASHISLASTMESSAGEXTHIRTYEIGHTDEGREESFIFTYSEVENMINUTESSIXPOINTFIVESECONDSNORTHSEVENTYSEVENDEGREESEIGHTMINUTESFORTYFOURSECONDSWESTIDBYROWS",
                result.solution
            );
        }
    }
}