using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000769 RID: 1897
public class ReflectiveShieldEffect : BattleEffectBase
{
	// Token: 0x0600375F RID: 14175 RVA: 0x0016E8C0 File Offset: 0x0016CCC0
	public ReflectiveShieldEffect(string effectSourceIdentityCode, int? numberOfLastingTurns, IBattleEffectSource effectSource)
	{
		this._effectSource = effectSource;
		this._effectSourceIdentityCode = "uniquereflectiveshield";
		this._numberOfLastingTurns = numberOfLastingTurns;
		base.Description = this.BattleEffectType.GetDescription();
		base.TurnEventsCollected = new List<AdventureEventType>();
	}

	// Token: 0x06003760 RID: 14176 RVA: 0x0016E924 File Offset: 0x0016CD24
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitReceivesDamage_Single
		};
	}

	// Token: 0x17000A20 RID: 2592
	// (get) Token: 0x06003761 RID: 14177 RVA: 0x0016E940 File Offset: 0x0016CD40
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000A21 RID: 2593
	// (get) Token: 0x06003762 RID: 14178 RVA: 0x0016E948 File Offset: 0x0016CD48
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000A22 RID: 2594
	// (get) Token: 0x06003763 RID: 14179 RVA: 0x0016E950 File Offset: 0x0016CD50
	// (set) Token: 0x06003764 RID: 14180 RVA: 0x0016E958 File Offset: 0x0016CD58
	public override float? MaxNumberOfLastingSeconds
	{
		get
		{
			return this._maxNumberOfLastingSeconds;
		}
		set
		{
			this._maxNumberOfLastingSeconds = value;
		}
	}

	// Token: 0x17000A23 RID: 2595
	// (get) Token: 0x06003765 RID: 14181 RVA: 0x0016E961 File Offset: 0x0016CD61
	// (set) Token: 0x06003766 RID: 14182 RVA: 0x0016E969 File Offset: 0x0016CD69
	public override int? NumberOfLastingTurns
	{
		get
		{
			return this._numberOfLastingTurns;
		}
		set
		{
			this._numberOfLastingTurns = value;
		}
	}

	// Token: 0x17000A24 RID: 2596
	// (get) Token: 0x06003767 RID: 14183 RVA: 0x0016E972 File Offset: 0x0016CD72
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000A25 RID: 2597
	// (get) Token: 0x06003768 RID: 14184 RVA: 0x0016E97A File Offset: 0x0016CD7A
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000A26 RID: 2598
	// (get) Token: 0x06003769 RID: 14185 RVA: 0x0016E982 File Offset: 0x0016CD82
	// (set) Token: 0x0600376A RID: 14186 RVA: 0x0016E98A File Offset: 0x0016CD8A
	public override bool CanBeDispersed
	{
		get
		{
			return this._canBeDispersed;
		}
		set
		{
			this._canBeDispersed = value;
		}
	}

	// Token: 0x17000A27 RID: 2599
	// (get) Token: 0x0600376B RID: 14187 RVA: 0x0016E993 File Offset: 0x0016CD93
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000A28 RID: 2600
	// (get) Token: 0x0600376C RID: 14188 RVA: 0x0016E99B File Offset: 0x0016CD9B
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x0600376D RID: 14189 RVA: 0x0016E9A4 File Offset: 0x0016CDA4
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitReceivesDamage_Single && eventTriggerUnit == listener)
		{
			DamageComponent damage = data as DamageComponent;
			if (damage != null && !damage.IsReflectedDamage && !damage.HasFullyNeutralized() && !damage.CompleteReflected && damage.GetTotalRawDamage() - damage.ReflectedDamage > 0.0)
			{
				damage.CompleteReflected = true;
				damage.ReflectedDamage = damage.GetTotalRawDamage();
				foreach (DamageComponentPotion damageComponentPotion in damage.Potions)
				{
					damageComponentPotion.SetNeutralize(true);
				}
				IEnumerator enumerator2 = this.Triggered(listener).GetEnumerator();
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
				IEnumerator enumerator3 = listener.LooseSkillEffect(this, EffectWearsOffType.Expiration).GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						object _2 = enumerator3.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator3 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				double reflectiveRate = 1.0;
				double af = damage.Target.GetReflectiveRateInBattle();
				if (af >= reflectiveRate)
				{
					reflectiveRate = af;
				}
				ReleaseableDamage reflectDamage = new ReleaseableDamage(new List<BattleDamage>
				{
					new BattleDamage(damage.Dealer, this, new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							DamagePotionValue.CreateRawValuedDamageComponent(damage.Target, damage.Dealer, OutputType.RealDamage, damage.ReflectedDamage * reflectiveRate)
						}, damage.Dealer, damage.Target, false, true)
					})
				}, listener);
				IEnumerator enumerator4 = reflectDamage.Release().GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						object _3 = enumerator4.Current;
						yield return _3;
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator4 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				if (this.EffectSource is AdventureUnitSkill && damage.Dealer.IsAliveInBattle())
				{
					AdventureUnitSkill skill = this.EffectSource as AdventureUnitSkill;
					if (skill.Skill.SkillType == SkillType.EmbracedShield)
					{
						int dispel = this.EffectSource.SourceUnit.SpecialEffects.OfType<EmbracedShieldDispelEnhancementData>().Sum((EmbracedShieldDispelEnhancementData d) => d.NumberOfDispels);
						if (dispel > 0)
						{
							IEnumerator enumerator5 = UnitStyleConfigurationBase.DispelPositiveEffects(damage.Dealer, new int?(dispel)).GetEnumerator();
							try
							{
								while (enumerator5.MoveNext())
								{
									object _4 = enumerator5.Current;
									yield return _4;
								}
							}
							finally
							{
								IDisposable disposable4;
								if ((disposable4 = (enumerator5 as IDisposable)) != null)
								{
									disposable4.Dispose();
								}
							}
						}
						int stun = this.EffectSource.SourceUnit.SpecialEffects.OfType<EmbracedShieldStunEnhancementData>().Sum((EmbracedShieldStunEnhancementData s) => s.StunSeconds);
						if (stun > 0)
						{
							IEnumerator enumerator6 = LockTimeEffect.AddStunSeconds(damage.Dealer, (float)stun, skill, true).GetEnumerator();
							try
							{
								while (enumerator6.MoveNext())
								{
									object _5 = enumerator6.Current;
									yield return _5;
								}
							}
							finally
							{
								IDisposable disposable5;
								if ((disposable5 = (enumerator6 as IDisposable)) != null)
								{
									disposable5.Dispose();
								}
							}
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x17000A29 RID: 2601
	// (get) Token: 0x0600376E RID: 14190 RVA: 0x0016E9E4 File Offset: 0x0016CDE4
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x04002AE5 RID: 10981
	private string _effectSourceIdentityCode;

	// Token: 0x04002AE6 RID: 10982
	private BattleEffectType _battleEffectType = BattleEffectType.ReflectiveShield;

	// Token: 0x04002AE7 RID: 10983
	private int? _numberOfLastingTurns;

	// Token: 0x04002AE8 RID: 10984
	private bool _isThroughEffect;

	// Token: 0x04002AE9 RID: 10985
	private bool _canBeImmuned;

	// Token: 0x04002AEA RID: 10986
	private bool _canBeDispersed = true;

	// Token: 0x04002AEB RID: 10987
	private int? _maxStackableInstances = new int?(15);

	// Token: 0x04002AEC RID: 10988
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002AED RID: 10989
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002AEE RID: 10990
	private IBattleEffectSource _effectSource;

	// Token: 0x02000ED0 RID: 3792
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005F8D RID: 24461 RVA: 0x0016E9EC File Offset: 0x0016CDEC
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005F8E RID: 24462 RVA: 0x0016E9F4 File Offset: 0x0016CDF4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitReceivesDamage_Single || eventTriggerUnit != listener)
				{
					goto IL_64A;
				}
				damage = (data as DamageComponent);
				if (damage == null || damage.IsReflectedDamage || damage.HasFullyNeutralized() || damage.CompleteReflected || damage.GetTotalRawDamage() - damage.ReflectedDamage <= 0.0)
				{
					goto IL_64A;
				}
				damage.CompleteReflected = true;
				damage.ReflectedDamage = damage.GetTotalRawDamage();
				enumerator = damage.Potions.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						DamageComponentPotion damageComponentPotion = enumerator.Current;
						damageComponentPotion.SetNeutralize(true);
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				enumerator2 = this.Triggered(listener).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_1FA;
			case 3u:
				goto IL_379;
			case 4u:
				goto IL_4CC;
			case 5u:
				Block_22:
				try
				{
					switch (num)
					{
					}
					if (enumerator6.MoveNext())
					{
						_5 = enumerator6.Current;
						this.$current = _5;
						if (!this.$disposing)
						{
							this.$PC = 5;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable5 = (enumerator6 as IDisposable)) != null)
						{
							disposable5.Dispose();
						}
					}
				}
				goto IL_64A;
			default:
				return false;
			}
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
			enumerator3 = listener.LooseSkillEffect(this, EffectWearsOffType.Expiration).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_1FA:
				switch (num)
				{
				}
				if (enumerator3.MoveNext())
				{
					_2 = enumerator3.Current;
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
					if ((disposable2 = (enumerator3 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			reflectiveRate = 1.0;
			af = damage.Target.GetReflectiveRateInBattle();
			if (af >= reflectiveRate)
			{
				reflectiveRate = af;
			}
			reflectDamage = new ReleaseableDamage(new List<BattleDamage>
			{
				new BattleDamage(damage.Dealer, this, new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						DamagePotionValue.CreateRawValuedDamageComponent(damage.Target, damage.Dealer, OutputType.RealDamage, damage.ReflectedDamage * reflectiveRate)
					}, damage.Dealer, damage.Target, false, true)
				})
			}, listener);
			enumerator4 = reflectDamage.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_379:
				switch (num)
				{
				}
				if (enumerator4.MoveNext())
				{
					_3 = enumerator4.Current;
					this.$current = _3;
					if (!this.$disposing)
					{
						this.$PC = 3;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable3 = (enumerator4 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			if (!(this.EffectSource is AdventureUnitSkill) || !damage.Dealer.IsAliveInBattle())
			{
				goto IL_64A;
			}
			skill = (this.EffectSource as AdventureUnitSkill);
			if (skill.Skill.SkillType != SkillType.EmbracedShield)
			{
				goto IL_64A;
			}
			dispel = this.EffectSource.SourceUnit.SpecialEffects.OfType<EmbracedShieldDispelEnhancementData>().Sum((EmbracedShieldDispelEnhancementData d) => d.NumberOfDispels);
			if (dispel <= 0)
			{
				goto IL_54E;
			}
			enumerator5 = UnitStyleConfigurationBase.DispelPositiveEffects(damage.Dealer, new int?(dispel)).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_4CC:
				switch (num)
				{
				}
				if (enumerator5.MoveNext())
				{
					_4 = enumerator5.Current;
					this.$current = _4;
					if (!this.$disposing)
					{
						this.$PC = 4;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable4 = (enumerator5 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			IL_54E:
			stun = this.EffectSource.SourceUnit.SpecialEffects.OfType<EmbracedShieldStunEnhancementData>().Sum((EmbracedShieldStunEnhancementData s) => s.StunSeconds);
			if (stun > 0)
			{
				enumerator6 = LockTimeEffect.AddStunSeconds(damage.Dealer, (float)stun, skill, true).GetEnumerator();
				num = 4294967293u;
				goto Block_22;
			}
			IL_64A:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013FA RID: 5114
		// (get) Token: 0x06005F8F RID: 24463 RVA: 0x0016F0A4 File Offset: 0x0016D4A4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013FB RID: 5115
		// (get) Token: 0x06005F90 RID: 24464 RVA: 0x0016F0AC File Offset: 0x0016D4AC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005F91 RID: 24465 RVA: 0x0016F0B4 File Offset: 0x0016D4B4
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
					if ((disposable = (enumerator2 as IDisposable)) != null)
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
					if ((disposable2 = (enumerator3 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator4 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			case 4u:
				try
				{
				}
				finally
				{
					if ((disposable4 = (enumerator5 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			case 5u:
				try
				{
				}
				finally
				{
					if ((disposable5 = (enumerator6 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005F92 RID: 24466 RVA: 0x0016F220 File Offset: 0x0016D620
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005F93 RID: 24467 RVA: 0x0016F227 File Offset: 0x0016D627
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005F94 RID: 24468 RVA: 0x0016F230 File Offset: 0x0016D630
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ReflectiveShieldEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new ReflectiveShieldEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.listener = listener;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.data = data;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x06005F95 RID: 24469 RVA: 0x0016F294 File Offset: 0x0016D694
		private static int <>m__0(EmbracedShieldDispelEnhancementData d)
		{
			return d.NumberOfDispels;
		}

		// Token: 0x06005F96 RID: 24470 RVA: 0x0016F29C File Offset: 0x0016D69C
		private static int <>m__1(EmbracedShieldStunEnhancementData s)
		{
			return s.StunSeconds;
		}

		// Token: 0x0400542E RID: 21550
		internal AdventureEventType eventType;

		// Token: 0x0400542F RID: 21551
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x04005430 RID: 21552
		internal IBattleUnit listener;

		// Token: 0x04005431 RID: 21553
		internal object data;

		// Token: 0x04005432 RID: 21554
		internal DamageComponent <damage>__1;

		// Token: 0x04005433 RID: 21555
		internal List<DamageComponentPotion>.Enumerator $locvar0;

		// Token: 0x04005434 RID: 21556
		internal IEnumerator $locvar1;

		// Token: 0x04005435 RID: 21557
		internal object <_>__2;

		// Token: 0x04005436 RID: 21558
		internal IDisposable $locvar2;

		// Token: 0x04005437 RID: 21559
		internal IEnumerator $locvar3;

		// Token: 0x04005438 RID: 21560
		internal object <_>__3;

		// Token: 0x04005439 RID: 21561
		internal IDisposable $locvar4;

		// Token: 0x0400543A RID: 21562
		internal double <reflectiveRate>__4;

		// Token: 0x0400543B RID: 21563
		internal double <af>__4;

		// Token: 0x0400543C RID: 21564
		internal ReleaseableDamage <reflectDamage>__4;

		// Token: 0x0400543D RID: 21565
		internal IEnumerator $locvar5;

		// Token: 0x0400543E RID: 21566
		internal object <_>__5;

		// Token: 0x0400543F RID: 21567
		internal IDisposable $locvar6;

		// Token: 0x04005440 RID: 21568
		internal AdventureUnitSkill <skill>__6;

		// Token: 0x04005441 RID: 21569
		internal int <dispel>__7;

		// Token: 0x04005442 RID: 21570
		internal IEnumerator $locvar7;

		// Token: 0x04005443 RID: 21571
		internal object <_>__8;

		// Token: 0x04005444 RID: 21572
		internal IDisposable $locvar8;

		// Token: 0x04005445 RID: 21573
		internal int <stun>__7;

		// Token: 0x04005446 RID: 21574
		internal IEnumerator $locvar9;

		// Token: 0x04005447 RID: 21575
		internal object <_>__9;

		// Token: 0x04005448 RID: 21576
		internal IDisposable $locvarA;

		// Token: 0x04005449 RID: 21577
		internal ReflectiveShieldEffect $this;

		// Token: 0x0400544A RID: 21578
		internal object $current;

		// Token: 0x0400544B RID: 21579
		internal bool $disposing;

		// Token: 0x0400544C RID: 21580
		internal int $PC;

		// Token: 0x0400544D RID: 21581
		private static Func<EmbracedShieldDispelEnhancementData, int> <>f__am$cache0;

		// Token: 0x0400544E RID: 21582
		private static Func<EmbracedShieldStunEnhancementData, int> <>f__am$cache1;
	}
}
