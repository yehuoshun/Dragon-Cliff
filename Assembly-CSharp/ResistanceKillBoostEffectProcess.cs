using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000919 RID: 2329
public class ResistanceKillBoostEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x060040A3 RID: 16547 RVA: 0x001A1CC0 File Offset: 0x001A00C0
	public ResistanceKillBoostEffectProcess()
	{
	}

	// Token: 0x17000BF3 RID: 3059
	// (get) Token: 0x060040A4 RID: 16548 RVA: 0x001A1CC8 File Offset: 0x001A00C8
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.ResistanceKillBoost;
		}
	}

	// Token: 0x17000BF4 RID: 3060
	// (get) Token: 0x060040A5 RID: 16549 RVA: 0x001A1CCC File Offset: 0x001A00CC
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

	// Token: 0x060040A6 RID: 16550 RVA: 0x001A1CE8 File Offset: 0x001A00E8
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitKilled && evtData is BattleDamage && specialEffectData is ResistanceKillBoostData)
		{
			BattleDamage damage = evtData as BattleDamage;
			if (damage.Dealer == effectCarrier)
			{
				ResistanceKillBoostData data = specialEffectData as ResistanceKillBoostData;
				string key = "resistancekillboost";
				AttributeModificationEffect existing = triggerUnit.BattleEffects.OfType<AttributeModificationEffect>().FirstOrDefault((AttributeModificationEffect e) => e.EffectSourceIdentityCode == key);
				List<AttributeType> resistances = UnitExtensions.GetAllResistances();
				if (existing == null)
				{
					IEnumerator enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, (from r in resistances
					select new AttributeModifier
					{
						AttributeType = r,
						ModificationType = ModificationType.Multiplication,
						Value = data.BoostRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}).ToList<AttributeModifier>(), key, new int?(1), null, null, false, false, true), false).GetEnumerator();
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
					double value = existing.GetAdditionalModifiers(effectCarrier, effectCarrier.CurrentEncounter).First<AttributeModifier>().Value;
					value += data.BoostRate;
					if (value > data.MaxRate)
					{
						value = data.MaxRate;
					}
					IEnumerator enumerator2 = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, (from r in resistances
					select new AttributeModifier
					{
						AttributeType = r,
						ModificationType = ModificationType.Multiplication,
						Value = value,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}).ToList<AttributeModifier>(), key, new int?(1), null, null, false, false, true), false).GetEnumerator();
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

	// Token: 0x02000FA8 RID: 4008
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600658E RID: 25998 RVA: 0x001A1D29 File Offset: 0x001A0129
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600658F RID: 25999 RVA: 0x001A1D34 File Offset: 0x001A0134
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				if (evtType != AdventureEventType.UnitKilled || !(evtData is BattleDamage) || !(specialEffectData is ResistanceKillBoostData))
				{
					goto IL_39A;
				}
				damage = (evtData as BattleDamage);
				if (damage.Dealer != effectCarrier)
				{
					goto IL_39A;
				}
				ResistanceKillBoostData data = specialEffectData as ResistanceKillBoostData;
				string key = "resistancekillboost";
				existing = triggerUnit.BattleEffects.OfType<AttributeModificationEffect>().FirstOrDefault((AttributeModificationEffect e) => e.EffectSourceIdentityCode == key);
				resistances = UnitExtensions.GetAllResistances();
				if (existing != null)
				{
					double value = existing.GetAdditionalModifiers(effectCarrier, effectCarrier.CurrentEncounter).First<AttributeModifier>().Value;
					value += data.BoostRate;
					if (value > data.MaxRate)
					{
						value = data.MaxRate;
					}
					enumerator2 = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, (from r in resistances
					select new AttributeModifier
					{
						AttributeType = r,
						ModificationType = ModificationType.Multiplication,
						Value = value,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}).ToList<AttributeModifier>(), key, new int?(1), null, null, false, false, true), false).GetEnumerator();
					num = 4294967293u;
					goto Block_9;
				}
				enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, (from r in resistances
				select new AttributeModifier
				{
					AttributeType = r,
					ModificationType = ModificationType.Multiplication,
					Value = data.BoostRate,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				}).ToList<AttributeModifier>(), key, new int?(1), null, null, false, false, true), false).GetEnumerator();
				num = 4294967293u;
				break;
			}
			case 1u:
				break;
			case 2u:
				goto IL_316;
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
			goto IL_39A;
			Block_9:
			try
			{
				IL_316:
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
			IL_39A:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001549 RID: 5449
		// (get) Token: 0x06006590 RID: 26000 RVA: 0x001A2104 File Offset: 0x001A0504
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700154A RID: 5450
		// (get) Token: 0x06006591 RID: 26001 RVA: 0x001A210C File Offset: 0x001A050C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006592 RID: 26002 RVA: 0x001A2114 File Offset: 0x001A0514
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

		// Token: 0x06006593 RID: 26003 RVA: 0x001A21C4 File Offset: 0x001A05C4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006594 RID: 26004 RVA: 0x001A21CB File Offset: 0x001A05CB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006595 RID: 26005 RVA: 0x001A21D4 File Offset: 0x001A05D4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ResistanceKillBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new ResistanceKillBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005E3D RID: 24125
		internal AdventureEventType evtType;

		// Token: 0x04005E3E RID: 24126
		internal object evtData;

		// Token: 0x04005E3F RID: 24127
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005E40 RID: 24128
		internal BattleDamage <damage>__1;

		// Token: 0x04005E41 RID: 24129
		internal IBattleUnit effectCarrier;

		// Token: 0x04005E42 RID: 24130
		internal IBattleUnit triggerUnit;

		// Token: 0x04005E43 RID: 24131
		internal AttributeModificationEffect <existing>__2;

		// Token: 0x04005E44 RID: 24132
		internal List<AttributeType> <resistances>__2;

		// Token: 0x04005E45 RID: 24133
		internal IEnumerator $locvar0;

		// Token: 0x04005E46 RID: 24134
		internal object <_>__3;

		// Token: 0x04005E47 RID: 24135
		internal IDisposable $locvar1;

		// Token: 0x04005E48 RID: 24136
		internal IEnumerator $locvar2;

		// Token: 0x04005E49 RID: 24137
		internal object <_>__5;

		// Token: 0x04005E4A RID: 24138
		internal IDisposable $locvar3;

		// Token: 0x04005E4B RID: 24139
		internal object $current;

		// Token: 0x04005E4C RID: 24140
		internal bool $disposing;

		// Token: 0x04005E4D RID: 24141
		internal int $PC;

		// Token: 0x04005E4E RID: 24142
		private ResistanceKillBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar4;

		// Token: 0x04005E4F RID: 24143
		private ResistanceKillBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey2 $locvar5;

		// Token: 0x02000FA9 RID: 4009
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x06006596 RID: 26006 RVA: 0x001A2238 File Offset: 0x001A0638
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x06006597 RID: 26007 RVA: 0x001A2240 File Offset: 0x001A0640
			internal bool <>m__0(AttributeModificationEffect e)
			{
				return e.EffectSourceIdentityCode == this.key;
			}

			// Token: 0x06006598 RID: 26008 RVA: 0x001A2254 File Offset: 0x001A0654
			internal AttributeModifier <>m__1(AttributeType r)
			{
				return new AttributeModifier
				{
					AttributeType = r,
					ModificationType = ModificationType.Multiplication,
					Value = this.data.BoostRate,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				};
			}

			// Token: 0x04005E50 RID: 24144
			internal string key;

			// Token: 0x04005E51 RID: 24145
			internal ResistanceKillBoostData data;

			// Token: 0x04005E52 RID: 24146
			internal ResistanceKillBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;
		}

		// Token: 0x02000FAA RID: 4010
		private sealed class <AsActiveUnitProcess>c__AnonStorey2
		{
			// Token: 0x06006599 RID: 26009 RVA: 0x001A2299 File Offset: 0x001A0699
			public <AsActiveUnitProcess>c__AnonStorey2()
			{
			}

			// Token: 0x0600659A RID: 26010 RVA: 0x001A22A4 File Offset: 0x001A06A4
			internal AttributeModifier <>m__0(AttributeType r)
			{
				return new AttributeModifier
				{
					AttributeType = r,
					ModificationType = ModificationType.Multiplication,
					Value = this.value,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				};
			}

			// Token: 0x04005E53 RID: 24147
			internal double value;

			// Token: 0x04005E54 RID: 24148
			internal ResistanceKillBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;

			// Token: 0x04005E55 RID: 24149
			internal ResistanceKillBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 <>f__ref$1;
		}
	}
}
