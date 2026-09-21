using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000927 RID: 2343
public class StandingGunEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x060040E8 RID: 16616 RVA: 0x001A4EA4 File Offset: 0x001A32A4
	public StandingGunEffectProcess()
	{
	}

	// Token: 0x17000C0D RID: 3085
	// (get) Token: 0x060040E9 RID: 16617 RVA: 0x001A4EAC File Offset: 0x001A32AC
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.StandingGun;
		}
	}

	// Token: 0x17000C0E RID: 3086
	// (get) Token: 0x060040EA RID: 16618 RVA: 0x001A4EB0 File Offset: 0x001A32B0
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

	// Token: 0x060040EB RID: 16619 RVA: 0x001A4ECC File Offset: 0x001A32CC
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && specialEffectData is StandingGunData)
		{
			StandingGunData data = specialEffectData as StandingGunData;
			List<AttributeModifier> modifiers = new List<AttributeModifier>();
			modifiers.AddRange(from r in UnitExtensions.GetAllResistances()
			select new AttributeModifier
			{
				AttributeType = r,
				ModificationType = ModificationType.Multiplication,
				Value = data.ResistanceBoost,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			});
			modifiers.Add(new AttributeModifier
			{
				AttributeType = effectCarrier.GetOutputAttributeType(),
				ModificationType = ModificationType.Multiplication,
				Value = data.OutputRate,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			});
			IEnumerator enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, modifiers, "standinggun", new int?(1), null, null, false, false, false), false).GetEnumerator();
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

	// Token: 0x02000FC2 RID: 4034
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006636 RID: 26166 RVA: 0x001A4F05 File Offset: 0x001A3305
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006637 RID: 26167 RVA: 0x001A4F10 File Offset: 0x001A3310
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				if (evtType != AdventureEventType.UnitReadyInBattle || triggerUnit != effectCarrier || !(specialEffectData is StandingGunData))
				{
					goto IL_1D1;
				}
				StandingGunData data = specialEffectData as StandingGunData;
				modifiers = new List<AttributeModifier>();
				modifiers.AddRange(from r in UnitExtensions.GetAllResistances()
				select new AttributeModifier
				{
					AttributeType = r,
					ModificationType = ModificationType.Multiplication,
					Value = data.ResistanceBoost,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				});
				modifiers.Add(new AttributeModifier
				{
					AttributeType = effectCarrier.GetOutputAttributeType(),
					ModificationType = ModificationType.Multiplication,
					Value = data.OutputRate,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				});
				enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, modifiers, "standinggun", new int?(1), null, null, false, false, false), false).GetEnumerator();
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
			IL_1D1:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700156F RID: 5487
		// (get) Token: 0x06006638 RID: 26168 RVA: 0x001A5108 File Offset: 0x001A3508
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001570 RID: 5488
		// (get) Token: 0x06006639 RID: 26169 RVA: 0x001A5110 File Offset: 0x001A3510
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600663A RID: 26170 RVA: 0x001A5118 File Offset: 0x001A3518
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

		// Token: 0x0600663B RID: 26171 RVA: 0x001A5188 File Offset: 0x001A3588
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600663C RID: 26172 RVA: 0x001A518F File Offset: 0x001A358F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600663D RID: 26173 RVA: 0x001A5198 File Offset: 0x001A3598
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			StandingGunEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new StandingGunEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005F1E RID: 24350
		internal AdventureEventType evtType;

		// Token: 0x04005F1F RID: 24351
		internal IBattleUnit triggerUnit;

		// Token: 0x04005F20 RID: 24352
		internal IBattleUnit effectCarrier;

		// Token: 0x04005F21 RID: 24353
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005F22 RID: 24354
		internal List<AttributeModifier> <modifiers>__1;

		// Token: 0x04005F23 RID: 24355
		internal IEnumerator $locvar0;

		// Token: 0x04005F24 RID: 24356
		internal object <_>__2;

		// Token: 0x04005F25 RID: 24357
		internal IDisposable $locvar1;

		// Token: 0x04005F26 RID: 24358
		internal object $current;

		// Token: 0x04005F27 RID: 24359
		internal bool $disposing;

		// Token: 0x04005F28 RID: 24360
		internal int $PC;

		// Token: 0x04005F29 RID: 24361
		private StandingGunEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar2;

		// Token: 0x02000FC3 RID: 4035
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x0600663E RID: 26174 RVA: 0x001A51F0 File Offset: 0x001A35F0
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x0600663F RID: 26175 RVA: 0x001A51F8 File Offset: 0x001A35F8
			internal AttributeModifier <>m__0(AttributeType r)
			{
				return new AttributeModifier
				{
					AttributeType = r,
					ModificationType = ModificationType.Multiplication,
					Value = this.data.ResistanceBoost,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				};
			}

			// Token: 0x04005F2A RID: 24362
			internal StandingGunData data;

			// Token: 0x04005F2B RID: 24363
			internal StandingGunEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;
		}
	}
}
