using System;

// Token: 0x0200077B RID: 1915
public enum SkillType
{
	// Token: 0x04002BD4 RID: 11220
	None,
	// Token: 0x04002BD5 RID: 11221
	WeaponEnchantment,
	// Token: 0x04002BD6 RID: 11222
	Assassination = 1001,
	// Token: 0x04002BD7 RID: 11223
	BladeRain,
	// Token: 0x04002BD8 RID: 11224
	DeadlyBlade,
	// Token: 0x04002BD9 RID: 11225
	Strike,
	// Token: 0x04002BDA RID: 11226
	MultiStrike,
	// Token: 0x04002BDB RID: 11227
	StealSoul,
	// Token: 0x04002BDC RID: 11228
	Stun,
	// Token: 0x04002BDD RID: 11229
	Taunt,
	// Token: 0x04002BDE RID: 11230
	Roar,
	// Token: 0x04002BDF RID: 11231
	Relentless,
	// Token: 0x04002BE0 RID: 11232
	Scorn,
	// Token: 0x04002BE1 RID: 11233
	FireBall,
	// Token: 0x04002BE2 RID: 11234
	Meteorolite,
	// Token: 0x04002BE3 RID: 11235
	Lightning,
	// Token: 0x04002BE4 RID: 11236
	Freeze,
	// Token: 0x04002BE5 RID: 11237
	Arcane,
	// Token: 0x04002BE6 RID: 11238
	DivineHammer,
	// Token: 0x04002BE7 RID: 11239
	DivineLight,
	// Token: 0x04002BE8 RID: 11240
	Pray,
	// Token: 0x04002BE9 RID: 11241
	BloodThirst,
	// Token: 0x04002BEA RID: 11242
	Rage,
	// Token: 0x04002BEB RID: 11243
	Principle,
	// Token: 0x04002BEC RID: 11244
	Rebirth,
	// Token: 0x04002BED RID: 11245
	FleshToStone = 1025,
	// Token: 0x04002BEE RID: 11246
	Harmony,
	// Token: 0x04002BEF RID: 11247
	Flame,
	// Token: 0x04002BF0 RID: 11248
	Flourish,
	// Token: 0x04002BF1 RID: 11249
	LightningSpeed,
	// Token: 0x04002BF2 RID: 11250
	Wave,
	// Token: 0x04002BF3 RID: 11251
	Stamina,
	// Token: 0x04002BF4 RID: 11252
	SwallowFire,
	// Token: 0x04002BF5 RID: 11253
	Shadowless,
	// Token: 0x04002BF6 RID: 11254
	WillOfFight,
	// Token: 0x04002BF7 RID: 11255
	BrightCircle,
	// Token: 0x04002BF8 RID: 11256
	CorruptedPower,
	// Token: 0x04002BF9 RID: 11257
	BurningHeart,
	// Token: 0x04002BFA RID: 11258
	GrandStrategy,
	// Token: 0x04002BFB RID: 11259
	PoisonBlade,
	// Token: 0x04002BFC RID: 11260
	Pierce,
	// Token: 0x04002BFD RID: 11261
	SpellSlayer,
	// Token: 0x04002BFE RID: 11262
	ShadowSacrifice,
	// Token: 0x04002BFF RID: 11263
	SeedsOfSin,
	// Token: 0x04002C00 RID: 11264
	Confusion,
	// Token: 0x04002C01 RID: 11265
	CurseOfCube,
	// Token: 0x04002C02 RID: 11266
	Shock,
	// Token: 0x04002C03 RID: 11267
	FireBreath,
	// Token: 0x04002C04 RID: 11268
	FireBlast,
	// Token: 0x04002C05 RID: 11269
	FistPunch,
	// Token: 0x04002C06 RID: 11270
	Nightmare,
	// Token: 0x04002C07 RID: 11271
	Dance,
	// Token: 0x04002C08 RID: 11272
	FrenzeSpike,
	// Token: 0x04002C09 RID: 11273
	Stray,
	// Token: 0x04002C0A RID: 11274
	Swift,
	// Token: 0x04002C0B RID: 11275
	ChargedBolt,
	// Token: 0x04002C0C RID: 11276
	Cleaning,
	// Token: 0x04002C0D RID: 11277
	Purify,
	// Token: 0x04002C0E RID: 11278
	ShieldBurn,
	// Token: 0x04002C0F RID: 11279
	LightFire,
	// Token: 0x04002C10 RID: 11280
	SoulSeeker,
	// Token: 0x04002C11 RID: 11281
	Undead,
	// Token: 0x04002C12 RID: 11282
	ReturningSoul,
	// Token: 0x04002C13 RID: 11283
	FireBurst,
	// Token: 0x04002C14 RID: 11284
	Dummy,
	// Token: 0x04002C15 RID: 11285
	SpellOfHoliness,
	// Token: 0x04002C16 RID: 11286
	SpiritOfDemon,
	// Token: 0x04002C17 RID: 11287
	IronBlood,
	// Token: 0x04002C18 RID: 11288
	ArmorOfWind,
	// Token: 0x04002C19 RID: 11289
	EmbracedShield,
	// Token: 0x04002C1A RID: 11290
	BloodCurse,
	// Token: 0x04002C1B RID: 11291
	HeartlessFire,
	// Token: 0x04002C1C RID: 11292
	CurseOfTheDead,
	// Token: 0x04002C1D RID: 11293
	Formless,
	// Token: 0x04002C1E RID: 11294
	GhostlySmoke,
	// Token: 0x04002C1F RID: 11295
	GodsFire,
	// Token: 0x04002C20 RID: 11296
	PoisonousMist,
	// Token: 0x04002C21 RID: 11297
	Sunder,
	// Token: 0x04002C22 RID: 11298
	SwiftWind,
	// Token: 0x04002C23 RID: 11299
	Crash,
	// Token: 0x04002C24 RID: 11300
	Drunkenness,
	// Token: 0x04002C25 RID: 11301
	ThousandKnives,
	// Token: 0x04002C26 RID: 11302
	Encouragement,
	// Token: 0x04002C27 RID: 11303
	Rotation,
	// Token: 0x04002C28 RID: 11304
	Punishment,
	// Token: 0x04002C29 RID: 11305
	GrandMeteorolite,
	// Token: 0x04002C2A RID: 11306
	Frenzy,
	// Token: 0x04002C2B RID: 11307
	Seduction,
	// Token: 0x04002C2C RID: 11308
	DivineRemedy,
	// Token: 0x04002C2D RID: 11309
	Brutality,
	// Token: 0x04002C2E RID: 11310
	Swordmanship
}
