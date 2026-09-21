using System;

// Token: 0x02000924 RID: 2340
public enum SpecialEffectType
{
	// Token: 0x04002FB1 RID: 12209
	None,
	// Token: 0x04002FB2 RID: 12210
	Growth,
	// Token: 0x04002FB3 RID: 12211
	Possession,
	// Token: 0x04002FB4 RID: 12212
	AttributeStealing,
	// Token: 0x04002FB5 RID: 12213
	Starfall,
	// Token: 0x04002FB6 RID: 12214
	AttributeDestroy,
	// Token: 0x04002FB7 RID: 12215
	CowardTimely,
	// Token: 0x04002FB8 RID: 12216
	LifePotion,
	// Token: 0x04002FB9 RID: 12217
	DeadMatch,
	// Token: 0x04002FBA RID: 12218
	Phenix,
	// Token: 0x04002FBB RID: 12219
	SoulCollection,
	// Token: 0x04002FBC RID: 12220
	ClearWater,
	// Token: 0x04002FBD RID: 12221
	ExtraTargetting,
	// Token: 0x04002FBE RID: 12222
	Fadeout,
	// Token: 0x04002FBF RID: 12223
	TauntRecovery,
	// Token: 0x04002FC0 RID: 12224
	Charge,
	// Token: 0x04002FC1 RID: 12225
	Sufferless,
	// Token: 0x04002FC2 RID: 12226
	SpiritOfDeadGeneralEffect,
	// Token: 0x04002FC3 RID: 12227
	FairyStoneEffect,
	// Token: 0x04002FC4 RID: 12228
	EmeraldOfClearHeartEffect,
	// Token: 0x04002FC5 RID: 12229
	BoneOfRaptureEffect,
	// Token: 0x04002FC6 RID: 12230
	UndeadAshEffect,
	// Token: 0x04002FC7 RID: 12231
	MonksEyesEffect,
	// Token: 0x04002FC8 RID: 12232
	StoneOfSoulbringerEffect,
	// Token: 0x04002FC9 RID: 12233
	SavageHeartEffect,
	// Token: 0x04002FCA RID: 12234
	FlyingFeatherEffect,
	// Token: 0x04002FCB RID: 12235
	GodsMoralEffect,
	// Token: 0x04002FCC RID: 12236
	DemonicFireEffect,
	// Token: 0x04002FCD RID: 12237
	ElementEffects,
	// Token: 0x04002FCE RID: 12238
	ElementReplacement = 30,
	// Token: 0x04002FCF RID: 12239
	DarkKnightRage,
	// Token: 0x04002FD0 RID: 12240
	RageHeal,
	// Token: 0x04002FD1 RID: 12241
	DarknessRevengeEffect,
	// Token: 0x04002FD2 RID: 12242
	LavaBeastEffect,
	// Token: 0x04002FD3 RID: 12243
	InversedMandate,
	// Token: 0x04002FD4 RID: 12244
	PoisonMist,
	// Token: 0x04002FD5 RID: 12245
	DemonSkullEffect,
	// Token: 0x04002FD6 RID: 12246
	CorruptedHornEffect,
	// Token: 0x04002FD7 RID: 12247
	DungeonScaleUndeadEffect,
	// Token: 0x04002FD8 RID: 12248
	ThousandWarmsNest,
	// Token: 0x04002FD9 RID: 12249
	DarknessEffect,
	// Token: 0x04002FDA RID: 12250
	DeathShadowEffect,
	// Token: 0x04002FDB RID: 12251
	BlessedSinEffect,
	// Token: 0x04002FDC RID: 12252
	BloodEyeSelfProtectionEffect,
	// Token: 0x04002FDD RID: 12253
	DivineBlindnessEffect,
	// Token: 0x04002FDE RID: 12254
	HydraSpiritEffect,
	// Token: 0x04002FDF RID: 12255
	DemonDragonEffect,
	// Token: 0x04002FE0 RID: 12256
	NegativeEffectSpeedup,
	// Token: 0x04002FE1 RID: 12257
	TrickyDefence,
	// Token: 0x04002FE2 RID: 12258
	MagicBreadEffect,
	// Token: 0x04002FE3 RID: 12259
	FieryTaleEffect,
	// Token: 0x04002FE4 RID: 12260
	Transcendence,
	// Token: 0x04002FE5 RID: 12261
	Enlightment,
	// Token: 0x04002FE6 RID: 12262
	ProtectorsPride,
	// Token: 0x04002FE7 RID: 12263
	KillingIntent,
	// Token: 0x04002FE8 RID: 12264
	Rejuvenation,
	// Token: 0x04002FE9 RID: 12265
	Sacrifice,
	// Token: 0x04002FEA RID: 12266
	FirstHand,
	// Token: 0x04002FEB RID: 12267
	LifeGen,
	// Token: 0x04002FEC RID: 12268
	StoneGuard,
	// Token: 0x04002FED RID: 12269
	Victious,
	// Token: 0x04002FEE RID: 12270
	ImmortalShield,
	// Token: 0x04002FEF RID: 12271
	TattoringFoes,
	// Token: 0x04002FF0 RID: 12272
	ShiftShield,
	// Token: 0x04002FF1 RID: 12273
	CommonEnemy,
	// Token: 0x04002FF2 RID: 12274
	Purification,
	// Token: 0x04002FF3 RID: 12275
	ConfidentHealer,
	// Token: 0x04002FF4 RID: 12276
	DispelOnHit,
	// Token: 0x04002FF5 RID: 12277
	PushOnHit,
	// Token: 0x04002FF6 RID: 12278
	ReviveDamage,
	// Token: 0x04002FF7 RID: 12279
	OutputResistanceBoost,
	// Token: 0x04002FF8 RID: 12280
	SoulCollectionUnDispellable,
	// Token: 0x04002FF9 RID: 12281
	ClearWaterDispelShield,
	// Token: 0x04002FFA RID: 12282
	BossMaterialDrop,
	// Token: 0x04002FFB RID: 12283
	ExcessiveDamageToOtherUnit,
	// Token: 0x04002FFC RID: 12284
	ExcessiveHealToOtherUnit,
	// Token: 0x04002FFD RID: 12285
	PositiveEffectBoost,
	// Token: 0x04002FFE RID: 12286
	NegativeEffectBoost,
	// Token: 0x04002FFF RID: 12287
	StrongMan,
	// Token: 0x04003000 RID: 12288
	HardLife,
	// Token: 0x04003001 RID: 12289
	StrongGuard,
	// Token: 0x04003002 RID: 12290
	Mindless,
	// Token: 0x04003003 RID: 12291
	StandingKiller,
	// Token: 0x04003004 RID: 12292
	HealingStrength,
	// Token: 0x04003005 RID: 12293
	StandingGun,
	// Token: 0x04003006 RID: 12294
	ThugPower,
	// Token: 0x04003007 RID: 12295
	TimeLockResistance,
	// Token: 0x04003008 RID: 12296
	TurnResistance,
	// Token: 0x04003009 RID: 12297
	EffectSeal,
	// Token: 0x0400300A RID: 12298
	PoisonSeed = 91,
	// Token: 0x0400300B RID: 12299
	CourageBlessing,
	// Token: 0x0400300C RID: 12300
	PowerThirst,
	// Token: 0x0400300D RID: 12301
	ReflectionBoost,
	// Token: 0x0400300E RID: 12302
	DecayBlade,
	// Token: 0x0400300F RID: 12303
	Outrage,
	// Token: 0x04003010 RID: 12304
	Respite,
	// Token: 0x04003011 RID: 12305
	ClearUp,
	// Token: 0x04003012 RID: 12306
	Swallow,
	// Token: 0x04003013 RID: 12307
	ExtremeTaunt,
	// Token: 0x04003014 RID: 12308
	ElementalMaster,
	// Token: 0x04003015 RID: 12309
	Disease,
	// Token: 0x04003016 RID: 12310
	Agility,
	// Token: 0x04003017 RID: 12311
	RageBoost,
	// Token: 0x04003018 RID: 12312
	IceHeart,
	// Token: 0x04003019 RID: 12313
	LifeBind,
	// Token: 0x0400301A RID: 12314
	Fear,
	// Token: 0x0400301B RID: 12315
	ResistanceKillBoost,
	// Token: 0x0400301C RID: 12316
	GrowthPerAdventure,
	// Token: 0x0400301D RID: 12317
	AgilityIdleBoost,
	// Token: 0x0400301E RID: 12318
	EyeOfPrecisionEffect,
	// Token: 0x0400301F RID: 12319
	MissHaste,
	// Token: 0x04003020 RID: 12320
	DispelOnHeal,
	// Token: 0x04003021 RID: 12321
	HealOverTimeBoost,
	// Token: 0x04003022 RID: 12322
	LifeRegen,
	// Token: 0x04003023 RID: 12323
	CommandmentOfSpell,
	// Token: 0x04003024 RID: 12324
	FlyingBlade,
	// Token: 0x04003025 RID: 12325
	DodgeProtection,
	// Token: 0x04003026 RID: 12326
	WarmFlow,
	// Token: 0x04003027 RID: 12327
	SpiritualHeart,
	// Token: 0x04003028 RID: 12328
	TigerRoar,
	// Token: 0x04003029 RID: 12329
	Stopper,
	// Token: 0x0400302A RID: 12330
	GodBlessing,
	// Token: 0x0400302B RID: 12331
	AttributeBoostOnStart,
	// Token: 0x0400302C RID: 12332
	OutputBoostOnStart,
	// Token: 0x0400302D RID: 12333
	EvilHeart,
	// Token: 0x0400302E RID: 12334
	FireShield,
	// Token: 0x0400302F RID: 12335
	ShadowOfGhost,
	// Token: 0x04003030 RID: 12336
	RestrictionOfTime,
	// Token: 0x04003031 RID: 12337
	Protector,
	// Token: 0x04003032 RID: 12338
	PoisonEffectEnhancement,
	// Token: 0x04003033 RID: 12339
	BlackBlood,
	// Token: 0x04003034 RID: 12340
	DivineHeart,
	// Token: 0x04003035 RID: 12341
	PhysicalEffectEnhancement,
	// Token: 0x04003036 RID: 12342
	ShadowEffectEnhancement,
	// Token: 0x04003037 RID: 12343
	IceEffectEnhancement,
	// Token: 0x04003038 RID: 12344
	DivineEffectEnhancement,
	// Token: 0x04003039 RID: 12345
	LightningShield,
	// Token: 0x0400303A RID: 12346
	BrokenIce,
	// Token: 0x0400303B RID: 12347
	Timeless,
	// Token: 0x0400303C RID: 12348
	LightningEnhancement,
	// Token: 0x0400303D RID: 12349
	StreetManEnhancement,
	// Token: 0x0400303E RID: 12350
	DrunkReaderEnhancement,
	// Token: 0x0400303F RID: 12351
	Arrogance,
	// Token: 0x04003040 RID: 12352
	KillerEnhancement,
	// Token: 0x04003041 RID: 12353
	SnowMaideEnhancement,
	// Token: 0x04003042 RID: 12354
	FashionEnhancement,
	// Token: 0x04003043 RID: 12355
	AttributeDepression,
	// Token: 0x04003044 RID: 12356
	Curse,
	// Token: 0x04003045 RID: 12357
	UnitLock,
	// Token: 0x04003046 RID: 12358
	EvilLust = 152,
	// Token: 0x04003047 RID: 12359
	ActiveStrategyTargetBoost,
	// Token: 0x04003048 RID: 12360
	ActiveStrategyTargetDebuff,
	// Token: 0x04003049 RID: 12361
	SpellOfHolinessHeal,
	// Token: 0x0400304A RID: 12362
	SpellOfHolinessDamage,
	// Token: 0x0400304B RID: 12363
	ConjourerPetEnhancement,
	// Token: 0x0400304C RID: 12364
	RageOccupy,
	// Token: 0x0400304D RID: 12365
	ArmorOfWindNumberEnhancement,
	// Token: 0x0400304E RID: 12366
	ArmorOfWindAttributeEnhancement,
	// Token: 0x0400304F RID: 12367
	EmbracedShieldNumberEnhancement,
	// Token: 0x04003050 RID: 12368
	EmbracedShieldDispelEnhancement,
	// Token: 0x04003051 RID: 12369
	EmbracedShieldStunEnhancement,
	// Token: 0x04003052 RID: 12370
	BloodCurseDispelPartyEnhancement,
	// Token: 0x04003053 RID: 12371
	BloodCurseDispelOnHitEnhancement,
	// Token: 0x04003054 RID: 12372
	BloodCurseOutputDepressionEnhancement,
	// Token: 0x04003055 RID: 12373
	HeartlessTrigger,
	// Token: 0x04003056 RID: 12374
	HeartlessSeedEnhancement,
	// Token: 0x04003057 RID: 12375
	HeartlessSingleHit,
	// Token: 0x04003058 RID: 12376
	CurseOfTheDeadDamageBoost,
	// Token: 0x04003059 RID: 12377
	FormlessAttributeDecay,
	// Token: 0x0400305A RID: 12378
	FormlessExtraHit,
	// Token: 0x0400305B RID: 12379
	FormlessDispel,
	// Token: 0x0400305C RID: 12380
	GhostlySmokeConfusionEnhancement,
	// Token: 0x0400305D RID: 12381
	SpitFireProtectionEnhancement,
	// Token: 0x0400305E RID: 12382
	SpitFireFocusEnhancement,
	// Token: 0x0400305F RID: 12383
	SpitFireDispelEnhancement,
	// Token: 0x04003060 RID: 12384
	PoisonMistDispelEnhancement,
	// Token: 0x04003061 RID: 12385
	SunderDepressionEnhancement,
	// Token: 0x04003062 RID: 12386
	SunderTauntEnhancement,
	// Token: 0x04003063 RID: 12387
	SwiftWindDamageSwitchEnhancement,
	// Token: 0x04003064 RID: 12388
	SwiftWindAgilityBoostEnhancement,
	// Token: 0x04003065 RID: 12389
	SwiftWindPushBoostEnhancement,
	// Token: 0x04003066 RID: 12390
	DrunknessExtraTargetEnhancement,
	// Token: 0x04003067 RID: 12391
	ThousandKnivesDepressionEnhancement,
	// Token: 0x04003068 RID: 12392
	ThousandKnivesDamageEnhancement,
	// Token: 0x04003069 RID: 12393
	ThousandKnivesDispelEnhancement,
	// Token: 0x0400306A RID: 12394
	RotationShieldEnhancement,
	// Token: 0x0400306B RID: 12395
	RotationDispelEnhancement,
	// Token: 0x0400306C RID: 12396
	RotationAttributeDecay,
	// Token: 0x0400306D RID: 12397
	TacticRageCostChange,
	// Token: 0x0400306E RID: 12398
	ActiveTargetPushProgress,
	// Token: 0x0400306F RID: 12399
	GrandMeteoroliteElementalChange,
	// Token: 0x04003070 RID: 12400
	FrenzyDispelEnhancement = 195,
	// Token: 0x04003071 RID: 12401
	FrenzyPushEnhancemednt,
	// Token: 0x04003072 RID: 12402
	FrenzyStunEnhancement,
	// Token: 0x04003073 RID: 12403
	SeductionExtraTarget,
	// Token: 0x04003074 RID: 12404
	SeductionAttributeDecayEnhancement,
	// Token: 0x04003075 RID: 12405
	SeductionSelfCleanEnhancement,
	// Token: 0x04003076 RID: 12406
	ActiveTargetAttributeDecayPriorCast,
	// Token: 0x04003077 RID: 12407
	ActiveTargetDispelPositivePriorCast,
	// Token: 0x04003078 RID: 12408
	CrashExtraDamage,
	// Token: 0x04003079 RID: 12409
	CrashExtraHit,
	// Token: 0x0400307A RID: 12410
	CrashDispel,
	// Token: 0x0400307B RID: 12411
	RedBlade,
	// Token: 0x0400307C RID: 12412
	PoisonMistBoost,
	// Token: 0x0400307D RID: 12413
	DeathBoost,
	// Token: 0x0400307E RID: 12414
	BunBoost,
	// Token: 0x0400307F RID: 12415
	DuelistIronBloodBoost,
	// Token: 0x04003080 RID: 12416
	BunAura,
	// Token: 0x04003081 RID: 12417
	GhostSmokeBoost,
	// Token: 0x04003082 RID: 12418
	DevilSpell,
	// Token: 0x04003083 RID: 12419
	RageCloth,
	// Token: 0x04003084 RID: 12420
	RageDepression,
	// Token: 0x04003085 RID: 12421
	CriticalHitDepression,
	// Token: 0x04003086 RID: 12422
	DuplicatedUnit,
	// Token: 0x04003087 RID: 12423
	RestrictedAccess,
	// Token: 0x04003088 RID: 12424
	LifePotionPercentage,
	// Token: 0x04003089 RID: 12425
	StrengthOfTheGhost,
	// Token: 0x0400308A RID: 12426
	EnhancedNightBlade,
	// Token: 0x0400308B RID: 12427
	EnhancedChubbyLady,
	// Token: 0x0400308C RID: 12428
	Reincarnation,
	// Token: 0x0400308D RID: 12429
	Thorns,
	// Token: 0x0400308E RID: 12430
	Guilt,
	// Token: 0x0400308F RID: 12431
	Annihilation,
	// Token: 0x04003090 RID: 12432
	Focus,
	// Token: 0x04003091 RID: 12433
	HealResistanceBoost,
	// Token: 0x04003092 RID: 12434
	DamageAttributeReductionByValue,
	// Token: 0x04003093 RID: 12435
	HealOutputBoost,
	// Token: 0x04003094 RID: 12436
	TauntResistanceBoost,
	// Token: 0x04003095 RID: 12437
	AdventureEnergyBoostByValue,
	// Token: 0x04003096 RID: 12438
	OffensiveDamageIgnoreByAttacker = 234,
	// Token: 0x04003097 RID: 12439
	TauntBoost,
	// Token: 0x04003098 RID: 12440
	DamageReductionByHealth,
	// Token: 0x04003099 RID: 12441
	AdventureEnergyRecollection,
	// Token: 0x0400309A RID: 12442
	Domineering = 252,
	// Token: 0x0400309B RID: 12443
	PrismLightAdventurePointsCollection = 254,
	// Token: 0x0400309C RID: 12444
	PrismLightTurnCollection,
	// Token: 0x0400309D RID: 12445
	PrismLightTacticCollection,
	// Token: 0x0400309E RID: 12446
	GhostBreathsDirectDamageReceiveCollection,
	// Token: 0x0400309F RID: 12447
	GhostBreathsDisperseNegativeEffectCollection = 259,
	// Token: 0x040030A0 RID: 12448
	VitalEnergyRebirthCollection = 261,
	// Token: 0x040030A1 RID: 12449
	VitalEnergyTauntCollection,
	// Token: 0x040030A2 RID: 12450
	ChaoticSpiritDirectKillCollection,
	// Token: 0x040030A3 RID: 12451
	CHaoticSpiritReflectionCollection,
	// Token: 0x040030A4 RID: 12452
	ConeEffect,
	// Token: 0x040030A5 RID: 12453
	ShieldBreaker,
	// Token: 0x040030A6 RID: 12454
	SoulLockRandomTargetEffect,
	// Token: 0x040030A7 RID: 12455
	SoulLockHighestSpeedEffect,
	// Token: 0x040030A8 RID: 12456
	SoulLockHighestDpsEffect,
	// Token: 0x040030A9 RID: 12457
	SoulLockHighestLifeEffect,
	// Token: 0x040030AA RID: 12458
	PoisonousNeedles,
	// Token: 0x040030AB RID: 12459
	SurvivalKit,
	// Token: 0x040030AC RID: 12460
	MagicBarrier,
	// Token: 0x040030AD RID: 12461
	DeathPrevent,
	// Token: 0x040030AE RID: 12462
	EffectCleanserRandomTarget,
	// Token: 0x040030AF RID: 12463
	EffectCleanserHighestEffect,
	// Token: 0x040030B0 RID: 12464
	ArmorBreakerRandom,
	// Token: 0x040030B1 RID: 12465
	ArmorBreakerHighestArmor,
	// Token: 0x040030B2 RID: 12466
	ArmorBreakerHighestHealth,
	// Token: 0x040030B3 RID: 12467
	FlowRandom,
	// Token: 0x040030B4 RID: 12468
	FlowLowestHealth,
	// Token: 0x040030B5 RID: 12469
	FlowHighestHealth,
	// Token: 0x040030B6 RID: 12470
	ReflectionDevice,
	// Token: 0x040030B7 RID: 12471
	HealDepresser,
	// Token: 0x040030B8 RID: 12472
	FirePlayerStarDoubleHit,
	// Token: 0x040030B9 RID: 12473
	YoungWarlockStarIntSteal,
	// Token: 0x040030BA RID: 12474
	ConjurerStarTeamBoost,
	// Token: 0x040030BB RID: 12475
	ElementalWizardStarHeal,
	// Token: 0x040030BC RID: 12476
	CubeStarSkillBoost,
	// Token: 0x040030BD RID: 12477
	SoulThiefStarEffectBoost,
	// Token: 0x040030BE RID: 12478
	FireAssassinStarImmune,
	// Token: 0x040030BF RID: 12479
	NightbladeStarHealReduceBoost,
	// Token: 0x040030C0 RID: 12480
	WarriorStarTaunt,
	// Token: 0x040030C1 RID: 12481
	DuelistStarSkillBoost,
	// Token: 0x040030C2 RID: 12482
	TacticianStarSkillBoost,
	// Token: 0x040030C3 RID: 12483
	ToughWomanStarAgileBoost,
	// Token: 0x040030C4 RID: 12484
	StreetManStarHitBoost,
	// Token: 0x040030C5 RID: 12485
	DrunkReaderStarUndead,
	// Token: 0x040030C6 RID: 12486
	MissionaryStarReflection,
	// Token: 0x040030C7 RID: 12487
	KillerStarReflection,
	// Token: 0x040030C8 RID: 12488
	PaladinStarTauntEnhance,
	// Token: 0x040030C9 RID: 12489
	ChubbyLadyStarHealerEnhance,
	// Token: 0x040030CA RID: 12490
	BunSisterStarMultipleHit,
	// Token: 0x040030CB RID: 12491
	FashionBoyStarDoubleDamage,
	// Token: 0x040030CC RID: 12492
	IronSoilderStarHitBoost,
	// Token: 0x040030CD RID: 12493
	SnowMaidenStarEffect,
	// Token: 0x040030CE RID: 12494
	FireChargerStarElement,
	// Token: 0x040030CF RID: 12495
	GoldenShamanStarHeal,
	// Token: 0x040030D0 RID: 12496
	RedHornStarDamageBoost,
	// Token: 0x040030D1 RID: 12497
	FireChargerDoTBlast,
	// Token: 0x040030D2 RID: 12498
	BurningHeartEnhancement = 312,
	// Token: 0x040030D3 RID: 12499
	ThousandKnivesExtremeDamageEnhancement,
	// Token: 0x040030D4 RID: 12500
	ToughWomanSwiftness,
	// Token: 0x040030D5 RID: 12501
	DrunkReaderRevive = 316,
	// Token: 0x040030D6 RID: 12502
	PaladinDecayEnhancement,
	// Token: 0x040030D7 RID: 12503
	ReflectiveHeal,
	// Token: 0x040030D8 RID: 12504
	Edgeless
}
