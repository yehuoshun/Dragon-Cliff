using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000935 RID: 2357
public class TauntResistanceBoostEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004128 RID: 16680 RVA: 0x001A842C File Offset: 0x001A682C
	public TauntResistanceBoostEffectProcess()
	{
	}

	// Token: 0x17000C29 RID: 3113
	// (get) Token: 0x06004129 RID: 16681 RVA: 0x001A8467 File Offset: 0x001A6867
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000C2A RID: 3114
	// (get) Token: 0x0600412A RID: 16682 RVA: 0x001A846F File Offset: 0x001A686F
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return this._correspondingEvents;
		}
	}

	// Token: 0x0600412B RID: 16683 RVA: 0x001A8478 File Offset: 0x001A6878
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.BattleEffectResisted && effectCarrier == triggerUnit && (effectCarrier.GetUnitClassStyle() == UnitClassStyle.PhysicalKiller || effectCarrier.GetUnitClassStyle() == UnitClassStyle.SpellKiller) && evtData is TauntEffect && specialEffectData is TauntResistanceBoostData)
		{
			TauntResistanceBoostData data = specialEffectData as TauntResistanceBoostData;
			IEnumerator enumerator = triggerUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = triggerUnit.GetOutputAttributeType(),
					ModificationType = ModificationType.Multiplication,
					Key = string.Empty,
					Value = data.OutputBoostRate,
					AttributeModifierType = AttributeModifierType.Skill
				},
				new AttributeModifier
				{
					AttributeType = AttributeType.Agility,
					ModificationType = ModificationType.Multiplication,
					Key = string.Empty,
					Value = data.AgilityBoostRate,
					AttributeModifierType = AttributeModifierType.Skill
				}
			}, TauntResistanceBoostEffectProcess.EffectKey, new int?(1), null, null, false, true, false), false).GetEnumerator();
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
			IEnumerator enumerator2 = UnitStyleConfigurationBase.PushTargetProgress(effectCarrier, effectCarrier, data.PushRate).GetEnumerator();
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
		if (evtType == AdventureEventType.UnitPostCastSkill && effectCarrier == triggerUnit && (effectCarrier.GetUnitClassStyle() == UnitClassStyle.PhysicalKiller || effectCarrier.GetUnitClassStyle() == UnitClassStyle.SpellKiller) && specialEffectData is TauntResistanceBoostData)
		{
			List<BattleEffectBase> toremove = (from ef in effectCarrier.BattleEffects
			where ef.EffectSourceIdentityCode == TauntResistanceBoostEffectProcess.EffectKey
			select ef).ToList<BattleEffectBase>();
			foreach (BattleEffectBase battleEffectBase in toremove)
			{
				IEnumerator enumerator4 = effectCarrier.LooseSkillEffect(battleEffectBase, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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
			}
		}
		yield break;
	}

	// Token: 0x0600412C RID: 16684 RVA: 0x001A84B9 File Offset: 0x001A68B9
	// Note: this type is marked as 'beforefieldinit'.
	static TauntResistanceBoostEffectProcess()
	{
	}

	// Token: 0x040030E3 RID: 12515
	public static string EffectKey = "TauntResistanceBoostEffectUnique";

	// Token: 0x040030E4 RID: 12516
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.TauntResistanceBoost;

	// Token: 0x040030E5 RID: 12517
	private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
	{
		AdventureEventType.BattleEffectResisted,
		AdventureEventType.UnitPostCastSkill
	};

	// Token: 0x02000FD5 RID: 4053
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060066B0 RID: 26288 RVA: 0x001A84C5 File Offset: 0x001A68C5
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060066B1 RID: 26289 RVA: 0x001A84D0 File Offset: 0x001A68D0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.BattleEffectResisted || effectCarrier != triggerUnit || (effectCarrier.GetUnitClassStyle() != UnitClassStyle.PhysicalKiller && effectCarrier.GetUnitClassStyle() != UnitClassStyle.SpellKiller) || !(evtData is TauntEffect) || !(specialEffectData is TauntResistanceBoostData))
				{
					goto IL_2A2;
				}
				data = (specialEffectData as TauntResistanceBoostData);
				enumerator = triggerUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = triggerUnit.GetOutputAttributeType(),
						ModificationType = ModificationType.Multiplication,
						Key = string.Empty,
						Value = data.OutputBoostRate,
						AttributeModifierType = AttributeModifierType.Skill
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.Agility,
						ModificationType = ModificationType.Multiplication,
						Key = string.Empty,
						Value = data.AgilityBoostRate,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, TauntResistanceBoostEffectProcess.EffectKey, new int?(1), null, null, false, true, false), false).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_21E;
			case 3u:
				Block_14:
				try
				{
					switch (num)
					{
					case 3u:
						Block_28:
						try
						{
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
						break;
					}
					if (enumerator3.MoveNext())
					{
						battleEffectBase = enumerator3.Current;
						enumerator4 = effectCarrier.LooseSkillEffect(battleEffectBase, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
						num = 4294967293u;
						goto Block_28;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator3).Dispose();
					}
				}
				goto IL_42F;
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
			enumerator2 = UnitStyleConfigurationBase.PushTargetProgress(effectCarrier, effectCarrier, data.PushRate).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_21E:
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
			IL_2A2:
			if (evtType == AdventureEventType.UnitPostCastSkill && effectCarrier == triggerUnit && (effectCarrier.GetUnitClassStyle() == UnitClassStyle.PhysicalKiller || effectCarrier.GetUnitClassStyle() == UnitClassStyle.SpellKiller) && specialEffectData is TauntResistanceBoostData)
			{
				toremove = (from ef in effectCarrier.BattleEffects
				where ef.EffectSourceIdentityCode == TauntResistanceBoostEffectProcess.EffectKey
				select ef).ToList<BattleEffectBase>();
				enumerator3 = toremove.GetEnumerator();
				num = 4294967293u;
				goto Block_14;
			}
			IL_42F:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700158B RID: 5515
		// (get) Token: 0x060066B2 RID: 26290 RVA: 0x001A894C File Offset: 0x001A6D4C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700158C RID: 5516
		// (get) Token: 0x060066B3 RID: 26291 RVA: 0x001A8954 File Offset: 0x001A6D54
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060066B4 RID: 26292 RVA: 0x001A895C File Offset: 0x001A6D5C
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
			case 3u:
				try
				{
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
				}
				finally
				{
					((IDisposable)enumerator3).Dispose();
				}
				break;
			}
		}

		// Token: 0x060066B5 RID: 26293 RVA: 0x001A8A6C File Offset: 0x001A6E6C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060066B6 RID: 26294 RVA: 0x001A8A73 File Offset: 0x001A6E73
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060066B7 RID: 26295 RVA: 0x001A8A7C File Offset: 0x001A6E7C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			TauntResistanceBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new TauntResistanceBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x060066B8 RID: 26296 RVA: 0x001A8AE0 File Offset: 0x001A6EE0
		private static bool <>m__0(BattleEffectBase ef)
		{
			return ef.EffectSourceIdentityCode == TauntResistanceBoostEffectProcess.EffectKey;
		}

		// Token: 0x04005FE4 RID: 24548
		internal AdventureEventType evtType;

		// Token: 0x04005FE5 RID: 24549
		internal IBattleUnit effectCarrier;

		// Token: 0x04005FE6 RID: 24550
		internal IBattleUnit triggerUnit;

		// Token: 0x04005FE7 RID: 24551
		internal object evtData;

		// Token: 0x04005FE8 RID: 24552
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005FE9 RID: 24553
		internal TauntResistanceBoostData <data>__1;

		// Token: 0x04005FEA RID: 24554
		internal IEnumerator $locvar0;

		// Token: 0x04005FEB RID: 24555
		internal object <_>__2;

		// Token: 0x04005FEC RID: 24556
		internal IDisposable $locvar1;

		// Token: 0x04005FED RID: 24557
		internal IEnumerator $locvar2;

		// Token: 0x04005FEE RID: 24558
		internal object <_>__3;

		// Token: 0x04005FEF RID: 24559
		internal IDisposable $locvar3;

		// Token: 0x04005FF0 RID: 24560
		internal List<BattleEffectBase> <toremove>__4;

		// Token: 0x04005FF1 RID: 24561
		internal List<BattleEffectBase>.Enumerator $locvar4;

		// Token: 0x04005FF2 RID: 24562
		internal BattleEffectBase <battleEffectBase>__5;

		// Token: 0x04005FF3 RID: 24563
		internal IEnumerator $locvar5;

		// Token: 0x04005FF4 RID: 24564
		internal object <_>__6;

		// Token: 0x04005FF5 RID: 24565
		internal IDisposable $locvar6;

		// Token: 0x04005FF6 RID: 24566
		internal object $current;

		// Token: 0x04005FF7 RID: 24567
		internal bool $disposing;

		// Token: 0x04005FF8 RID: 24568
		internal int $PC;

		// Token: 0x04005FF9 RID: 24569
		private static Func<BattleEffectBase, bool> <>f__am$cache0;
	}
}
