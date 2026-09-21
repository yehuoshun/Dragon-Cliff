using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008BA RID: 2234
public class CommandmentOfSpellEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F03 RID: 16131 RVA: 0x00188790 File Offset: 0x00186B90
	public CommandmentOfSpellEffectProcess()
	{
	}

	// Token: 0x17000B36 RID: 2870
	// (get) Token: 0x06003F04 RID: 16132 RVA: 0x00188798 File Offset: 0x00186B98
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.CommandmentOfSpell;
		}
	}

	// Token: 0x17000B37 RID: 2871
	// (get) Token: 0x06003F05 RID: 16133 RVA: 0x0018879C File Offset: 0x00186B9C
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

	// Token: 0x06003F06 RID: 16134 RVA: 0x001887B8 File Offset: 0x00186BB8
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && specialEffectData is CommandmentOfSpellData && triggerUnit.GetOutputAttributeType() == AttributeType.Intelligience)
		{
			double totalValue = (from t in triggerUnit.GetAllLiveFriendlyTargetsIncSelf(false)
			where t != triggerUnit
			select t).Sum((IBattleUnit t) => t.GetAttributeValue_Final(AttributeType.Strength, AttributeRetrievalLevel.Skill));
			CommandmentOfSpellData data = specialEffectData as CommandmentOfSpellData;
			IEnumerator enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.Agility,
					ModificationType = ModificationType.Addition,
					Value = totalValue * data.Rate,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				}
			}, "commandmentofspell", new int?(1), null, null, false, false, false), false).GetEnumerator();
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

	// Token: 0x02000F2D RID: 3885
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006229 RID: 25129 RVA: 0x001887F1 File Offset: 0x00186BF1
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600622A RID: 25130 RVA: 0x001887FC File Offset: 0x00186BFC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitReadyInBattle || triggerUnit != effectCarrier || !(specialEffectData is CommandmentOfSpellData) || triggerUnit.GetOutputAttributeType() != AttributeType.Intelligience)
				{
					goto IL_20B;
				}
				totalValue = (from t in triggerUnit.GetAllLiveFriendlyTargetsIncSelf(false)
				where t != triggerUnit
				select t).Sum((IBattleUnit t) => t.GetAttributeValue_Final(AttributeType.Strength, AttributeRetrievalLevel.Skill));
				data = (specialEffectData as CommandmentOfSpellData);
				enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.Agility,
						ModificationType = ModificationType.Addition,
						Value = totalValue * data.Rate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "commandmentofspell", new int?(1), null, null, false, false, false), false).GetEnumerator();
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
			IL_20B:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700148D RID: 5261
		// (get) Token: 0x0600622B RID: 25131 RVA: 0x00188A30 File Offset: 0x00186E30
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700148E RID: 5262
		// (get) Token: 0x0600622C RID: 25132 RVA: 0x00188A38 File Offset: 0x00186E38
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600622D RID: 25133 RVA: 0x00188A40 File Offset: 0x00186E40
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

		// Token: 0x0600622E RID: 25134 RVA: 0x00188AB0 File Offset: 0x00186EB0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600622F RID: 25135 RVA: 0x00188AB7 File Offset: 0x00186EB7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006230 RID: 25136 RVA: 0x00188AC0 File Offset: 0x00186EC0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			CommandmentOfSpellEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new CommandmentOfSpellEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x06006231 RID: 25137 RVA: 0x00188B18 File Offset: 0x00186F18
		private static double <>m__0(IBattleUnit t)
		{
			return t.GetAttributeValue_Final(AttributeType.Strength, AttributeRetrievalLevel.Skill);
		}

		// Token: 0x04005858 RID: 22616
		internal AdventureEventType evtType;

		// Token: 0x04005859 RID: 22617
		internal IBattleUnit triggerUnit;

		// Token: 0x0400585A RID: 22618
		internal IBattleUnit effectCarrier;

		// Token: 0x0400585B RID: 22619
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x0400585C RID: 22620
		internal double <totalValue>__1;

		// Token: 0x0400585D RID: 22621
		internal CommandmentOfSpellData <data>__1;

		// Token: 0x0400585E RID: 22622
		internal IEnumerator $locvar0;

		// Token: 0x0400585F RID: 22623
		internal object <_>__2;

		// Token: 0x04005860 RID: 22624
		internal IDisposable $locvar1;

		// Token: 0x04005861 RID: 22625
		internal object $current;

		// Token: 0x04005862 RID: 22626
		internal bool $disposing;

		// Token: 0x04005863 RID: 22627
		internal int $PC;

		// Token: 0x04005864 RID: 22628
		private CommandmentOfSpellEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar2;

		// Token: 0x04005865 RID: 22629
		private static Func<IBattleUnit, double> <>f__am$cache0;

		// Token: 0x02000F2E RID: 3886
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x06006232 RID: 25138 RVA: 0x00188B22 File Offset: 0x00186F22
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x06006233 RID: 25139 RVA: 0x00188B2A File Offset: 0x00186F2A
			internal bool <>m__0(IBattleUnit t)
			{
				return t != this.triggerUnit;
			}

			// Token: 0x04005866 RID: 22630
			internal IBattleUnit triggerUnit;

			// Token: 0x04005867 RID: 22631
			internal CommandmentOfSpellEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;
		}
	}
}
