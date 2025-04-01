using BepInEx;
using BrutalAPI;
using System;

namespace ZeitgeistsHaveParental
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public const string GUID = "SpecialAPI.ZeitgeistsHaveParentalMod";
        public const string NAME = "Zeitgeists have Parental Mod";
        public const string VERSION = "1.0.0";

        public void Start()
        {
            var zeitgeist = LoadedAssetsHandler.GetEnemy("Zeitgeist_EN");

            if (zeitgeist == null || zeitgeist.abilities == null || zeitgeist.abilities.Count <= 0)
                return;

            var babyShower = zeitgeist.abilities[0];
            zeitgeist.abilities.RemoveAt(0);

            zeitgeist.passiveAbilities.Add(Passives.ParentalGenerator(new()
            {
                ability = babyShower.ability,
                cost = [Pigments.Red, Pigments.Blue, Pigments.Red, Pigments.Blue],
                rarity = babyShower.rarity,
            }));
        }
    }
}
