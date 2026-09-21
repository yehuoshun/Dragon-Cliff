using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008CB RID: 2251
public class DemonSkullEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F4D RID: 16205 RVA: 0x0018E38C File Offset: 0x0018C78C
	public DemonSkullEffectProcess()
	{
	}

	// Token: 0x17000B58 RID: 2904
	// (get) Token: 0x06003F4E RID: 16206 RVA: 0x0018E39C File Offset: 0x0018C79C
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B59 RID: 2905
	// (get) Token: 0x06003F4F RID: 16207 RVA: 0x0018E3A4 File Offset: 0x0018C7A4
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.TurnSetupCompleted,
				AdventureEventType.UnitPostReceivesDamage_Single,
				AdventureEventType.DamagePerSecondTrigger,
				AdventureEventType.UnitPreKilled
			};
		}
	}

	// Token: 0x06003F50 RID: 16208 RVA: 0x0018E3D8 File Offset: 0x0018C7D8
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.TurnSetupCompleted && triggerUnit == effectCarrier && specialEffectData is DemonSkullData)
		{
			DemonSkullData data = specialEffectData as DemonSkullData;
			data.SoulCharged = 0.0;
			data.HaveRevived = false;
			IEnumerator enumerator = effectCarrier.DoTurn().GetEnumerator();
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
		if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && triggerUnit == effectCarrier)
		{
			DamageComponent damage = evtData as DamageComponent;
			if (damage != null && damage.IsDirectDamage && !damage.IsMissed)
			{
				DemonSkullData data2 = specialEffectData as DemonSkullData;
				if (data2 != null && (double)UnityEngine.Random.value <= data2.BleedingChanceOnHit)
				{
					IEnumerator enumerator2 = DamageOverTimeEffect.AddDamageOverSecond(damage.Dealer, effectCarrier, effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * data2.BleedingDamageRate, (int)data2.RebirthBleedingLastingSeconds, data2.BleedingDamageType).GetEnumerator();
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
		if (evtType == AdventureEventType.DamagePerSecondTrigger && evtData is List<BattleEffectBase>)
		{
			List<DamageOverTimeEffect> dots = (evtData as List<BattleEffectBase>).OfType<DamageOverTimeEffect>().ToList<DamageOverTimeEffect>();
			foreach (DamageOverTimeEffect dot in dots)
			{
				if (dot.BattleEffectType == BattleEffectType.DamagePerSecond && dot.EffectSource.SourceUnit == effectCarrier)
				{
					DemonSkullData data3 = specialEffectData as DemonSkullData;
					if (data3 != null)
					{
						data3.SoulCharged += data3.SoulChargeRatePerBleeding;
						if (data3.SoulCharged >= 1.0)
						{
							data3.SoulCharged -= 1.0;
							List<AttributeModifier> modifiers = new List<AttributeModifier>
							{
								new AttributeModifier
								{
									AttributeType = AttributeType.Agility,
									ModificationType = ModificationType.Addition,
									Value = data3.ChargedAgilityBoostValue,
									AttributeModifierType = AttributeModifierType.Skill,
									Key = string.Empty
								}
							};
							if (data3.HaveRevived)
							{
								modifiers.Add(new AttributeModifier
								{
									AttributeType = AttributeType.Strength,
									ModificationType = ModificationType.Addition,
									Value = data3.RebirthStrengthBoostValue,
									AttributeModifierType = AttributeModifierType.Skill,
									Key = string.Empty
								});
							}
							IEnumerator enumerator4 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(effectCarrier, AdventureEventType.DemonSoulFullyCharged, effectCarrier)).GetEnumerator();
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
							IEnumerator enumerator5 = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, modifiers, "DEMONSKULL", null, null, null, false, false, false), false).GetEnumerator();
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
					}
				}
			}
		}
		if (evtType == AdventureEventType.UnitPreKilled && triggerUnit == effectCarrier && effectCarrier.HealthPoints <= 0.0)
		{
			DemonSkullData data4 = specialEffectData as DemonSkullData;
			if (data4 != null && !data4.HaveRevived)
			{
				ReleaseableHeal releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(effectCarrier, effectCarrier, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = triggerUnit.GetMaxLife(AttributeRetrievalLevel.Skill) * data4.ReviveRate,
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
						}
					}, true)
				}, effectCarrier);
				data4.HaveRevived = true;
				IEnumerator enumerator6 = releaseableHeal.Release().GetEnumerator();
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
				List<IBattleUnit> targetUnits = effectCarrier.GetLiveEnemyTargets(false, true);
				foreach (IBattleUnit targetUnit in targetUnits)
				{
					for (int i = 0; i < data4.NumberOfBleedingsOnRebirth; i++)
					{
						IEnumerator enumerator8 = DamageOverTimeEffect.AddDamageOverSecond(targetUnit, effectCarrier, effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * data4.RebirthBleedingDamageRate, (int)data4.RebirthBleedingLastingSeconds, data4.RebirthBleedingDamageType).GetEnumerator();
						try
						{
							while (enumerator8.MoveNext())
							{
								object _6 = enumerator8.Current;
								yield return _6;
							}
						}
						finally
						{
							IDisposable disposable6;
							if ((disposable6 = (enumerator8 as IDisposable)) != null)
							{
								disposable6.Dispose();
							}
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x04002F7A RID: 12154
	private readonly SpecialEffectType _correspondingEffectType = SpecialEffectType.DemonSkullEffect;

	// Token: 0x02000F4A RID: 3914
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060062E5 RID: 25317 RVA: 0x0018E419 File Offset: 0x0018C819
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060062E6 RID: 25318 RVA: 0x0018E424 File Offset: 0x0018C824
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.TurnSetupCompleted || triggerUnit != effectCarrier || !(specialEffectData is DemonSkullData))
				{
					goto IL_131;
				}
				data = (specialEffectData as DemonSkullData);
				data.SoulCharged = 0.0;
				data.HaveRevived = false;
				enumerator = effectCarrier.DoTurn().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				Block_13:
				try
				{
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
				goto IL_297;
			case 3u:
			case 4u:
				Block_16:
				try
				{
					switch (num)
					{
					case 3u:
						Block_42:
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
						enumerator5 = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, modifiers, "DEMONSKULL", null, null, null, false, false, false), false).GetEnumerator();
						num = 4294967293u;
						goto Block_43;
					case 4u:
						goto IL_54D;
					}
					IL_5CF:
					while (enumerator3.MoveNext())
					{
						dot = enumerator3.Current;
						if (dot.BattleEffectType == BattleEffectType.DamagePerSecond && dot.EffectSource.SourceUnit == effectCarrier)
						{
							data3 = (specialEffectData as DemonSkullData);
							if (data3 != null)
							{
								data3.SoulCharged += data3.SoulChargeRatePerBleeding;
								if (data3.SoulCharged >= 1.0)
								{
									data3.SoulCharged -= 1.0;
									modifiers = new List<AttributeModifier>
									{
										new AttributeModifier
										{
											AttributeType = AttributeType.Agility,
											ModificationType = ModificationType.Addition,
											Value = data3.ChargedAgilityBoostValue,
											AttributeModifierType = AttributeModifierType.Skill,
											Key = string.Empty
										}
									};
									if (data3.HaveRevived)
									{
										modifiers.Add(new AttributeModifier
										{
											AttributeType = AttributeType.Strength,
											ModificationType = ModificationType.Addition,
											Value = data3.RebirthStrengthBoostValue,
											AttributeModifierType = AttributeModifierType.Skill,
											Key = string.Empty
										});
									}
									enumerator4 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(effectCarrier, AdventureEventType.DemonSoulFullyCharged, effectCarrier)).GetEnumerator();
									num = 4294967293u;
									goto Block_42;
								}
							}
						}
					}
					goto IL_5FA;
					Block_43:
					try
					{
						IL_54D:
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
					goto IL_5CF;
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator3).Dispose();
					}
				}
				goto IL_5FA;
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
				targetUnits = effectCarrier.GetLiveEnemyTargets(false, true);
				enumerator7 = targetUnits.GetEnumerator();
				num = 4294967293u;
				goto Block_23;
			case 6u:
				goto IL_7A7;
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
			IL_131:
			if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && triggerUnit == effectCarrier)
			{
				damage = (evtData as DamageComponent);
				if (damage != null && damage.IsDirectDamage && !damage.IsMissed)
				{
					data2 = (specialEffectData as DemonSkullData);
					if (data2 != null && (double)UnityEngine.Random.value <= data2.BleedingChanceOnHit)
					{
						enumerator2 = DamageOverTimeEffect.AddDamageOverSecond(damage.Dealer, effectCarrier, effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * data2.BleedingDamageRate, (int)data2.RebirthBleedingLastingSeconds, data2.BleedingDamageType).GetEnumerator();
						num = 4294967293u;
						goto Block_13;
					}
				}
			}
			IL_297:
			if (evtType == AdventureEventType.DamagePerSecondTrigger && evtData is List<BattleEffectBase>)
			{
				dots = (evtData as List<BattleEffectBase>).OfType<DamageOverTimeEffect>().ToList<DamageOverTimeEffect>();
				enumerator3 = dots.GetEnumerator();
				num = 4294967293u;
				goto Block_16;
			}
			IL_5FA:
			if (evtType != AdventureEventType.UnitPreKilled || triggerUnit != effectCarrier || effectCarrier.HealthPoints > 0.0)
			{
				goto IL_8F9;
			}
			data4 = (specialEffectData as DemonSkullData);
			if (data4 != null && !data4.HaveRevived)
			{
				releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(effectCarrier, effectCarrier, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = triggerUnit.GetMaxLife(AttributeRetrievalLevel.Skill) * data4.ReviveRate,
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
						}
					}, true)
				}, effectCarrier);
				data4.HaveRevived = true;
				enumerator6 = releaseableHeal.Release().GetEnumerator();
				num = 4294967293u;
				goto Block_22;
			}
			goto IL_8F9;
			Block_23:
			try
			{
				IL_7A7:
				switch (num)
				{
				case 6u:
					Block_66:
					try
					{
						switch (num)
						{
						}
						if (enumerator8.MoveNext())
						{
							_6 = enumerator8.Current;
							this.$current = _6;
							if (!this.$disposing)
							{
								this.$PC = 6;
							}
							flag = true;
							return true;
						}
					}
					finally
					{
						if (!flag)
						{
							if ((disposable6 = (enumerator8 as IDisposable)) != null)
							{
								disposable6.Dispose();
							}
						}
					}
					i++;
					break;
				default:
					goto IL_8CE;
				}
				IL_8B8:
				if (i < data4.NumberOfBleedingsOnRebirth)
				{
					enumerator8 = DamageOverTimeEffect.AddDamageOverSecond(targetUnit, effectCarrier, effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * data4.RebirthBleedingDamageRate, (int)data4.RebirthBleedingLastingSeconds, data4.RebirthBleedingDamageType).GetEnumerator();
					num = 4294967293u;
					goto Block_66;
				}
				IL_8CE:
				if (enumerator7.MoveNext())
				{
					targetUnit = enumerator7.Current;
					i = 0;
					goto IL_8B8;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator7).Dispose();
				}
			}
			IL_8F9:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014B3 RID: 5299
		// (get) Token: 0x060062E7 RID: 25319 RVA: 0x0018EDF8 File Offset: 0x0018D1F8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014B4 RID: 5300
		// (get) Token: 0x060062E8 RID: 25320 RVA: 0x0018EE00 File Offset: 0x0018D200
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060062E9 RID: 25321 RVA: 0x0018EE08 File Offset: 0x0018D208
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
			case 4u:
				try
				{
					switch (num)
					{
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
					}
				}
				finally
				{
					((IDisposable)enumerator3).Dispose();
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
			case 6u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable6 = (enumerator8 as IDisposable)) != null)
						{
							disposable6.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator7).Dispose();
				}
				break;
			}
		}

		// Token: 0x060062EA RID: 25322 RVA: 0x0018F010 File Offset: 0x0018D410
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060062EB RID: 25323 RVA: 0x0018F017 File Offset: 0x0018D417
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060062EC RID: 25324 RVA: 0x0018F020 File Offset: 0x0018D420
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DemonSkullEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new DemonSkullEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x040059B2 RID: 22962
		internal AdventureEventType evtType;

		// Token: 0x040059B3 RID: 22963
		internal IBattleUnit triggerUnit;

		// Token: 0x040059B4 RID: 22964
		internal IBattleUnit effectCarrier;

		// Token: 0x040059B5 RID: 22965
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x040059B6 RID: 22966
		internal DemonSkullData <data>__1;

		// Token: 0x040059B7 RID: 22967
		internal IEnumerator $locvar0;

		// Token: 0x040059B8 RID: 22968
		internal object <_>__2;

		// Token: 0x040059B9 RID: 22969
		internal IDisposable $locvar1;

		// Token: 0x040059BA RID: 22970
		internal object evtData;

		// Token: 0x040059BB RID: 22971
		internal DamageComponent <damage>__3;

		// Token: 0x040059BC RID: 22972
		internal DemonSkullData <data>__4;

		// Token: 0x040059BD RID: 22973
		internal IEnumerator $locvar2;

		// Token: 0x040059BE RID: 22974
		internal object <_>__5;

		// Token: 0x040059BF RID: 22975
		internal IDisposable $locvar3;

		// Token: 0x040059C0 RID: 22976
		internal List<DamageOverTimeEffect> <dots>__6;

		// Token: 0x040059C1 RID: 22977
		internal List<DamageOverTimeEffect>.Enumerator $locvar4;

		// Token: 0x040059C2 RID: 22978
		internal DamageOverTimeEffect <dot>__7;

		// Token: 0x040059C3 RID: 22979
		internal DemonSkullData <data>__8;

		// Token: 0x040059C4 RID: 22980
		internal List<AttributeModifier> <modifiers>__9;

		// Token: 0x040059C5 RID: 22981
		internal IEnumerator $locvar5;

		// Token: 0x040059C6 RID: 22982
		internal object <_>__10;

		// Token: 0x040059C7 RID: 22983
		internal IDisposable $locvar6;

		// Token: 0x040059C8 RID: 22984
		internal IEnumerator $locvar7;

		// Token: 0x040059C9 RID: 22985
		internal object <_>__11;

		// Token: 0x040059CA RID: 22986
		internal IDisposable $locvar8;

		// Token: 0x040059CB RID: 22987
		internal DemonSkullData <data>__12;

		// Token: 0x040059CC RID: 22988
		internal ReleaseableHeal <releaseableHeal>__13;

		// Token: 0x040059CD RID: 22989
		internal IEnumerator $locvar9;

		// Token: 0x040059CE RID: 22990
		internal object <_>__14;

		// Token: 0x040059CF RID: 22991
		internal IDisposable $locvarA;

		// Token: 0x040059D0 RID: 22992
		internal List<IBattleUnit> <targetUnits>__13;

		// Token: 0x040059D1 RID: 22993
		internal List<IBattleUnit>.Enumerator $locvarB;

		// Token: 0x040059D2 RID: 22994
		internal IBattleUnit <targetUnit>__15;

		// Token: 0x040059D3 RID: 22995
		internal int <i>__16;

		// Token: 0x040059D4 RID: 22996
		internal IEnumerator $locvarC;

		// Token: 0x040059D5 RID: 22997
		internal object <_>__17;

		// Token: 0x040059D6 RID: 22998
		internal IDisposable $locvarD;

		// Token: 0x040059D7 RID: 22999
		internal object $current;

		// Token: 0x040059D8 RID: 23000
		internal bool $disposing;

		// Token: 0x040059D9 RID: 23001
		internal int $PC;
	}
}
