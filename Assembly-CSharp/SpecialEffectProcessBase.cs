using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000923 RID: 2339
public abstract class SpecialEffectProcessBase : IPresentable
{
	// Token: 0x060040D1 RID: 16593 RVA: 0x001736D3 File Offset: 0x00171AD3
	protected SpecialEffectProcessBase()
	{
	}

	// Token: 0x17000C07 RID: 3079
	// (get) Token: 0x060040D2 RID: 16594
	public abstract SpecialEffectType CorrespondingEffectType { get; }

	// Token: 0x17000C08 RID: 3080
	// (get) Token: 0x060040D3 RID: 16595
	public abstract List<AdventureEventType> CorrespondingEvents { get; }

	// Token: 0x060040D4 RID: 16596 RVA: 0x001736DC File Offset: 0x00171ADC
	public virtual IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		yield break;
	}

	// Token: 0x060040D5 RID: 16597 RVA: 0x001736F8 File Offset: 0x00171AF8
	public virtual IEnumerable AsActiveUnitPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit effectCarrier)
	{
		yield break;
	}

	// Token: 0x060040D6 RID: 16598 RVA: 0x00173714 File Offset: 0x00171B14
	public virtual IEnumerable AsInactiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		yield break;
	}

	// Token: 0x060040D7 RID: 16599 RVA: 0x00173730 File Offset: 0x00171B30
	public virtual IEnumerable AsInactiveUnitPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit effectCarrier)
	{
		yield break;
	}

	// Token: 0x060040D8 RID: 16600 RVA: 0x0017374C File Offset: 0x00171B4C
	public virtual IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		yield break;
	}

	// Token: 0x060040D9 RID: 16601 RVA: 0x00173768 File Offset: 0x00171B68
	public virtual IEnumerable AsAdventureEffectPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IEncounter encounter)
	{
		yield break;
	}

	// Token: 0x060040DA RID: 16602 RVA: 0x00173784 File Offset: 0x00171B84
	public virtual bool CanBeRandomSpecialEffects(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		return false;
	}

	// Token: 0x060040DB RID: 16603 RVA: 0x00173787 File Offset: 0x00171B87
	public virtual bool CanBeStarEffects(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		return false;
	}

	// Token: 0x060040DC RID: 16604 RVA: 0x0017378A File Offset: 0x00171B8A
	public virtual List<ISpecialEffectDataLoad> GenerateRandomEffect(int itemTierLevel, ResourceType itemType, QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x060040DD RID: 16605 RVA: 0x00173791 File Offset: 0x00171B91
	public virtual List<ISpecialEffectDataLoad> GenerateStarEffect(int itemTierNumber, ResourceType itemType, QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x060040DE RID: 16606 RVA: 0x00173798 File Offset: 0x00171B98
	protected static double GetItemRootValue(int itemTierLevel, ResourceType itemType, AttributeType type)
	{
		ResourceCategory resourceCategory = itemType.GetResourceCategory();
		double result = 0.0;
		if (resourceCategory.IsWeapon())
		{
			result = ItemExtensions.WeaponRoots[itemTierLevel - 1].RootAdditionModifiers.GetAttributeValue(type, AttributeRetrievalLevel.Skill);
		}
		if (resourceCategory.IsArmor())
		{
			result = ItemExtensions.ArmorRoots[itemTierLevel - 1].RootAdditionModifiers.GetAttributeValue(type, AttributeRetrievalLevel.Skill);
		}
		return result;
	}

	// Token: 0x060040DF RID: 16607 RVA: 0x00173801 File Offset: 0x00171C01
	public virtual int GetPresence()
	{
		return 100;
	}

	// Token: 0x02000FBA RID: 4026
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060065F6 RID: 26102 RVA: 0x00173805 File Offset: 0x00171C05
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060065F7 RID: 26103 RVA: 0x0017380D File Offset: 0x00171C0D
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x1700155F RID: 5471
		// (get) Token: 0x060065F8 RID: 26104 RVA: 0x00173827 File Offset: 0x00171C27
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001560 RID: 5472
		// (get) Token: 0x060065F9 RID: 26105 RVA: 0x0017382F File Offset: 0x00171C2F
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060065FA RID: 26106 RVA: 0x00173837 File Offset: 0x00171C37
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x060065FB RID: 26107 RVA: 0x00173839 File Offset: 0x00171C39
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060065FC RID: 26108 RVA: 0x00173840 File Offset: 0x00171C40
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060065FD RID: 26109 RVA: 0x00173848 File Offset: 0x00171C48
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new SpecialEffectProcessBase.<AsActiveUnitProcess>c__Iterator0();
		}

		// Token: 0x04005EF3 RID: 24307
		internal object $current;

		// Token: 0x04005EF4 RID: 24308
		internal bool $disposing;

		// Token: 0x04005EF5 RID: 24309
		internal int $PC;
	}

	// Token: 0x02000FBB RID: 4027
	[CompilerGenerated]
	private sealed class <AsActiveUnitPerSecondProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060065FE RID: 26110 RVA: 0x00173863 File Offset: 0x00171C63
		[DebuggerHidden]
		public <AsActiveUnitPerSecondProcess>c__Iterator1()
		{
		}

		// Token: 0x060065FF RID: 26111 RVA: 0x0017386B File Offset: 0x00171C6B
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x17001561 RID: 5473
		// (get) Token: 0x06006600 RID: 26112 RVA: 0x00173885 File Offset: 0x00171C85
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001562 RID: 5474
		// (get) Token: 0x06006601 RID: 26113 RVA: 0x0017388D File Offset: 0x00171C8D
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006602 RID: 26114 RVA: 0x00173895 File Offset: 0x00171C95
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06006603 RID: 26115 RVA: 0x00173897 File Offset: 0x00171C97
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006604 RID: 26116 RVA: 0x0017389E File Offset: 0x00171C9E
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006605 RID: 26117 RVA: 0x001738A6 File Offset: 0x00171CA6
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new SpecialEffectProcessBase.<AsActiveUnitPerSecondProcess>c__Iterator1();
		}

		// Token: 0x04005EF6 RID: 24310
		internal object $current;

		// Token: 0x04005EF7 RID: 24311
		internal bool $disposing;

		// Token: 0x04005EF8 RID: 24312
		internal int $PC;
	}

	// Token: 0x02000FBC RID: 4028
	[CompilerGenerated]
	private sealed class <AsInactiveUnitProcess>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006606 RID: 26118 RVA: 0x001738C1 File Offset: 0x00171CC1
		[DebuggerHidden]
		public <AsInactiveUnitProcess>c__Iterator2()
		{
		}

		// Token: 0x06006607 RID: 26119 RVA: 0x001738C9 File Offset: 0x00171CC9
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x17001563 RID: 5475
		// (get) Token: 0x06006608 RID: 26120 RVA: 0x001738E3 File Offset: 0x00171CE3
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001564 RID: 5476
		// (get) Token: 0x06006609 RID: 26121 RVA: 0x001738EB File Offset: 0x00171CEB
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600660A RID: 26122 RVA: 0x001738F3 File Offset: 0x00171CF3
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x0600660B RID: 26123 RVA: 0x001738F5 File Offset: 0x00171CF5
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600660C RID: 26124 RVA: 0x001738FC File Offset: 0x00171CFC
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600660D RID: 26125 RVA: 0x00173904 File Offset: 0x00171D04
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new SpecialEffectProcessBase.<AsInactiveUnitProcess>c__Iterator2();
		}

		// Token: 0x04005EF9 RID: 24313
		internal object $current;

		// Token: 0x04005EFA RID: 24314
		internal bool $disposing;

		// Token: 0x04005EFB RID: 24315
		internal int $PC;
	}

	// Token: 0x02000FBD RID: 4029
	[CompilerGenerated]
	private sealed class <AsInactiveUnitPerSecondProcess>c__Iterator3 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600660E RID: 26126 RVA: 0x0017391F File Offset: 0x00171D1F
		[DebuggerHidden]
		public <AsInactiveUnitPerSecondProcess>c__Iterator3()
		{
		}

		// Token: 0x0600660F RID: 26127 RVA: 0x00173927 File Offset: 0x00171D27
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x17001565 RID: 5477
		// (get) Token: 0x06006610 RID: 26128 RVA: 0x00173941 File Offset: 0x00171D41
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001566 RID: 5478
		// (get) Token: 0x06006611 RID: 26129 RVA: 0x00173949 File Offset: 0x00171D49
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006612 RID: 26130 RVA: 0x00173951 File Offset: 0x00171D51
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06006613 RID: 26131 RVA: 0x00173953 File Offset: 0x00171D53
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006614 RID: 26132 RVA: 0x0017395A File Offset: 0x00171D5A
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006615 RID: 26133 RVA: 0x00173962 File Offset: 0x00171D62
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new SpecialEffectProcessBase.<AsInactiveUnitPerSecondProcess>c__Iterator3();
		}

		// Token: 0x04005EFC RID: 24316
		internal object $current;

		// Token: 0x04005EFD RID: 24317
		internal bool $disposing;

		// Token: 0x04005EFE RID: 24318
		internal int $PC;
	}

	// Token: 0x02000FBE RID: 4030
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator4 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006616 RID: 26134 RVA: 0x0017397D File Offset: 0x00171D7D
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator4()
		{
		}

		// Token: 0x06006617 RID: 26135 RVA: 0x00173985 File Offset: 0x00171D85
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x17001567 RID: 5479
		// (get) Token: 0x06006618 RID: 26136 RVA: 0x0017399F File Offset: 0x00171D9F
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001568 RID: 5480
		// (get) Token: 0x06006619 RID: 26137 RVA: 0x001739A7 File Offset: 0x00171DA7
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600661A RID: 26138 RVA: 0x001739AF File Offset: 0x00171DAF
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x0600661B RID: 26139 RVA: 0x001739B1 File Offset: 0x00171DB1
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600661C RID: 26140 RVA: 0x001739B8 File Offset: 0x00171DB8
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600661D RID: 26141 RVA: 0x001739C0 File Offset: 0x00171DC0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new SpecialEffectProcessBase.<AsAdventureEffectProcess>c__Iterator4();
		}

		// Token: 0x04005EFF RID: 24319
		internal object $current;

		// Token: 0x04005F00 RID: 24320
		internal bool $disposing;

		// Token: 0x04005F01 RID: 24321
		internal int $PC;
	}

	// Token: 0x02000FBF RID: 4031
	[CompilerGenerated]
	private sealed class <AsAdventureEffectPerSecondProcess>c__Iterator5 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600661E RID: 26142 RVA: 0x001739DB File Offset: 0x00171DDB
		[DebuggerHidden]
		public <AsAdventureEffectPerSecondProcess>c__Iterator5()
		{
		}

		// Token: 0x0600661F RID: 26143 RVA: 0x001739E3 File Offset: 0x00171DE3
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x17001569 RID: 5481
		// (get) Token: 0x06006620 RID: 26144 RVA: 0x001739FD File Offset: 0x00171DFD
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700156A RID: 5482
		// (get) Token: 0x06006621 RID: 26145 RVA: 0x00173A05 File Offset: 0x00171E05
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006622 RID: 26146 RVA: 0x00173A0D File Offset: 0x00171E0D
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06006623 RID: 26147 RVA: 0x00173A0F File Offset: 0x00171E0F
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006624 RID: 26148 RVA: 0x00173A16 File Offset: 0x00171E16
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006625 RID: 26149 RVA: 0x00173A1E File Offset: 0x00171E1E
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new SpecialEffectProcessBase.<AsAdventureEffectPerSecondProcess>c__Iterator5();
		}

		// Token: 0x04005F02 RID: 24322
		internal object $current;

		// Token: 0x04005F03 RID: 24323
		internal bool $disposing;

		// Token: 0x04005F04 RID: 24324
		internal int $PC;
	}
}
