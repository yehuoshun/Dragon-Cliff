using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000916 RID: 2326
public class ReflectionBoostEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004097 RID: 16535 RVA: 0x001A1074 File Offset: 0x0019F474
	public ReflectionBoostEffectProcess()
	{
	}

	// Token: 0x17000BED RID: 3053
	// (get) Token: 0x06004098 RID: 16536 RVA: 0x001A107C File Offset: 0x0019F47C
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.ReflectionBoost;
		}
	}

	// Token: 0x17000BEE RID: 3054
	// (get) Token: 0x06004099 RID: 16537 RVA: 0x001A1080 File Offset: 0x0019F480
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitRegularTurnStarts,
				AdventureEventType.UnitReadyInBattle
			};
		}
	}

	// Token: 0x0600409A RID: 16538 RVA: 0x001A10A4 File Offset: 0x0019F4A4
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if ((evtType == AdventureEventType.UnitRegularTurnStarts || evtType == AdventureEventType.UnitReadyInBattle) && triggerUnit == effectCarrier && specialEffectData is ReflectionBoostData)
		{
			List<IBattleUnit> targets = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true);
			ReflectionBoostData data = specialEffectData as ReflectionBoostData;
			foreach (IBattleUnit battleUnit in targets)
			{
				IEnumerator enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.ReflectiveDamage,
						ModificationType = ModificationType.Addition,
						Value = data.ReflectionRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "uniquereflectionboost", new int?(1), null, new int?(2), false, true, false), false).GetEnumerator();
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

	// Token: 0x02000FA3 RID: 4003
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006571 RID: 25969 RVA: 0x001A10DD File Offset: 0x0019F4DD
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006572 RID: 25970 RVA: 0x001A10E8 File Offset: 0x0019F4E8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if ((evtType != AdventureEventType.UnitRegularTurnStarts && evtType != AdventureEventType.UnitReadyInBattle) || triggerUnit != effectCarrier || !(specialEffectData is ReflectionBoostData))
				{
					goto IL_1F1;
				}
				targets = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true);
				data = (specialEffectData as ReflectionBoostData);
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
					enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.ReflectiveDamage,
							ModificationType = ModificationType.Addition,
							Value = data.ReflectionRate,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, "uniquereflectionboost", new int?(1), null, new int?(2), false, true, false), false).GetEnumerator();
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
			IL_1F1:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001543 RID: 5443
		// (get) Token: 0x06006573 RID: 25971 RVA: 0x001A1324 File Offset: 0x0019F724
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001544 RID: 5444
		// (get) Token: 0x06006574 RID: 25972 RVA: 0x001A132C File Offset: 0x0019F72C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006575 RID: 25973 RVA: 0x001A1334 File Offset: 0x0019F734
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

		// Token: 0x06006576 RID: 25974 RVA: 0x001A13C8 File Offset: 0x0019F7C8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006577 RID: 25975 RVA: 0x001A13CF File Offset: 0x0019F7CF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006578 RID: 25976 RVA: 0x001A13D8 File Offset: 0x0019F7D8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ReflectionBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new ReflectionBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005E12 RID: 24082
		internal AdventureEventType evtType;

		// Token: 0x04005E13 RID: 24083
		internal IBattleUnit triggerUnit;

		// Token: 0x04005E14 RID: 24084
		internal IBattleUnit effectCarrier;

		// Token: 0x04005E15 RID: 24085
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005E16 RID: 24086
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x04005E17 RID: 24087
		internal ReflectionBoostData <data>__1;

		// Token: 0x04005E18 RID: 24088
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04005E19 RID: 24089
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x04005E1A RID: 24090
		internal IEnumerator $locvar1;

		// Token: 0x04005E1B RID: 24091
		internal object <_>__3;

		// Token: 0x04005E1C RID: 24092
		internal IDisposable $locvar2;

		// Token: 0x04005E1D RID: 24093
		internal object $current;

		// Token: 0x04005E1E RID: 24094
		internal bool $disposing;

		// Token: 0x04005E1F RID: 24095
		internal int $PC;
	}
}
