using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000913 RID: 2323
public class RageBoostEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x0600408B RID: 16523 RVA: 0x001A0649 File Offset: 0x0019EA49
	public RageBoostEffectProcess()
	{
	}

	// Token: 0x17000BE7 RID: 3047
	// (get) Token: 0x0600408C RID: 16524 RVA: 0x001A0651 File Offset: 0x0019EA51
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.RageBoost;
		}
	}

	// Token: 0x17000BE8 RID: 3048
	// (get) Token: 0x0600408D RID: 16525 RVA: 0x001A0658 File Offset: 0x0019EA58
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReadyInBattle
			};
		}
	}

	// Token: 0x0600408E RID: 16526 RVA: 0x001A0674 File Offset: 0x0019EA74
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && specialEffectData is RageBoostData)
		{
			RageBoostData data = specialEffectData as RageBoostData;
			List<IBattleUnit> targets = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true);
			foreach (IBattleUnit battleUnit in targets)
			{
				IEnumerator enumerator2 = battleUnit.ApplySkillEffect(new RageThirstEffect(data.SuctionValue, null, null, effectCarrier), false).GetEnumerator();
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

	// Token: 0x02000FA0 RID: 4000
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006559 RID: 25945 RVA: 0x001A06AD File Offset: 0x0019EAAD
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600655A RID: 25946 RVA: 0x001A06B8 File Offset: 0x0019EAB8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitReadyInBattle || triggerUnit != effectCarrier || !(specialEffectData is RageBoostData))
				{
					goto IL_199;
				}
				data = (specialEffectData as RageBoostData);
				targets = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true);
				enumerator = targets.GetEnumerator();
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
					Block_7:
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
					battleUnit = enumerator.Current;
					enumerator2 = battleUnit.ApplySkillEffect(new RageThirstEffect(data.SuctionValue, null, null, effectCarrier), false).GetEnumerator();
					num = 4294967293u;
					goto Block_7;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_199:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700153D RID: 5437
		// (get) Token: 0x0600655B RID: 25947 RVA: 0x001A0884 File Offset: 0x0019EC84
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700153E RID: 5438
		// (get) Token: 0x0600655C RID: 25948 RVA: 0x001A088C File Offset: 0x0019EC8C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600655D RID: 25949 RVA: 0x001A0894 File Offset: 0x0019EC94
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

		// Token: 0x0600655E RID: 25950 RVA: 0x001A0928 File Offset: 0x0019ED28
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600655F RID: 25951 RVA: 0x001A092F File Offset: 0x0019ED2F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006560 RID: 25952 RVA: 0x001A0938 File Offset: 0x0019ED38
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			RageBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new RageBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005DE9 RID: 24041
		internal AdventureEventType evtType;

		// Token: 0x04005DEA RID: 24042
		internal IBattleUnit triggerUnit;

		// Token: 0x04005DEB RID: 24043
		internal IBattleUnit effectCarrier;

		// Token: 0x04005DEC RID: 24044
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005DED RID: 24045
		internal RageBoostData <data>__1;

		// Token: 0x04005DEE RID: 24046
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x04005DEF RID: 24047
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04005DF0 RID: 24048
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x04005DF1 RID: 24049
		internal IEnumerator $locvar1;

		// Token: 0x04005DF2 RID: 24050
		internal object <_>__3;

		// Token: 0x04005DF3 RID: 24051
		internal IDisposable $locvar2;

		// Token: 0x04005DF4 RID: 24052
		internal object $current;

		// Token: 0x04005DF5 RID: 24053
		internal bool $disposing;

		// Token: 0x04005DF6 RID: 24054
		internal int $PC;
	}
}
