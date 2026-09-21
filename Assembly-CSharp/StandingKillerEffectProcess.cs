using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000928 RID: 2344
public class StandingKillerEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x060040EC RID: 16620 RVA: 0x001A523D File Offset: 0x001A363D
	public StandingKillerEffectProcess()
	{
	}

	// Token: 0x17000C0F RID: 3087
	// (get) Token: 0x060040ED RID: 16621 RVA: 0x001A5250 File Offset: 0x001A3650
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.StandingKiller;
		}
	}

	// Token: 0x17000C10 RID: 3088
	// (get) Token: 0x060040EE RID: 16622 RVA: 0x001A5254 File Offset: 0x001A3654
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReadyInBattle,
				AdventureEventType.UnitPostReceivesDamage_Single
			};
		}
	}

	// Token: 0x060040EF RID: 16623 RVA: 0x001A5278 File Offset: 0x001A3678
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && specialEffectData is StandingKillerData)
		{
			StandingKillerData standingKillerData = specialEffectData as StandingKillerData;
			standingKillerData.Counter = 0;
		}
		if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && triggerUnit == effectCarrier && specialEffectData is StandingKillerData)
		{
			DamageComponent damage = evtData as DamageComponent;
			if (damage.IsDirectDamage && !damage.IsMissed)
			{
				StandingKillerData data = specialEffectData as StandingKillerData;
				data.Counter = 0;
				List<AttributeModificationEffect> existings = (from ef in effectCarrier.BattleEffects.OfType<AttributeModificationEffect>()
				where ef.EffectSourceIdentityCode == this.buffKey
				select ef).ToList<AttributeModificationEffect>();
				foreach (AttributeModificationEffect attributeModificationEffect in existings)
				{
					IEnumerator enumerator2 = effectCarrier.LooseSkillEffect(attributeModificationEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x060040F0 RID: 16624 RVA: 0x001A52C0 File Offset: 0x001A36C0
	public override IEnumerable AsActiveUnitPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit effectCarrier)
	{
		if (specialEffectData is StandingKillerData)
		{
			StandingKillerData data = specialEffectData as StandingKillerData;
			data.Counter++;
			if (data.Counter >= 1)
			{
				data.Counter = 0;
				IEnumerator enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = effectCarrier.GetOutputAttributeType(),
						ModificationType = ModificationType.Multiplication,
						Value = data.OutputIncrease,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, this.buffKey, new int?(1), null, null, false, true, false), false).GetEnumerator();
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

	// Token: 0x040030DA RID: 12506
	private string buffKey = "standingkiller";

	// Token: 0x02000FC4 RID: 4036
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006640 RID: 26176 RVA: 0x001A52F1 File Offset: 0x001A36F1
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006641 RID: 26177 RVA: 0x001A52FC File Offset: 0x001A36FC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && specialEffectData is StandingKillerData)
				{
					StandingKillerData standingKillerData = specialEffectData as StandingKillerData;
					standingKillerData.Counter = 0;
				}
				if (evtType != AdventureEventType.UnitPostReceivesDamage_Single || triggerUnit != effectCarrier || !(specialEffectData is StandingKillerData))
				{
					goto IL_20F;
				}
				damage = (evtData as DamageComponent);
				if (!damage.IsDirectDamage || damage.IsMissed)
				{
					goto IL_20F;
				}
				data = (specialEffectData as StandingKillerData);
				data.Counter = 0;
				existings = (from ef in effectCarrier.BattleEffects.OfType<AttributeModificationEffect>()
				where ef.EffectSourceIdentityCode == this.buffKey
				select ef).ToList<AttributeModificationEffect>();
				enumerator = existings.GetEnumerator();
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
					Block_12:
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
					attributeModificationEffect = enumerator.Current;
					enumerator2 = effectCarrier.LooseSkillEffect(attributeModificationEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
					num = 4294967293u;
					goto Block_12;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_20F:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001571 RID: 5489
		// (get) Token: 0x06006642 RID: 26178 RVA: 0x001A5540 File Offset: 0x001A3940
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001572 RID: 5490
		// (get) Token: 0x06006643 RID: 26179 RVA: 0x001A5548 File Offset: 0x001A3948
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006644 RID: 26180 RVA: 0x001A5550 File Offset: 0x001A3950
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

		// Token: 0x06006645 RID: 26181 RVA: 0x001A55E4 File Offset: 0x001A39E4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006646 RID: 26182 RVA: 0x001A55EB File Offset: 0x001A39EB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006647 RID: 26183 RVA: 0x001A55F4 File Offset: 0x001A39F4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			StandingKillerEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new StandingKillerEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.$this = this;
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x06006648 RID: 26184 RVA: 0x001A5664 File Offset: 0x001A3A64
		internal bool <>m__0(AttributeModificationEffect ef)
		{
			return ef.EffectSourceIdentityCode == this.buffKey;
		}

		// Token: 0x04005F2C RID: 24364
		internal AdventureEventType evtType;

		// Token: 0x04005F2D RID: 24365
		internal IBattleUnit triggerUnit;

		// Token: 0x04005F2E RID: 24366
		internal IBattleUnit effectCarrier;

		// Token: 0x04005F2F RID: 24367
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005F30 RID: 24368
		internal object evtData;

		// Token: 0x04005F31 RID: 24369
		internal DamageComponent <damage>__1;

		// Token: 0x04005F32 RID: 24370
		internal StandingKillerData <data>__2;

		// Token: 0x04005F33 RID: 24371
		internal List<AttributeModificationEffect> <existings>__2;

		// Token: 0x04005F34 RID: 24372
		internal List<AttributeModificationEffect>.Enumerator $locvar0;

		// Token: 0x04005F35 RID: 24373
		internal AttributeModificationEffect <attributeModificationEffect>__3;

		// Token: 0x04005F36 RID: 24374
		internal IEnumerator $locvar1;

		// Token: 0x04005F37 RID: 24375
		internal object <_>__4;

		// Token: 0x04005F38 RID: 24376
		internal IDisposable $locvar2;

		// Token: 0x04005F39 RID: 24377
		internal StandingKillerEffectProcess $this;

		// Token: 0x04005F3A RID: 24378
		internal object $current;

		// Token: 0x04005F3B RID: 24379
		internal bool $disposing;

		// Token: 0x04005F3C RID: 24380
		internal int $PC;
	}

	// Token: 0x02000FC5 RID: 4037
	[CompilerGenerated]
	private sealed class <AsActiveUnitPerSecondProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006649 RID: 26185 RVA: 0x001A567C File Offset: 0x001A3A7C
		[DebuggerHidden]
		public <AsActiveUnitPerSecondProcess>c__Iterator1()
		{
		}

		// Token: 0x0600664A RID: 26186 RVA: 0x001A5684 File Offset: 0x001A3A84
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (!(specialEffectData is StandingKillerData))
				{
					goto IL_194;
				}
				data = (specialEffectData as StandingKillerData);
				data.Counter++;
				if (data.Counter < 1)
				{
					goto IL_194;
				}
				data.Counter = 0;
				enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = effectCarrier.GetOutputAttributeType(),
						ModificationType = ModificationType.Multiplication,
						Value = data.OutputIncrease,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, this.buffKey, new int?(1), null, null, false, true, false), false).GetEnumerator();
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
			IL_194:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001573 RID: 5491
		// (get) Token: 0x0600664B RID: 26187 RVA: 0x001A5840 File Offset: 0x001A3C40
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001574 RID: 5492
		// (get) Token: 0x0600664C RID: 26188 RVA: 0x001A5848 File Offset: 0x001A3C48
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600664D RID: 26189 RVA: 0x001A5850 File Offset: 0x001A3C50
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

		// Token: 0x0600664E RID: 26190 RVA: 0x001A58C0 File Offset: 0x001A3CC0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600664F RID: 26191 RVA: 0x001A58C7 File Offset: 0x001A3CC7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006650 RID: 26192 RVA: 0x001A58D0 File Offset: 0x001A3CD0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			StandingKillerEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator1 <AsActiveUnitPerSecondProcess>c__Iterator = new StandingKillerEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator1();
			<AsActiveUnitPerSecondProcess>c__Iterator.$this = this;
			<AsActiveUnitPerSecondProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitPerSecondProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitPerSecondProcess>c__Iterator;
		}

		// Token: 0x04005F3D RID: 24381
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005F3E RID: 24382
		internal StandingKillerData <data>__1;

		// Token: 0x04005F3F RID: 24383
		internal IBattleUnit effectCarrier;

		// Token: 0x04005F40 RID: 24384
		internal IEnumerator $locvar0;

		// Token: 0x04005F41 RID: 24385
		internal object <_>__2;

		// Token: 0x04005F42 RID: 24386
		internal IDisposable $locvar1;

		// Token: 0x04005F43 RID: 24387
		internal StandingKillerEffectProcess $this;

		// Token: 0x04005F44 RID: 24388
		internal object $current;

		// Token: 0x04005F45 RID: 24389
		internal bool $disposing;

		// Token: 0x04005F46 RID: 24390
		internal int $PC;
	}
}
