using System.Collections.Generic;
using Xunit;

namespace Kryptos4
{
    public class ProblemCommandHandlerTest
    {
        [Fact]
        public void Solve_WhenSolvingKryptos1_SolutionIsCorrect()
        {
            var factory = new ProblemCommandFactory(
                new List<ProblemDefinition> {
                    new ProblemDefinition {
                        encryptedText = "EMUFPHZLRFAXYUSDJKZLDKRNSHGNFIVJYQTQUXQBQVYUVLLTREVJYQTMKYRDMFD"
                    }
                },
                "KRYPTOSABCDEFGHIJLMNQUVWXZ",
                "PALIMPSEST"
            );
            var command = factory.GetNextCommand();
            var handler = new ProblemCommandHandler();
            
            var result = handler.Solve(command);

            Assert.Equal(
                "BETWEENSUBTLESHADINGANDTHEABSENCEOFLIGHTLIESTHENUANCEOFIQLUSION",
                result.decryptedText
            );
        }

        [Fact]
        public void Solve_WhenSolvingKryptos2_SolutionIsCorrect()
        {
            var factory = new ProblemCommandFactory(
                new List<ProblemDefinition> {
                    new ProblemDefinition {
                        encryptedText = "VFPJUDEEHZWETZYVGWHKKQETGFQJNCEGGWHKK?DQMCPFQZDQMMIAGPFXHQRLGTIMVMZJANQLVKQEDAGDVFRPJUNGEUNAQZGZLECGYUXUEENJTBJLBQCRTBJDFHRRYIZETKZEMVDUFKSJHKFWHKUWQLSZFTIHHDDDUVH?DWKBFUFPWNTDFIYCUQZEREEVLDKFEZMOQQJLTTUGSYQPFEUNLAVIDXFLGGTEZ?FKZBSFDQVGOGIPUFXHHDRKFFHQNTGPUAECNUVPDJMQCLQUMUNEDFQELZZVRRGKFFVOEEXBDMVPNFQXEZLGREDNQFMPNZGLFLPMRJQYALMGNUVPDXVKPDQUMEBEDMHDAFMJGZNUPLGEWJLLAETG"
                    }
                },
                "KRYPTOSABCDEFGHIJLMNQUVWXZ",
                "ABSCISSA"
            );
            var command = factory.GetNextCommand();
            var handler = new ProblemCommandHandler();
            
            var result = handler.Solve(command);
            
            Assert.Equal(
                "ITWASTOTALLYINVISIBLEHOWSTHATPOSSIBLE?THEYUSEDTHEEARTHSMAGNETICFIELDXTHEINFORMATIONWASGATHEREDANDTRANSMITTEDUNDERGRUUNDTOANUNKNOWNLOCATIONXDOESLANGLEYKNOWABOUTTHIS?THEYSHOULDITSBURIEDOUTTHERESOMEWHEREXWHOKNOWSTHEEXACTLOCATION?ONLYWWTHISWASHISLASTMESSAGEXTHIRTYEIGHTDEGREESFIFTYSEVENMINUTESSIXPOINTFIVESECONDSNORTHSEVENTYSEVENDEGREESEIGHTMINUTESFORTYFOURSECONDSWESTIDBYROWS",
                result.decryptedText
            );
        }
    }
}