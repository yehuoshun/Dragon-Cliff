using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008CD RID: 2253
public class DiseaseEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F56 RID: 16214 RVA: 0x0018F13C File Offset: 0x0018D53C
	public DiseaseEffectProcess()
	{
	}

	// Token: 0x17000B5C RID: 2908
	// (get) Token: 0x06003F57 RID: 16215 RVA: 0x0018F144 File Offset: 0x0018D544
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.Disease;
		}
	}

	// Token: 0x17000B5D RID: 2909
	// (get) Token: 0x06003F58 RID: 16216 RVA: 0x0018F148 File Offset: 0x0018D548
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

	// Token: 0x06003F59 RID: 16217 RVA: 0x0018F164 File Offset: 0x0018D564
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && effectCarrier == triggerUnit && evtData is DamageComponent && specialEffectData is DiseaseData)
		{
			DiseaseData data = specialEffectData as DiseaseData;
			DamageComponent damage = evtData as DamageComponent;
			List<IBattleUnit> targets = damage.Dealer.GetAllLiveFriendlyTargetsIncSelf(true);
			foreach (IBattleUnit target in targets)
			{
				IEnumerator enumerator2 = target.ApplySkillEffect(new ResistanceReductionPerSecondEffect(data.ResistanceReductionStartingValue, data.ResistanceReductionRateValue, effectCarrier, null, null), false).GetEnumerator();
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
				IEnumerator enumerator3 = DamageOverTimeEffect.AddDamageOverSecond(target, effectCarrier, data.DamageRate * effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value, data.DamageLastingSeconds, data.DamageType).GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						object _2 = enumerator3.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator3 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x02000F4B RID: 3915
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060062ED RID: 25325 RVA: 0x0018F1A5 File Offset: 0x0018D5A5
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060062EE RID: 25326 RVA: 0x0018F1B0 File Offset: 0x0018D5B0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitPostReceivesDamage_Single || effectCarrier != triggerUnit || !(evtData is DamageComponent) || !(specialEffectData is DiseaseData))
				{
					goto IL_2A6;
				}
				data = (specialEffectData as DiseaseData);
				damage = (evtData as DamageComponent);
				targets = damage.Dealer.GetAllLiveFriendlyTargetsIncSelf(true);
				enumerator = targets.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
			case 2u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_8:
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
					enumerator3 = DamageOverTimeEffect.AddDamageOverSecond(target, effectCarrier, data.DamageRate * effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value, data.DamageLastingSeconds, data.DamageType).GetEnumerator();
					num = 4294967293u;
					break;
				case 2u:
					break;
				default:
					goto IL_27B;
				}
				try
				{
					switch (num)
					{
					}
					if (enumerator3.MoveNext())
					{
						_2 = enumerator3.Current;
						this.$current = _2;
						if (!this.$disposing)
						{
							this.$PC = 2;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable2 = (enumerator3 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				IL_27B:
				if (enumerator.MoveNext())
				{
					target = enumerator.Current;
					enumerator2 = target.ApplySkillEffect(new ResistanceReductionPerSecondEffect(data.ResistanceReductionStartingValue, data.ResistanceReductionRateValue, effectCarrier, null, null), false).GetEnumerator();
					num = 4294967293u;
					goto Block_8;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_2A6:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014B5 RID: 5301
		// (get) Token: 0x060062EF RID: 25327 RVA: 0x0018F4BC File Offset: 0x0018D8BC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014B6 RID: 5302
		// (get) Token: 0x060062F0 RID: 25328 RVA: 0x0018F4C4 File Offset: 0x0018D8C4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060062F1 RID: 25329 RVA: 0x0018F4CC File Offset: 0x0018D8CC
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
			case 2u:
				try
				{
					switch (num)
					{
					case 1u:
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
						break;
					case 2u:
						try
						{
						}
						finally
						{
							if ((disposable2 = (enumerator3 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x060062F2 RID: 25330 RVA: 0x0018F5B4 File Offset: 0x0018D9B4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060062F3 RID: 25331 RVA: 0x0018F5BB File Offset: 0x0018D9BB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060062F4 RID: 25332 RVA: 0x0018F5C4 File Offset: 0x0018D9C4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DiseaseEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new DiseaseEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x040059DA RID: 23002
		internal AdventureEventType evtType;

		// Token: 0x040059DB RID: 23003
		internal IBattleUnit effectCarrier;

		// Token: 0x040059DC RID: 23004
		internal IBattleUnit triggerUnit;

		// Token: 0x040059DD RID: 23005
		internal object evtData;

		// Token: 0x040059DE RID: 23006
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x040059DF RID: 23007
		internal DiseaseData <data>__1;

		// Token: 0x040059E0 RID: 23008
		internal DamageComponent <damage>__1;

		// Token: 0x040059E1 RID: 23009
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x040059E2 RID: 23010
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x040059E3 RID: 23011
		internal IBattleUnit <target>__2;

		// Token: 0x040059E4 RID: 23012
		internal IEnumerator $locvar1;

		// Token: 0x040059E5 RID: 23013
		internal object <_>__3;

		// Token: 0x040059E6 RID: 23014
		internal IDisposable $locvar2;

		// Token: 0x040059E7 RID: 23015
		internal IEnumerator $locvar3;

		// Token: 0x040059E8 RID: 23016
		internal object <_>__4;

		// Token: 0x040059E9 RID: 23017
		internal IDisposable $locvar4;

		// Token: 0x040059EA RID: 23018
		internal object $current;

		// Token: 0x040059EB RID: 23019
		internal bool $disposing;

		// Token: 0x040059EC RID: 23020
		internal int $PC;
	}
}
