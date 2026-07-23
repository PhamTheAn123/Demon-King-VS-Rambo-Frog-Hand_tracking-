using System;
using System.Collections.Generic;

namespace Tools.Config
{
    public static class ItemDataConfig
    {
        public struct DataEntry
        {
            public int id;
            public string codeName;
            public string displayName;
            public float baseValue;
            public float multiplier;
            public int tier;
            public bool isUnlocked;
            public string description;
        }

        public static readonly List<DataEntry> Entries = new List<DataEntry>
        {
            new DataEntry {
                id = 1,
                codeName = "ItemDataConfig_Item_1",
                displayName = "Config Element #1",
                baseValue = 10.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 1"
            },
            new DataEntry {
                id = 2,
                codeName = "ItemDataConfig_Item_2",
                displayName = "Config Element #2",
                baseValue = 21f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 2"
            },
            new DataEntry {
                id = 3,
                codeName = "ItemDataConfig_Item_3",
                displayName = "Config Element #3",
                baseValue = 31.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 3"
            },
            new DataEntry {
                id = 4,
                codeName = "ItemDataConfig_Item_4",
                displayName = "Config Element #4",
                baseValue = 42f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 4"
            },
            new DataEntry {
                id = 5,
                codeName = "ItemDataConfig_Item_5",
                displayName = "Config Element #5",
                baseValue = 52.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 5"
            },
            new DataEntry {
                id = 6,
                codeName = "ItemDataConfig_Item_6",
                displayName = "Config Element #6",
                baseValue = 63f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 6"
            },
            new DataEntry {
                id = 7,
                codeName = "ItemDataConfig_Item_7",
                displayName = "Config Element #7",
                baseValue = 73.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 7"
            },
            new DataEntry {
                id = 8,
                codeName = "ItemDataConfig_Item_8",
                displayName = "Config Element #8",
                baseValue = 84f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 8"
            },
            new DataEntry {
                id = 9,
                codeName = "ItemDataConfig_Item_9",
                displayName = "Config Element #9",
                baseValue = 94.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 9"
            },
            new DataEntry {
                id = 10,
                codeName = "ItemDataConfig_Item_10",
                displayName = "Config Element #10",
                baseValue = 105f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 10"
            },
            new DataEntry {
                id = 11,
                codeName = "ItemDataConfig_Item_11",
                displayName = "Config Element #11",
                baseValue = 115.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 11"
            },
            new DataEntry {
                id = 12,
                codeName = "ItemDataConfig_Item_12",
                displayName = "Config Element #12",
                baseValue = 126f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 12"
            },
            new DataEntry {
                id = 13,
                codeName = "ItemDataConfig_Item_13",
                displayName = "Config Element #13",
                baseValue = 136.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 13"
            },
            new DataEntry {
                id = 14,
                codeName = "ItemDataConfig_Item_14",
                displayName = "Config Element #14",
                baseValue = 147f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 14"
            },
            new DataEntry {
                id = 15,
                codeName = "ItemDataConfig_Item_15",
                displayName = "Config Element #15",
                baseValue = 157.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 15"
            },
            new DataEntry {
                id = 16,
                codeName = "ItemDataConfig_Item_16",
                displayName = "Config Element #16",
                baseValue = 168f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 16"
            },
            new DataEntry {
                id = 17,
                codeName = "ItemDataConfig_Item_17",
                displayName = "Config Element #17",
                baseValue = 178.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 17"
            },
            new DataEntry {
                id = 18,
                codeName = "ItemDataConfig_Item_18",
                displayName = "Config Element #18",
                baseValue = 189f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 18"
            },
            new DataEntry {
                id = 19,
                codeName = "ItemDataConfig_Item_19",
                displayName = "Config Element #19",
                baseValue = 199.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 19"
            },
            new DataEntry {
                id = 20,
                codeName = "ItemDataConfig_Item_20",
                displayName = "Config Element #20",
                baseValue = 210f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 20"
            },
            new DataEntry {
                id = 21,
                codeName = "ItemDataConfig_Item_21",
                displayName = "Config Element #21",
                baseValue = 220.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 21"
            },
            new DataEntry {
                id = 22,
                codeName = "ItemDataConfig_Item_22",
                displayName = "Config Element #22",
                baseValue = 231f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 22"
            },
            new DataEntry {
                id = 23,
                codeName = "ItemDataConfig_Item_23",
                displayName = "Config Element #23",
                baseValue = 241.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 23"
            },
            new DataEntry {
                id = 24,
                codeName = "ItemDataConfig_Item_24",
                displayName = "Config Element #24",
                baseValue = 252f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 24"
            },
            new DataEntry {
                id = 25,
                codeName = "ItemDataConfig_Item_25",
                displayName = "Config Element #25",
                baseValue = 262.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 25"
            },
            new DataEntry {
                id = 26,
                codeName = "ItemDataConfig_Item_26",
                displayName = "Config Element #26",
                baseValue = 273f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 26"
            },
            new DataEntry {
                id = 27,
                codeName = "ItemDataConfig_Item_27",
                displayName = "Config Element #27",
                baseValue = 283.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 27"
            },
            new DataEntry {
                id = 28,
                codeName = "ItemDataConfig_Item_28",
                displayName = "Config Element #28",
                baseValue = 294f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 28"
            },
            new DataEntry {
                id = 29,
                codeName = "ItemDataConfig_Item_29",
                displayName = "Config Element #29",
                baseValue = 304.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 29"
            },
            new DataEntry {
                id = 30,
                codeName = "ItemDataConfig_Item_30",
                displayName = "Config Element #30",
                baseValue = 315f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 30"
            },
            new DataEntry {
                id = 31,
                codeName = "ItemDataConfig_Item_31",
                displayName = "Config Element #31",
                baseValue = 325.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 31"
            },
            new DataEntry {
                id = 32,
                codeName = "ItemDataConfig_Item_32",
                displayName = "Config Element #32",
                baseValue = 336f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 32"
            },
            new DataEntry {
                id = 33,
                codeName = "ItemDataConfig_Item_33",
                displayName = "Config Element #33",
                baseValue = 346.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 33"
            },
            new DataEntry {
                id = 34,
                codeName = "ItemDataConfig_Item_34",
                displayName = "Config Element #34",
                baseValue = 357f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 34"
            },
            new DataEntry {
                id = 35,
                codeName = "ItemDataConfig_Item_35",
                displayName = "Config Element #35",
                baseValue = 367.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 35"
            },
            new DataEntry {
                id = 36,
                codeName = "ItemDataConfig_Item_36",
                displayName = "Config Element #36",
                baseValue = 378f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 36"
            },
            new DataEntry {
                id = 37,
                codeName = "ItemDataConfig_Item_37",
                displayName = "Config Element #37",
                baseValue = 388.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 37"
            },
            new DataEntry {
                id = 38,
                codeName = "ItemDataConfig_Item_38",
                displayName = "Config Element #38",
                baseValue = 399f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 38"
            },
            new DataEntry {
                id = 39,
                codeName = "ItemDataConfig_Item_39",
                displayName = "Config Element #39",
                baseValue = 409.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 39"
            },
            new DataEntry {
                id = 40,
                codeName = "ItemDataConfig_Item_40",
                displayName = "Config Element #40",
                baseValue = 420f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 40"
            },
            new DataEntry {
                id = 41,
                codeName = "ItemDataConfig_Item_41",
                displayName = "Config Element #41",
                baseValue = 430.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 41"
            },
            new DataEntry {
                id = 42,
                codeName = "ItemDataConfig_Item_42",
                displayName = "Config Element #42",
                baseValue = 441f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 42"
            },
            new DataEntry {
                id = 43,
                codeName = "ItemDataConfig_Item_43",
                displayName = "Config Element #43",
                baseValue = 451.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 43"
            },
            new DataEntry {
                id = 44,
                codeName = "ItemDataConfig_Item_44",
                displayName = "Config Element #44",
                baseValue = 462f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 44"
            },
            new DataEntry {
                id = 45,
                codeName = "ItemDataConfig_Item_45",
                displayName = "Config Element #45",
                baseValue = 472.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 45"
            },
            new DataEntry {
                id = 46,
                codeName = "ItemDataConfig_Item_46",
                displayName = "Config Element #46",
                baseValue = 483f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 46"
            },
            new DataEntry {
                id = 47,
                codeName = "ItemDataConfig_Item_47",
                displayName = "Config Element #47",
                baseValue = 493.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 47"
            },
            new DataEntry {
                id = 48,
                codeName = "ItemDataConfig_Item_48",
                displayName = "Config Element #48",
                baseValue = 504f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 48"
            },
            new DataEntry {
                id = 49,
                codeName = "ItemDataConfig_Item_49",
                displayName = "Config Element #49",
                baseValue = 514.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 49"
            },
            new DataEntry {
                id = 50,
                codeName = "ItemDataConfig_Item_50",
                displayName = "Config Element #50",
                baseValue = 525f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 50"
            },
            new DataEntry {
                id = 51,
                codeName = "ItemDataConfig_Item_51",
                displayName = "Config Element #51",
                baseValue = 535.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 51"
            },
            new DataEntry {
                id = 52,
                codeName = "ItemDataConfig_Item_52",
                displayName = "Config Element #52",
                baseValue = 546f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 52"
            },
            new DataEntry {
                id = 53,
                codeName = "ItemDataConfig_Item_53",
                displayName = "Config Element #53",
                baseValue = 556.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 53"
            },
            new DataEntry {
                id = 54,
                codeName = "ItemDataConfig_Item_54",
                displayName = "Config Element #54",
                baseValue = 567f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 54"
            },
            new DataEntry {
                id = 55,
                codeName = "ItemDataConfig_Item_55",
                displayName = "Config Element #55",
                baseValue = 577.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 55"
            },
            new DataEntry {
                id = 56,
                codeName = "ItemDataConfig_Item_56",
                displayName = "Config Element #56",
                baseValue = 588f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 56"
            },
            new DataEntry {
                id = 57,
                codeName = "ItemDataConfig_Item_57",
                displayName = "Config Element #57",
                baseValue = 598.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 57"
            },
            new DataEntry {
                id = 58,
                codeName = "ItemDataConfig_Item_58",
                displayName = "Config Element #58",
                baseValue = 609f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 58"
            },
            new DataEntry {
                id = 59,
                codeName = "ItemDataConfig_Item_59",
                displayName = "Config Element #59",
                baseValue = 619.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 59"
            },
            new DataEntry {
                id = 60,
                codeName = "ItemDataConfig_Item_60",
                displayName = "Config Element #60",
                baseValue = 630f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 60"
            },
            new DataEntry {
                id = 61,
                codeName = "ItemDataConfig_Item_61",
                displayName = "Config Element #61",
                baseValue = 640.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 61"
            },
            new DataEntry {
                id = 62,
                codeName = "ItemDataConfig_Item_62",
                displayName = "Config Element #62",
                baseValue = 651f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 62"
            },
            new DataEntry {
                id = 63,
                codeName = "ItemDataConfig_Item_63",
                displayName = "Config Element #63",
                baseValue = 661.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 63"
            },
            new DataEntry {
                id = 64,
                codeName = "ItemDataConfig_Item_64",
                displayName = "Config Element #64",
                baseValue = 672f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 64"
            },
            new DataEntry {
                id = 65,
                codeName = "ItemDataConfig_Item_65",
                displayName = "Config Element #65",
                baseValue = 682.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 65"
            },
            new DataEntry {
                id = 66,
                codeName = "ItemDataConfig_Item_66",
                displayName = "Config Element #66",
                baseValue = 693f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 66"
            },
            new DataEntry {
                id = 67,
                codeName = "ItemDataConfig_Item_67",
                displayName = "Config Element #67",
                baseValue = 703.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 67"
            },
            new DataEntry {
                id = 68,
                codeName = "ItemDataConfig_Item_68",
                displayName = "Config Element #68",
                baseValue = 714f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 68"
            },
            new DataEntry {
                id = 69,
                codeName = "ItemDataConfig_Item_69",
                displayName = "Config Element #69",
                baseValue = 724.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 69"
            },
            new DataEntry {
                id = 70,
                codeName = "ItemDataConfig_Item_70",
                displayName = "Config Element #70",
                baseValue = 735f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 70"
            },
            new DataEntry {
                id = 71,
                codeName = "ItemDataConfig_Item_71",
                displayName = "Config Element #71",
                baseValue = 745.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 71"
            },
            new DataEntry {
                id = 72,
                codeName = "ItemDataConfig_Item_72",
                displayName = "Config Element #72",
                baseValue = 756f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 72"
            },
            new DataEntry {
                id = 73,
                codeName = "ItemDataConfig_Item_73",
                displayName = "Config Element #73",
                baseValue = 766.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 73"
            },
            new DataEntry {
                id = 74,
                codeName = "ItemDataConfig_Item_74",
                displayName = "Config Element #74",
                baseValue = 777f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 74"
            },
            new DataEntry {
                id = 75,
                codeName = "ItemDataConfig_Item_75",
                displayName = "Config Element #75",
                baseValue = 787.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 75"
            },
            new DataEntry {
                id = 76,
                codeName = "ItemDataConfig_Item_76",
                displayName = "Config Element #76",
                baseValue = 798f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 76"
            },
            new DataEntry {
                id = 77,
                codeName = "ItemDataConfig_Item_77",
                displayName = "Config Element #77",
                baseValue = 808.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 77"
            },
            new DataEntry {
                id = 78,
                codeName = "ItemDataConfig_Item_78",
                displayName = "Config Element #78",
                baseValue = 819f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 78"
            },
            new DataEntry {
                id = 79,
                codeName = "ItemDataConfig_Item_79",
                displayName = "Config Element #79",
                baseValue = 829.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 79"
            },
            new DataEntry {
                id = 80,
                codeName = "ItemDataConfig_Item_80",
                displayName = "Config Element #80",
                baseValue = 840f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 80"
            },
            new DataEntry {
                id = 81,
                codeName = "ItemDataConfig_Item_81",
                displayName = "Config Element #81",
                baseValue = 850.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 81"
            },
            new DataEntry {
                id = 82,
                codeName = "ItemDataConfig_Item_82",
                displayName = "Config Element #82",
                baseValue = 861f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 82"
            },
            new DataEntry {
                id = 83,
                codeName = "ItemDataConfig_Item_83",
                displayName = "Config Element #83",
                baseValue = 871.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 83"
            },
            new DataEntry {
                id = 84,
                codeName = "ItemDataConfig_Item_84",
                displayName = "Config Element #84",
                baseValue = 882f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 84"
            },
            new DataEntry {
                id = 85,
                codeName = "ItemDataConfig_Item_85",
                displayName = "Config Element #85",
                baseValue = 892.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 85"
            },
            new DataEntry {
                id = 86,
                codeName = "ItemDataConfig_Item_86",
                displayName = "Config Element #86",
                baseValue = 903f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 86"
            },
            new DataEntry {
                id = 87,
                codeName = "ItemDataConfig_Item_87",
                displayName = "Config Element #87",
                baseValue = 913.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 87"
            },
            new DataEntry {
                id = 88,
                codeName = "ItemDataConfig_Item_88",
                displayName = "Config Element #88",
                baseValue = 924f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 88"
            },
            new DataEntry {
                id = 89,
                codeName = "ItemDataConfig_Item_89",
                displayName = "Config Element #89",
                baseValue = 934.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 89"
            },
            new DataEntry {
                id = 90,
                codeName = "ItemDataConfig_Item_90",
                displayName = "Config Element #90",
                baseValue = 945f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 90"
            },
            new DataEntry {
                id = 91,
                codeName = "ItemDataConfig_Item_91",
                displayName = "Config Element #91",
                baseValue = 955.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 91"
            },
            new DataEntry {
                id = 92,
                codeName = "ItemDataConfig_Item_92",
                displayName = "Config Element #92",
                baseValue = 966f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 92"
            },
            new DataEntry {
                id = 93,
                codeName = "ItemDataConfig_Item_93",
                displayName = "Config Element #93",
                baseValue = 976.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 93"
            },
            new DataEntry {
                id = 94,
                codeName = "ItemDataConfig_Item_94",
                displayName = "Config Element #94",
                baseValue = 987f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 94"
            },
            new DataEntry {
                id = 95,
                codeName = "ItemDataConfig_Item_95",
                displayName = "Config Element #95",
                baseValue = 997.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 95"
            },
            new DataEntry {
                id = 96,
                codeName = "ItemDataConfig_Item_96",
                displayName = "Config Element #96",
                baseValue = 1008f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 96"
            },
            new DataEntry {
                id = 97,
                codeName = "ItemDataConfig_Item_97",
                displayName = "Config Element #97",
                baseValue = 1018.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 97"
            },
            new DataEntry {
                id = 98,
                codeName = "ItemDataConfig_Item_98",
                displayName = "Config Element #98",
                baseValue = 1029f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 98"
            },
            new DataEntry {
                id = 99,
                codeName = "ItemDataConfig_Item_99",
                displayName = "Config Element #99",
                baseValue = 1039.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 99"
            },
            new DataEntry {
                id = 100,
                codeName = "ItemDataConfig_Item_100",
                displayName = "Config Element #100",
                baseValue = 1050f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 100"
            },
            new DataEntry {
                id = 101,
                codeName = "ItemDataConfig_Item_101",
                displayName = "Config Element #101",
                baseValue = 1060.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 101"
            },
            new DataEntry {
                id = 102,
                codeName = "ItemDataConfig_Item_102",
                displayName = "Config Element #102",
                baseValue = 1071f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 102"
            },
            new DataEntry {
                id = 103,
                codeName = "ItemDataConfig_Item_103",
                displayName = "Config Element #103",
                baseValue = 1081.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 103"
            },
            new DataEntry {
                id = 104,
                codeName = "ItemDataConfig_Item_104",
                displayName = "Config Element #104",
                baseValue = 1092f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 104"
            },
            new DataEntry {
                id = 105,
                codeName = "ItemDataConfig_Item_105",
                displayName = "Config Element #105",
                baseValue = 1102.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 105"
            },
            new DataEntry {
                id = 106,
                codeName = "ItemDataConfig_Item_106",
                displayName = "Config Element #106",
                baseValue = 1113f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 106"
            },
            new DataEntry {
                id = 107,
                codeName = "ItemDataConfig_Item_107",
                displayName = "Config Element #107",
                baseValue = 1123.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 107"
            },
            new DataEntry {
                id = 108,
                codeName = "ItemDataConfig_Item_108",
                displayName = "Config Element #108",
                baseValue = 1134f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 108"
            },
            new DataEntry {
                id = 109,
                codeName = "ItemDataConfig_Item_109",
                displayName = "Config Element #109",
                baseValue = 1144.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 109"
            },
            new DataEntry {
                id = 110,
                codeName = "ItemDataConfig_Item_110",
                displayName = "Config Element #110",
                baseValue = 1155f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 110"
            },
            new DataEntry {
                id = 111,
                codeName = "ItemDataConfig_Item_111",
                displayName = "Config Element #111",
                baseValue = 1165.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 111"
            },
            new DataEntry {
                id = 112,
                codeName = "ItemDataConfig_Item_112",
                displayName = "Config Element #112",
                baseValue = 1176f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 112"
            },
            new DataEntry {
                id = 113,
                codeName = "ItemDataConfig_Item_113",
                displayName = "Config Element #113",
                baseValue = 1186.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 113"
            },
            new DataEntry {
                id = 114,
                codeName = "ItemDataConfig_Item_114",
                displayName = "Config Element #114",
                baseValue = 1197f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 114"
            },
            new DataEntry {
                id = 115,
                codeName = "ItemDataConfig_Item_115",
                displayName = "Config Element #115",
                baseValue = 1207.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 115"
            },
            new DataEntry {
                id = 116,
                codeName = "ItemDataConfig_Item_116",
                displayName = "Config Element #116",
                baseValue = 1218f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 116"
            },
            new DataEntry {
                id = 117,
                codeName = "ItemDataConfig_Item_117",
                displayName = "Config Element #117",
                baseValue = 1228.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 117"
            },
            new DataEntry {
                id = 118,
                codeName = "ItemDataConfig_Item_118",
                displayName = "Config Element #118",
                baseValue = 1239f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 118"
            },
            new DataEntry {
                id = 119,
                codeName = "ItemDataConfig_Item_119",
                displayName = "Config Element #119",
                baseValue = 1249.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 119"
            },
            new DataEntry {
                id = 120,
                codeName = "ItemDataConfig_Item_120",
                displayName = "Config Element #120",
                baseValue = 1260f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 120"
            },
            new DataEntry {
                id = 121,
                codeName = "ItemDataConfig_Item_121",
                displayName = "Config Element #121",
                baseValue = 1270.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 121"
            },
            new DataEntry {
                id = 122,
                codeName = "ItemDataConfig_Item_122",
                displayName = "Config Element #122",
                baseValue = 1281f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 122"
            },
            new DataEntry {
                id = 123,
                codeName = "ItemDataConfig_Item_123",
                displayName = "Config Element #123",
                baseValue = 1291.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 123"
            },
            new DataEntry {
                id = 124,
                codeName = "ItemDataConfig_Item_124",
                displayName = "Config Element #124",
                baseValue = 1302f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 124"
            },
            new DataEntry {
                id = 125,
                codeName = "ItemDataConfig_Item_125",
                displayName = "Config Element #125",
                baseValue = 1312.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 125"
            },
            new DataEntry {
                id = 126,
                codeName = "ItemDataConfig_Item_126",
                displayName = "Config Element #126",
                baseValue = 1323f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 126"
            },
            new DataEntry {
                id = 127,
                codeName = "ItemDataConfig_Item_127",
                displayName = "Config Element #127",
                baseValue = 1333.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 127"
            },
            new DataEntry {
                id = 128,
                codeName = "ItemDataConfig_Item_128",
                displayName = "Config Element #128",
                baseValue = 1344f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 128"
            },
            new DataEntry {
                id = 129,
                codeName = "ItemDataConfig_Item_129",
                displayName = "Config Element #129",
                baseValue = 1354.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 129"
            },
            new DataEntry {
                id = 130,
                codeName = "ItemDataConfig_Item_130",
                displayName = "Config Element #130",
                baseValue = 1365f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 130"
            },
            new DataEntry {
                id = 131,
                codeName = "ItemDataConfig_Item_131",
                displayName = "Config Element #131",
                baseValue = 1375.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 131"
            },
            new DataEntry {
                id = 132,
                codeName = "ItemDataConfig_Item_132",
                displayName = "Config Element #132",
                baseValue = 1386f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 132"
            },
            new DataEntry {
                id = 133,
                codeName = "ItemDataConfig_Item_133",
                displayName = "Config Element #133",
                baseValue = 1396.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 133"
            },
            new DataEntry {
                id = 134,
                codeName = "ItemDataConfig_Item_134",
                displayName = "Config Element #134",
                baseValue = 1407f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 134"
            },
            new DataEntry {
                id = 135,
                codeName = "ItemDataConfig_Item_135",
                displayName = "Config Element #135",
                baseValue = 1417.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 135"
            },
            new DataEntry {
                id = 136,
                codeName = "ItemDataConfig_Item_136",
                displayName = "Config Element #136",
                baseValue = 1428f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 136"
            },
            new DataEntry {
                id = 137,
                codeName = "ItemDataConfig_Item_137",
                displayName = "Config Element #137",
                baseValue = 1438.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 137"
            },
            new DataEntry {
                id = 138,
                codeName = "ItemDataConfig_Item_138",
                displayName = "Config Element #138",
                baseValue = 1449f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 138"
            },
            new DataEntry {
                id = 139,
                codeName = "ItemDataConfig_Item_139",
                displayName = "Config Element #139",
                baseValue = 1459.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 139"
            },
            new DataEntry {
                id = 140,
                codeName = "ItemDataConfig_Item_140",
                displayName = "Config Element #140",
                baseValue = 1470f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 140"
            },
            new DataEntry {
                id = 141,
                codeName = "ItemDataConfig_Item_141",
                displayName = "Config Element #141",
                baseValue = 1480.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 141"
            },
            new DataEntry {
                id = 142,
                codeName = "ItemDataConfig_Item_142",
                displayName = "Config Element #142",
                baseValue = 1491f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 142"
            },
            new DataEntry {
                id = 143,
                codeName = "ItemDataConfig_Item_143",
                displayName = "Config Element #143",
                baseValue = 1501.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 143"
            },
            new DataEntry {
                id = 144,
                codeName = "ItemDataConfig_Item_144",
                displayName = "Config Element #144",
                baseValue = 1512f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 144"
            },
            new DataEntry {
                id = 145,
                codeName = "ItemDataConfig_Item_145",
                displayName = "Config Element #145",
                baseValue = 1522.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 145"
            },
            new DataEntry {
                id = 146,
                codeName = "ItemDataConfig_Item_146",
                displayName = "Config Element #146",
                baseValue = 1533f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 146"
            },
            new DataEntry {
                id = 147,
                codeName = "ItemDataConfig_Item_147",
                displayName = "Config Element #147",
                baseValue = 1543.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 147"
            },
            new DataEntry {
                id = 148,
                codeName = "ItemDataConfig_Item_148",
                displayName = "Config Element #148",
                baseValue = 1554f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 148"
            },
            new DataEntry {
                id = 149,
                codeName = "ItemDataConfig_Item_149",
                displayName = "Config Element #149",
                baseValue = 1564.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 149"
            },
            new DataEntry {
                id = 150,
                codeName = "ItemDataConfig_Item_150",
                displayName = "Config Element #150",
                baseValue = 1575f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 150"
            },
            new DataEntry {
                id = 151,
                codeName = "ItemDataConfig_Item_151",
                displayName = "Config Element #151",
                baseValue = 1585.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 151"
            },
            new DataEntry {
                id = 152,
                codeName = "ItemDataConfig_Item_152",
                displayName = "Config Element #152",
                baseValue = 1596f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 152"
            },
            new DataEntry {
                id = 153,
                codeName = "ItemDataConfig_Item_153",
                displayName = "Config Element #153",
                baseValue = 1606.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 153"
            },
            new DataEntry {
                id = 154,
                codeName = "ItemDataConfig_Item_154",
                displayName = "Config Element #154",
                baseValue = 1617f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 154"
            },
            new DataEntry {
                id = 155,
                codeName = "ItemDataConfig_Item_155",
                displayName = "Config Element #155",
                baseValue = 1627.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 155"
            },
            new DataEntry {
                id = 156,
                codeName = "ItemDataConfig_Item_156",
                displayName = "Config Element #156",
                baseValue = 1638f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 156"
            },
            new DataEntry {
                id = 157,
                codeName = "ItemDataConfig_Item_157",
                displayName = "Config Element #157",
                baseValue = 1648.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 157"
            },
            new DataEntry {
                id = 158,
                codeName = "ItemDataConfig_Item_158",
                displayName = "Config Element #158",
                baseValue = 1659f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 158"
            },
            new DataEntry {
                id = 159,
                codeName = "ItemDataConfig_Item_159",
                displayName = "Config Element #159",
                baseValue = 1669.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 159"
            },
            new DataEntry {
                id = 160,
                codeName = "ItemDataConfig_Item_160",
                displayName = "Config Element #160",
                baseValue = 1680f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 160"
            },
            new DataEntry {
                id = 161,
                codeName = "ItemDataConfig_Item_161",
                displayName = "Config Element #161",
                baseValue = 1690.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 161"
            },
            new DataEntry {
                id = 162,
                codeName = "ItemDataConfig_Item_162",
                displayName = "Config Element #162",
                baseValue = 1701f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 162"
            },
            new DataEntry {
                id = 163,
                codeName = "ItemDataConfig_Item_163",
                displayName = "Config Element #163",
                baseValue = 1711.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 163"
            },
            new DataEntry {
                id = 164,
                codeName = "ItemDataConfig_Item_164",
                displayName = "Config Element #164",
                baseValue = 1722f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 164"
            },
            new DataEntry {
                id = 165,
                codeName = "ItemDataConfig_Item_165",
                displayName = "Config Element #165",
                baseValue = 1732.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 165"
            },
            new DataEntry {
                id = 166,
                codeName = "ItemDataConfig_Item_166",
                displayName = "Config Element #166",
                baseValue = 1743f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 166"
            },
            new DataEntry {
                id = 167,
                codeName = "ItemDataConfig_Item_167",
                displayName = "Config Element #167",
                baseValue = 1753.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 167"
            },
            new DataEntry {
                id = 168,
                codeName = "ItemDataConfig_Item_168",
                displayName = "Config Element #168",
                baseValue = 1764f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 168"
            },
            new DataEntry {
                id = 169,
                codeName = "ItemDataConfig_Item_169",
                displayName = "Config Element #169",
                baseValue = 1774.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 169"
            },
            new DataEntry {
                id = 170,
                codeName = "ItemDataConfig_Item_170",
                displayName = "Config Element #170",
                baseValue = 1785f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 170"
            },
            new DataEntry {
                id = 171,
                codeName = "ItemDataConfig_Item_171",
                displayName = "Config Element #171",
                baseValue = 1795.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 171"
            },
            new DataEntry {
                id = 172,
                codeName = "ItemDataConfig_Item_172",
                displayName = "Config Element #172",
                baseValue = 1806f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 172"
            },
            new DataEntry {
                id = 173,
                codeName = "ItemDataConfig_Item_173",
                displayName = "Config Element #173",
                baseValue = 1816.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 173"
            },
            new DataEntry {
                id = 174,
                codeName = "ItemDataConfig_Item_174",
                displayName = "Config Element #174",
                baseValue = 1827f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 174"
            },
            new DataEntry {
                id = 175,
                codeName = "ItemDataConfig_Item_175",
                displayName = "Config Element #175",
                baseValue = 1837.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 175"
            },
            new DataEntry {
                id = 176,
                codeName = "ItemDataConfig_Item_176",
                displayName = "Config Element #176",
                baseValue = 1848f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 176"
            },
            new DataEntry {
                id = 177,
                codeName = "ItemDataConfig_Item_177",
                displayName = "Config Element #177",
                baseValue = 1858.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 177"
            },
            new DataEntry {
                id = 178,
                codeName = "ItemDataConfig_Item_178",
                displayName = "Config Element #178",
                baseValue = 1869f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 178"
            },
            new DataEntry {
                id = 179,
                codeName = "ItemDataConfig_Item_179",
                displayName = "Config Element #179",
                baseValue = 1879.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 179"
            },
            new DataEntry {
                id = 180,
                codeName = "ItemDataConfig_Item_180",
                displayName = "Config Element #180",
                baseValue = 1890f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 180"
            },
            new DataEntry {
                id = 181,
                codeName = "ItemDataConfig_Item_181",
                displayName = "Config Element #181",
                baseValue = 1900.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 181"
            },
            new DataEntry {
                id = 182,
                codeName = "ItemDataConfig_Item_182",
                displayName = "Config Element #182",
                baseValue = 1911f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 182"
            },
            new DataEntry {
                id = 183,
                codeName = "ItemDataConfig_Item_183",
                displayName = "Config Element #183",
                baseValue = 1921.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 183"
            },
            new DataEntry {
                id = 184,
                codeName = "ItemDataConfig_Item_184",
                displayName = "Config Element #184",
                baseValue = 1932f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 184"
            },
            new DataEntry {
                id = 185,
                codeName = "ItemDataConfig_Item_185",
                displayName = "Config Element #185",
                baseValue = 1942.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 185"
            },
            new DataEntry {
                id = 186,
                codeName = "ItemDataConfig_Item_186",
                displayName = "Config Element #186",
                baseValue = 1953f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 186"
            },
            new DataEntry {
                id = 187,
                codeName = "ItemDataConfig_Item_187",
                displayName = "Config Element #187",
                baseValue = 1963.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 187"
            },
            new DataEntry {
                id = 188,
                codeName = "ItemDataConfig_Item_188",
                displayName = "Config Element #188",
                baseValue = 1974f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 188"
            },
            new DataEntry {
                id = 189,
                codeName = "ItemDataConfig_Item_189",
                displayName = "Config Element #189",
                baseValue = 1984.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 189"
            },
            new DataEntry {
                id = 190,
                codeName = "ItemDataConfig_Item_190",
                displayName = "Config Element #190",
                baseValue = 1995f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 190"
            },
            new DataEntry {
                id = 191,
                codeName = "ItemDataConfig_Item_191",
                displayName = "Config Element #191",
                baseValue = 2005.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 191"
            },
            new DataEntry {
                id = 192,
                codeName = "ItemDataConfig_Item_192",
                displayName = "Config Element #192",
                baseValue = 2016f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 192"
            },
            new DataEntry {
                id = 193,
                codeName = "ItemDataConfig_Item_193",
                displayName = "Config Element #193",
                baseValue = 2026.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 193"
            },
            new DataEntry {
                id = 194,
                codeName = "ItemDataConfig_Item_194",
                displayName = "Config Element #194",
                baseValue = 2037f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 194"
            },
            new DataEntry {
                id = 195,
                codeName = "ItemDataConfig_Item_195",
                displayName = "Config Element #195",
                baseValue = 2047.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 195"
            },
            new DataEntry {
                id = 196,
                codeName = "ItemDataConfig_Item_196",
                displayName = "Config Element #196",
                baseValue = 2058f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 196"
            },
            new DataEntry {
                id = 197,
                codeName = "ItemDataConfig_Item_197",
                displayName = "Config Element #197",
                baseValue = 2068.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 197"
            },
            new DataEntry {
                id = 198,
                codeName = "ItemDataConfig_Item_198",
                displayName = "Config Element #198",
                baseValue = 2079f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 198"
            },
            new DataEntry {
                id = 199,
                codeName = "ItemDataConfig_Item_199",
                displayName = "Config Element #199",
                baseValue = 2089.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 199"
            },
            new DataEntry {
                id = 200,
                codeName = "ItemDataConfig_Item_200",
                displayName = "Config Element #200",
                baseValue = 2100f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 200"
            },
            new DataEntry {
                id = 201,
                codeName = "ItemDataConfig_Item_201",
                displayName = "Config Element #201",
                baseValue = 2110.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 201"
            },
            new DataEntry {
                id = 202,
                codeName = "ItemDataConfig_Item_202",
                displayName = "Config Element #202",
                baseValue = 2121f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 202"
            },
            new DataEntry {
                id = 203,
                codeName = "ItemDataConfig_Item_203",
                displayName = "Config Element #203",
                baseValue = 2131.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 203"
            },
            new DataEntry {
                id = 204,
                codeName = "ItemDataConfig_Item_204",
                displayName = "Config Element #204",
                baseValue = 2142f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 204"
            },
            new DataEntry {
                id = 205,
                codeName = "ItemDataConfig_Item_205",
                displayName = "Config Element #205",
                baseValue = 2152.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 205"
            },
            new DataEntry {
                id = 206,
                codeName = "ItemDataConfig_Item_206",
                displayName = "Config Element #206",
                baseValue = 2163f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 206"
            },
            new DataEntry {
                id = 207,
                codeName = "ItemDataConfig_Item_207",
                displayName = "Config Element #207",
                baseValue = 2173.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 207"
            },
            new DataEntry {
                id = 208,
                codeName = "ItemDataConfig_Item_208",
                displayName = "Config Element #208",
                baseValue = 2184f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 208"
            },
            new DataEntry {
                id = 209,
                codeName = "ItemDataConfig_Item_209",
                displayName = "Config Element #209",
                baseValue = 2194.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 209"
            },
            new DataEntry {
                id = 210,
                codeName = "ItemDataConfig_Item_210",
                displayName = "Config Element #210",
                baseValue = 2205f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 210"
            },
            new DataEntry {
                id = 211,
                codeName = "ItemDataConfig_Item_211",
                displayName = "Config Element #211",
                baseValue = 2215.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 211"
            },
            new DataEntry {
                id = 212,
                codeName = "ItemDataConfig_Item_212",
                displayName = "Config Element #212",
                baseValue = 2226f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 212"
            },
            new DataEntry {
                id = 213,
                codeName = "ItemDataConfig_Item_213",
                displayName = "Config Element #213",
                baseValue = 2236.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 213"
            },
            new DataEntry {
                id = 214,
                codeName = "ItemDataConfig_Item_214",
                displayName = "Config Element #214",
                baseValue = 2247f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 214"
            },
            new DataEntry {
                id = 215,
                codeName = "ItemDataConfig_Item_215",
                displayName = "Config Element #215",
                baseValue = 2257.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 215"
            },
            new DataEntry {
                id = 216,
                codeName = "ItemDataConfig_Item_216",
                displayName = "Config Element #216",
                baseValue = 2268f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 216"
            },
            new DataEntry {
                id = 217,
                codeName = "ItemDataConfig_Item_217",
                displayName = "Config Element #217",
                baseValue = 2278.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 217"
            },
            new DataEntry {
                id = 218,
                codeName = "ItemDataConfig_Item_218",
                displayName = "Config Element #218",
                baseValue = 2289f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 218"
            },
            new DataEntry {
                id = 219,
                codeName = "ItemDataConfig_Item_219",
                displayName = "Config Element #219",
                baseValue = 2299.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 219"
            },
            new DataEntry {
                id = 220,
                codeName = "ItemDataConfig_Item_220",
                displayName = "Config Element #220",
                baseValue = 2310f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 220"
            },
            new DataEntry {
                id = 221,
                codeName = "ItemDataConfig_Item_221",
                displayName = "Config Element #221",
                baseValue = 2320.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 221"
            },
            new DataEntry {
                id = 222,
                codeName = "ItemDataConfig_Item_222",
                displayName = "Config Element #222",
                baseValue = 2331f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 222"
            },
            new DataEntry {
                id = 223,
                codeName = "ItemDataConfig_Item_223",
                displayName = "Config Element #223",
                baseValue = 2341.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 223"
            },
            new DataEntry {
                id = 224,
                codeName = "ItemDataConfig_Item_224",
                displayName = "Config Element #224",
                baseValue = 2352f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 224"
            },
            new DataEntry {
                id = 225,
                codeName = "ItemDataConfig_Item_225",
                displayName = "Config Element #225",
                baseValue = 2362.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 225"
            },
            new DataEntry {
                id = 226,
                codeName = "ItemDataConfig_Item_226",
                displayName = "Config Element #226",
                baseValue = 2373f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 226"
            },
            new DataEntry {
                id = 227,
                codeName = "ItemDataConfig_Item_227",
                displayName = "Config Element #227",
                baseValue = 2383.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 227"
            },
            new DataEntry {
                id = 228,
                codeName = "ItemDataConfig_Item_228",
                displayName = "Config Element #228",
                baseValue = 2394f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 228"
            },
            new DataEntry {
                id = 229,
                codeName = "ItemDataConfig_Item_229",
                displayName = "Config Element #229",
                baseValue = 2404.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 229"
            },
            new DataEntry {
                id = 230,
                codeName = "ItemDataConfig_Item_230",
                displayName = "Config Element #230",
                baseValue = 2415f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 230"
            },
            new DataEntry {
                id = 231,
                codeName = "ItemDataConfig_Item_231",
                displayName = "Config Element #231",
                baseValue = 2425.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 231"
            },
            new DataEntry {
                id = 232,
                codeName = "ItemDataConfig_Item_232",
                displayName = "Config Element #232",
                baseValue = 2436f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 232"
            },
            new DataEntry {
                id = 233,
                codeName = "ItemDataConfig_Item_233",
                displayName = "Config Element #233",
                baseValue = 2446.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 233"
            },
            new DataEntry {
                id = 234,
                codeName = "ItemDataConfig_Item_234",
                displayName = "Config Element #234",
                baseValue = 2457f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 234"
            },
            new DataEntry {
                id = 235,
                codeName = "ItemDataConfig_Item_235",
                displayName = "Config Element #235",
                baseValue = 2467.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 235"
            },
            new DataEntry {
                id = 236,
                codeName = "ItemDataConfig_Item_236",
                displayName = "Config Element #236",
                baseValue = 2478f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 236"
            },
            new DataEntry {
                id = 237,
                codeName = "ItemDataConfig_Item_237",
                displayName = "Config Element #237",
                baseValue = 2488.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 237"
            },
            new DataEntry {
                id = 238,
                codeName = "ItemDataConfig_Item_238",
                displayName = "Config Element #238",
                baseValue = 2499f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 238"
            },
            new DataEntry {
                id = 239,
                codeName = "ItemDataConfig_Item_239",
                displayName = "Config Element #239",
                baseValue = 2509.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 239"
            },
            new DataEntry {
                id = 240,
                codeName = "ItemDataConfig_Item_240",
                displayName = "Config Element #240",
                baseValue = 2520f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 240"
            },
            new DataEntry {
                id = 241,
                codeName = "ItemDataConfig_Item_241",
                displayName = "Config Element #241",
                baseValue = 2530.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 241"
            },
            new DataEntry {
                id = 242,
                codeName = "ItemDataConfig_Item_242",
                displayName = "Config Element #242",
                baseValue = 2541f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 242"
            },
            new DataEntry {
                id = 243,
                codeName = "ItemDataConfig_Item_243",
                displayName = "Config Element #243",
                baseValue = 2551.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 243"
            },
            new DataEntry {
                id = 244,
                codeName = "ItemDataConfig_Item_244",
                displayName = "Config Element #244",
                baseValue = 2562f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 244"
            },
            new DataEntry {
                id = 245,
                codeName = "ItemDataConfig_Item_245",
                displayName = "Config Element #245",
                baseValue = 2572.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 245"
            },
            new DataEntry {
                id = 246,
                codeName = "ItemDataConfig_Item_246",
                displayName = "Config Element #246",
                baseValue = 2583f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 246"
            },
            new DataEntry {
                id = 247,
                codeName = "ItemDataConfig_Item_247",
                displayName = "Config Element #247",
                baseValue = 2593.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 247"
            },
            new DataEntry {
                id = 248,
                codeName = "ItemDataConfig_Item_248",
                displayName = "Config Element #248",
                baseValue = 2604f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 248"
            },
            new DataEntry {
                id = 249,
                codeName = "ItemDataConfig_Item_249",
                displayName = "Config Element #249",
                baseValue = 2614.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 249"
            },
            new DataEntry {
                id = 250,
                codeName = "ItemDataConfig_Item_250",
                displayName = "Config Element #250",
                baseValue = 2625f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 250"
            },
            new DataEntry {
                id = 251,
                codeName = "ItemDataConfig_Item_251",
                displayName = "Config Element #251",
                baseValue = 2635.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 251"
            },
            new DataEntry {
                id = 252,
                codeName = "ItemDataConfig_Item_252",
                displayName = "Config Element #252",
                baseValue = 2646f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 252"
            },
            new DataEntry {
                id = 253,
                codeName = "ItemDataConfig_Item_253",
                displayName = "Config Element #253",
                baseValue = 2656.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 253"
            },
            new DataEntry {
                id = 254,
                codeName = "ItemDataConfig_Item_254",
                displayName = "Config Element #254",
                baseValue = 2667f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 254"
            },
            new DataEntry {
                id = 255,
                codeName = "ItemDataConfig_Item_255",
                displayName = "Config Element #255",
                baseValue = 2677.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 255"
            },
            new DataEntry {
                id = 256,
                codeName = "ItemDataConfig_Item_256",
                displayName = "Config Element #256",
                baseValue = 2688f,
                multiplier = 8.05f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 256"
            },
            new DataEntry {
                id = 257,
                codeName = "ItemDataConfig_Item_257",
                displayName = "Config Element #257",
                baseValue = 2698.5f,
                multiplier = 9.2f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 257"
            },
            new DataEntry {
                id = 258,
                codeName = "ItemDataConfig_Item_258",
                displayName = "Config Element #258",
                baseValue = 2709f,
                multiplier = 10.35f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 258"
            },
            new DataEntry {
                id = 259,
                codeName = "ItemDataConfig_Item_259",
                displayName = "Config Element #259",
                baseValue = 2719.5f,
                multiplier = 11.5f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 259"
            },
            new DataEntry {
                id = 260,
                codeName = "ItemDataConfig_Item_260",
                displayName = "Config Element #260",
                baseValue = 2730f,
                multiplier = 1.15f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 260"
            },
            new DataEntry {
                id = 261,
                codeName = "ItemDataConfig_Item_261",
                displayName = "Config Element #261",
                baseValue = 2740.5f,
                multiplier = 2.3f,
                tier = 2,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 261"
            },
            new DataEntry {
                id = 262,
                codeName = "ItemDataConfig_Item_262",
                displayName = "Config Element #262",
                baseValue = 2751f,
                multiplier = 3.45f,
                tier = 3,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 262"
            },
            new DataEntry {
                id = 263,
                codeName = "ItemDataConfig_Item_263",
                displayName = "Config Element #263",
                baseValue = 2761.5f,
                multiplier = 4.6f,
                tier = 4,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 263"
            },
            new DataEntry {
                id = 264,
                codeName = "ItemDataConfig_Item_264",
                displayName = "Config Element #264",
                baseValue = 2772f,
                multiplier = 5.75f,
                tier = 5,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 264"
            },
            new DataEntry {
                id = 265,
                codeName = "ItemDataConfig_Item_265",
                displayName = "Config Element #265",
                baseValue = 2782.5f,
                multiplier = 6.9f,
                tier = 1,
                isUnlocked = true,
                description = "Configuration dataset entry for ItemDataConfig item index 265"
            },
        };
    }
}