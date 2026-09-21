using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000722 RID: 1826
public class BattleDamage
{
	// Token: 0x060032E8 RID: 13032 RVA: 0x00157B8C File Offset: 0x00155F8C
	public BattleDamage(IBattleUnit target, IBattleEffectSource source, List<DamageComponentValue> values)
	{
		this.Damages = (from v in values
		select new DamageComponent(v, source)).ToList<DamageComponent>();
		this.Target = target;
		this.DamageSource = source;
	}

	// Token: 0x170007C5 RID: 1989
	// (get) Token: 0x060032E9 RID: 13033 RVA: 0x00157BDC File Offset: 0x00155FDC
	// (set) Token: 0x060032EA RID: 13034 RVA: 0x00157BE4 File Offset: 0x00155FE4
	public IBattleUnit Target
	{
		[CompilerGenerated]
		get
		{
			return this.<Target>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Target>k__BackingField = value;
		}
	}

	// Token: 0x170007C6 RID: 1990
	// (get) Token: 0x060032EB RID: 13035 RVA: 0x00157BED File Offset: 0x00155FED
	// (set) Token: 0x060032EC RID: 13036 RVA: 0x00157BF5 File Offset: 0x00155FF5
	public List<DamageComponent> Damages
	{
		[CompilerGenerated]
		get
		{
			return this.<Damages>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Damages>k__BackingField = value;
		}
	}

	// Token: 0x170007C7 RID: 1991
	// (get) Token: 0x060032ED RID: 13037 RVA: 0x00157BFE File Offset: 0x00155FFE
	// (set) Token: 0x060032EE RID: 13038 RVA: 0x00157C06 File Offset: 0x00156006
	public IBattleEffectSource DamageSource
	{
		[CompilerGenerated]
		get
		{
			return this.<DamageSource>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<DamageSource>k__BackingField = value;
		}
	}

	// Token: 0x170007C8 RID: 1992
	// (get) Token: 0x060032EF RID: 13039 RVA: 0x00157C0F File Offset: 0x0015600F
	public IBattleUnit Dealer
	{
		get
		{
			return this.DamageSource.SourceUnit;
		}
	}

	// Token: 0x170007C9 RID: 1993
	// (get) Token: 0x060032F0 RID: 13040 RVA: 0x00157C1C File Offset: 0x0015601C
	// (set) Token: 0x060032F1 RID: 13041 RVA: 0x00157C24 File Offset: 0x00156024
	public ReleaseableDamage Releaseable
	{
		[CompilerGenerated]
		get
		{
			return this.<Releaseable>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Releaseable>k__BackingField = value;
		}
	}

	// Token: 0x060032F2 RID: 13042 RVA: 0x00157C2D File Offset: 0x0015602D
	// Note: this type is marked as 'beforefieldinit'.
	static BattleDamage()
	{
	}

	// Token: 0x040027D9 RID: 10201
	public static double MaxDamagePerPotion = double.MaxValue;

	// Token: 0x040027DA RID: 10202
	public static double MaxDamagePerHit = double.MaxValue;

	// Token: 0x040027DB RID: 10203
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <Target>k__BackingField;

	// Token: 0x040027DC RID: 10204
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<DamageComponent> <Damages>k__BackingField;

	// Token: 0x040027DD RID: 10205
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleEffectSource <DamageSource>k__BackingField;

	// Token: 0x040027DE RID: 10206
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ReleaseableDamage <Releaseable>k__BackingField;

	// Token: 0x02000E87 RID: 3719
	[CompilerGenerated]
	private sealed class <BattleDamage>c__AnonStorey0
	{
		// Token: 0x06005DA2 RID: 23970 RVA: 0x00157C4B File Offset: 0x0015604B
		public <BattleDamage>c__AnonStorey0()
		{
		}

		// Token: 0x06005DA3 RID: 23971 RVA: 0x00157C53 File Offset: 0x00156053
		internal DamageComponent <>m__0(DamageComponentValue v)
		{
			return new DamageComponent(v, this.source);
		}

		// Token: 0x040050FB RID: 20731
		internal IBattleEffectSource source;
	}
}
