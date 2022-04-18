using System;
using System.Collections.Generic;
using System.Linq;

namespace FErdle
{
    public class WordList
    {
        //17-4-2022: updated with new wordlist
        List<string> answers = new List<string>
        {
            "marth","holst","dorte","gerik","caeda","eitri","thorr","ytiki","atiki","quest","kiran","remix","bantu","mkris","fkris","norne","cecil","elice","linde","midia","roger","barst","phina","camus","maria","jagen","draug","etzel","arlen","gotoh",
            "tomas","arran","dolph","frost","mycen","kliff","tobin","clive","clair","lukas","saber","nomah","genny","kamui","sonya","atlas","jesse","palla","rinea","blake","barth","garth","dolth","jedah","marla","arden","lewyn","edain","midir","jamke",
            "arvis","hilda","claud","julia","arion","linda","oifey","daisy","byron","brian","bloom","voltz","nanna","eyvel","tanya","osian","lifis","ronan","asbel","karin","misha","homer","perne","salem","olwen","sleuf","kempf","dryas","glade","marty",
            "saias","shiva","hicks","ilios","gomez","idunn","niime","dieck","klein","zeiss","karel","raigh","ogier","lance","geese","larum","galle","dayan","zelot","yoder","sonia","athos","lloyd","raven","serra","canas","oswin","karla","fiora","lowen",
            "geitz","linus","vaida","heath","uther","leila","orson","forde","franz","saleh","myrrh","morva","innes","dozla","neimi","artur","knoll","elena","fiona","greil","largo","laura","lethe","lucia","nasir","nolan","oscar","soren","sothe","volke",
            "volug","aimee","alder","bryce","izuka","jarod","jorge","chrom","robin","grima","henry","lonqu","owain","inigo","priam","lissa","gaius","vaike","noire","stahl","libra","panne","sumia","sayri","yarne","sully","brady","phila","azura","ryoma",
            "dwyer","elise","niles","shura","jakob","benny","reina","effie","oboro","saizo","flora","arete","silas","izana","kaden","shiro","azama","asugi","garon","percy","layla","alois","cyril","dedue","hubie","felix","flayn","annie","petra","aegir",
            "nader","solon","maiko","touma","kiria","ellie","barry","ayaha","rowan","fjorm","bruno","surtr","peony","dance","sword","ninja","astra","anima","earth","water","light","badge","beast","beorc","boots","staff","stave","tomes","mages","exalt",
            "dromi","grail","laguz","magic","aegis","stone","tonic","lunar","solar","brace","blade","steel","thief","torch","trait","witch","devil","angel","venin","knife","glass","ladle","blaze","brass","paper","broom","ember","brave","wodao","shine",
            "heavy","speed","katti","stick","sleep","flame","guard","levin","brand","spear","indra","death","purge","swarm","waste","quake","charm","talon","assal","agnea","hades","saint","urvan","skadi","royal","bragi","amiti","noble","skuld","vouge",
            "thogn","thani","sylgr","ninis","wrath","adept","steal","nihil","canto","trace","smite","shove","nudge","shade","daunt","flare","imbue","glare","mercy","galdr","ignis","avoid","focus","unity","salve","curse","crest","rally","skill","melee",
            "zofia","rigel","gjoll","sable","grado","rogue","kunai","panic","flash","thokk","arrow","order","chaos","hrist","alfar","surge","bunny","bride","pivot","dream","armor","catch","ideal","bonus","sacae","ostia","lycia","flier","horse","repel",
            "spurn","eagle","yngvi","drive","valor","pulse","smoke","golem","druid","heron","nomad","pupil","queen","altea","cheve","daein","dagda","darna","dolhr","dozel","elibe","embla","evans","ferox","fiana","grust","novis","opera","plain","ruins",
            "tahra","talys","tower","valla"
        };

        IEnumerable<string> possibleAnswers;

        public WordList()
        {
            possibleAnswers = answers;
        }

        public void AnswerHasLetterNotOnPosition(char letter, int pos)
        {            
            possibleAnswers = possibleAnswers.Where(word => word.Contains(letter) && word[pos] != letter);           
        }

        public void AnswerHasLetterOnPosition(char letter, int pos)
        {
            possibleAnswers = possibleAnswers.Where(word => word[pos] == letter);
        }

        public void AnswerDoesNotHaveLetter(char letter)
        {
            possibleAnswers = possibleAnswers.Where(word => !word.Contains(letter));
        }

        public void ReinitializeWordList()
        {
            possibleAnswers = answers;
        }

        public IEnumerable<string> GetPossibleAnswers()
        {
            return possibleAnswers;
        }

       


    }
}
