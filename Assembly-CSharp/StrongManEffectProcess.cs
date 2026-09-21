using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200092F RID: 2351
public class StrongManEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x0600410A RID: 16650 RVA: 0x001A6C74 File Offset: 0x001A5074
	public StrongManEffectProcess()
	{
	}

	// Token: 0x17000C1D RID: 3101
	// (get) Token: 0x0600410B RID: 16651 RVA: 0x001A6C7C File Offset: 0x001A507C
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.StrongMan;
		}
	}

	// Token: 0x17000C1E RID: 3102
	// (get) Token: 0x0600410C RID: 16652 RVA: 0x001A6C80 File Offset: 0x001A5080
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

	// Token: 0x0600410D RID: 16653 RVA: 0x001A6C9C File Offset: 0x001A509C
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && specialEffectData is StrongManData)
		{
			StrongManData data = specialEffectData as StrongManData;
			double value = data.Rate * effectCarrier.GetAttributeValue_Final(AttributeType.Strength, AttributeRetrievalLevel.Skill);
			AttributeModificationEffect effect = AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, (from r in UnitExtensions.GetAllResistances()
			select new AttributeModifier
			{
				AttributeType = r,
				ModificationType = ModificationType.Addition,
				Value = value,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			}).ToList<AttributeModifier>(), "strongman", new int?(1), null, null, false, false, false);
			IEnumerator enumerator = effectCarrier.ApplySkillEffect(effect, false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x02000FCC RID: 4044
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600667B RID: 26235 RVA: 0x001A6CD5 File Offset: 0x001A50D5
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600667C RID: 26236 RVA: 0x001A6CE0 File Offset: 0x001A50E0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				if (evtType != AdventureEventType.UnitReadyInBattle || triggerUnit != effectCarrier || !(specialEffectData is StrongManData))
				{
					goto IL_192;
				}
				data = (specialEffectData as StrongManData);
				double value = data.Rate * effectCarrier.GetAttributeValue_Final(AttributeType.Strength, AttributeRetrievalLevel.Skill);
				effect = AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, (from r in UnitExtensions.GetAllResistances()
				select new AttributeModifier
				{
					AttributeType = r,
					ModificationType = ModificationType.Addition,
					Value = value,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				}).ToList<AttributeModifier>(), "strongman", new int?(1), null, null, false, false, false);
				enumerator = effectCarrier.ApplySkillEffect(effect, false).GetEnumerator();
				num = 4294967293u;
				break;
			}
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
			IL_192:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700157F RID: 5503
		// (get) Token: 0x0600667D RID: 26237 RVA: 0x001A6E9C File Offset: 0x001A529C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001580 RID: 5504
		// (get) Token: 0x0600667E RID: 26238 RVA: 0x001A6EA4 File Offset: 0x001A52A4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600667F RID: 26239 RVA: 0x001A6EAC File Offset: 0x001A52AC
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

		// Token: 0x06006680 RID: 26240 RVA: 0x001A6F1C File Offset: 0x001A531C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006681 RID: 26241 RVA: 0x001A6F23 File Offset: 0x001A5323
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006682 RID: 26242 RVA: 0x001A6F2C File Offset: 0x001A532C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			StrongManEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new StrongManEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005F8A RID: 24458
		internal AdventureEventType evtType;

		// Token: 0x04005F8B RID: 24459
		internal IBattleUnit triggerUnit;

		// Token: 0x04005F8C RID: 24460
		internal IBattleUnit effectCarrier;

		// Token: 0x04005F8D RID: 24461
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005F8E RID: 24462
		internal StrongManData <data>__1;

		// Token: 0x04005F8F RID: 24463
		internal AttributeModificationEffect <effect>__1;

		// Token: 0x04005F90 RID: 24464
		internal IEnumerator $locvar0;

		// Token: 0x04005F91 RID: 24465
		internal object <_>__2;

		// Token: 0x04005F92 RID: 24466
		internal IDisposable $locvar1;

		// Token: 0x04005F93 RID: 24467
		internal object $current;

		// Token: 0x04005F94 RID: 24468
		internal bool $disposing;

		// Token: 0x04005F95 RID: 24469
		internal int $PC;

		// Token: 0x04005F96 RID: 24470
		private StrongManEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar2;

		// Token: 0x02000FCD RID: 4045
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x06006683 RID: 26243 RVA: 0x001A6F84 File Offset: 0x001A5384
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x06006684 RID: 26244 RVA: 0x001A6F8C File Offset: 0x001A538C
			internal AttributeModifier <>m__0(AttributeType r)
			{
				return new AttributeModifier
				{
					AttributeType = r,
					ModificationType = ModificationType.Addition,
					Value = this.value,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				};
			}

			// Token: 0x04005F97 RID: 24471
			internal double value;

			// Token: 0x04005F98 RID: 24472
			internal StrongManEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;
		}
	}
}
