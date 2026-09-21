using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Core.Battle.RunePower;
using UnityEngine;

// Token: 0x0200072C RID: 1836
public class ReleaseableDamage : IReleaseable
{
	// Token: 0x06003387 RID: 13191 RVA: 0x00158EB4 File Offset: 0x001572B4
	public ReleaseableDamage(List<BattleDamage> battleDamages, IBattleUnit dealer)
	{
		this.BattleDamages = battleDamages;
		this.Status = ReleaseStatus.NotReleased;
		this.Dealer = dealer;
		foreach (BattleDamage battleDamage in battleDamages)
		{
			battleDamage.Releaseable = this;
		}
		if (dealer.BattleEffects.OfType<FocusEffect>().Any<FocusEffect>())
		{
			if (battleDamages.Any((BattleDamage d) => d.Damages.Any((DamageComponent dd) => dd.IsDirectDamage)))
			{
				int num = (from t in battleDamages
				select t.Target.GetId()).Distinct<string>().Count<string>() - 1;
				FocusEffect focusEffect = dealer.BattleEffects.OfType<FocusEffect>().First<FocusEffect>();
				double num2 = focusEffect.ExtraDamageRate - focusEffect.DamageReductPerExtraTarget * (double)num;
				if (num2 > 0.0)
				{
					double rate = num2 + 1.0;
					foreach (BattleDamage battleDamage2 in battleDamages)
					{
						foreach (DamageComponent damageComponent in (from d in battleDamage2.Damages
						where d.IsDirectDamage
						select d).ToList<DamageComponent>())
						{
							foreach (DamageComponentPotion damageComponentPotion in damageComponent.Potions)
							{
								damageComponentPotion.MultiplyCalculatedDamageValue(rate);
							}
						}
					}
				}
			}
		}
		if (dealer.BattleEffects.OfType<GuiltEffect>().Any<GuiltEffect>())
		{
			if (battleDamages.Any((BattleDamage d) => d.Damages.Any((DamageComponent dd) => dd.IsDirectDamage) && d.DamageSource is AdventureUnitSkill))
			{
				if ((from b in battleDamages
				select b.Target).Distinct<IBattleUnit>().Count<IBattleUnit>() == dealer.GetLiveEnemyTargets(false, false).Count)
				{
					GuiltEffect guiltEffect = dealer.BattleEffects.OfType<GuiltEffect>().First<GuiltEffect>();
					foreach (BattleDamage battleDamage3 in battleDamages)
					{
						double num3 = guiltEffect.DirectDamageBoostRate;
						double num4 = 1.0;
						if (num3 < 0.0)
						{
							num3 = 0.0;
						}
						num4 += num3;
						if (num4 > 1.0)
						{
							foreach (DamageComponent damageComponent2 in from d in battleDamage3.Damages
							where d.IsDirectDamage
							select d)
							{
								foreach (DamageComponentPotion damageComponentPotion2 in damageComponent2.Potions)
								{
									damageComponentPotion2.MultiplyCalculatedDamageValue(num4);
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x170007FC RID: 2044
	// (get) Token: 0x06003388 RID: 13192 RVA: 0x001592F8 File Offset: 0x001576F8
	// (set) Token: 0x06003389 RID: 13193 RVA: 0x00159300 File Offset: 0x00157700
	public ReleaseStatus Status
	{
		[CompilerGenerated]
		get
		{
			return this.<Status>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Status>k__BackingField = value;
		}
	}

	// Token: 0x170007FD RID: 2045
	// (get) Token: 0x0600338A RID: 13194 RVA: 0x00159309 File Offset: 0x00157709
	// (set) Token: 0x0600338B RID: 13195 RVA: 0x00159311 File Offset: 0x00157711
	public List<BattleDamage> BattleDamages
	{
		[CompilerGenerated]
		get
		{
			return this.<BattleDamages>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<BattleDamages>k__BackingField = value;
		}
	}

	// Token: 0x170007FE RID: 2046
	// (get) Token: 0x0600338C RID: 13196 RVA: 0x0015931A File Offset: 0x0015771A
	// (set) Token: 0x0600338D RID: 13197 RVA: 0x00159322 File Offset: 0x00157722
	public IBattleUnit Dealer
	{
		[CompilerGenerated]
		get
		{
			return this.<Dealer>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Dealer>k__BackingField = value;
		}
	}

	// Token: 0x0600338E RID: 13198 RVA: 0x0015932C File Offset: 0x0015772C
	public IEnumerable Release()
	{
		this.Status = ReleaseStatus.Releasing;
		IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(this.Dealer, AdventureEventType.UnitReleasesDamage, this)).GetEnumerator();
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
		foreach (BattleDamage battleDamage in this.BattleDamages)
		{
			IEnumerator enumerator3 = battleDamage.Target.ReceivesDamage(battleDamage).GetEnumerator();
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
		}
		this.Status = ReleaseStatus.Released;
		List<BattleEffectBase> toRemove = (from ef in this.Dealer.BattleEffects
		where ef.EffectSourceIdentityCode.StartsWith(AttributeModificationEffect.PostDamageReleaseRemovePartial)
		select ef).ToList<BattleEffectBase>();
		foreach (BattleEffectBase battleEffectBase in toRemove)
		{
			IEnumerator enumerator5 = this.Dealer.LooseSkillEffect(battleEffectBase, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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
		IEnumerator enumerator6 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(this.Dealer, AdventureEventType.DamageReleased, this)).GetEnumerator();
		try
		{
			while (enumerator6.MoveNext())
			{
				object _4 = enumerator6.Current;
				yield return _4;
			}
		}
		finally
		{
			IDisposable disposable4;
			if ((disposable4 = (enumerator6 as IDisposable)) != null)
			{
				disposable4.Dispose();
			}
		}
		foreach (BattleDamage battleDamage2 in this.BattleDamages)
		{
			if (battleDamage2.Target.IsPlayer && battleDamage2.Target.CurrentAdventure.RunePower != null)
			{
				int totalNumberOfValidDamages = battleDamage2.Damages.Count((DamageComponent d) => d.IsDirectDamage && !d.IsReflectedDamage);
				int directDamageGhostRate = battleDamage2.Target.CurrentAdventure.RunePower.GetRate(SpecialEffectType.GhostBreathsDirectDamageReceiveCollection);
				IEnumerator enumerator8 = battleDamage2.Target.CurrentAdventure.RunePower.AddPower(RunePowerType.GhostBreaths, directDamageGhostRate * totalNumberOfValidDamages, battleDamage2.Target).GetEnumerator();
				try
				{
					while (enumerator8.MoveNext())
					{
						object _5 = enumerator8.Current;
						yield return _5;
					}
				}
				finally
				{
					IDisposable disposable5;
					if ((disposable5 = (enumerator8 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
			}
		}
		if (this.BattleDamages.All((BattleDamage d) => d.DamageSource is AdventureUnitSkill))
		{
			List<StarfallData> starfalls = this.Dealer.SpecialEffects.OfType<StarfallData>().ToList<StarfallData>();
			if (starfalls.Any<StarfallData>())
			{
				List<IBattleUnit> targets = this.Dealer.GetLiveEnemyTargets(false, true);
				if (targets.Any<IBattleUnit>())
				{
					List<BattleDamage> damages = new List<BattleDamage>();
					foreach (IBattleUnit target in targets)
					{
						List<DamagePotionValue> list = new List<DamagePotionValue>();
						foreach (StarfallData starfallData in starfalls)
						{
							if ((double)UnityEngine.Random.value <= starfallData.Chance)
							{
								list.Add(new DamagePotionValue(this.Dealer, target, starfallData.DamageType, starfallData.DamagePercentage));
							}
						}
						if (list.Any<DamagePotionValue>())
						{
							damages.Add(new BattleDamage(target, new SpecialEffectTriggerSource(this.Dealer, SpecialEffectType.Starfall), new List<DamageComponentValue>
							{
								new DamageComponentValue(list, target, this.Dealer, true, false)
							}));
						}
					}
					if (damages.Any<BattleDamage>())
					{
						ReleaseableDamage releaseable = new ReleaseableDamage(damages, this.Dealer);
						IEnumerator enumerator11 = releaseable.Release().GetEnumerator();
						try
						{
							while (enumerator11.MoveNext())
							{
								object _6 = enumerator11.Current;
								yield return _6;
							}
						}
						finally
						{
							IDisposable disposable6;
							if ((disposable6 = (enumerator11 as IDisposable)) != null)
							{
								disposable6.Dispose();
							}
						}
					}
				}
			}
		}
		IEnumerator enumerator12 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(this.Dealer, AdventureEventType.DamageReleaseProcessCompleted, this)).GetEnumerator();
		try
		{
			while (enumerator12.MoveNext())
			{
				object _7 = enumerator12.Current;
				yield return _7;
			}
		}
		finally
		{
			IDisposable disposable7;
			if ((disposable7 = (enumerator12 as IDisposable)) != null)
			{
				disposable7.Dispose();
			}
		}
		yield break;
	}

	// Token: 0x0600338F RID: 13199 RVA: 0x0015934F File Offset: 0x0015774F
	[CompilerGenerated]
	private static bool <ReleaseableDamage>m__0(BattleDamage d)
	{
		return d.Damages.Any((DamageComponent dd) => dd.IsDirectDamage);
	}

	// Token: 0x06003390 RID: 13200 RVA: 0x00159379 File Offset: 0x00157779
	[CompilerGenerated]
	private static string <ReleaseableDamage>m__1(BattleDamage t)
	{
		return t.Target.GetId();
	}

	// Token: 0x06003391 RID: 13201 RVA: 0x00159386 File Offset: 0x00157786
	[CompilerGenerated]
	private static bool <ReleaseableDamage>m__2(DamageComponent d)
	{
		return d.IsDirectDamage;
	}

	// Token: 0x06003392 RID: 13202 RVA: 0x0015938E File Offset: 0x0015778E
	[CompilerGenerated]
	private static bool <ReleaseableDamage>m__3(BattleDamage d)
	{
		return d.Damages.Any((DamageComponent dd) => dd.IsDirectDamage) && d.DamageSource is AdventureUnitSkill;
	}

	// Token: 0x06003393 RID: 13203 RVA: 0x001593CE File Offset: 0x001577CE
	[CompilerGenerated]
	private static IBattleUnit <ReleaseableDamage>m__4(BattleDamage b)
	{
		return b.Target;
	}

	// Token: 0x06003394 RID: 13204 RVA: 0x001593D6 File Offset: 0x001577D6
	[CompilerGenerated]
	private static bool <ReleaseableDamage>m__5(DamageComponent d)
	{
		return d.IsDirectDamage;
	}

	// Token: 0x06003395 RID: 13205 RVA: 0x001593DE File Offset: 0x001577DE
	[CompilerGenerated]
	private static bool <ReleaseableDamage>m__6(DamageComponent dd)
	{
		return dd.IsDirectDamage;
	}

	// Token: 0x06003396 RID: 13206 RVA: 0x001593E6 File Offset: 0x001577E6
	[CompilerGenerated]
	private static bool <ReleaseableDamage>m__7(DamageComponent dd)
	{
		return dd.IsDirectDamage;
	}

	// Token: 0x04002829 RID: 10281
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ReleaseStatus <Status>k__BackingField;

	// Token: 0x0400282A RID: 10282
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<BattleDamage> <BattleDamages>k__BackingField;

	// Token: 0x0400282B RID: 10283
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <Dealer>k__BackingField;

	// Token: 0x0400282C RID: 10284
	[CompilerGenerated]
	private static Func<BattleDamage, bool> <>f__am$cache0;

	// Token: 0x0400282D RID: 10285
	[CompilerGenerated]
	private static Func<BattleDamage, string> <>f__am$cache1;

	// Token: 0x0400282E RID: 10286
	[CompilerGenerated]
	private static Func<DamageComponent, bool> <>f__am$cache2;

	// Token: 0x0400282F RID: 10287
	[CompilerGenerated]
	private static Func<BattleDamage, bool> <>f__am$cache3;

	// Token: 0x04002830 RID: 10288
	[CompilerGenerated]
	private static Func<BattleDamage, IBattleUnit> <>f__am$cache4;

	// Token: 0x04002831 RID: 10289
	[CompilerGenerated]
	private static Func<DamageComponent, bool> <>f__am$cache5;

	// Token: 0x04002832 RID: 10290
	[CompilerGenerated]
	private static Func<DamageComponent, bool> <>f__am$cache6;

	// Token: 0x04002833 RID: 10291
	[CompilerGenerated]
	private static Func<DamageComponent, bool> <>f__am$cache7;

	// Token: 0x02000E8A RID: 3722
	[CompilerGenerated]
	private sealed class <Release>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005DA9 RID: 23977 RVA: 0x001593EE File Offset: 0x001577EE
		[DebuggerHidden]
		public <Release>c__Iterator0()
		{
		}

		// Token: 0x06005DAA RID: 23978 RVA: 0x001593F8 File Offset: 0x001577F8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				base.Status = ReleaseStatus.Releasing;
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(base.Dealer, AdventureEventType.UnitReleasesDamage, this)).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_112;
			case 3u:
				goto IL_262;
			case 4u:
				goto IL_386;
			case 5u:
				goto IL_421;
			case 6u:
				goto IL_7A7;
			case 7u:
				Block_15:
				try
				{
					switch (num)
					{
					}
					if (enumerator12.MoveNext())
					{
						_7 = enumerator12.Current;
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
						if ((disposable7 = (enumerator12 as IDisposable)) != null)
						{
							disposable7.Dispose();
						}
					}
				}
				this.$PC = -1;
				return false;
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
			enumerator2 = base.BattleDamages.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_112:
				switch (num)
				{
				case 2u:
					Block_23:
					try
					{
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
					break;
				}
				if (enumerator2.MoveNext())
				{
					battleDamage = enumerator2.Current;
					enumerator3 = battleDamage.Target.ReceivesDamage(battleDamage).GetEnumerator();
					num = 4294967293u;
					goto Block_23;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
			base.Status = ReleaseStatus.Released;
			toRemove = (from ef in base.Dealer.BattleEffects
			where ef.EffectSourceIdentityCode.StartsWith(AttributeModificationEffect.PostDamageReleaseRemovePartial)
			select ef).ToList<BattleEffectBase>();
			enumerator4 = toRemove.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_262:
				switch (num)
				{
				case 3u:
					Block_34:
					try
					{
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
					break;
				}
				if (enumerator4.MoveNext())
				{
					battleEffectBase = enumerator4.Current;
					enumerator5 = base.Dealer.LooseSkillEffect(battleEffectBase, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
					num = 4294967293u;
					goto Block_34;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator4).Dispose();
				}
			}
			enumerator6 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(base.Dealer, AdventureEventType.DamageReleased, this)).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_386:
				switch (num)
				{
				}
				if (enumerator6.MoveNext())
				{
					_4 = enumerator6.Current;
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
					if ((disposable4 = (enumerator6 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			enumerator7 = base.BattleDamages.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_421:
				switch (num)
				{
				case 5u:
					Block_54:
					try
					{
						switch (num)
						{
						}
						if (enumerator8.MoveNext())
						{
							_5 = enumerator8.Current;
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
							if ((disposable5 = (enumerator8 as IDisposable)) != null)
							{
								disposable5.Dispose();
							}
						}
					}
					break;
				}
				while (enumerator7.MoveNext())
				{
					battleDamage2 = enumerator7.Current;
					if (battleDamage2.Target.IsPlayer && battleDamage2.Target.CurrentAdventure.RunePower != null)
					{
						totalNumberOfValidDamages = battleDamage2.Damages.Count((DamageComponent d) => d.IsDirectDamage && !d.IsReflectedDamage);
						directDamageGhostRate = battleDamage2.Target.CurrentAdventure.RunePower.GetRate(SpecialEffectType.GhostBreathsDirectDamageReceiveCollection);
						enumerator8 = battleDamage2.Target.CurrentAdventure.RunePower.AddPower(RunePowerType.GhostBreaths, directDamageGhostRate * totalNumberOfValidDamages, battleDamage2.Target).GetEnumerator();
						num = 4294967293u;
						goto Block_54;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator7).Dispose();
				}
			}
			if (!base.BattleDamages.All((BattleDamage d) => d.DamageSource is AdventureUnitSkill))
			{
				goto IL_829;
			}
			starfalls = base.Dealer.SpecialEffects.OfType<StarfallData>().ToList<StarfallData>();
			if (!starfalls.Any<StarfallData>())
			{
				goto IL_829;
			}
			targets = base.Dealer.GetLiveEnemyTargets(false, true);
			if (!targets.Any<IBattleUnit>())
			{
				goto IL_829;
			}
			damages = new List<BattleDamage>();
			enumerator9 = targets.GetEnumerator();
			try
			{
				while (enumerator9.MoveNext())
				{
					IBattleUnit target = enumerator9.Current;
					List<DamagePotionValue> list = new List<DamagePotionValue>();
					foreach (StarfallData starfallData in starfalls)
					{
						if ((double)UnityEngine.Random.value <= starfallData.Chance)
						{
							list.Add(new DamagePotionValue(base.Dealer, target, starfallData.DamageType, starfallData.DamagePercentage));
						}
					}
					if (list.Any<DamagePotionValue>())
					{
						damages.Add(new BattleDamage(target, new SpecialEffectTriggerSource(base.Dealer, SpecialEffectType.Starfall), new List<DamageComponentValue>
						{
							new DamageComponentValue(list, target, base.Dealer, true, false)
						}));
					}
				}
			}
			finally
			{
				((IDisposable)enumerator9).Dispose();
			}
			if (!damages.Any<BattleDamage>())
			{
				goto IL_829;
			}
			releaseable = new ReleaseableDamage(damages, base.Dealer);
			enumerator11 = releaseable.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_7A7:
				switch (num)
				{
				}
				if (enumerator11.MoveNext())
				{
					_6 = enumerator11.Current;
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
					if ((disposable6 = (enumerator11 as IDisposable)) != null)
					{
						disposable6.Dispose();
					}
				}
			}
			IL_829:
			enumerator12 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(base.Dealer, AdventureEventType.DamageReleaseProcessCompleted, this)).GetEnumerator();
			num = 4294967293u;
			goto Block_15;
		}

		// Token: 0x1700138E RID: 5006
		// (get) Token: 0x06005DAB RID: 23979 RVA: 0x00159E10 File Offset: 0x00158210
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700138F RID: 5007
		// (get) Token: 0x06005DAC RID: 23980 RVA: 0x00159E18 File Offset: 0x00158218
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005DAD RID: 23981 RVA: 0x00159E20 File Offset: 0x00158220
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
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
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
						if ((disposable3 = (enumerator5 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator4).Dispose();
				}
				break;
			case 4u:
				try
				{
				}
				finally
				{
					if ((disposable4 = (enumerator6 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			case 5u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable5 = (enumerator8 as IDisposable)) != null)
						{
							disposable5.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator7).Dispose();
				}
				break;
			case 6u:
				try
				{
				}
				finally
				{
					if ((disposable6 = (enumerator11 as IDisposable)) != null)
					{
						disposable6.Dispose();
					}
				}
				break;
			case 7u:
				try
				{
				}
				finally
				{
					if ((disposable7 = (enumerator12 as IDisposable)) != null)
					{
						disposable7.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005DAE RID: 23982 RVA: 0x0015A074 File Offset: 0x00158474
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005DAF RID: 23983 RVA: 0x0015A07B File Offset: 0x0015847B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005DB0 RID: 23984 RVA: 0x0015A084 File Offset: 0x00158484
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ReleaseableDamage.<Release>c__Iterator0 <Release>c__Iterator = new ReleaseableDamage.<Release>c__Iterator0();
			<Release>c__Iterator.$this = this;
			return <Release>c__Iterator;
		}

		// Token: 0x06005DB1 RID: 23985 RVA: 0x0015A0B8 File Offset: 0x001584B8
		private static bool <>m__0(BattleEffectBase ef)
		{
			return ef.EffectSourceIdentityCode.StartsWith(AttributeModificationEffect.PostDamageReleaseRemovePartial);
		}

		// Token: 0x06005DB2 RID: 23986 RVA: 0x0015A0CA File Offset: 0x001584CA
		private static bool <>m__1(DamageComponent d)
		{
			return d.IsDirectDamage && !d.IsReflectedDamage;
		}

		// Token: 0x06005DB3 RID: 23987 RVA: 0x0015A0E3 File Offset: 0x001584E3
		private static bool <>m__2(BattleDamage d)
		{
			return d.DamageSource is AdventureUnitSkill;
		}

		// Token: 0x040050FF RID: 20735
		internal IEnumerator $locvar0;

		// Token: 0x04005100 RID: 20736
		internal object <_>__1;

		// Token: 0x04005101 RID: 20737
		internal IDisposable $locvar1;

		// Token: 0x04005102 RID: 20738
		internal List<BattleDamage>.Enumerator $locvar2;

		// Token: 0x04005103 RID: 20739
		internal BattleDamage <battleDamage>__2;

		// Token: 0x04005104 RID: 20740
		internal IEnumerator $locvar3;

		// Token: 0x04005105 RID: 20741
		internal object <_>__3;

		// Token: 0x04005106 RID: 20742
		internal IDisposable $locvar4;

		// Token: 0x04005107 RID: 20743
		internal List<BattleEffectBase> <toRemove>__0;

		// Token: 0x04005108 RID: 20744
		internal List<BattleEffectBase>.Enumerator $locvar5;

		// Token: 0x04005109 RID: 20745
		internal BattleEffectBase <battleEffectBase>__4;

		// Token: 0x0400510A RID: 20746
		internal IEnumerator $locvar6;

		// Token: 0x0400510B RID: 20747
		internal object <_>__5;

		// Token: 0x0400510C RID: 20748
		internal IDisposable $locvar7;

		// Token: 0x0400510D RID: 20749
		internal IEnumerator $locvar8;

		// Token: 0x0400510E RID: 20750
		internal object <_>__6;

		// Token: 0x0400510F RID: 20751
		internal IDisposable $locvar9;

		// Token: 0x04005110 RID: 20752
		internal List<BattleDamage>.Enumerator $locvarA;

		// Token: 0x04005111 RID: 20753
		internal BattleDamage <battleDamage>__7;

		// Token: 0x04005112 RID: 20754
		internal int <totalNumberOfValidDamages>__8;

		// Token: 0x04005113 RID: 20755
		internal int <directDamageGhostRate>__8;

		// Token: 0x04005114 RID: 20756
		internal IEnumerator $locvarB;

		// Token: 0x04005115 RID: 20757
		internal object <_>__9;

		// Token: 0x04005116 RID: 20758
		internal IDisposable $locvarC;

		// Token: 0x04005117 RID: 20759
		internal List<StarfallData> <starfalls>__10;

		// Token: 0x04005118 RID: 20760
		internal List<IBattleUnit> <targets>__11;

		// Token: 0x04005119 RID: 20761
		internal List<BattleDamage> <damages>__12;

		// Token: 0x0400511A RID: 20762
		internal List<IBattleUnit>.Enumerator $locvarD;

		// Token: 0x0400511B RID: 20763
		internal ReleaseableDamage <releaseable>__13;

		// Token: 0x0400511C RID: 20764
		internal IEnumerator $locvarF;

		// Token: 0x0400511D RID: 20765
		internal object <_>__14;

		// Token: 0x0400511E RID: 20766
		internal IDisposable $locvar10;

		// Token: 0x0400511F RID: 20767
		internal IEnumerator $locvar11;

		// Token: 0x04005120 RID: 20768
		internal object <_>__15;

		// Token: 0x04005121 RID: 20769
		internal IDisposable $locvar12;

		// Token: 0x04005122 RID: 20770
		internal ReleaseableDamage $this;

		// Token: 0x04005123 RID: 20771
		internal object $current;

		// Token: 0x04005124 RID: 20772
		internal bool $disposing;

		// Token: 0x04005125 RID: 20773
		internal int $PC;

		// Token: 0x04005126 RID: 20774
		private static Func<BattleEffectBase, bool> <>f__am$cache0;

		// Token: 0x04005127 RID: 20775
		private static Func<DamageComponent, bool> <>f__am$cache1;

		// Token: 0x04005128 RID: 20776
		private static Func<BattleDamage, bool> <>f__am$cache2;
	}
}
