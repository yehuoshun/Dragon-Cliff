using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000915 RID: 2325
public class RedBladeEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004093 RID: 16531 RVA: 0x001A0D08 File Offset: 0x0019F108
	public RedBladeEffectProcess()
	{
	}

	// Token: 0x17000BEB RID: 3051
	// (get) Token: 0x06004094 RID: 16532 RVA: 0x001A0D3B File Offset: 0x0019F13B
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000BEC RID: 3052
	// (get) Token: 0x06004095 RID: 16533 RVA: 0x001A0D43 File Offset: 0x0019F143
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return this._correspondingEvents;
		}
	}

	// Token: 0x06004096 RID: 16534 RVA: 0x001A0D4C File Offset: 0x0019F14C
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitKilled && !triggerUnit.IsPlayer && evtData is BattleDamage && specialEffectData is RedBladeData)
		{
			BattleDamage damage = evtData as BattleDamage;
			RedBladeData data = specialEffectData as RedBladeData;
			if (damage.Dealer == effectCarrier && effectCarrier.GetUnitType() == UnitClass.RedHorn)
			{
				IEnumerator enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.Strength,
						ModificationType = ModificationType.Multiplication,
						Value = data.BoostRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "redbladeboost", new int?(10), null, null, false, false, true), false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x04002FA9 RID: 12201
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.RedBlade;

	// Token: 0x04002FAA RID: 12202
	private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
	{
		AdventureEventType.UnitKilled
	};

	// Token: 0x02000FA2 RID: 4002
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006569 RID: 25961 RVA: 0x001A0D8D File Offset: 0x0019F18D
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600656A RID: 25962 RVA: 0x001A0D98 File Offset: 0x0019F198
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitKilled || triggerUnit.IsPlayer || !(evtData is BattleDamage) || !(specialEffectData is RedBladeData))
				{
					goto IL_1BE;
				}
				damage = (evtData as BattleDamage);
				data = (specialEffectData as RedBladeData);
				if (damage.Dealer != effectCarrier || effectCarrier.GetUnitType() != UnitClass.RedHorn)
				{
					goto IL_1BE;
				}
				enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.Strength,
						ModificationType = ModificationType.Multiplication,
						Value = data.BoostRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "redbladeboost", new int?(10), null, null, false, false, true), false).GetEnumerator();
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
			IL_1BE:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001541 RID: 5441
		// (get) Token: 0x0600656B RID: 25963 RVA: 0x001A0F80 File Offset: 0x0019F380
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001542 RID: 5442
		// (get) Token: 0x0600656C RID: 25964 RVA: 0x001A0F88 File Offset: 0x0019F388
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600656D RID: 25965 RVA: 0x001A0F90 File Offset: 0x0019F390
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

		// Token: 0x0600656E RID: 25966 RVA: 0x001A1000 File Offset: 0x0019F400
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600656F RID: 25967 RVA: 0x001A1007 File Offset: 0x0019F407
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006570 RID: 25968 RVA: 0x001A1010 File Offset: 0x0019F410
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			RedBladeEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new RedBladeEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005E05 RID: 24069
		internal AdventureEventType evtType;

		// Token: 0x04005E06 RID: 24070
		internal IBattleUnit triggerUnit;

		// Token: 0x04005E07 RID: 24071
		internal object evtData;

		// Token: 0x04005E08 RID: 24072
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005E09 RID: 24073
		internal BattleDamage <damage>__1;

		// Token: 0x04005E0A RID: 24074
		internal RedBladeData <data>__1;

		// Token: 0x04005E0B RID: 24075
		internal IBattleUnit effectCarrier;

		// Token: 0x04005E0C RID: 24076
		internal IEnumerator $locvar0;

		// Token: 0x04005E0D RID: 24077
		internal object <_>__2;

		// Token: 0x04005E0E RID: 24078
		internal IDisposable $locvar1;

		// Token: 0x04005E0F RID: 24079
		internal object $current;

		// Token: 0x04005E10 RID: 24080
		internal bool $disposing;

		// Token: 0x04005E11 RID: 24081
		internal int $PC;
	}
}
