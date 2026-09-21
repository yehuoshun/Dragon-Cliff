using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200093A RID: 2362
public class TranscendenceEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004141 RID: 16705 RVA: 0x001AB810 File Offset: 0x001A9C10
	public TranscendenceEffectProcess()
	{
	}

	// Token: 0x17000C33 RID: 3123
	// (get) Token: 0x06004142 RID: 16706 RVA: 0x001AB818 File Offset: 0x001A9C18
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.Transcendence;
		}
	}

	// Token: 0x17000C34 RID: 3124
	// (get) Token: 0x06004143 RID: 16707 RVA: 0x001AB81C File Offset: 0x001A9C1C
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitKilled
			};
		}
	}

	// Token: 0x06004144 RID: 16708 RVA: 0x001AB838 File Offset: 0x001A9C38
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitKilled && specialEffectData is TranscendenceEffectData)
		{
			TranscendenceEffectData data = specialEffectData as TranscendenceEffectData;
			AttributeType optType = effectCarrier.GetOutputAttributeType();
			double optValue = effectCarrier.GetAttributeValue_Final(optType, AttributeRetrievalLevel.Skill);
			double boostValue = optValue * data.Rate;
			IEnumerator enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = optType,
					ModificationType = ModificationType.Addition,
					Value = boostValue,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				}
			}, "transcendent", new int?(20), null, null, false, true, false), false).GetEnumerator();
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

	// Token: 0x02000FDF RID: 4063
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060066F4 RID: 26356 RVA: 0x001AB86A File Offset: 0x001A9C6A
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060066F5 RID: 26357 RVA: 0x001AB874 File Offset: 0x001A9C74
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitKilled || !(specialEffectData is TranscendenceEffectData))
				{
					goto IL_1A3;
				}
				data = (specialEffectData as TranscendenceEffectData);
				optType = effectCarrier.GetOutputAttributeType();
				optValue = effectCarrier.GetAttributeValue_Final(optType, AttributeRetrievalLevel.Skill);
				boostValue = optValue * data.Rate;
				enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = optType,
						ModificationType = ModificationType.Addition,
						Value = boostValue,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					}
				}, "transcendent", new int?(20), null, null, false, true, false), false).GetEnumerator();
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
			IL_1A3:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001599 RID: 5529
		// (get) Token: 0x060066F6 RID: 26358 RVA: 0x001ABA40 File Offset: 0x001A9E40
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700159A RID: 5530
		// (get) Token: 0x060066F7 RID: 26359 RVA: 0x001ABA48 File Offset: 0x001A9E48
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060066F8 RID: 26360 RVA: 0x001ABA50 File Offset: 0x001A9E50
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

		// Token: 0x060066F9 RID: 26361 RVA: 0x001ABAC0 File Offset: 0x001A9EC0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060066FA RID: 26362 RVA: 0x001ABAC7 File Offset: 0x001A9EC7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060066FB RID: 26363 RVA: 0x001ABAD0 File Offset: 0x001A9ED0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			TranscendenceEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new TranscendenceEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x0400609D RID: 24733
		internal AdventureEventType evtType;

		// Token: 0x0400609E RID: 24734
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x0400609F RID: 24735
		internal TranscendenceEffectData <data>__1;

		// Token: 0x040060A0 RID: 24736
		internal IBattleUnit effectCarrier;

		// Token: 0x040060A1 RID: 24737
		internal AttributeType <optType>__1;

		// Token: 0x040060A2 RID: 24738
		internal double <optValue>__1;

		// Token: 0x040060A3 RID: 24739
		internal double <boostValue>__1;

		// Token: 0x040060A4 RID: 24740
		internal IEnumerator $locvar0;

		// Token: 0x040060A5 RID: 24741
		internal object <_>__2;

		// Token: 0x040060A6 RID: 24742
		internal IDisposable $locvar1;

		// Token: 0x040060A7 RID: 24743
		internal object $current;

		// Token: 0x040060A8 RID: 24744
		internal bool $disposing;

		// Token: 0x040060A9 RID: 24745
		internal int $PC;
	}
}
