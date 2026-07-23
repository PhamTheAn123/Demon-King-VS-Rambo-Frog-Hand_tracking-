using System;
using System.Collections.Generic;
using UnityEngine;

namespace DemonKingVSRamboFrog.Config
{
    /// <summary>
    /// Auto-generated game configuration data containing level definitions,
    /// enemy spawn tables, item databases, and balancing parameters.
    /// </summary>
    public static class GameConfigData
    {
        #region Level Definitions

        /// <summary>Level configuration entries indexed by level ID.</summary>
        public static readonly Dictionary<int, LevelConfig> Levels = new Dictionary<int, LevelConfig>
        {
            // Level 1 - Wave Configuration
            {
                1,
                new LevelConfig
                {
                    LevelId = 1,
                    DisplayName = "Level 1",
                    BaseEnemyHealth = 115f,
                    BaseEnemyDamage = 12f,
                    EnemySpeedMultiplier = 1.05f,
                    GoldReward = 75,
                    ExperienceReward = 150,
                    MaxWaves = 3,
                }
            },
            // Level 2 - Wave Configuration
            {
                2,
                new LevelConfig
                {
                    LevelId = 2,
                    DisplayName = "Level 2",
                    BaseEnemyHealth = 130f,
                    BaseEnemyDamage = 14f,
                    EnemySpeedMultiplier = 1.1f,
                    GoldReward = 100,
                    ExperienceReward = 200,
                    MaxWaves = 3,
                }
            },
            // Level 3 - Wave Configuration
            {
                3,
                new LevelConfig
                {
                    LevelId = 3,
                    DisplayName = "Level 3",
                    BaseEnemyHealth = 145f,
                    BaseEnemyDamage = 16f,
                    EnemySpeedMultiplier = 1.15f,
                    GoldReward = 125,
                    ExperienceReward = 250,
                    MaxWaves = 3,
                }
            },
            // Level 4 - Wave Configuration
            {
                4,
                new LevelConfig
                {
                    LevelId = 4,
                    DisplayName = "Level 4",
                    BaseEnemyHealth = 160f,
                    BaseEnemyDamage = 18f,
                    EnemySpeedMultiplier = 1.2f,
                    GoldReward = 150,
                    ExperienceReward = 300,
                    MaxWaves = 3,
                }
            },
            // Level 5 - Wave Configuration
            {
                5,
                new LevelConfig
                {
                    LevelId = 5,
                    DisplayName = "Level 5",
                    BaseEnemyHealth = 175f,
                    BaseEnemyDamage = 20f,
                    EnemySpeedMultiplier = 1.25f,
                    GoldReward = 175,
                    ExperienceReward = 350,
                    MaxWaves = 3,
                }
            },
            // Level 6 - Wave Configuration
            {
                6,
                new LevelConfig
                {
                    LevelId = 6,
                    DisplayName = "Level 6",
                    BaseEnemyHealth = 190f,
                    BaseEnemyDamage = 22f,
                    EnemySpeedMultiplier = 1.3f,
                    GoldReward = 200,
                    ExperienceReward = 400,
                    MaxWaves = 3,
                }
            },
            // Level 7 - Wave Configuration
            {
                7,
                new LevelConfig
                {
                    LevelId = 7,
                    DisplayName = "Level 7",
                    BaseEnemyHealth = 205f,
                    BaseEnemyDamage = 24f,
                    EnemySpeedMultiplier = 1.35f,
                    GoldReward = 225,
                    ExperienceReward = 450,
                    MaxWaves = 3,
                }
            },
            // Level 8 - Wave Configuration
            {
                8,
                new LevelConfig
                {
                    LevelId = 8,
                    DisplayName = "Level 8",
                    BaseEnemyHealth = 220f,
                    BaseEnemyDamage = 26f,
                    EnemySpeedMultiplier = 1.4f,
                    GoldReward = 250,
                    ExperienceReward = 500,
                    MaxWaves = 3,
                }
            },
            // Level 9 - Wave Configuration
            {
                9,
                new LevelConfig
                {
                    LevelId = 9,
                    DisplayName = "Level 9",
                    BaseEnemyHealth = 235f,
                    BaseEnemyDamage = 28f,
                    EnemySpeedMultiplier = 1.45f,
                    GoldReward = 275,
                    ExperienceReward = 550,
                    MaxWaves = 3,
                }
            },
            // Level 10 - Wave Configuration
            {
                10,
                new LevelConfig
                {
                    LevelId = 10,
                    DisplayName = "Level 10",
                    BaseEnemyHealth = 250f,
                    BaseEnemyDamage = 30f,
                    EnemySpeedMultiplier = 1.5f,
                    GoldReward = 300,
                    ExperienceReward = 600,
                    MaxWaves = 4,
                }
            },
            // Level 11 - Wave Configuration
            {
                11,
                new LevelConfig
                {
                    LevelId = 11,
                    DisplayName = "Level 11",
                    BaseEnemyHealth = 265f,
                    BaseEnemyDamage = 32f,
                    EnemySpeedMultiplier = 1.55f,
                    GoldReward = 325,
                    ExperienceReward = 650,
                    MaxWaves = 4,
                }
            },
            // Level 12 - Wave Configuration
            {
                12,
                new LevelConfig
                {
                    LevelId = 12,
                    DisplayName = "Level 12",
                    BaseEnemyHealth = 280f,
                    BaseEnemyDamage = 34f,
                    EnemySpeedMultiplier = 1.6f,
                    GoldReward = 350,
                    ExperienceReward = 700,
                    MaxWaves = 4,
                }
            },
            // Level 13 - Wave Configuration
            {
                13,
                new LevelConfig
                {
                    LevelId = 13,
                    DisplayName = "Level 13",
                    BaseEnemyHealth = 295f,
                    BaseEnemyDamage = 36f,
                    EnemySpeedMultiplier = 1.65f,
                    GoldReward = 375,
                    ExperienceReward = 750,
                    MaxWaves = 4,
                }
            },
            // Level 14 - Wave Configuration
            {
                14,
                new LevelConfig
                {
                    LevelId = 14,
                    DisplayName = "Level 14",
                    BaseEnemyHealth = 310f,
                    BaseEnemyDamage = 38f,
                    EnemySpeedMultiplier = 1.7f,
                    GoldReward = 400,
                    ExperienceReward = 800,
                    MaxWaves = 4,
                }
            },
            // Level 15 - Wave Configuration
            {
                15,
                new LevelConfig
                {
                    LevelId = 15,
                    DisplayName = "Level 15",
                    BaseEnemyHealth = 325f,
                    BaseEnemyDamage = 40f,
                    EnemySpeedMultiplier = 1.75f,
                    GoldReward = 425,
                    ExperienceReward = 850,
                    MaxWaves = 4,
                }
            },
            // Level 16 - Wave Configuration
            {
                16,
                new LevelConfig
                {
                    LevelId = 16,
                    DisplayName = "Level 16",
                    BaseEnemyHealth = 340f,
                    BaseEnemyDamage = 42f,
                    EnemySpeedMultiplier = 1.8f,
                    GoldReward = 450,
                    ExperienceReward = 900,
                    MaxWaves = 4,
                }
            },
            // Level 17 - Wave Configuration
            {
                17,
                new LevelConfig
                {
                    LevelId = 17,
                    DisplayName = "Level 17",
                    BaseEnemyHealth = 355f,
                    BaseEnemyDamage = 44f,
                    EnemySpeedMultiplier = 1.85f,
                    GoldReward = 475,
                    ExperienceReward = 950,
                    MaxWaves = 4,
                }
            },
            // Level 18 - Wave Configuration
            {
                18,
                new LevelConfig
                {
                    LevelId = 18,
                    DisplayName = "Level 18",
                    BaseEnemyHealth = 370f,
                    BaseEnemyDamage = 46f,
                    EnemySpeedMultiplier = 1.9f,
                    GoldReward = 500,
                    ExperienceReward = 1000,
                    MaxWaves = 4,
                }
            },
            // Level 19 - Wave Configuration
            {
                19,
                new LevelConfig
                {
                    LevelId = 19,
                    DisplayName = "Level 19",
                    BaseEnemyHealth = 385f,
                    BaseEnemyDamage = 48f,
                    EnemySpeedMultiplier = 1.95f,
                    GoldReward = 525,
                    ExperienceReward = 1050,
                    MaxWaves = 4,
                }
            },
            // Level 20 - Wave Configuration
            {
                20,
                new LevelConfig
                {
                    LevelId = 20,
                    DisplayName = "Level 20",
                    BaseEnemyHealth = 400f,
                    BaseEnemyDamage = 50f,
                    EnemySpeedMultiplier = 2f,
                    GoldReward = 550,
                    ExperienceReward = 1100,
                    MaxWaves = 5,
                }
            },
            // Level 21 - Wave Configuration
            {
                21,
                new LevelConfig
                {
                    LevelId = 21,
                    DisplayName = "Level 21",
                    BaseEnemyHealth = 415f,
                    BaseEnemyDamage = 52f,
                    EnemySpeedMultiplier = 2.05f,
                    GoldReward = 575,
                    ExperienceReward = 1150,
                    MaxWaves = 5,
                }
            },
            // Level 22 - Wave Configuration
            {
                22,
                new LevelConfig
                {
                    LevelId = 22,
                    DisplayName = "Level 22",
                    BaseEnemyHealth = 430f,
                    BaseEnemyDamage = 54f,
                    EnemySpeedMultiplier = 2.1f,
                    GoldReward = 600,
                    ExperienceReward = 1200,
                    MaxWaves = 5,
                }
            },
            // Level 23 - Wave Configuration
            {
                23,
                new LevelConfig
                {
                    LevelId = 23,
                    DisplayName = "Level 23",
                    BaseEnemyHealth = 445f,
                    BaseEnemyDamage = 56f,
                    EnemySpeedMultiplier = 2.15f,
                    GoldReward = 625,
                    ExperienceReward = 1250,
                    MaxWaves = 5,
                }
            },
            // Level 24 - Wave Configuration
            {
                24,
                new LevelConfig
                {
                    LevelId = 24,
                    DisplayName = "Level 24",
                    BaseEnemyHealth = 460f,
                    BaseEnemyDamage = 58f,
                    EnemySpeedMultiplier = 2.2f,
                    GoldReward = 650,
                    ExperienceReward = 1300,
                    MaxWaves = 5,
                }
            },
            // Level 25 - Wave Configuration
            {
                25,
                new LevelConfig
                {
                    LevelId = 25,
                    DisplayName = "Level 25",
                    BaseEnemyHealth = 475f,
                    BaseEnemyDamage = 60f,
                    EnemySpeedMultiplier = 2.25f,
                    GoldReward = 675,
                    ExperienceReward = 1350,
                    MaxWaves = 5,
                }
            },
            // Level 26 - Wave Configuration
            {
                26,
                new LevelConfig
                {
                    LevelId = 26,
                    DisplayName = "Level 26",
                    BaseEnemyHealth = 490f,
                    BaseEnemyDamage = 62f,
                    EnemySpeedMultiplier = 2.3f,
                    GoldReward = 700,
                    ExperienceReward = 1400,
                    MaxWaves = 5,
                }
            },
            // Level 27 - Wave Configuration
            {
                27,
                new LevelConfig
                {
                    LevelId = 27,
                    DisplayName = "Level 27",
                    BaseEnemyHealth = 505f,
                    BaseEnemyDamage = 64f,
                    EnemySpeedMultiplier = 2.35f,
                    GoldReward = 725,
                    ExperienceReward = 1450,
                    MaxWaves = 5,
                }
            },
            // Level 28 - Wave Configuration
            {
                28,
                new LevelConfig
                {
                    LevelId = 28,
                    DisplayName = "Level 28",
                    BaseEnemyHealth = 520f,
                    BaseEnemyDamage = 66f,
                    EnemySpeedMultiplier = 2.4f,
                    GoldReward = 750,
                    ExperienceReward = 1500,
                    MaxWaves = 5,
                }
            },
            // Level 29 - Wave Configuration
            {
                29,
                new LevelConfig
                {
                    LevelId = 29,
                    DisplayName = "Level 29",
                    BaseEnemyHealth = 535f,
                    BaseEnemyDamage = 68f,
                    EnemySpeedMultiplier = 2.45f,
                    GoldReward = 775,
                    ExperienceReward = 1550,
                    MaxWaves = 5,
                }
            },
            // Level 30 - Wave Configuration
            {
                30,
                new LevelConfig
                {
                    LevelId = 30,
                    DisplayName = "Level 30",
                    BaseEnemyHealth = 550f,
                    BaseEnemyDamage = 70f,
                    EnemySpeedMultiplier = 2.5f,
                    GoldReward = 800,
                    ExperienceReward = 1600,
                    MaxWaves = 6,
                }
            },
            // Level 31 - Wave Configuration
            {
                31,
                new LevelConfig
                {
                    LevelId = 31,
                    DisplayName = "Level 31",
                    BaseEnemyHealth = 565f,
                    BaseEnemyDamage = 72f,
                    EnemySpeedMultiplier = 2.55f,
                    GoldReward = 825,
                    ExperienceReward = 1650,
                    MaxWaves = 6,
                }
            },
            // Level 32 - Wave Configuration
            {
                32,
                new LevelConfig
                {
                    LevelId = 32,
                    DisplayName = "Level 32",
                    BaseEnemyHealth = 580f,
                    BaseEnemyDamage = 74f,
                    EnemySpeedMultiplier = 2.6f,
                    GoldReward = 850,
                    ExperienceReward = 1700,
                    MaxWaves = 6,
                }
            },
            // Level 33 - Wave Configuration
            {
                33,
                new LevelConfig
                {
                    LevelId = 33,
                    DisplayName = "Level 33",
                    BaseEnemyHealth = 595f,
                    BaseEnemyDamage = 76f,
                    EnemySpeedMultiplier = 2.65f,
                    GoldReward = 875,
                    ExperienceReward = 1750,
                    MaxWaves = 6,
                }
            },
            // Level 34 - Wave Configuration
            {
                34,
                new LevelConfig
                {
                    LevelId = 34,
                    DisplayName = "Level 34",
                    BaseEnemyHealth = 610f,
                    BaseEnemyDamage = 78f,
                    EnemySpeedMultiplier = 2.7f,
                    GoldReward = 900,
                    ExperienceReward = 1800,
                    MaxWaves = 6,
                }
            },
            // Level 35 - Wave Configuration
            {
                35,
                new LevelConfig
                {
                    LevelId = 35,
                    DisplayName = "Level 35",
                    BaseEnemyHealth = 625f,
                    BaseEnemyDamage = 80f,
                    EnemySpeedMultiplier = 2.75f,
                    GoldReward = 925,
                    ExperienceReward = 1850,
                    MaxWaves = 6,
                }
            },
            // Level 36 - Wave Configuration
            {
                36,
                new LevelConfig
                {
                    LevelId = 36,
                    DisplayName = "Level 36",
                    BaseEnemyHealth = 640f,
                    BaseEnemyDamage = 82f,
                    EnemySpeedMultiplier = 2.8f,
                    GoldReward = 950,
                    ExperienceReward = 1900,
                    MaxWaves = 6,
                }
            },
            // Level 37 - Wave Configuration
            {
                37,
                new LevelConfig
                {
                    LevelId = 37,
                    DisplayName = "Level 37",
                    BaseEnemyHealth = 655f,
                    BaseEnemyDamage = 84f,
                    EnemySpeedMultiplier = 2.85f,
                    GoldReward = 975,
                    ExperienceReward = 1950,
                    MaxWaves = 6,
                }
            },
            // Level 38 - Wave Configuration
            {
                38,
                new LevelConfig
                {
                    LevelId = 38,
                    DisplayName = "Level 38",
                    BaseEnemyHealth = 670f,
                    BaseEnemyDamage = 86f,
                    EnemySpeedMultiplier = 2.9f,
                    GoldReward = 1000,
                    ExperienceReward = 2000,
                    MaxWaves = 6,
                }
            },
            // Level 39 - Wave Configuration
            {
                39,
                new LevelConfig
                {
                    LevelId = 39,
                    DisplayName = "Level 39",
                    BaseEnemyHealth = 685f,
                    BaseEnemyDamage = 88f,
                    EnemySpeedMultiplier = 2.95f,
                    GoldReward = 1025,
                    ExperienceReward = 2050,
                    MaxWaves = 6,
                }
            },
            // Level 40 - Wave Configuration
            {
                40,
                new LevelConfig
                {
                    LevelId = 40,
                    DisplayName = "Level 40",
                    BaseEnemyHealth = 700f,
                    BaseEnemyDamage = 90f,
                    EnemySpeedMultiplier = 3f,
                    GoldReward = 1050,
                    ExperienceReward = 2100,
                    MaxWaves = 7,
                }
            },
            // Level 41 - Wave Configuration
            {
                41,
                new LevelConfig
                {
                    LevelId = 41,
                    DisplayName = "Level 41",
                    BaseEnemyHealth = 715f,
                    BaseEnemyDamage = 92f,
                    EnemySpeedMultiplier = 3.05f,
                    GoldReward = 1075,
                    ExperienceReward = 2150,
                    MaxWaves = 7,
                }
            },
            // Level 42 - Wave Configuration
            {
                42,
                new LevelConfig
                {
                    LevelId = 42,
                    DisplayName = "Level 42",
                    BaseEnemyHealth = 730f,
                    BaseEnemyDamage = 94f,
                    EnemySpeedMultiplier = 3.1f,
                    GoldReward = 1100,
                    ExperienceReward = 2200,
                    MaxWaves = 7,
                }
            },
            // Level 43 - Wave Configuration
            {
                43,
                new LevelConfig
                {
                    LevelId = 43,
                    DisplayName = "Level 43",
                    BaseEnemyHealth = 745f,
                    BaseEnemyDamage = 96f,
                    EnemySpeedMultiplier = 3.15f,
                    GoldReward = 1125,
                    ExperienceReward = 2250,
                    MaxWaves = 7,
                }
            },
            // Level 44 - Wave Configuration
            {
                44,
                new LevelConfig
                {
                    LevelId = 44,
                    DisplayName = "Level 44",
                    BaseEnemyHealth = 760f,
                    BaseEnemyDamage = 98f,
                    EnemySpeedMultiplier = 3.2f,
                    GoldReward = 1150,
                    ExperienceReward = 2300,
                    MaxWaves = 7,
                }
            },
            // Level 45 - Wave Configuration
            {
                45,
                new LevelConfig
                {
                    LevelId = 45,
                    DisplayName = "Level 45",
                    BaseEnemyHealth = 775f,
                    BaseEnemyDamage = 100f,
                    EnemySpeedMultiplier = 3.25f,
                    GoldReward = 1175,
                    ExperienceReward = 2350,
                    MaxWaves = 7,
                }
            },
            // Level 46 - Wave Configuration
            {
                46,
                new LevelConfig
                {
                    LevelId = 46,
                    DisplayName = "Level 46",
                    BaseEnemyHealth = 790f,
                    BaseEnemyDamage = 102f,
                    EnemySpeedMultiplier = 3.3f,
                    GoldReward = 1200,
                    ExperienceReward = 2400,
                    MaxWaves = 7,
                }
            },
            // Level 47 - Wave Configuration
            {
                47,
                new LevelConfig
                {
                    LevelId = 47,
                    DisplayName = "Level 47",
                    BaseEnemyHealth = 805f,
                    BaseEnemyDamage = 104f,
                    EnemySpeedMultiplier = 3.35f,
                    GoldReward = 1225,
                    ExperienceReward = 2450,
                    MaxWaves = 7,
                }
            },
            // Level 48 - Wave Configuration
            {
                48,
                new LevelConfig
                {
                    LevelId = 48,
                    DisplayName = "Level 48",
                    BaseEnemyHealth = 820f,
                    BaseEnemyDamage = 106f,
                    EnemySpeedMultiplier = 3.4f,
                    GoldReward = 1250,
                    ExperienceReward = 2500,
                    MaxWaves = 7,
                }
            },
            // Level 49 - Wave Configuration
            {
                49,
                new LevelConfig
                {
                    LevelId = 49,
                    DisplayName = "Level 49",
                    BaseEnemyHealth = 835f,
                    BaseEnemyDamage = 108f,
                    EnemySpeedMultiplier = 3.45f,
                    GoldReward = 1275,
                    ExperienceReward = 2550,
                    MaxWaves = 7,
                }
            },
            // Level 50 - Wave Configuration
            {
                50,
                new LevelConfig
                {
                    LevelId = 50,
                    DisplayName = "Level 50",
                    BaseEnemyHealth = 850f,
                    BaseEnemyDamage = 110f,
                    EnemySpeedMultiplier = 3.5f,
                    GoldReward = 1300,
                    ExperienceReward = 2600,
                    MaxWaves = 8,
                }
            },
            // Level 51 - Wave Configuration
            {
                51,
                new LevelConfig
                {
                    LevelId = 51,
                    DisplayName = "Level 51",
                    BaseEnemyHealth = 865f,
                    BaseEnemyDamage = 112f,
                    EnemySpeedMultiplier = 3.55f,
                    GoldReward = 1325,
                    ExperienceReward = 2650,
                    MaxWaves = 8,
                }
            },
            // Level 52 - Wave Configuration
            {
                52,
                new LevelConfig
                {
                    LevelId = 52,
                    DisplayName = "Level 52",
                    BaseEnemyHealth = 880f,
                    BaseEnemyDamage = 114f,
                    EnemySpeedMultiplier = 3.6f,
                    GoldReward = 1350,
                    ExperienceReward = 2700,
                    MaxWaves = 8,
                }
            },
            // Level 53 - Wave Configuration
            {
                53,
                new LevelConfig
                {
                    LevelId = 53,
                    DisplayName = "Level 53",
                    BaseEnemyHealth = 895f,
                    BaseEnemyDamage = 116f,
                    EnemySpeedMultiplier = 3.65f,
                    GoldReward = 1375,
                    ExperienceReward = 2750,
                    MaxWaves = 8,
                }
            },
            // Level 54 - Wave Configuration
            {
                54,
                new LevelConfig
                {
                    LevelId = 54,
                    DisplayName = "Level 54",
                    BaseEnemyHealth = 910f,
                    BaseEnemyDamage = 118f,
                    EnemySpeedMultiplier = 3.7f,
                    GoldReward = 1400,
                    ExperienceReward = 2800,
                    MaxWaves = 8,
                }
            },
            // Level 55 - Wave Configuration
            {
                55,
                new LevelConfig
                {
                    LevelId = 55,
                    DisplayName = "Level 55",
                    BaseEnemyHealth = 925f,
                    BaseEnemyDamage = 120f,
                    EnemySpeedMultiplier = 3.75f,
                    GoldReward = 1425,
                    ExperienceReward = 2850,
                    MaxWaves = 8,
                }
            },
            // Level 56 - Wave Configuration
            {
                56,
                new LevelConfig
                {
                    LevelId = 56,
                    DisplayName = "Level 56",
                    BaseEnemyHealth = 940f,
                    BaseEnemyDamage = 122f,
                    EnemySpeedMultiplier = 3.8f,
                    GoldReward = 1450,
                    ExperienceReward = 2900,
                    MaxWaves = 8,
                }
            },
            // Level 57 - Wave Configuration
            {
                57,
                new LevelConfig
                {
                    LevelId = 57,
                    DisplayName = "Level 57",
                    BaseEnemyHealth = 955f,
                    BaseEnemyDamage = 124f,
                    EnemySpeedMultiplier = 3.85f,
                    GoldReward = 1475,
                    ExperienceReward = 2950,
                    MaxWaves = 8,
                }
            },
            // Level 58 - Wave Configuration
            {
                58,
                new LevelConfig
                {
                    LevelId = 58,
                    DisplayName = "Level 58",
                    BaseEnemyHealth = 970f,
                    BaseEnemyDamage = 126f,
                    EnemySpeedMultiplier = 3.9f,
                    GoldReward = 1500,
                    ExperienceReward = 3000,
                    MaxWaves = 8,
                }
            },
            // Level 59 - Wave Configuration
            {
                59,
                new LevelConfig
                {
                    LevelId = 59,
                    DisplayName = "Level 59",
                    BaseEnemyHealth = 985f,
                    BaseEnemyDamage = 128f,
                    EnemySpeedMultiplier = 3.95f,
                    GoldReward = 1525,
                    ExperienceReward = 3050,
                    MaxWaves = 8,
                }
            },
            // Level 60 - Wave Configuration
            {
                60,
                new LevelConfig
                {
                    LevelId = 60,
                    DisplayName = "Level 60",
                    BaseEnemyHealth = 1000f,
                    BaseEnemyDamage = 130f,
                    EnemySpeedMultiplier = 4f,
                    GoldReward = 1550,
                    ExperienceReward = 3100,
                    MaxWaves = 9,
                }
            },
            // Level 61 - Wave Configuration
            {
                61,
                new LevelConfig
                {
                    LevelId = 61,
                    DisplayName = "Level 61",
                    BaseEnemyHealth = 1015f,
                    BaseEnemyDamage = 132f,
                    EnemySpeedMultiplier = 4.05f,
                    GoldReward = 1575,
                    ExperienceReward = 3150,
                    MaxWaves = 9,
                }
            },
            // Level 62 - Wave Configuration
            {
                62,
                new LevelConfig
                {
                    LevelId = 62,
                    DisplayName = "Level 62",
                    BaseEnemyHealth = 1030f,
                    BaseEnemyDamage = 134f,
                    EnemySpeedMultiplier = 4.1f,
                    GoldReward = 1600,
                    ExperienceReward = 3200,
                    MaxWaves = 9,
                }
            },
            // Level 63 - Wave Configuration
            {
                63,
                new LevelConfig
                {
                    LevelId = 63,
                    DisplayName = "Level 63",
                    BaseEnemyHealth = 1045f,
                    BaseEnemyDamage = 136f,
                    EnemySpeedMultiplier = 4.15f,
                    GoldReward = 1625,
                    ExperienceReward = 3250,
                    MaxWaves = 9,
                }
            },
            // Level 64 - Wave Configuration
            {
                64,
                new LevelConfig
                {
                    LevelId = 64,
                    DisplayName = "Level 64",
                    BaseEnemyHealth = 1060f,
                    BaseEnemyDamage = 138f,
                    EnemySpeedMultiplier = 4.2f,
                    GoldReward = 1650,
                    ExperienceReward = 3300,
                    MaxWaves = 9,
                }
            },
            // Level 65 - Wave Configuration
            {
                65,
                new LevelConfig
                {
                    LevelId = 65,
                    DisplayName = "Level 65",
                    BaseEnemyHealth = 1075f,
                    BaseEnemyDamage = 140f,
                    EnemySpeedMultiplier = 4.25f,
                    GoldReward = 1675,
                    ExperienceReward = 3350,
                    MaxWaves = 9,
                }
            },
            // Level 66 - Wave Configuration
            {
                66,
                new LevelConfig
                {
                    LevelId = 66,
                    DisplayName = "Level 66",
                    BaseEnemyHealth = 1090f,
                    BaseEnemyDamage = 142f,
                    EnemySpeedMultiplier = 4.3f,
                    GoldReward = 1700,
                    ExperienceReward = 3400,
                    MaxWaves = 9,
                }
            },
            // Level 67 - Wave Configuration
            {
                67,
                new LevelConfig
                {
                    LevelId = 67,
                    DisplayName = "Level 67",
                    BaseEnemyHealth = 1105f,
                    BaseEnemyDamage = 144f,
                    EnemySpeedMultiplier = 4.35f,
                    GoldReward = 1725,
                    ExperienceReward = 3450,
                    MaxWaves = 9,
                }
            },
            // Level 68 - Wave Configuration
            {
                68,
                new LevelConfig
                {
                    LevelId = 68,
                    DisplayName = "Level 68",
                    BaseEnemyHealth = 1120f,
                    BaseEnemyDamage = 146f,
                    EnemySpeedMultiplier = 4.4f,
                    GoldReward = 1750,
                    ExperienceReward = 3500,
                    MaxWaves = 9,
                }
            },
            // Level 69 - Wave Configuration
            {
                69,
                new LevelConfig
                {
                    LevelId = 69,
                    DisplayName = "Level 69",
                    BaseEnemyHealth = 1135f,
                    BaseEnemyDamage = 148f,
                    EnemySpeedMultiplier = 4.45f,
                    GoldReward = 1775,
                    ExperienceReward = 3550,
                    MaxWaves = 9,
                }
            },
            // Level 70 - Wave Configuration
            {
                70,
                new LevelConfig
                {
                    LevelId = 70,
                    DisplayName = "Level 70",
                    BaseEnemyHealth = 1150f,
                    BaseEnemyDamage = 150f,
                    EnemySpeedMultiplier = 4.5f,
                    GoldReward = 1800,
                    ExperienceReward = 3600,
                    MaxWaves = 10,
                }
            },
            // Level 71 - Wave Configuration
            {
                71,
                new LevelConfig
                {
                    LevelId = 71,
                    DisplayName = "Level 71",
                    BaseEnemyHealth = 1165f,
                    BaseEnemyDamage = 152f,
                    EnemySpeedMultiplier = 4.55f,
                    GoldReward = 1825,
                    ExperienceReward = 3650,
                    MaxWaves = 10,
                }
            },
            // Level 72 - Wave Configuration
            {
                72,
                new LevelConfig
                {
                    LevelId = 72,
                    DisplayName = "Level 72",
                    BaseEnemyHealth = 1180f,
                    BaseEnemyDamage = 154f,
                    EnemySpeedMultiplier = 4.6f,
                    GoldReward = 1850,
                    ExperienceReward = 3700,
                    MaxWaves = 10,
                }
            },
            // Level 73 - Wave Configuration
            {
                73,
                new LevelConfig
                {
                    LevelId = 73,
                    DisplayName = "Level 73",
                    BaseEnemyHealth = 1195f,
                    BaseEnemyDamage = 156f,
                    EnemySpeedMultiplier = 4.65f,
                    GoldReward = 1875,
                    ExperienceReward = 3750,
                    MaxWaves = 10,
                }
            },
            // Level 74 - Wave Configuration
            {
                74,
                new LevelConfig
                {
                    LevelId = 74,
                    DisplayName = "Level 74",
                    BaseEnemyHealth = 1210f,
                    BaseEnemyDamage = 158f,
                    EnemySpeedMultiplier = 4.7f,
                    GoldReward = 1900,
                    ExperienceReward = 3800,
                    MaxWaves = 10,
                }
            },
            // Level 75 - Wave Configuration
            {
                75,
                new LevelConfig
                {
                    LevelId = 75,
                    DisplayName = "Level 75",
                    BaseEnemyHealth = 1225f,
                    BaseEnemyDamage = 160f,
                    EnemySpeedMultiplier = 4.75f,
                    GoldReward = 1925,
                    ExperienceReward = 3850,
                    MaxWaves = 10,
                }
            },
            // Level 76 - Wave Configuration
            {
                76,
                new LevelConfig
                {
                    LevelId = 76,
                    DisplayName = "Level 76",
                    BaseEnemyHealth = 1240f,
                    BaseEnemyDamage = 162f,
                    EnemySpeedMultiplier = 4.8f,
                    GoldReward = 1950,
                    ExperienceReward = 3900,
                    MaxWaves = 10,
                }
            },
            // Level 77 - Wave Configuration
            {
                77,
                new LevelConfig
                {
                    LevelId = 77,
                    DisplayName = "Level 77",
                    BaseEnemyHealth = 1255f,
                    BaseEnemyDamage = 164f,
                    EnemySpeedMultiplier = 4.85f,
                    GoldReward = 1975,
                    ExperienceReward = 3950,
                    MaxWaves = 10,
                }
            },
            // Level 78 - Wave Configuration
            {
                78,
                new LevelConfig
                {
                    LevelId = 78,
                    DisplayName = "Level 78",
                    BaseEnemyHealth = 1270f,
                    BaseEnemyDamage = 166f,
                    EnemySpeedMultiplier = 4.9f,
                    GoldReward = 2000,
                    ExperienceReward = 4000,
                    MaxWaves = 10,
                }
            },
            // Level 79 - Wave Configuration
            {
                79,
                new LevelConfig
                {
                    LevelId = 79,
                    DisplayName = "Level 79",
                    BaseEnemyHealth = 1285f,
                    BaseEnemyDamage = 168f,
                    EnemySpeedMultiplier = 4.95f,
                    GoldReward = 2025,
                    ExperienceReward = 4050,
                    MaxWaves = 10,
                }
            },
            // Level 80 - Wave Configuration
            {
                80,
                new LevelConfig
                {
                    LevelId = 80,
                    DisplayName = "Level 80",
                    BaseEnemyHealth = 1300f,
                    BaseEnemyDamage = 170f,
                    EnemySpeedMultiplier = 5f,
                    GoldReward = 2050,
                    ExperienceReward = 4100,
                    MaxWaves = 11,
                }
            },
            // Level 81 - Wave Configuration
            {
                81,
                new LevelConfig
                {
                    LevelId = 81,
                    DisplayName = "Level 81",
                    BaseEnemyHealth = 1315f,
                    BaseEnemyDamage = 172f,
                    EnemySpeedMultiplier = 5.05f,
                    GoldReward = 2075,
                    ExperienceReward = 4150,
                    MaxWaves = 11,
                }
            },
            // Level 82 - Wave Configuration
            {
                82,
                new LevelConfig
                {
                    LevelId = 82,
                    DisplayName = "Level 82",
                    BaseEnemyHealth = 1330f,
                    BaseEnemyDamage = 174f,
                    EnemySpeedMultiplier = 5.1f,
                    GoldReward = 2100,
                    ExperienceReward = 4200,
                    MaxWaves = 11,
                }
            },
            // Level 83 - Wave Configuration
            {
                83,
                new LevelConfig
                {
                    LevelId = 83,
                    DisplayName = "Level 83",
                    BaseEnemyHealth = 1345f,
                    BaseEnemyDamage = 176f,
                    EnemySpeedMultiplier = 5.15f,
                    GoldReward = 2125,
                    ExperienceReward = 4250,
                    MaxWaves = 11,
                }
            },
            // Level 84 - Wave Configuration
            {
                84,
                new LevelConfig
                {
                    LevelId = 84,
                    DisplayName = "Level 84",
                    BaseEnemyHealth = 1360f,
                    BaseEnemyDamage = 178f,
                    EnemySpeedMultiplier = 5.2f,
                    GoldReward = 2150,
                    ExperienceReward = 4300,
                    MaxWaves = 11,
                }
            },
            // Level 85 - Wave Configuration
            {
                85,
                new LevelConfig
                {
                    LevelId = 85,
                    DisplayName = "Level 85",
                    BaseEnemyHealth = 1375f,
                    BaseEnemyDamage = 180f,
                    EnemySpeedMultiplier = 5.25f,
                    GoldReward = 2175,
                    ExperienceReward = 4350,
                    MaxWaves = 11,
                }
            },
            // Level 86 - Wave Configuration
            {
                86,
                new LevelConfig
                {
                    LevelId = 86,
                    DisplayName = "Level 86",
                    BaseEnemyHealth = 1390f,
                    BaseEnemyDamage = 182f,
                    EnemySpeedMultiplier = 5.3f,
                    GoldReward = 2200,
                    ExperienceReward = 4400,
                    MaxWaves = 11,
                }
            },
            // Level 87 - Wave Configuration
            {
                87,
                new LevelConfig
                {
                    LevelId = 87,
                    DisplayName = "Level 87",
                    BaseEnemyHealth = 1405f,
                    BaseEnemyDamage = 184f,
                    EnemySpeedMultiplier = 5.35f,
                    GoldReward = 2225,
                    ExperienceReward = 4450,
                    MaxWaves = 11,
                }
            },
            // Level 88 - Wave Configuration
            {
                88,
                new LevelConfig
                {
                    LevelId = 88,
                    DisplayName = "Level 88",
                    BaseEnemyHealth = 1420f,
                    BaseEnemyDamage = 186f,
                    EnemySpeedMultiplier = 5.4f,
                    GoldReward = 2250,
                    ExperienceReward = 4500,
                    MaxWaves = 11,
                }
            },
            // Level 89 - Wave Configuration
            {
                89,
                new LevelConfig
                {
                    LevelId = 89,
                    DisplayName = "Level 89",
                    BaseEnemyHealth = 1435f,
                    BaseEnemyDamage = 188f,
                    EnemySpeedMultiplier = 5.45f,
                    GoldReward = 2275,
                    ExperienceReward = 4550,
                    MaxWaves = 11,
                }
            },
            // Level 90 - Wave Configuration
            {
                90,
                new LevelConfig
                {
                    LevelId = 90,
                    DisplayName = "Level 90",
                    BaseEnemyHealth = 1450f,
                    BaseEnemyDamage = 190f,
                    EnemySpeedMultiplier = 5.5f,
                    GoldReward = 2300,
                    ExperienceReward = 4600,
                    MaxWaves = 12,
                }
            },
            // Level 91 - Wave Configuration
            {
                91,
                new LevelConfig
                {
                    LevelId = 91,
                    DisplayName = "Level 91",
                    BaseEnemyHealth = 1465f,
                    BaseEnemyDamage = 192f,
                    EnemySpeedMultiplier = 5.55f,
                    GoldReward = 2325,
                    ExperienceReward = 4650,
                    MaxWaves = 12,
                }
            },
            // Level 92 - Wave Configuration
            {
                92,
                new LevelConfig
                {
                    LevelId = 92,
                    DisplayName = "Level 92",
                    BaseEnemyHealth = 1480f,
                    BaseEnemyDamage = 194f,
                    EnemySpeedMultiplier = 5.6f,
                    GoldReward = 2350,
                    ExperienceReward = 4700,
                    MaxWaves = 12,
                }
            },
            // Level 93 - Wave Configuration
            {
                93,
                new LevelConfig
                {
                    LevelId = 93,
                    DisplayName = "Level 93",
                    BaseEnemyHealth = 1495f,
                    BaseEnemyDamage = 196f,
                    EnemySpeedMultiplier = 5.65f,
                    GoldReward = 2375,
                    ExperienceReward = 4750,
                    MaxWaves = 12,
                }
            },
            // Level 94 - Wave Configuration
            {
                94,
                new LevelConfig
                {
                    LevelId = 94,
                    DisplayName = "Level 94",
                    BaseEnemyHealth = 1510f,
                    BaseEnemyDamage = 198f,
                    EnemySpeedMultiplier = 5.7f,
                    GoldReward = 2400,
                    ExperienceReward = 4800,
                    MaxWaves = 12,
                }
            },
            // Level 95 - Wave Configuration
            {
                95,
                new LevelConfig
                {
                    LevelId = 95,
                    DisplayName = "Level 95",
                    BaseEnemyHealth = 1525f,
                    BaseEnemyDamage = 200f,
                    EnemySpeedMultiplier = 5.75f,
                    GoldReward = 2425,
                    ExperienceReward = 4850,
                    MaxWaves = 12,
                }
            },
            // Level 96 - Wave Configuration
            {
                96,
                new LevelConfig
                {
                    LevelId = 96,
                    DisplayName = "Level 96",
                    BaseEnemyHealth = 1540f,
                    BaseEnemyDamage = 202f,
                    EnemySpeedMultiplier = 5.8f,
                    GoldReward = 2450,
                    ExperienceReward = 4900,
                    MaxWaves = 12,
                }
            },
            // Level 97 - Wave Configuration
            {
                97,
                new LevelConfig
                {
                    LevelId = 97,
                    DisplayName = "Level 97",
                    BaseEnemyHealth = 1555f,
                    BaseEnemyDamage = 204f,
                    EnemySpeedMultiplier = 5.85f,
                    GoldReward = 2475,
                    ExperienceReward = 4950,
                    MaxWaves = 12,
                }
            },
            // Level 98 - Wave Configuration
            {
                98,
                new LevelConfig
                {
                    LevelId = 98,
                    DisplayName = "Level 98",
                    BaseEnemyHealth = 1570f,
                    BaseEnemyDamage = 206f,
                    EnemySpeedMultiplier = 5.9f,
                    GoldReward = 2500,
                    ExperienceReward = 5000,
                    MaxWaves = 12,
                }
            },
            // Level 99 - Wave Configuration
            {
                99,
                new LevelConfig
                {
                    LevelId = 99,
                    DisplayName = "Level 99",
                    BaseEnemyHealth = 1585f,
                    BaseEnemyDamage = 208f,
                    EnemySpeedMultiplier = 5.95f,
                    GoldReward = 2525,
                    ExperienceReward = 5050,
                    MaxWaves = 12,
                }
            },
            // Level 100 - Wave Configuration
            {
                100,
                new LevelConfig
                {
                    LevelId = 100,
                    DisplayName = "Level 100",
                    BaseEnemyHealth = 1600f,
                    BaseEnemyDamage = 210f,
                    EnemySpeedMultiplier = 6f,
                    GoldReward = 2550,
                    ExperienceReward = 5100,
                    MaxWaves = 13,
                }
            },
            // Level 101 - Wave Configuration
            {
                101,
                new LevelConfig
                {
                    LevelId = 101,
                    DisplayName = "Level 101",
                    BaseEnemyHealth = 1615f,
                    BaseEnemyDamage = 212f,
                    EnemySpeedMultiplier = 6.05f,
                    GoldReward = 2575,
                    ExperienceReward = 5150,
                    MaxWaves = 13,
                }
            },
            // Level 102 - Wave Configuration
            {
                102,
                new LevelConfig
                {
                    LevelId = 102,
                    DisplayName = "Level 102",
                    BaseEnemyHealth = 1630f,
                    BaseEnemyDamage = 214f,
                    EnemySpeedMultiplier = 6.1f,
                    GoldReward = 2600,
                    ExperienceReward = 5200,
                    MaxWaves = 13,
                }
            },
            // Level 103 - Wave Configuration
            {
                103,
                new LevelConfig
                {
                    LevelId = 103,
                    DisplayName = "Level 103",
                    BaseEnemyHealth = 1645f,
                    BaseEnemyDamage = 216f,
                    EnemySpeedMultiplier = 6.15f,
                    GoldReward = 2625,
                    ExperienceReward = 5250,
                    MaxWaves = 13,
                }
            },
            // Level 104 - Wave Configuration
            {
                104,
                new LevelConfig
                {
                    LevelId = 104,
                    DisplayName = "Level 104",
                    BaseEnemyHealth = 1660f,
                    BaseEnemyDamage = 218f,
                    EnemySpeedMultiplier = 6.2f,
                    GoldReward = 2650,
                    ExperienceReward = 5300,
                    MaxWaves = 13,
                }
            },
            // Level 105 - Wave Configuration
            {
                105,
                new LevelConfig
                {
                    LevelId = 105,
                    DisplayName = "Level 105",
                    BaseEnemyHealth = 1675f,
                    BaseEnemyDamage = 220f,
                    EnemySpeedMultiplier = 6.25f,
                    GoldReward = 2675,
                    ExperienceReward = 5350,
                    MaxWaves = 13,
                }
            },
            // Level 106 - Wave Configuration
            {
                106,
                new LevelConfig
                {
                    LevelId = 106,
                    DisplayName = "Level 106",
                    BaseEnemyHealth = 1690f,
                    BaseEnemyDamage = 222f,
                    EnemySpeedMultiplier = 6.3f,
                    GoldReward = 2700,
                    ExperienceReward = 5400,
                    MaxWaves = 13,
                }
            },
            // Level 107 - Wave Configuration
            {
                107,
                new LevelConfig
                {
                    LevelId = 107,
                    DisplayName = "Level 107",
                    BaseEnemyHealth = 1705f,
                    BaseEnemyDamage = 224f,
                    EnemySpeedMultiplier = 6.35f,
                    GoldReward = 2725,
                    ExperienceReward = 5450,
                    MaxWaves = 13,
                }
            },
            // Level 108 - Wave Configuration
            {
                108,
                new LevelConfig
                {
                    LevelId = 108,
                    DisplayName = "Level 108",
                    BaseEnemyHealth = 1720f,
                    BaseEnemyDamage = 226f,
                    EnemySpeedMultiplier = 6.4f,
                    GoldReward = 2750,
                    ExperienceReward = 5500,
                    MaxWaves = 13,
                }
            },
            // Level 109 - Wave Configuration
            {
                109,
                new LevelConfig
                {
                    LevelId = 109,
                    DisplayName = "Level 109",
                    BaseEnemyHealth = 1735f,
                    BaseEnemyDamage = 228f,
                    EnemySpeedMultiplier = 6.45f,
                    GoldReward = 2775,
                    ExperienceReward = 5550,
                    MaxWaves = 13,
                }
            },
            // Level 110 - Wave Configuration
            {
                110,
                new LevelConfig
                {
                    LevelId = 110,
                    DisplayName = "Level 110",
                    BaseEnemyHealth = 1750f,
                    BaseEnemyDamage = 230f,
                    EnemySpeedMultiplier = 6.5f,
                    GoldReward = 2800,
                    ExperienceReward = 5600,
                    MaxWaves = 14,
                }
            },
            // Level 111 - Wave Configuration
            {
                111,
                new LevelConfig
                {
                    LevelId = 111,
                    DisplayName = "Level 111",
                    BaseEnemyHealth = 1765f,
                    BaseEnemyDamage = 232f,
                    EnemySpeedMultiplier = 6.55f,
                    GoldReward = 2825,
                    ExperienceReward = 5650,
                    MaxWaves = 14,
                }
            },
            // Level 112 - Wave Configuration
            {
                112,
                new LevelConfig
                {
                    LevelId = 112,
                    DisplayName = "Level 112",
                    BaseEnemyHealth = 1780f,
                    BaseEnemyDamage = 234f,
                    EnemySpeedMultiplier = 6.6f,
                    GoldReward = 2850,
                    ExperienceReward = 5700,
                    MaxWaves = 14,
                }
            },
            // Level 113 - Wave Configuration
            {
                113,
                new LevelConfig
                {
                    LevelId = 113,
                    DisplayName = "Level 113",
                    BaseEnemyHealth = 1795f,
                    BaseEnemyDamage = 236f,
                    EnemySpeedMultiplier = 6.65f,
                    GoldReward = 2875,
                    ExperienceReward = 5750,
                    MaxWaves = 14,
                }
            },
            // Level 114 - Wave Configuration
            {
                114,
                new LevelConfig
                {
                    LevelId = 114,
                    DisplayName = "Level 114",
                    BaseEnemyHealth = 1810f,
                    BaseEnemyDamage = 238f,
                    EnemySpeedMultiplier = 6.7f,
                    GoldReward = 2900,
                    ExperienceReward = 5800,
                    MaxWaves = 14,
                }
            },
            // Level 115 - Wave Configuration
            {
                115,
                new LevelConfig
                {
                    LevelId = 115,
                    DisplayName = "Level 115",
                    BaseEnemyHealth = 1825f,
                    BaseEnemyDamage = 240f,
                    EnemySpeedMultiplier = 6.75f,
                    GoldReward = 2925,
                    ExperienceReward = 5850,
                    MaxWaves = 14,
                }
            },
            // Level 116 - Wave Configuration
            {
                116,
                new LevelConfig
                {
                    LevelId = 116,
                    DisplayName = "Level 116",
                    BaseEnemyHealth = 1840f,
                    BaseEnemyDamage = 242f,
                    EnemySpeedMultiplier = 6.8f,
                    GoldReward = 2950,
                    ExperienceReward = 5900,
                    MaxWaves = 14,
                }
            },
            // Level 117 - Wave Configuration
            {
                117,
                new LevelConfig
                {
                    LevelId = 117,
                    DisplayName = "Level 117",
                    BaseEnemyHealth = 1855f,
                    BaseEnemyDamage = 244f,
                    EnemySpeedMultiplier = 6.85f,
                    GoldReward = 2975,
                    ExperienceReward = 5950,
                    MaxWaves = 14,
                }
            },
            // Level 118 - Wave Configuration
            {
                118,
                new LevelConfig
                {
                    LevelId = 118,
                    DisplayName = "Level 118",
                    BaseEnemyHealth = 1870f,
                    BaseEnemyDamage = 246f,
                    EnemySpeedMultiplier = 6.9f,
                    GoldReward = 3000,
                    ExperienceReward = 6000,
                    MaxWaves = 14,
                }
            },
            // Level 119 - Wave Configuration
            {
                119,
                new LevelConfig
                {
                    LevelId = 119,
                    DisplayName = "Level 119",
                    BaseEnemyHealth = 1885f,
                    BaseEnemyDamage = 248f,
                    EnemySpeedMultiplier = 6.95f,
                    GoldReward = 3025,
                    ExperienceReward = 6050,
                    MaxWaves = 14,
                }
            },
            // Level 120 - Wave Configuration
            {
                120,
                new LevelConfig
                {
                    LevelId = 120,
                    DisplayName = "Level 120",
                    BaseEnemyHealth = 1900f,
                    BaseEnemyDamage = 250f,
                    EnemySpeedMultiplier = 7f,
                    GoldReward = 3050,
                    ExperienceReward = 6100,
                    MaxWaves = 15,
                }
            },
            // Level 121 - Wave Configuration
            {
                121,
                new LevelConfig
                {
                    LevelId = 121,
                    DisplayName = "Level 121",
                    BaseEnemyHealth = 1915f,
                    BaseEnemyDamage = 252f,
                    EnemySpeedMultiplier = 7.05f,
                    GoldReward = 3075,
                    ExperienceReward = 6150,
                    MaxWaves = 15,
                }
            },
            // Level 122 - Wave Configuration
            {
                122,
                new LevelConfig
                {
                    LevelId = 122,
                    DisplayName = "Level 122",
                    BaseEnemyHealth = 1930f,
                    BaseEnemyDamage = 254f,
                    EnemySpeedMultiplier = 7.1f,
                    GoldReward = 3100,
                    ExperienceReward = 6200,
                    MaxWaves = 15,
                }
            },
            // Level 123 - Wave Configuration
            {
                123,
                new LevelConfig
                {
                    LevelId = 123,
                    DisplayName = "Level 123",
                    BaseEnemyHealth = 1945f,
                    BaseEnemyDamage = 256f,
                    EnemySpeedMultiplier = 7.15f,
                    GoldReward = 3125,
                    ExperienceReward = 6250,
                    MaxWaves = 15,
                }
            },
            // Level 124 - Wave Configuration
            {
                124,
                new LevelConfig
                {
                    LevelId = 124,
                    DisplayName = "Level 124",
                    BaseEnemyHealth = 1960f,
                    BaseEnemyDamage = 258f,
                    EnemySpeedMultiplier = 7.2f,
                    GoldReward = 3150,
                    ExperienceReward = 6300,
                    MaxWaves = 15,
                }
            },
            // Level 125 - Wave Configuration
            {
                125,
                new LevelConfig
                {
                    LevelId = 125,
                    DisplayName = "Level 125",
                    BaseEnemyHealth = 1975f,
                    BaseEnemyDamage = 260f,
                    EnemySpeedMultiplier = 7.25f,
                    GoldReward = 3175,
                    ExperienceReward = 6350,
                    MaxWaves = 15,
                }
            },
            // Level 126 - Wave Configuration
            {
                126,
                new LevelConfig
                {
                    LevelId = 126,
                    DisplayName = "Level 126",
                    BaseEnemyHealth = 1990f,
                    BaseEnemyDamage = 262f,
                    EnemySpeedMultiplier = 7.3f,
                    GoldReward = 3200,
                    ExperienceReward = 6400,
                    MaxWaves = 15,
                }
            },
            // Level 127 - Wave Configuration
            {
                127,
                new LevelConfig
                {
                    LevelId = 127,
                    DisplayName = "Level 127",
                    BaseEnemyHealth = 2005f,
                    BaseEnemyDamage = 264f,
                    EnemySpeedMultiplier = 7.35f,
                    GoldReward = 3225,
                    ExperienceReward = 6450,
                    MaxWaves = 15,
                }
            },
            // Level 128 - Wave Configuration
            {
                128,
                new LevelConfig
                {
                    LevelId = 128,
                    DisplayName = "Level 128",
                    BaseEnemyHealth = 2020f,
                    BaseEnemyDamage = 266f,
                    EnemySpeedMultiplier = 7.4f,
                    GoldReward = 3250,
                    ExperienceReward = 6500,
                    MaxWaves = 15,
                }
            },
            // Level 129 - Wave Configuration
            {
                129,
                new LevelConfig
                {
                    LevelId = 129,
                    DisplayName = "Level 129",
                    BaseEnemyHealth = 2035f,
                    BaseEnemyDamage = 268f,
                    EnemySpeedMultiplier = 7.45f,
                    GoldReward = 3275,
                    ExperienceReward = 6550,
                    MaxWaves = 15,
                }
            },
            // Level 130 - Wave Configuration
            {
                130,
                new LevelConfig
                {
                    LevelId = 130,
                    DisplayName = "Level 130",
                    BaseEnemyHealth = 2050f,
                    BaseEnemyDamage = 270f,
                    EnemySpeedMultiplier = 7.5f,
                    GoldReward = 3300,
                    ExperienceReward = 6600,
                    MaxWaves = 15,
                }
            },
            // Level 131 - Wave Configuration
            {
                131,
                new LevelConfig
                {
                    LevelId = 131,
                    DisplayName = "Level 131",
                    BaseEnemyHealth = 2065f,
                    BaseEnemyDamage = 272f,
                    EnemySpeedMultiplier = 7.55f,
                    GoldReward = 3325,
                    ExperienceReward = 6650,
                    MaxWaves = 15,
                }
            },
            // Level 132 - Wave Configuration
            {
                132,
                new LevelConfig
                {
                    LevelId = 132,
                    DisplayName = "Level 132",
                    BaseEnemyHealth = 2080f,
                    BaseEnemyDamage = 274f,
                    EnemySpeedMultiplier = 7.6f,
                    GoldReward = 3350,
                    ExperienceReward = 6700,
                    MaxWaves = 15,
                }
            },
            // Level 133 - Wave Configuration
            {
                133,
                new LevelConfig
                {
                    LevelId = 133,
                    DisplayName = "Level 133",
                    BaseEnemyHealth = 2095f,
                    BaseEnemyDamage = 276f,
                    EnemySpeedMultiplier = 7.65f,
                    GoldReward = 3375,
                    ExperienceReward = 6750,
                    MaxWaves = 15,
                }
            },
            // Level 134 - Wave Configuration
            {
                134,
                new LevelConfig
                {
                    LevelId = 134,
                    DisplayName = "Level 134",
                    BaseEnemyHealth = 2110f,
                    BaseEnemyDamage = 278f,
                    EnemySpeedMultiplier = 7.7f,
                    GoldReward = 3400,
                    ExperienceReward = 6800,
                    MaxWaves = 15,
                }
            },
            // Level 135 - Wave Configuration
            {
                135,
                new LevelConfig
                {
                    LevelId = 135,
                    DisplayName = "Level 135",
                    BaseEnemyHealth = 2125f,
                    BaseEnemyDamage = 280f,
                    EnemySpeedMultiplier = 7.75f,
                    GoldReward = 3425,
                    ExperienceReward = 6850,
                    MaxWaves = 15,
                }
            },
            // Level 136 - Wave Configuration
            {
                136,
                new LevelConfig
                {
                    LevelId = 136,
                    DisplayName = "Level 136",
                    BaseEnemyHealth = 2140f,
                    BaseEnemyDamage = 282f,
                    EnemySpeedMultiplier = 7.8f,
                    GoldReward = 3450,
                    ExperienceReward = 6900,
                    MaxWaves = 15,
                }
            },
            // Level 137 - Wave Configuration
            {
                137,
                new LevelConfig
                {
                    LevelId = 137,
                    DisplayName = "Level 137",
                    BaseEnemyHealth = 2155f,
                    BaseEnemyDamage = 284f,
                    EnemySpeedMultiplier = 7.85f,
                    GoldReward = 3475,
                    ExperienceReward = 6950,
                    MaxWaves = 15,
                }
            },
            // Level 138 - Wave Configuration
            {
                138,
                new LevelConfig
                {
                    LevelId = 138,
                    DisplayName = "Level 138",
                    BaseEnemyHealth = 2170f,
                    BaseEnemyDamage = 286f,
                    EnemySpeedMultiplier = 7.9f,
                    GoldReward = 3500,
                    ExperienceReward = 7000,
                    MaxWaves = 15,
                }
            },
            // Level 139 - Wave Configuration
            {
                139,
                new LevelConfig
                {
                    LevelId = 139,
                    DisplayName = "Level 139",
                    BaseEnemyHealth = 2185f,
                    BaseEnemyDamage = 288f,
                    EnemySpeedMultiplier = 7.95f,
                    GoldReward = 3525,
                    ExperienceReward = 7050,
                    MaxWaves = 15,
                }
            },
            // Level 140 - Wave Configuration
            {
                140,
                new LevelConfig
                {
                    LevelId = 140,
                    DisplayName = "Level 140",
                    BaseEnemyHealth = 2200f,
                    BaseEnemyDamage = 290f,
                    EnemySpeedMultiplier = 8f,
                    GoldReward = 3550,
                    ExperienceReward = 7100,
                    MaxWaves = 15,
                }
            },
            // Level 141 - Wave Configuration
            {
                141,
                new LevelConfig
                {
                    LevelId = 141,
                    DisplayName = "Level 141",
                    BaseEnemyHealth = 2215f,
                    BaseEnemyDamage = 292f,
                    EnemySpeedMultiplier = 8.05f,
                    GoldReward = 3575,
                    ExperienceReward = 7150,
                    MaxWaves = 15,
                }
            },
            // Level 142 - Wave Configuration
            {
                142,
                new LevelConfig
                {
                    LevelId = 142,
                    DisplayName = "Level 142",
                    BaseEnemyHealth = 2230f,
                    BaseEnemyDamage = 294f,
                    EnemySpeedMultiplier = 8.1f,
                    GoldReward = 3600,
                    ExperienceReward = 7200,
                    MaxWaves = 15,
                }
            },
            // Level 143 - Wave Configuration
            {
                143,
                new LevelConfig
                {
                    LevelId = 143,
                    DisplayName = "Level 143",
                    BaseEnemyHealth = 2245f,
                    BaseEnemyDamage = 296f,
                    EnemySpeedMultiplier = 8.15f,
                    GoldReward = 3625,
                    ExperienceReward = 7250,
                    MaxWaves = 15,
                }
            },
            // Level 144 - Wave Configuration
            {
                144,
                new LevelConfig
                {
                    LevelId = 144,
                    DisplayName = "Level 144",
                    BaseEnemyHealth = 2260f,
                    BaseEnemyDamage = 298f,
                    EnemySpeedMultiplier = 8.2f,
                    GoldReward = 3650,
                    ExperienceReward = 7300,
                    MaxWaves = 15,
                }
            },
            // Level 145 - Wave Configuration
            {
                145,
                new LevelConfig
                {
                    LevelId = 145,
                    DisplayName = "Level 145",
                    BaseEnemyHealth = 2275f,
                    BaseEnemyDamage = 300f,
                    EnemySpeedMultiplier = 8.25f,
                    GoldReward = 3675,
                    ExperienceReward = 7350,
                    MaxWaves = 15,
                }
            },
            // Level 146 - Wave Configuration
            {
                146,
                new LevelConfig
                {
                    LevelId = 146,
                    DisplayName = "Level 146",
                    BaseEnemyHealth = 2290f,
                    BaseEnemyDamage = 302f,
                    EnemySpeedMultiplier = 8.3f,
                    GoldReward = 3700,
                    ExperienceReward = 7400,
                    MaxWaves = 15,
                }
            },
            // Level 147 - Wave Configuration
            {
                147,
                new LevelConfig
                {
                    LevelId = 147,
                    DisplayName = "Level 147",
                    BaseEnemyHealth = 2305f,
                    BaseEnemyDamage = 304f,
                    EnemySpeedMultiplier = 8.35f,
                    GoldReward = 3725,
                    ExperienceReward = 7450,
                    MaxWaves = 15,
                }
            },
            // Level 148 - Wave Configuration
            {
                148,
                new LevelConfig
                {
                    LevelId = 148,
                    DisplayName = "Level 148",
                    BaseEnemyHealth = 2320f,
                    BaseEnemyDamage = 306f,
                    EnemySpeedMultiplier = 8.4f,
                    GoldReward = 3750,
                    ExperienceReward = 7500,
                    MaxWaves = 15,
                }
            },
            // Level 149 - Wave Configuration
            {
                149,
                new LevelConfig
                {
                    LevelId = 149,
                    DisplayName = "Level 149",
                    BaseEnemyHealth = 2335f,
                    BaseEnemyDamage = 308f,
                    EnemySpeedMultiplier = 8.45f,
                    GoldReward = 3775,
                    ExperienceReward = 7550,
                    MaxWaves = 15,
                }
            },
            // Level 150 - Wave Configuration
            {
                150,
                new LevelConfig
                {
                    LevelId = 150,
                    DisplayName = "Level 150",
                    BaseEnemyHealth = 2350f,
                    BaseEnemyDamage = 310f,
                    EnemySpeedMultiplier = 8.5f,
                    GoldReward = 3800,
                    ExperienceReward = 7600,
                    MaxWaves = 15,
                }
            },
            // Level 151 - Wave Configuration
            {
                151,
                new LevelConfig
                {
                    LevelId = 151,
                    DisplayName = "Level 151",
                    BaseEnemyHealth = 2365f,
                    BaseEnemyDamage = 312f,
                    EnemySpeedMultiplier = 8.55f,
                    GoldReward = 3825,
                    ExperienceReward = 7650,
                    MaxWaves = 15,
                }
            },
            // Level 152 - Wave Configuration
            {
                152,
                new LevelConfig
                {
                    LevelId = 152,
                    DisplayName = "Level 152",
                    BaseEnemyHealth = 2380f,
                    BaseEnemyDamage = 314f,
                    EnemySpeedMultiplier = 8.6f,
                    GoldReward = 3850,
                    ExperienceReward = 7700,
                    MaxWaves = 15,
                }
            },
            // Level 153 - Wave Configuration
            {
                153,
                new LevelConfig
                {
                    LevelId = 153,
                    DisplayName = "Level 153",
                    BaseEnemyHealth = 2395f,
                    BaseEnemyDamage = 316f,
                    EnemySpeedMultiplier = 8.65f,
                    GoldReward = 3875,
                    ExperienceReward = 7750,
                    MaxWaves = 15,
                }
            },
            // Level 154 - Wave Configuration
            {
                154,
                new LevelConfig
                {
                    LevelId = 154,
                    DisplayName = "Level 154",
                    BaseEnemyHealth = 2410f,
                    BaseEnemyDamage = 318f,
                    EnemySpeedMultiplier = 8.7f,
                    GoldReward = 3900,
                    ExperienceReward = 7800,
                    MaxWaves = 15,
                }
            },
            // Level 155 - Wave Configuration
            {
                155,
                new LevelConfig
                {
                    LevelId = 155,
                    DisplayName = "Level 155",
                    BaseEnemyHealth = 2425f,
                    BaseEnemyDamage = 320f,
                    EnemySpeedMultiplier = 8.75f,
                    GoldReward = 3925,
                    ExperienceReward = 7850,
                    MaxWaves = 15,
                }
            },
            // Level 156 - Wave Configuration
            {
                156,
                new LevelConfig
                {
                    LevelId = 156,
                    DisplayName = "Level 156",
                    BaseEnemyHealth = 2440f,
                    BaseEnemyDamage = 322f,
                    EnemySpeedMultiplier = 8.8f,
                    GoldReward = 3950,
                    ExperienceReward = 7900,
                    MaxWaves = 15,
                }
            },
            // Level 157 - Wave Configuration
            {
                157,
                new LevelConfig
                {
                    LevelId = 157,
                    DisplayName = "Level 157",
                    BaseEnemyHealth = 2455f,
                    BaseEnemyDamage = 324f,
                    EnemySpeedMultiplier = 8.85f,
                    GoldReward = 3975,
                    ExperienceReward = 7950,
                    MaxWaves = 15,
                }
            },
            // Level 158 - Wave Configuration
            {
                158,
                new LevelConfig
                {
                    LevelId = 158,
                    DisplayName = "Level 158",
                    BaseEnemyHealth = 2470f,
                    BaseEnemyDamage = 326f,
                    EnemySpeedMultiplier = 8.9f,
                    GoldReward = 4000,
                    ExperienceReward = 8000,
                    MaxWaves = 15,
                }
            },
            // Level 159 - Wave Configuration
            {
                159,
                new LevelConfig
                {
                    LevelId = 159,
                    DisplayName = "Level 159",
                    BaseEnemyHealth = 2485f,
                    BaseEnemyDamage = 328f,
                    EnemySpeedMultiplier = 8.95f,
                    GoldReward = 4025,
                    ExperienceReward = 8050,
                    MaxWaves = 15,
                }
            },
            // Level 160 - Wave Configuration
            {
                160,
                new LevelConfig
                {
                    LevelId = 160,
                    DisplayName = "Level 160",
                    BaseEnemyHealth = 2500f,
                    BaseEnemyDamage = 330f,
                    EnemySpeedMultiplier = 9f,
                    GoldReward = 4050,
                    ExperienceReward = 8100,
                    MaxWaves = 15,
                }
            },
            // Level 161 - Wave Configuration
            {
                161,
                new LevelConfig
                {
                    LevelId = 161,
                    DisplayName = "Level 161",
                    BaseEnemyHealth = 2515f,
                    BaseEnemyDamage = 332f,
                    EnemySpeedMultiplier = 9.05f,
                    GoldReward = 4075,
                    ExperienceReward = 8150,
                    MaxWaves = 15,
                }
            },
            // Level 162 - Wave Configuration
            {
                162,
                new LevelConfig
                {
                    LevelId = 162,
                    DisplayName = "Level 162",
                    BaseEnemyHealth = 2530f,
                    BaseEnemyDamage = 334f,
                    EnemySpeedMultiplier = 9.1f,
                    GoldReward = 4100,
                    ExperienceReward = 8200,
                    MaxWaves = 15,
                }
            },
            // Level 163 - Wave Configuration
            {
                163,
                new LevelConfig
                {
                    LevelId = 163,
                    DisplayName = "Level 163",
                    BaseEnemyHealth = 2545f,
                    BaseEnemyDamage = 336f,
                    EnemySpeedMultiplier = 9.15f,
                    GoldReward = 4125,
                    ExperienceReward = 8250,
                    MaxWaves = 15,
                }
            },
            // Level 164 - Wave Configuration
            {
                164,
                new LevelConfig
                {
                    LevelId = 164,
                    DisplayName = "Level 164",
                    BaseEnemyHealth = 2560f,
                    BaseEnemyDamage = 338f,
                    EnemySpeedMultiplier = 9.2f,
                    GoldReward = 4150,
                    ExperienceReward = 8300,
                    MaxWaves = 15,
                }
            },
            // Level 165 - Wave Configuration
            {
                165,
                new LevelConfig
                {
                    LevelId = 165,
                    DisplayName = "Level 165",
                    BaseEnemyHealth = 2575f,
                    BaseEnemyDamage = 340f,
                    EnemySpeedMultiplier = 9.25f,
                    GoldReward = 4175,
                    ExperienceReward = 8350,
                    MaxWaves = 15,
                }
            },
            // Level 166 - Wave Configuration
            {
                166,
                new LevelConfig
                {
                    LevelId = 166,
                    DisplayName = "Level 166",
                    BaseEnemyHealth = 2590f,
                    BaseEnemyDamage = 342f,
                    EnemySpeedMultiplier = 9.3f,
                    GoldReward = 4200,
                    ExperienceReward = 8400,
                    MaxWaves = 15,
                }
            },
            // Level 167 - Wave Configuration
            {
                167,
                new LevelConfig
                {
                    LevelId = 167,
                    DisplayName = "Level 167",
                    BaseEnemyHealth = 2605f,
                    BaseEnemyDamage = 344f,
                    EnemySpeedMultiplier = 9.35f,
                    GoldReward = 4225,
                    ExperienceReward = 8450,
                    MaxWaves = 15,
                }
            },
            // Level 168 - Wave Configuration
            {
                168,
                new LevelConfig
                {
                    LevelId = 168,
                    DisplayName = "Level 168",
                    BaseEnemyHealth = 2620f,
                    BaseEnemyDamage = 346f,
                    EnemySpeedMultiplier = 9.4f,
                    GoldReward = 4250,
                    ExperienceReward = 8500,
                    MaxWaves = 15,
                }
            },
            // Level 169 - Wave Configuration
            {
                169,
                new LevelConfig
                {
                    LevelId = 169,
                    DisplayName = "Level 169",
                    BaseEnemyHealth = 2635f,
                    BaseEnemyDamage = 348f,
                    EnemySpeedMultiplier = 9.45f,
                    GoldReward = 4275,
                    ExperienceReward = 8550,
                    MaxWaves = 15,
                }
            },
            // Level 170 - Wave Configuration
            {
                170,
                new LevelConfig
                {
                    LevelId = 170,
                    DisplayName = "Level 170",
                    BaseEnemyHealth = 2650f,
                    BaseEnemyDamage = 350f,
                    EnemySpeedMultiplier = 9.5f,
                    GoldReward = 4300,
                    ExperienceReward = 8600,
                    MaxWaves = 15,
                }
            },
            // Level 171 - Wave Configuration
            {
                171,
                new LevelConfig
                {
                    LevelId = 171,
                    DisplayName = "Level 171",
                    BaseEnemyHealth = 2665f,
                    BaseEnemyDamage = 352f,
                    EnemySpeedMultiplier = 9.55f,
                    GoldReward = 4325,
                    ExperienceReward = 8650,
                    MaxWaves = 15,
                }
            },
            // Level 172 - Wave Configuration
            {
                172,
                new LevelConfig
                {
                    LevelId = 172,
                    DisplayName = "Level 172",
                    BaseEnemyHealth = 2680f,
                    BaseEnemyDamage = 354f,
                    EnemySpeedMultiplier = 9.6f,
                    GoldReward = 4350,
                    ExperienceReward = 8700,
                    MaxWaves = 15,
                }
            },
            // Level 173 - Wave Configuration
            {
                173,
                new LevelConfig
                {
                    LevelId = 173,
                    DisplayName = "Level 173",
                    BaseEnemyHealth = 2695f,
                    BaseEnemyDamage = 356f,
                    EnemySpeedMultiplier = 9.65f,
                    GoldReward = 4375,
                    ExperienceReward = 8750,
                    MaxWaves = 15,
                }
            },
            // Level 174 - Wave Configuration
            {
                174,
                new LevelConfig
                {
                    LevelId = 174,
                    DisplayName = "Level 174",
                    BaseEnemyHealth = 2710f,
                    BaseEnemyDamage = 358f,
                    EnemySpeedMultiplier = 9.7f,
                    GoldReward = 4400,
                    ExperienceReward = 8800,
                    MaxWaves = 15,
                }
            },
            // Level 175 - Wave Configuration
            {
                175,
                new LevelConfig
                {
                    LevelId = 175,
                    DisplayName = "Level 175",
                    BaseEnemyHealth = 2725f,
                    BaseEnemyDamage = 360f,
                    EnemySpeedMultiplier = 9.75f,
                    GoldReward = 4425,
                    ExperienceReward = 8850,
                    MaxWaves = 15,
                }
            },
            // Level 176 - Wave Configuration
            {
                176,
                new LevelConfig
                {
                    LevelId = 176,
                    DisplayName = "Level 176",
                    BaseEnemyHealth = 2740f,
                    BaseEnemyDamage = 362f,
                    EnemySpeedMultiplier = 9.8f,
                    GoldReward = 4450,
                    ExperienceReward = 8900,
                    MaxWaves = 15,
                }
            },
            // Level 177 - Wave Configuration
            {
                177,
                new LevelConfig
                {
                    LevelId = 177,
                    DisplayName = "Level 177",
                    BaseEnemyHealth = 2755f,
                    BaseEnemyDamage = 364f,
                    EnemySpeedMultiplier = 9.85f,
                    GoldReward = 4475,
                    ExperienceReward = 8950,
                    MaxWaves = 15,
                }
            },
            // Level 178 - Wave Configuration
            {
                178,
                new LevelConfig
                {
                    LevelId = 178,
                    DisplayName = "Level 178",
                    BaseEnemyHealth = 2770f,
                    BaseEnemyDamage = 366f,
                    EnemySpeedMultiplier = 9.9f,
                    GoldReward = 4500,
                    ExperienceReward = 9000,
                    MaxWaves = 15,
                }
            },
            // Level 179 - Wave Configuration
            {
                179,
                new LevelConfig
                {
                    LevelId = 179,
                    DisplayName = "Level 179",
                    BaseEnemyHealth = 2785f,
                    BaseEnemyDamage = 368f,
                    EnemySpeedMultiplier = 9.95f,
                    GoldReward = 4525,
                    ExperienceReward = 9050,
                    MaxWaves = 15,
                }
            },
            // Level 180 - Wave Configuration
            {
                180,
                new LevelConfig
                {
                    LevelId = 180,
                    DisplayName = "Level 180",
                    BaseEnemyHealth = 2800f,
                    BaseEnemyDamage = 370f,
                    EnemySpeedMultiplier = 10f,
                    GoldReward = 4550,
                    ExperienceReward = 9100,
                    MaxWaves = 15,
                }
            },
            // Level 181 - Wave Configuration
            {
                181,
                new LevelConfig
                {
                    LevelId = 181,
                    DisplayName = "Level 181",
                    BaseEnemyHealth = 2815f,
                    BaseEnemyDamage = 372f,
                    EnemySpeedMultiplier = 10.05f,
                    GoldReward = 4575,
                    ExperienceReward = 9150,
                    MaxWaves = 15,
                }
            },
            // Level 182 - Wave Configuration
            {
                182,
                new LevelConfig
                {
                    LevelId = 182,
                    DisplayName = "Level 182",
                    BaseEnemyHealth = 2830f,
                    BaseEnemyDamage = 374f,
                    EnemySpeedMultiplier = 10.1f,
                    GoldReward = 4600,
                    ExperienceReward = 9200,
                    MaxWaves = 15,
                }
            },
            // Level 183 - Wave Configuration
            {
                183,
                new LevelConfig
                {
                    LevelId = 183,
                    DisplayName = "Level 183",
                    BaseEnemyHealth = 2845f,
                    BaseEnemyDamage = 376f,
                    EnemySpeedMultiplier = 10.15f,
                    GoldReward = 4625,
                    ExperienceReward = 9250,
                    MaxWaves = 15,
                }
            },
            // Level 184 - Wave Configuration
            {
                184,
                new LevelConfig
                {
                    LevelId = 184,
                    DisplayName = "Level 184",
                    BaseEnemyHealth = 2860f,
                    BaseEnemyDamage = 378f,
                    EnemySpeedMultiplier = 10.2f,
                    GoldReward = 4650,
                    ExperienceReward = 9300,
                    MaxWaves = 15,
                }
            },
            // Level 185 - Wave Configuration
            {
                185,
                new LevelConfig
                {
                    LevelId = 185,
                    DisplayName = "Level 185",
                    BaseEnemyHealth = 2875f,
                    BaseEnemyDamage = 380f,
                    EnemySpeedMultiplier = 10.25f,
                    GoldReward = 4675,
                    ExperienceReward = 9350,
                    MaxWaves = 15,
                }
            },
            // Level 186 - Wave Configuration
            {
                186,
                new LevelConfig
                {
                    LevelId = 186,
                    DisplayName = "Level 186",
                    BaseEnemyHealth = 2890f,
                    BaseEnemyDamage = 382f,
                    EnemySpeedMultiplier = 10.3f,
                    GoldReward = 4700,
                    ExperienceReward = 9400,
                    MaxWaves = 15,
                }
            },
            // Level 187 - Wave Configuration
            {
                187,
                new LevelConfig
                {
                    LevelId = 187,
                    DisplayName = "Level 187",
                    BaseEnemyHealth = 2905f,
                    BaseEnemyDamage = 384f,
                    EnemySpeedMultiplier = 10.35f,
                    GoldReward = 4725,
                    ExperienceReward = 9450,
                    MaxWaves = 15,
                }
            },
            // Level 188 - Wave Configuration
            {
                188,
                new LevelConfig
                {
                    LevelId = 188,
                    DisplayName = "Level 188",
                    BaseEnemyHealth = 2920f,
                    BaseEnemyDamage = 386f,
                    EnemySpeedMultiplier = 10.4f,
                    GoldReward = 4750,
                    ExperienceReward = 9500,
                    MaxWaves = 15,
                }
            },
            // Level 189 - Wave Configuration
            {
                189,
                new LevelConfig
                {
                    LevelId = 189,
                    DisplayName = "Level 189",
                    BaseEnemyHealth = 2935f,
                    BaseEnemyDamage = 388f,
                    EnemySpeedMultiplier = 10.45f,
                    GoldReward = 4775,
                    ExperienceReward = 9550,
                    MaxWaves = 15,
                }
            },
            // Level 190 - Wave Configuration
            {
                190,
                new LevelConfig
                {
                    LevelId = 190,
                    DisplayName = "Level 190",
                    BaseEnemyHealth = 2950f,
                    BaseEnemyDamage = 390f,
                    EnemySpeedMultiplier = 10.5f,
                    GoldReward = 4800,
                    ExperienceReward = 9600,
                    MaxWaves = 15,
                }
            },
            // Level 191 - Wave Configuration
            {
                191,
                new LevelConfig
                {
                    LevelId = 191,
                    DisplayName = "Level 191",
                    BaseEnemyHealth = 2965f,
                    BaseEnemyDamage = 392f,
                    EnemySpeedMultiplier = 10.55f,
                    GoldReward = 4825,
                    ExperienceReward = 9650,
                    MaxWaves = 15,
                }
            },
            // Level 192 - Wave Configuration
            {
                192,
                new LevelConfig
                {
                    LevelId = 192,
                    DisplayName = "Level 192",
                    BaseEnemyHealth = 2980f,
                    BaseEnemyDamage = 394f,
                    EnemySpeedMultiplier = 10.6f,
                    GoldReward = 4850,
                    ExperienceReward = 9700,
                    MaxWaves = 15,
                }
            },
            // Level 193 - Wave Configuration
            {
                193,
                new LevelConfig
                {
                    LevelId = 193,
                    DisplayName = "Level 193",
                    BaseEnemyHealth = 2995f,
                    BaseEnemyDamage = 396f,
                    EnemySpeedMultiplier = 10.65f,
                    GoldReward = 4875,
                    ExperienceReward = 9750,
                    MaxWaves = 15,
                }
            },
            // Level 194 - Wave Configuration
            {
                194,
                new LevelConfig
                {
                    LevelId = 194,
                    DisplayName = "Level 194",
                    BaseEnemyHealth = 3010f,
                    BaseEnemyDamage = 398f,
                    EnemySpeedMultiplier = 10.7f,
                    GoldReward = 4900,
                    ExperienceReward = 9800,
                    MaxWaves = 15,
                }
            },
            // Level 195 - Wave Configuration
            {
                195,
                new LevelConfig
                {
                    LevelId = 195,
                    DisplayName = "Level 195",
                    BaseEnemyHealth = 3025f,
                    BaseEnemyDamage = 400f,
                    EnemySpeedMultiplier = 10.75f,
                    GoldReward = 4925,
                    ExperienceReward = 9850,
                    MaxWaves = 15,
                }
            },
            // Level 196 - Wave Configuration
            {
                196,
                new LevelConfig
                {
                    LevelId = 196,
                    DisplayName = "Level 196",
                    BaseEnemyHealth = 3040f,
                    BaseEnemyDamage = 402f,
                    EnemySpeedMultiplier = 10.8f,
                    GoldReward = 4950,
                    ExperienceReward = 9900,
                    MaxWaves = 15,
                }
            },
            // Level 197 - Wave Configuration
            {
                197,
                new LevelConfig
                {
                    LevelId = 197,
                    DisplayName = "Level 197",
                    BaseEnemyHealth = 3055f,
                    BaseEnemyDamage = 404f,
                    EnemySpeedMultiplier = 10.85f,
                    GoldReward = 4975,
                    ExperienceReward = 9950,
                    MaxWaves = 15,
                }
            },
            // Level 198 - Wave Configuration
            {
                198,
                new LevelConfig
                {
                    LevelId = 198,
                    DisplayName = "Level 198",
                    BaseEnemyHealth = 3070f,
                    BaseEnemyDamage = 406f,
                    EnemySpeedMultiplier = 10.9f,
                    GoldReward = 5000,
                    ExperienceReward = 10000,
                    MaxWaves = 15,
                }
            },
            // Level 199 - Wave Configuration
            {
                199,
                new LevelConfig
                {
                    LevelId = 199,
                    DisplayName = "Level 199",
                    BaseEnemyHealth = 3085f,
                    BaseEnemyDamage = 408f,
                    EnemySpeedMultiplier = 10.95f,
                    GoldReward = 5025,
                    ExperienceReward = 10050,
                    MaxWaves = 15,
                }
            },
            // Level 200 - Wave Configuration
            {
                200,
                new LevelConfig
                {
                    LevelId = 200,
                    DisplayName = "Level 200",
                    BaseEnemyHealth = 3100f,
                    BaseEnemyDamage = 410f,
                    EnemySpeedMultiplier = 11f,
                    GoldReward = 5050,
                    ExperienceReward = 10100,
                    MaxWaves = 15,
                }
            },
        };

