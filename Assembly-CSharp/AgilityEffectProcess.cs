using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008A9 RID: 2217
public class AgilityEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003EB2 RID: 16050 RVA: 0x00182D6C File Offset: 0x0018116C
	public AgilityEffectProcess()
	{
	}

	// Token: 0x17000B14 RID: 2836
	// (get) Token: 0x06003EB3 RID: 16051 RVA: 0x00182D74 File Offset: 0x00181174
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.Agility;
		}
	}

	// Token: 0x17000B15 RID: 2837
	// (get) Token: 0x06003EB4 RID: 16052 RVA: 0x00182D78 File Offset: 0x00181178
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

	// Token: 0x06003EB5 RID: 16053 RVA: 0x00182D94 File Offset: 0x00181194
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && effectCarrier == triggerUnit && evtData is DamageComponent && specialEffectData is AgilityData)
		{
			DamageComponent damage = evtData as DamageComponent;
			if (!damage.IsMissed && damage.IsDirectDamage)
			{
				AgilityData data = specialEffectData as AgilityData;
				IEnumerator enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.DodgeRateAdjustment,
						ModificationType = ModificationType.Addition,
						Value = data.IncreaseRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "agilityuniquerateboost", new int?(10), null, null, false, true, false), false).GetEnumerator();
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

	// Token: 0x02000F0F RID: 3855
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600615F RID: 24927 RVA: 0x00182DD5 File Offset: 0x001811D5
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006160 RID: 24928 RVA: 0x00182DE0 File Offset: 0x001811E0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitPostReceivesDamage_Single || effectCarrier != triggerUnit || !(evtData is DamageComponent) || !(specialEffectData is AgilityData))
				{
					goto IL_1B8;
				}
				damage = (evtData as DamageComponent);
				if (damage.IsMissed || !damage.IsDirectDamage)
				{
					goto IL_1B8;
				}
				data = (specialEffectData as AgilityData);
				enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.DodgeRateAdjustment,
						ModificationType = ModificationType.Addition,
						Value = data.IncreaseRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "agilityuniquerateboost", new int?(10), null, null, false, true, false), false).GetEnumerator();
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
			IL_1B8:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001464 RID: 5220
		// (get) Token: 0x06006161 RID: 24929 RVA: 0x00182FC0 File Offset: 0x001813C0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001465 RID: 5221
		// (get) Token: 0x06006162 RID: 24930 RVA: 0x00182FC8 File Offset: 0x001813C8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006163 RID: 24931 RVA: 0x00182FD0 File Offset: 0x001813D0
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

		// Token: 0x06006164 RID: 24932 RVA: 0x00183040 File Offset: 0x00181440
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006165 RID: 24933 RVA: 0x00183047 File Offset: 0x00181447
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006166 RID: 24934 RVA: 0x00183050 File Offset: 0x00181450
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			AgilityEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new AgilityEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005701 RID: 22273
		internal AdventureEventType evtType;

		// Token: 0x04005702 RID: 22274
		internal IBattleUnit effectCarrier;

		// Token: 0x04005703 RID: 22275
		internal IBattleUnit triggerUnit;

		// Token: 0x04005704 RID: 22276
		internal object evtData;

		// Token: 0x04005705 RID: 22277
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005706 RID: 22278
		internal DamageComponent <damage>__1;

		// Token: 0x04005707 RID: 22279
		internal AgilityData <data>__2;

		// Token: 0x04005708 RID: 22280
		internal IEnumerator $locvar0;

		// Token: 0x04005709 RID: 22281
		internal object <_>__3;

		// Token: 0x0400570A RID: 22282
		internal IDisposable $locvar1;

		// Token: 0x0400570B RID: 22283
		internal object $current;

		// Token: 0x0400570C RID: 22284
		internal bool $disposing;

		// Token: 0x0400570D RID: 22285
		internal int $PC;
	}
}
