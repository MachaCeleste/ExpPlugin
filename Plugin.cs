using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace ExpPlugin;

[BepInPlugin("com.machaceleste.expplugin", MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;

    public static ConfigEntry<int> playerExp;
    public static ConfigEntry<int> guildExp;

    private void Awake()
    {
        playerExp = Config.Bind("Main", "Player EXP", 200, new ConfigDescription("", new AcceptableValueRange<int>(1, 1000)));
        guildExp = Config.Bind("Main", "Guild EXP", 25, new ConfigDescription("", new AcceptableValueRange<int>(1, 1000)));

        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        var harmony = new Harmony("com.machaceleste.expplugin");
        harmony.PatchAll();
    }
}