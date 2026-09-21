using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008B8 RID: 2232
public class ClearUpProcess : SpecialEffectProcessBase
{
	// Token: 0x06003EFB RID: 16123 RVA: 0x00187E3C File Offset: 0x0018623C
	public ClearUpProcess()
	{
	}

	// Token: 0x17000B32 RID: 2866
	// (get) Token: 0x06003EFC RID: 16124 RVA: 0x00187E44 File Offset: 0x00186244
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.ClearUp;
		}
	}

	// Token: 0x17000B33 RID: 2867
	// (get) Token: 0x06003EFD RID: 16125 RVA: 0x00187E48 File Offset: 0x00186248
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitEntersTurn
			};
		}
	}

	// Token: 0x06003EFE RID: 16126 RVA: 0x00187E64 File Offset: 0x00186264
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitEntersTurn && triggerUnit == effectCarrier)
		{
			List<IBattleUnit> friendlyUnits = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true);
			foreach (IBattleUnit friendlyUnit in friendlyUnits)
			{
				IEnumerator enumerator2 = UnitStyleConfigurationBase.DispelNegativeEffects(friendlyUnit, null).GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						object _ = enumerator2.Current;
						yield return _;
					}
				}
				finally
				{
					IDisposable disposable;
					if ((disposable = (enumerator2 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x02000F2B RID: 3883
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006219 RID: 25113 RVA: 0x00187E96 File Offset: 0x00186296
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600621A RID: 25114 RVA: 0x00187EA0 File Offset: 0x001862A0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitEntersTurn || triggerUnit != effectCarrier)
				{
					goto IL_157;
				}
				friendlyUnits = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true);
				enumerator = friendlyUnits.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_6:
					try
					{
						switch (num)
						{
						}
						if (enumerator2.MoveNext())
						{
							_ = enumerator2.Current;
							this.$current = _;
							if (!this.$disposing)
							{
								this.$PC = 1;
							}
							flag = true;
							return true;
						}
					}
					finally
					{
						if (!flag)
						{
							if ((disposable = (enumerator2 as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
					break;
				}
				if (enumerator.MoveNext())
				{
					friendlyUnit = enumerator.Current;
					enumerator2 = UnitStyleConfigurationBase.DispelNegativeEffects(friendlyUnit, null).GetEnumerator();
					num = 4294967293u;
					goto Block_6;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_157:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001489 RID: 5257
		// (get) Token: 0x0600621B RID: 25115 RVA: 0x0018802C File Offset: 0x0018642C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700148A RID: 5258
		// (get) Token: 0x0600621C RID: 25116 RVA: 0x00188034 File Offset: 0x00186434
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600621D RID: 25117 RVA: 0x0018803C File Offset: 0x0018643C
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable = (enumerator2 as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x0600621E RID: 25118 RVA: 0x001880D0 File Offset: 0x001864D0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600621F RID: 25119 RVA: 0x001880D7 File Offset: 0x001864D7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006220 RID: 25120 RVA: 0x001880E0 File Offset: 0x001864E0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ClearUpProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new ClearUpProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005835 RID: 22581
		internal AdventureEventType evtType;

		// Token: 0x04005836 RID: 22582
		internal IBattleUnit triggerUnit;

		// Token: 0x04005837 RID: 22583
		internal IBattleUnit effectCarrier;

		// Token: 0x04005838 RID: 22584
		internal List<IBattleUnit> <friendlyUnits>__1;

		// Token: 0x04005839 RID: 22585
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x0400583A RID: 22586
		internal IBattleUnit <friendlyUnit>__2;

		// Token: 0x0400583B RID: 22587
		internal IEnumerator $locvar1;

		// Token: 0x0400583C RID: 22588
		internal object <_>__3;

		// Token: 0x0400583D RID: 22589
		internal IDisposable $locvar2;

		// Token: 0x0400583E RID: 22590
		internal object $current;

		// Token: 0x0400583F RID: 22591
		internal bool $disposing;

		// Token: 0x04005840 RID: 22592
		internal int $PC;
	}
}
