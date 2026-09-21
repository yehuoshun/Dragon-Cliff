using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000754 RID: 1876
public class FireSeedEffect : BattleEffectBase
{
	// Token: 0x06003618 RID: 13848 RVA: 0x001676F0 File Offset: 0x00165AF0
	private FireSeedEffect(IBattleUnit sourceUnit, double rawDamage)
	{
		this._effectSourceIdentityCode = FireSeedEffect.SingularSourceIdentityCode;
		this._effectSource = sourceUnit;
		base.TurnEventsCollected = new List<AdventureEventType>();
		base.Description = BattleEffectType.FireSeed.GetDescription();
		base.Description.Details1 = base.Description.Details1.Replace("{damage}", rawDamage.DoubleToString());
		this._rawDamage = rawDamage;
		this._numberOfLastingTurns = null;
		this._maxNumberOfLastingSeconds = new float?(6f);
		this.CanBeDispersed = true;
	}

	// Token: 0x06003619 RID: 13849 RVA: 0x00167780 File Offset: 0x00165B80
	public static IEnumerable AddFireSeed(IBattleUnit target, double damageValue, IBattleUnit dealer)
	{
		FireSeedEffect existingFireSeed = target.BattleEffects.OfType<FireSeedEffect>().FirstOrDefault<FireSeedEffect>();
		if (existingFireSeed != null)
		{
			existingFireSeed.Timer = 0f;
			existingFireSeed.TurnEventsCollected = new List<AdventureEventType>();
			double effectTimeRatio = dealer.GetEffectTimeRatio(target);
			double num = 6.0 * effectTimeRatio;
			float? maxNumberOfLastingSeconds = existingFireSeed._maxNumberOfLastingSeconds;
			if (num > ((maxNumberOfLastingSeconds == null) ? null : new double?((double)maxNumberOfLastingSeconds.Value)))
			{
				existingFireSeed._maxNumberOfLastingSeconds = new float?(Convert.ToSingle(num));
			}
			double num2 = dealer.GetOutputCapacity(AttributeRetrievalLevel.Gear).Value * 15.0;
			double rawDamage = existingFireSeed._rawDamage;
			double num3 = num2 - rawDamage;
			if (damageValue > num3)
			{
				damageValue = num3;
			}
			if (damageValue > 0.0)
			{
				existingFireSeed.AddDamage(damageValue);
			}
		}
		else
		{
			IEnumerator enumerator = target.ApplySkillEffect(new FireSeedEffect(dealer, damageValue), false).GetEnumerator();
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

	// Token: 0x0600361A RID: 13850 RVA: 0x001677B8 File Offset: 0x00165BB8
	public void AddDamage(double damage)
	{
		this._rawDamage += damage;
		base.Description.Details1 = this.BattleEffectType.GetDescription().Details1.Replace("{damage}", this._rawDamage.DoubleToString());
	}

	// Token: 0x1700095E RID: 2398
	// (get) Token: 0x0600361B RID: 13851 RVA: 0x001677F8 File Offset: 0x00165BF8
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x1700095F RID: 2399
	// (get) Token: 0x0600361C RID: 13852 RVA: 0x00167800 File Offset: 0x00165C00
	public double DamgeValue
	{
		get
		{
			return this._rawDamage;
		}
	}

	// Token: 0x17000960 RID: 2400
	// (get) Token: 0x0600361D RID: 13853 RVA: 0x00167808 File Offset: 0x00165C08
	// (set) Token: 0x0600361E RID: 13854 RVA: 0x00167810 File Offset: 0x00165C10
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

	// Token: 0x0600361F RID: 13855 RVA: 0x00167819 File Offset: 0x00165C19
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return new List<AttributeModifier>();
	}

	// Token: 0x17000961 RID: 2401
	// (get) Token: 0x06003620 RID: 13856 RVA: 0x00167820 File Offset: 0x00165C20
	public override bool IsThroughEffect
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000962 RID: 2402
	// (get) Token: 0x06003621 RID: 13857 RVA: 0x00167823 File Offset: 0x00165C23
	public override bool CanBeImmuned
	{
		get
		{
			return true;
		}
	}

	// Token: 0x17000963 RID: 2403
	// (get) Token: 0x06003622 RID: 13858 RVA: 0x00167826 File Offset: 0x00165C26
	public override int? MaxStackableInstances
	{
		get
		{
			return new int?(1);
		}
	}

	// Token: 0x17000964 RID: 2404
	// (get) Token: 0x06003623 RID: 13859 RVA: 0x0016782E File Offset: 0x00165C2E
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return BattleEffectNature.Negative;
		}
	}

	// Token: 0x17000965 RID: 2405
	// (get) Token: 0x06003624 RID: 13860 RVA: 0x00167831 File Offset: 0x00165C31
	// (set) Token: 0x06003625 RID: 13861 RVA: 0x00167839 File Offset: 0x00165C39
	public sealed override bool CanBeDispersed
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

	// Token: 0x06003626 RID: 13862 RVA: 0x00167842 File Offset: 0x00165C42
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000966 RID: 2406
	// (get) Token: 0x06003627 RID: 13863 RVA: 0x00167849 File Offset: 0x00165C49
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000967 RID: 2407
	// (get) Token: 0x06003628 RID: 13864 RVA: 0x00167851 File Offset: 0x00165C51
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return BattleEffectType.FireSeed;
		}
	}

	// Token: 0x17000968 RID: 2408
	// (get) Token: 0x06003629 RID: 13865 RVA: 0x00167854 File Offset: 0x00165C54
	// (set) Token: 0x0600362A RID: 13866 RVA: 0x0016785C File Offset: 0x00165C5C
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

	// Token: 0x0600362B RID: 13867 RVA: 0x00167865 File Offset: 0x00165C65
	// Note: this type is marked as 'beforefieldinit'.
	static FireSeedEffect()
	{
	}

	// Token: 0x04002A1C RID: 10780
	public static string SingularSourceIdentityCode = "FireSeedSingleSource";

	// Token: 0x04002A1D RID: 10781
	private string _effectSourceIdentityCode;

	// Token: 0x04002A1E RID: 10782
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002A1F RID: 10783
	private IBattleEffectSource _effectSource;

	// Token: 0x04002A20 RID: 10784
	private double _rawDamage;

	// Token: 0x04002A21 RID: 10785
	private int? _numberOfLastingTurns;

	// Token: 0x04002A22 RID: 10786
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;

	// Token: 0x02000EB6 RID: 3766
	[CompilerGenerated]
	private sealed class <AddFireSeed>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005EDD RID: 24285 RVA: 0x00167871 File Offset: 0x00165C71
		[DebuggerHidden]
		public <AddFireSeed>c__Iterator0()
		{
		}

		// Token: 0x06005EDE RID: 24286 RVA: 0x0016787C File Offset: 0x00165C7C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				existingFireSeed = target.BattleEffects.OfType<FireSeedEffect>().FirstOrDefault<FireSeedEffect>();
				if (existingFireSeed != null)
				{
					existingFireSeed.Timer = 0f;
					existingFireSeed.TurnEventsCollected = new List<AdventureEventType>();
					double effectTimeRatio = dealer.GetEffectTimeRatio(target);
					double num2 = 6.0 * effectTimeRatio;
					float? maxNumberOfLastingSeconds = existingFireSeed._maxNumberOfLastingSeconds;
					if (num2 > ((maxNumberOfLastingSeconds == null) ? null : new double?((double)maxNumberOfLastingSeconds.Value)))
					{
						existingFireSeed._maxNumberOfLastingSeconds = new float?(Convert.ToSingle(num2));
					}
					double num3 = dealer.GetOutputCapacity(AttributeRetrievalLevel.Gear).Value * 15.0;
					double rawDamage = existingFireSeed._rawDamage;
					double num4 = num3 - rawDamage;
					if (damageValue > num4)
					{
						damageValue = num4;
					}
					if (damageValue > 0.0)
					{
						existingFireSeed.AddDamage(damageValue);
					}
					goto IL_211;
				}
				enumerator = target.ApplySkillEffect(new FireSeedEffect(dealer, damageValue), false).GetEnumerator();
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
			IL_211:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013D2 RID: 5074
		// (get) Token: 0x06005EDF RID: 24287 RVA: 0x00167AB4 File Offset: 0x00165EB4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013D3 RID: 5075
		// (get) Token: 0x06005EE0 RID: 24288 RVA: 0x00167ABC File Offset: 0x00165EBC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005EE1 RID: 24289 RVA: 0x00167AC4 File Offset: 0x00165EC4
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

		// Token: 0x06005EE2 RID: 24290 RVA: 0x00167B34 File Offset: 0x00165F34
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005EE3 RID: 24291 RVA: 0x00167B3B File Offset: 0x00165F3B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005EE4 RID: 24292 RVA: 0x00167B44 File Offset: 0x00165F44
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			FireSeedEffect.<AddFireSeed>c__Iterator0 <AddFireSeed>c__Iterator = new FireSeedEffect.<AddFireSeed>c__Iterator0();
			<AddFireSeed>c__Iterator.target = target;
			<AddFireSeed>c__Iterator.dealer = dealer;
			<AddFireSeed>c__Iterator.damageValue = damageValue;
			return <AddFireSeed>c__Iterator;
		}

		// Token: 0x040052E5 RID: 21221
		internal IBattleUnit target;

		// Token: 0x040052E6 RID: 21222
		internal FireSeedEffect <existingFireSeed>__0;

		// Token: 0x040052E7 RID: 21223
		internal IBattleUnit dealer;

		// Token: 0x040052E8 RID: 21224
		internal double damageValue;

		// Token: 0x040052E9 RID: 21225
		internal IEnumerator $locvar0;

		// Token: 0x040052EA RID: 21226
		internal object <_>__1;

		// Token: 0x040052EB RID: 21227
		internal IDisposable $locvar1;

		// Token: 0x040052EC RID: 21228
		internal object $current;

		// Token: 0x040052ED RID: 21229
		internal bool $disposing;

		// Token: 0x040052EE RID: 21230
		internal double <$>damageValue;

		// Token: 0x040052EF RID: 21231
		internal int $PC;
	}
}
