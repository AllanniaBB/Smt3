using Il2Cpp;
using Il2Cppresult2_H;
using MelonLoader;
using static Il2Cpp.SteamDlcFileUtil;

[assembly: MelonInfo(typeof(PixeJive.Core), "PixeJive", "1.0.0", "Allannia", null)]
[assembly: MelonGame("アトラス", "smt3hd")]

namespace PixeJive
{
    public class Core : MelonPlugin
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
            tblSkill.fclSkillTbl[61].Event[7] = new fclSkillParam_t { Param = 421, TargetLevel = 0, Type = 1 }; // Jive Talk
        }
    }
}



