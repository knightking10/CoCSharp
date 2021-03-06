﻿using CoCSharp.Data;
using CoCSharp.Data.Slots;
using CoCSharp.Logic;
using System;
using System.Diagnostics;

namespace CoCSharp.Network.Messages
{
    /// <summary>
    /// Represents an <see cref="Avatar"/>'s data sent in the
    /// networking protocol.
    /// </summary>
    public class AvatarMessageComponent : MessageComponent
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="AvatarMessageComponent"/> class.
        /// </summary>
        public AvatarMessageComponent()
        {
            // Space
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AvatarMessageComponent"/> class from
        /// the specified <see cref="Avatar"/>.
        /// </summary>
        /// <param name="avatar"><see cref="Avatar"/> from which the data will be set.</param>
        /// <exception cref="ArgumentNullException"><paramref name="avatar"/> is null.</exception>
        public AvatarMessageComponent(Avatar avatar)
        {
            if (avatar == null)
                throw new ArgumentNullException("avatar");

            UserID = avatar.ID;
            HomeID = avatar.ID;

            if (avatar.Alliance != null)
            {
                var member = avatar.Alliance.FindMember(avatar.ID);
                Debug.Assert(member != null);

                ClanData = new ClanMessageComponent()
                {
                    ID = avatar.Alliance.ID,
                    Name = avatar.Alliance.Name,
                    Badge = avatar.Alliance.Badge,
                    Role = member.Role,
                    Level = avatar.Alliance.Level
                };
            }

            //LegenderyTrophy = 99;
            //BestSeasonEnabled = 1;
            //BestSeasonMonth = 1;
            //BestSeasonYear = 1999;
            //BestSeasonTrophies = 99;
            //BestSeasonPosition = 1;
            LeagueLevel = avatar.League;
            TownHallLevel = avatar.Home.TownHall.Level;
            Name = avatar.Name;

            //Unknown13 = -1;
            //Unknown14 = -1;
            Unknown15 = -1;

            Experience = avatar.ExpPoints;
            Level = avatar.ExpLevel;
            Gems = avatar.Gems;
            FreeGems = avatar.FreeGems;

            Unknown16 = 1200;
            Unknown17 = 60;

            Trophies = avatar.Trophies;

            Unknown21 = 1;
            Unknown22 = 946720861000;
            //Unknown22 = 4294967516;
            //Unknown23 = -169129983;

            IsNamed = avatar.IsNamed;

            Unknown26 = 1;
            Unknown27 = 1;

            ResourcesAmount = avatar.ResourcesAmount;
            Units = avatar.Units;
            Spells = avatar.Spells;
            UnitUpgrades = avatar.UnitUpgrades;
            SpellUpgrades = avatar.SpellUpgrades;
            HeroUpgrades = avatar.HeroUpgrades;
            HeroHealths = avatar.HeroHealths;
            HeroStates = avatar.HeroStates;
            TutorialProgess = avatar.TutorialProgess;
            Achievements = avatar.Achievements;
            AchievementProgress = avatar.AchievementProgress;
            NpcStars = avatar.NpcStars;
            NpcGold = avatar.NpcGold;
            NpcElixir = avatar.NpcElixir;

            UnknownSlot1 = new SlotCollection<UnknownSlot>();
            UnknownSlot2 = new SlotCollection<UnknownSlot>();
            UnknownSlot3 = new SlotCollection<UnknownSlot>();
        }
        #endregion

        #region Fields
        /// <summary>
        /// Unknown integer 1.
        /// </summary>
        public int Unknown1;

        /// <summary>
        /// User ID.
        /// </summary>
        public long UserID;
        /// <summary>
        /// Home ID. Usually same as <see cref="UserID"/>.
        /// </summary>
        public long HomeID;
        /// <summary>
        /// Data of the clan of the avatar.
        /// </summary>
        public ClanMessageComponent ClanData;

        /// <summary>
        /// Legendery Trophy Count.
        /// </summary>
        public int LegenderyTrophy; // 0
        /// <summary>
        /// Best Season Is Player Legendary Stats.
        /// </summary>
        public int BestSeasonEnabled; // 0
        /// <summary>
        /// Best Season In Legendary Stats Month.
        /// </summary>
        public int BestSeasonMonth; // 0
        /// <summary>
        /// Best Season In Legendary Stats Month.
        /// </summary>
        public int BestSeasonYear; // 0
        /// <summary>
        /// Best Season In Legendary Stats Year.
        /// </summary>
        public int BestSeasonPosition; // 0
        /// <summary>
        /// Best Season In Legendary Stats Trophies.
        /// </summary>
        public int BestSeasonTrophies; // 0
        /// <summary>
        /// Last Season Is Player Legendary Stats.
        /// </summary>
        public int LastSeasonEnabled; // 0
        /// <summary>
        /// Last Season In Legendary Stats Month.
        /// </summary>
        public int LastSeasonMonth; // 0
        /// <summary>
        /// Last Season In Legendary Stats Year.
        /// </summary>
        public int LastSeasonYear; // 0
        /// <summary>
        /// Last Season In Legendary Stats Position.
        /// </summary>
        public int LastSeasonPosition; // 0
        /// <summary>
        /// Last Season In Legendary Stats Trophies.
        /// </summary>
        public int LastSeasonTrophies; // 0
        /// <summary>
        /// League ID.
        /// </summary>
        public int LeagueLevel;
        /// <summary>
        /// Alliance castle level.
        /// </summary>
        public int AllianceCastleLevel;
        /// <summary>
        /// Alliance castle capacity.
        /// </summary>
        public int AllianceCastleTotalCapacity;
        /// <summary>
        /// Alliance castle troop count.
        /// </summary>
        public int AllianceCastleUsedCapacity;
        /// <summary>
        /// Unknown integer 13.
        /// </summary>
        public int Unknown13; // -1
        /// <summary>
        /// Unknown integer 14.
        /// </summary>
        public int Unknown14; // -1
        /// <summary>
        /// TownHall level.
        /// </summary>
        public int TownHallLevel;
        /// <summary>
        /// Name of avatar.
        /// </summary>
        public string Name;
        /// <summary>
        /// Unknown integer 15.
        /// </summary>
        public int Unknown15;
        /// <summary>
        /// Level of avatar.
        /// </summary>
        public int Level;
        /// <summary>
        /// Experience of avatar.
        /// </summary>
        public int Experience;
        /// <summary>
        /// Gems available.
        /// </summary>
        public int Gems;
        /// <summary>
        /// Free gems available.
        /// </summary>
        public int FreeGems;
        /// <summary>
        /// Unknown integer 16.
        /// </summary>
        public int Unknown16;

        /// <summary>
        /// Trophies count.
        /// </summary>
        public int Trophies;

        /// <summary>
        /// Number of attacks won.
        /// </summary>
        public int AttacksWon; // 0
        /// <summary>
        /// Number of attacks lost.
        /// </summary>
        public int AttacksLost; // 0
        /// <summary>
        /// Number of defenses won.
        /// </summary>
        public int DefensesWon; // 0
        /// <summary>
        /// Number of defenses lost.
        /// </summary> 
        public int DefensesLost; // 0

        /// <summary>
        /// Unknown integer 17.
        /// </summary>
        public int Unknown17; // 0
        /// <summary>
        /// Unknown integer 18.
        /// </summary>
        public int Unknown18; // 0
        /// <summary>
        /// Unknown integer 19.
        /// </summary>
        public int Unknown19; // 0
        /// <summary>
        /// Unknown integer 20.
        /// </summary>
        public int Unknown20; // 1
        /// <summary>
        /// Unknown byte 21.
        /// </summary>
        public byte Unknown21;

        /// <summary>
        /// Avatar name is set.
        /// </summary>
        public bool IsNamed;

        /// <summary>
        /// Unknown long 22.
        /// </summary>
        public long Unknown22;
        /// <summary>
        /// Unknown integer 23.
        /// </summary>
        public int Unknown23;
        /// <summary>
        /// Unknown integer 24.
        /// </summary>
        public int Unknown24;
        /// <summary>
        /// Unknown integer 25.
        /// </summary>
        public int Unknown25;
        /// <summary>
        /// Unknown integer 26.
        /// </summary>
        public int Unknown26;
        /// <summary>
        /// Unknown integer 27.
        /// </summary>
        public int Unknown27;
        /// <summary>
        /// Unknown integer 28.
        /// </summary>
        public int Unknown28;
        /// <summary>
        /// Unknown integer 29.
        /// </summary>
        public int Unknown29;
        /// <summary>
        /// Unknown byte 30.
        /// </summary>
        public byte Unknown30;

        /// <summary>
        /// Resources capacity.
        /// </summary>
        public SlotCollection<ResourceCapacitySlot> ResourcesCapacity;
        /// <summary>
        /// Resources amount.
        /// </summary>
        public SlotCollection<ResourceAmountSlot> ResourcesAmount;
        /// <summary>
        /// Units.
        /// </summary>
        public SlotCollection<UnitSlot> Units;
        /// <summary>
        /// Spells.
        /// </summary>
        public SlotCollection<SpellSlot> Spells;
        /// <summary>
        /// Unit upgrades level.
        /// </summary>
        public SlotCollection<UnitUpgradeSlot> UnitUpgrades;
        /// <summary>
        /// Spell upgrades level.
        /// </summary>
        public SlotCollection<SpellUpgradeSlot> SpellUpgrades;
        /// <summary>
        /// Hero upgrades level.
        /// </summary>
        public SlotCollection<HeroUpgradeSlot> HeroUpgrades;
        /// <summary>
        /// Hero healths.
        /// </summary>
        public SlotCollection<HeroHealthSlot> HeroHealths;
        /// <summary>
        /// Hero states.
        /// </summary>
        public SlotCollection<HeroStateSlot> HeroStates;
        /// <summary>
        /// Alliance units
        /// </summary>
        public SlotCollection<AllianceUnitSlot> AllianceUnits;
        /// <summary>
        /// Tutorial progress.
        /// </summary>
        public SlotCollection<TutorialProgressSlot> TutorialProgess;
        /// <summary>
        /// Achievements state.
        /// </summary>
        public SlotCollection<AchievementSlot> Achievements;
        /// <summary>
        /// Achievement progress.
        /// </summary>
        public SlotCollection<AchievementProgessSlot> AchievementProgress;
        /// <summary>
        /// NPC stars.
        /// </summary>
        public SlotCollection<NpcStarSlot> NpcStars;
        /// <summary>
        /// NPC gold.
        /// </summary>
        public SlotCollection<NpcGoldSlot> NpcGold;
        /// <summary>
        /// NPC elixir.
        /// </summary>
        public SlotCollection<NpcElixirSlot> NpcElixir;

        /// <summary>
        /// Unknown slot 1.
        /// </summary>
        public SlotCollection<UnknownSlot> UnknownSlot1;
        /// <summary>
        /// Unknown slot 2.
        /// </summary>
        public SlotCollection<UnknownSlot> UnknownSlot2;
        /// <summary>
        /// Unknown slot 3.
        /// </summary>
        public SlotCollection<UnknownSlot> UnknownSlot3;
        /// <summary>
        /// Unknown slot 4.
        /// </summary>
        public SlotCollection<UnknownSlot> UnknownSlot4;

        /// <summary>
        /// Unknown integer 31.
        /// </summary>
        public int Unknown31;
        /// <summary>
        /// Unknown integer 32.
        /// </summary>
        public int Unknown32;
        /// <summary>
        /// Unknown integer 33.
        /// </summary>
        public int Unknown33;

        /// <summary>
        /// Unknown slot 5;
        /// </summary>
        public SlotCollection<UnitSlot> UnknownSlot5;
        #endregion

        #region Methods
        /// <summary>
        /// Reads the <see cref="AvatarMessageComponent"/> from the specified <see cref="MessageReader"/>.
        /// </summary>
        /// <param name="reader">
        /// <see cref="MessageReader"/> that will be used to read the <see cref="AvatarMessageComponent"/>.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="reader"/> is null.</exception>
        public override void ReadMessageComponent(MessageReader reader)
        {
            ThrowIfReaderNull(reader);

            Unknown1 = reader.ReadInt32();

            UserID = reader.ReadInt64();
            HomeID = reader.ReadInt64();
            if (reader.ReadBoolean())
            {
                ClanData = new ClanMessageComponent();
                ClanData.ID = reader.ReadInt64();
                ClanData.Name = reader.ReadString();
                ClanData.Badge = reader.ReadInt32();
                ClanData.Role = (ClanMemberRole)reader.ReadInt32();
                ClanData.Level = reader.ReadInt32();
                ClanData.Unknown1 = reader.ReadByte(); // Clan war?
                if (ClanData.Unknown1 == 1)
                    ClanData.Unknown2 = reader.ReadInt64(); // Clan war ID?
            }

            LegenderyTrophy = reader.ReadInt32();
            BestSeasonEnabled = reader.ReadInt32();
            BestSeasonMonth = reader.ReadInt32();
            BestSeasonYear = reader.ReadInt32();
            BestSeasonPosition = reader.ReadInt32();
            BestSeasonTrophies = reader.ReadInt32();
            LastSeasonEnabled = reader.ReadInt32();
            LastSeasonMonth = reader.ReadInt32();
            LastSeasonYear = reader.ReadInt32();
            LastSeasonPosition = reader.ReadInt32();
            LastSeasonTrophies = reader.ReadInt32();

            LeagueLevel = reader.ReadInt32();
            AllianceCastleLevel = reader.ReadInt32();
            AllianceCastleTotalCapacity = reader.ReadInt32();
            AllianceCastleUsedCapacity = reader.ReadInt32();

            Unknown13 = reader.ReadInt32(); // 0 = 8.x.x
            Unknown14 = reader.ReadInt32(); // -1 = 8.x.x

            TownHallLevel = reader.ReadInt32();
            Name = reader.ReadString();

            Unknown15 = reader.ReadInt32(); // -1, Facebook ID

            Level = reader.ReadInt32();
            Experience = reader.ReadInt32();
            Gems = reader.ReadInt32(); // Scrambled when not own avatar data.
            FreeGems = reader.ReadInt32(); // Scrambled when not own avatar data.

            Unknown16 = reader.ReadInt32(); // 1200 // Scrambled when not own avatar data.
            Unknown17 = reader.ReadInt32(); // 60 // Scrambled when not own avatar data.

            Trophies = reader.ReadInt32();
            AttacksWon = reader.ReadInt32();
            AttacksLost = reader.ReadInt32(); // Scrambled when not own avatar data.
            DefensesWon = reader.ReadInt32();
            DefensesLost = reader.ReadInt32(); // Scrambled when not own avatar data.

            Unknown18 = reader.ReadInt32();
            Unknown19 = reader.ReadInt32();
            Unknown20 = reader.ReadInt32();

            // 8.511.4
            Unknown29 = reader.ReadInt32();

            Unknown21 = reader.ReadByte(); // 1, might be a bool
            Unknown22 = reader.ReadInt64(); // 946720861000

            IsNamed = reader.ReadBoolean();

            Unknown23 = reader.ReadInt32();
            Unknown24 = reader.ReadInt32(); // Scrambled when not own avatar data.
            Unknown25 = reader.ReadInt32();
            Unknown26 = reader.ReadInt32(); // 1
            Unknown27 = reader.ReadInt32(); // 0 = 8.x.x
            Unknown28 = reader.ReadInt32(); // 0 = 8.x.x

            // 8.551.4
            Unknown30 = reader.ReadByte();

            ResourcesCapacity = reader.Read<ResourceCapacitySlot>();
            ResourcesAmount = reader.Read<ResourceAmountSlot>();
            Units = reader.Read<UnitSlot>();
            Spells = reader.Read<SpellSlot>();
            UnitUpgrades = reader.Read<UnitUpgradeSlot>();
            SpellUpgrades = reader.Read<SpellUpgradeSlot>();
            HeroUpgrades = reader.Read<HeroUpgradeSlot>();
            HeroHealths = reader.Read<HeroHealthSlot>();
            HeroStates = reader.Read<HeroStateSlot>();
            AllianceUnits = reader.Read<AllianceUnitSlot>();
            TutorialProgess = reader.Read<TutorialProgressSlot>();
            Achievements = reader.Read<AchievementSlot>();
            AchievementProgress = reader.Read<AchievementProgessSlot>();
            NpcStars = reader.Read<NpcStarSlot>();
            NpcGold = reader.Read<NpcGoldSlot>();
            NpcElixir = reader.Read<NpcElixirSlot>();

            UnknownSlot1 = reader.Read<UnknownSlot>();
            UnknownSlot2 = reader.Read<UnknownSlot>();
            UnknownSlot3 = reader.Read<UnknownSlot>();
            UnknownSlot4 = reader.Read<UnknownSlot>();

            // 8.551.4
            // Those might be resource lists as well.
            Unknown31 = reader.ReadInt32();
            Unknown32 = reader.ReadInt32();
            Unknown33 = reader.ReadInt32();

            UnknownSlot5 = reader.Read<UnitSlot>();
        }

        /// <summary>
        /// Writes the <see cref="AvatarMessageComponent"/> to the specified <see cref="MessageWriter"/>.
        /// </summary>
        /// <param name="writer">
        /// <see cref="MessageWriter"/> that will be used to write the <see cref="AvatarMessageComponent"/>.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="writer"/> is null.</exception>
        public override void WriteMessageComponent(MessageWriter writer)
        {
            ThrowIfWriterNull(writer);

            writer.Write(Unknown1);

            writer.Write(UserID);
            writer.Write(HomeID);
            writer.Write(ClanData != null);
            if (ClanData != null)
            {
                writer.Write(ClanData.ID);
                writer.Write(ClanData.Name);
                writer.Write(ClanData.Badge);
                writer.Write((int)ClanData.Role);
                writer.Write(ClanData.Level);
                writer.Write(ClanData.Unknown1);
                if (ClanData.Unknown1 == 1)
                    writer.Write(ClanData.Unknown2);
            }

            writer.Write(LegenderyTrophy);
            writer.Write(BestSeasonEnabled);
            writer.Write(BestSeasonMonth);
            writer.Write(BestSeasonYear);
            writer.Write(BestSeasonPosition);
            writer.Write(BestSeasonTrophies);
            writer.Write(LastSeasonEnabled);
            writer.Write(LastSeasonMonth);
            writer.Write(LastSeasonYear);
            writer.Write(LastSeasonPosition); // 1
            writer.Write(LastSeasonTrophies);

            writer.Write(LeagueLevel);
            writer.Write(AllianceCastleLevel);
            writer.Write(AllianceCastleTotalCapacity);
            writer.Write(AllianceCastleUsedCapacity);
            writer.Write(Unknown13); // 1 = 8.x.x
            writer.Write(Unknown14); // 0 = 8.x.x
            writer.Write(TownHallLevel);
            writer.Write(Name);

            writer.Write(Unknown15); // -1

            writer.Write(Level);
            writer.Write(Experience);
            writer.Write(Gems);
            writer.Write(FreeGems);

            writer.Write(Unknown16); // 1200
            writer.Write(Unknown17); // 60

            writer.Write(Trophies);

            writer.Write(AttacksWon);
            writer.Write(AttacksLost);
            writer.Write(DefensesWon);
            writer.Write(DefensesLost);

            writer.Write(Unknown18);
            writer.Write(Unknown19);
            writer.Write(Unknown20);

            // 8.551.4
            writer.Write(Unknown29);

            writer.Write(Unknown21); // 1, might be a bool
            writer.Write(Unknown22); // 946720861000

            writer.Write(IsNamed);

            writer.Write(Unknown23);
            writer.Write(Unknown24);
            writer.Write(Unknown25);
            writer.Write(Unknown26); // 1
            writer.Write(Unknown27); // 1 = 8.x.x
            writer.Write(Unknown28); // 0 = 8.x.x

            // 8.551.4
            writer.Write(Unknown30);

            writer.Write(ResourcesCapacity);
            writer.Write(ResourcesAmount);
            writer.Write(Units);
            writer.Write(Spells);
            writer.Write(UnitUpgrades);
            writer.Write(SpellUpgrades);
            writer.Write(HeroUpgrades);
            writer.Write(HeroHealths);
            writer.Write(HeroStates);
            writer.Write(AllianceUnits);
            writer.Write(TutorialProgess);
            writer.Write(Achievements);
            writer.Write(AchievementProgress);
            writer.Write(NpcStars);
            writer.Write(NpcGold);
            writer.Write(NpcElixir);

            writer.Write(UnknownSlot1);
            writer.Write(UnknownSlot2);
            writer.Write(UnknownSlot3);
            writer.Write(UnknownSlot4);

            writer.Write(Unknown31);
            writer.Write(Unknown32);
            writer.Write(Unknown33);

            writer.Write(UnknownSlot5);
        }
        #endregion
    }
}