        #endregion

        #region Item Database

        /// <summary>Complete item database with stats and descriptions.</summary>
        public static readonly Dictionary<string, ItemData> Items = new Dictionary<string, ItemData>
        {
            // Weapon - Common Tier 1
            {
                "Weapon_Common_T1",
                new ItemData
                {
                    ItemId = "Weapon_Common_T1",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Weapon of Power 1",
                    Description = "A common weapon imbued with tier 1 enchantments.",
                    BasePrice = 10,
                    PowerRating = 5f,
                    RequiredLevel = 3,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Common Tier 2
            {
                "Weapon_Common_T2",
                new ItemData
                {
                    ItemId = "Weapon_Common_T2",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Weapon of Power 2",
                    Description = "A common weapon imbued with tier 2 enchantments.",
                    BasePrice = 20,
                    PowerRating = 10f,
                    RequiredLevel = 6,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Common Tier 3
            {
                "Weapon_Common_T3",
                new ItemData
                {
                    ItemId = "Weapon_Common_T3",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Weapon of Power 3",
                    Description = "A common weapon imbued with tier 3 enchantments.",
                    BasePrice = 30,
                    PowerRating = 15f,
                    RequiredLevel = 9,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Common Tier 4
            {
                "Weapon_Common_T4",
                new ItemData
                {
                    ItemId = "Weapon_Common_T4",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Weapon of Power 4",
                    Description = "A common weapon imbued with tier 4 enchantments.",
                    BasePrice = 40,
                    PowerRating = 20f,
                    RequiredLevel = 12,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Common Tier 5
            {
                "Weapon_Common_T5",
                new ItemData
                {
                    ItemId = "Weapon_Common_T5",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Weapon of Power 5",
                    Description = "A common weapon imbued with tier 5 enchantments.",
                    BasePrice = 50,
                    PowerRating = 25f,
                    RequiredLevel = 15,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Common Tier 6
            {
                "Weapon_Common_T6",
                new ItemData
                {
                    ItemId = "Weapon_Common_T6",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Weapon of Power 6",
                    Description = "A common weapon imbued with tier 6 enchantments.",
                    BasePrice = 60,
                    PowerRating = 30f,
                    RequiredLevel = 18,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Common Tier 7
            {
                "Weapon_Common_T7",
                new ItemData
                {
                    ItemId = "Weapon_Common_T7",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Weapon of Power 7",
                    Description = "A common weapon imbued with tier 7 enchantments.",
                    BasePrice = 70,
                    PowerRating = 35f,
                    RequiredLevel = 21,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Common Tier 8
            {
                "Weapon_Common_T8",
                new ItemData
                {
                    ItemId = "Weapon_Common_T8",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Weapon of Power 8",
                    Description = "A common weapon imbued with tier 8 enchantments.",
                    BasePrice = 80,
                    PowerRating = 40f,
                    RequiredLevel = 24,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Common Tier 9
            {
                "Weapon_Common_T9",
                new ItemData
                {
                    ItemId = "Weapon_Common_T9",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Weapon of Power 9",
                    Description = "A common weapon imbued with tier 9 enchantments.",
                    BasePrice = 90,
                    PowerRating = 45f,
                    RequiredLevel = 27,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Common Tier 10
            {
                "Weapon_Common_T10",
                new ItemData
                {
                    ItemId = "Weapon_Common_T10",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Weapon of Power 10",
                    Description = "A common weapon imbued with tier 10 enchantments.",
                    BasePrice = 100,
                    PowerRating = 50f,
                    RequiredLevel = 30,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Uncommon Tier 1
            {
                "Weapon_Uncommon_T1",
                new ItemData
                {
                    ItemId = "Weapon_Uncommon_T1",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Weapon of Power 1",
                    Description = "A uncommon weapon imbued with tier 1 enchantments.",
                    BasePrice = 60,
                    PowerRating = 20f,
                    RequiredLevel = 8,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Uncommon Tier 2
            {
                "Weapon_Uncommon_T2",
                new ItemData
                {
                    ItemId = "Weapon_Uncommon_T2",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Weapon of Power 2",
                    Description = "A uncommon weapon imbued with tier 2 enchantments.",
                    BasePrice = 120,
                    PowerRating = 40f,
                    RequiredLevel = 11,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Uncommon Tier 3
            {
                "Weapon_Uncommon_T3",
                new ItemData
                {
                    ItemId = "Weapon_Uncommon_T3",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Weapon of Power 3",
                    Description = "A uncommon weapon imbued with tier 3 enchantments.",
                    BasePrice = 180,
                    PowerRating = 60f,
                    RequiredLevel = 14,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Uncommon Tier 4
            {
                "Weapon_Uncommon_T4",
                new ItemData
                {
                    ItemId = "Weapon_Uncommon_T4",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Weapon of Power 4",
                    Description = "A uncommon weapon imbued with tier 4 enchantments.",
                    BasePrice = 240,
                    PowerRating = 80f,
                    RequiredLevel = 17,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Uncommon Tier 5
            {
                "Weapon_Uncommon_T5",
                new ItemData
                {
                    ItemId = "Weapon_Uncommon_T5",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Weapon of Power 5",
                    Description = "A uncommon weapon imbued with tier 5 enchantments.",
                    BasePrice = 300,
                    PowerRating = 100f,
                    RequiredLevel = 20,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Uncommon Tier 6
            {
                "Weapon_Uncommon_T6",
                new ItemData
                {
                    ItemId = "Weapon_Uncommon_T6",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Weapon of Power 6",
                    Description = "A uncommon weapon imbued with tier 6 enchantments.",
                    BasePrice = 360,
                    PowerRating = 120f,
                    RequiredLevel = 23,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Uncommon Tier 7
            {
                "Weapon_Uncommon_T7",
                new ItemData
                {
                    ItemId = "Weapon_Uncommon_T7",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Weapon of Power 7",
                    Description = "A uncommon weapon imbued with tier 7 enchantments.",
                    BasePrice = 420,
                    PowerRating = 140f,
                    RequiredLevel = 26,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Uncommon Tier 8
            {
                "Weapon_Uncommon_T8",
                new ItemData
                {
                    ItemId = "Weapon_Uncommon_T8",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Weapon of Power 8",
                    Description = "A uncommon weapon imbued with tier 8 enchantments.",
                    BasePrice = 480,
                    PowerRating = 160f,
                    RequiredLevel = 29,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Uncommon Tier 9
            {
                "Weapon_Uncommon_T9",
                new ItemData
                {
                    ItemId = "Weapon_Uncommon_T9",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Weapon of Power 9",
                    Description = "A uncommon weapon imbued with tier 9 enchantments.",
                    BasePrice = 540,
                    PowerRating = 180f,
                    RequiredLevel = 32,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Uncommon Tier 10
            {
                "Weapon_Uncommon_T10",
                new ItemData
                {
                    ItemId = "Weapon_Uncommon_T10",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Weapon of Power 10",
                    Description = "A uncommon weapon imbued with tier 10 enchantments.",
                    BasePrice = 600,
                    PowerRating = 200f,
                    RequiredLevel = 35,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Rare Tier 1
            {
                "Weapon_Rare_T1",
                new ItemData
                {
                    ItemId = "Weapon_Rare_T1",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Weapon of Power 1",
                    Description = "A rare weapon imbued with tier 1 enchantments.",
                    BasePrice = 110,
                    PowerRating = 35f,
                    RequiredLevel = 13,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Rare Tier 2
            {
                "Weapon_Rare_T2",
                new ItemData
                {
                    ItemId = "Weapon_Rare_T2",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Weapon of Power 2",
                    Description = "A rare weapon imbued with tier 2 enchantments.",
                    BasePrice = 220,
                    PowerRating = 70f,
                    RequiredLevel = 16,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Rare Tier 3
            {
                "Weapon_Rare_T3",
                new ItemData
                {
                    ItemId = "Weapon_Rare_T3",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Weapon of Power 3",
                    Description = "A rare weapon imbued with tier 3 enchantments.",
                    BasePrice = 330,
                    PowerRating = 105f,
                    RequiredLevel = 19,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Rare Tier 4
            {
                "Weapon_Rare_T4",
                new ItemData
                {
                    ItemId = "Weapon_Rare_T4",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Weapon of Power 4",
                    Description = "A rare weapon imbued with tier 4 enchantments.",
                    BasePrice = 440,
                    PowerRating = 140f,
                    RequiredLevel = 22,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Rare Tier 5
            {
                "Weapon_Rare_T5",
                new ItemData
                {
                    ItemId = "Weapon_Rare_T5",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Weapon of Power 5",
                    Description = "A rare weapon imbued with tier 5 enchantments.",
                    BasePrice = 550,
                    PowerRating = 175f,
                    RequiredLevel = 25,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Rare Tier 6
            {
                "Weapon_Rare_T6",
                new ItemData
                {
                    ItemId = "Weapon_Rare_T6",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Weapon of Power 6",
                    Description = "A rare weapon imbued with tier 6 enchantments.",
                    BasePrice = 660,
                    PowerRating = 210f,
                    RequiredLevel = 28,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Rare Tier 7
            {
                "Weapon_Rare_T7",
                new ItemData
                {
                    ItemId = "Weapon_Rare_T7",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Weapon of Power 7",
                    Description = "A rare weapon imbued with tier 7 enchantments.",
                    BasePrice = 770,
                    PowerRating = 245f,
                    RequiredLevel = 31,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Rare Tier 8
            {
                "Weapon_Rare_T8",
                new ItemData
                {
                    ItemId = "Weapon_Rare_T8",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Weapon of Power 8",
                    Description = "A rare weapon imbued with tier 8 enchantments.",
                    BasePrice = 880,
                    PowerRating = 280f,
                    RequiredLevel = 34,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Rare Tier 9
            {
                "Weapon_Rare_T9",
                new ItemData
                {
                    ItemId = "Weapon_Rare_T9",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Weapon of Power 9",
                    Description = "A rare weapon imbued with tier 9 enchantments.",
                    BasePrice = 990,
                    PowerRating = 315f,
                    RequiredLevel = 37,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Rare Tier 10
            {
                "Weapon_Rare_T10",
                new ItemData
                {
                    ItemId = "Weapon_Rare_T10",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Weapon of Power 10",
                    Description = "A rare weapon imbued with tier 10 enchantments.",
                    BasePrice = 1100,
                    PowerRating = 350f,
                    RequiredLevel = 40,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Epic Tier 1
            {
                "Weapon_Epic_T1",
                new ItemData
                {
                    ItemId = "Weapon_Epic_T1",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Weapon of Power 1",
                    Description = "A epic weapon imbued with tier 1 enchantments.",
                    BasePrice = 160,
                    PowerRating = 50f,
                    RequiredLevel = 18,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Epic Tier 2
            {
                "Weapon_Epic_T2",
                new ItemData
                {
                    ItemId = "Weapon_Epic_T2",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Weapon of Power 2",
                    Description = "A epic weapon imbued with tier 2 enchantments.",
                    BasePrice = 320,
                    PowerRating = 100f,
                    RequiredLevel = 21,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Epic Tier 3
            {
                "Weapon_Epic_T3",
                new ItemData
                {
                    ItemId = "Weapon_Epic_T3",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Weapon of Power 3",
                    Description = "A epic weapon imbued with tier 3 enchantments.",
                    BasePrice = 480,
                    PowerRating = 150f,
                    RequiredLevel = 24,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Epic Tier 4
            {
                "Weapon_Epic_T4",
                new ItemData
                {
                    ItemId = "Weapon_Epic_T4",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Weapon of Power 4",
                    Description = "A epic weapon imbued with tier 4 enchantments.",
                    BasePrice = 640,
                    PowerRating = 200f,
                    RequiredLevel = 27,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Epic Tier 5
            {
                "Weapon_Epic_T5",
                new ItemData
                {
                    ItemId = "Weapon_Epic_T5",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Weapon of Power 5",
                    Description = "A epic weapon imbued with tier 5 enchantments.",
                    BasePrice = 800,
                    PowerRating = 250f,
                    RequiredLevel = 30,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Epic Tier 6
            {
                "Weapon_Epic_T6",
                new ItemData
                {
                    ItemId = "Weapon_Epic_T6",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Weapon of Power 6",
                    Description = "A epic weapon imbued with tier 6 enchantments.",
                    BasePrice = 960,
                    PowerRating = 300f,
                    RequiredLevel = 33,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Epic Tier 7
            {
                "Weapon_Epic_T7",
                new ItemData
                {
                    ItemId = "Weapon_Epic_T7",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Weapon of Power 7",
                    Description = "A epic weapon imbued with tier 7 enchantments.",
                    BasePrice = 1120,
                    PowerRating = 350f,
                    RequiredLevel = 36,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Epic Tier 8
            {
                "Weapon_Epic_T8",
                new ItemData
                {
                    ItemId = "Weapon_Epic_T8",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Weapon of Power 8",
                    Description = "A epic weapon imbued with tier 8 enchantments.",
                    BasePrice = 1280,
                    PowerRating = 400f,
                    RequiredLevel = 39,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Epic Tier 9
            {
                "Weapon_Epic_T9",
                new ItemData
                {
                    ItemId = "Weapon_Epic_T9",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Weapon of Power 9",
                    Description = "A epic weapon imbued with tier 9 enchantments.",
                    BasePrice = 1440,
                    PowerRating = 450f,
                    RequiredLevel = 42,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Epic Tier 10
            {
                "Weapon_Epic_T10",
                new ItemData
                {
                    ItemId = "Weapon_Epic_T10",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Weapon of Power 10",
                    Description = "A epic weapon imbued with tier 10 enchantments.",
                    BasePrice = 1600,
                    PowerRating = 500f,
                    RequiredLevel = 45,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Legendary Tier 1
            {
                "Weapon_Legendary_T1",
                new ItemData
                {
                    ItemId = "Weapon_Legendary_T1",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Weapon of Power 1",
                    Description = "A legendary weapon imbued with tier 1 enchantments.",
                    BasePrice = 210,
                    PowerRating = 65f,
                    RequiredLevel = 23,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Legendary Tier 2
            {
                "Weapon_Legendary_T2",
                new ItemData
                {
                    ItemId = "Weapon_Legendary_T2",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Weapon of Power 2",
                    Description = "A legendary weapon imbued with tier 2 enchantments.",
                    BasePrice = 420,
                    PowerRating = 130f,
                    RequiredLevel = 26,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Legendary Tier 3
            {
                "Weapon_Legendary_T3",
                new ItemData
                {
                    ItemId = "Weapon_Legendary_T3",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Weapon of Power 3",
                    Description = "A legendary weapon imbued with tier 3 enchantments.",
                    BasePrice = 630,
                    PowerRating = 195f,
                    RequiredLevel = 29,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Legendary Tier 4
            {
                "Weapon_Legendary_T4",
                new ItemData
                {
                    ItemId = "Weapon_Legendary_T4",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Weapon of Power 4",
                    Description = "A legendary weapon imbued with tier 4 enchantments.",
                    BasePrice = 840,
                    PowerRating = 260f,
                    RequiredLevel = 32,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Legendary Tier 5
            {
                "Weapon_Legendary_T5",
                new ItemData
                {
                    ItemId = "Weapon_Legendary_T5",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Weapon of Power 5",
                    Description = "A legendary weapon imbued with tier 5 enchantments.",
                    BasePrice = 1050,
                    PowerRating = 325f,
                    RequiredLevel = 35,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Legendary Tier 6
            {
                "Weapon_Legendary_T6",
                new ItemData
                {
                    ItemId = "Weapon_Legendary_T6",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Weapon of Power 6",
                    Description = "A legendary weapon imbued with tier 6 enchantments.",
                    BasePrice = 1260,
                    PowerRating = 390f,
                    RequiredLevel = 38,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Legendary Tier 7
            {
                "Weapon_Legendary_T7",
                new ItemData
                {
                    ItemId = "Weapon_Legendary_T7",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Weapon of Power 7",
                    Description = "A legendary weapon imbued with tier 7 enchantments.",
                    BasePrice = 1470,
                    PowerRating = 455f,
                    RequiredLevel = 41,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Legendary Tier 8
            {
                "Weapon_Legendary_T8",
                new ItemData
                {
                    ItemId = "Weapon_Legendary_T8",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Weapon of Power 8",
                    Description = "A legendary weapon imbued with tier 8 enchantments.",
                    BasePrice = 1680,
                    PowerRating = 520f,
                    RequiredLevel = 44,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Legendary Tier 9
            {
                "Weapon_Legendary_T9",
                new ItemData
                {
                    ItemId = "Weapon_Legendary_T9",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Weapon of Power 9",
                    Description = "A legendary weapon imbued with tier 9 enchantments.",
                    BasePrice = 1890,
                    PowerRating = 585f,
                    RequiredLevel = 47,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Weapon - Legendary Tier 10
            {
                "Weapon_Legendary_T10",
                new ItemData
                {
                    ItemId = "Weapon_Legendary_T10",
                    Category = ItemCategory.Weapon,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Weapon of Power 10",
                    Description = "A legendary weapon imbued with tier 10 enchantments.",
                    BasePrice = 2100,
                    PowerRating = 650f,
                    RequiredLevel = 50,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Common Tier 1
            {
                "Armor_Common_T1",
                new ItemData
                {
                    ItemId = "Armor_Common_T1",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Armor of Power 1",
                    Description = "A common armor imbued with tier 1 enchantments.",
                    BasePrice = 10,
                    PowerRating = 5f,
                    RequiredLevel = 3,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Common Tier 2
            {
                "Armor_Common_T2",
                new ItemData
                {
                    ItemId = "Armor_Common_T2",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Armor of Power 2",
                    Description = "A common armor imbued with tier 2 enchantments.",
                    BasePrice = 20,
                    PowerRating = 10f,
                    RequiredLevel = 6,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Common Tier 3
            {
                "Armor_Common_T3",
                new ItemData
                {
                    ItemId = "Armor_Common_T3",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Armor of Power 3",
                    Description = "A common armor imbued with tier 3 enchantments.",
                    BasePrice = 30,
                    PowerRating = 15f,
                    RequiredLevel = 9,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Common Tier 4
            {
                "Armor_Common_T4",
                new ItemData
                {
                    ItemId = "Armor_Common_T4",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Armor of Power 4",
                    Description = "A common armor imbued with tier 4 enchantments.",
                    BasePrice = 40,
                    PowerRating = 20f,
                    RequiredLevel = 12,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Common Tier 5
            {
                "Armor_Common_T5",
                new ItemData
                {
                    ItemId = "Armor_Common_T5",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Armor of Power 5",
                    Description = "A common armor imbued with tier 5 enchantments.",
                    BasePrice = 50,
                    PowerRating = 25f,
                    RequiredLevel = 15,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Common Tier 6
            {
                "Armor_Common_T6",
                new ItemData
                {
                    ItemId = "Armor_Common_T6",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Armor of Power 6",
                    Description = "A common armor imbued with tier 6 enchantments.",
                    BasePrice = 60,
                    PowerRating = 30f,
                    RequiredLevel = 18,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Common Tier 7
            {
                "Armor_Common_T7",
                new ItemData
                {
                    ItemId = "Armor_Common_T7",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Armor of Power 7",
                    Description = "A common armor imbued with tier 7 enchantments.",
                    BasePrice = 70,
                    PowerRating = 35f,
                    RequiredLevel = 21,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Common Tier 8
            {
                "Armor_Common_T8",
                new ItemData
                {
                    ItemId = "Armor_Common_T8",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Armor of Power 8",
                    Description = "A common armor imbued with tier 8 enchantments.",
                    BasePrice = 80,
                    PowerRating = 40f,
                    RequiredLevel = 24,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Common Tier 9
            {
                "Armor_Common_T9",
                new ItemData
                {
                    ItemId = "Armor_Common_T9",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Armor of Power 9",
                    Description = "A common armor imbued with tier 9 enchantments.",
                    BasePrice = 90,
                    PowerRating = 45f,
                    RequiredLevel = 27,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Common Tier 10
            {
                "Armor_Common_T10",
                new ItemData
                {
                    ItemId = "Armor_Common_T10",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Armor of Power 10",
                    Description = "A common armor imbued with tier 10 enchantments.",
                    BasePrice = 100,
                    PowerRating = 50f,
                    RequiredLevel = 30,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Uncommon Tier 1
            {
                "Armor_Uncommon_T1",
                new ItemData
                {
                    ItemId = "Armor_Uncommon_T1",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Armor of Power 1",
                    Description = "A uncommon armor imbued with tier 1 enchantments.",
                    BasePrice = 60,
                    PowerRating = 20f,
                    RequiredLevel = 8,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Uncommon Tier 2
            {
                "Armor_Uncommon_T2",
                new ItemData
                {
                    ItemId = "Armor_Uncommon_T2",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Armor of Power 2",
                    Description = "A uncommon armor imbued with tier 2 enchantments.",
                    BasePrice = 120,
                    PowerRating = 40f,
                    RequiredLevel = 11,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Uncommon Tier 3
            {
                "Armor_Uncommon_T3",
                new ItemData
                {
                    ItemId = "Armor_Uncommon_T3",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Armor of Power 3",
                    Description = "A uncommon armor imbued with tier 3 enchantments.",
                    BasePrice = 180,
                    PowerRating = 60f,
                    RequiredLevel = 14,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Uncommon Tier 4
            {
                "Armor_Uncommon_T4",
                new ItemData
                {
                    ItemId = "Armor_Uncommon_T4",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Armor of Power 4",
                    Description = "A uncommon armor imbued with tier 4 enchantments.",
                    BasePrice = 240,
                    PowerRating = 80f,
                    RequiredLevel = 17,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Uncommon Tier 5
            {
                "Armor_Uncommon_T5",
                new ItemData
                {
                    ItemId = "Armor_Uncommon_T5",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Armor of Power 5",
                    Description = "A uncommon armor imbued with tier 5 enchantments.",
                    BasePrice = 300,
                    PowerRating = 100f,
                    RequiredLevel = 20,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Uncommon Tier 6
            {
                "Armor_Uncommon_T6",
                new ItemData
                {
                    ItemId = "Armor_Uncommon_T6",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Armor of Power 6",
                    Description = "A uncommon armor imbued with tier 6 enchantments.",
                    BasePrice = 360,
                    PowerRating = 120f,
                    RequiredLevel = 23,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Uncommon Tier 7
            {
                "Armor_Uncommon_T7",
                new ItemData
                {
                    ItemId = "Armor_Uncommon_T7",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Armor of Power 7",
                    Description = "A uncommon armor imbued with tier 7 enchantments.",
                    BasePrice = 420,
                    PowerRating = 140f,
                    RequiredLevel = 26,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Uncommon Tier 8
            {
                "Armor_Uncommon_T8",
                new ItemData
                {
                    ItemId = "Armor_Uncommon_T8",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Armor of Power 8",
                    Description = "A uncommon armor imbued with tier 8 enchantments.",
                    BasePrice = 480,
                    PowerRating = 160f,
                    RequiredLevel = 29,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Uncommon Tier 9
            {
                "Armor_Uncommon_T9",
                new ItemData
                {
                    ItemId = "Armor_Uncommon_T9",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Armor of Power 9",
                    Description = "A uncommon armor imbued with tier 9 enchantments.",
                    BasePrice = 540,
                    PowerRating = 180f,
                    RequiredLevel = 32,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Uncommon Tier 10
            {
                "Armor_Uncommon_T10",
                new ItemData
                {
                    ItemId = "Armor_Uncommon_T10",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Armor of Power 10",
                    Description = "A uncommon armor imbued with tier 10 enchantments.",
                    BasePrice = 600,
                    PowerRating = 200f,
                    RequiredLevel = 35,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Rare Tier 1
            {
                "Armor_Rare_T1",
                new ItemData
                {
                    ItemId = "Armor_Rare_T1",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Armor of Power 1",
                    Description = "A rare armor imbued with tier 1 enchantments.",
                    BasePrice = 110,
                    PowerRating = 35f,
                    RequiredLevel = 13,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Rare Tier 2
            {
                "Armor_Rare_T2",
                new ItemData
                {
                    ItemId = "Armor_Rare_T2",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Armor of Power 2",
                    Description = "A rare armor imbued with tier 2 enchantments.",
                    BasePrice = 220,
                    PowerRating = 70f,
                    RequiredLevel = 16,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Rare Tier 3
            {
                "Armor_Rare_T3",
                new ItemData
                {
                    ItemId = "Armor_Rare_T3",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Armor of Power 3",
                    Description = "A rare armor imbued with tier 3 enchantments.",
                    BasePrice = 330,
                    PowerRating = 105f,
                    RequiredLevel = 19,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Rare Tier 4
            {
                "Armor_Rare_T4",
                new ItemData
                {
                    ItemId = "Armor_Rare_T4",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Armor of Power 4",
                    Description = "A rare armor imbued with tier 4 enchantments.",
                    BasePrice = 440,
                    PowerRating = 140f,
                    RequiredLevel = 22,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Rare Tier 5
            {
                "Armor_Rare_T5",
                new ItemData
                {
                    ItemId = "Armor_Rare_T5",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Armor of Power 5",
                    Description = "A rare armor imbued with tier 5 enchantments.",
                    BasePrice = 550,
                    PowerRating = 175f,
                    RequiredLevel = 25,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Rare Tier 6
            {
                "Armor_Rare_T6",
                new ItemData
                {
                    ItemId = "Armor_Rare_T6",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Armor of Power 6",
                    Description = "A rare armor imbued with tier 6 enchantments.",
                    BasePrice = 660,
                    PowerRating = 210f,
                    RequiredLevel = 28,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Rare Tier 7
            {
                "Armor_Rare_T7",
                new ItemData
                {
                    ItemId = "Armor_Rare_T7",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Armor of Power 7",
                    Description = "A rare armor imbued with tier 7 enchantments.",
                    BasePrice = 770,
                    PowerRating = 245f,
                    RequiredLevel = 31,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Rare Tier 8
            {
                "Armor_Rare_T8",
                new ItemData
                {
                    ItemId = "Armor_Rare_T8",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Armor of Power 8",
                    Description = "A rare armor imbued with tier 8 enchantments.",
                    BasePrice = 880,
                    PowerRating = 280f,
                    RequiredLevel = 34,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Rare Tier 9
            {
                "Armor_Rare_T9",
                new ItemData
                {
                    ItemId = "Armor_Rare_T9",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Armor of Power 9",
                    Description = "A rare armor imbued with tier 9 enchantments.",
                    BasePrice = 990,
                    PowerRating = 315f,
                    RequiredLevel = 37,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Rare Tier 10
            {
                "Armor_Rare_T10",
                new ItemData
                {
                    ItemId = "Armor_Rare_T10",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Armor of Power 10",
                    Description = "A rare armor imbued with tier 10 enchantments.",
                    BasePrice = 1100,
                    PowerRating = 350f,
                    RequiredLevel = 40,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Epic Tier 1
            {
                "Armor_Epic_T1",
                new ItemData
                {
                    ItemId = "Armor_Epic_T1",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Armor of Power 1",
                    Description = "A epic armor imbued with tier 1 enchantments.",
                    BasePrice = 160,
                    PowerRating = 50f,
                    RequiredLevel = 18,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Epic Tier 2
            {
                "Armor_Epic_T2",
                new ItemData
                {
                    ItemId = "Armor_Epic_T2",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Armor of Power 2",
                    Description = "A epic armor imbued with tier 2 enchantments.",
                    BasePrice = 320,
                    PowerRating = 100f,
                    RequiredLevel = 21,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Epic Tier 3
            {
                "Armor_Epic_T3",
                new ItemData
                {
                    ItemId = "Armor_Epic_T3",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Armor of Power 3",
                    Description = "A epic armor imbued with tier 3 enchantments.",
                    BasePrice = 480,
                    PowerRating = 150f,
                    RequiredLevel = 24,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Epic Tier 4
            {
                "Armor_Epic_T4",
                new ItemData
                {
                    ItemId = "Armor_Epic_T4",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Armor of Power 4",
                    Description = "A epic armor imbued with tier 4 enchantments.",
                    BasePrice = 640,
                    PowerRating = 200f,
                    RequiredLevel = 27,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Epic Tier 5
            {
                "Armor_Epic_T5",
                new ItemData
                {
                    ItemId = "Armor_Epic_T5",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Armor of Power 5",
                    Description = "A epic armor imbued with tier 5 enchantments.",
                    BasePrice = 800,
                    PowerRating = 250f,
                    RequiredLevel = 30,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Epic Tier 6
            {
                "Armor_Epic_T6",
                new ItemData
                {
                    ItemId = "Armor_Epic_T6",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Armor of Power 6",
                    Description = "A epic armor imbued with tier 6 enchantments.",
                    BasePrice = 960,
                    PowerRating = 300f,
                    RequiredLevel = 33,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Epic Tier 7
            {
                "Armor_Epic_T7",
                new ItemData
                {
                    ItemId = "Armor_Epic_T7",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Armor of Power 7",
                    Description = "A epic armor imbued with tier 7 enchantments.",
                    BasePrice = 1120,
                    PowerRating = 350f,
                    RequiredLevel = 36,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Epic Tier 8
            {
                "Armor_Epic_T8",
                new ItemData
                {
                    ItemId = "Armor_Epic_T8",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Armor of Power 8",
                    Description = "A epic armor imbued with tier 8 enchantments.",
                    BasePrice = 1280,
                    PowerRating = 400f,
                    RequiredLevel = 39,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Epic Tier 9
            {
                "Armor_Epic_T9",
                new ItemData
                {
                    ItemId = "Armor_Epic_T9",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Armor of Power 9",
                    Description = "A epic armor imbued with tier 9 enchantments.",
                    BasePrice = 1440,
                    PowerRating = 450f,
                    RequiredLevel = 42,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Epic Tier 10
            {
                "Armor_Epic_T10",
                new ItemData
                {
                    ItemId = "Armor_Epic_T10",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Armor of Power 10",
                    Description = "A epic armor imbued with tier 10 enchantments.",
                    BasePrice = 1600,
                    PowerRating = 500f,
                    RequiredLevel = 45,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Legendary Tier 1
            {
                "Armor_Legendary_T1",
                new ItemData
                {
                    ItemId = "Armor_Legendary_T1",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Armor of Power 1",
                    Description = "A legendary armor imbued with tier 1 enchantments.",
                    BasePrice = 210,
                    PowerRating = 65f,
                    RequiredLevel = 23,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Legendary Tier 2
            {
                "Armor_Legendary_T2",
                new ItemData
                {
                    ItemId = "Armor_Legendary_T2",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Armor of Power 2",
                    Description = "A legendary armor imbued with tier 2 enchantments.",
                    BasePrice = 420,
                    PowerRating = 130f,
                    RequiredLevel = 26,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Legendary Tier 3
            {
                "Armor_Legendary_T3",
                new ItemData
                {
                    ItemId = "Armor_Legendary_T3",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Armor of Power 3",
                    Description = "A legendary armor imbued with tier 3 enchantments.",
                    BasePrice = 630,
                    PowerRating = 195f,
                    RequiredLevel = 29,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Legendary Tier 4
            {
                "Armor_Legendary_T4",
                new ItemData
                {
                    ItemId = "Armor_Legendary_T4",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Armor of Power 4",
                    Description = "A legendary armor imbued with tier 4 enchantments.",
                    BasePrice = 840,
                    PowerRating = 260f,
                    RequiredLevel = 32,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Legendary Tier 5
            {
                "Armor_Legendary_T5",
                new ItemData
                {
                    ItemId = "Armor_Legendary_T5",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Armor of Power 5",
                    Description = "A legendary armor imbued with tier 5 enchantments.",
                    BasePrice = 1050,
                    PowerRating = 325f,
                    RequiredLevel = 35,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Legendary Tier 6
            {
                "Armor_Legendary_T6",
                new ItemData
                {
                    ItemId = "Armor_Legendary_T6",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Armor of Power 6",
                    Description = "A legendary armor imbued with tier 6 enchantments.",
                    BasePrice = 1260,
                    PowerRating = 390f,
                    RequiredLevel = 38,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Legendary Tier 7
            {
                "Armor_Legendary_T7",
                new ItemData
                {
                    ItemId = "Armor_Legendary_T7",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Armor of Power 7",
                    Description = "A legendary armor imbued with tier 7 enchantments.",
                    BasePrice = 1470,
                    PowerRating = 455f,
                    RequiredLevel = 41,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Legendary Tier 8
            {
                "Armor_Legendary_T8",
                new ItemData
                {
                    ItemId = "Armor_Legendary_T8",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Armor of Power 8",
                    Description = "A legendary armor imbued with tier 8 enchantments.",
                    BasePrice = 1680,
                    PowerRating = 520f,
                    RequiredLevel = 44,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Legendary Tier 9
            {
                "Armor_Legendary_T9",
                new ItemData
                {
                    ItemId = "Armor_Legendary_T9",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Armor of Power 9",
                    Description = "A legendary armor imbued with tier 9 enchantments.",
                    BasePrice = 1890,
                    PowerRating = 585f,
                    RequiredLevel = 47,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Armor - Legendary Tier 10
            {
                "Armor_Legendary_T10",
                new ItemData
                {
                    ItemId = "Armor_Legendary_T10",
                    Category = ItemCategory.Armor,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Armor of Power 10",
                    Description = "A legendary armor imbued with tier 10 enchantments.",
                    BasePrice = 2100,
                    PowerRating = 650f,
                    RequiredLevel = 50,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Potion - Common Tier 1
            {
                "Potion_Common_T1",
                new ItemData
                {
                    ItemId = "Potion_Common_T1",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Potion of Power 1",
                    Description = "A common potion imbued with tier 1 enchantments.",
                    BasePrice = 10,
                    PowerRating = 5f,
                    RequiredLevel = 3,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Common Tier 2
            {
                "Potion_Common_T2",
                new ItemData
                {
                    ItemId = "Potion_Common_T2",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Potion of Power 2",
                    Description = "A common potion imbued with tier 2 enchantments.",
                    BasePrice = 20,
                    PowerRating = 10f,
                    RequiredLevel = 6,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Common Tier 3
            {
                "Potion_Common_T3",
                new ItemData
                {
                    ItemId = "Potion_Common_T3",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Potion of Power 3",
                    Description = "A common potion imbued with tier 3 enchantments.",
                    BasePrice = 30,
                    PowerRating = 15f,
                    RequiredLevel = 9,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Common Tier 4
            {
                "Potion_Common_T4",
                new ItemData
                {
                    ItemId = "Potion_Common_T4",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Potion of Power 4",
                    Description = "A common potion imbued with tier 4 enchantments.",
                    BasePrice = 40,
                    PowerRating = 20f,
                    RequiredLevel = 12,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Common Tier 5
            {
                "Potion_Common_T5",
                new ItemData
                {
                    ItemId = "Potion_Common_T5",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Potion of Power 5",
                    Description = "A common potion imbued with tier 5 enchantments.",
                    BasePrice = 50,
                    PowerRating = 25f,
                    RequiredLevel = 15,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Common Tier 6
            {
                "Potion_Common_T6",
                new ItemData
                {
                    ItemId = "Potion_Common_T6",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Potion of Power 6",
                    Description = "A common potion imbued with tier 6 enchantments.",
                    BasePrice = 60,
                    PowerRating = 30f,
                    RequiredLevel = 18,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Common Tier 7
            {
                "Potion_Common_T7",
                new ItemData
                {
                    ItemId = "Potion_Common_T7",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Potion of Power 7",
                    Description = "A common potion imbued with tier 7 enchantments.",
                    BasePrice = 70,
                    PowerRating = 35f,
                    RequiredLevel = 21,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Common Tier 8
            {
                "Potion_Common_T8",
                new ItemData
                {
                    ItemId = "Potion_Common_T8",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Potion of Power 8",
                    Description = "A common potion imbued with tier 8 enchantments.",
                    BasePrice = 80,
                    PowerRating = 40f,
                    RequiredLevel = 24,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Common Tier 9
            {
                "Potion_Common_T9",
                new ItemData
                {
                    ItemId = "Potion_Common_T9",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Potion of Power 9",
                    Description = "A common potion imbued with tier 9 enchantments.",
                    BasePrice = 90,
                    PowerRating = 45f,
                    RequiredLevel = 27,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Common Tier 10
            {
                "Potion_Common_T10",
                new ItemData
                {
                    ItemId = "Potion_Common_T10",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Potion of Power 10",
                    Description = "A common potion imbued with tier 10 enchantments.",
                    BasePrice = 100,
                    PowerRating = 50f,
                    RequiredLevel = 30,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Uncommon Tier 1
            {
                "Potion_Uncommon_T1",
                new ItemData
                {
                    ItemId = "Potion_Uncommon_T1",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Potion of Power 1",
                    Description = "A uncommon potion imbued with tier 1 enchantments.",
                    BasePrice = 60,
                    PowerRating = 20f,
                    RequiredLevel = 8,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Uncommon Tier 2
            {
                "Potion_Uncommon_T2",
                new ItemData
                {
                    ItemId = "Potion_Uncommon_T2",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Potion of Power 2",
                    Description = "A uncommon potion imbued with tier 2 enchantments.",
                    BasePrice = 120,
                    PowerRating = 40f,
                    RequiredLevel = 11,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Uncommon Tier 3
            {
                "Potion_Uncommon_T3",
                new ItemData
                {
                    ItemId = "Potion_Uncommon_T3",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Potion of Power 3",
                    Description = "A uncommon potion imbued with tier 3 enchantments.",
                    BasePrice = 180,
                    PowerRating = 60f,
                    RequiredLevel = 14,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Uncommon Tier 4
            {
                "Potion_Uncommon_T4",
                new ItemData
                {
                    ItemId = "Potion_Uncommon_T4",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Potion of Power 4",
                    Description = "A uncommon potion imbued with tier 4 enchantments.",
                    BasePrice = 240,
                    PowerRating = 80f,
                    RequiredLevel = 17,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Uncommon Tier 5
            {
                "Potion_Uncommon_T5",
                new ItemData
                {
                    ItemId = "Potion_Uncommon_T5",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Potion of Power 5",
                    Description = "A uncommon potion imbued with tier 5 enchantments.",
                    BasePrice = 300,
                    PowerRating = 100f,
                    RequiredLevel = 20,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Uncommon Tier 6
            {
                "Potion_Uncommon_T6",
                new ItemData
                {
                    ItemId = "Potion_Uncommon_T6",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Potion of Power 6",
                    Description = "A uncommon potion imbued with tier 6 enchantments.",
                    BasePrice = 360,
                    PowerRating = 120f,
                    RequiredLevel = 23,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Uncommon Tier 7
            {
                "Potion_Uncommon_T7",
                new ItemData
                {
                    ItemId = "Potion_Uncommon_T7",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Potion of Power 7",
                    Description = "A uncommon potion imbued with tier 7 enchantments.",
                    BasePrice = 420,
                    PowerRating = 140f,
                    RequiredLevel = 26,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Uncommon Tier 8
            {
                "Potion_Uncommon_T8",
                new ItemData
                {
                    ItemId = "Potion_Uncommon_T8",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Potion of Power 8",
                    Description = "A uncommon potion imbued with tier 8 enchantments.",
                    BasePrice = 480,
                    PowerRating = 160f,
                    RequiredLevel = 29,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Uncommon Tier 9
            {
                "Potion_Uncommon_T9",
                new ItemData
                {
                    ItemId = "Potion_Uncommon_T9",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Potion of Power 9",
                    Description = "A uncommon potion imbued with tier 9 enchantments.",
                    BasePrice = 540,
                    PowerRating = 180f,
                    RequiredLevel = 32,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Uncommon Tier 10
            {
                "Potion_Uncommon_T10",
                new ItemData
                {
                    ItemId = "Potion_Uncommon_T10",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Potion of Power 10",
                    Description = "A uncommon potion imbued with tier 10 enchantments.",
                    BasePrice = 600,
                    PowerRating = 200f,
                    RequiredLevel = 35,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Rare Tier 1
            {
                "Potion_Rare_T1",
                new ItemData
                {
                    ItemId = "Potion_Rare_T1",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Potion of Power 1",
                    Description = "A rare potion imbued with tier 1 enchantments.",
                    BasePrice = 110,
                    PowerRating = 35f,
                    RequiredLevel = 13,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Rare Tier 2
            {
                "Potion_Rare_T2",
                new ItemData
                {
                    ItemId = "Potion_Rare_T2",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Potion of Power 2",
                    Description = "A rare potion imbued with tier 2 enchantments.",
                    BasePrice = 220,
                    PowerRating = 70f,
                    RequiredLevel = 16,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Rare Tier 3
            {
                "Potion_Rare_T3",
                new ItemData
                {
                    ItemId = "Potion_Rare_T3",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Potion of Power 3",
                    Description = "A rare potion imbued with tier 3 enchantments.",
                    BasePrice = 330,
                    PowerRating = 105f,
                    RequiredLevel = 19,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Rare Tier 4
            {
                "Potion_Rare_T4",
                new ItemData
                {
                    ItemId = "Potion_Rare_T4",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Potion of Power 4",
                    Description = "A rare potion imbued with tier 4 enchantments.",
                    BasePrice = 440,
                    PowerRating = 140f,
                    RequiredLevel = 22,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Rare Tier 5
            {
                "Potion_Rare_T5",
                new ItemData
                {
                    ItemId = "Potion_Rare_T5",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Potion of Power 5",
                    Description = "A rare potion imbued with tier 5 enchantments.",
                    BasePrice = 550,
                    PowerRating = 175f,
                    RequiredLevel = 25,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Rare Tier 6
            {
                "Potion_Rare_T6",
                new ItemData
                {
                    ItemId = "Potion_Rare_T6",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Potion of Power 6",
                    Description = "A rare potion imbued with tier 6 enchantments.",
                    BasePrice = 660,
                    PowerRating = 210f,
                    RequiredLevel = 28,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Rare Tier 7
            {
                "Potion_Rare_T7",
                new ItemData
                {
                    ItemId = "Potion_Rare_T7",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Potion of Power 7",
                    Description = "A rare potion imbued with tier 7 enchantments.",
                    BasePrice = 770,
                    PowerRating = 245f,
                    RequiredLevel = 31,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Rare Tier 8
            {
                "Potion_Rare_T8",
                new ItemData
                {
                    ItemId = "Potion_Rare_T8",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Potion of Power 8",
                    Description = "A rare potion imbued with tier 8 enchantments.",
                    BasePrice = 880,
                    PowerRating = 280f,
                    RequiredLevel = 34,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Rare Tier 9
            {
                "Potion_Rare_T9",
                new ItemData
                {
                    ItemId = "Potion_Rare_T9",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Potion of Power 9",
                    Description = "A rare potion imbued with tier 9 enchantments.",
                    BasePrice = 990,
                    PowerRating = 315f,
                    RequiredLevel = 37,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Rare Tier 10
            {
                "Potion_Rare_T10",
                new ItemData
                {
                    ItemId = "Potion_Rare_T10",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Potion of Power 10",
                    Description = "A rare potion imbued with tier 10 enchantments.",
                    BasePrice = 1100,
                    PowerRating = 350f,
                    RequiredLevel = 40,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Epic Tier 1
            {
                "Potion_Epic_T1",
                new ItemData
                {
                    ItemId = "Potion_Epic_T1",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Potion of Power 1",
                    Description = "A epic potion imbued with tier 1 enchantments.",
                    BasePrice = 160,
                    PowerRating = 50f,
                    RequiredLevel = 18,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Epic Tier 2
            {
                "Potion_Epic_T2",
                new ItemData
                {
                    ItemId = "Potion_Epic_T2",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Potion of Power 2",
                    Description = "A epic potion imbued with tier 2 enchantments.",
                    BasePrice = 320,
                    PowerRating = 100f,
                    RequiredLevel = 21,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Epic Tier 3
            {
                "Potion_Epic_T3",
                new ItemData
                {
                    ItemId = "Potion_Epic_T3",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Potion of Power 3",
                    Description = "A epic potion imbued with tier 3 enchantments.",
                    BasePrice = 480,
                    PowerRating = 150f,
                    RequiredLevel = 24,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Epic Tier 4
            {
                "Potion_Epic_T4",
                new ItemData
                {
                    ItemId = "Potion_Epic_T4",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Potion of Power 4",
                    Description = "A epic potion imbued with tier 4 enchantments.",
                    BasePrice = 640,
                    PowerRating = 200f,
                    RequiredLevel = 27,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Epic Tier 5
            {
                "Potion_Epic_T5",
                new ItemData
                {
                    ItemId = "Potion_Epic_T5",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Potion of Power 5",
                    Description = "A epic potion imbued with tier 5 enchantments.",
                    BasePrice = 800,
                    PowerRating = 250f,
                    RequiredLevel = 30,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Epic Tier 6
            {
                "Potion_Epic_T6",
                new ItemData
                {
                    ItemId = "Potion_Epic_T6",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Potion of Power 6",
                    Description = "A epic potion imbued with tier 6 enchantments.",
                    BasePrice = 960,
                    PowerRating = 300f,
                    RequiredLevel = 33,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Epic Tier 7
            {
                "Potion_Epic_T7",
                new ItemData
                {
                    ItemId = "Potion_Epic_T7",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Potion of Power 7",
                    Description = "A epic potion imbued with tier 7 enchantments.",
                    BasePrice = 1120,
                    PowerRating = 350f,
                    RequiredLevel = 36,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Epic Tier 8
            {
                "Potion_Epic_T8",
                new ItemData
                {
                    ItemId = "Potion_Epic_T8",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Potion of Power 8",
                    Description = "A epic potion imbued with tier 8 enchantments.",
                    BasePrice = 1280,
                    PowerRating = 400f,
                    RequiredLevel = 39,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Epic Tier 9
            {
                "Potion_Epic_T9",
                new ItemData
                {
                    ItemId = "Potion_Epic_T9",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Potion of Power 9",
                    Description = "A epic potion imbued with tier 9 enchantments.",
                    BasePrice = 1440,
                    PowerRating = 450f,
                    RequiredLevel = 42,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Epic Tier 10
            {
                "Potion_Epic_T10",
                new ItemData
                {
                    ItemId = "Potion_Epic_T10",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Potion of Power 10",
                    Description = "A epic potion imbued with tier 10 enchantments.",
                    BasePrice = 1600,
                    PowerRating = 500f,
                    RequiredLevel = 45,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Legendary Tier 1
            {
                "Potion_Legendary_T1",
                new ItemData
                {
                    ItemId = "Potion_Legendary_T1",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Potion of Power 1",
                    Description = "A legendary potion imbued with tier 1 enchantments.",
                    BasePrice = 210,
                    PowerRating = 65f,
                    RequiredLevel = 23,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Legendary Tier 2
            {
                "Potion_Legendary_T2",
                new ItemData
                {
                    ItemId = "Potion_Legendary_T2",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Potion of Power 2",
                    Description = "A legendary potion imbued with tier 2 enchantments.",
                    BasePrice = 420,
                    PowerRating = 130f,
                    RequiredLevel = 26,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Legendary Tier 3
            {
                "Potion_Legendary_T3",
                new ItemData
                {
                    ItemId = "Potion_Legendary_T3",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Potion of Power 3",
                    Description = "A legendary potion imbued with tier 3 enchantments.",
                    BasePrice = 630,
                    PowerRating = 195f,
                    RequiredLevel = 29,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Legendary Tier 4
            {
                "Potion_Legendary_T4",
                new ItemData
                {
                    ItemId = "Potion_Legendary_T4",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Potion of Power 4",
                    Description = "A legendary potion imbued with tier 4 enchantments.",
                    BasePrice = 840,
                    PowerRating = 260f,
                    RequiredLevel = 32,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Legendary Tier 5
            {
                "Potion_Legendary_T5",
                new ItemData
                {
                    ItemId = "Potion_Legendary_T5",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Potion of Power 5",
                    Description = "A legendary potion imbued with tier 5 enchantments.",
                    BasePrice = 1050,
                    PowerRating = 325f,
                    RequiredLevel = 35,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Legendary Tier 6
            {
                "Potion_Legendary_T6",
                new ItemData
                {
                    ItemId = "Potion_Legendary_T6",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Potion of Power 6",
                    Description = "A legendary potion imbued with tier 6 enchantments.",
                    BasePrice = 1260,
                    PowerRating = 390f,
                    RequiredLevel = 38,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Legendary Tier 7
            {
                "Potion_Legendary_T7",
                new ItemData
                {
                    ItemId = "Potion_Legendary_T7",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Potion of Power 7",
                    Description = "A legendary potion imbued with tier 7 enchantments.",
                    BasePrice = 1470,
                    PowerRating = 455f,
                    RequiredLevel = 41,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Legendary Tier 8
            {
                "Potion_Legendary_T8",
                new ItemData
                {
                    ItemId = "Potion_Legendary_T8",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Potion of Power 8",
                    Description = "A legendary potion imbued with tier 8 enchantments.",
                    BasePrice = 1680,
                    PowerRating = 520f,
                    RequiredLevel = 44,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Legendary Tier 9
            {
                "Potion_Legendary_T9",
                new ItemData
                {
                    ItemId = "Potion_Legendary_T9",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Potion of Power 9",
                    Description = "A legendary potion imbued with tier 9 enchantments.",
                    BasePrice = 1890,
                    PowerRating = 585f,
                    RequiredLevel = 47,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Potion - Legendary Tier 10
            {
                "Potion_Legendary_T10",
                new ItemData
                {
                    ItemId = "Potion_Legendary_T10",
                    Category = ItemCategory.Potion,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Potion of Power 10",
                    Description = "A legendary potion imbued with tier 10 enchantments.",
                    BasePrice = 2100,
                    PowerRating = 650f,
                    RequiredLevel = 50,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Common Tier 1
            {
                "Scroll_Common_T1",
                new ItemData
                {
                    ItemId = "Scroll_Common_T1",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Scroll of Power 1",
                    Description = "A common scroll imbued with tier 1 enchantments.",
                    BasePrice = 10,
                    PowerRating = 5f,
                    RequiredLevel = 3,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Common Tier 2
            {
                "Scroll_Common_T2",
                new ItemData
                {
                    ItemId = "Scroll_Common_T2",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Scroll of Power 2",
                    Description = "A common scroll imbued with tier 2 enchantments.",
                    BasePrice = 20,
                    PowerRating = 10f,
                    RequiredLevel = 6,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Common Tier 3
            {
                "Scroll_Common_T3",
                new ItemData
                {
                    ItemId = "Scroll_Common_T3",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Scroll of Power 3",
                    Description = "A common scroll imbued with tier 3 enchantments.",
                    BasePrice = 30,
                    PowerRating = 15f,
                    RequiredLevel = 9,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Common Tier 4
            {
                "Scroll_Common_T4",
                new ItemData
                {
                    ItemId = "Scroll_Common_T4",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Scroll of Power 4",
                    Description = "A common scroll imbued with tier 4 enchantments.",
                    BasePrice = 40,
                    PowerRating = 20f,
                    RequiredLevel = 12,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Common Tier 5
            {
                "Scroll_Common_T5",
                new ItemData
                {
                    ItemId = "Scroll_Common_T5",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Scroll of Power 5",
                    Description = "A common scroll imbued with tier 5 enchantments.",
                    BasePrice = 50,
                    PowerRating = 25f,
                    RequiredLevel = 15,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Common Tier 6
            {
                "Scroll_Common_T6",
                new ItemData
                {
                    ItemId = "Scroll_Common_T6",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Scroll of Power 6",
                    Description = "A common scroll imbued with tier 6 enchantments.",
                    BasePrice = 60,
                    PowerRating = 30f,
                    RequiredLevel = 18,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Common Tier 7
            {
                "Scroll_Common_T7",
                new ItemData
                {
                    ItemId = "Scroll_Common_T7",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Scroll of Power 7",
                    Description = "A common scroll imbued with tier 7 enchantments.",
                    BasePrice = 70,
                    PowerRating = 35f,
                    RequiredLevel = 21,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Common Tier 8
            {
                "Scroll_Common_T8",
                new ItemData
                {
                    ItemId = "Scroll_Common_T8",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Scroll of Power 8",
                    Description = "A common scroll imbued with tier 8 enchantments.",
                    BasePrice = 80,
                    PowerRating = 40f,
                    RequiredLevel = 24,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Common Tier 9
            {
                "Scroll_Common_T9",
                new ItemData
                {
                    ItemId = "Scroll_Common_T9",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Scroll of Power 9",
                    Description = "A common scroll imbued with tier 9 enchantments.",
                    BasePrice = 90,
                    PowerRating = 45f,
                    RequiredLevel = 27,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Common Tier 10
            {
                "Scroll_Common_T10",
                new ItemData
                {
                    ItemId = "Scroll_Common_T10",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Scroll of Power 10",
                    Description = "A common scroll imbued with tier 10 enchantments.",
                    BasePrice = 100,
                    PowerRating = 50f,
                    RequiredLevel = 30,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Uncommon Tier 1
            {
                "Scroll_Uncommon_T1",
                new ItemData
                {
                    ItemId = "Scroll_Uncommon_T1",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Scroll of Power 1",
                    Description = "A uncommon scroll imbued with tier 1 enchantments.",
                    BasePrice = 60,
                    PowerRating = 20f,
                    RequiredLevel = 8,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Uncommon Tier 2
            {
                "Scroll_Uncommon_T2",
                new ItemData
                {
                    ItemId = "Scroll_Uncommon_T2",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Scroll of Power 2",
                    Description = "A uncommon scroll imbued with tier 2 enchantments.",
                    BasePrice = 120,
                    PowerRating = 40f,
                    RequiredLevel = 11,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Uncommon Tier 3
            {
                "Scroll_Uncommon_T3",
                new ItemData
                {
                    ItemId = "Scroll_Uncommon_T3",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Scroll of Power 3",
                    Description = "A uncommon scroll imbued with tier 3 enchantments.",
                    BasePrice = 180,
                    PowerRating = 60f,
                    RequiredLevel = 14,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Uncommon Tier 4
            {
                "Scroll_Uncommon_T4",
                new ItemData
                {
                    ItemId = "Scroll_Uncommon_T4",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Scroll of Power 4",
                    Description = "A uncommon scroll imbued with tier 4 enchantments.",
                    BasePrice = 240,
                    PowerRating = 80f,
                    RequiredLevel = 17,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Uncommon Tier 5
            {
                "Scroll_Uncommon_T5",
                new ItemData
                {
                    ItemId = "Scroll_Uncommon_T5",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Scroll of Power 5",
                    Description = "A uncommon scroll imbued with tier 5 enchantments.",
                    BasePrice = 300,
                    PowerRating = 100f,
                    RequiredLevel = 20,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Uncommon Tier 6
            {
                "Scroll_Uncommon_T6",
                new ItemData
                {
                    ItemId = "Scroll_Uncommon_T6",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Scroll of Power 6",
                    Description = "A uncommon scroll imbued with tier 6 enchantments.",
                    BasePrice = 360,
                    PowerRating = 120f,
                    RequiredLevel = 23,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Uncommon Tier 7
            {
                "Scroll_Uncommon_T7",
                new ItemData
                {
                    ItemId = "Scroll_Uncommon_T7",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Scroll of Power 7",
                    Description = "A uncommon scroll imbued with tier 7 enchantments.",
                    BasePrice = 420,
                    PowerRating = 140f,
                    RequiredLevel = 26,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Uncommon Tier 8
            {
                "Scroll_Uncommon_T8",
                new ItemData
                {
                    ItemId = "Scroll_Uncommon_T8",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Scroll of Power 8",
                    Description = "A uncommon scroll imbued with tier 8 enchantments.",
                    BasePrice = 480,
                    PowerRating = 160f,
                    RequiredLevel = 29,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Uncommon Tier 9
            {
                "Scroll_Uncommon_T9",
                new ItemData
                {
                    ItemId = "Scroll_Uncommon_T9",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Scroll of Power 9",
                    Description = "A uncommon scroll imbued with tier 9 enchantments.",
                    BasePrice = 540,
                    PowerRating = 180f,
                    RequiredLevel = 32,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Uncommon Tier 10
            {
                "Scroll_Uncommon_T10",
                new ItemData
                {
                    ItemId = "Scroll_Uncommon_T10",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Scroll of Power 10",
                    Description = "A uncommon scroll imbued with tier 10 enchantments.",
                    BasePrice = 600,
                    PowerRating = 200f,
                    RequiredLevel = 35,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Rare Tier 1
            {
                "Scroll_Rare_T1",
                new ItemData
                {
                    ItemId = "Scroll_Rare_T1",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Scroll of Power 1",
                    Description = "A rare scroll imbued with tier 1 enchantments.",
                    BasePrice = 110,
                    PowerRating = 35f,
                    RequiredLevel = 13,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Rare Tier 2
            {
                "Scroll_Rare_T2",
                new ItemData
                {
                    ItemId = "Scroll_Rare_T2",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Scroll of Power 2",
                    Description = "A rare scroll imbued with tier 2 enchantments.",
                    BasePrice = 220,
                    PowerRating = 70f,
                    RequiredLevel = 16,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Rare Tier 3
            {
                "Scroll_Rare_T3",
                new ItemData
                {
                    ItemId = "Scroll_Rare_T3",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Scroll of Power 3",
                    Description = "A rare scroll imbued with tier 3 enchantments.",
                    BasePrice = 330,
                    PowerRating = 105f,
                    RequiredLevel = 19,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Rare Tier 4
            {
                "Scroll_Rare_T4",
                new ItemData
                {
                    ItemId = "Scroll_Rare_T4",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Scroll of Power 4",
                    Description = "A rare scroll imbued with tier 4 enchantments.",
                    BasePrice = 440,
                    PowerRating = 140f,
                    RequiredLevel = 22,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Rare Tier 5
            {
                "Scroll_Rare_T5",
                new ItemData
                {
                    ItemId = "Scroll_Rare_T5",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Scroll of Power 5",
                    Description = "A rare scroll imbued with tier 5 enchantments.",
                    BasePrice = 550,
                    PowerRating = 175f,
                    RequiredLevel = 25,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Rare Tier 6
            {
                "Scroll_Rare_T6",
                new ItemData
                {
                    ItemId = "Scroll_Rare_T6",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Scroll of Power 6",
                    Description = "A rare scroll imbued with tier 6 enchantments.",
                    BasePrice = 660,
                    PowerRating = 210f,
                    RequiredLevel = 28,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Rare Tier 7
            {
                "Scroll_Rare_T7",
                new ItemData
                {
                    ItemId = "Scroll_Rare_T7",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Scroll of Power 7",
                    Description = "A rare scroll imbued with tier 7 enchantments.",
                    BasePrice = 770,
                    PowerRating = 245f,
                    RequiredLevel = 31,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Rare Tier 8
            {
                "Scroll_Rare_T8",
                new ItemData
                {
                    ItemId = "Scroll_Rare_T8",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Scroll of Power 8",
                    Description = "A rare scroll imbued with tier 8 enchantments.",
                    BasePrice = 880,
                    PowerRating = 280f,
                    RequiredLevel = 34,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Rare Tier 9
            {
                "Scroll_Rare_T9",
                new ItemData
                {
                    ItemId = "Scroll_Rare_T9",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Scroll of Power 9",
                    Description = "A rare scroll imbued with tier 9 enchantments.",
                    BasePrice = 990,
                    PowerRating = 315f,
                    RequiredLevel = 37,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Rare Tier 10
            {
                "Scroll_Rare_T10",
                new ItemData
                {
                    ItemId = "Scroll_Rare_T10",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Scroll of Power 10",
                    Description = "A rare scroll imbued with tier 10 enchantments.",
                    BasePrice = 1100,
                    PowerRating = 350f,
                    RequiredLevel = 40,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Epic Tier 1
            {
                "Scroll_Epic_T1",
                new ItemData
                {
                    ItemId = "Scroll_Epic_T1",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Scroll of Power 1",
                    Description = "A epic scroll imbued with tier 1 enchantments.",
                    BasePrice = 160,
                    PowerRating = 50f,
                    RequiredLevel = 18,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Epic Tier 2
            {
                "Scroll_Epic_T2",
                new ItemData
                {
                    ItemId = "Scroll_Epic_T2",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Scroll of Power 2",
                    Description = "A epic scroll imbued with tier 2 enchantments.",
                    BasePrice = 320,
                    PowerRating = 100f,
                    RequiredLevel = 21,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Epic Tier 3
            {
                "Scroll_Epic_T3",
                new ItemData
                {
                    ItemId = "Scroll_Epic_T3",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Scroll of Power 3",
                    Description = "A epic scroll imbued with tier 3 enchantments.",
                    BasePrice = 480,
                    PowerRating = 150f,
                    RequiredLevel = 24,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Epic Tier 4
            {
                "Scroll_Epic_T4",
                new ItemData
                {
                    ItemId = "Scroll_Epic_T4",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Scroll of Power 4",
                    Description = "A epic scroll imbued with tier 4 enchantments.",
                    BasePrice = 640,
                    PowerRating = 200f,
                    RequiredLevel = 27,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Epic Tier 5
            {
                "Scroll_Epic_T5",
                new ItemData
                {
                    ItemId = "Scroll_Epic_T5",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Scroll of Power 5",
                    Description = "A epic scroll imbued with tier 5 enchantments.",
                    BasePrice = 800,
                    PowerRating = 250f,
                    RequiredLevel = 30,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Epic Tier 6
            {
                "Scroll_Epic_T6",
                new ItemData
                {
                    ItemId = "Scroll_Epic_T6",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Scroll of Power 6",
                    Description = "A epic scroll imbued with tier 6 enchantments.",
                    BasePrice = 960,
                    PowerRating = 300f,
                    RequiredLevel = 33,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Epic Tier 7
            {
                "Scroll_Epic_T7",
                new ItemData
                {
                    ItemId = "Scroll_Epic_T7",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Scroll of Power 7",
                    Description = "A epic scroll imbued with tier 7 enchantments.",
                    BasePrice = 1120,
                    PowerRating = 350f,
                    RequiredLevel = 36,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Epic Tier 8
            {
                "Scroll_Epic_T8",
                new ItemData
                {
                    ItemId = "Scroll_Epic_T8",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Scroll of Power 8",
                    Description = "A epic scroll imbued with tier 8 enchantments.",
                    BasePrice = 1280,
                    PowerRating = 400f,
                    RequiredLevel = 39,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Epic Tier 9
            {
                "Scroll_Epic_T9",
                new ItemData
                {
                    ItemId = "Scroll_Epic_T9",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Scroll of Power 9",
                    Description = "A epic scroll imbued with tier 9 enchantments.",
                    BasePrice = 1440,
                    PowerRating = 450f,
                    RequiredLevel = 42,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Epic Tier 10
            {
                "Scroll_Epic_T10",
                new ItemData
                {
                    ItemId = "Scroll_Epic_T10",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Scroll of Power 10",
                    Description = "A epic scroll imbued with tier 10 enchantments.",
                    BasePrice = 1600,
                    PowerRating = 500f,
                    RequiredLevel = 45,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Legendary Tier 1
            {
                "Scroll_Legendary_T1",
                new ItemData
                {
                    ItemId = "Scroll_Legendary_T1",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Scroll of Power 1",
                    Description = "A legendary scroll imbued with tier 1 enchantments.",
                    BasePrice = 210,
                    PowerRating = 65f,
                    RequiredLevel = 23,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Legendary Tier 2
            {
                "Scroll_Legendary_T2",
                new ItemData
                {
                    ItemId = "Scroll_Legendary_T2",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Scroll of Power 2",
                    Description = "A legendary scroll imbued with tier 2 enchantments.",
                    BasePrice = 420,
                    PowerRating = 130f,
                    RequiredLevel = 26,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Legendary Tier 3
            {
                "Scroll_Legendary_T3",
                new ItemData
                {
                    ItemId = "Scroll_Legendary_T3",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Scroll of Power 3",
                    Description = "A legendary scroll imbued with tier 3 enchantments.",
                    BasePrice = 630,
                    PowerRating = 195f,
                    RequiredLevel = 29,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Legendary Tier 4
            {
                "Scroll_Legendary_T4",
                new ItemData
                {
                    ItemId = "Scroll_Legendary_T4",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Scroll of Power 4",
                    Description = "A legendary scroll imbued with tier 4 enchantments.",
                    BasePrice = 840,
                    PowerRating = 260f,
                    RequiredLevel = 32,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Legendary Tier 5
            {
                "Scroll_Legendary_T5",
                new ItemData
                {
                    ItemId = "Scroll_Legendary_T5",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Scroll of Power 5",
                    Description = "A legendary scroll imbued with tier 5 enchantments.",
                    BasePrice = 1050,
                    PowerRating = 325f,
                    RequiredLevel = 35,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Legendary Tier 6
            {
                "Scroll_Legendary_T6",
                new ItemData
                {
                    ItemId = "Scroll_Legendary_T6",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Scroll of Power 6",
                    Description = "A legendary scroll imbued with tier 6 enchantments.",
                    BasePrice = 1260,
                    PowerRating = 390f,
                    RequiredLevel = 38,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Legendary Tier 7
            {
                "Scroll_Legendary_T7",
                new ItemData
                {
                    ItemId = "Scroll_Legendary_T7",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Scroll of Power 7",
                    Description = "A legendary scroll imbued with tier 7 enchantments.",
                    BasePrice = 1470,
                    PowerRating = 455f,
                    RequiredLevel = 41,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Legendary Tier 8
            {
                "Scroll_Legendary_T8",
                new ItemData
                {
                    ItemId = "Scroll_Legendary_T8",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Scroll of Power 8",
                    Description = "A legendary scroll imbued with tier 8 enchantments.",
                    BasePrice = 1680,
                    PowerRating = 520f,
                    RequiredLevel = 44,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Legendary Tier 9
            {
                "Scroll_Legendary_T9",
                new ItemData
                {
                    ItemId = "Scroll_Legendary_T9",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Scroll of Power 9",
                    Description = "A legendary scroll imbued with tier 9 enchantments.",
                    BasePrice = 1890,
                    PowerRating = 585f,
                    RequiredLevel = 47,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Scroll - Legendary Tier 10
            {
                "Scroll_Legendary_T10",
                new ItemData
                {
                    ItemId = "Scroll_Legendary_T10",
                    Category = ItemCategory.Scroll,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Scroll of Power 10",
                    Description = "A legendary scroll imbued with tier 10 enchantments.",
                    BasePrice = 2100,
                    PowerRating = 650f,
                    RequiredLevel = 50,
                    IsStackable = true,
                    MaxStackSize = 99,
                }
            },
            // Ring - Common Tier 1
            {
                "Ring_Common_T1",
                new ItemData
                {
                    ItemId = "Ring_Common_T1",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Ring of Power 1",
                    Description = "A common ring imbued with tier 1 enchantments.",
                    BasePrice = 10,
                    PowerRating = 5f,
                    RequiredLevel = 3,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Common Tier 2
            {
                "Ring_Common_T2",
                new ItemData
                {
                    ItemId = "Ring_Common_T2",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Ring of Power 2",
                    Description = "A common ring imbued with tier 2 enchantments.",
                    BasePrice = 20,
                    PowerRating = 10f,
                    RequiredLevel = 6,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Common Tier 3
            {
                "Ring_Common_T3",
                new ItemData
                {
                    ItemId = "Ring_Common_T3",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Ring of Power 3",
                    Description = "A common ring imbued with tier 3 enchantments.",
                    BasePrice = 30,
                    PowerRating = 15f,
                    RequiredLevel = 9,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Common Tier 4
            {
                "Ring_Common_T4",
                new ItemData
                {
                    ItemId = "Ring_Common_T4",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Ring of Power 4",
                    Description = "A common ring imbued with tier 4 enchantments.",
                    BasePrice = 40,
                    PowerRating = 20f,
                    RequiredLevel = 12,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Common Tier 5
            {
                "Ring_Common_T5",
                new ItemData
                {
                    ItemId = "Ring_Common_T5",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Ring of Power 5",
                    Description = "A common ring imbued with tier 5 enchantments.",
                    BasePrice = 50,
                    PowerRating = 25f,
                    RequiredLevel = 15,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Common Tier 6
            {
                "Ring_Common_T6",
                new ItemData
                {
                    ItemId = "Ring_Common_T6",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Ring of Power 6",
                    Description = "A common ring imbued with tier 6 enchantments.",
                    BasePrice = 60,
                    PowerRating = 30f,
                    RequiredLevel = 18,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Common Tier 7
            {
                "Ring_Common_T7",
                new ItemData
                {
                    ItemId = "Ring_Common_T7",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Ring of Power 7",
                    Description = "A common ring imbued with tier 7 enchantments.",
                    BasePrice = 70,
                    PowerRating = 35f,
                    RequiredLevel = 21,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Common Tier 8
            {
                "Ring_Common_T8",
                new ItemData
                {
                    ItemId = "Ring_Common_T8",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Ring of Power 8",
                    Description = "A common ring imbued with tier 8 enchantments.",
                    BasePrice = 80,
                    PowerRating = 40f,
                    RequiredLevel = 24,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Common Tier 9
            {
                "Ring_Common_T9",
                new ItemData
                {
                    ItemId = "Ring_Common_T9",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Ring of Power 9",
                    Description = "A common ring imbued with tier 9 enchantments.",
                    BasePrice = 90,
                    PowerRating = 45f,
                    RequiredLevel = 27,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Common Tier 10
            {
                "Ring_Common_T10",
                new ItemData
                {
                    ItemId = "Ring_Common_T10",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Ring of Power 10",
                    Description = "A common ring imbued with tier 10 enchantments.",
                    BasePrice = 100,
                    PowerRating = 50f,
                    RequiredLevel = 30,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Uncommon Tier 1
            {
                "Ring_Uncommon_T1",
                new ItemData
                {
                    ItemId = "Ring_Uncommon_T1",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Ring of Power 1",
                    Description = "A uncommon ring imbued with tier 1 enchantments.",
                    BasePrice = 60,
                    PowerRating = 20f,
                    RequiredLevel = 8,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Uncommon Tier 2
            {
                "Ring_Uncommon_T2",
                new ItemData
                {
                    ItemId = "Ring_Uncommon_T2",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Ring of Power 2",
                    Description = "A uncommon ring imbued with tier 2 enchantments.",
                    BasePrice = 120,
                    PowerRating = 40f,
                    RequiredLevel = 11,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Uncommon Tier 3
            {
                "Ring_Uncommon_T3",
                new ItemData
                {
                    ItemId = "Ring_Uncommon_T3",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Ring of Power 3",
                    Description = "A uncommon ring imbued with tier 3 enchantments.",
                    BasePrice = 180,
                    PowerRating = 60f,
                    RequiredLevel = 14,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Uncommon Tier 4
            {
                "Ring_Uncommon_T4",
                new ItemData
                {
                    ItemId = "Ring_Uncommon_T4",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Ring of Power 4",
                    Description = "A uncommon ring imbued with tier 4 enchantments.",
                    BasePrice = 240,
                    PowerRating = 80f,
                    RequiredLevel = 17,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Uncommon Tier 5
            {
                "Ring_Uncommon_T5",
                new ItemData
                {
                    ItemId = "Ring_Uncommon_T5",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Ring of Power 5",
                    Description = "A uncommon ring imbued with tier 5 enchantments.",
                    BasePrice = 300,
                    PowerRating = 100f,
                    RequiredLevel = 20,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Uncommon Tier 6
            {
                "Ring_Uncommon_T6",
                new ItemData
                {
                    ItemId = "Ring_Uncommon_T6",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Ring of Power 6",
                    Description = "A uncommon ring imbued with tier 6 enchantments.",
                    BasePrice = 360,
                    PowerRating = 120f,
                    RequiredLevel = 23,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Uncommon Tier 7
            {
                "Ring_Uncommon_T7",
                new ItemData
                {
                    ItemId = "Ring_Uncommon_T7",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Ring of Power 7",
                    Description = "A uncommon ring imbued with tier 7 enchantments.",
                    BasePrice = 420,
                    PowerRating = 140f,
                    RequiredLevel = 26,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Uncommon Tier 8
            {
                "Ring_Uncommon_T8",
                new ItemData
                {
                    ItemId = "Ring_Uncommon_T8",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Ring of Power 8",
                    Description = "A uncommon ring imbued with tier 8 enchantments.",
                    BasePrice = 480,
                    PowerRating = 160f,
                    RequiredLevel = 29,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Uncommon Tier 9
            {
                "Ring_Uncommon_T9",
                new ItemData
                {
                    ItemId = "Ring_Uncommon_T9",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Ring of Power 9",
                    Description = "A uncommon ring imbued with tier 9 enchantments.",
                    BasePrice = 540,
                    PowerRating = 180f,
                    RequiredLevel = 32,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Uncommon Tier 10
            {
                "Ring_Uncommon_T10",
                new ItemData
                {
                    ItemId = "Ring_Uncommon_T10",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Ring of Power 10",
                    Description = "A uncommon ring imbued with tier 10 enchantments.",
                    BasePrice = 600,
                    PowerRating = 200f,
                    RequiredLevel = 35,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Rare Tier 1
            {
                "Ring_Rare_T1",
                new ItemData
                {
                    ItemId = "Ring_Rare_T1",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Ring of Power 1",
                    Description = "A rare ring imbued with tier 1 enchantments.",
                    BasePrice = 110,
                    PowerRating = 35f,
                    RequiredLevel = 13,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Rare Tier 2
            {
                "Ring_Rare_T2",
                new ItemData
                {
                    ItemId = "Ring_Rare_T2",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Ring of Power 2",
                    Description = "A rare ring imbued with tier 2 enchantments.",
                    BasePrice = 220,
                    PowerRating = 70f,
                    RequiredLevel = 16,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Rare Tier 3
            {
                "Ring_Rare_T3",
                new ItemData
                {
                    ItemId = "Ring_Rare_T3",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Ring of Power 3",
                    Description = "A rare ring imbued with tier 3 enchantments.",
                    BasePrice = 330,
                    PowerRating = 105f,
                    RequiredLevel = 19,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Rare Tier 4
            {
                "Ring_Rare_T4",
                new ItemData
                {
                    ItemId = "Ring_Rare_T4",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Ring of Power 4",
                    Description = "A rare ring imbued with tier 4 enchantments.",
                    BasePrice = 440,
                    PowerRating = 140f,
                    RequiredLevel = 22,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Rare Tier 5
            {
                "Ring_Rare_T5",
                new ItemData
                {
                    ItemId = "Ring_Rare_T5",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Ring of Power 5",
                    Description = "A rare ring imbued with tier 5 enchantments.",
                    BasePrice = 550,
                    PowerRating = 175f,
                    RequiredLevel = 25,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Rare Tier 6
            {
                "Ring_Rare_T6",
                new ItemData
                {
                    ItemId = "Ring_Rare_T6",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Ring of Power 6",
                    Description = "A rare ring imbued with tier 6 enchantments.",
                    BasePrice = 660,
                    PowerRating = 210f,
                    RequiredLevel = 28,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Rare Tier 7
            {
                "Ring_Rare_T7",
                new ItemData
                {
                    ItemId = "Ring_Rare_T7",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Ring of Power 7",
                    Description = "A rare ring imbued with tier 7 enchantments.",
                    BasePrice = 770,
                    PowerRating = 245f,
                    RequiredLevel = 31,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Rare Tier 8
            {
                "Ring_Rare_T8",
                new ItemData
                {
                    ItemId = "Ring_Rare_T8",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Ring of Power 8",
                    Description = "A rare ring imbued with tier 8 enchantments.",
                    BasePrice = 880,
                    PowerRating = 280f,
                    RequiredLevel = 34,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Rare Tier 9
            {
                "Ring_Rare_T9",
                new ItemData
                {
                    ItemId = "Ring_Rare_T9",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Ring of Power 9",
                    Description = "A rare ring imbued with tier 9 enchantments.",
                    BasePrice = 990,
                    PowerRating = 315f,
                    RequiredLevel = 37,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Rare Tier 10
            {
                "Ring_Rare_T10",
                new ItemData
                {
                    ItemId = "Ring_Rare_T10",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Ring of Power 10",
                    Description = "A rare ring imbued with tier 10 enchantments.",
                    BasePrice = 1100,
                    PowerRating = 350f,
                    RequiredLevel = 40,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Epic Tier 1
            {
                "Ring_Epic_T1",
                new ItemData
                {
                    ItemId = "Ring_Epic_T1",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Ring of Power 1",
                    Description = "A epic ring imbued with tier 1 enchantments.",
                    BasePrice = 160,
                    PowerRating = 50f,
                    RequiredLevel = 18,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Epic Tier 2
            {
                "Ring_Epic_T2",
                new ItemData
                {
                    ItemId = "Ring_Epic_T2",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Ring of Power 2",
                    Description = "A epic ring imbued with tier 2 enchantments.",
                    BasePrice = 320,
                    PowerRating = 100f,
                    RequiredLevel = 21,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Epic Tier 3
            {
                "Ring_Epic_T3",
                new ItemData
                {
                    ItemId = "Ring_Epic_T3",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Ring of Power 3",
                    Description = "A epic ring imbued with tier 3 enchantments.",
                    BasePrice = 480,
                    PowerRating = 150f,
                    RequiredLevel = 24,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Epic Tier 4
            {
                "Ring_Epic_T4",
                new ItemData
                {
                    ItemId = "Ring_Epic_T4",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Ring of Power 4",
                    Description = "A epic ring imbued with tier 4 enchantments.",
                    BasePrice = 640,
                    PowerRating = 200f,
                    RequiredLevel = 27,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Epic Tier 5
            {
                "Ring_Epic_T5",
                new ItemData
                {
                    ItemId = "Ring_Epic_T5",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Ring of Power 5",
                    Description = "A epic ring imbued with tier 5 enchantments.",
                    BasePrice = 800,
                    PowerRating = 250f,
                    RequiredLevel = 30,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Epic Tier 6
            {
                "Ring_Epic_T6",
                new ItemData
                {
                    ItemId = "Ring_Epic_T6",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Ring of Power 6",
                    Description = "A epic ring imbued with tier 6 enchantments.",
                    BasePrice = 960,
                    PowerRating = 300f,
                    RequiredLevel = 33,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Epic Tier 7
            {
                "Ring_Epic_T7",
                new ItemData
                {
                    ItemId = "Ring_Epic_T7",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Ring of Power 7",
                    Description = "A epic ring imbued with tier 7 enchantments.",
                    BasePrice = 1120,
                    PowerRating = 350f,
                    RequiredLevel = 36,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Epic Tier 8
            {
                "Ring_Epic_T8",
                new ItemData
                {
                    ItemId = "Ring_Epic_T8",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Ring of Power 8",
                    Description = "A epic ring imbued with tier 8 enchantments.",
                    BasePrice = 1280,
                    PowerRating = 400f,
                    RequiredLevel = 39,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Epic Tier 9
            {
                "Ring_Epic_T9",
                new ItemData
                {
                    ItemId = "Ring_Epic_T9",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Ring of Power 9",
                    Description = "A epic ring imbued with tier 9 enchantments.",
                    BasePrice = 1440,
                    PowerRating = 450f,
                    RequiredLevel = 42,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Epic Tier 10
            {
                "Ring_Epic_T10",
                new ItemData
                {
                    ItemId = "Ring_Epic_T10",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Ring of Power 10",
                    Description = "A epic ring imbued with tier 10 enchantments.",
                    BasePrice = 1600,
                    PowerRating = 500f,
                    RequiredLevel = 45,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Legendary Tier 1
            {
                "Ring_Legendary_T1",
                new ItemData
                {
                    ItemId = "Ring_Legendary_T1",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Ring of Power 1",
                    Description = "A legendary ring imbued with tier 1 enchantments.",
                    BasePrice = 210,
                    PowerRating = 65f,
                    RequiredLevel = 23,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Legendary Tier 2
            {
                "Ring_Legendary_T2",
                new ItemData
                {
                    ItemId = "Ring_Legendary_T2",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Ring of Power 2",
                    Description = "A legendary ring imbued with tier 2 enchantments.",
                    BasePrice = 420,
                    PowerRating = 130f,
                    RequiredLevel = 26,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Legendary Tier 3
            {
                "Ring_Legendary_T3",
                new ItemData
                {
                    ItemId = "Ring_Legendary_T3",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Ring of Power 3",
                    Description = "A legendary ring imbued with tier 3 enchantments.",
                    BasePrice = 630,
                    PowerRating = 195f,
                    RequiredLevel = 29,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Legendary Tier 4
            {
                "Ring_Legendary_T4",
                new ItemData
                {
                    ItemId = "Ring_Legendary_T4",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Ring of Power 4",
                    Description = "A legendary ring imbued with tier 4 enchantments.",
                    BasePrice = 840,
                    PowerRating = 260f,
                    RequiredLevel = 32,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Legendary Tier 5
            {
                "Ring_Legendary_T5",
                new ItemData
                {
                    ItemId = "Ring_Legendary_T5",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Ring of Power 5",
                    Description = "A legendary ring imbued with tier 5 enchantments.",
                    BasePrice = 1050,
                    PowerRating = 325f,
                    RequiredLevel = 35,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Legendary Tier 6
            {
                "Ring_Legendary_T6",
                new ItemData
                {
                    ItemId = "Ring_Legendary_T6",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Ring of Power 6",
                    Description = "A legendary ring imbued with tier 6 enchantments.",
                    BasePrice = 1260,
                    PowerRating = 390f,
                    RequiredLevel = 38,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Legendary Tier 7
            {
                "Ring_Legendary_T7",
                new ItemData
                {
                    ItemId = "Ring_Legendary_T7",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Ring of Power 7",
                    Description = "A legendary ring imbued with tier 7 enchantments.",
                    BasePrice = 1470,
                    PowerRating = 455f,
                    RequiredLevel = 41,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Legendary Tier 8
            {
                "Ring_Legendary_T8",
                new ItemData
                {
                    ItemId = "Ring_Legendary_T8",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Ring of Power 8",
                    Description = "A legendary ring imbued with tier 8 enchantments.",
                    BasePrice = 1680,
                    PowerRating = 520f,
                    RequiredLevel = 44,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Legendary Tier 9
            {
                "Ring_Legendary_T9",
                new ItemData
                {
                    ItemId = "Ring_Legendary_T9",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Ring of Power 9",
                    Description = "A legendary ring imbued with tier 9 enchantments.",
                    BasePrice = 1890,
                    PowerRating = 585f,
                    RequiredLevel = 47,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Ring - Legendary Tier 10
            {
                "Ring_Legendary_T10",
                new ItemData
                {
                    ItemId = "Ring_Legendary_T10",
                    Category = ItemCategory.Ring,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Ring of Power 10",
                    Description = "A legendary ring imbued with tier 10 enchantments.",
                    BasePrice = 2100,
                    PowerRating = 650f,
                    RequiredLevel = 50,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Common Tier 1
            {
                "Amulet_Common_T1",
                new ItemData
                {
                    ItemId = "Amulet_Common_T1",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Amulet of Power 1",
                    Description = "A common amulet imbued with tier 1 enchantments.",
                    BasePrice = 10,
                    PowerRating = 5f,
                    RequiredLevel = 3,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Common Tier 2
            {
                "Amulet_Common_T2",
                new ItemData
                {
                    ItemId = "Amulet_Common_T2",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Amulet of Power 2",
                    Description = "A common amulet imbued with tier 2 enchantments.",
                    BasePrice = 20,
                    PowerRating = 10f,
                    RequiredLevel = 6,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Common Tier 3
            {
                "Amulet_Common_T3",
                new ItemData
                {
                    ItemId = "Amulet_Common_T3",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Amulet of Power 3",
                    Description = "A common amulet imbued with tier 3 enchantments.",
                    BasePrice = 30,
                    PowerRating = 15f,
                    RequiredLevel = 9,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Common Tier 4
            {
                "Amulet_Common_T4",
                new ItemData
                {
                    ItemId = "Amulet_Common_T4",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Amulet of Power 4",
                    Description = "A common amulet imbued with tier 4 enchantments.",
                    BasePrice = 40,
                    PowerRating = 20f,
                    RequiredLevel = 12,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Common Tier 5
            {
                "Amulet_Common_T5",
                new ItemData
                {
                    ItemId = "Amulet_Common_T5",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Amulet of Power 5",
                    Description = "A common amulet imbued with tier 5 enchantments.",
                    BasePrice = 50,
                    PowerRating = 25f,
                    RequiredLevel = 15,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Common Tier 6
            {
                "Amulet_Common_T6",
                new ItemData
                {
                    ItemId = "Amulet_Common_T6",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Amulet of Power 6",
                    Description = "A common amulet imbued with tier 6 enchantments.",
                    BasePrice = 60,
                    PowerRating = 30f,
                    RequiredLevel = 18,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Common Tier 7
            {
                "Amulet_Common_T7",
                new ItemData
                {
                    ItemId = "Amulet_Common_T7",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Amulet of Power 7",
                    Description = "A common amulet imbued with tier 7 enchantments.",
                    BasePrice = 70,
                    PowerRating = 35f,
                    RequiredLevel = 21,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Common Tier 8
            {
                "Amulet_Common_T8",
                new ItemData
                {
                    ItemId = "Amulet_Common_T8",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Amulet of Power 8",
                    Description = "A common amulet imbued with tier 8 enchantments.",
                    BasePrice = 80,
                    PowerRating = 40f,
                    RequiredLevel = 24,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Common Tier 9
            {
                "Amulet_Common_T9",
                new ItemData
                {
                    ItemId = "Amulet_Common_T9",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Amulet of Power 9",
                    Description = "A common amulet imbued with tier 9 enchantments.",
                    BasePrice = 90,
                    PowerRating = 45f,
                    RequiredLevel = 27,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Common Tier 10
            {
                "Amulet_Common_T10",
                new ItemData
                {
                    ItemId = "Amulet_Common_T10",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Amulet of Power 10",
                    Description = "A common amulet imbued with tier 10 enchantments.",
                    BasePrice = 100,
                    PowerRating = 50f,
                    RequiredLevel = 30,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Uncommon Tier 1
            {
                "Amulet_Uncommon_T1",
                new ItemData
                {
                    ItemId = "Amulet_Uncommon_T1",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Amulet of Power 1",
                    Description = "A uncommon amulet imbued with tier 1 enchantments.",
                    BasePrice = 60,
                    PowerRating = 20f,
                    RequiredLevel = 8,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Uncommon Tier 2
            {
                "Amulet_Uncommon_T2",
                new ItemData
                {
                    ItemId = "Amulet_Uncommon_T2",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Amulet of Power 2",
                    Description = "A uncommon amulet imbued with tier 2 enchantments.",
                    BasePrice = 120,
                    PowerRating = 40f,
                    RequiredLevel = 11,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Uncommon Tier 3
            {
                "Amulet_Uncommon_T3",
                new ItemData
                {
                    ItemId = "Amulet_Uncommon_T3",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Amulet of Power 3",
                    Description = "A uncommon amulet imbued with tier 3 enchantments.",
                    BasePrice = 180,
                    PowerRating = 60f,
                    RequiredLevel = 14,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Uncommon Tier 4
            {
                "Amulet_Uncommon_T4",
                new ItemData
                {
                    ItemId = "Amulet_Uncommon_T4",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Amulet of Power 4",
                    Description = "A uncommon amulet imbued with tier 4 enchantments.",
                    BasePrice = 240,
                    PowerRating = 80f,
                    RequiredLevel = 17,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Uncommon Tier 5
            {
                "Amulet_Uncommon_T5",
                new ItemData
                {
                    ItemId = "Amulet_Uncommon_T5",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Amulet of Power 5",
                    Description = "A uncommon amulet imbued with tier 5 enchantments.",
                    BasePrice = 300,
                    PowerRating = 100f,
                    RequiredLevel = 20,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Uncommon Tier 6
            {
                "Amulet_Uncommon_T6",
                new ItemData
                {
                    ItemId = "Amulet_Uncommon_T6",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Amulet of Power 6",
                    Description = "A uncommon amulet imbued with tier 6 enchantments.",
                    BasePrice = 360,
                    PowerRating = 120f,
                    RequiredLevel = 23,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Uncommon Tier 7
            {
                "Amulet_Uncommon_T7",
                new ItemData
                {
                    ItemId = "Amulet_Uncommon_T7",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Amulet of Power 7",
                    Description = "A uncommon amulet imbued with tier 7 enchantments.",
                    BasePrice = 420,
                    PowerRating = 140f,
                    RequiredLevel = 26,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Uncommon Tier 8
            {
                "Amulet_Uncommon_T8",
                new ItemData
                {
                    ItemId = "Amulet_Uncommon_T8",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Amulet of Power 8",
                    Description = "A uncommon amulet imbued with tier 8 enchantments.",
                    BasePrice = 480,
                    PowerRating = 160f,
                    RequiredLevel = 29,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Uncommon Tier 9
            {
                "Amulet_Uncommon_T9",
                new ItemData
                {
                    ItemId = "Amulet_Uncommon_T9",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Amulet of Power 9",
                    Description = "A uncommon amulet imbued with tier 9 enchantments.",
                    BasePrice = 540,
                    PowerRating = 180f,
                    RequiredLevel = 32,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Uncommon Tier 10
            {
                "Amulet_Uncommon_T10",
                new ItemData
                {
                    ItemId = "Amulet_Uncommon_T10",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Amulet of Power 10",
                    Description = "A uncommon amulet imbued with tier 10 enchantments.",
                    BasePrice = 600,
                    PowerRating = 200f,
                    RequiredLevel = 35,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Rare Tier 1
            {
                "Amulet_Rare_T1",
                new ItemData
                {
                    ItemId = "Amulet_Rare_T1",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Amulet of Power 1",
                    Description = "A rare amulet imbued with tier 1 enchantments.",
                    BasePrice = 110,
                    PowerRating = 35f,
                    RequiredLevel = 13,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Rare Tier 2
            {
                "Amulet_Rare_T2",
                new ItemData
                {
                    ItemId = "Amulet_Rare_T2",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Amulet of Power 2",
                    Description = "A rare amulet imbued with tier 2 enchantments.",
                    BasePrice = 220,
                    PowerRating = 70f,
                    RequiredLevel = 16,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Rare Tier 3
            {
                "Amulet_Rare_T3",
                new ItemData
                {
                    ItemId = "Amulet_Rare_T3",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Amulet of Power 3",
                    Description = "A rare amulet imbued with tier 3 enchantments.",
                    BasePrice = 330,
                    PowerRating = 105f,
                    RequiredLevel = 19,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Rare Tier 4
            {
                "Amulet_Rare_T4",
                new ItemData
                {
                    ItemId = "Amulet_Rare_T4",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Amulet of Power 4",
                    Description = "A rare amulet imbued with tier 4 enchantments.",
                    BasePrice = 440,
                    PowerRating = 140f,
                    RequiredLevel = 22,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Rare Tier 5
            {
                "Amulet_Rare_T5",
                new ItemData
                {
                    ItemId = "Amulet_Rare_T5",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Amulet of Power 5",
                    Description = "A rare amulet imbued with tier 5 enchantments.",
                    BasePrice = 550,
                    PowerRating = 175f,
                    RequiredLevel = 25,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Rare Tier 6
            {
                "Amulet_Rare_T6",
                new ItemData
                {
                    ItemId = "Amulet_Rare_T6",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Amulet of Power 6",
                    Description = "A rare amulet imbued with tier 6 enchantments.",
                    BasePrice = 660,
                    PowerRating = 210f,
                    RequiredLevel = 28,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Rare Tier 7
            {
                "Amulet_Rare_T7",
                new ItemData
                {
                    ItemId = "Amulet_Rare_T7",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Amulet of Power 7",
                    Description = "A rare amulet imbued with tier 7 enchantments.",
                    BasePrice = 770,
                    PowerRating = 245f,
                    RequiredLevel = 31,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Rare Tier 8
            {
                "Amulet_Rare_T8",
                new ItemData
                {
                    ItemId = "Amulet_Rare_T8",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Amulet of Power 8",
                    Description = "A rare amulet imbued with tier 8 enchantments.",
                    BasePrice = 880,
                    PowerRating = 280f,
                    RequiredLevel = 34,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Rare Tier 9
            {
                "Amulet_Rare_T9",
                new ItemData
                {
                    ItemId = "Amulet_Rare_T9",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Amulet of Power 9",
                    Description = "A rare amulet imbued with tier 9 enchantments.",
                    BasePrice = 990,
                    PowerRating = 315f,
                    RequiredLevel = 37,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Rare Tier 10
            {
                "Amulet_Rare_T10",
                new ItemData
                {
                    ItemId = "Amulet_Rare_T10",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Amulet of Power 10",
                    Description = "A rare amulet imbued with tier 10 enchantments.",
                    BasePrice = 1100,
                    PowerRating = 350f,
                    RequiredLevel = 40,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Epic Tier 1
            {
                "Amulet_Epic_T1",
                new ItemData
                {
                    ItemId = "Amulet_Epic_T1",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Amulet of Power 1",
                    Description = "A epic amulet imbued with tier 1 enchantments.",
                    BasePrice = 160,
                    PowerRating = 50f,
                    RequiredLevel = 18,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Epic Tier 2
            {
                "Amulet_Epic_T2",
                new ItemData
                {
                    ItemId = "Amulet_Epic_T2",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Amulet of Power 2",
                    Description = "A epic amulet imbued with tier 2 enchantments.",
                    BasePrice = 320,
                    PowerRating = 100f,
                    RequiredLevel = 21,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Epic Tier 3
            {
                "Amulet_Epic_T3",
                new ItemData
                {
                    ItemId = "Amulet_Epic_T3",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Amulet of Power 3",
                    Description = "A epic amulet imbued with tier 3 enchantments.",
                    BasePrice = 480,
                    PowerRating = 150f,
                    RequiredLevel = 24,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Epic Tier 4
            {
                "Amulet_Epic_T4",
                new ItemData
                {
                    ItemId = "Amulet_Epic_T4",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Amulet of Power 4",
                    Description = "A epic amulet imbued with tier 4 enchantments.",
                    BasePrice = 640,
                    PowerRating = 200f,
                    RequiredLevel = 27,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Epic Tier 5
            {
                "Amulet_Epic_T5",
                new ItemData
                {
                    ItemId = "Amulet_Epic_T5",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Amulet of Power 5",
                    Description = "A epic amulet imbued with tier 5 enchantments.",
                    BasePrice = 800,
                    PowerRating = 250f,
                    RequiredLevel = 30,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Epic Tier 6
            {
                "Amulet_Epic_T6",
                new ItemData
                {
                    ItemId = "Amulet_Epic_T6",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Amulet of Power 6",
                    Description = "A epic amulet imbued with tier 6 enchantments.",
                    BasePrice = 960,
                    PowerRating = 300f,
                    RequiredLevel = 33,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Epic Tier 7
            {
                "Amulet_Epic_T7",
                new ItemData
                {
                    ItemId = "Amulet_Epic_T7",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Amulet of Power 7",
                    Description = "A epic amulet imbued with tier 7 enchantments.",
                    BasePrice = 1120,
                    PowerRating = 350f,
                    RequiredLevel = 36,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Epic Tier 8
            {
                "Amulet_Epic_T8",
                new ItemData
                {
                    ItemId = "Amulet_Epic_T8",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Amulet of Power 8",
                    Description = "A epic amulet imbued with tier 8 enchantments.",
                    BasePrice = 1280,
                    PowerRating = 400f,
                    RequiredLevel = 39,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Epic Tier 9
            {
                "Amulet_Epic_T9",
                new ItemData
                {
                    ItemId = "Amulet_Epic_T9",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Amulet of Power 9",
                    Description = "A epic amulet imbued with tier 9 enchantments.",
                    BasePrice = 1440,
                    PowerRating = 450f,
                    RequiredLevel = 42,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Epic Tier 10
            {
                "Amulet_Epic_T10",
                new ItemData
                {
                    ItemId = "Amulet_Epic_T10",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Amulet of Power 10",
                    Description = "A epic amulet imbued with tier 10 enchantments.",
                    BasePrice = 1600,
                    PowerRating = 500f,
                    RequiredLevel = 45,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Legendary Tier 1
            {
                "Amulet_Legendary_T1",
                new ItemData
                {
                    ItemId = "Amulet_Legendary_T1",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Amulet of Power 1",
                    Description = "A legendary amulet imbued with tier 1 enchantments.",
                    BasePrice = 210,
                    PowerRating = 65f,
                    RequiredLevel = 23,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Legendary Tier 2
            {
                "Amulet_Legendary_T2",
                new ItemData
                {
                    ItemId = "Amulet_Legendary_T2",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Amulet of Power 2",
                    Description = "A legendary amulet imbued with tier 2 enchantments.",
                    BasePrice = 420,
                    PowerRating = 130f,
                    RequiredLevel = 26,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Legendary Tier 3
            {
                "Amulet_Legendary_T3",
                new ItemData
                {
                    ItemId = "Amulet_Legendary_T3",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Amulet of Power 3",
                    Description = "A legendary amulet imbued with tier 3 enchantments.",
                    BasePrice = 630,
                    PowerRating = 195f,
                    RequiredLevel = 29,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Legendary Tier 4
            {
                "Amulet_Legendary_T4",
                new ItemData
                {
                    ItemId = "Amulet_Legendary_T4",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Amulet of Power 4",
                    Description = "A legendary amulet imbued with tier 4 enchantments.",
                    BasePrice = 840,
                    PowerRating = 260f,
                    RequiredLevel = 32,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Legendary Tier 5
            {
                "Amulet_Legendary_T5",
                new ItemData
                {
                    ItemId = "Amulet_Legendary_T5",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Amulet of Power 5",
                    Description = "A legendary amulet imbued with tier 5 enchantments.",
                    BasePrice = 1050,
                    PowerRating = 325f,
                    RequiredLevel = 35,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Legendary Tier 6
            {
                "Amulet_Legendary_T6",
                new ItemData
                {
                    ItemId = "Amulet_Legendary_T6",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Amulet of Power 6",
                    Description = "A legendary amulet imbued with tier 6 enchantments.",
                    BasePrice = 1260,
                    PowerRating = 390f,
                    RequiredLevel = 38,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Legendary Tier 7
            {
                "Amulet_Legendary_T7",
                new ItemData
                {
                    ItemId = "Amulet_Legendary_T7",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Amulet of Power 7",
                    Description = "A legendary amulet imbued with tier 7 enchantments.",
                    BasePrice = 1470,
                    PowerRating = 455f,
                    RequiredLevel = 41,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Legendary Tier 8
            {
                "Amulet_Legendary_T8",
                new ItemData
                {
                    ItemId = "Amulet_Legendary_T8",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Amulet of Power 8",
                    Description = "A legendary amulet imbued with tier 8 enchantments.",
                    BasePrice = 1680,
                    PowerRating = 520f,
                    RequiredLevel = 44,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Legendary Tier 9
            {
                "Amulet_Legendary_T9",
                new ItemData
                {
                    ItemId = "Amulet_Legendary_T9",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Amulet of Power 9",
                    Description = "A legendary amulet imbued with tier 9 enchantments.",
                    BasePrice = 1890,
                    PowerRating = 585f,
                    RequiredLevel = 47,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Amulet - Legendary Tier 10
            {
                "Amulet_Legendary_T10",
                new ItemData
                {
                    ItemId = "Amulet_Legendary_T10",
                    Category = ItemCategory.Amulet,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Amulet of Power 10",
                    Description = "A legendary amulet imbued with tier 10 enchantments.",
                    BasePrice = 2100,
                    PowerRating = 650f,
                    RequiredLevel = 50,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Common Tier 1
            {
                "Shield_Common_T1",
                new ItemData
                {
                    ItemId = "Shield_Common_T1",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Shield of Power 1",
                    Description = "A common shield imbued with tier 1 enchantments.",
                    BasePrice = 10,
                    PowerRating = 5f,
                    RequiredLevel = 3,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Common Tier 2
            {
                "Shield_Common_T2",
                new ItemData
                {
                    ItemId = "Shield_Common_T2",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Shield of Power 2",
                    Description = "A common shield imbued with tier 2 enchantments.",
                    BasePrice = 20,
                    PowerRating = 10f,
                    RequiredLevel = 6,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Common Tier 3
            {
                "Shield_Common_T3",
                new ItemData
                {
                    ItemId = "Shield_Common_T3",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Shield of Power 3",
                    Description = "A common shield imbued with tier 3 enchantments.",
                    BasePrice = 30,
                    PowerRating = 15f,
                    RequiredLevel = 9,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Common Tier 4
            {
                "Shield_Common_T4",
                new ItemData
                {
                    ItemId = "Shield_Common_T4",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Shield of Power 4",
                    Description = "A common shield imbued with tier 4 enchantments.",
                    BasePrice = 40,
                    PowerRating = 20f,
                    RequiredLevel = 12,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Common Tier 5
            {
                "Shield_Common_T5",
                new ItemData
                {
                    ItemId = "Shield_Common_T5",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Shield of Power 5",
                    Description = "A common shield imbued with tier 5 enchantments.",
                    BasePrice = 50,
                    PowerRating = 25f,
                    RequiredLevel = 15,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Common Tier 6
            {
                "Shield_Common_T6",
                new ItemData
                {
                    ItemId = "Shield_Common_T6",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Shield of Power 6",
                    Description = "A common shield imbued with tier 6 enchantments.",
                    BasePrice = 60,
                    PowerRating = 30f,
                    RequiredLevel = 18,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Common Tier 7
            {
                "Shield_Common_T7",
                new ItemData
                {
                    ItemId = "Shield_Common_T7",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Shield of Power 7",
                    Description = "A common shield imbued with tier 7 enchantments.",
                    BasePrice = 70,
                    PowerRating = 35f,
                    RequiredLevel = 21,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Common Tier 8
            {
                "Shield_Common_T8",
                new ItemData
                {
                    ItemId = "Shield_Common_T8",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Shield of Power 8",
                    Description = "A common shield imbued with tier 8 enchantments.",
                    BasePrice = 80,
                    PowerRating = 40f,
                    RequiredLevel = 24,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Common Tier 9
            {
                "Shield_Common_T9",
                new ItemData
                {
                    ItemId = "Shield_Common_T9",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Shield of Power 9",
                    Description = "A common shield imbued with tier 9 enchantments.",
                    BasePrice = 90,
                    PowerRating = 45f,
                    RequiredLevel = 27,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Common Tier 10
            {
                "Shield_Common_T10",
                new ItemData
                {
                    ItemId = "Shield_Common_T10",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Shield of Power 10",
                    Description = "A common shield imbued with tier 10 enchantments.",
                    BasePrice = 100,
                    PowerRating = 50f,
                    RequiredLevel = 30,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Uncommon Tier 1
            {
                "Shield_Uncommon_T1",
                new ItemData
                {
                    ItemId = "Shield_Uncommon_T1",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Shield of Power 1",
                    Description = "A uncommon shield imbued with tier 1 enchantments.",
                    BasePrice = 60,
                    PowerRating = 20f,
                    RequiredLevel = 8,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Uncommon Tier 2
            {
                "Shield_Uncommon_T2",
                new ItemData
                {
                    ItemId = "Shield_Uncommon_T2",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Shield of Power 2",
                    Description = "A uncommon shield imbued with tier 2 enchantments.",
                    BasePrice = 120,
                    PowerRating = 40f,
                    RequiredLevel = 11,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Uncommon Tier 3
            {
                "Shield_Uncommon_T3",
                new ItemData
                {
                    ItemId = "Shield_Uncommon_T3",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Shield of Power 3",
                    Description = "A uncommon shield imbued with tier 3 enchantments.",
                    BasePrice = 180,
                    PowerRating = 60f,
                    RequiredLevel = 14,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Uncommon Tier 4
            {
                "Shield_Uncommon_T4",
                new ItemData
                {
                    ItemId = "Shield_Uncommon_T4",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Shield of Power 4",
                    Description = "A uncommon shield imbued with tier 4 enchantments.",
                    BasePrice = 240,
                    PowerRating = 80f,
                    RequiredLevel = 17,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Uncommon Tier 5
            {
                "Shield_Uncommon_T5",
                new ItemData
                {
                    ItemId = "Shield_Uncommon_T5",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Shield of Power 5",
                    Description = "A uncommon shield imbued with tier 5 enchantments.",
                    BasePrice = 300,
                    PowerRating = 100f,
                    RequiredLevel = 20,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Uncommon Tier 6
            {
                "Shield_Uncommon_T6",
                new ItemData
                {
                    ItemId = "Shield_Uncommon_T6",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Shield of Power 6",
                    Description = "A uncommon shield imbued with tier 6 enchantments.",
                    BasePrice = 360,
                    PowerRating = 120f,
                    RequiredLevel = 23,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Uncommon Tier 7
            {
                "Shield_Uncommon_T7",
                new ItemData
                {
                    ItemId = "Shield_Uncommon_T7",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Shield of Power 7",
                    Description = "A uncommon shield imbued with tier 7 enchantments.",
                    BasePrice = 420,
                    PowerRating = 140f,
                    RequiredLevel = 26,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Uncommon Tier 8
            {
                "Shield_Uncommon_T8",
                new ItemData
                {
                    ItemId = "Shield_Uncommon_T8",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Shield of Power 8",
                    Description = "A uncommon shield imbued with tier 8 enchantments.",
                    BasePrice = 480,
                    PowerRating = 160f,
                    RequiredLevel = 29,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Uncommon Tier 9
            {
                "Shield_Uncommon_T9",
                new ItemData
                {
                    ItemId = "Shield_Uncommon_T9",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Shield of Power 9",
                    Description = "A uncommon shield imbued with tier 9 enchantments.",
                    BasePrice = 540,
                    PowerRating = 180f,
                    RequiredLevel = 32,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Uncommon Tier 10
            {
                "Shield_Uncommon_T10",
                new ItemData
                {
                    ItemId = "Shield_Uncommon_T10",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Shield of Power 10",
                    Description = "A uncommon shield imbued with tier 10 enchantments.",
                    BasePrice = 600,
                    PowerRating = 200f,
                    RequiredLevel = 35,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Rare Tier 1
            {
                "Shield_Rare_T1",
                new ItemData
                {
                    ItemId = "Shield_Rare_T1",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Shield of Power 1",
                    Description = "A rare shield imbued with tier 1 enchantments.",
                    BasePrice = 110,
                    PowerRating = 35f,
                    RequiredLevel = 13,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Rare Tier 2
            {
                "Shield_Rare_T2",
                new ItemData
                {
                    ItemId = "Shield_Rare_T2",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Shield of Power 2",
                    Description = "A rare shield imbued with tier 2 enchantments.",
                    BasePrice = 220,
                    PowerRating = 70f,
                    RequiredLevel = 16,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Rare Tier 3
            {
                "Shield_Rare_T3",
                new ItemData
                {
                    ItemId = "Shield_Rare_T3",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Shield of Power 3",
                    Description = "A rare shield imbued with tier 3 enchantments.",
                    BasePrice = 330,
                    PowerRating = 105f,
                    RequiredLevel = 19,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Rare Tier 4
            {
                "Shield_Rare_T4",
                new ItemData
                {
                    ItemId = "Shield_Rare_T4",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Shield of Power 4",
                    Description = "A rare shield imbued with tier 4 enchantments.",
                    BasePrice = 440,
                    PowerRating = 140f,
                    RequiredLevel = 22,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Rare Tier 5
            {
                "Shield_Rare_T5",
                new ItemData
                {
                    ItemId = "Shield_Rare_T5",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Shield of Power 5",
                    Description = "A rare shield imbued with tier 5 enchantments.",
                    BasePrice = 550,
                    PowerRating = 175f,
                    RequiredLevel = 25,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Rare Tier 6
            {
                "Shield_Rare_T6",
                new ItemData
                {
                    ItemId = "Shield_Rare_T6",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Shield of Power 6",
                    Description = "A rare shield imbued with tier 6 enchantments.",
                    BasePrice = 660,
                    PowerRating = 210f,
                    RequiredLevel = 28,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Rare Tier 7
            {
                "Shield_Rare_T7",
                new ItemData
                {
                    ItemId = "Shield_Rare_T7",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Shield of Power 7",
                    Description = "A rare shield imbued with tier 7 enchantments.",
                    BasePrice = 770,
                    PowerRating = 245f,
                    RequiredLevel = 31,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Rare Tier 8
            {
                "Shield_Rare_T8",
                new ItemData
                {
                    ItemId = "Shield_Rare_T8",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Shield of Power 8",
                    Description = "A rare shield imbued with tier 8 enchantments.",
                    BasePrice = 880,
                    PowerRating = 280f,
                    RequiredLevel = 34,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Rare Tier 9
            {
                "Shield_Rare_T9",
                new ItemData
                {
                    ItemId = "Shield_Rare_T9",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Shield of Power 9",
                    Description = "A rare shield imbued with tier 9 enchantments.",
                    BasePrice = 990,
                    PowerRating = 315f,
                    RequiredLevel = 37,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Rare Tier 10
            {
                "Shield_Rare_T10",
                new ItemData
                {
                    ItemId = "Shield_Rare_T10",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Shield of Power 10",
                    Description = "A rare shield imbued with tier 10 enchantments.",
                    BasePrice = 1100,
                    PowerRating = 350f,
                    RequiredLevel = 40,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Epic Tier 1
            {
                "Shield_Epic_T1",
                new ItemData
                {
                    ItemId = "Shield_Epic_T1",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Shield of Power 1",
                    Description = "A epic shield imbued with tier 1 enchantments.",
                    BasePrice = 160,
                    PowerRating = 50f,
                    RequiredLevel = 18,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Epic Tier 2
            {
                "Shield_Epic_T2",
                new ItemData
                {
                    ItemId = "Shield_Epic_T2",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Shield of Power 2",
                    Description = "A epic shield imbued with tier 2 enchantments.",
                    BasePrice = 320,
                    PowerRating = 100f,
                    RequiredLevel = 21,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Epic Tier 3
            {
                "Shield_Epic_T3",
                new ItemData
                {
                    ItemId = "Shield_Epic_T3",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Shield of Power 3",
                    Description = "A epic shield imbued with tier 3 enchantments.",
                    BasePrice = 480,
                    PowerRating = 150f,
                    RequiredLevel = 24,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Epic Tier 4
            {
                "Shield_Epic_T4",
                new ItemData
                {
                    ItemId = "Shield_Epic_T4",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Shield of Power 4",
                    Description = "A epic shield imbued with tier 4 enchantments.",
                    BasePrice = 640,
                    PowerRating = 200f,
                    RequiredLevel = 27,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Epic Tier 5
            {
                "Shield_Epic_T5",
                new ItemData
                {
                    ItemId = "Shield_Epic_T5",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Shield of Power 5",
                    Description = "A epic shield imbued with tier 5 enchantments.",
                    BasePrice = 800,
                    PowerRating = 250f,
                    RequiredLevel = 30,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Epic Tier 6
            {
                "Shield_Epic_T6",
                new ItemData
                {
                    ItemId = "Shield_Epic_T6",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Shield of Power 6",
                    Description = "A epic shield imbued with tier 6 enchantments.",
                    BasePrice = 960,
                    PowerRating = 300f,
                    RequiredLevel = 33,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Epic Tier 7
            {
                "Shield_Epic_T7",
                new ItemData
                {
                    ItemId = "Shield_Epic_T7",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Shield of Power 7",
                    Description = "A epic shield imbued with tier 7 enchantments.",
                    BasePrice = 1120,
                    PowerRating = 350f,
                    RequiredLevel = 36,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Epic Tier 8
            {
                "Shield_Epic_T8",
                new ItemData
                {
                    ItemId = "Shield_Epic_T8",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Shield of Power 8",
                    Description = "A epic shield imbued with tier 8 enchantments.",
                    BasePrice = 1280,
                    PowerRating = 400f,
                    RequiredLevel = 39,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Epic Tier 9
            {
                "Shield_Epic_T9",
                new ItemData
                {
                    ItemId = "Shield_Epic_T9",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Shield of Power 9",
                    Description = "A epic shield imbued with tier 9 enchantments.",
                    BasePrice = 1440,
                    PowerRating = 450f,
                    RequiredLevel = 42,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Epic Tier 10
            {
                "Shield_Epic_T10",
                new ItemData
                {
                    ItemId = "Shield_Epic_T10",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Shield of Power 10",
                    Description = "A epic shield imbued with tier 10 enchantments.",
                    BasePrice = 1600,
                    PowerRating = 500f,
                    RequiredLevel = 45,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Legendary Tier 1
            {
                "Shield_Legendary_T1",
                new ItemData
                {
                    ItemId = "Shield_Legendary_T1",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Shield of Power 1",
                    Description = "A legendary shield imbued with tier 1 enchantments.",
                    BasePrice = 210,
                    PowerRating = 65f,
                    RequiredLevel = 23,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Legendary Tier 2
            {
                "Shield_Legendary_T2",
                new ItemData
                {
                    ItemId = "Shield_Legendary_T2",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Shield of Power 2",
                    Description = "A legendary shield imbued with tier 2 enchantments.",
                    BasePrice = 420,
                    PowerRating = 130f,
                    RequiredLevel = 26,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Legendary Tier 3
            {
                "Shield_Legendary_T3",
                new ItemData
                {
                    ItemId = "Shield_Legendary_T3",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Shield of Power 3",
                    Description = "A legendary shield imbued with tier 3 enchantments.",
                    BasePrice = 630,
                    PowerRating = 195f,
                    RequiredLevel = 29,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Legendary Tier 4
            {
                "Shield_Legendary_T4",
                new ItemData
                {
                    ItemId = "Shield_Legendary_T4",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Shield of Power 4",
                    Description = "A legendary shield imbued with tier 4 enchantments.",
                    BasePrice = 840,
                    PowerRating = 260f,
                    RequiredLevel = 32,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Legendary Tier 5
            {
                "Shield_Legendary_T5",
                new ItemData
                {
                    ItemId = "Shield_Legendary_T5",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Shield of Power 5",
                    Description = "A legendary shield imbued with tier 5 enchantments.",
                    BasePrice = 1050,
                    PowerRating = 325f,
                    RequiredLevel = 35,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Legendary Tier 6
            {
                "Shield_Legendary_T6",
                new ItemData
                {
                    ItemId = "Shield_Legendary_T6",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Shield of Power 6",
                    Description = "A legendary shield imbued with tier 6 enchantments.",
                    BasePrice = 1260,
                    PowerRating = 390f,
                    RequiredLevel = 38,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Legendary Tier 7
            {
                "Shield_Legendary_T7",
                new ItemData
                {
                    ItemId = "Shield_Legendary_T7",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Shield of Power 7",
                    Description = "A legendary shield imbued with tier 7 enchantments.",
                    BasePrice = 1470,
                    PowerRating = 455f,
                    RequiredLevel = 41,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Legendary Tier 8
            {
                "Shield_Legendary_T8",
                new ItemData
                {
                    ItemId = "Shield_Legendary_T8",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Shield of Power 8",
                    Description = "A legendary shield imbued with tier 8 enchantments.",
                    BasePrice = 1680,
                    PowerRating = 520f,
                    RequiredLevel = 44,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Legendary Tier 9
            {
                "Shield_Legendary_T9",
                new ItemData
                {
                    ItemId = "Shield_Legendary_T9",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Shield of Power 9",
                    Description = "A legendary shield imbued with tier 9 enchantments.",
                    BasePrice = 1890,
                    PowerRating = 585f,
                    RequiredLevel = 47,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Shield - Legendary Tier 10
            {
                "Shield_Legendary_T10",
                new ItemData
                {
                    ItemId = "Shield_Legendary_T10",
                    Category = ItemCategory.Shield,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Shield of Power 10",
                    Description = "A legendary shield imbued with tier 10 enchantments.",
                    BasePrice = 2100,
                    PowerRating = 650f,
                    RequiredLevel = 50,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Common Tier 1
            {
                "Boots_Common_T1",
                new ItemData
                {
                    ItemId = "Boots_Common_T1",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Boots of Power 1",
                    Description = "A common boots imbued with tier 1 enchantments.",
                    BasePrice = 10,
                    PowerRating = 5f,
                    RequiredLevel = 3,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Common Tier 2
            {
                "Boots_Common_T2",
                new ItemData
                {
                    ItemId = "Boots_Common_T2",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Boots of Power 2",
                    Description = "A common boots imbued with tier 2 enchantments.",
                    BasePrice = 20,
                    PowerRating = 10f,
                    RequiredLevel = 6,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Common Tier 3
            {
                "Boots_Common_T3",
                new ItemData
                {
                    ItemId = "Boots_Common_T3",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Boots of Power 3",
                    Description = "A common boots imbued with tier 3 enchantments.",
                    BasePrice = 30,
                    PowerRating = 15f,
                    RequiredLevel = 9,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Common Tier 4
            {
                "Boots_Common_T4",
                new ItemData
                {
                    ItemId = "Boots_Common_T4",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Boots of Power 4",
                    Description = "A common boots imbued with tier 4 enchantments.",
                    BasePrice = 40,
                    PowerRating = 20f,
                    RequiredLevel = 12,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Common Tier 5
            {
                "Boots_Common_T5",
                new ItemData
                {
                    ItemId = "Boots_Common_T5",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Boots of Power 5",
                    Description = "A common boots imbued with tier 5 enchantments.",
                    BasePrice = 50,
                    PowerRating = 25f,
                    RequiredLevel = 15,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Common Tier 6
            {
                "Boots_Common_T6",
                new ItemData
                {
                    ItemId = "Boots_Common_T6",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Boots of Power 6",
                    Description = "A common boots imbued with tier 6 enchantments.",
                    BasePrice = 60,
                    PowerRating = 30f,
                    RequiredLevel = 18,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Common Tier 7
            {
                "Boots_Common_T7",
                new ItemData
                {
                    ItemId = "Boots_Common_T7",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Boots of Power 7",
                    Description = "A common boots imbued with tier 7 enchantments.",
                    BasePrice = 70,
                    PowerRating = 35f,
                    RequiredLevel = 21,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Common Tier 8
            {
                "Boots_Common_T8",
                new ItemData
                {
                    ItemId = "Boots_Common_T8",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Boots of Power 8",
                    Description = "A common boots imbued with tier 8 enchantments.",
                    BasePrice = 80,
                    PowerRating = 40f,
                    RequiredLevel = 24,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Common Tier 9
            {
                "Boots_Common_T9",
                new ItemData
                {
                    ItemId = "Boots_Common_T9",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Boots of Power 9",
                    Description = "A common boots imbued with tier 9 enchantments.",
                    BasePrice = 90,
                    PowerRating = 45f,
                    RequiredLevel = 27,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Common Tier 10
            {
                "Boots_Common_T10",
                new ItemData
                {
                    ItemId = "Boots_Common_T10",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Boots of Power 10",
                    Description = "A common boots imbued with tier 10 enchantments.",
                    BasePrice = 100,
                    PowerRating = 50f,
                    RequiredLevel = 30,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Uncommon Tier 1
            {
                "Boots_Uncommon_T1",
                new ItemData
                {
                    ItemId = "Boots_Uncommon_T1",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Boots of Power 1",
                    Description = "A uncommon boots imbued with tier 1 enchantments.",
                    BasePrice = 60,
                    PowerRating = 20f,
                    RequiredLevel = 8,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Uncommon Tier 2
            {
                "Boots_Uncommon_T2",
                new ItemData
                {
                    ItemId = "Boots_Uncommon_T2",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Boots of Power 2",
                    Description = "A uncommon boots imbued with tier 2 enchantments.",
                    BasePrice = 120,
                    PowerRating = 40f,
                    RequiredLevel = 11,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Uncommon Tier 3
            {
                "Boots_Uncommon_T3",
                new ItemData
                {
                    ItemId = "Boots_Uncommon_T3",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Boots of Power 3",
                    Description = "A uncommon boots imbued with tier 3 enchantments.",
                    BasePrice = 180,
                    PowerRating = 60f,
                    RequiredLevel = 14,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Uncommon Tier 4
            {
                "Boots_Uncommon_T4",
                new ItemData
                {
                    ItemId = "Boots_Uncommon_T4",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Boots of Power 4",
                    Description = "A uncommon boots imbued with tier 4 enchantments.",
                    BasePrice = 240,
                    PowerRating = 80f,
                    RequiredLevel = 17,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Uncommon Tier 5
            {
                "Boots_Uncommon_T5",
                new ItemData
                {
                    ItemId = "Boots_Uncommon_T5",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Boots of Power 5",
                    Description = "A uncommon boots imbued with tier 5 enchantments.",
                    BasePrice = 300,
                    PowerRating = 100f,
                    RequiredLevel = 20,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Uncommon Tier 6
            {
                "Boots_Uncommon_T6",
                new ItemData
                {
                    ItemId = "Boots_Uncommon_T6",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Boots of Power 6",
                    Description = "A uncommon boots imbued with tier 6 enchantments.",
                    BasePrice = 360,
                    PowerRating = 120f,
                    RequiredLevel = 23,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Uncommon Tier 7
            {
                "Boots_Uncommon_T7",
                new ItemData
                {
                    ItemId = "Boots_Uncommon_T7",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Boots of Power 7",
                    Description = "A uncommon boots imbued with tier 7 enchantments.",
                    BasePrice = 420,
                    PowerRating = 140f,
                    RequiredLevel = 26,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Uncommon Tier 8
            {
                "Boots_Uncommon_T8",
                new ItemData
                {
                    ItemId = "Boots_Uncommon_T8",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Boots of Power 8",
                    Description = "A uncommon boots imbued with tier 8 enchantments.",
                    BasePrice = 480,
                    PowerRating = 160f,
                    RequiredLevel = 29,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Uncommon Tier 9
            {
                "Boots_Uncommon_T9",
                new ItemData
                {
                    ItemId = "Boots_Uncommon_T9",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Boots of Power 9",
                    Description = "A uncommon boots imbued with tier 9 enchantments.",
                    BasePrice = 540,
                    PowerRating = 180f,
                    RequiredLevel = 32,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Uncommon Tier 10
            {
                "Boots_Uncommon_T10",
                new ItemData
                {
                    ItemId = "Boots_Uncommon_T10",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Boots of Power 10",
                    Description = "A uncommon boots imbued with tier 10 enchantments.",
                    BasePrice = 600,
                    PowerRating = 200f,
                    RequiredLevel = 35,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Rare Tier 1
            {
                "Boots_Rare_T1",
                new ItemData
                {
                    ItemId = "Boots_Rare_T1",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Boots of Power 1",
                    Description = "A rare boots imbued with tier 1 enchantments.",
                    BasePrice = 110,
                    PowerRating = 35f,
                    RequiredLevel = 13,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Rare Tier 2
            {
                "Boots_Rare_T2",
                new ItemData
                {
                    ItemId = "Boots_Rare_T2",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Boots of Power 2",
                    Description = "A rare boots imbued with tier 2 enchantments.",
                    BasePrice = 220,
                    PowerRating = 70f,
                    RequiredLevel = 16,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Rare Tier 3
            {
                "Boots_Rare_T3",
                new ItemData
                {
                    ItemId = "Boots_Rare_T3",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Boots of Power 3",
                    Description = "A rare boots imbued with tier 3 enchantments.",
                    BasePrice = 330,
                    PowerRating = 105f,
                    RequiredLevel = 19,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Rare Tier 4
            {
                "Boots_Rare_T4",
                new ItemData
                {
                    ItemId = "Boots_Rare_T4",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Boots of Power 4",
                    Description = "A rare boots imbued with tier 4 enchantments.",
                    BasePrice = 440,
                    PowerRating = 140f,
                    RequiredLevel = 22,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Rare Tier 5
            {
                "Boots_Rare_T5",
                new ItemData
                {
                    ItemId = "Boots_Rare_T5",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Boots of Power 5",
                    Description = "A rare boots imbued with tier 5 enchantments.",
                    BasePrice = 550,
                    PowerRating = 175f,
                    RequiredLevel = 25,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Rare Tier 6
            {
                "Boots_Rare_T6",
                new ItemData
                {
                    ItemId = "Boots_Rare_T6",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Boots of Power 6",
                    Description = "A rare boots imbued with tier 6 enchantments.",
                    BasePrice = 660,
                    PowerRating = 210f,
                    RequiredLevel = 28,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Rare Tier 7
            {
                "Boots_Rare_T7",
                new ItemData
                {
                    ItemId = "Boots_Rare_T7",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Boots of Power 7",
                    Description = "A rare boots imbued with tier 7 enchantments.",
                    BasePrice = 770,
                    PowerRating = 245f,
                    RequiredLevel = 31,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Rare Tier 8
            {
                "Boots_Rare_T8",
                new ItemData
                {
                    ItemId = "Boots_Rare_T8",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Boots of Power 8",
                    Description = "A rare boots imbued with tier 8 enchantments.",
                    BasePrice = 880,
                    PowerRating = 280f,
                    RequiredLevel = 34,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Rare Tier 9
            {
                "Boots_Rare_T9",
                new ItemData
                {
                    ItemId = "Boots_Rare_T9",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Boots of Power 9",
                    Description = "A rare boots imbued with tier 9 enchantments.",
                    BasePrice = 990,
                    PowerRating = 315f,
                    RequiredLevel = 37,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Rare Tier 10
            {
                "Boots_Rare_T10",
                new ItemData
                {
                    ItemId = "Boots_Rare_T10",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Rare,
                    DisplayName = "Rare Boots of Power 10",
                    Description = "A rare boots imbued with tier 10 enchantments.",
                    BasePrice = 1100,
                    PowerRating = 350f,
                    RequiredLevel = 40,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Epic Tier 1
            {
                "Boots_Epic_T1",
                new ItemData
                {
                    ItemId = "Boots_Epic_T1",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Boots of Power 1",
                    Description = "A epic boots imbued with tier 1 enchantments.",
                    BasePrice = 160,
                    PowerRating = 50f,
                    RequiredLevel = 18,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Epic Tier 2
            {
                "Boots_Epic_T2",
                new ItemData
                {
                    ItemId = "Boots_Epic_T2",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Boots of Power 2",
                    Description = "A epic boots imbued with tier 2 enchantments.",
                    BasePrice = 320,
                    PowerRating = 100f,
                    RequiredLevel = 21,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Epic Tier 3
            {
                "Boots_Epic_T3",
                new ItemData
                {
                    ItemId = "Boots_Epic_T3",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Boots of Power 3",
                    Description = "A epic boots imbued with tier 3 enchantments.",
                    BasePrice = 480,
                    PowerRating = 150f,
                    RequiredLevel = 24,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Epic Tier 4
            {
                "Boots_Epic_T4",
                new ItemData
                {
                    ItemId = "Boots_Epic_T4",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Boots of Power 4",
                    Description = "A epic boots imbued with tier 4 enchantments.",
                    BasePrice = 640,
                    PowerRating = 200f,
                    RequiredLevel = 27,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Epic Tier 5
            {
                "Boots_Epic_T5",
                new ItemData
                {
                    ItemId = "Boots_Epic_T5",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Boots of Power 5",
                    Description = "A epic boots imbued with tier 5 enchantments.",
                    BasePrice = 800,
                    PowerRating = 250f,
                    RequiredLevel = 30,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Epic Tier 6
            {
                "Boots_Epic_T6",
                new ItemData
                {
                    ItemId = "Boots_Epic_T6",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Boots of Power 6",
                    Description = "A epic boots imbued with tier 6 enchantments.",
                    BasePrice = 960,
                    PowerRating = 300f,
                    RequiredLevel = 33,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Epic Tier 7
            {
                "Boots_Epic_T7",
                new ItemData
                {
                    ItemId = "Boots_Epic_T7",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Boots of Power 7",
                    Description = "A epic boots imbued with tier 7 enchantments.",
                    BasePrice = 1120,
                    PowerRating = 350f,
                    RequiredLevel = 36,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Epic Tier 8
            {
                "Boots_Epic_T8",
                new ItemData
                {
                    ItemId = "Boots_Epic_T8",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Boots of Power 8",
                    Description = "A epic boots imbued with tier 8 enchantments.",
                    BasePrice = 1280,
                    PowerRating = 400f,
                    RequiredLevel = 39,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Epic Tier 9
            {
                "Boots_Epic_T9",
                new ItemData
                {
                    ItemId = "Boots_Epic_T9",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Boots of Power 9",
                    Description = "A epic boots imbued with tier 9 enchantments.",
                    BasePrice = 1440,
                    PowerRating = 450f,
                    RequiredLevel = 42,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Epic Tier 10
            {
                "Boots_Epic_T10",
                new ItemData
                {
                    ItemId = "Boots_Epic_T10",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Epic,
                    DisplayName = "Epic Boots of Power 10",
                    Description = "A epic boots imbued with tier 10 enchantments.",
                    BasePrice = 1600,
                    PowerRating = 500f,
                    RequiredLevel = 45,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Legendary Tier 1
            {
                "Boots_Legendary_T1",
                new ItemData
                {
                    ItemId = "Boots_Legendary_T1",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Boots of Power 1",
                    Description = "A legendary boots imbued with tier 1 enchantments.",
                    BasePrice = 210,
                    PowerRating = 65f,
                    RequiredLevel = 23,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Legendary Tier 2
            {
                "Boots_Legendary_T2",
                new ItemData
                {
                    ItemId = "Boots_Legendary_T2",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Boots of Power 2",
                    Description = "A legendary boots imbued with tier 2 enchantments.",
                    BasePrice = 420,
                    PowerRating = 130f,
                    RequiredLevel = 26,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Legendary Tier 3
            {
                "Boots_Legendary_T3",
                new ItemData
                {
                    ItemId = "Boots_Legendary_T3",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Boots of Power 3",
                    Description = "A legendary boots imbued with tier 3 enchantments.",
                    BasePrice = 630,
                    PowerRating = 195f,
                    RequiredLevel = 29,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Legendary Tier 4
            {
                "Boots_Legendary_T4",
                new ItemData
                {
                    ItemId = "Boots_Legendary_T4",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Boots of Power 4",
                    Description = "A legendary boots imbued with tier 4 enchantments.",
                    BasePrice = 840,
                    PowerRating = 260f,
                    RequiredLevel = 32,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Legendary Tier 5
            {
                "Boots_Legendary_T5",
                new ItemData
                {
                    ItemId = "Boots_Legendary_T5",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Boots of Power 5",
                    Description = "A legendary boots imbued with tier 5 enchantments.",
                    BasePrice = 1050,
                    PowerRating = 325f,
                    RequiredLevel = 35,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Legendary Tier 6
            {
                "Boots_Legendary_T6",
                new ItemData
                {
                    ItemId = "Boots_Legendary_T6",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Boots of Power 6",
                    Description = "A legendary boots imbued with tier 6 enchantments.",
                    BasePrice = 1260,
                    PowerRating = 390f,
                    RequiredLevel = 38,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Legendary Tier 7
            {
                "Boots_Legendary_T7",
                new ItemData
                {
                    ItemId = "Boots_Legendary_T7",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Boots of Power 7",
                    Description = "A legendary boots imbued with tier 7 enchantments.",
                    BasePrice = 1470,
                    PowerRating = 455f,
                    RequiredLevel = 41,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Legendary Tier 8
            {
                "Boots_Legendary_T8",
                new ItemData
                {
                    ItemId = "Boots_Legendary_T8",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Boots of Power 8",
                    Description = "A legendary boots imbued with tier 8 enchantments.",
                    BasePrice = 1680,
                    PowerRating = 520f,
                    RequiredLevel = 44,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Legendary Tier 9
            {
                "Boots_Legendary_T9",
                new ItemData
                {
                    ItemId = "Boots_Legendary_T9",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Boots of Power 9",
                    Description = "A legendary boots imbued with tier 9 enchantments.",
                    BasePrice = 1890,
                    PowerRating = 585f,
                    RequiredLevel = 47,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Boots - Legendary Tier 10
            {
                "Boots_Legendary_T10",
                new ItemData
                {
                    ItemId = "Boots_Legendary_T10",
                    Category = ItemCategory.Boots,
                    Rarity = ItemRarity.Legendary,
                    DisplayName = "Legendary Boots of Power 10",
                    Description = "A legendary boots imbued with tier 10 enchantments.",
                    BasePrice = 2100,
                    PowerRating = 650f,
                    RequiredLevel = 50,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Gloves - Common Tier 1
            {
                "Gloves_Common_T1",
                new ItemData
                {
                    ItemId = "Gloves_Common_T1",
                    Category = ItemCategory.Gloves,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Gloves of Power 1",
                    Description = "A common gloves imbued with tier 1 enchantments.",
                    BasePrice = 10,
                    PowerRating = 5f,
                    RequiredLevel = 3,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Gloves - Common Tier 2
            {
                "Gloves_Common_T2",
                new ItemData
                {
                    ItemId = "Gloves_Common_T2",
                    Category = ItemCategory.Gloves,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Gloves of Power 2",
                    Description = "A common gloves imbued with tier 2 enchantments.",
                    BasePrice = 20,
                    PowerRating = 10f,
                    RequiredLevel = 6,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Gloves - Common Tier 3
            {
                "Gloves_Common_T3",
                new ItemData
                {
                    ItemId = "Gloves_Common_T3",
                    Category = ItemCategory.Gloves,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Gloves of Power 3",
                    Description = "A common gloves imbued with tier 3 enchantments.",
                    BasePrice = 30,
                    PowerRating = 15f,
                    RequiredLevel = 9,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Gloves - Common Tier 4
            {
                "Gloves_Common_T4",
                new ItemData
                {
                    ItemId = "Gloves_Common_T4",
                    Category = ItemCategory.Gloves,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Gloves of Power 4",
                    Description = "A common gloves imbued with tier 4 enchantments.",
                    BasePrice = 40,
                    PowerRating = 20f,
                    RequiredLevel = 12,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Gloves - Common Tier 5
            {
                "Gloves_Common_T5",
                new ItemData
                {
                    ItemId = "Gloves_Common_T5",
                    Category = ItemCategory.Gloves,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Gloves of Power 5",
                    Description = "A common gloves imbued with tier 5 enchantments.",
                    BasePrice = 50,
                    PowerRating = 25f,
                    RequiredLevel = 15,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Gloves - Common Tier 6
            {
                "Gloves_Common_T6",
                new ItemData
                {
                    ItemId = "Gloves_Common_T6",
                    Category = ItemCategory.Gloves,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Gloves of Power 6",
                    Description = "A common gloves imbued with tier 6 enchantments.",
                    BasePrice = 60,
                    PowerRating = 30f,
                    RequiredLevel = 18,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Gloves - Common Tier 7
            {
                "Gloves_Common_T7",
                new ItemData
                {
                    ItemId = "Gloves_Common_T7",
                    Category = ItemCategory.Gloves,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Gloves of Power 7",
                    Description = "A common gloves imbued with tier 7 enchantments.",
                    BasePrice = 70,
                    PowerRating = 35f,
                    RequiredLevel = 21,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Gloves - Common Tier 8
            {
                "Gloves_Common_T8",
                new ItemData
                {
                    ItemId = "Gloves_Common_T8",
                    Category = ItemCategory.Gloves,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Gloves of Power 8",
                    Description = "A common gloves imbued with tier 8 enchantments.",
                    BasePrice = 80,
                    PowerRating = 40f,
                    RequiredLevel = 24,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Gloves - Common Tier 9
            {
                "Gloves_Common_T9",
                new ItemData
                {
                    ItemId = "Gloves_Common_T9",
                    Category = ItemCategory.Gloves,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Gloves of Power 9",
                    Description = "A common gloves imbued with tier 9 enchantments.",
                    BasePrice = 90,
                    PowerRating = 45f,
                    RequiredLevel = 27,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Gloves - Common Tier 10
            {
                "Gloves_Common_T10",
                new ItemData
                {
                    ItemId = "Gloves_Common_T10",
                    Category = ItemCategory.Gloves,
                    Rarity = ItemRarity.Common,
                    DisplayName = "Common Gloves of Power 10",
                    Description = "A common gloves imbued with tier 10 enchantments.",
                    BasePrice = 100,
                    PowerRating = 50f,
                    RequiredLevel = 30,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Gloves - Uncommon Tier 1
            {
                "Gloves_Uncommon_T1",
                new ItemData
                {
                    ItemId = "Gloves_Uncommon_T1",
                    Category = ItemCategory.Gloves,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Gloves of Power 1",
                    Description = "A uncommon gloves imbued with tier 1 enchantments.",
                    BasePrice = 60,
                    PowerRating = 20f,
                    RequiredLevel = 8,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Gloves - Uncommon Tier 2
            {
                "Gloves_Uncommon_T2",
                new ItemData
                {
                    ItemId = "Gloves_Uncommon_T2",
                    Category = ItemCategory.Gloves,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Gloves of Power 2",
                    Description = "A uncommon gloves imbued with tier 2 enchantments.",
                    BasePrice = 120,
                    PowerRating = 40f,
                    RequiredLevel = 11,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Gloves - Uncommon Tier 3
            {
                "Gloves_Uncommon_T3",
                new ItemData
                {
                    ItemId = "Gloves_Uncommon_T3",
                    Category = ItemCategory.Gloves,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Gloves of Power 3",
                    Description = "A uncommon gloves imbued with tier 3 enchantments.",
                    BasePrice = 180,
                    PowerRating = 60f,
                    RequiredLevel = 14,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Gloves - Uncommon Tier 4
            {
                "Gloves_Uncommon_T4",
                new ItemData
                {
                    ItemId = "Gloves_Uncommon_T4",
                    Category = ItemCategory.Gloves,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Gloves of Power 4",
                    Description = "A uncommon gloves imbued with tier 4 enchantments.",
                    BasePrice = 240,
                    PowerRating = 80f,
                    RequiredLevel = 17,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Gloves - Uncommon Tier 5
            {
                "Gloves_Uncommon_T5",
                new ItemData
                {
                    ItemId = "Gloves_Uncommon_T5",
                    Category = ItemCategory.Gloves,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Gloves of Power 5",
                    Description = "A uncommon gloves imbued with tier 5 enchantments.",
                    BasePrice = 300,
                    PowerRating = 100f,
                    RequiredLevel = 20,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
            // Gloves - Uncommon Tier 6
            {
                "Gloves_Uncommon_T6",
                new ItemData
                {
                    ItemId = "Gloves_Uncommon_T6",
                    Category = ItemCategory.Gloves,
                    Rarity = ItemRarity.Uncommon,
                    DisplayName = "Uncommon Gloves of Power 6",
                    Description = "A uncommon gloves imbued with tier 6 enchantments.",
                    BasePrice = 360,
                    PowerRating = 120f,
                    RequiredLevel = 23,
                    IsStackable = false,
                    MaxStackSize = 1,
                }
            },
        };

        #endregion
    };

    #region Data Structures

    [Serializable]
    public class LevelConfig
    {
        public int LevelId;
        public string DisplayName;
        public float BaseEnemyHealth;
        public float BaseEnemyDamage;
        public float EnemySpeedMultiplier;
        public int GoldReward;
        public int ExperienceReward;
        public int MaxWaves;
    }

    public enum ItemCategory { Weapon, Armor, Potion, Scroll, Ring, Amulet, Shield, Boots, Gloves, Helmet }
    public enum ItemRarity { Common, Uncommon, Rare, Epic, Legendary }

    [Serializable]
    public class ItemData
    {
        public string ItemId;
        public ItemCategory Category;
        public ItemRarity Rarity;
        public string DisplayName;
        public string Description;
        public int BasePrice;
        public float PowerRating;
        public int RequiredLevel;
        public bool IsStackable;
        public int MaxStackSize;
    }

    [Serializable]
    public class EnemyData
    {
        public string EnemyId;
        public string DisplayName;
        public float BaseHealth;
        public float BaseDamage;
        public float BaseDefense;
        public float MoveSpeed;
        public int ExperienceValue;
        public bool IsBoss;
        public int SpawnWeight;
    }

    [Serializable]
    public class SkillNode
    {
        public string SkillId;
        public string TreeName;
        public int TierLevel;
        public int NodeIndex;
        public string DisplayName;
        public string Description;
        public int SkillPointCost;
        public int RequiredLevel;
        public float StatBonus;
        public string PrerequisiteSkillId;
        public bool IsPassive;
    }

    #endregion
}

