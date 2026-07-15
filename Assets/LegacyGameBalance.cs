using System;
using System.Collections.Generic;
using UnityEngine;

namespace DemonKingVSRamboFrog.Config
{
    /// <summary>
    /// DEPRECATED: Legacy game balance constants.
    /// Replaced by GameConfigData.cs with full database approach.
    /// </summary>
    [Obsolete("Use GameConfigData instead")]
    public static class LegacyGameBalance
    {
        // Old hardcoded enemy stats
        public const float SLIME_HP = 50f;
        public const float SLIME_DMG = 8f;
        public const float SLIME_SPEED = 2.0f;
        public const float GOBLIN_HP = 75f;
        public const float GOBLIN_DMG = 12f;
        public const float GOBLIN_SPEED = 2.5f;
        public const float SKELETON_HP = 60f;
        public const float SKELETON_DMG = 15f;
        public const float SKELETON_SPEED = 1.8f;
        public const float ZOMBIE_HP = 100f;
        public const float ZOMBIE_DMG = 10f;
        public const float ZOMBIE_SPEED = 1.2f;
        public const float GHOST_HP = 40f;
        public const float GHOST_DMG = 20f;
        public const float GHOST_SPEED = 3.0f;
        public const float DEMON_HP = 200f;
        public const float DEMON_DMG = 30f;
        public const float DEMON_SPEED = 2.2f;
        public const float DRAGON_HP = 500f;
        public const float DRAGON_DMG = 50f;
        public const float DRAGON_SPEED = 1.5f;

        // Old level reward tables
        public const int LEVEL1_GOLD = 50;
        public const int LEVEL2_GOLD = 75;
        public const int LEVEL3_GOLD = 100;
        public const int LEVEL4_GOLD = 150;
        public const int LEVEL5_GOLD = 200;
        public const int LEVEL6_GOLD = 275;
        public const int LEVEL7_GOLD = 350;
        public const int LEVEL8_GOLD = 450;
        public const int LEVEL9_GOLD = 550;
        public const int LEVEL10_GOLD = 700;

        // Old weapon damage values
        public const float SWORD_BASE_DMG = 25f;
        public const float SWORD_CRIT_MULT = 1.5f;
        public const float BOW_BASE_DMG = 18f;
        public const float BOW_CRIT_MULT = 2.0f;
        public const float STAFF_BASE_DMG = 30f;
        public const float STAFF_CRIT_MULT = 1.8f;
        public const float DAGGER_BASE_DMG = 15f;
        public const float DAGGER_CRIT_MULT = 2.5f;
        public const float AXE_BASE_DMG = 35f;
        public const float AXE_CRIT_MULT = 1.3f;

        // Old potion values
        public const float HEALTH_POTION_SMALL = 25f;
        public const float HEALTH_POTION_MEDIUM = 50f;
        public const float HEALTH_POTION_LARGE = 100f;
        public const float MANA_POTION_SMALL = 20f;
        public const float MANA_POTION_MEDIUM = 40f;
        public const float MANA_POTION_LARGE = 80f;
        public const float SPEED_POTION_DURATION = 10f;
        public const float SPEED_POTION_MULTIPLIER = 1.5f;
        public const float SHIELD_POTION_DURATION = 8f;
        public const float SHIELD_POTION_ABSORB = 50f;

        // Old XP curve
        public static int GetXpForLevel(int level)
        {
            return level * level * 100 + level * 50;
        }

        // Old spawn rate calculation
        public static float GetSpawnInterval(int wave)
        {
            return Mathf.Max(0.5f, 3.0f - wave * 0.2f);
        }

        // Old difficulty scaling
        public static float GetDifficultyMultiplier(int level)
        {
            return 1.0f + (level - 1) * 0.15f;
        }

        // Old drop rate constants
        public const float DROP_RATE_COMMON = 0.60f;
        public const float DROP_RATE_UNCOMMON = 0.25f;
        public const float DROP_RATE_RARE = 0.10f;
        public const float DROP_RATE_EPIC = 0.04f;
        public const float DROP_RATE_LEGENDARY = 0.01f;

        // Old armor values
        public const float LEATHER_ARMOR_DEF = 10f;
        public const float CHAIN_ARMOR_DEF = 20f;
