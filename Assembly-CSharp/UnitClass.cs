using System;

// Token: 0x02000A4A RID: 2634
public enum UnitClass
{
	// Token: 0x0400397B RID: 14715
	Warrior = 1,
	// Token: 0x0400397C RID: 14716
	Duelist,
	// Token: 0x0400397D RID: 14717
	Tactician,
	// Token: 0x0400397E RID: 14718
	StrangeSuperGuy = 666,
	// Token: 0x0400397F RID: 14719
	Paladin = 5,
	// Token: 0x04003980 RID: 14720
	StreetMan,
	// Token: 0x04003981 RID: 14721
	OldWiseMan = 11,
	// Token: 0x04003982 RID: 14722
	TownManager,
	// Token: 0x04003983 RID: 14723
	ArmorShopManager,
	// Token: 0x04003984 RID: 14724
	WeaponShopManager,
	// Token: 0x04003985 RID: 14725
	SchoolManager,
	// Token: 0x04003986 RID: 14726
	ShopManager,
	// Token: 0x04003987 RID: 14727
	FurnaceManager,
	// Token: 0x04003988 RID: 14728
	RecruitmentManager,
	// Token: 0x04003989 RID: 14729
	TownGuardian,
	// Token: 0x0400398A RID: 14730
	FirePlayer = 1001,
	// Token: 0x0400398B RID: 14731
	YoungWarlock,
	// Token: 0x0400398C RID: 14732
	Conjurer,
	// Token: 0x0400398D RID: 14733
	ElementalWizard,
	// Token: 0x0400398E RID: 14734
	RedMage,
	// Token: 0x0400398F RID: 14735
	Cube,
	// Token: 0x04003990 RID: 14736
	DrunkReader = 1016,
	// Token: 0x04003991 RID: 14737
	Missionary = 1008,
	// Token: 0x04003992 RID: 14738
	Killer,
	// Token: 0x04003993 RID: 14739
	FashionBoy,
	// Token: 0x04003994 RID: 14740
	SnowMaiden,
	// Token: 0x04003995 RID: 14741
	FireCharger,
	// Token: 0x04003996 RID: 14742
	GoldenShaman,
	// Token: 0x04003997 RID: 14743
	BunSister,
	// Token: 0x04003998 RID: 14744
	IronSolider,
	// Token: 0x04003999 RID: 14745
	SoulThief = 2001,
	// Token: 0x0400399A RID: 14746
	FireAssassin,
	// Token: 0x0400399B RID: 14747
	NightBlade,
	// Token: 0x0400399C RID: 14748
	ToughWoman,
	// Token: 0x0400399D RID: 14749
	ChubbyLady,
	// Token: 0x0400399E RID: 14750
	RedHorn,
	// Token: 0x0400399F RID: 14751
	GrassFace = 10003,
	// Token: 0x040039A0 RID: 14752
	ScreamingShaman,
	// Token: 0x040039A1 RID: 14753
	PurpleOrc = 10001,
	// Token: 0x040039A2 RID: 14754
	BlueShaman = 10005,
	// Token: 0x040039A3 RID: 14755
	RedShaman,
	// Token: 0x040039A4 RID: 14756
	PurpleShaman,
	// Token: 0x040039A5 RID: 14757
	YellowShaman,
	// Token: 0x040039A6 RID: 14758
	YellowSharpTeeth,
	// Token: 0x040039A7 RID: 14759
	BlueGrassFace,
	// Token: 0x040039A8 RID: 14760
	PurpleGrassFace,
	// Token: 0x040039A9 RID: 14761
	GreenDragonPrayer,
	// Token: 0x040039AA RID: 14762
	YellowDragonPrayer,
	// Token: 0x040039AB RID: 14763
	RedDragonPrayer,
	// Token: 0x040039AC RID: 14764
	PurpleDragonPrayer,
	// Token: 0x040039AD RID: 14765
	RedShadowBat,
	// Token: 0x040039AE RID: 14766
	PurpleShadowBat,
	// Token: 0x040039AF RID: 14767
	YellowShadowBat,
	// Token: 0x040039B0 RID: 14768
	GreenShadowBat,
	// Token: 0x040039B1 RID: 14769
	BlueShadowBat,
	// Token: 0x040039B2 RID: 14770
	RedBirdMonster,
	// Token: 0x040039B3 RID: 14771
	PurpleBirdMonster,
	// Token: 0x040039B4 RID: 14772
	YellowBirdMonster,
	// Token: 0x040039B5 RID: 14773
	BlueBirdMonster,
	// Token: 0x040039B6 RID: 14774
	GreenBirdMonster,
	// Token: 0x040039B7 RID: 14775
	BlueDragonPrayer,
	// Token: 0x040039B8 RID: 14776
	BlueBat = 10032,
	// Token: 0x040039B9 RID: 14777
	GreenBat,
	// Token: 0x040039BA RID: 14778
	PurpleBat,
	// Token: 0x040039BB RID: 14779
	RedBat,
	// Token: 0x040039BC RID: 14780
	YellowBat,
	// Token: 0x040039BD RID: 14781
	BlueGoblinWizard = 10052,
	// Token: 0x040039BE RID: 14782
	GreenGoblinWizard,
	// Token: 0x040039BF RID: 14783
	PurpleGoblinWizard,
	// Token: 0x040039C0 RID: 14784
	RedGoblinWizard,
	// Token: 0x040039C1 RID: 14785
	YellowGoblinWizard,
	// Token: 0x040039C2 RID: 14786
	BlueHighMage = 10062,
	// Token: 0x040039C3 RID: 14787
	GreenHighMage,
	// Token: 0x040039C4 RID: 14788
	PurpleHighMage,
	// Token: 0x040039C5 RID: 14789
	RedHighMage,
	// Token: 0x040039C6 RID: 14790
	YellowHighMage,
	// Token: 0x040039C7 RID: 14791
	BlueScorpion = 10072,
	// Token: 0x040039C8 RID: 14792
	GreenScorpion,
	// Token: 0x040039C9 RID: 14793
	PurpleScorpion,
	// Token: 0x040039CA RID: 14794
	RedScorpion,
	// Token: 0x040039CB RID: 14795
	YellowScorpion,
	// Token: 0x040039CC RID: 14796
	BlueStoneGuard = 10082,
	// Token: 0x040039CD RID: 14797
	GreenStoneGuard,
	// Token: 0x040039CE RID: 14798
	PurpleStoneGuard,
	// Token: 0x040039CF RID: 14799
	RedStoneGuard,
	// Token: 0x040039D0 RID: 14800
	YellowStoneGuard,
	// Token: 0x040039D1 RID: 14801
	BlueVampire,
	// Token: 0x040039D2 RID: 14802
	GreenVampire,
	// Token: 0x040039D3 RID: 14803
	PurpleVampire,
	// Token: 0x040039D4 RID: 14804
	RedVampire,
	// Token: 0x040039D5 RID: 14805
	YellowVampire,
	// Token: 0x040039D6 RID: 14806
	Alchemist = 10097,
	// Token: 0x040039D7 RID: 14807
	FireMage,
	// Token: 0x040039D8 RID: 14808
	ImmortalSeeker,
	// Token: 0x040039D9 RID: 14809
	IceBeast,
	// Token: 0x040039DA RID: 14810
	MagicAmor,
	// Token: 0x040039DB RID: 14811
	PoisonMage,
	// Token: 0x040039DC RID: 14812
	SkeletonMage,
	// Token: 0x040039DD RID: 14813
	Trainer,
	// Token: 0x040039DE RID: 14814
	BlackMage,
	// Token: 0x040039DF RID: 14815
	DivineMage,
	// Token: 0x040039E0 RID: 14816
	Glutton,
	// Token: 0x040039E1 RID: 14817
	IceMage,
	// Token: 0x040039E2 RID: 14818
	Skeleton,
	// Token: 0x040039E3 RID: 14819
	Stringy,
	// Token: 0x040039E4 RID: 14820
	RedImmortalSeeker,
	// Token: 0x040039E5 RID: 14821
	HealingStone,
	// Token: 0x040039E6 RID: 14822
	FireStone,
	// Token: 0x040039E7 RID: 14823
	LightningStone,
	// Token: 0x040039E8 RID: 14824
	PoisonStone,
	// Token: 0x040039E9 RID: 14825
	BirdMonsterRed,
	// Token: 0x040039EA RID: 14826
	PurpleBloodEye,
	// Token: 0x040039EB RID: 14827
	PurpleIceBeast,
	// Token: 0x040039EC RID: 14828
	RedIceBeast,
	// Token: 0x040039ED RID: 14829
	GreenGoblin = 20002,
	// Token: 0x040039EE RID: 14830
	SharpTeeth = 20005,
	// Token: 0x040039EF RID: 14831
	GreenOrc,
	// Token: 0x040039F0 RID: 14832
	RedOrc = 20003,
	// Token: 0x040039F1 RID: 14833
	YellowOrc,
	// Token: 0x040039F2 RID: 14834
	PurpleSharpTeeth = 20007,
	// Token: 0x040039F3 RID: 14835
	GreenSpearer = 20011,
	// Token: 0x040039F4 RID: 14836
	RedSpearer,
	// Token: 0x040039F5 RID: 14837
	PurpleSpearer,
	// Token: 0x040039F6 RID: 14838
	YellowSpearer,
	// Token: 0x040039F7 RID: 14839
	GreenDoomFighter = 20017,
	// Token: 0x040039F8 RID: 14840
	RedDoomFighter,
	// Token: 0x040039F9 RID: 14841
	PurpleDoomFighter,
	// Token: 0x040039FA RID: 14842
	BlueDoomFighter,
	// Token: 0x040039FB RID: 14843
	GreenReaper,
	// Token: 0x040039FC RID: 14844
	YellowReaper,
	// Token: 0x040039FD RID: 14845
	RedReaper,
	// Token: 0x040039FE RID: 14846
	PurpleReaper,
	// Token: 0x040039FF RID: 14847
	Berserker,
	// Token: 0x04003A00 RID: 14848
	DarkKnight,
	// Token: 0x04003A01 RID: 14849
	CannibalBear,
	// Token: 0x04003A02 RID: 14850
	Devil,
	// Token: 0x04003A03 RID: 14851
	FireImp,
	// Token: 0x04003A04 RID: 14852
	HeartEater,
	// Token: 0x04003A05 RID: 14853
	EvilMask,
	// Token: 0x04003A06 RID: 14854
	Polymer,
	// Token: 0x04003A07 RID: 14855
	Werewolf,
	// Token: 0x04003A08 RID: 14856
	BloodDevil,
	// Token: 0x04003A09 RID: 14857
	BloodyCreature,
	// Token: 0x04003A0A RID: 14858
	Mutant,
	// Token: 0x04003A0B RID: 14859
	Ogre,
	// Token: 0x04003A0C RID: 14860
	Predator,
	// Token: 0x04003A0D RID: 14861
	Puppeteer,
	// Token: 0x04003A0E RID: 14862
	Savagery,
	// Token: 0x04003A0F RID: 14863
	BlacksmithBrother,
	// Token: 0x04003A10 RID: 14864
	ZombieWarrior,
	// Token: 0x04003A11 RID: 14865
	BlueDevil,
	// Token: 0x04003A12 RID: 14866
	GreenDevil,
	// Token: 0x04003A13 RID: 14867
	PurpleDevil,
	// Token: 0x04003A14 RID: 14868
	RedDevil,
	// Token: 0x04003A15 RID: 14869
	YellowDevil,
	// Token: 0x04003A16 RID: 14870
	BlueCannibalBear,
	// Token: 0x04003A17 RID: 14871
	GreenCannibalBear,
	// Token: 0x04003A18 RID: 14872
	PurpleCannibalBear,
	// Token: 0x04003A19 RID: 14873
	RedCannibalBear,
	// Token: 0x04003A1A RID: 14874
	YellowCannibalBear,
	// Token: 0x04003A1B RID: 14875
	BlueHeartEater,
	// Token: 0x04003A1C RID: 14876
	GreenHeartEater,
	// Token: 0x04003A1D RID: 14877
	RedHeartEater,
	// Token: 0x04003A1E RID: 14878
	YellowHeartEater,
	// Token: 0x04003A1F RID: 14879
	RedMask,
	// Token: 0x04003A20 RID: 14880
	BlacksmithBrother_Remnants,
	// Token: 0x04003A21 RID: 14881
	BloodEye_Remnants,
	// Token: 0x04003A22 RID: 14882
	CorruptedHorn_Remnants,
	// Token: 0x04003A23 RID: 14883
	DarkKnight_Remnants,
	// Token: 0x04003A24 RID: 14884
	Death_Remnants,
	// Token: 0x04003A25 RID: 14885
	DemonDragon_Remnants,
	// Token: 0x04003A26 RID: 14886
	DemonSkull_Remnants,
	// Token: 0x04003A27 RID: 14887
	DevilMan_Remnants,
	// Token: 0x04003A28 RID: 14888
	Pharmacist_Remnants,
	// Token: 0x04003A29 RID: 14889
	YellowGoblin = 30008,
	// Token: 0x04003A2A RID: 14890
	BlueOrc = 30001,
	// Token: 0x04003A2B RID: 14891
	BlueSharpTeeth,
	// Token: 0x04003A2C RID: 14892
	RedSharpTeeth = 30009,
	// Token: 0x04003A2D RID: 14893
	RedGrassFace = 30012,
	// Token: 0x04003A2E RID: 14894
	YellowGrassFace,
	// Token: 0x04003A2F RID: 14895
	RedArcher,
	// Token: 0x04003A30 RID: 14896
	BlueArcher,
	// Token: 0x04003A31 RID: 14897
	PurpleArcher,
	// Token: 0x04003A32 RID: 14898
	YellowArcher,
	// Token: 0x04003A33 RID: 14899
	RedMud = 30020,
	// Token: 0x04003A34 RID: 14900
	GreenMud,
	// Token: 0x04003A35 RID: 14901
	PurpleMud,
	// Token: 0x04003A36 RID: 14902
	YellowMud,
	// Token: 0x04003A37 RID: 14903
	BlueShadowKiller,
	// Token: 0x04003A38 RID: 14904
	YellowShadowKiller,
	// Token: 0x04003A39 RID: 14905
	RedShadowKiller,
	// Token: 0x04003A3A RID: 14906
	PurpleShadowKiller,
	// Token: 0x04003A3B RID: 14907
	Cyclops,
	// Token: 0x04003A3C RID: 14908
	ShadowSkinner,
	// Token: 0x04003A3D RID: 14909
	Parasite,
	// Token: 0x04003A3E RID: 14910
	Piper,
	// Token: 0x04003A3F RID: 14911
	Puppet,
	// Token: 0x04003A40 RID: 14912
	Ghoul,
	// Token: 0x04003A41 RID: 14913
	IceSkull,
	// Token: 0x04003A42 RID: 14914
	Pharmacist,
	// Token: 0x04003A43 RID: 14915
	BlueCyclops,
	// Token: 0x04003A44 RID: 14916
	GreenCyclops,
	// Token: 0x04003A45 RID: 14917
	PurpleCyclops,
	// Token: 0x04003A46 RID: 14918
	RedCyclops,
	// Token: 0x04003A47 RID: 14919
	DemonSkull = 40000,
	// Token: 0x04003A48 RID: 14920
	DevilMan,
	// Token: 0x04003A49 RID: 14921
	DemonDragon,
	// Token: 0x04003A4A RID: 14922
	Golem,
	// Token: 0x04003A4B RID: 14923
	GreedyMouth,
	// Token: 0x04003A4C RID: 14924
	LavaBeast,
	// Token: 0x04003A4D RID: 14925
	BloodyEye,
	// Token: 0x04003A4E RID: 14926
	Death,
	// Token: 0x04003A4F RID: 14927
	CorruptedHorn,
	// Token: 0x04003A50 RID: 14928
	Hydra,
	// Token: 0x04003A51 RID: 14929
	PurpleBerserker,
	// Token: 0x04003A52 RID: 14930
	BlueBerserker,
	// Token: 0x04003A53 RID: 14931
	GreenBerserker,
	// Token: 0x04003A54 RID: 14932
	ConjourerSpiritRed,
	// Token: 0x04003A55 RID: 14933
	ConjourerSpiritGreen,
	// Token: 0x04003A56 RID: 14934
	ConjourerSpiritBlue,
	// Token: 0x04003A57 RID: 14935
	Thug1,
	// Token: 0x04003A58 RID: 14936
	Thug2,
	// Token: 0x04003A59 RID: 14937
	Thug3,
	// Token: 0x04003A5A RID: 14938
	Thug4,
	// Token: 0x04003A5B RID: 14939
	Thug5,
	// Token: 0x04003A5C RID: 14940
	Thug6,
	// Token: 0x04003A5D RID: 14941
	ThugLeader1,
	// Token: 0x04003A5E RID: 14942
	ThugLeader2,
	// Token: 0x04003A5F RID: 14943
	ThugLeader3,
	// Token: 0x04003A60 RID: 14944
	ThugLeaderBoss,
	// Token: 0x04003A61 RID: 14945
	Nameless,
	// Token: 0x04003A62 RID: 14946
	ThugBoss1,
	// Token: 0x04003A63 RID: 14947
	ThugBoss2,
	// Token: 0x04003A64 RID: 14948
	BlueDemonDragon
}
