using BepInEx;
using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace ModTemp
{
	[BepInPlugin(modId, modName, modVer)]
	public class Mod : BaseUnityPlugin
	{
		// This is your mod's main class (duh)

		public const string modId = "com.yourname.mod";
		public const string modName = "Mod name";
		public const string modVer = "1.0.0";

		void Start()
		{
			new Harmony(modId).PatchAll(Assembly.GetExecutingAssembly());
		}

		void Update()
		{

		}
	}

	[HarmonyPatch]
	public class Patches
    {
		//Both of these HarmonyPatches are just examples and WILL cause errors upon starting your game.

        [HarmonyPatch(typeof(Object), "MethodName")]
        [HarmonyPrefix]
        public static bool Prefix_MethodName()
        {
			Debug.Log("MethodName has been called!");
            return false; // Setting this boolean to false prevents the hooked method from running. Your code here will execute either way.
        }

        [HarmonyPatch(typeof(Object), "MethodName2")]
        [HarmonyPrefix]
        public static void Prefix_MethodName2()
        {
            Debug.Log("MethodName2 has been called!");
            // When using a void for your method, it will always allow the hooked method to run, while executing your code.
        }
    }
}
