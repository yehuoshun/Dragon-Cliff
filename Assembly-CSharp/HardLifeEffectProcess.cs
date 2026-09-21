using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008F2 RID: 2290
public class HardLifeEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003FF5 RID: 16373 RVA: 0x00197810 File Offset: 0x00195C10
	public HardLifeEffectProcess()
	{
	}

	// Token: 0x17000BA6 RID: 2982
	// (get) Token: 0x06003FF6 RID: 16374 RVA: 0x00197818 File Offset: 0x00195C18
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.HardLife;
		}
	}

	// Token: 0x17000BA7 RID: 2983
	// (get) Token: 0x06003FF7 RID: 16375 RVA: 0x0019781C File Offset: 0x00195C1C
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitPostReceivesDamage_Single
			};
		}
	}

	// Token: 0x06003FF8 RID: 16376 RVA: 0x00197838 File Offset: 0x00195C38
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && triggerUnit == effectCarrier && evtData is DamageComponent && specialEffectData is HardLifeData)
		{
			DamageComponent damage = evtData as DamageComponent;
			HardLifeData data = specialEffectData as HardLifeData;
			double damageRate = damage.GetTotalDamageSoFar() / damage.Target.GetMaxLife(AttributeRetrievalLevel.Skill);
			if (damageRate >= data.DamageRate)
			{
				for (int i = 0; i < data.NumberOfShields; i++)
				{
					IEnumerator enumerator = effectCarrier.ApplySkillEffect(new DamageNeutralizationEffect(new int?(1), effectCarrier, true), false).GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							object _ = enumerator.Current;
							yield return _;
						}
					}
					finally
					{
						IDisposable disposable;
						if ((disposable = (enumerator as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x02000F76 RID: 3958
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600641E RID: 25630 RVA: 0x00197879 File Offset: 0x00195C79
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600641F RID: 25631 RVA: 0x00197884 File Offset: 0x00195C84
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitPostReceivesDamage_Single || triggerUnit != effectCarrier || !(evtData is DamageComponent) || !(specialEffectData is HardLifeData))
				{
					goto IL_19A;
				}
				damage = (evtData as DamageComponent);
				data = (specialEffectData as HardLifeData);
				damageRate = damage.GetTotalDamageSoFar() / damage.Target.GetMaxLife(AttributeRetrievalLevel.Skill);
				if (damageRate < data.DamageRate)
				{
					goto IL_19A;
				}
				i = 0;
				break;
			case 1u:
				Block_7:
				try
				{
					switch (num)
					{
					}
					if (enumerator.MoveNext())
					{
						_ = enumerator.Current;
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
						if ((disposable = (enumerator as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
				i++;
				break;
			default:
				return false;
			}
			if (i < data.NumberOfShields)
			{
				enumerator = effectCarrier.ApplySkillEffect(new DamageNeutralizationEffect(new int?(1), effectCarrier, true), false).GetEnumerator();
				num = 4294967293u;
				goto Block_7;
			}
			IL_19A:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014F7 RID: 5367
		// (get) Token: 0x06006420 RID: 25632 RVA: 0x00197A48 File Offset: 0x00195E48
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014F8 RID: 5368
		// (get) Token: 0x06006421 RID: 25633 RVA: 0x00197A50 File Offset: 0x00195E50
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006422 RID: 25634 RVA: 0x00197A58 File Offset: 0x00195E58
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
				}
				finally
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06006423 RID: 25635 RVA: 0x00197AC8 File Offset: 0x00195EC8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006424 RID: 25636 RVA: 0x00197ACF File Offset: 0x00195ECF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006425 RID: 25637 RVA: 0x00197AD8 File Offset: 0x00195ED8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			HardLifeEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new HardLifeEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005BC8 RID: 23496
		internal AdventureEventType evtType;

		// Token: 0x04005BC9 RID: 23497
		internal IBattleUnit triggerUnit;

		// Token: 0x04005BCA RID: 23498
		internal IBattleUnit effectCarrier;

		// Token: 0x04005BCB RID: 23499
		internal object evtData;

		// Token: 0x04005BCC RID: 23500
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005BCD RID: 23501
		internal DamageComponent <damage>__1;

		// Token: 0x04005BCE RID: 23502
		internal HardLifeData <data>__1;

		// Token: 0x04005BCF RID: 23503
		internal double <damageRate>__1;

		// Token: 0x04005BD0 RID: 23504
		internal int <i>__2;

		// Token: 0x04005BD1 RID: 23505
		internal IEnumerator $locvar0;

		// Token: 0x04005BD2 RID: 23506
		internal object <_>__3;

		// Token: 0x04005BD3 RID: 23507
		internal IDisposable $locvar1;

		// Token: 0x04005BD4 RID: 23508
		internal object $current;

		// Token: 0x04005BD5 RID: 23509
		internal bool $disposing;

		// Token: 0x04005BD6 RID: 23510
		internal int $PC;
	}
}
