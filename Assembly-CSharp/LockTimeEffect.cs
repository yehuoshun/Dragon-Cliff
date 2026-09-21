using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000763 RID: 1891
public class LockTimeEffect : BattleEffectBase
{
	// Token: 0x060036F5 RID: 14069 RVA: 0x0016B478 File Offset: 0x00169878
	private LockTimeEffect()
	{
	}

	// Token: 0x060036F6 RID: 14070 RVA: 0x0016B488 File Offset: 0x00169888
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		RestrictionOfTimeData restrictionOfTimeData = wearer.SpecialEffects.OfType<RestrictionOfTimeData>().FirstOrDefault<RestrictionOfTimeData>();
		List<AttributeModifier> list = new List<AttributeModifier>();
		if (restrictionOfTimeData != null)
		{
			list.Add(new AttributeModifier
			{
				AttributeType = AttributeType.DodgeRateAdjustment,
				ModificationType = ModificationType.Addition,
				Value = restrictionOfTimeData.DodgeRateBoost,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			});
		}
		if (base.SourceUnit.GetUnitType() == UnitClass.SnowMaiden && base.SourceUnit.SpecialEffects.OfType<SnowMaideEnhancementData>().Any<SnowMaideEnhancementData>())
		{
			list.Add(new AttributeModifier
			{
				AttributeType = AttributeType.DodgeRateAdjustment,
				ModificationType = ModificationType.Multiplication,
				Value = -0.5,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			});
		}
		return list;
	}

	// Token: 0x060036F7 RID: 14071 RVA: 0x0016B560 File Offset: 0x00169960
	public static IEnumerable AddStunSeconds(IBattleUnit target, float seconds, IBattleEffectSource effectSource, bool canAccumalate)
	{
		string key = "uniquestun";
		LockTimeEffect existing = target.BattleEffects.OfType<LockTimeEffect>().FirstOrDefault((LockTimeEffect e) => e.EffectSourceIdentityCode == key);
		if (existing == null)
		{
			Description description = BattleEffectType.Stun.GetDescription();
			description.Details1 = description.Details1.Replace("{seconds}", seconds.FloatToString());
			LockTimeEffect effect = new LockTimeEffect
			{
				_effectSource = effectSource,
				_effectSourceIdentityCode = key,
				_battleEffectType = BattleEffectType.Stun,
				MaxNumberOfLastingSeconds = new float?(seconds),
				_numberOfLastingTurns = null,
				TurnEventsCollected = new List<AdventureEventType>(),
				Description = description,
				_maxStackableInstances = new int?(1),
				_isThroughEffect = false,
				CanBeDispersed = true,
				_canBeImmuned = true,
				_effectCarrier = target
			};
			IEnumerator enumerator = target.ApplySkillEffect(effect, false).GetEnumerator();
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
		else if (!effectSource.SourceUnit.EffectApplySucceeded(target))
		{
			IEnumerator enumerator2 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(target, AdventureEventType.BattleEffectResisted, new LockTimeEffect
			{
				_effectSource = effectSource,
				_effectSourceIdentityCode = key,
				_battleEffectType = BattleEffectType.Stun,
				MaxNumberOfLastingSeconds = new float?(seconds),
				_numberOfLastingTurns = null,
				TurnEventsCollected = new List<AdventureEventType>(),
				Description = BattleEffectType.Stun.GetDescription(),
				_maxStackableInstances = new int?(1),
				_isThroughEffect = false,
				CanBeDispersed = true,
				_canBeImmuned = true,
				_effectCarrier = target
			})).GetEnumerator();
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
		else
		{
			if (canAccumalate)
			{
				double effectTimeRatio = effectSource.SourceUnit.GetEffectTimeRatio(target);
				if (target != effectSource)
				{
					seconds = Convert.ToSingle((double)seconds * effectTimeRatio);
				}
				LockTimeEffect lockTimeEffect = existing;
				float? maxNumberOfLastingSeconds = lockTimeEffect._maxNumberOfLastingSeconds;
				lockTimeEffect._maxNumberOfLastingSeconds = ((maxNumberOfLastingSeconds == null) ? null : new float?(maxNumberOfLastingSeconds.GetValueOrDefault() + seconds));
			}
			else
			{
				double effectTimeRatio2 = effectSource.SourceUnit.GetEffectTimeRatio(target);
				if (target != effectSource)
				{
					seconds = Convert.ToSingle((double)seconds * effectTimeRatio2);
				}
				float num = existing.MaxNumberOfLastingSeconds.GetValueOrDefault() - existing.Timer;
				if (num < seconds)
				{
					existing.Timer = 0f;
					existing.MaxNumberOfLastingSeconds = new float?(seconds);
				}
			}
			Description description2 = BattleEffectType.Stun.GetDescription();
			description2.Details1 = description2.Details1.Replace("{seconds}", existing.MaxNumberOfLastingSeconds.ToString());
			existing._effectSource = effectSource;
			existing.Description = description2;
		}
		yield break;
	}

	// Token: 0x060036F8 RID: 14072 RVA: 0x0016B5A0 File Offset: 0x001699A0
	public static IEnumerable AddFearSeconds(IBattleUnit target, float seconds, IBattleEffectSource effectSource, bool canAccumalate)
	{
		string key = "uniquestun_nondispel";
		LockTimeEffect existing = target.BattleEffects.OfType<LockTimeEffect>().FirstOrDefault((LockTimeEffect e) => e.EffectSourceIdentityCode == key);
		if (existing == null)
		{
			Description description = BattleEffectType.Fear.GetDescription();
			description.Details1 = description.Details1.Replace("{seconds}", seconds.FloatToString());
			LockTimeEffect effect = new LockTimeEffect
			{
				_effectSource = effectSource,
				_effectSourceIdentityCode = key,
				_battleEffectType = BattleEffectType.Fear,
				MaxNumberOfLastingSeconds = new float?(seconds),
				_numberOfLastingTurns = null,
				TurnEventsCollected = new List<AdventureEventType>(),
				Description = description,
				_maxStackableInstances = new int?(1),
				_isThroughEffect = false,
				CanBeDispersed = false,
				_canBeImmuned = false,
				_effectCarrier = target
			};
			IEnumerator enumerator = target.ApplySkillEffect(effect, false).GetEnumerator();
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
		else
		{
			if (canAccumalate)
			{
				double effectTimeRatio = effectSource.SourceUnit.GetEffectTimeRatio(target);
				if (target != effectSource)
				{
					seconds = Convert.ToSingle((double)seconds * effectTimeRatio);
				}
				LockTimeEffect lockTimeEffect = existing;
				float? maxNumberOfLastingSeconds = lockTimeEffect._maxNumberOfLastingSeconds;
				lockTimeEffect._maxNumberOfLastingSeconds = ((maxNumberOfLastingSeconds == null) ? null : new float?(maxNumberOfLastingSeconds.GetValueOrDefault() + seconds));
			}
			else
			{
				double effectTimeRatio2 = effectSource.SourceUnit.GetEffectTimeRatio(target);
				if (target != effectSource)
				{
					seconds = Convert.ToSingle((double)seconds * effectTimeRatio2);
				}
				float num = existing.MaxNumberOfLastingSeconds.GetValueOrDefault() - existing.Timer;
				if (num < seconds)
				{
					existing.Timer = 0f;
					existing.MaxNumberOfLastingSeconds = new float?(seconds);
				}
			}
			Description description2 = BattleEffectType.Fear.GetDescription();
			description2.Details1 = description2.Details1.Replace("{seconds}", existing.MaxNumberOfLastingSeconds.ToString());
			existing._effectSource = effectSource;
			existing.Description = description2;
		}
		yield break;
	}

	// Token: 0x060036F9 RID: 14073 RVA: 0x0016B5E0 File Offset: 0x001699E0
	public static IEnumerable AddFrozenSeconds(IBattleUnit target, float seconds, IBattleEffectSource effectSource, bool canAccumalate)
	{
		string key = "uniquefrozen";
		LockTimeEffect existing = target.BattleEffects.OfType<LockTimeEffect>().FirstOrDefault((LockTimeEffect e) => e.EffectSourceIdentityCode == key);
		if (existing == null)
		{
			Description description = BattleEffectType.Frozen.GetDescription();
			description.Details1 = description.Details1.Replace("{seconds}", seconds.FloatToString());
			LockTimeEffect effect = new LockTimeEffect
			{
				_effectSource = effectSource,
				_effectSourceIdentityCode = key,
				_battleEffectType = BattleEffectType.Frozen,
				MaxNumberOfLastingSeconds = new float?(seconds),
				_numberOfLastingTurns = null,
				TurnEventsCollected = new List<AdventureEventType>(),
				Description = description,
				_maxStackableInstances = new int?(1),
				_isThroughEffect = false,
				CanBeDispersed = true,
				_canBeImmuned = true,
				_effectCarrier = target
			};
			IEnumerator enumerator = target.ApplySkillEffect(effect, false).GetEnumerator();
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
		else if (!effectSource.SourceUnit.EffectApplySucceeded(target))
		{
			IEnumerator enumerator2 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(target, AdventureEventType.BattleEffectResisted, new LockTimeEffect
			{
				_effectSource = effectSource,
				_effectSourceIdentityCode = key,
				_battleEffectType = BattleEffectType.Stun,
				MaxNumberOfLastingSeconds = new float?(seconds),
				_numberOfLastingTurns = null,
				TurnEventsCollected = new List<AdventureEventType>(),
				Description = BattleEffectType.Stun.GetDescription(),
				_maxStackableInstances = new int?(1),
				_isThroughEffect = false,
				CanBeDispersed = true,
				_canBeImmuned = true,
				_effectCarrier = target
			})).GetEnumerator();
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
		else
		{
			if (canAccumalate)
			{
				double effectTimeRatio = effectSource.SourceUnit.GetEffectTimeRatio(target);
				if (target != effectSource)
				{
					seconds = Convert.ToSingle((double)seconds * effectTimeRatio);
				}
				LockTimeEffect lockTimeEffect = existing;
				float? maxNumberOfLastingSeconds = lockTimeEffect._maxNumberOfLastingSeconds;
				lockTimeEffect._maxNumberOfLastingSeconds = ((maxNumberOfLastingSeconds == null) ? null : new float?(maxNumberOfLastingSeconds.GetValueOrDefault() + seconds));
			}
			else
			{
				double effectTimeRatio2 = effectSource.SourceUnit.GetEffectTimeRatio(target);
				if (target != effectSource)
				{
					seconds = Convert.ToSingle((double)seconds * effectTimeRatio2);
				}
				float num = existing.MaxNumberOfLastingSeconds.GetValueOrDefault() - existing.Timer;
				if (num < seconds)
				{
					existing.Timer = 0f;
					existing.MaxNumberOfLastingSeconds = new float?(seconds);
				}
			}
			Description description2 = BattleEffectType.Frozen.GetDescription();
			existing._effectSource = effectSource;
			description2.Details1 = description2.Details1.Replace("{seconds}", existing.MaxNumberOfLastingSeconds.ToString());
			existing.Description = description2;
		}
		yield break;
	}

	// Token: 0x060036FA RID: 14074 RVA: 0x0016B620 File Offset: 0x00169A20
	public static IEnumerable AddSoulLockSeconds(IBattleUnit target, float seconds, IBattleEffectSource effectSource)
	{
		string key = "uniquesoullock_nondispel";
		LockTimeEffect existing = target.BattleEffects.OfType<LockTimeEffect>().FirstOrDefault((LockTimeEffect e) => e.EffectSourceIdentityCode == key);
		if (existing == null)
		{
			Description description = BattleEffectType.Fear.GetDescription();
			description.Details1 = description.Details1.Replace("{seconds}", seconds.FloatToString());
			LockTimeEffect effect = new LockTimeEffect
			{
				_effectSource = effectSource,
				_effectSourceIdentityCode = key,
				_battleEffectType = BattleEffectType.Fear,
				MaxNumberOfLastingSeconds = new float?(seconds),
				_numberOfLastingTurns = null,
				TurnEventsCollected = new List<AdventureEventType>(),
				Description = description,
				_maxStackableInstances = new int?(1),
				_isThroughEffect = false,
				CanBeDispersed = false,
				_canBeImmuned = false,
				_effectCarrier = target
			};
			IEnumerator enumerator = target.ApplySkillEffect(effect, true).GetEnumerator();
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
		else
		{
			existing.Timer = 0f;
			existing.MaxNumberOfLastingSeconds = new float?(seconds);
			Description description2 = BattleEffectType.Fear.GetDescription();
			description2.Details1 = description2.Details1.Replace("{seconds}", existing.MaxNumberOfLastingSeconds.ToString());
			existing._effectSource = effectSource;
			existing.Description = description2;
		}
		yield break;
	}

	// Token: 0x060036FB RID: 14075 RVA: 0x0016B651 File Offset: 0x00169A51
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x170009E4 RID: 2532
	// (get) Token: 0x060036FC RID: 14076 RVA: 0x0016B658 File Offset: 0x00169A58
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x170009E5 RID: 2533
	// (get) Token: 0x060036FD RID: 14077 RVA: 0x0016B660 File Offset: 0x00169A60
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x170009E6 RID: 2534
	// (get) Token: 0x060036FE RID: 14078 RVA: 0x0016B668 File Offset: 0x00169A68
	// (set) Token: 0x060036FF RID: 14079 RVA: 0x0016B670 File Offset: 0x00169A70
	public override float? MaxNumberOfLastingSeconds
	{
		get
		{
			return this._maxNumberOfLastingSeconds;
		}
		set
		{
			this._maxNumberOfLastingSeconds = value;
			Description description = this._battleEffectType.GetDescription();
			description.Details1 = description.Details1.Replace("{seconds}", value.GetValueOrDefault().FloatToString());
			base.Description = description;
		}
	}

	// Token: 0x170009E7 RID: 2535
	// (get) Token: 0x06003700 RID: 14080 RVA: 0x0016B6B9 File Offset: 0x00169AB9
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x170009E8 RID: 2536
	// (get) Token: 0x06003701 RID: 14081 RVA: 0x0016B6C1 File Offset: 0x00169AC1
	// (set) Token: 0x06003702 RID: 14082 RVA: 0x0016B6C9 File Offset: 0x00169AC9
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

	// Token: 0x170009E9 RID: 2537
	// (get) Token: 0x06003703 RID: 14083 RVA: 0x0016B6D2 File Offset: 0x00169AD2
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x170009EA RID: 2538
	// (get) Token: 0x06003704 RID: 14084 RVA: 0x0016B6DA File Offset: 0x00169ADA
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x170009EB RID: 2539
	// (get) Token: 0x06003705 RID: 14085 RVA: 0x0016B6E2 File Offset: 0x00169AE2
	// (set) Token: 0x06003706 RID: 14086 RVA: 0x0016B6EA File Offset: 0x00169AEA
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

	// Token: 0x170009EC RID: 2540
	// (get) Token: 0x06003707 RID: 14087 RVA: 0x0016B6F3 File Offset: 0x00169AF3
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x170009ED RID: 2541
	// (get) Token: 0x06003708 RID: 14088 RVA: 0x0016B6FB File Offset: 0x00169AFB
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x06003709 RID: 14089 RVA: 0x0016B704 File Offset: 0x00169B04
	// Note: this type is marked as 'beforefieldinit'.
	static LockTimeEffect()
	{
	}

	// Token: 0x04002A9D RID: 10909
	public static string ConfusionEffectCode = "CONFUSIONEFFECTKEY";

	// Token: 0x04002A9E RID: 10910
	public static string FrozenHeartEffectCode = "FROZENHEARTEFFECTKEY";

	// Token: 0x04002A9F RID: 10911
	public static string FrozenEffectCode = "FROZENEFFECTUNIQUEKEY";

	// Token: 0x04002AA0 RID: 10912
	public static string StunEffectCode = "STUNEFFECTUNIQUEKEY";

	// Token: 0x04002AA1 RID: 10913
	public static string SwarmNightmareCode = "SWARMNIGHTMAREKEY";

	// Token: 0x04002AA2 RID: 10914
	public static string SwarmSelfStunCode = "SWARMSELFSTUNKEY";

	// Token: 0x04002AA3 RID: 10915
	public static string DragonShockCode = "DRAGONSHOCKKEY";

	// Token: 0x04002AA4 RID: 10916
	private string _effectSourceIdentityCode;

	// Token: 0x04002AA5 RID: 10917
	private BattleEffectType _battleEffectType;

	// Token: 0x04002AA6 RID: 10918
	private int? _numberOfLastingTurns;

	// Token: 0x04002AA7 RID: 10919
	private bool _isThroughEffect;

	// Token: 0x04002AA8 RID: 10920
	private bool _canBeImmuned;

	// Token: 0x04002AA9 RID: 10921
	private bool _canBeDispersed;

	// Token: 0x04002AAA RID: 10922
	private int? _maxStackableInstances;

	// Token: 0x04002AAB RID: 10923
	private BattleEffectNature _battleEffectNatureForWearer = BattleEffectNature.Negative;

	// Token: 0x04002AAC RID: 10924
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002AAD RID: 10925
	private IBattleEffectSource _effectSource;

	// Token: 0x04002AAE RID: 10926
	private IBattleUnit _effectCarrier;

	// Token: 0x02000EBF RID: 3775
	[CompilerGenerated]
	private sealed class <AddStunSeconds>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005F29 RID: 24361 RVA: 0x0016B757 File Offset: 0x00169B57
		[DebuggerHidden]
		public <AddStunSeconds>c__Iterator0()
		{
		}

		// Token: 0x06005F2A RID: 24362 RVA: 0x0016B760 File Offset: 0x00169B60
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				string key = "uniquestun";
				existing = target.BattleEffects.OfType<LockTimeEffect>().FirstOrDefault((LockTimeEffect e) => e.EffectSourceIdentityCode == key);
				if (existing == null)
				{
					description = BattleEffectType.Stun.GetDescription();
					description.Details1 = description.Details1.Replace("{seconds}", seconds.FloatToString());
					effect = new LockTimeEffect
					{
						_effectSource = effectSource,
						_effectSourceIdentityCode = key,
						_battleEffectType = BattleEffectType.Stun,
						MaxNumberOfLastingSeconds = new float?(seconds),
						_numberOfLastingTurns = null,
						TurnEventsCollected = new List<AdventureEventType>(),
						Description = description,
						_maxStackableInstances = new int?(1),
						_isThroughEffect = false,
						CanBeDispersed = true,
						_canBeImmuned = true,
						_effectCarrier = target
					};
					enumerator = target.ApplySkillEffect(effect, false).GetEnumerator();
					num = 4294967293u;
				}
				else
				{
					if (!effectSource.SourceUnit.EffectApplySucceeded(target))
					{
						enumerator2 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(target, AdventureEventType.BattleEffectResisted, new LockTimeEffect
						{
							_effectSource = effectSource,
							_effectSourceIdentityCode = key,
							_battleEffectType = BattleEffectType.Stun,
							MaxNumberOfLastingSeconds = new float?(seconds),
							_numberOfLastingTurns = null,
							TurnEventsCollected = new List<AdventureEventType>(),
							Description = BattleEffectType.Stun.GetDescription(),
							_maxStackableInstances = new int?(1),
							_isThroughEffect = false,
							CanBeDispersed = true,
							_canBeImmuned = true,
							_effectCarrier = target
						})).GetEnumerator();
						num = 4294967293u;
						goto Block_5;
					}
					if (canAccumalate)
					{
						double effectTimeRatio = effectSource.SourceUnit.GetEffectTimeRatio(target);
						if (target != effectSource)
						{
							seconds = Convert.ToSingle((double)seconds * effectTimeRatio);
						}
						LockTimeEffect lockTimeEffect = existing;
						float? maxNumberOfLastingSeconds = lockTimeEffect._maxNumberOfLastingSeconds;
						lockTimeEffect._maxNumberOfLastingSeconds = ((maxNumberOfLastingSeconds == null) ? null : new float?(maxNumberOfLastingSeconds.GetValueOrDefault() + seconds));
					}
					else
					{
						double effectTimeRatio2 = effectSource.SourceUnit.GetEffectTimeRatio(target);
						if (target != effectSource)
						{
							seconds = Convert.ToSingle((double)seconds * effectTimeRatio2);
						}
						float num2 = existing.MaxNumberOfLastingSeconds.GetValueOrDefault() - existing.Timer;
						if (num2 < seconds)
						{
							existing.Timer = 0f;
							existing.MaxNumberOfLastingSeconds = new float?(seconds);
						}
					}
					Description description2 = BattleEffectType.Stun.GetDescription();
					description2.Details1 = description2.Details1.Replace("{seconds}", existing.MaxNumberOfLastingSeconds.ToString());
					existing._effectSource = effectSource;
					existing.Description = description2;
					goto IL_4CE;
				}
				break;
			}
			case 1u:
				break;
			case 2u:
				goto IL_2CD;
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
			goto IL_4CE;
			Block_5:
			try
			{
				IL_2CD:
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
			IL_4CE:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013E4 RID: 5092
		// (get) Token: 0x06005F2B RID: 24363 RVA: 0x0016BC64 File Offset: 0x0016A064
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013E5 RID: 5093
		// (get) Token: 0x06005F2C RID: 24364 RVA: 0x0016BC6C File Offset: 0x0016A06C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005F2D RID: 24365 RVA: 0x0016BC74 File Offset: 0x0016A074
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

		// Token: 0x06005F2E RID: 24366 RVA: 0x0016BD24 File Offset: 0x0016A124
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005F2F RID: 24367 RVA: 0x0016BD2B File Offset: 0x0016A12B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005F30 RID: 24368 RVA: 0x0016BD34 File Offset: 0x0016A134
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			LockTimeEffect.<AddStunSeconds>c__Iterator0 <AddStunSeconds>c__Iterator = new LockTimeEffect.<AddStunSeconds>c__Iterator0();
			<AddStunSeconds>c__Iterator.target = target;
			<AddStunSeconds>c__Iterator.seconds = seconds;
			<AddStunSeconds>c__Iterator.effectSource = effectSource;
			<AddStunSeconds>c__Iterator.canAccumalate = canAccumalate;
			return <AddStunSeconds>c__Iterator;
		}

		// Token: 0x0400538F RID: 21391
		internal IBattleUnit target;

		// Token: 0x04005390 RID: 21392
		internal LockTimeEffect <existing>__0;

		// Token: 0x04005391 RID: 21393
		internal Description <description>__1;

		// Token: 0x04005392 RID: 21394
		internal float seconds;

		// Token: 0x04005393 RID: 21395
		internal IBattleEffectSource effectSource;

		// Token: 0x04005394 RID: 21396
		internal LockTimeEffect <effect>__1;

		// Token: 0x04005395 RID: 21397
		internal IEnumerator $locvar0;

		// Token: 0x04005396 RID: 21398
		internal object <_>__2;

		// Token: 0x04005397 RID: 21399
		internal IDisposable $locvar1;

		// Token: 0x04005398 RID: 21400
		internal IEnumerator $locvar2;

		// Token: 0x04005399 RID: 21401
		internal object <_>__3;

		// Token: 0x0400539A RID: 21402
		internal IDisposable $locvar3;

		// Token: 0x0400539B RID: 21403
		internal bool canAccumalate;

		// Token: 0x0400539C RID: 21404
		internal object $current;

		// Token: 0x0400539D RID: 21405
		internal bool $disposing;

		// Token: 0x0400539E RID: 21406
		internal float <$>seconds;

		// Token: 0x0400539F RID: 21407
		internal int $PC;

		// Token: 0x040053A0 RID: 21408
		private LockTimeEffect.<AddStunSeconds>c__Iterator0.<AddStunSeconds>c__AnonStorey4 $locvar4;

		// Token: 0x02000EC3 RID: 3779
		private sealed class <AddStunSeconds>c__AnonStorey4
		{
			// Token: 0x06005F49 RID: 24393 RVA: 0x0016BD8C File Offset: 0x0016A18C
			public <AddStunSeconds>c__AnonStorey4()
			{
			}

			// Token: 0x06005F4A RID: 24394 RVA: 0x0016BD94 File Offset: 0x0016A194
			internal bool <>m__0(LockTimeEffect e)
			{
				return e.EffectSourceIdentityCode == this.key;
			}

			// Token: 0x040053CF RID: 21455
			internal string key;

			// Token: 0x040053D0 RID: 21456
			internal LockTimeEffect.<AddStunSeconds>c__Iterator0 <>f__ref$0;
		}
	}

	// Token: 0x02000EC0 RID: 3776
	[CompilerGenerated]
	private sealed class <AddFearSeconds>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005F31 RID: 24369 RVA: 0x0016BDA7 File Offset: 0x0016A1A7
		[DebuggerHidden]
		public <AddFearSeconds>c__Iterator1()
		{
		}

		// Token: 0x06005F32 RID: 24370 RVA: 0x0016BDB0 File Offset: 0x0016A1B0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				string key = "uniquestun_nondispel";
				existing = target.BattleEffects.OfType<LockTimeEffect>().FirstOrDefault((LockTimeEffect e) => e.EffectSourceIdentityCode == key);
				if (existing != null)
				{
					if (canAccumalate)
					{
						double effectTimeRatio = effectSource.SourceUnit.GetEffectTimeRatio(target);
						if (target != effectSource)
						{
							seconds = Convert.ToSingle((double)seconds * effectTimeRatio);
						}
						LockTimeEffect lockTimeEffect = existing;
						float? maxNumberOfLastingSeconds = lockTimeEffect._maxNumberOfLastingSeconds;
						lockTimeEffect._maxNumberOfLastingSeconds = ((maxNumberOfLastingSeconds == null) ? null : new float?(maxNumberOfLastingSeconds.GetValueOrDefault() + seconds));
					}
					else
					{
						double effectTimeRatio2 = effectSource.SourceUnit.GetEffectTimeRatio(target);
						if (target != effectSource)
						{
							seconds = Convert.ToSingle((double)seconds * effectTimeRatio2);
						}
						float num2 = existing.MaxNumberOfLastingSeconds.GetValueOrDefault() - existing.Timer;
						if (num2 < seconds)
						{
							existing.Timer = 0f;
							existing.MaxNumberOfLastingSeconds = new float?(seconds);
						}
					}
					Description description2 = BattleEffectType.Fear.GetDescription();
					description2.Details1 = description2.Details1.Replace("{seconds}", existing.MaxNumberOfLastingSeconds.ToString());
					existing._effectSource = effectSource;
					existing.Description = description2;
					goto IL_370;
				}
				description = BattleEffectType.Fear.GetDescription();
				description.Details1 = description.Details1.Replace("{seconds}", seconds.FloatToString());
				effect = new LockTimeEffect
				{
					_effectSource = effectSource,
					_effectSourceIdentityCode = key,
					_battleEffectType = BattleEffectType.Fear,
					MaxNumberOfLastingSeconds = new float?(seconds),
					_numberOfLastingTurns = null,
					TurnEventsCollected = new List<AdventureEventType>(),
					Description = description,
					_maxStackableInstances = new int?(1),
					_isThroughEffect = false,
					CanBeDispersed = false,
					_canBeImmuned = false,
					_effectCarrier = target
				};
				enumerator = target.ApplySkillEffect(effect, false).GetEnumerator();
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
			IL_370:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013E6 RID: 5094
		// (get) Token: 0x06005F33 RID: 24371 RVA: 0x0016C148 File Offset: 0x0016A548
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013E7 RID: 5095
		// (get) Token: 0x06005F34 RID: 24372 RVA: 0x0016C150 File Offset: 0x0016A550
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005F35 RID: 24373 RVA: 0x0016C158 File Offset: 0x0016A558
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

		// Token: 0x06005F36 RID: 24374 RVA: 0x0016C1C8 File Offset: 0x0016A5C8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005F37 RID: 24375 RVA: 0x0016C1CF File Offset: 0x0016A5CF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005F38 RID: 24376 RVA: 0x0016C1D8 File Offset: 0x0016A5D8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			LockTimeEffect.<AddFearSeconds>c__Iterator1 <AddFearSeconds>c__Iterator = new LockTimeEffect.<AddFearSeconds>c__Iterator1();
			<AddFearSeconds>c__Iterator.target = target;
			<AddFearSeconds>c__Iterator.seconds = seconds;
			<AddFearSeconds>c__Iterator.effectSource = effectSource;
			<AddFearSeconds>c__Iterator.canAccumalate = canAccumalate;
			return <AddFearSeconds>c__Iterator;
		}

		// Token: 0x040053A1 RID: 21409
		internal IBattleUnit target;

		// Token: 0x040053A2 RID: 21410
		internal LockTimeEffect <existing>__0;

		// Token: 0x040053A3 RID: 21411
		internal Description <description>__1;

		// Token: 0x040053A4 RID: 21412
		internal float seconds;

		// Token: 0x040053A5 RID: 21413
		internal IBattleEffectSource effectSource;

		// Token: 0x040053A6 RID: 21414
		internal LockTimeEffect <effect>__1;

		// Token: 0x040053A7 RID: 21415
		internal IEnumerator $locvar0;

		// Token: 0x040053A8 RID: 21416
		internal object <_>__2;

		// Token: 0x040053A9 RID: 21417
		internal IDisposable $locvar1;

		// Token: 0x040053AA RID: 21418
		internal bool canAccumalate;

		// Token: 0x040053AB RID: 21419
		internal object $current;

		// Token: 0x040053AC RID: 21420
		internal bool $disposing;

		// Token: 0x040053AD RID: 21421
		internal float <$>seconds;

		// Token: 0x040053AE RID: 21422
		internal int $PC;

		// Token: 0x040053AF RID: 21423
		private LockTimeEffect.<AddFearSeconds>c__Iterator1.<AddFearSeconds>c__AnonStorey5 $locvar2;

		// Token: 0x02000EC4 RID: 3780
		private sealed class <AddFearSeconds>c__AnonStorey5
		{
			// Token: 0x06005F4B RID: 24395 RVA: 0x0016C230 File Offset: 0x0016A630
			public <AddFearSeconds>c__AnonStorey5()
			{
			}

			// Token: 0x06005F4C RID: 24396 RVA: 0x0016C238 File Offset: 0x0016A638
			internal bool <>m__0(LockTimeEffect e)
			{
				return e.EffectSourceIdentityCode == this.key;
			}

			// Token: 0x040053D1 RID: 21457
			internal string key;

			// Token: 0x040053D2 RID: 21458
			internal LockTimeEffect.<AddFearSeconds>c__Iterator1 <>f__ref$1;
		}
	}

	// Token: 0x02000EC1 RID: 3777
	[CompilerGenerated]
	private sealed class <AddFrozenSeconds>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005F39 RID: 24377 RVA: 0x0016C24B File Offset: 0x0016A64B
		[DebuggerHidden]
		public <AddFrozenSeconds>c__Iterator2()
		{
		}

		// Token: 0x06005F3A RID: 24378 RVA: 0x0016C254 File Offset: 0x0016A654
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				string key = "uniquefrozen";
				existing = target.BattleEffects.OfType<LockTimeEffect>().FirstOrDefault((LockTimeEffect e) => e.EffectSourceIdentityCode == key);
				if (existing == null)
				{
					description = BattleEffectType.Frozen.GetDescription();
					description.Details1 = description.Details1.Replace("{seconds}", seconds.FloatToString());
					effect = new LockTimeEffect
					{
						_effectSource = effectSource,
						_effectSourceIdentityCode = key,
						_battleEffectType = BattleEffectType.Frozen,
						MaxNumberOfLastingSeconds = new float?(seconds),
						_numberOfLastingTurns = null,
						TurnEventsCollected = new List<AdventureEventType>(),
						Description = description,
						_maxStackableInstances = new int?(1),
						_isThroughEffect = false,
						CanBeDispersed = true,
						_canBeImmuned = true,
						_effectCarrier = target
					};
					enumerator = target.ApplySkillEffect(effect, false).GetEnumerator();
					num = 4294967293u;
				}
				else
				{
					if (!effectSource.SourceUnit.EffectApplySucceeded(target))
					{
						enumerator2 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(target, AdventureEventType.BattleEffectResisted, new LockTimeEffect
						{
							_effectSource = effectSource,
							_effectSourceIdentityCode = key,
							_battleEffectType = BattleEffectType.Stun,
							MaxNumberOfLastingSeconds = new float?(seconds),
							_numberOfLastingTurns = null,
							TurnEventsCollected = new List<AdventureEventType>(),
							Description = BattleEffectType.Stun.GetDescription(),
							_maxStackableInstances = new int?(1),
							_isThroughEffect = false,
							CanBeDispersed = true,
							_canBeImmuned = true,
							_effectCarrier = target
						})).GetEnumerator();
						num = 4294967293u;
						goto Block_5;
					}
					if (canAccumalate)
					{
						double effectTimeRatio = effectSource.SourceUnit.GetEffectTimeRatio(target);
						if (target != effectSource)
						{
							seconds = Convert.ToSingle((double)seconds * effectTimeRatio);
						}
						LockTimeEffect lockTimeEffect = existing;
						float? maxNumberOfLastingSeconds = lockTimeEffect._maxNumberOfLastingSeconds;
						lockTimeEffect._maxNumberOfLastingSeconds = ((maxNumberOfLastingSeconds == null) ? null : new float?(maxNumberOfLastingSeconds.GetValueOrDefault() + seconds));
					}
					else
					{
						double effectTimeRatio2 = effectSource.SourceUnit.GetEffectTimeRatio(target);
						if (target != effectSource)
						{
							seconds = Convert.ToSingle((double)seconds * effectTimeRatio2);
						}
						float num2 = existing.MaxNumberOfLastingSeconds.GetValueOrDefault() - existing.Timer;
						if (num2 < seconds)
						{
							existing.Timer = 0f;
							existing.MaxNumberOfLastingSeconds = new float?(seconds);
						}
					}
					Description description2 = BattleEffectType.Frozen.GetDescription();
					existing._effectSource = effectSource;
					description2.Details1 = description2.Details1.Replace("{seconds}", existing.MaxNumberOfLastingSeconds.ToString());
					existing.Description = description2;
					goto IL_4CE;
				}
				break;
			}
			case 1u:
				break;
			case 2u:
				goto IL_2CD;
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
			goto IL_4CE;
			Block_5:
			try
			{
				IL_2CD:
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
			IL_4CE:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013E8 RID: 5096
		// (get) Token: 0x06005F3B RID: 24379 RVA: 0x0016C758 File Offset: 0x0016AB58
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013E9 RID: 5097
		// (get) Token: 0x06005F3C RID: 24380 RVA: 0x0016C760 File Offset: 0x0016AB60
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005F3D RID: 24381 RVA: 0x0016C768 File Offset: 0x0016AB68
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

		// Token: 0x06005F3E RID: 24382 RVA: 0x0016C818 File Offset: 0x0016AC18
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005F3F RID: 24383 RVA: 0x0016C81F File Offset: 0x0016AC1F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005F40 RID: 24384 RVA: 0x0016C828 File Offset: 0x0016AC28
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			LockTimeEffect.<AddFrozenSeconds>c__Iterator2 <AddFrozenSeconds>c__Iterator = new LockTimeEffect.<AddFrozenSeconds>c__Iterator2();
			<AddFrozenSeconds>c__Iterator.target = target;
			<AddFrozenSeconds>c__Iterator.seconds = seconds;
			<AddFrozenSeconds>c__Iterator.effectSource = effectSource;
			<AddFrozenSeconds>c__Iterator.canAccumalate = canAccumalate;
			return <AddFrozenSeconds>c__Iterator;
		}

		// Token: 0x040053B0 RID: 21424
		internal IBattleUnit target;

		// Token: 0x040053B1 RID: 21425
		internal LockTimeEffect <existing>__0;

		// Token: 0x040053B2 RID: 21426
		internal Description <description>__1;

		// Token: 0x040053B3 RID: 21427
		internal float seconds;

		// Token: 0x040053B4 RID: 21428
		internal IBattleEffectSource effectSource;

		// Token: 0x040053B5 RID: 21429
		internal LockTimeEffect <effect>__1;

		// Token: 0x040053B6 RID: 21430
		internal IEnumerator $locvar0;

		// Token: 0x040053B7 RID: 21431
		internal object <_>__2;

		// Token: 0x040053B8 RID: 21432
		internal IDisposable $locvar1;

		// Token: 0x040053B9 RID: 21433
		internal IEnumerator $locvar2;

		// Token: 0x040053BA RID: 21434
		internal object <_>__3;

		// Token: 0x040053BB RID: 21435
		internal IDisposable $locvar3;

		// Token: 0x040053BC RID: 21436
		internal bool canAccumalate;

		// Token: 0x040053BD RID: 21437
		internal object $current;

		// Token: 0x040053BE RID: 21438
		internal bool $disposing;

		// Token: 0x040053BF RID: 21439
		internal float <$>seconds;

		// Token: 0x040053C0 RID: 21440
		internal int $PC;

		// Token: 0x040053C1 RID: 21441
		private LockTimeEffect.<AddFrozenSeconds>c__Iterator2.<AddFrozenSeconds>c__AnonStorey6 $locvar4;

		// Token: 0x02000EC5 RID: 3781
		private sealed class <AddFrozenSeconds>c__AnonStorey6
		{
			// Token: 0x06005F4D RID: 24397 RVA: 0x0016C880 File Offset: 0x0016AC80
			public <AddFrozenSeconds>c__AnonStorey6()
			{
			}

			// Token: 0x06005F4E RID: 24398 RVA: 0x0016C888 File Offset: 0x0016AC88
			internal bool <>m__0(LockTimeEffect e)
			{
				return e.EffectSourceIdentityCode == this.key;
			}

			// Token: 0x040053D3 RID: 21459
			internal string key;

			// Token: 0x040053D4 RID: 21460
			internal LockTimeEffect.<AddFrozenSeconds>c__Iterator2 <>f__ref$2;
		}
	}

	// Token: 0x02000EC2 RID: 3778
	[CompilerGenerated]
	private sealed class <AddSoulLockSeconds>c__Iterator3 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005F41 RID: 24385 RVA: 0x0016C89B File Offset: 0x0016AC9B
		[DebuggerHidden]
		public <AddSoulLockSeconds>c__Iterator3()
		{
		}

		// Token: 0x06005F42 RID: 24386 RVA: 0x0016C8A4 File Offset: 0x0016ACA4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				string key = "uniquesoullock_nondispel";
				existing = target.BattleEffects.OfType<LockTimeEffect>().FirstOrDefault((LockTimeEffect e) => e.EffectSourceIdentityCode == key);
				if (existing != null)
				{
					existing.Timer = 0f;
					existing.MaxNumberOfLastingSeconds = new float?(seconds);
					Description description2 = BattleEffectType.Fear.GetDescription();
					description2.Details1 = description2.Details1.Replace("{seconds}", existing.MaxNumberOfLastingSeconds.ToString());
					existing._effectSource = effectSource;
					existing.Description = description2;
					goto IL_277;
				}
				description = BattleEffectType.Fear.GetDescription();
				description.Details1 = description.Details1.Replace("{seconds}", seconds.FloatToString());
				effect = new LockTimeEffect
				{
					_effectSource = effectSource,
					_effectSourceIdentityCode = key,
					_battleEffectType = BattleEffectType.Fear,
					MaxNumberOfLastingSeconds = new float?(seconds),
					_numberOfLastingTurns = null,
					TurnEventsCollected = new List<AdventureEventType>(),
					Description = description,
					_maxStackableInstances = new int?(1),
					_isThroughEffect = false,
					CanBeDispersed = false,
					_canBeImmuned = false,
					_effectCarrier = target
				};
				enumerator = target.ApplySkillEffect(effect, true).GetEnumerator();
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
			IL_277:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013EA RID: 5098
		// (get) Token: 0x06005F43 RID: 24387 RVA: 0x0016CB44 File Offset: 0x0016AF44
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013EB RID: 5099
		// (get) Token: 0x06005F44 RID: 24388 RVA: 0x0016CB4C File Offset: 0x0016AF4C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005F45 RID: 24389 RVA: 0x0016CB54 File Offset: 0x0016AF54
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

		// Token: 0x06005F46 RID: 24390 RVA: 0x0016CBC4 File Offset: 0x0016AFC4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005F47 RID: 24391 RVA: 0x0016CBCB File Offset: 0x0016AFCB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005F48 RID: 24392 RVA: 0x0016CBD4 File Offset: 0x0016AFD4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			LockTimeEffect.<AddSoulLockSeconds>c__Iterator3 <AddSoulLockSeconds>c__Iterator = new LockTimeEffect.<AddSoulLockSeconds>c__Iterator3();
			<AddSoulLockSeconds>c__Iterator.target = target;
			<AddSoulLockSeconds>c__Iterator.seconds = seconds;
			<AddSoulLockSeconds>c__Iterator.effectSource = effectSource;
			return <AddSoulLockSeconds>c__Iterator;
		}

		// Token: 0x040053C2 RID: 21442
		internal IBattleUnit target;

		// Token: 0x040053C3 RID: 21443
		internal LockTimeEffect <existing>__0;

		// Token: 0x040053C4 RID: 21444
		internal Description <description>__1;

		// Token: 0x040053C5 RID: 21445
		internal float seconds;

		// Token: 0x040053C6 RID: 21446
		internal IBattleEffectSource effectSource;

		// Token: 0x040053C7 RID: 21447
		internal LockTimeEffect <effect>__1;

		// Token: 0x040053C8 RID: 21448
		internal IEnumerator $locvar0;

		// Token: 0x040053C9 RID: 21449
		internal object <_>__2;

		// Token: 0x040053CA RID: 21450
		internal IDisposable $locvar1;

		// Token: 0x040053CB RID: 21451
		internal object $current;

		// Token: 0x040053CC RID: 21452
		internal bool $disposing;

		// Token: 0x040053CD RID: 21453
		internal int $PC;

		// Token: 0x040053CE RID: 21454
		private LockTimeEffect.<AddSoulLockSeconds>c__Iterator3.<AddSoulLockSeconds>c__AnonStorey7 $locvar2;

		// Token: 0x02000EC6 RID: 3782
		private sealed class <AddSoulLockSeconds>c__AnonStorey7
		{
			// Token: 0x06005F4F RID: 24399 RVA: 0x0016CC20 File Offset: 0x0016B020
			public <AddSoulLockSeconds>c__AnonStorey7()
			{
			}

			// Token: 0x06005F50 RID: 24400 RVA: 0x0016CC28 File Offset: 0x0016B028
			internal bool <>m__0(LockTimeEffect e)
			{
				return e.EffectSourceIdentityCode == this.key;
			}

			// Token: 0x040053D5 RID: 21461
			internal string key;

			// Token: 0x040053D6 RID: 21462
			internal LockTimeEffect.<AddSoulLockSeconds>c__Iterator3 <>f__ref$3;
		}
	}
}
