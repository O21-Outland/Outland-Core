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
            listing.Label("Bones");
            listing.GapLine();
            listing.AddLabeledSlider("Harvest Multiplier: " + settings.boneFactor.ToStringPercent(), ref settings.boneFactor, 0f, 2f, "Min: 0%", "Max: 200%", 0.01f);
            listing.GapLine();
            listing.Label("Crafting");
            listing.GapLine();
            listing.CheckboxEnhanced("Add Smithy recipes to Forge", "If enabled, adds all recipes from the vanilla Smithing bench to the Outland Forge.", ref settings.smithyToForge);
        }
    }
}
