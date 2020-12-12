using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Kryptos4
{
    public class ProblemCommandHandlerTest
    {
        [Fact]
        public async void Solve_WhenSolvingKryptos1_SolutionIsCorrect()
        {
            Config.BuildLookupTable();
            var command = new ProblemCommand {
                encryptedText = "EMUFPHZLRFAXYUSDJKZLDKRNSHGNFIVJYQTQUXQBQVYUVLLTREVJYQTMKYRDMFD",
                keyword = "PALIMPSEST"
            };
            var handler = new ProblemCommandHandler();
            
            var result = await handler.Solve(command);

            Assert.Equal(
                "BETWEENSUBTLESHADINGANDTHEABSENCEOFLIGHTLIESTHENUANCEOFIQLUSION",
                result.decryptedText
            );
        }

        [Fact]
        public async void Solve_WhenSolvingKryptos2_SolutionIsCorrect()
        {
            Config.BuildLookupTable();
            var command = new ProblemCommand {
                encryptedText = "VFPJUDEEHZWETZYVGWHKKQETGFQJNCEGGWHKK?DQMCPFQZDQMMIAGPFXHQRLGTIMVMZJANQLVKQEDAGDVFRPJUNGEUNAQZGZLECGYUXUEENJTBJLBQCRTBJDFHRRYIZETKZEMVDUFKSJHKFWHKUWQLSZFTIHHDDDUVH?DWKBFUFPWNTDFIYCUQZEREEVLDKFEZMOQQJLTTUGSYQPFEUNLAVIDXFLGGTEZ?FKZBSFDQVGOGIPUFXHHDRKFFHQNTGPUAECNUVPDJMQCLQUMUNEDFQELZZVRRGKFFVOEEXBDMVPNFQXEZLGREDNQFMPNZGLFLPMRJQYALMGNUVPDXVKPDQUMEBEDMHDAFMJGZNUPLGEWJLLAETG",
                keyword = "ABSCISSA"
            };
            var handler = new ProblemCommandHandler();
            
            var result = await handler.Solve(command);
            
            Assert.Equal(
                "ITWASTOTALLYINVISIBLEHOWSTHATPOSSIBLE?THEYUSEDTHEEARTHSMAGNETICFIELDXTHEINFORMATIONWASGATHEREDANDTRANSMITTEDUNDERGRUUNDTOANUNKNOWNLOCATIONXDOESLANGLEYKNOWABOUTTHIS?THEYSHOULDITSBURIEDOUTTHERESOMEWHEREXWHOKNOWSTHEEXACTLOCATION?ONLYWWTHISWASHISLASTMESSAGEXTHIRTYEIGHTDEGREESFIFTYSEVENMINUTESSIXPOINTFIVESECONDSNORTHSEVENTYSEVENDEGREESEIGHTMINUTESFORTYFOURSECONDSWESTIDBYROWS",
                result.decryptedText
            );
        }
    }
}