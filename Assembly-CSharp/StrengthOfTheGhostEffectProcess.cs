using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200092D RID: 2349
public class StrengthOfTheGhostEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004102 RID: 16642 RVA: 0x001A6540 File Offset: 0x001A4940
	public StrengthOfTheGhostEffectProcess()
	{
	}

	// Token: 0x17000C19 RID: 3097
	// (get) Token: 0x06004103 RID: 16643 RVA: 0x001A657B File Offset: 0x001A497B
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000C1A RID: 3098
	// (get) Token: 0x06004104 RID: 16644 RVA: 0x001A6583 File Offset: 0x001A4983
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return this._correspondingEvents;
		}
	}

	// Token: 0x06004105 RID: 16645 RVA: 0x001A658C File Offset: 0x001A498C
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && specialEffectData is StrengthOfTheGhostData)
		{
			StrengthOfTheGhostData strengthOfTheGhostData = specialEffectData as StrengthOfTheGhostData;
			strengthOfTheGhostData.NumberOfDeathsSoFar = 0;
		}
		if (evtType == AdventureEventType.UnitKilled && triggerUnit != effectCarrier && effectCarrier.GetUnitType() == UnitClass.YoungWarlock && specialEffectData is StrengthOfTheGhostData)
		{
			StrengthOfTheGhostData data = specialEffectData as StrengthOfTheGhostData;
			data.NumberOfDeathsSoFar++;
			IEnumerator enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = effectCarrier.GetOutputAttributeType(),
					ModificationType = ModificationType.Multiplication,
					Value = data.OutputRate * (double)data.NumberOfDeathsSoFar,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				},
				new AttributeModifier
				{
					AttributeType = AttributeType.Allresistances,
					ModificationType = ModificationType.Multiplication,
					Value = data.ResistanceRate * (double)data.NumberOfDeathsSoFar,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				}
			}, "youngwarlockunique", new int?(1), null, null, false, false, false), false).GetEnumerator();
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

	// Token: 0x040030DC RID: 12508
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.StrengthOfTheGhost;

	// Token: 0x040030DD RID: 12509
	private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
	{
		AdventureEventType.UnitKilled,
		AdventureEventType.UnitReadyInBattle
	};

	// Token: 0x02000FCA RID: 4042
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600666B RID: 26219 RVA: 0x001A65C5 File Offset: 0x001A49C5
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600666C RID: 26220 RVA: 0x001A65D0 File Offset: 0x001A49D0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && specialEffectData is StrengthOfTheGhostData)
				{
					StrengthOfTheGhostData strengthOfTheGhostData = specialEffectData as StrengthOfTheGhostData;
					strengthOfTheGhostData.NumberOfDeathsSoFar = 0;
				}
				if (evtType != AdventureEventType.UnitKilled || triggerUnit == effectCarrier || effectCarrier.GetUnitType() != UnitClass.YoungWarlock || !(specialEffectData is StrengthOfTheGhostData))
				{
					goto IL_24C;
				}
				data = (specialEffectData as StrengthOfTheGhostData);
				data.NumberOfDeathsSoFar++;
				enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = effectCarrier.GetOutputAttributeType(),
						ModificationType = ModificationType.Multiplication,
						Value = data.OutputRate * (double)data.NumberOfDeathsSoFar,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.Allresistances,
						ModificationType = ModificationType.Multiplication,
						Value = data.ResistanceRate * (double)data.NumberOfDeathsSoFar,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "youngwarlockunique", new int?(1), null, null, false, false, false), false).GetEnumerator();
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
			IL_24C:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700157B RID: 5499
		// (get) Token: 0x0600666D RID: 26221 RVA: 0x001A6844 File Offset: 0x001A4C44
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700157C RID: 5500
		// (get) Token: 0x0600666E RID: 26222 RVA: 0x001A684C File Offset: 0x001A4C4C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600666F RID: 26223 RVA: 0x001A6854 File Offset: 0x001A4C54
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

		// Token: 0x06006670 RID: 26224 RVA: 0x001A68C4 File Offset: 0x001A4CC4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006671 RID: 26225 RVA: 0x001A68CB File Offset: 0x001A4CCB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006672 RID: 26226 RVA: 0x001A68D4 File Offset: 0x001A4CD4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			StrengthOfTheGhostEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new StrengthOfTheGhostEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005F71 RID: 24433
		internal AdventureEventType evtType;

		// Token: 0x04005F72 RID: 24434
		internal IBattleUnit triggerUnit;

		// Token: 0x04005F73 RID: 24435
		internal IBattleUnit effectCarrier;

		// Token: 0x04005F74 RID: 24436
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005F75 RID: 24437
		internal StrengthOfTheGhostData <data>__1;

		// Token: 0x04005F76 RID: 24438
		internal IEnumerator $locvar0;

		// Token: 0x04005F77 RID: 24439
		internal object <_>__2;

		// Token: 0x04005F78 RID: 24440
		internal IDisposable $locvar1;

		// Token: 0x04005F79 RID: 24441
		internal object $current;

		// Token: 0x04005F7A RID: 24442
		internal bool $disposing;

		// Token: 0x04005F7B RID: 24443
		internal int $PC;
	}
}
