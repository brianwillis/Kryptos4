using System;
using Xunit;

namespace Kryptos4
{
    public class KryptosCypherDecryptCommandHandlerTest
    {
        [Fact]
        public void Solve_WhenSolvingKryptos1_SolutionIsCorrect()
        {
            var factory = new KryptosCypherDecryptCommandFactory(
                "EMUFPHZLRFAXYUSDJKZLDKRNSHGNFIVJYQTQUXQBQVYUVLLTREVJYQTMKYRDMFD",
                "KRYPTOSABCDEFGHIJLMNQUVWXZ",
                "PALIMPSEST"
            );
            var command = factory.GetNextCommand();
            var handler = new KryptosCypherDecryptCommandHandler();
            
            var result = handler.Solve(command);

            Assert.Equal(
                "BETWEENSUBTLESHADINGANDTHEABSENCEOFLIGHTLIESTHENUANCEOFIQLUSION",
                result.solution
            );
        }

        [Fact]
        public void Solve_WhenSolvingKryptos2_SolutionIsCorrect()
        {
            var factory = new KryptosCypherDecryptCommandFactory(
                "VFPJUDEEHZWETZYVGWHKKQETGFQJNCEGGWHKK?DQMCPFQZDQMMIAGPFXHQRLGTIMVMZJANQLVKQEDAGDVFRPJUNGEUNAQZGZLECGYUXUEENJTBJLBQCRTBJDFHRRYIZETKZEMVDUFKSJHKFWHKUWQLSZFTIHHDDDUVH?DWKBFUFPWNTDFIYCUQZEREEVLDKFEZMOQQJLTTUGSYQPFEUNLAVIDXFLGGTEZ?FKZBSFDQVGOGIPUFXHHDRKFFHQNTGPUAECNUVPDJMQCLQUMUNEDFQELZZVRRGKFFVOEEXBDMVPNFQXEZLGREDNQFMPNZGLFLPMRJQYALMGNUVPDXVKPDQUMEBEDMHDAFMJGZNUPLGEWJLLAETG",
                "KRYPTOSABCDEFGHIJLMNQUVWXZ",
                "ABSCISSA"
            );
            var command = factory.GetNextCommand();
            var handler = new KryptosCypherDecryptCommandHandler();
            
            var result = handler.Solve(command);
            
            Assert.Equal(
                "ITWASTOTALLYINVISIBLEHOWSTHATPOSSIBLE?THEYUSEDTHEEARTHSMAGNETICFIELDXTHEINFORMATIONWASGATHEREDANDTRANSMITTEDUNDERGRUUNDTOANUNKNOWNLOCATIONXDOESLANGLEYKNOWABOUTTHIS?THEYSHOULDITSBURIEDOUTTHERESOMEWHEREXWHOKNOWSTHEEXACTLOCATION?ONLYWWTHISWASHISLASTMESSAGEXTHIRTYEIGHTDEGREESFIFTYSEVENMINUTESSIXPOINTFIVESECONDSNORTHSEVENTYSEVENDEGREESEIGHTMINUTESFORTYFOURSECONDSWESTIDBYROWS",
                result.solution
            );
        }
    }
}