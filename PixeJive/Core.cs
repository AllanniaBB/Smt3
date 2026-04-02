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
            // fclSkillTbl = 61 -> Pixie
            // fclSkillTbl[61].Event -> Skill slot
            // 0 = Dia (starting skill)
            // 1 = Zio (starting skill)
            // 2 = Seduce (Level 3)
            // 3 = Rakunda (Level 4)
            // 4 = trigger to show the “Pixie’s body is showing signs of change” text (Level 4)
            // 5 = Posumudi (Level 5)
            // 6 = Storm Gale (Level 6)
            // 7 -> add new skills here
            // Param = 461 -> Jive Talk
            // TargetLevel = 0 -> Lv 0 = Start with skill
            tblSkill.fclSkillTbl[61].Event[7] = new fclSkillParam_t { Param = 421, TargetLevel = 0, Type = 1 };
        }
    }
}



