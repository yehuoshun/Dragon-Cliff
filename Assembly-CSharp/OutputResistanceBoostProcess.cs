using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200090A RID: 2314
public class OutputResistanceBoostProcess : SpecialEffectProcessBase
{
	// Token: 0x0600405F RID: 16479 RVA: 0x0019E18C File Offset: 0x0019C58C
	public OutputResistanceBoostProcess()
	{
	}

	// Token: 0x17000BD4 RID: 3028
	// (get) Token: 0x06004060 RID: 16480 RVA: 0x0019E194 File Offset: 0x0019C594
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.OutputResistanceBoost;
		}
	}

	// Token: 0x17000BD5 RID: 3029
	// (get) Token: 0x06004061 RID: 16481 RVA: 0x0019E198 File Offset: 0x0019C598
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

	// Token: 0x06004062 RID: 16482 RVA: 0x0019E1B4 File Offset: 0x0019C5B4
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && effectCarrier == triggerUnit && specialEffectData is OutputResistanceBoostData)
		{
			OutputResistanceBoostData data = specialEffectData as OutputResistanceBoostData;
			AttributeModificationEffect ef = AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = BattleUnitExtensions.ResistanceToOutput[effectCarrier.GetOutputType()],
					ModificationType = ModificationType.Multiplication,
					Value = data.BoostRate,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				}
			}, "outputresistance", new int?(1), null, null, false, false, false);
			IEnumerator enumerator = effectCarrier.ApplySkillEffect(ef, false).GetEnumerator();
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

	// Token: 0x02000F97 RID: 3991
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006512 RID: 25874 RVA: 0x0019E1ED File Offset: 0x0019C5ED
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006513 RID: 25875 RVA: 0x0019E1F8 File Offset: 0x0019C5F8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitReadyInBattle || effectCarrier != triggerUnit || !(specialEffectData is OutputResistanceBoostData))
				{
					goto IL_192;
				}
				data = (specialEffectData as OutputResistanceBoostData);
				ef = AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = BattleUnitExtensions.ResistanceToOutput[effectCarrier.GetOutputType()],
						ModificationType = ModificationType.Multiplication,
						Value = data.BoostRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "outputresistance", new int?(1), null, null, false, false, false);
				enumerator = effectCarrier.ApplySkillEffect(ef, false).GetEnumerator();
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
			IL_192:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700152D RID: 5421
		// (get) Token: 0x06006514 RID: 25876 RVA: 0x0019E3B4 File Offset: 0x0019C7B4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700152E RID: 5422
		// (get) Token: 0x06006515 RID: 25877 RVA: 0x0019E3BC File Offset: 0x0019C7BC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006516 RID: 25878 RVA: 0x0019E3C4 File Offset: 0x0019C7C4
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

		// Token: 0x06006517 RID: 25879 RVA: 0x0019E434 File Offset: 0x0019C834
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006518 RID: 25880 RVA: 0x0019E43B File Offset: 0x0019C83B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006519 RID: 25881 RVA: 0x0019E444 File Offset: 0x0019C844
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			OutputResistanceBoostProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new OutputResistanceBoostProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005D62 RID: 23906
		internal AdventureEventType evtType;

		// Token: 0x04005D63 RID: 23907
		internal IBattleUnit effectCarrier;

		// Token: 0x04005D64 RID: 23908
		internal IBattleUnit triggerUnit;

		// Token: 0x04005D65 RID: 23909
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005D66 RID: 23910
		internal OutputResistanceBoostData <data>__1;

		// Token: 0x04005D67 RID: 23911
		internal AttributeModificationEffect <ef>__1;

		// Token: 0x04005D68 RID: 23912
		internal IEnumerator $locvar0;

		// Token: 0x04005D69 RID: 23913
		internal object <_>__2;

		// Token: 0x04005D6A RID: 23914
		internal IDisposable $locvar1;

		// Token: 0x04005D6B RID: 23915
		internal object $current;

		// Token: 0x04005D6C RID: 23916
		internal bool $disposing;

		// Token: 0x04005D6D RID: 23917
		internal int $PC;
	}
}
