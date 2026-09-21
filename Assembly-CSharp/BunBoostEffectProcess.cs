using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008B6 RID: 2230
public class BunBoostEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003EF1 RID: 16113 RVA: 0x00187282 File Offset: 0x00185682
	public BunBoostEffectProcess()
	{
	}

	// Token: 0x17000B2E RID: 2862
	// (get) Token: 0x06003EF2 RID: 16114 RVA: 0x0018728A File Offset: 0x0018568A
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.BunBoost;
		}
	}

	// Token: 0x17000B2F RID: 2863
	// (get) Token: 0x06003EF3 RID: 16115 RVA: 0x00187294 File Offset: 0x00185694
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

	// Token: 0x06003EF4 RID: 16116 RVA: 0x001872B0 File Offset: 0x001856B0
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitKilled && !triggerUnit.IsPlayer && evtData is BattleDamage && specialEffectData is BunBoostData && effectCarrier.GetUnitType() == UnitClass.BunSister)
		{
			BunBoostData data = specialEffectData as BunBoostData;
			IEnumerator enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.Vitality,
					ModificationType = ModificationType.Multiplication,
					Value = data.VitalityBoostRate,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				},
				new AttributeModifier
				{
					AttributeType = AttributeType.ReflectiveDamage,
					ModificationType = ModificationType.Addition,
					Value = data.DamageReflectionRate,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				}
			}, "bunbooostexclusiveeffect", new int?(15), null, null, false, false, true), false).GetEnumerator();
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

	// Token: 0x02000F26 RID: 3878
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060061FE RID: 25086 RVA: 0x001872F1 File Offset: 0x001856F1
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060061FF RID: 25087 RVA: 0x001872FC File Offset: 0x001856FC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitKilled || triggerUnit.IsPlayer || !(evtData is BattleDamage) || !(specialEffectData is BunBoostData) || effectCarrier.GetUnitType() != UnitClass.BunSister)
				{
					goto IL_1D9;
				}
				data = (specialEffectData as BunBoostData);
				enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.Vitality,
						ModificationType = ModificationType.Multiplication,
						Value = data.VitalityBoostRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.ReflectiveDamage,
						ModificationType = ModificationType.Addition,
						Value = data.DamageReflectionRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "bunbooostexclusiveeffect", new int?(15), null, null, false, false, true), false).GetEnumerator();
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
			IL_1D9:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001485 RID: 5253
		// (get) Token: 0x06006200 RID: 25088 RVA: 0x001874FC File Offset: 0x001858FC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001486 RID: 5254
		// (get) Token: 0x06006201 RID: 25089 RVA: 0x00187504 File Offset: 0x00185904
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006202 RID: 25090 RVA: 0x0018750C File Offset: 0x0018590C
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

		// Token: 0x06006203 RID: 25091 RVA: 0x0018757C File Offset: 0x0018597C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006204 RID: 25092 RVA: 0x00187583 File Offset: 0x00185983
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006205 RID: 25093 RVA: 0x0018758C File Offset: 0x0018598C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BunBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new BunBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005807 RID: 22535
		internal AdventureEventType evtType;

		// Token: 0x04005808 RID: 22536
		internal IBattleUnit triggerUnit;

		// Token: 0x04005809 RID: 22537
		internal object evtData;

		// Token: 0x0400580A RID: 22538
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x0400580B RID: 22539
		internal IBattleUnit effectCarrier;

		// Token: 0x0400580C RID: 22540
		internal BunBoostData <data>__1;

		// Token: 0x0400580D RID: 22541
		internal IEnumerator $locvar0;

		// Token: 0x0400580E RID: 22542
		internal object <_>__2;

		// Token: 0x0400580F RID: 22543
		internal IDisposable $locvar1;

		// Token: 0x04005810 RID: 22544
		internal object $current;

		// Token: 0x04005811 RID: 22545
		internal bool $disposing;

		// Token: 0x04005812 RID: 22546
		internal int $PC;
	}
}
