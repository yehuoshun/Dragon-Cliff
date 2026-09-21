using System;

// Token: 0x020003AE RID: 942
public enum AdventurerTalentType
{
	// Token: 0x040018D4 RID: 6356
	ElementalDamageIncrease = 1,
	// Token: 0x040018D5 RID: 6357
	AttributeDebuffByRateOnHit,
	// Token: 0x040018D6 RID: 6358
	DispelPositiveEffectsOnHit,
	// Token: 0x040018D7 RID: 6359
	FireBreathFireSeedEnhancement = 5,
	// Token: 0x040018D8 RID: 6360
	NegativeEffectsRefresh,
	// Token: 0x040018D9 RID: 6361
	AttributeBoostOnKillByRate,
	// Token: 0x040018DA RID: 6362
	PushOnHit = 9,
	// Token: 0x040018DB RID: 6363
	FireBreathAbsorbShield,
	// Token: 0x040018DC RID: 6364
	AttributeDebuffByValueOnHit,
	// Token: 0x040018DD RID: 6365
	SkillExtraTarget,
	// Token: 0x040018DE RID: 6366
	FreezeEnhancement,
	// Token: 0x040018DF RID: 6367
	ArcaneCritEnhancement,
	// Token: 0x040018E0 RID: 6368
	SelfHealOnKill,
	// Token: 0x040018E1 RID: 6369
	ShadowSacrificeExplosionEnhancement,
	// Token: 0x040018E2 RID: 6370
	ShadowSacrificeStunEnhancement,
	// Token: 0x040018E3 RID: 6371
	ShadowSacrificeHealOnExplo,
	// Token: 0x040018E4 RID: 6372
	SeedsOfSinPetPush,
	// Token: 0x040018E5 RID: 6373
	DivineHammerDamage,
	// Token: 0x040018E6 RID: 6374
	AttributeBoostOnHealByRate,
	// Token: 0x040018E7 RID: 6375
	PrayDispelEnhancement,
	// Token: 0x040018E8 RID: 6376
	GodSeedStablize,
	// Token: 0x040018E9 RID: 6377
	StunOnHit,
	// Token: 0x040018EA RID: 6378
	AssassinDispelEnhancement,
	// Token: 0x040018EB RID: 6379
	ShieldOnKill,
	// Token: 0x040018EC RID: 6380
	StealSoulDispelEnhancement,
	// Token: 0x040018ED RID: 6381
	ShadowlessDamageEnhancement,
	// Token: 0x040018EE RID: 6382
	AttributeBoostAllMemberOnKillBasedOnSelfRate,
	// Token: 0x040018EF RID: 6383
	TauntDamageEnhancement,
	// Token: 0x040018F0 RID: 6384
	TauntTimeEnhancement,
	// Token: 0x040018F1 RID: 6385
	TauntDebuff,
	// Token: 0x040018F2 RID: 6386
	RoarTargetEnhancement,
	// Token: 0x040018F3 RID: 6387
	ScornChanceEnhancement,
	// Token: 0x040018F4 RID: 6388
	BrightCircleBoostEnhancement,
	// Token: 0x040018F5 RID: 6389
	BrightCircleDispelEnhancement,
	// Token: 0x040018F6 RID: 6390
	BurningHeartStrengthBurnEnhancement,
	// Token: 0x040018F7 RID: 6391
	BurningHeartDispelEnhancement,
	// Token: 0x040018F8 RID: 6392
	GrandStrategyDamageEnhancement,
	// Token: 0x040018F9 RID: 6393
	GrandStrategyDispelEnhancement,
	// Token: 0x040018FA RID: 6394
	EmbraceShieldMemberOnKill,
	// Token: 0x040018FB RID: 6395
	DodgeEnhancement,
	// Token: 0x040018FC RID: 6396
	LifeRegen,
	// Token: 0x040018FD RID: 6397
	VitalityEnhancement,
	// Token: 0x040018FE RID: 6398
	TauntEnhancement,
	// Token: 0x040018FF RID: 6399
	FurySpeed,
	// Token: 0x04001900 RID: 6400
	KillerPower,
	// Token: 0x04001901 RID: 6401
	EnhancedEffects,
	// Token: 0x04001902 RID: 6402
	EnhancedResistances,
	// Token: 0x04001903 RID: 6403
	HitRateEnhancement,
	// Token: 0x04001904 RID: 6404
	NegativeEffectResistanceBoost,
	// Token: 0x04001905 RID: 6405
	ElementDamageEnhancement,
	// Token: 0x04001906 RID: 6406
	FireShield,
	// Token: 0x04001907 RID: 6407
	ShadowOfGhost,
	// Token: 0x04001908 RID: 6408
	ProtectorTalent,
	// Token: 0x04001909 RID: 6409
	RestrictionOfTime,
	// Token: 0x0400190A RID: 6410
	PoisonEnhancement,
	// Token: 0x0400190B RID: 6411
	BlackBlood,
	// Token: 0x0400190C RID: 6412
	DivineHeart,
	// Token: 0x0400190D RID: 6413
	PhysicalEnhancement,
	// Token: 0x0400190E RID: 6414
	ShadowEnhancement,
	// Token: 0x0400190F RID: 6415
	IceEnhancement,
	// Token: 0x04001910 RID: 6416
	DivineEnhancement,
	// Token: 0x04001911 RID: 6417
	LightningShield,
	// Token: 0x04001912 RID: 6418
	ActiveTargetDebuff = 66,
	// Token: 0x04001913 RID: 6419
	CritDamageBoost,
	// Token: 0x04001914 RID: 6420
	EfficiencyBoost,
	// Token: 0x04001915 RID: 6421
	StunEnhancement,
	// Token: 0x04001916 RID: 6422
	RecoveryEnhancement,
	// Token: 0x04001917 RID: 6423
	TargetSelectionBuff,
	// Token: 0x04001918 RID: 6424
	SpellOfHolinessDispelHeal,
	// Token: 0x04001919 RID: 6425
	SpellOfHolinessDamage,
	// Token: 0x0400191A RID: 6426
	SpiritOfDemonBoost,
	// Token: 0x0400191B RID: 6427
	ArmorOfWindExtraHit,
	// Token: 0x0400191C RID: 6428
	ArmorOfWindAttributeBuff,
	// Token: 0x0400191D RID: 6429
	EmbracedShieldExtraHit,
	// Token: 0x0400191E RID: 6430
	EmbracedShieldDispel,
	// Token: 0x0400191F RID: 6431
	EmbracedStun,
	// Token: 0x04001920 RID: 6432
	BloodCurseDispelAllMember,
	// Token: 0x04001921 RID: 6433
	BloodCurseDispelOnHit,
	// Token: 0x04001922 RID: 6434
	BloodCurseOutputDepression,
	// Token: 0x04001923 RID: 6435
	HeartlessTrigger,
	// Token: 0x04001924 RID: 6436
	HeartlessSeedEnhancement,
	// Token: 0x04001925 RID: 6437
	HeartlessSingleHit,
	// Token: 0x04001926 RID: 6438
	CurseOfTheDeadDamageBoost,
	// Token: 0x04001927 RID: 6439
	FormlessAttributeDecay,
	// Token: 0x04001928 RID: 6440
	FormlessExtraHit,
	// Token: 0x04001929 RID: 6441
	FormlessDispel,
	// Token: 0x0400192A RID: 6442
	GhostlySmokeConfusionEnhancement,
	// Token: 0x0400192B RID: 6443
	SpitFireProtectionEnhancement,
	// Token: 0x0400192C RID: 6444
	SpitFireFocusEnhancement,
	// Token: 0x0400192D RID: 6445
	SpitFireDispelEnhancement,
	// Token: 0x0400192E RID: 6446
	PoisonMistDispelEnhancement,
	// Token: 0x0400192F RID: 6447
	SunderDepressionEnhancement,
	// Token: 0x04001930 RID: 6448
	SunderTauntEnhancement,
	// Token: 0x04001931 RID: 6449
	SwiftWindDamageSwitchEnhancement,
	// Token: 0x04001932 RID: 6450
	SwiftWindAgilityBoostEnhancement,
	// Token: 0x04001933 RID: 6451
	SwiftWindPushBoostEnhancement,
	// Token: 0x04001934 RID: 6452
	DrunknessExtraTargetEnhancement,
	// Token: 0x04001935 RID: 6453
	ThousandKnivesDepressionEnhancement,
	// Token: 0x04001936 RID: 6454
	ThousandKnivesDamageEnhancement,
	// Token: 0x04001937 RID: 6455
	ThousandKnivesDispelEnhancement,
	// Token: 0x04001938 RID: 6456
	RotationShieldEnhancement,
	// Token: 0x04001939 RID: 6457
	RotationDispelEnhancement,
	// Token: 0x0400193A RID: 6458
	RotationAttributeDecay,
	// Token: 0x0400193B RID: 6459
	TacticRageCostChange,
	// Token: 0x0400193C RID: 6460
	ActiveTargetPushProgress,
	// Token: 0x0400193D RID: 6461
	GrandMeteoroliteElementalChange,
	// Token: 0x0400193E RID: 6462
	FrenzyDispelEnhancement,
	// Token: 0x0400193F RID: 6463
	FrenzyPushEnhancemednt,
	// Token: 0x04001940 RID: 6464
	FrenzyStunEnhancement,
	// Token: 0x04001941 RID: 6465
	SeductionExtraTarget,
	// Token: 0x04001942 RID: 6466
	SeductionAttributeDecayEnhancement,
	// Token: 0x04001943 RID: 6467
	SeductionSelfCleanEnhancement,
	// Token: 0x04001944 RID: 6468
	ActiveTargetAttributeDecayPriorCast,
	// Token: 0x04001945 RID: 6469
	ActiveTargetDispelPositivePriorCast,
	// Token: 0x04001946 RID: 6470
	CrashExtraDamage,
	// Token: 0x04001947 RID: 6471
	CrashExtraHit,
	// Token: 0x04001948 RID: 6472
	CrashDispel
}
