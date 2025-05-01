using ExpPlugin;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;

[HarmonyPatch]
public class MailHelperServerPatch
{
    [HarmonyPatch(typeof(MailHelperServer), "CheckMailActions")]
    class CheckMailActionsPatch
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Ldc_I4)
                {
                    if ((int)instruction.operand == 200)
                        instruction.operand = Plugin.playerExp.Value;
                    else if ((int)instruction.operand == 25)
                        instruction.operand = Plugin.guildExp.Value;
                }
                yield return instruction;
            }
        }
    }
}