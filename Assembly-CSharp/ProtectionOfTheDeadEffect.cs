using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000767 RID: 1895
public class ProtectionOfTheDeadEffect : BattleEffectBase
{
	// Token: 0x0600373B RID: 14139 RVA: 0x0016D4AD File Offset: 0x0016B8AD
	public ProtectionOfTheDeadEffect()
	{
	}

	// Token: 0x0600373C RID: 14140 RVA: 0x0016D4B8 File Offset: 0x0016B8B8
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitPreKilled
		};
	}

	// Token: 0x17000A0C RID: 2572
	// (get) Token: 0x0600373D RID: 14141 RVA: 0x0016D4D4 File Offset: 0x0016B8D4
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000A0D RID: 2573
	// (get) Token: 0x0600373E RID: 14142 RVA: 0x0016D4DC File Offset: 0x0016B8DC
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000A0E RID: 2574
	// (get) Token: 0x0600373F RID: 14143 RVA: 0x0016D4E4 File Offset: 0x0016B8E4
	// (set) Token: 0x06003740 RID: 14144 RVA: 0x0016D4EC File Offset: 0x0016B8EC
	public override float? MaxNumberOfLastingSeconds
	{
		[CompilerGenerated]
		get
		{
			return this.<MaxNumberOfLastingSeconds>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<MaxNumberOfLastingSeconds>k__BackingField = value;
		}
	}

	// Token: 0x17000A0F RID: 2575
	// (get) Token: 0x06003741 RID: 14145 RVA: 0x0016D4F5 File Offset: 0x0016B8F5
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000A10 RID: 2576
	// (get) Token: 0x06003742 RID: 14146 RVA: 0x0016D4FD File Offset: 0x0016B8FD
	// (set) Token: 0x06003743 RID: 14147 RVA: 0x0016D505 File Offset: 0x0016B905
	public override int? NumberOfLastingTurns
	{
		[CompilerGenerated]
		get
		{
			return this.<NumberOfLastingTurns>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<NumberOfLastingTurns>k__BackingField = value;
		}
	}

	// Token: 0x17000A11 RID: 2577
	// (get) Token: 0x06003744 RID: 14148 RVA: 0x0016D50E File Offset: 0x0016B90E
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000A12 RID: 2578
	// (get) Token: 0x06003745 RID: 14149 RVA: 0x0016D516 File Offset: 0x0016B916
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000A13 RID: 2579
	// (get) Token: 0x06003746 RID: 14150 RVA: 0x0016D51E File Offset: 0x0016B91E
	// (set) Token: 0x06003747 RID: 14151 RVA: 0x0016D526 File Offset: 0x0016B926
	public override bool CanBeDispersed
	{
		[CompilerGenerated]
		get
		{
			return this.<CanBeDispersed>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CanBeDispersed>k__BackingField = value;
		}
	}

	// Token: 0x17000A14 RID: 2580
	// (get) Token: 0x06003748 RID: 14152 RVA: 0x0016D52F File Offset: 0x0016B92F
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000A15 RID: 2581
	// (get) Token: 0x06003749 RID: 14153 RVA: 0x0016D537 File Offset: 0x0016B937
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x0600374A RID: 14154 RVA: 0x0016D540 File Offset: 0x0016B940
	public static IEnumerable AddLayer(int numberOfLayer, IBattleUnit target, IBattleUnit sourceUnit)
	{
		ProtectionOfTheDeadEffect existing = target.BattleEffects.OfType<ProtectionOfTheDeadEffect>().FirstOrDefault<ProtectionOfTheDeadEffect>();
		DeathBoostData effect = sourceUnit.SpecialEffects.OfType<DeathBoostData>().FirstOrDefault<DeathBoostData>();
		if (existing != null)
		{
			existing._layer += numberOfLayer;
			if (existing._layer > 15)
			{
				existing._layer = 15;
			}
			existing.Description = existing._battleEffectType.GetDescription();
			existing.Description.Details1 = existing.Description.Details1.Replace("{number}", existing._layer.ToString()).Replace("{rate}", (effect == null) ? string.Empty : effect.DamageRatePerLayer.ToExpressionMultiply100());
		}
		else
		{
			ProtectionOfTheDeadEffect eft = new ProtectionOfTheDeadEffect
			{
				CanBeDispersed = false,
				_effectSource = sourceUnit,
				_effectSourceIdentityCode = "uniqueprotectionofdeatheffect",
				MaxNumberOfLastingSeconds = null,
				NumberOfLastingTurns = null,
				_battleEffectNatureForWearer = BattleEffectNature.Positive,
				_battleEffectType = BattleEffectType.ProtectionOfTheDead,
				_canBeImmuned = false,
				_isThroughEffect = true,
				_layer = numberOfLayer,
				_maxStackableInstances = new int?(1),
				TurnEventsCollected = new List<AdventureEventType>(),
				Description = BattleEffectType.ProtectionOfTheDead.GetDescription()
			};
			if (eft._layer > 15)
			{
				eft._layer = 15;
			}
			eft.Description.Details1 = eft.Description.Details1.Replace("{number}", eft._layer.ToString()).Replace("{rate}", (effect == null) ? string.Empty : effect.DamageRatePerLayer.ToExpressionMultiply100());
			IEnumerator enumerator = target.ApplySkillEffect(eft, false).GetEnumerator();
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

	// Token: 0x0600374B RID: 14155 RVA: 0x0016D574 File Offset: 0x0016B974
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		if (this._layer > 0)
		{
			return new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.EffectResistanceRating,
					ModificationType = ModificationType.Multiplication,
					Value = (double)this._layer * 0.1,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				}
			};
		}
		return new List<AttributeModifier>();
	}

	// Token: 0x0600374C RID: 14156 RVA: 0x0016D5E4 File Offset: 0x0016B9E4
	public override IEnumerable PerSecondLogic_ActiveUnit(IBattleUnit listener)
	{
		DeathBoostData ef = listener.SpecialEffects.OfType<DeathBoostData>().FirstOrDefault<DeathBoostData>();
		if (ef != null)
		{
			double damage = ef.DamageRatePerLayer * (double)this._layer * listener.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value;
			List<IBattleUnit> targets = listener.GetLiveEnemyTargets(false, true);
			if (targets.Any<IBattleUnit>())
			{
				IBattleUnit target = targets[UnityEngine.Random.Range(0, targets.Count)];
				IEnumerator enumerator = DamageOverTimeEffect.AddDamageOverSecond(target, listener, damage, 5, OutputType.Shadow).GetEnumerator();
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

	// Token: 0x0600374D RID: 14157 RVA: 0x0016D610 File Offset: 0x0016BA10
	public IEnumerable RemoveLayer(int numberOfremoval, IBattleUnit carrier)
	{
		if (numberOfremoval <= this._layer)
		{
			this._layer -= numberOfremoval;
			if (this._layer <= 0)
			{
				IEnumerator enumerator = carrier.LooseSkillEffect(this, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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

	// Token: 0x0600374E RID: 14158 RVA: 0x0016D644 File Offset: 0x0016BA44
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitPreKilled && eventTriggerUnit == listener && listener.HealthPoints <= 0.0 && this._layer >= 5)
		{
			this._layer -= 5;
			DeathBoostData ef = listener.SpecialEffects.OfType<DeathBoostData>().FirstOrDefault<DeathBoostData>();
			if (ef != null)
			{
				IEnumerator enumerator = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(listener, listener, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = listener.GetMaxLife(AttributeRetrievalLevel.Skill) * ef.ReviveRate,
							IsDirectHeal = false,
							HealType = OutputType.RealHeal
						}
					}, true)
				}, listener).Release().GetEnumerator();
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
				if (this._layer <= 0)
				{
					IEnumerator enumerator2 = listener.LooseSkillEffect(this, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							object _2 = enumerator2.Current;
							yield return _2;
						}
					}
					finally
					{
						IDisposable disposable2;
						if ((disposable2 = (enumerator2 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x04002ACF RID: 10959
	private string _effectSourceIdentityCode;

	// Token: 0x04002AD0 RID: 10960
	private BattleEffectType _battleEffectType;

	// Token: 0x04002AD1 RID: 10961
	private IBattleEffectSource _effectSource;

	// Token: 0x04002AD2 RID: 10962
	private bool _isThroughEffect;

	// Token: 0x04002AD3 RID: 10963
	private bool _canBeImmuned;

	// Token: 0x04002AD4 RID: 10964
	private int? _maxStackableInstances;

	// Token: 0x04002AD5 RID: 10965
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002AD6 RID: 10966
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x04002AD7 RID: 10967
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x04002AD8 RID: 10968
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;

	// Token: 0x04002AD9 RID: 10969
	public int _layer;

	// Token: 0x02000ECB RID: 3787
	[CompilerGenerated]
	private sealed class <AddLayer>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005F64 RID: 24420 RVA: 0x0016D67C File Offset: 0x0016BA7C
		[DebuggerHidden]
		public <AddLayer>c__Iterator0()
		{
		}

		// Token: 0x06005F65 RID: 24421 RVA: 0x0016D684 File Offset: 0x0016BA84
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				existing = target.BattleEffects.OfType<ProtectionOfTheDeadEffect>().FirstOrDefault<ProtectionOfTheDeadEffect>();
				effect = sourceUnit.SpecialEffects.OfType<DeathBoostData>().FirstOrDefault<DeathBoostData>();
				if (existing != null)
				{
					existing._layer += numberOfLayer;
					if (existing._layer > 15)
					{
						existing._layer = 15;
					}
					existing.Description = existing._battleEffectType.GetDescription();
					existing.Description.Details1 = existing.Description.Details1.Replace("{number}", existing._layer.ToString()).Replace("{rate}", (effect == null) ? string.Empty : effect.DamageRatePerLayer.ToExpressionMultiply100());
					goto IL_2F3;
				}
				eft = new ProtectionOfTheDeadEffect
				{
					CanBeDispersed = false,
					_effectSource = sourceUnit,
					_effectSourceIdentityCode = "uniqueprotectionofdeatheffect",
					MaxNumberOfLastingSeconds = null,
					NumberOfLastingTurns = null,
					_battleEffectNatureForWearer = BattleEffectNature.Positive,
					_battleEffectType = BattleEffectType.ProtectionOfTheDead,
					_canBeImmuned = false,
					_isThroughEffect = true,
					_layer = numberOfLayer,
					_maxStackableInstances = new int?(1),
					TurnEventsCollected = new List<AdventureEventType>(),
					Description = BattleEffectType.ProtectionOfTheDead.GetDescription()
				};
				if (eft._layer > 15)
				{
					eft._layer = 15;
				}
				eft.Description.Details1 = eft.Description.Details1.Replace("{number}", eft._layer.ToString()).Replace("{rate}", (effect == null) ? string.Empty : effect.DamageRatePerLayer.ToExpressionMultiply100());
				enumerator = target.ApplySkillEffect(eft, false).GetEnumerator();
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
			IL_2F3:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013F0 RID: 5104
		// (get) Token: 0x06005F66 RID: 24422 RVA: 0x0016D9A0 File Offset: 0x0016BDA0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013F1 RID: 5105
		// (get) Token: 0x06005F67 RID: 24423 RVA: 0x0016D9A8 File Offset: 0x0016BDA8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005F68 RID: 24424 RVA: 0x0016D9B0 File Offset: 0x0016BDB0
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

		// Token: 0x06005F69 RID: 24425 RVA: 0x0016DA20 File Offset: 0x0016BE20
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005F6A RID: 24426 RVA: 0x0016DA27 File Offset: 0x0016BE27
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005F6B RID: 24427 RVA: 0x0016DA30 File Offset: 0x0016BE30
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ProtectionOfTheDeadEffect.<AddLayer>c__Iterator0 <AddLayer>c__Iterator = new ProtectionOfTheDeadEffect.<AddLayer>c__Iterator0();
			<AddLayer>c__Iterator.target = target;
			<AddLayer>c__Iterator.sourceUnit = sourceUnit;
			<AddLayer>c__Iterator.numberOfLayer = numberOfLayer;
			return <AddLayer>c__Iterator;
		}

		// Token: 0x040053EC RID: 21484
		internal IBattleUnit target;

		// Token: 0x040053ED RID: 21485
		internal ProtectionOfTheDeadEffect <existing>__0;

		// Token: 0x040053EE RID: 21486
		internal IBattleUnit sourceUnit;

		// Token: 0x040053EF RID: 21487
		internal DeathBoostData <effect>__0;

		// Token: 0x040053F0 RID: 21488
		internal int numberOfLayer;

		// Token: 0x040053F1 RID: 21489
		internal ProtectionOfTheDeadEffect <eft>__1;

		// Token: 0x040053F2 RID: 21490
		internal IEnumerator $locvar0;

		// Token: 0x040053F3 RID: 21491
		internal object <_>__2;

		// Token: 0x040053F4 RID: 21492
		internal IDisposable $locvar1;

		// Token: 0x040053F5 RID: 21493
		internal object $current;

		// Token: 0x040053F6 RID: 21494
		internal bool $disposing;

		// Token: 0x040053F7 RID: 21495
		internal int $PC;
	}

	// Token: 0x02000ECC RID: 3788
	[CompilerGenerated]
	private sealed class <PerSecondLogic_ActiveUnit>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005F6C RID: 24428 RVA: 0x0016DA7C File Offset: 0x0016BE7C
		[DebuggerHidden]
		public <PerSecondLogic_ActiveUnit>c__Iterator1()
		{
		}

		// Token: 0x06005F6D RID: 24429 RVA: 0x0016DA84 File Offset: 0x0016BE84
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ef = listener.SpecialEffects.OfType<DeathBoostData>().FirstOrDefault<DeathBoostData>();
				if (ef == null)
				{
					goto IL_167;
				}
				damage = ef.DamageRatePerLayer * (double)this._layer * listener.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value;
				targets = listener.GetLiveEnemyTargets(false, true);
				if (!targets.Any<IBattleUnit>())
				{
					goto IL_167;
				}
				target = targets[UnityEngine.Random.Range(0, targets.Count)];
				enumerator = DamageOverTimeEffect.AddDamageOverSecond(target, listener, damage, 5, OutputType.Shadow).GetEnumerator();
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
			IL_167:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013F2 RID: 5106
		// (get) Token: 0x06005F6E RID: 24430 RVA: 0x0016DC14 File Offset: 0x0016C014
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013F3 RID: 5107
		// (get) Token: 0x06005F6F RID: 24431 RVA: 0x0016DC1C File Offset: 0x0016C01C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005F70 RID: 24432 RVA: 0x0016DC24 File Offset: 0x0016C024
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

		// Token: 0x06005F71 RID: 24433 RVA: 0x0016DC94 File Offset: 0x0016C094
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005F72 RID: 24434 RVA: 0x0016DC9B File Offset: 0x0016C09B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005F73 RID: 24435 RVA: 0x0016DCA4 File Offset: 0x0016C0A4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ProtectionOfTheDeadEffect.<PerSecondLogic_ActiveUnit>c__Iterator1 <PerSecondLogic_ActiveUnit>c__Iterator = new ProtectionOfTheDeadEffect.<PerSecondLogic_ActiveUnit>c__Iterator1();
			<PerSecondLogic_ActiveUnit>c__Iterator.$this = this;
			<PerSecondLogic_ActiveUnit>c__Iterator.listener = listener;
			return <PerSecondLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x040053F8 RID: 21496
		internal IBattleUnit listener;

		// Token: 0x040053F9 RID: 21497
		internal DeathBoostData <ef>__0;

		// Token: 0x040053FA RID: 21498
		internal double <damage>__1;

		// Token: 0x040053FB RID: 21499
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x040053FC RID: 21500
		internal IBattleUnit <target>__2;

		// Token: 0x040053FD RID: 21501
		internal IEnumerator $locvar0;

		// Token: 0x040053FE RID: 21502
		internal object <_>__3;

		// Token: 0x040053FF RID: 21503
		internal IDisposable $locvar1;

		// Token: 0x04005400 RID: 21504
		internal ProtectionOfTheDeadEffect $this;

		// Token: 0x04005401 RID: 21505
		internal object $current;

		// Token: 0x04005402 RID: 21506
		internal bool $disposing;

		// Token: 0x04005403 RID: 21507
		internal int $PC;
	}

	// Token: 0x02000ECD RID: 3789
	[CompilerGenerated]
	private sealed class <RemoveLayer>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005F74 RID: 24436 RVA: 0x0016DCE4 File Offset: 0x0016C0E4
		[DebuggerHidden]
		public <RemoveLayer>c__Iterator2()
		{
		}

		// Token: 0x06005F75 RID: 24437 RVA: 0x0016DCEC File Offset: 0x0016C0EC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (numberOfremoval > this._layer)
				{
					goto IL_104;
				}
				this._layer -= numberOfremoval;
				if (this._layer > 0)
				{
					goto IL_104;
				}
				enumerator = carrier.LooseSkillEffect(this, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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
			IL_104:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013F4 RID: 5108
		// (get) Token: 0x06005F76 RID: 24438 RVA: 0x0016DE18 File Offset: 0x0016C218
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013F5 RID: 5109
		// (get) Token: 0x06005F77 RID: 24439 RVA: 0x0016DE20 File Offset: 0x0016C220
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005F78 RID: 24440 RVA: 0x0016DE28 File Offset: 0x0016C228
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

		// Token: 0x06005F79 RID: 24441 RVA: 0x0016DE98 File Offset: 0x0016C298
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005F7A RID: 24442 RVA: 0x0016DE9F File Offset: 0x0016C29F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005F7B RID: 24443 RVA: 0x0016DEA8 File Offset: 0x0016C2A8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ProtectionOfTheDeadEffect.<RemoveLayer>c__Iterator2 <RemoveLayer>c__Iterator = new ProtectionOfTheDeadEffect.<RemoveLayer>c__Iterator2();
			<RemoveLayer>c__Iterator.$this = this;
			<RemoveLayer>c__Iterator.numberOfremoval = numberOfremoval;
			<RemoveLayer>c__Iterator.carrier = carrier;
			return <RemoveLayer>c__Iterator;
		}

		// Token: 0x04005404 RID: 21508
		internal int numberOfremoval;

		// Token: 0x04005405 RID: 21509
		internal IBattleUnit carrier;

		// Token: 0x04005406 RID: 21510
		internal IEnumerator $locvar0;

		// Token: 0x04005407 RID: 21511
		internal object <_>__1;

		// Token: 0x04005408 RID: 21512
		internal IDisposable $locvar1;

		// Token: 0x04005409 RID: 21513
		internal ProtectionOfTheDeadEffect $this;

		// Token: 0x0400540A RID: 21514
		internal object $current;

		// Token: 0x0400540B RID: 21515
		internal bool $disposing;

		// Token: 0x0400540C RID: 21516
		internal int $PC;
	}

	// Token: 0x02000ECE RID: 3790
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator3 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005F7C RID: 24444 RVA: 0x0016DEF4 File Offset: 0x0016C2F4
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator3()
		{
		}

		// Token: 0x06005F7D RID: 24445 RVA: 0x0016DEFC File Offset: 0x0016C2FC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitPreKilled || eventTriggerUnit != listener || listener.HealthPoints > 0.0 || this._layer < 5)
				{
					goto IL_264;
				}
				this._layer -= 5;
				ef = listener.SpecialEffects.OfType<DeathBoostData>().FirstOrDefault<DeathBoostData>();
				if (ef == null)
				{
					goto IL_264;
				}
				enumerator = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(listener, listener, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = listener.GetMaxLife(AttributeRetrievalLevel.Skill) * ef.ReviveRate,
							IsDirectHeal = false,
							HealType = OutputType.RealHeal
						}
					}, true)
				}, listener).Release().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_1E0;
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
			if (this._layer > 0)
			{
				goto IL_264;
			}
			enumerator2 = listener.LooseSkillEffect(this, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_1E0:
				switch (num)
				{
				}
				if (enumerator2.MoveNext())
				{
					_2 = enumerator2.Current;
					this.$current = _2;
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			IL_264:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013F6 RID: 5110
		// (get) Token: 0x06005F7E RID: 24446 RVA: 0x0016E194 File Offset: 0x0016C594
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013F7 RID: 5111
		// (get) Token: 0x06005F7F RID: 24447 RVA: 0x0016E19C File Offset: 0x0016C59C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005F80 RID: 24448 RVA: 0x0016E1A4 File Offset: 0x0016C5A4
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
			case 2u:
				try
				{
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005F81 RID: 24449 RVA: 0x0016E254 File Offset: 0x0016C654
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005F82 RID: 24450 RVA: 0x0016E25B File Offset: 0x0016C65B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005F83 RID: 24451 RVA: 0x0016E264 File Offset: 0x0016C664
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ProtectionOfTheDeadEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator3 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new ProtectionOfTheDeadEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator3();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.listener = listener;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x0400540D RID: 21517
		internal AdventureEventType eventType;

		// Token: 0x0400540E RID: 21518
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x0400540F RID: 21519
		internal IBattleUnit listener;

		// Token: 0x04005410 RID: 21520
		internal DeathBoostData <ef>__1;

		// Token: 0x04005411 RID: 21521
		internal IEnumerator $locvar0;

		// Token: 0x04005412 RID: 21522
		internal object <_>__2;

		// Token: 0x04005413 RID: 21523
		internal IDisposable $locvar1;

		// Token: 0x04005414 RID: 21524
		internal IEnumerator $locvar2;

		// Token: 0x04005415 RID: 21525
		internal object <_>__3;

		// Token: 0x04005416 RID: 21526
		internal IDisposable $locvar3;

		// Token: 0x04005417 RID: 21527
		internal ProtectionOfTheDeadEffect $this;

		// Token: 0x04005418 RID: 21528
		internal object $current;

		// Token: 0x04005419 RID: 21529
		internal bool $disposing;

		// Token: 0x0400541A RID: 21530
		internal int $PC;
	}
}
