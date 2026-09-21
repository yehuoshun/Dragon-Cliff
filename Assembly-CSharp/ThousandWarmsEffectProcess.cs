using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000936 RID: 2358
public class ThousandWarmsEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x0600412D RID: 16685 RVA: 0x001A8AF2 File Offset: 0x001A6EF2
	public ThousandWarmsEffectProcess()
	{
	}

	// Token: 0x17000C2B RID: 3115
	// (get) Token: 0x0600412E RID: 16686 RVA: 0x001A8B02 File Offset: 0x001A6F02
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000C2C RID: 3116
	// (get) Token: 0x0600412F RID: 16687 RVA: 0x001A8B0C File Offset: 0x001A6F0C
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.BattleEncounterStarts,
				AdventureEventType.UnitPostReceivesDamage_Single,
				AdventureEventType.BattleEffectCapStackReached
			};
		}
	}

	// Token: 0x06004130 RID: 16688 RVA: 0x001A8B38 File Offset: 0x001A6F38
	public override IEnumerable AsActiveUnitPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit effectCarrier)
	{
		if (specialEffectData is ThousandWarmsNestData)
		{
			List<IBattleUnit> playerUnits = effectCarrier.GetLiveEnemyTargets(false, true);
			ThousandWarmsNestData data = specialEffectData as ThousandWarmsNestData;
			if ((double)UnityEngine.Random.value <= data.SwarmChancePerSecond && !effectCarrier.BattleEffects.OfType<LockTimeEffect>().Any<LockTimeEffect>())
			{
				foreach (IBattleUnit playerUnit in playerUnits)
				{
					IEnumerator enumerator2 = playerUnit.ApplySkillEffect(new PoisonWarmEffect("m21boss", data.MaxNumberOfSwarmsPerTarget, effectCarrier), false).GetEnumerator();
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
			data.ThousandSwarmChagedCounter++;
			if (data.ThousandSwarmChagedCounter >= data.ThousandSwarmChargeCapSeconds)
			{
				data.ThousandSwarmChagedCounter -= data.ThousandSwarmChargeCapSeconds;
				foreach (IBattleUnit playerUnit2 in playerUnits)
				{
					IEnumerator enumerator4 = LockTimeEffect.AddStunSeconds(playerUnit2, data.ThousandSwarmLastingSeconds, effectCarrier, false).GetEnumerator();
					try
					{
						while (enumerator4.MoveNext())
						{
							object _2 = enumerator4.Current;
							yield return _2;
						}
					}
					finally
					{
						IDisposable disposable2;
						if ((disposable2 = (enumerator4 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				IEnumerator enumerator5 = effectCarrier.ApplySkillEffect(new ThousandSwarmSoulCollectionEffect(data.ThousandSwarmLastingSeconds, effectCarrier, data.LifeDrinkRate * effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value, data.SwarmDamageType, effectCarrier), false).GetEnumerator();
				try
				{
					while (enumerator5.MoveNext())
					{
						object _3 = enumerator5.Current;
						yield return _3;
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator5 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x06004131 RID: 16689 RVA: 0x001A8B64 File Offset: 0x001A6F64
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.BattleEncounterStarts)
		{
			ThousandWarmsNestData thousandWarmsNestData = specialEffectData as ThousandWarmsNestData;
			if (thousandWarmsNestData != null)
			{
				thousandWarmsNestData.ThousandSwarmChagedCounter = 0;
			}
		}
		if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && triggerUnit == effectCarrier)
		{
			DamageComponent damage = evtData as DamageComponent;
			if (damage != null && effectCarrier.BattleEffects.OfType<ThousandSwarmSoulCollectionEffect>().Any<ThousandSwarmSoulCollectionEffect>() && !damage.HasFullyNeutralized())
			{
				if (damage.Potions.Any((DamageComponentPotion p) => !p.IsNeutralized && p.DamageType == OutputType.Divine))
				{
					List<ThousandSwarmSoulCollectionEffect> soulCollectionEffects = effectCarrier.BattleEffects.OfType<ThousandSwarmSoulCollectionEffect>().ToList<ThousandSwarmSoulCollectionEffect>();
					foreach (ThousandSwarmSoulCollectionEffect thousandSwarmSoulCollectionEffect in soulCollectionEffects)
					{
						IEnumerator enumerator2 = effectCarrier.LooseSkillEffect(thousandSwarmSoulCollectionEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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
					List<IBattleUnit> playerUnits = effectCarrier.GetLiveEnemyTargets(false, true);
					foreach (IBattleUnit playerUnit in playerUnits)
					{
						List<LockTimeEffect> existingSwarmNightmares = (from ef in playerUnit.BattleEffects.OfType<LockTimeEffect>()
						where ef.EffectSourceIdentityCode == LockTimeEffect.SwarmNightmareCode
						select ef).ToList<LockTimeEffect>();
						foreach (LockTimeEffect existingSwarmNightmare in existingSwarmNightmares)
						{
							IEnumerator enumerator5 = playerUnit.LooseSkillEffect(existingSwarmNightmare, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
							try
							{
								while (enumerator5.MoveNext())
								{
									object _2 = enumerator5.Current;
									yield return _2;
								}
							}
							finally
							{
								IDisposable disposable2;
								if ((disposable2 = (enumerator5 as IDisposable)) != null)
								{
									disposable2.Dispose();
								}
							}
						}
					}
					ThousandWarmsNestData data = specialEffectData as ThousandWarmsNestData;
					if (data != null)
					{
						IEnumerator enumerator6 = LockTimeEffect.AddStunSeconds(effectCarrier, data.SelfStunSeconds, effectCarrier, false).GetEnumerator();
						try
						{
							while (enumerator6.MoveNext())
							{
								object _3 = enumerator6.Current;
								yield return _3;
							}
						}
						finally
						{
							IDisposable disposable3;
							if ((disposable3 = (enumerator6 as IDisposable)) != null)
							{
								disposable3.Dispose();
							}
						}
					}
				}
			}
		}
		if (evtType == AdventureEventType.BattleEffectCapStackReached && evtData is PoisonWarmEffect && specialEffectData is ThousandWarmsNestData)
		{
			List<PoisonWarmEffect> existingWarms = triggerUnit.BattleEffects.OfType<PoisonWarmEffect>().ToList<PoisonWarmEffect>();
			int numberOfLayers = existingWarms.Count;
			foreach (PoisonWarmEffect poisonSwarmEffect in existingWarms)
			{
				IEnumerator enumerator8 = triggerUnit.LooseSkillEffect(poisonSwarmEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
				try
				{
					while (enumerator8.MoveNext())
					{
						object _4 = enumerator8.Current;
						yield return _4;
					}
				}
				finally
				{
					IDisposable disposable4;
					if ((disposable4 = (enumerator8 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			ThousandWarmsNestData data2 = specialEffectData as ThousandWarmsNestData;
			double totalDamage = (double)numberOfLayers * data2.DamageRatePerWarm * effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value;
			ReleaseableDamage mainDamage = new ReleaseableDamage(new List<BattleDamage>
			{
				new BattleDamage(triggerUnit, new SpecialEffectTriggerSource(effectCarrier, this.CorrespondingEffectType), new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						DamagePotionValue.CreateRawValuedDamageComponent(triggerUnit, effectCarrier, data2.SwarmDamageType, totalDamage)
					}, triggerUnit, effectCarrier, false, false)
				})
			}, effectCarrier);
			IEnumerator enumerator9 = mainDamage.Release().GetEnumerator();
			try
			{
				while (enumerator9.MoveNext())
				{
					object _5 = enumerator9.Current;
					yield return _5;
				}
			}
			finally
			{
				IDisposable disposable5;
				if ((disposable5 = (enumerator9 as IDisposable)) != null)
				{
					disposable5.Dispose();
				}
			}
			if (existingWarms.Any<PoisonWarmEffect>())
			{
				IEnumerator enumerator10 = existingWarms.First<PoisonWarmEffect>().Triggered(triggerUnit).GetEnumerator();
				try
				{
					while (enumerator10.MoveNext())
					{
						object _6 = enumerator10.Current;
						yield return _6;
					}
				}
				finally
				{
					IDisposable disposable6;
					if ((disposable6 = (enumerator10 as IDisposable)) != null)
					{
						disposable6.Dispose();
					}
				}
			}
			IEnumerable<IBattleUnit> neigbourUnits = from u in triggerUnit.GetAllLiveFriendlyTargetsIncSelf(true)
			where u != triggerUnit
			select u;
			foreach (IBattleUnit neigbourUnit in neigbourUnits)
			{
				List<PoisonWarmEffect> warms = neigbourUnit.BattleEffects.OfType<PoisonWarmEffect>().ToList<PoisonWarmEffect>();
				if (warms.Any<PoisonWarmEffect>())
				{
					int extraLayers = warms.Count;
					double extraDamage = (double)extraLayers * data2.DamageRatePerWarm * effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value;
					foreach (PoisonWarmEffect poisonWarmEffect in warms)
					{
						IEnumerator enumerator13 = neigbourUnit.LooseSkillEffect(poisonWarmEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
						try
						{
							while (enumerator13.MoveNext())
							{
								object _7 = enumerator13.Current;
								yield return _7;
							}
						}
						finally
						{
							IDisposable disposable7;
							if ((disposable7 = (enumerator13 as IDisposable)) != null)
							{
								disposable7.Dispose();
							}
						}
					}
					ReleaseableDamage extraReleaseableDamage = new ReleaseableDamage(new List<BattleDamage>
					{
						new BattleDamage(neigbourUnit, new SpecialEffectTriggerSource(effectCarrier, this.CorrespondingEffectType), new List<DamageComponentValue>
						{
							new DamageComponentValue(new List<DamagePotionValue>
							{
								DamagePotionValue.CreateRawValuedDamageComponent(neigbourUnit, effectCarrier, data2.SwarmDamageType, extraDamage)
							}, neigbourUnit, effectCarrier, false, false)
						})
					}, effectCarrier);
					IEnumerator enumerator14 = extraReleaseableDamage.Release().GetEnumerator();
					try
					{
						while (enumerator14.MoveNext())
						{
							object _8 = enumerator14.Current;
							yield return _8;
						}
					}
					finally
					{
						IDisposable disposable8;
						if ((disposable8 = (enumerator14 as IDisposable)) != null)
						{
							disposable8.Dispose();
						}
					}
					IEnumerator enumerator15 = warms.First<PoisonWarmEffect>().Triggered(neigbourUnit).GetEnumerator();
					try
					{
						while (enumerator15.MoveNext())
						{
							object _9 = enumerator15.Current;
							yield return _9;
						}
					}
					finally
					{
						IDisposable disposable9;
						if ((disposable9 = (enumerator15 as IDisposable)) != null)
						{
							disposable9.Dispose();
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x040030E6 RID: 12518
	private readonly SpecialEffectType _correspondingEffectType = SpecialEffectType.ThousandWarmsNest;

	// Token: 0x02000FD6 RID: 4054
	[CompilerGenerated]
	private sealed class <AsActiveUnitPerSecondProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060066B9 RID: 26297 RVA: 0x001A8BAC File Offset: 0x001A6FAC
		[DebuggerHidden]
		public <AsActiveUnitPerSecondProcess>c__Iterator0()
		{
		}

		// Token: 0x060066BA RID: 26298 RVA: 0x001A8BB4 File Offset: 0x001A6FB4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (!(specialEffectData is ThousandWarmsNestData))
				{
					goto IL_3E0;
				}
				playerUnits = effectCarrier.GetLiveEnemyTargets(false, true);
				data = (specialEffectData as ThousandWarmsNestData);
				if ((double)UnityEngine.Random.value > data.SwarmChancePerSecond || effectCarrier.BattleEffects.OfType<LockTimeEffect>().Any<LockTimeEffect>())
				{
					goto IL_1A7;
				}
				enumerator = playerUnits.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				Block_7:
				try
				{
					switch (num)
					{
					case 2u:
						Block_21:
						try
						{
							switch (num)
							{
							}
							if (enumerator4.MoveNext())
							{
								_2 = enumerator4.Current;
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
								if ((disposable2 = (enumerator4 as IDisposable)) != null)
								{
									disposable2.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator3.MoveNext())
					{
						playerUnit2 = enumerator3.Current;
						enumerator4 = LockTimeEffect.AddStunSeconds(playerUnit2, data.ThousandSwarmLastingSeconds, effectCarrier, false).GetEnumerator();
						num = 4294967293u;
						goto Block_21;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator3).Dispose();
					}
				}
				enumerator5 = effectCarrier.ApplySkillEffect(new ThousandSwarmSoulCollectionEffect(data.ThousandSwarmLastingSeconds, effectCarrier, data.LifeDrinkRate * effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value, data.SwarmDamageType, effectCarrier), false).GetEnumerator();
				num = 4294967293u;
				goto Block_8;
			case 3u:
				goto IL_35E;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_10:
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
					playerUnit = enumerator.Current;
					enumerator2 = playerUnit.ApplySkillEffect(new PoisonWarmEffect("m21boss", data.MaxNumberOfSwarmsPerTarget, effectCarrier), false).GetEnumerator();
					num = 4294967293u;
					goto Block_10;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_1A7:
			data.ThousandSwarmChagedCounter++;
			if (data.ThousandSwarmChagedCounter >= data.ThousandSwarmChargeCapSeconds)
			{
				data.ThousandSwarmChagedCounter -= data.ThousandSwarmChargeCapSeconds;
				enumerator3 = playerUnits.GetEnumerator();
				num = 4294967293u;
				goto Block_7;
			}
			goto IL_3E0;
			Block_8:
			try
			{
				IL_35E:
				switch (num)
				{
				}
				if (enumerator5.MoveNext())
				{
					_3 = enumerator5.Current;
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
					if ((disposable3 = (enumerator5 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			IL_3E0:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700158D RID: 5517
		// (get) Token: 0x060066BB RID: 26299 RVA: 0x001A8FEC File Offset: 0x001A73EC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700158E RID: 5518
		// (get) Token: 0x060066BC RID: 26300 RVA: 0x001A8FF4 File Offset: 0x001A73F4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060066BD RID: 26301 RVA: 0x001A8FFC File Offset: 0x001A73FC
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
			case 2u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable2 = (enumerator4 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator3).Dispose();
				}
				break;
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator5 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x060066BE RID: 26302 RVA: 0x001A9130 File Offset: 0x001A7530
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060066BF RID: 26303 RVA: 0x001A9137 File Offset: 0x001A7537
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060066C0 RID: 26304 RVA: 0x001A9140 File Offset: 0x001A7540
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ThousandWarmsEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0 <AsActiveUnitPerSecondProcess>c__Iterator = new ThousandWarmsEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0();
			<AsActiveUnitPerSecondProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitPerSecondProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitPerSecondProcess>c__Iterator;
		}

		// Token: 0x04005FFA RID: 24570
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005FFB RID: 24571
		internal IBattleUnit effectCarrier;

		// Token: 0x04005FFC RID: 24572
		internal List<IBattleUnit> <playerUnits>__1;

		// Token: 0x04005FFD RID: 24573
		internal ThousandWarmsNestData <data>__1;

		// Token: 0x04005FFE RID: 24574
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04005FFF RID: 24575
		internal IBattleUnit <playerUnit>__2;

		// Token: 0x04006000 RID: 24576
		internal IEnumerator $locvar1;

		// Token: 0x04006001 RID: 24577
		internal object <_>__3;

		// Token: 0x04006002 RID: 24578
		internal IDisposable $locvar2;

		// Token: 0x04006003 RID: 24579
		internal List<IBattleUnit>.Enumerator $locvar3;

		// Token: 0x04006004 RID: 24580
		internal IBattleUnit <playerUnit>__4;

		// Token: 0x04006005 RID: 24581
		internal IEnumerator $locvar4;

		// Token: 0x04006006 RID: 24582
		internal object <_>__5;

		// Token: 0x04006007 RID: 24583
		internal IDisposable $locvar5;

		// Token: 0x04006008 RID: 24584
		internal IEnumerator $locvar6;

		// Token: 0x04006009 RID: 24585
		internal object <_>__6;

		// Token: 0x0400600A RID: 24586
		internal IDisposable $locvar7;

		// Token: 0x0400600B RID: 24587
		internal object $current;

		// Token: 0x0400600C RID: 24588
		internal bool $disposing;

		// Token: 0x0400600D RID: 24589
		internal int $PC;
	}

	// Token: 0x02000FD7 RID: 4055
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060066C1 RID: 26305 RVA: 0x001A9180 File Offset: 0x001A7580
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator1()
		{
		}

		// Token: 0x060066C2 RID: 26306 RVA: 0x001A9188 File Offset: 0x001A7588
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType == AdventureEventType.BattleEncounterStarts)
				{
					ThousandWarmsNestData thousandWarmsNestData = specialEffectData as ThousandWarmsNestData;
					if (thousandWarmsNestData != null)
					{
						thousandWarmsNestData.ThousandSwarmChagedCounter = 0;
					}
				}
				if (evtType != AdventureEventType.UnitPostReceivesDamage_Single || triggerUnit != effectCarrier)
				{
					goto IL_4C7;
				}
				damage = (evtData as DamageComponent);
				if (damage == null || !effectCarrier.BattleEffects.OfType<ThousandSwarmSoulCollectionEffect>().Any<ThousandSwarmSoulCollectionEffect>() || damage.HasFullyNeutralized())
				{
					goto IL_4C7;
				}
				if (!damage.Potions.Any((DamageComponentPotion p) => !p.IsNeutralized && p.DamageType == OutputType.Divine))
				{
					goto IL_4C7;
				}
				soulCollectionEffects = effectCarrier.BattleEffects.OfType<ThousandSwarmSoulCollectionEffect>().ToList<ThousandSwarmSoulCollectionEffect>();
				enumerator = soulCollectionEffects.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_271;
			case 3u:
				goto IL_445;
			case 4u:
				Block_18:
				try
				{
					switch (num)
					{
					case 4u:
						Block_58:
						try
						{
							switch (num)
							{
							}
							if (enumerator8.MoveNext())
							{
								_4 = enumerator8.Current;
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
								if ((disposable4 = (enumerator8 as IDisposable)) != null)
								{
									disposable4.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator7.MoveNext())
					{
						poisonSwarmEffect = enumerator7.Current;
						enumerator8 = <AsActiveUnitProcess>c__AnonStorey.triggerUnit.LooseSkillEffect(poisonSwarmEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
						num = 4294967293u;
						goto Block_58;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator7).Dispose();
					}
				}
				data2 = (specialEffectData as ThousandWarmsNestData);
				totalDamage = (double)numberOfLayers * data2.DamageRatePerWarm * effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value;
				mainDamage = new ReleaseableDamage(new List<BattleDamage>
				{
					new BattleDamage(<AsActiveUnitProcess>c__AnonStorey.triggerUnit, new SpecialEffectTriggerSource(effectCarrier, this.CorrespondingEffectType), new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							DamagePotionValue.CreateRawValuedDamageComponent(<AsActiveUnitProcess>c__AnonStorey.triggerUnit, effectCarrier, data2.SwarmDamageType, totalDamage)
						}, <AsActiveUnitProcess>c__AnonStorey.triggerUnit, effectCarrier, false, false)
					})
				}, effectCarrier);
				enumerator9 = mainDamage.Release().GetEnumerator();
				num = 4294967293u;
				goto Block_19;
			case 5u:
				goto IL_728;
			case 6u:
				goto IL_7E3;
			case 7u:
			case 8u:
			case 9u:
				Block_22:
				try
				{
					switch (num)
					{
					case 7u:
						Block_82:
						try
						{
							switch (num)
							{
							case 7u:
								Block_87:
								try
								{
									switch (num)
									{
									}
									if (enumerator13.MoveNext())
									{
										_7 = enumerator13.Current;
										this.$current = _7;
										if (!this.$disposing)
										{
											this.$PC = 7;
										}
										flag = true;
										return true;
									}
								}
								finally
								{
									if (!flag)
									{
										if ((disposable7 = (enumerator13 as IDisposable)) != null)
										{
											disposable7.Dispose();
										}
									}
								}
								break;
							}
							if (enumerator12.MoveNext())
							{
								poisonWarmEffect = enumerator12.Current;
								enumerator13 = neigbourUnit.LooseSkillEffect(poisonWarmEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
								num = 4294967293u;
								goto Block_87;
							}
						}
						finally
						{
							if (!flag)
							{
								((IDisposable)enumerator12).Dispose();
							}
						}
						extraReleaseableDamage = new ReleaseableDamage(new List<BattleDamage>
						{
							new BattleDamage(neigbourUnit, new SpecialEffectTriggerSource(effectCarrier, this.CorrespondingEffectType), new List<DamageComponentValue>
							{
								new DamageComponentValue(new List<DamagePotionValue>
								{
									DamagePotionValue.CreateRawValuedDamageComponent(neigbourUnit, effectCarrier, data2.SwarmDamageType, extraDamage)
								}, neigbourUnit, effectCarrier, false, false)
							})
						}, effectCarrier);
						enumerator14 = extraReleaseableDamage.Release().GetEnumerator();
						num = 4294967293u;
						goto Block_83;
					case 8u:
						goto IL_AEA;
					case 9u:
						goto IL_B90;
					}
					IL_C14:
					while (enumerator11.MoveNext())
					{
						neigbourUnit = enumerator11.Current;
						warms = neigbourUnit.BattleEffects.OfType<PoisonWarmEffect>().ToList<PoisonWarmEffect>();
						if (warms.Any<PoisonWarmEffect>())
						{
							extraLayers = warms.Count;
							extraDamage = (double)extraLayers * data2.DamageRatePerWarm * effectCarrier.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value;
							enumerator12 = warms.GetEnumerator();
							num = 4294967293u;
							goto Block_82;
						}
					}
					goto IL_C44;
					Block_83:
					try
					{
						IL_AEA:
						switch (num)
						{
						}
						if (enumerator14.MoveNext())
						{
							_8 = enumerator14.Current;
							this.$current = _8;
							if (!this.$disposing)
							{
								this.$PC = 8;
							}
							flag = true;
							return true;
						}
					}
					finally
					{
						if (!flag)
						{
							if ((disposable8 = (enumerator14 as IDisposable)) != null)
							{
								disposable8.Dispose();
							}
						}
					}
					enumerator15 = warms.First<PoisonWarmEffect>().Triggered(neigbourUnit).GetEnumerator();
					num = 4294967293u;
					try
					{
						IL_B90:
						switch (num)
						{
						}
						if (enumerator15.MoveNext())
						{
							_9 = enumerator15.Current;
							this.$current = _9;
							if (!this.$disposing)
							{
								this.$PC = 9;
							}
							flag = true;
							return true;
						}
					}
					finally
					{
						if (!flag)
						{
							if ((disposable9 = (enumerator15 as IDisposable)) != null)
							{
								disposable9.Dispose();
							}
						}
					}
					goto IL_C14;
				}
				finally
				{
					if (!flag)
					{
						if (enumerator11 != null)
						{
							enumerator11.Dispose();
						}
					}
				}
				goto IL_C44;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_24:
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
					thousandSwarmSoulCollectionEffect = enumerator.Current;
					enumerator2 = effectCarrier.LooseSkillEffect(thousandSwarmSoulCollectionEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
					num = 4294967293u;
					goto Block_24;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			playerUnits = effectCarrier.GetLiveEnemyTargets(false, true);
			enumerator3 = playerUnits.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_271:
				switch (num)
				{
				case 2u:
					Block_36:
					try
					{
						switch (num)
						{
						case 2u:
							Block_39:
							try
							{
								switch (num)
								{
								}
								if (enumerator5.MoveNext())
								{
									_2 = enumerator5.Current;
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
									if ((disposable2 = (enumerator5 as IDisposable)) != null)
									{
										disposable2.Dispose();
									}
								}
							}
							break;
						}
						if (enumerator4.MoveNext())
						{
							existingSwarmNightmare = enumerator4.Current;
							enumerator5 = playerUnit.LooseSkillEffect(existingSwarmNightmare, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
							num = 4294967293u;
							goto Block_39;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator4).Dispose();
						}
					}
					break;
				}
				if (enumerator3.MoveNext())
				{
					playerUnit = enumerator3.Current;
					existingSwarmNightmares = (from ef in playerUnit.BattleEffects.OfType<LockTimeEffect>()
					where ef.EffectSourceIdentityCode == LockTimeEffect.SwarmNightmareCode
					select ef).ToList<LockTimeEffect>();
					enumerator4 = existingSwarmNightmares.GetEnumerator();
					num = 4294967293u;
					goto Block_36;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator3).Dispose();
				}
			}
			data = (specialEffectData as ThousandWarmsNestData);
			if (data == null)
			{
				goto IL_4C7;
			}
			enumerator6 = LockTimeEffect.AddStunSeconds(effectCarrier, data.SelfStunSeconds, effectCarrier, false).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_445:
				switch (num)
				{
				}
				if (enumerator6.MoveNext())
				{
					_3 = enumerator6.Current;
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
					if ((disposable3 = (enumerator6 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			IL_4C7:
			if (evtType == AdventureEventType.BattleEffectCapStackReached && evtData is PoisonWarmEffect && specialEffectData is ThousandWarmsNestData)
			{
				existingWarms = <AsActiveUnitProcess>c__AnonStorey.triggerUnit.BattleEffects.OfType<PoisonWarmEffect>().ToList<PoisonWarmEffect>();
				numberOfLayers = existingWarms.Count;
				enumerator7 = existingWarms.GetEnumerator();
				num = 4294967293u;
				goto Block_18;
			}
			goto IL_C44;
			Block_19:
			try
			{
				IL_728:
				switch (num)
				{
				}
				if (enumerator9.MoveNext())
				{
					_5 = enumerator9.Current;
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
					if ((disposable5 = (enumerator9 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
			}
			if (!existingWarms.Any<PoisonWarmEffect>())
			{
				goto IL_865;
			}
			enumerator10 = existingWarms.First<PoisonWarmEffect>().Triggered(<AsActiveUnitProcess>c__AnonStorey.triggerUnit).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_7E3:
				switch (num)
				{
				}
				if (enumerator10.MoveNext())
				{
					_6 = enumerator10.Current;
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
					if ((disposable6 = (enumerator10 as IDisposable)) != null)
					{
						disposable6.Dispose();
					}
				}
			}
			IL_865:
			neigbourUnits = from u in <AsActiveUnitProcess>c__AnonStorey.triggerUnit.GetAllLiveFriendlyTargetsIncSelf(true)
			where u != <AsActiveUnitProcess>c__AnonStorey.triggerUnit
			select u;
			enumerator11 = neigbourUnits.GetEnumerator();
			num = 4294967293u;
			goto Block_22;
			IL_C44:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700158F RID: 5519
		// (get) Token: 0x060066C3 RID: 26307 RVA: 0x001A9F50 File Offset: 0x001A8350
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001590 RID: 5520
		// (get) Token: 0x060066C4 RID: 26308 RVA: 0x001A9F58 File Offset: 0x001A8358
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060066C5 RID: 26309 RVA: 0x001A9F60 File Offset: 0x001A8360
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
			case 2u:
				try
				{
					try
					{
						try
						{
						}
						finally
						{
							if ((disposable2 = (enumerator5 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator4).Dispose();
					}
				}
				finally
				{
					((IDisposable)enumerator3).Dispose();
				}
				break;
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator6 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			case 4u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable4 = (enumerator8 as IDisposable)) != null)
						{
							disposable4.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator7).Dispose();
				}
				break;
			case 5u:
				try
				{
				}
				finally
				{
					if ((disposable5 = (enumerator9 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
				break;
			case 6u:
				try
				{
				}
				finally
				{
					if ((disposable6 = (enumerator10 as IDisposable)) != null)
					{
						disposable6.Dispose();
					}
				}
				break;
			case 7u:
			case 8u:
			case 9u:
				try
				{
					switch (num)
					{
					case 7u:
						try
						{
							try
							{
							}
							finally
							{
								if ((disposable7 = (enumerator13 as IDisposable)) != null)
								{
									disposable7.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator12).Dispose();
						}
						break;
					case 8u:
						try
						{
						}
						finally
						{
							if ((disposable8 = (enumerator14 as IDisposable)) != null)
							{
								disposable8.Dispose();
							}
						}
						break;
					case 9u:
						try
						{
						}
						finally
						{
							if ((disposable9 = (enumerator15 as IDisposable)) != null)
							{
								disposable9.Dispose();
							}
						}
						break;
					}
				}
				finally
				{
					if (enumerator11 != null)
					{
						enumerator11.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x060066C6 RID: 26310 RVA: 0x001AA2B8 File Offset: 0x001A86B8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060066C7 RID: 26311 RVA: 0x001AA2BF File Offset: 0x001A86BF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060066C8 RID: 26312 RVA: 0x001AA2C8 File Offset: 0x001A86C8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ThousandWarmsEffectProcess.<AsActiveUnitProcess>c__Iterator1 <AsActiveUnitProcess>c__Iterator = new ThousandWarmsEffectProcess.<AsActiveUnitProcess>c__Iterator1();
			<AsActiveUnitProcess>c__Iterator.$this = this;
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x060066C9 RID: 26313 RVA: 0x001AA338 File Offset: 0x001A8738
		private static bool <>m__0(DamageComponentPotion p)
		{
			return !p.IsNeutralized && p.DamageType == OutputType.Divine;
		}

		// Token: 0x060066CA RID: 26314 RVA: 0x001AA351 File Offset: 0x001A8751
		private static bool <>m__1(LockTimeEffect ef)
		{
			return ef.EffectSourceIdentityCode == LockTimeEffect.SwarmNightmareCode;
		}

		// Token: 0x0400600E RID: 24590
		internal AdventureEventType evtType;

		// Token: 0x0400600F RID: 24591
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04006010 RID: 24592
		internal IBattleUnit triggerUnit;

		// Token: 0x04006011 RID: 24593
		internal IBattleUnit effectCarrier;

		// Token: 0x04006012 RID: 24594
		internal object evtData;

		// Token: 0x04006013 RID: 24595
		internal DamageComponent <damage>__1;

		// Token: 0x04006014 RID: 24596
		internal List<ThousandSwarmSoulCollectionEffect> <soulCollectionEffects>__2;

		// Token: 0x04006015 RID: 24597
		internal List<ThousandSwarmSoulCollectionEffect>.Enumerator $locvar0;

		// Token: 0x04006016 RID: 24598
		internal ThousandSwarmSoulCollectionEffect <thousandSwarmSoulCollectionEffect>__3;

		// Token: 0x04006017 RID: 24599
		internal IEnumerator $locvar1;

		// Token: 0x04006018 RID: 24600
		internal object <_>__4;

		// Token: 0x04006019 RID: 24601
		internal IDisposable $locvar2;

		// Token: 0x0400601A RID: 24602
		internal List<IBattleUnit> <playerUnits>__2;

		// Token: 0x0400601B RID: 24603
		internal List<IBattleUnit>.Enumerator $locvar3;

		// Token: 0x0400601C RID: 24604
		internal IBattleUnit <playerUnit>__5;

		// Token: 0x0400601D RID: 24605
		internal List<LockTimeEffect> <existingSwarmNightmares>__6;

		// Token: 0x0400601E RID: 24606
		internal List<LockTimeEffect>.Enumerator $locvar4;

		// Token: 0x0400601F RID: 24607
		internal LockTimeEffect <existingSwarmNightmare>__7;

		// Token: 0x04006020 RID: 24608
		internal IEnumerator $locvar5;

		// Token: 0x04006021 RID: 24609
		internal object <_>__8;

		// Token: 0x04006022 RID: 24610
		internal IDisposable $locvar6;

		// Token: 0x04006023 RID: 24611
		internal ThousandWarmsNestData <data>__2;

		// Token: 0x04006024 RID: 24612
		internal IEnumerator $locvar7;

		// Token: 0x04006025 RID: 24613
		internal object <_>__9;

		// Token: 0x04006026 RID: 24614
		internal IDisposable $locvar8;

		// Token: 0x04006027 RID: 24615
		internal List<PoisonWarmEffect> <existingWarms>__10;

		// Token: 0x04006028 RID: 24616
		internal int <numberOfLayers>__10;

		// Token: 0x04006029 RID: 24617
		internal List<PoisonWarmEffect>.Enumerator $locvar9;

		// Token: 0x0400602A RID: 24618
		internal PoisonWarmEffect <poisonSwarmEffect>__11;

		// Token: 0x0400602B RID: 24619
		internal IEnumerator $locvarA;

		// Token: 0x0400602C RID: 24620
		internal object <_>__12;

		// Token: 0x0400602D RID: 24621
		internal IDisposable $locvarB;

		// Token: 0x0400602E RID: 24622
		internal ThousandWarmsNestData <data>__10;

		// Token: 0x0400602F RID: 24623
		internal double <totalDamage>__10;

		// Token: 0x04006030 RID: 24624
		internal ReleaseableDamage <mainDamage>__10;

		// Token: 0x04006031 RID: 24625
		internal IEnumerator $locvarC;

		// Token: 0x04006032 RID: 24626
		internal object <_>__13;

		// Token: 0x04006033 RID: 24627
		internal IDisposable $locvarD;

		// Token: 0x04006034 RID: 24628
		internal IEnumerator $locvarE;

		// Token: 0x04006035 RID: 24629
		internal object <_>__14;

		// Token: 0x04006036 RID: 24630
		internal IDisposable $locvarF;

		// Token: 0x04006037 RID: 24631
		internal IEnumerable<IBattleUnit> <neigbourUnits>__10;

		// Token: 0x04006038 RID: 24632
		internal IEnumerator<IBattleUnit> $locvar10;

		// Token: 0x04006039 RID: 24633
		internal IBattleUnit <neigbourUnit>__15;

		// Token: 0x0400603A RID: 24634
		internal List<PoisonWarmEffect> <warms>__16;

		// Token: 0x0400603B RID: 24635
		internal int <extraLayers>__17;

		// Token: 0x0400603C RID: 24636
		internal double <extraDamage>__17;

		// Token: 0x0400603D RID: 24637
		internal List<PoisonWarmEffect>.Enumerator $locvar11;

		// Token: 0x0400603E RID: 24638
		internal PoisonWarmEffect <poisonWarmEffect>__18;

		// Token: 0x0400603F RID: 24639
		internal IEnumerator $locvar12;

		// Token: 0x04006040 RID: 24640
		internal object <_>__19;

		// Token: 0x04006041 RID: 24641
		internal IDisposable $locvar13;

		// Token: 0x04006042 RID: 24642
		internal ReleaseableDamage <extraReleaseableDamage>__17;

		// Token: 0x04006043 RID: 24643
		internal IEnumerator $locvar14;

		// Token: 0x04006044 RID: 24644
		internal object <_>__20;

		// Token: 0x04006045 RID: 24645
		internal IDisposable $locvar15;

		// Token: 0x04006046 RID: 24646
		internal IEnumerator $locvar16;

		// Token: 0x04006047 RID: 24647
		internal object <_>__21;

		// Token: 0x04006048 RID: 24648
		internal IDisposable $locvar17;

		// Token: 0x04006049 RID: 24649
		internal ThousandWarmsEffectProcess $this;

		// Token: 0x0400604A RID: 24650
		internal object $current;

		// Token: 0x0400604B RID: 24651
		internal bool $disposing;

		// Token: 0x0400604C RID: 24652
		internal int $PC;

		// Token: 0x0400604D RID: 24653
		private ThousandWarmsEffectProcess.<AsActiveUnitProcess>c__Iterator1.<AsActiveUnitProcess>c__AnonStorey2 $locvar18;

		// Token: 0x0400604E RID: 24654
		private static Func<DamageComponentPotion, bool> <>f__am$cache0;

		// Token: 0x0400604F RID: 24655
		private static Func<LockTimeEffect, bool> <>f__am$cache1;

		// Token: 0x02000FD8 RID: 4056
		private sealed class <AsActiveUnitProcess>c__AnonStorey2
		{
			// Token: 0x060066CB RID: 26315 RVA: 0x001AA363 File Offset: 0x001A8763
			public <AsActiveUnitProcess>c__AnonStorey2()
			{
			}

			// Token: 0x060066CC RID: 26316 RVA: 0x001AA36B File Offset: 0x001A876B
			internal bool <>m__0(IBattleUnit u)
			{
				return u != this.triggerUnit;
			}

			// Token: 0x04006050 RID: 24656
			internal IBattleUnit triggerUnit;

			// Token: 0x04006051 RID: 24657
			internal ThousandWarmsEffectProcess.<AsActiveUnitProcess>c__Iterator1 <>f__ref$1;
		}
	}
}
