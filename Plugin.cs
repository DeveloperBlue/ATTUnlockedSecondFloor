using BepInEx;
using BepInEx.Logging;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ATTUnlockedSecondFloor;

[BepInPlugin("com.michaelrooplall.mods.attunlockedsecondfloor", "Unlocked Second Floor", "1.0.0")]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
        
    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    private void OnDestroy() {
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name == "Playtest") {
            Invoke("build", 2f);
        }
    }

    private void build() {
        try {
            this.unlockSecondFloor();
        } catch (System.Exception e) {
            Logger.LogError(e);
        }

    }

    private void unlockSecondFloor() {

        GameObject stairs_r = GameObject.Find("Tavern/Interactive/Zones/Opening Soon Stairs R");
        GameObject stairs_l = GameObject.Find("Tavern/Interactive/Zones/Opening Soon Stairs L");
        GameObject walls = GameObject.Find("Tavern/Interactive/Zones/Invisible Walls 2 Floor");
        GameObject invisibleDivider = GameObject.Find("Tavern/Interactive/Zones/Opening Soon Main/Top Wall");
        
        stairs_r.SetActive(false);
        stairs_l.SetActive(false);
        walls.SetActive(false);
        invisibleDivider.SetActive(false);

    }
}
