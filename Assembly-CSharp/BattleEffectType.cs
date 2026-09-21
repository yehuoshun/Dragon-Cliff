using System;

// Token: 0x0200073F RID: 1855
public enum BattleEffectType
{
	// Token: 0x040028D3 RID: 10451
	TurnDamage,
	// Token: 0x040028D4 RID: 10452
	BrightCircle,
	// Token: 0x040028D5 RID: 10453
	Chill = 3,
	// Token: 0x040028D6 RID: 10454
	ArcaneFocused,
	// Token: 0x040028D7 RID: 10455
	MultiStrikeFocused,
	// Token: 0x040028D8 RID: 10456
	Exhausted,
	// Token: 0x040028D9 RID: 10457
	StrengthBoost,
	// Token: 0x040028DA RID: 10458
	FireSeed,
	// Token: 0x040028DB RID: 10459
	Flourish,
	// Token: 0x040028DC RID: 10460
	Frozen,
	// Token: 0x040028DD RID: 10461
	GodSeed,
	// Token: 0x040028DE RID: 10462
	Harmony,
	// Token: 0x040028DF RID: 10463
	EffectImmune,
	// Token: 0x040028E0 RID: 10464
	LighteningSpeed,
	// Token: 0x040028E1 RID: 10465
	MoraleReduction,
	// Token: 0x040028E2 RID: 10466
	PoisonSeed = 17,
	// Token: 0x040028E3 RID: 10467
	Principle,
	// Token: 0x040028E4 RID: 10468
	Relentless,
	// Token: 0x040028E5 RID: 10469
	Roar,
	// Token: 0x040028E6 RID: 10470
	ShadowSpirit,
	// Token: 0x040028E7 RID: 10471
	CorruptedPowerEffect,
	// Token: 0x040028E8 RID: 10472
	Rage = 24,
	// Token: 0x040028E9 RID: 10473
	Stamina = 26,
	// Token: 0x040028EA RID: 10474
	Stone,
	// Token: 0x040028EB RID: 10475
	BurningHeartEffect,
	// Token: 0x040028EC RID: 10476
	StrengthDecay,
	// Token: 0x040028ED RID: 10477
	Stun,
	// Token: 0x040028EE RID: 10478
	Taunt,
	// Token: 0x040028EF RID: 10479
	FierySoul = 34,
	// Token: 0x040028F0 RID: 10480
	DamagePerSecond,
	// Token: 0x040028F1 RID: 10481
	ShieldBurn,
	// Token: 0x040028F2 RID: 10482
	ArmorReduction,
	// Token: 0x040028F3 RID: 10483
	ReturnedSoul,
	// Token: 0x040028F4 RID: 10484
	Empowerment,
	// Token: 0x040028F5 RID: 10485
	AttributeStolen,
	// Token: 0x040028F6 RID: 10486
	AttributeObtain,
	// Token: 0x040028F7 RID: 10487
	AttributeReplacement,
	// Token: 0x040028F8 RID: 10488
	TimelyCoward,
	// Token: 0x040028F9 RID: 10489
	BattlePressure,
	// Token: 0x040028FA RID: 10490
	SoulCollectedBoost,
	// Token: 0x040028FB RID: 10491
	Fade,
	// Token: 0x040028FC RID: 10492
	Charged,
	// Token: 0x040028FD RID: 10493
	DamageImmune,
	// Token: 0x040028FE RID: 10494
	SufferlessPenalty,
	// Token: 0x040028FF RID: 10495
	SpiritOfDemon,
	// Token: 0x04002900 RID: 10496
	DamageReduction,
	// Token: 0x04002901 RID: 10497
	DamageNeutrualization,
	// Token: 0x04002902 RID: 10498
	ReflectiveShield,
	// Token: 0x04002903 RID: 10499
	BloodCurseEffect,
	// Token: 0x04002904 RID: 10500
	CritRateBoost,
	// Token: 0x04002905 RID: 10501
	Confusion,
	// Token: 0x04002906 RID: 10502
	FireSpiritEffect,
	// Token: 0x04002907 RID: 10503
	HealingReduction,
	// Token: 0x04002908 RID: 10504
	AgilityBoost,
	// Token: 0x04002909 RID: 10505
	ArmorEnhancement,
	// Token: 0x0400290A RID: 10506
	AdditionalTarget,
	// Token: 0x0400290B RID: 10507
	IntelligienceBoost,
	// Token: 0x0400290C RID: 10508
	Frenzy,
	// Token: 0x0400290D RID: 10509
	UndeadAsh = 65,
	// Token: 0x0400290E RID: 10510
	FlyingFeatherEffect,
	// Token: 0x0400290F RID: 10511
	BrokenArmor,
	// Token: 0x04002910 RID: 10512
	DivineShine,
	// Token: 0x04002911 RID: 10513
	Constraint = 70,
	// Token: 0x04002912 RID: 10514
	Slowdown,
	// Token: 0x04002913 RID: 10515
	FrozenHeart,
	// Token: 0x04002914 RID: 10516
	EnhancedAttributes,
	// Token: 0x04002915 RID: 10517
	DarknessRevenge,
	// Token: 0x04002916 RID: 10518
	SinisterRage,
	// Token: 0x04002917 RID: 10519
	BleedingPerSecond = 77,
	// Token: 0x04002918 RID: 10520
	PoisonWarm,
	// Token: 0x04002919 RID: 10521
	ThousandSwarmSoulCollection,
	// Token: 0x0400291A RID: 10522
	DarknessOutputDepression,
	// Token: 0x0400291B RID: 10523
	DarknessHealDepression,
	// Token: 0x0400291C RID: 10524
	InversedKill,
	// Token: 0x0400291D RID: 10525
	StrangeGhost,
	// Token: 0x0400291E RID: 10526
	LifeLink,
	// Token: 0x0400291F RID: 10527
	HealPerTurn,
	// Token: 0x04002920 RID: 10528
	HealPerSecond,
	// Token: 0x04002921 RID: 10529
	DamageIncreased,
	// Token: 0x04002922 RID: 10530
	GreatGodnessProtection,
	// Token: 0x04002923 RID: 10531
	TargettedEffect,
	// Token: 0x04002924 RID: 10532
	PoisonBait,
	// Token: 0x04002925 RID: 10533
	AttributeWeakened,
	// Token: 0x04002926 RID: 10534
	KillingIntent,
	// Token: 0x04002927 RID: 10535
	DamageAbsorbShield,
	// Token: 0x04002928 RID: 10536
	TurnFrozen,
	// Token: 0x04002929 RID: 10537
	Targetted,
	// Token: 0x0400292A RID: 10538
	Sealed,
	// Token: 0x0400292B RID: 10539
	CourageBlessed,
	// Token: 0x0400292C RID: 10540
	DecayBlade,
	// Token: 0x0400292D RID: 10541
	Silienced,
	// Token: 0x0400292E RID: 10542
	ArrogancePunishement,
	// Token: 0x0400292F RID: 10543
	RespiteShield,
	// Token: 0x04002930 RID: 10544
	Fear,
	// Token: 0x04002931 RID: 10545
	EvilThirst,
	// Token: 0x04002932 RID: 10546
	ResistanceReductionPerSecond,
	// Token: 0x04002933 RID: 10547
	RageThirst,
	// Token: 0x04002934 RID: 10548
	BlackBlood,
	// Token: 0x04002935 RID: 10549
	FreeCast,
	// Token: 0x04002936 RID: 10550
	CrashExtra,
	// Token: 0x04002937 RID: 10551
	Undead,
	// Token: 0x04002938 RID: 10552
	FashionEnhanced,
	// Token: 0x04002939 RID: 10553
	ProtectionOfTheDead,
	// Token: 0x0400293A RID: 10554
	GuiltEffect,
	// Token: 0x0400293B RID: 10555
	AnnihilationEffect,
	// Token: 0x0400293C RID: 10556
	Focused,
	// Token: 0x0400293D RID: 10557
	TauntBoost,
	// Token: 0x0400293E RID: 10558
	DamageReductionByValue,
	// Token: 0x0400293F RID: 10559
	EmbracedMind,
	// Token: 0x04002940 RID: 10560
	ConcentratedEnergy
}
