using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

using HarmonyLib;

using TabulaRasa;
using System.IO;
using System.Reflection;

namespace Outland
{
    public class OutlandMod : Mod
    {
        public static OutlandMod mod;
        public static OutlandSettings settings;

        public Vector2 optionsScrollPosition;
        public float optionsViewRectHeight;

        internal static string VersionDir => Path.Combine(mod.Content.ModMetaData.RootDir.FullName, "Version.txt");
        public static string CurrentVersion { get; private set; }

        public OutlandMod(ModContentPack content) : base(content)
        {
            mod = this;
            settings = GetSettings<OutlandSettings>();

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            CurrentVersion = $"{version.Major}.{version.Minor}.{version.Build}";

            LogUtil.LogMessage($"{CurrentVersion} ::");

            if (Prefs.DevMode)
            {
                File.WriteAllText(VersionDir, CurrentVersion);
            }

            new Harmony("Neronix17.Outland.Core").PatchAll();
        }

        public override string SettingsCategory() => "Outland - Core";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            bool flag = optionsViewRectHeight > inRect.height;
            Rect viewRect = new Rect(inRect.x, inRect.y, inRect.width - (flag ? 26f : 0f), optionsViewRectHeight);
            Widgets.BeginScrollView(inRect, ref optionsScrollPosition, viewRect);
            Listing_Standard listing = new Listing_Standard();
            Rect rect = new Rect(viewRect.x, viewRect.y, viewRect.width, 999999f);
            listing.Begin(rect);
            // ============================ CONTENTS ================================
            DoOptionsCategoryContents(listing);
            // ======================================================================
            optionsViewRectHeight = listing.CurHeight;
            listing.End();
            Widgets.EndScrollView();
        }

        public void DoOptionsCategoryContents(Listing_Standard listing)
        {
            listing.Note("Some settings may require a game restart to take effect.", GameFont.Tiny);
            listing.GapLine();
            //listing.Label("Kalocite");
            //listing.GapLine();
            //listing.CheckboxEnhanced("Glowing Kalocite", "Adds a glow to Kalocite if enabled. Disabled by default as high numbers of glowers can cause performance issues for some.", ref settings.kalociteGlow);
            //listing.CheckboxEnhanced("Natural Kalocite", "Controls whether or not Kalocite spawns naturally through biomes.", ref settings.kalociteSpawnsNaturally);
            //if (settings.kalociteSpawnsNaturally)
            //{
            //    listing.AddLabeledSlider("Kalocite Spawn Multiplier: " + settings.kalociteCommonality.ToStringPercent(), ref settings.kalociteCommonality, 0f, 2f, "Min: 0%", "Max: 200%", 0.01f);
            //}
            //if (ModLister.BiotechInstalled)
            //{
            //    listing.CheckboxEnhanced("Polluting Toxocite", "Toxocite spawns in pollution instead of Kalocite, if this option is enabled it will slowly spread pollution within a moderate radius around it too.", ref settings.toxociteSpread);
            //}
            //listing.GapLine();
            listing.Label("Bones");
            listing.GapLine();
            listing.AddLabeledSlider("Harvest Multiplier: " + settings.boneFactor.ToStringPercent(), ref settings.boneFactor, 0f, 2f, "Min: 0%", "Max: 200%", 0.01f);
            listing.GapLine();
            //if(Util_Classes.AnyAlchemicalClasses)
            //{
            //    listing.Label("Alchemical");
            //    listing.GapLine();
            //    listing.AddLabeledSlider("Storage base: " + settings.alchemical_capacityBase.ToString(), ref settings.alchemical_capacityBase, 0f, 1000f, "Min:  0", "Max: 1000", 25f);
            //    listing.AddLabeledSlider("Storage per Level: " +  settings.alchemical_capacityPerLevel.ToString(), ref settings.alchemical_capacityPerLevel, 0f, 200f, "Min:  0", "Max: 200", 1f);
            //    listing.AddLabeledSlider("Skill Points per Level: " + settings.alchemical_pointsPerLevel.ToString(), ref settings.alchemical_pointsPerLevel, 0f, 20f, "Min:  0", "Max: 20", 1f);
            //    listing.AddLabeledSlider("Exp multiplier: " + settings.alchemical_expMulti.ToStringPercent(), ref settings.alchemical_expMulti, 0.05f, 10f, "Min:  5%", "Max: 1000%", 0.05f);
            //}
            //if (Util_Classes.AnyArcaneClasses)
            //{
            //    listing.Label("Arcane");
            //    listing.GapLine();
            //    listing.AddLabeledSlider("Mana base: " + settings.arcane_capacityBase.ToString(), ref settings.arcane_capacityBase, 0f, 1000f, "Min:  0", "Max: 1000", 25f);
            //    listing.AddLabeledSlider("Mana per Level: " + settings.arcane_capacityPerLevel.ToString(), ref settings.arcane_capacityPerLevel, 0f, 200f, "Min:  0", "Max: 200", 1f);
            //    listing.AddLabeledSlider("Regen base: " + settings.arcane_regenBase.ToStringPercent(), ref settings.arcane_regenBase, 0f, 20f, "Min:  0%", "Max: 2000%", 0.01f);
            //    listing.AddLabeledSlider("Regen per Level: " + settings.arcane_regenPerLevel.ToStringPercent(), ref settings.arcane_regenPerLevel, 0f, 4f, "Min:  0%", "Max: 400%", 0.01f);
            //    listing.AddLabeledSlider("Skill Points per Level: " + settings.arcane_pointsPerLevel.ToString(), ref settings.arcane_pointsPerLevel, 0f, 20f, "Min:  0", "Max: 20", 1f);
            //    listing.AddLabeledSlider("Exp multiplier: " + settings.arcane_expMulti.ToStringPercent(), ref settings.arcane_expMulti, 0.05f, 10f, "Min:  5%", "Max: 1000%", 0.05f);
            //}
            //if (Util_Classes.AnyMartialClasses)
            //{
            //    listing.Label("Martial");
            //    listing.GapLine();
            //    listing.AddLabeledSlider("Stamina base: " + settings.martial_capacityBase.ToString(), ref settings.martial_capacityBase, 0f, 1000f, "Min:  0", "Max: 1000", 25f);
            //    listing.AddLabeledSlider("Stamina per Level: " + settings.martial_capacityPerLevel.ToString(), ref settings.martial_capacityPerLevel, 0f, 200f, "Min:  0", "Max: 200", 1f);
            //    listing.AddLabeledSlider("Regen base: " + settings.martial_regenBase.ToStringPercent(), ref settings.martial_regenBase, 0f, 20f, "Min:  0%", "Max: 2000%", 0.01f);
            //    listing.AddLabeledSlider("Regen per Level: " + settings.martial_regenPerLevel.ToStringPercent(), ref settings.martial_regenPerLevel, 0f, 4f, "Min:  0%", "Max: 400%", 0.01f);
            //    listing.AddLabeledSlider("Skill Points per Level: " + settings.martial_pointsPerLevel.ToString(), ref settings.martial_pointsPerLevel, 0f, 20f, "Min:  0", "Max: 20", 1f);
            //    listing.AddLabeledSlider("Exp multiplier: " + settings.martial_expMulti.ToStringPercent(), ref settings.martial_expMulti, 0.05f, 10f, "Min:  5%", "Max: 1000%", 0.05f);
            //}
        }
    }
}
