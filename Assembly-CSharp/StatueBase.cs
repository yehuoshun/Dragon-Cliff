using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000A46 RID: 2630
public class StatueBase : UnitStyleConfigurationBase
{
	// Token: 0x060047A7 RID: 18343 RVA: 0x001DB0EE File Offset: 0x001D94EE
	public StatueBase()
	{
	}

	// Token: 0x17000E0A RID: 3594
	// (get) Token: 0x060047A8 RID: 18344 RVA: 0x001DB0F6 File Offset: 0x001D94F6
	public override UnitClassStyle CorrespondingStyle
	{
		get
		{
			return UnitClassStyle.Statue;
		}
	}

	// Token: 0x060047A9 RID: 18345 RVA: 0x001DB0FC File Offset: 0x001D94FC
	public override UnitGrowthProfile GetGrowthProfile(DifficultyLevelMeasurement measurement)
	{
		return new UnitGrowthProfile().SetValue(AttributeType.Intelligience, 20.0, false).SetValue(AttributeType.Vitality, 60.0, false).SetValue(AttributeType.CritRate, 0.2, false).SetValue(AttributeType.Agility, 20.0, false);
	}

	// Token: 0x060047AA RID: 18346 RVA: 0x001DB150 File Offset: 0x001D9550
	public override List<ISpecialEffectDataLoad> GetSpecialEffectDataLoads(DifficultyLevelMeasurement measurement)
	{
		List<ISpecialEffectDataLoad> list = new List<ISpecialEffectDataLoad>();
		if (measurement.StarRating != 1)
		{
			list.Add(new ShiftShieldData
			{
				IsStar = false,
				NumberOfSecondsPerShift = 3,
				Counter = 0,
				NumberOfElements = 3
			});
		}
		return list;
	}

	// Token: 0x060047AB RID: 18347 RVA: 0x001DB19C File Offset: 0x001D959C
	public override IEnumerable NormalGradeAttackLogic(IBattleUnit unit)
	{
		yield break;
	}

	// Token: 0x060047AC RID: 18348 RVA: 0x001DB1B8 File Offset: 0x001D95B8
	public override IEnumerable HardGradeAttackLogic(IBattleUnit unit)
	{
		yield break;
	}

	// Token: 0x17000E0B RID: 3595
	// (get) Token: 0x060047AD RID: 18349 RVA: 0x001DB1D4 File Offset: 0x001D95D4
	public override List<ResourceCategory> WeaponCategories
	{
		get
		{
			return new List<ResourceCategory>();
		}
	}

	// Token: 0x17000E0C RID: 3596
	// (get) Token: 0x060047AE RID: 18350 RVA: 0x001DB1DB File Offset: 0x001D95DB
	public override List<ResourceCategory> ArmorCategories
	{
		get
		{
			return new List<ResourceCategory>();
		}
	}

	// Token: 0x17000E0D RID: 3597
	// (get) Token: 0x060047AF RID: 18351 RVA: 0x001DB1E2 File Offset: 0x001D95E2
	public override List<ResourceType> SuitableAccessories
	{
		get
		{
			return new List<ResourceType>();
		}
	}

	// Token: 0x02001071 RID: 4209
	[CompilerGenerated]
	private sealed class <NormalGradeAttackLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600693C RID: 26940 RVA: 0x001DB1E9 File Offset: 0x001D95E9
		[DebuggerHidden]
		public <NormalGradeAttackLogic>c__Iterator0()
		{
		}

		// Token: 0x0600693D RID: 26941 RVA: 0x001DB1F1 File Offset: 0x001D95F1
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x170015F7 RID: 5623
		// (get) Token: 0x0600693E RID: 26942 RVA: 0x001DB20B File Offset: 0x001D960B
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015F8 RID: 5624
		// (get) Token: 0x0600693F RID: 26943 RVA: 0x001DB213 File Offset: 0x001D9613
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006940 RID: 26944 RVA: 0x001DB21B File Offset: 0x001D961B
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06006941 RID: 26945 RVA: 0x001DB21D File Offset: 0x001D961D
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006942 RID: 26946 RVA: 0x001DB224 File Offset: 0x001D9624
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006943 RID: 26947 RVA: 0x001DB22C File Offset: 0x001D962C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new StatueBase.<NormalGradeAttackLogic>c__Iterator0();
		}

		// Token: 0x040063AF RID: 25519
		internal object $current;

		// Token: 0x040063B0 RID: 25520
		internal bool $disposing;

		// Token: 0x040063B1 RID: 25521
		internal int $PC;
	}

	// Token: 0x02001072 RID: 4210
	[CompilerGenerated]
	private sealed class <HardGradeAttackLogic>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006944 RID: 26948 RVA: 0x001DB247 File Offset: 0x001D9647
		[DebuggerHidden]
		public <HardGradeAttackLogic>c__Iterator1()
		{
		}

		// Token: 0x06006945 RID: 26949 RVA: 0x001DB24F File Offset: 0x001D964F
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x170015F9 RID: 5625
		// (get) Token: 0x06006946 RID: 26950 RVA: 0x001DB269 File Offset: 0x001D9669
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015FA RID: 5626
		// (get) Token: 0x06006947 RID: 26951 RVA: 0x001DB271 File Offset: 0x001D9671
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006948 RID: 26952 RVA: 0x001DB279 File Offset: 0x001D9679
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06006949 RID: 26953 RVA: 0x001DB27B File Offset: 0x001D967B
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600694A RID: 26954 RVA: 0x001DB282 File Offset: 0x001D9682
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600694B RID: 26955 RVA: 0x001DB28A File Offset: 0x001D968A
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new StatueBase.<HardGradeAttackLogic>c__Iterator1();
		}

		// Token: 0x040063B2 RID: 25522
		internal object $current;

		// Token: 0x040063B3 RID: 25523
		internal bool $disposing;

		// Token: 0x040063B4 RID: 25524
		internal int $PC;
	}
}
