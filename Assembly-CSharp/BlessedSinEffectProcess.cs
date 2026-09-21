using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008B1 RID: 2225
public class BlessedSinEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003ED6 RID: 16086 RVA: 0x001855BC File Offset: 0x001839BC
	public BlessedSinEffectProcess()
	{
	}

	// Token: 0x17000B24 RID: 2852
	// (get) Token: 0x06003ED7 RID: 16087 RVA: 0x001855CC File Offset: 0x001839CC
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B25 RID: 2853
	// (get) Token: 0x06003ED8 RID: 16088 RVA: 0x001855D4 File Offset: 0x001839D4
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.BattleEncounterStarts
			};
		}
	}

	// Token: 0x06003ED9 RID: 16089 RVA: 0x001855F0 File Offset: 0x001839F0
	public override IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.BattleEncounterStarts)
		{
			BattleEncounter battleEncounter = evt.EventTriggeringUnit.CurrentEncounter as BattleEncounter;
			BlessedSinData data = specialEffectData as BlessedSinData;
			if (battleEncounter != null && data != null)
			{
				if (battleEncounter.EnemyUnits.All((IBattleUnit u) => !u.IsBoss()))
				{
					foreach (IBattleUnit enemy in battleEncounter.EnemyUnits)
					{
						IEnumerator enumerator2 = enemy.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(enemy, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = AttributeType.LifeOnHit,
								ModificationType = ModificationType.Addition,
								Value = data.LifeOnHitRate,
								AttributeModifierType = AttributeModifierType.Skill,
								Key = string.Empty
							}
						}, AttributeModificationEffect.BlessedSinKey, new int?(1), null, null, false, false, false), false).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x06003EDA RID: 16090 RVA: 0x0018561C File Offset: 0x00183A1C
	public override IEnumerable AsAdventureEffectPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IEncounter encounter)
	{
		BlessedSinData data = specialEffectData as BlessedSinData;
		BattleEncounter battleEncounter = encounter as BattleEncounter;
		if (data != null && battleEncounter != null)
		{
			if (battleEncounter.EnemyUnits.All((IBattleUnit e) => !e.IsBoss()))
			{
				List<IBattleUnit> targets = new List<IBattleUnit>();
				targets.AddRange((from u in battleEncounter.EnemyUnits
				where u.Status == BattleUnitStatus.Active
				select u).ToList<IBattleUnit>());
				targets.AddRange((from u in battleEncounter.PlayerUnits
				where u.Status == BattleUnitStatus.Active
				select u).ToList<IBattleUnit>());
				IBattleUnit triggerUnit = encounter.PlayerUnits.FirstOrDefault<IBattleUnit>();
				ReleaseableDamage releaseableDamage = new ReleaseableDamage((from t in targets
				select new BattleDamage(t, new SpecialEffectTriggerSource(encounter.PlayerUnits.FirstOrDefault<IBattleUnit>(), data.GetSpecialEffectType()), new List<DamageComponentValue>
				{
					new DamageComponentValue((from ot in data.DamageTypes
					select DamagePotionValue.CreateRawValuedDamageComponent(t, triggerUnit, OutputType.RealDamage, data.DamagePerSecondPerType)).ToList<DamagePotionValue>(), t, triggerUnit, false, false)
				})).ToList<BattleDamage>(), triggerUnit);
				IEnumerator enumerator = releaseableDamage.Release().GetEnumerator();
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

	// Token: 0x04002F69 RID: 12137
	private readonly SpecialEffectType _correspondingEffectType = SpecialEffectType.BlessedSinEffect;

	// Token: 0x02000F1B RID: 3867
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060061B8 RID: 25016 RVA: 0x00185646 File Offset: 0x00183A46
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator0()
		{
		}

		// Token: 0x060061B9 RID: 25017 RVA: 0x00185650 File Offset: 0x00183A50
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evt.EventType != AdventureEventType.BattleEncounterStarts)
				{
					goto IL_223;
				}
				battleEncounter = (evt.EventTriggeringUnit.CurrentEncounter as BattleEncounter);
				data = (specialEffectData as BlessedSinData);
				if (battleEncounter == null || data == null)
				{
					goto IL_223;
				}
				if (!battleEncounter.EnemyUnits.All((IBattleUnit u) => !u.IsBoss()))
				{
					goto IL_223;
				}
				enumerator = battleEncounter.EnemyUnits.GetEnumerator();
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
					Block_9:
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
					enemy = enumerator.Current;
					enumerator2 = enemy.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(enemy, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.LifeOnHit,
							ModificationType = ModificationType.Addition,
							Value = data.LifeOnHitRate,
							AttributeModifierType = AttributeModifierType.Skill,
							Key = string.Empty
						}
					}, AttributeModificationEffect.BlessedSinKey, new int?(1), null, null, false, false, false), false).GetEnumerator();
					num = 4294967293u;
					goto Block_9;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_223:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001477 RID: 5239
		// (get) Token: 0x060061BA RID: 25018 RVA: 0x001858C0 File Offset: 0x00183CC0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001478 RID: 5240
		// (get) Token: 0x060061BB RID: 25019 RVA: 0x001858C8 File Offset: 0x00183CC8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060061BC RID: 25020 RVA: 0x001858D0 File Offset: 0x00183CD0
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

		// Token: 0x060061BD RID: 25021 RVA: 0x00185964 File Offset: 0x00183D64
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060061BE RID: 25022 RVA: 0x0018596B File Offset: 0x00183D6B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060061BF RID: 25023 RVA: 0x00185974 File Offset: 0x00183D74
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BlessedSinEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <AsAdventureEffectProcess>c__Iterator = new BlessedSinEffectProcess.<AsAdventureEffectProcess>c__Iterator0();
			<AsAdventureEffectProcess>c__Iterator.evt = evt;
			<AsAdventureEffectProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsAdventureEffectProcess>c__Iterator;
		}

		// Token: 0x060061C0 RID: 25024 RVA: 0x001859B4 File Offset: 0x00183DB4
		private static bool <>m__0(IBattleUnit u)
		{
			return !u.IsBoss();
		}

		// Token: 0x04005791 RID: 22417
		internal BroadcastEvent evt;

		// Token: 0x04005792 RID: 22418
		internal BattleEncounter <battleEncounter>__1;

		// Token: 0x04005793 RID: 22419
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005794 RID: 22420
		internal BlessedSinData <data>__1;

		// Token: 0x04005795 RID: 22421
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04005796 RID: 22422
		internal IBattleUnit <enemy>__2;

		// Token: 0x04005797 RID: 22423
		internal IEnumerator $locvar1;

		// Token: 0x04005798 RID: 22424
		internal object <_>__3;

		// Token: 0x04005799 RID: 22425
		internal IDisposable $locvar2;

		// Token: 0x0400579A RID: 22426
		internal object $current;

		// Token: 0x0400579B RID: 22427
		internal bool $disposing;

		// Token: 0x0400579C RID: 22428
		internal int $PC;

		// Token: 0x0400579D RID: 22429
		private static Func<IBattleUnit, bool> <>f__am$cache0;
	}

	// Token: 0x02000F1C RID: 3868
	[CompilerGenerated]
	private sealed class <AsAdventureEffectPerSecondProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060061C1 RID: 25025 RVA: 0x001859BF File Offset: 0x00183DBF
		[DebuggerHidden]
		public <AsAdventureEffectPerSecondProcess>c__Iterator1()
		{
		}

		// Token: 0x060061C2 RID: 25026 RVA: 0x001859C8 File Offset: 0x00183DC8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				<AsAdventureEffectPerSecondProcess>c__AnonStorey = new BlessedSinEffectProcess.<AsAdventureEffectPerSecondProcess>c__Iterator1.<AsAdventureEffectPerSecondProcess>c__AnonStorey2();
				<AsAdventureEffectPerSecondProcess>c__AnonStorey.encounter = encounter;
				<AsAdventureEffectPerSecondProcess>c__AnonStorey.data = (specialEffectData as BlessedSinData);
				battleEncounter = (<AsAdventureEffectPerSecondProcess>c__AnonStorey.encounter as BattleEncounter);
				if (<AsAdventureEffectPerSecondProcess>c__AnonStorey.data == null || battleEncounter == null)
				{
					goto IL_257;
				}
				if (!battleEncounter.EnemyUnits.All((IBattleUnit e) => !e.IsBoss()))
				{
					goto IL_257;
				}
				targets = new List<IBattleUnit>();
				targets.AddRange((from u in battleEncounter.EnemyUnits
				where u.Status == BattleUnitStatus.Active
				select u).ToList<IBattleUnit>());
				targets.AddRange((from u in battleEncounter.PlayerUnits
				where u.Status == BattleUnitStatus.Active
				select u).ToList<IBattleUnit>());
				IBattleUnit triggerUnit = <AsAdventureEffectPerSecondProcess>c__AnonStorey.encounter.PlayerUnits.FirstOrDefault<IBattleUnit>();
				releaseableDamage = new ReleaseableDamage((from t in targets
				select new BattleDamage(t, new SpecialEffectTriggerSource(<AsAdventureEffectPerSecondProcess>c__AnonStorey.encounter.PlayerUnits.FirstOrDefault<IBattleUnit>(), <AsAdventureEffectPerSecondProcess>c__AnonStorey.data.GetSpecialEffectType()), new List<DamageComponentValue>
				{
					new DamageComponentValue((from ot in <AsAdventureEffectPerSecondProcess>c__AnonStorey.data.DamageTypes
					select DamagePotionValue.CreateRawValuedDamageComponent(t, triggerUnit, OutputType.RealDamage, <AsAdventureEffectPerSecondProcess>c__AnonStorey.data.DamagePerSecondPerType)).ToList<DamagePotionValue>(), t, triggerUnit, false, false)
				})).ToList<BattleDamage>(), triggerUnit);
				enumerator = releaseableDamage.Release().GetEnumerator();
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
			IL_257:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001479 RID: 5241
		// (get) Token: 0x060061C3 RID: 25027 RVA: 0x00185C48 File Offset: 0x00184048
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700147A RID: 5242
		// (get) Token: 0x060061C4 RID: 25028 RVA: 0x00185C50 File Offset: 0x00184050
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060061C5 RID: 25029 RVA: 0x00185C58 File Offset: 0x00184058
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

		// Token: 0x060061C6 RID: 25030 RVA: 0x00185CC8 File Offset: 0x001840C8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060061C7 RID: 25031 RVA: 0x00185CCF File Offset: 0x001840CF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060061C8 RID: 25032 RVA: 0x00185CD8 File Offset: 0x001840D8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BlessedSinEffectProcess.<AsAdventureEffectPerSecondProcess>c__Iterator1 <AsAdventureEffectPerSecondProcess>c__Iterator = new BlessedSinEffectProcess.<AsAdventureEffectPerSecondProcess>c__Iterator1();
			<AsAdventureEffectPerSecondProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsAdventureEffectPerSecondProcess>c__Iterator.encounter = encounter;
			return <AsAdventureEffectPerSecondProcess>c__Iterator;
		}

		// Token: 0x060061C9 RID: 25033 RVA: 0x00185D18 File Offset: 0x00184118
		private static bool <>m__0(IBattleUnit e)
		{
			return !e.IsBoss();
		}

		// Token: 0x060061CA RID: 25034 RVA: 0x00185D23 File Offset: 0x00184123
		private static bool <>m__1(IBattleUnit u)
		{
			return u.Status == BattleUnitStatus.Active;
		}

		// Token: 0x060061CB RID: 25035 RVA: 0x00185D2E File Offset: 0x0018412E
		private static bool <>m__2(IBattleUnit u)
		{
			return u.Status == BattleUnitStatus.Active;
		}

		// Token: 0x0400579E RID: 22430
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x0400579F RID: 22431
		internal IEncounter encounter;

		// Token: 0x040057A0 RID: 22432
		internal BattleEncounter <battleEncounter>__0;

		// Token: 0x040057A1 RID: 22433
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x040057A2 RID: 22434
		internal ReleaseableDamage <releaseableDamage>__1;

		// Token: 0x040057A3 RID: 22435
		internal IEnumerator $locvar0;

		// Token: 0x040057A4 RID: 22436
		internal object <_>__2;

		// Token: 0x040057A5 RID: 22437
		internal IDisposable $locvar1;

		// Token: 0x040057A6 RID: 22438
		internal object $current;

		// Token: 0x040057A7 RID: 22439
		internal bool $disposing;

		// Token: 0x040057A8 RID: 22440
		internal int $PC;

		// Token: 0x040057A9 RID: 22441
		private BlessedSinEffectProcess.<AsAdventureEffectPerSecondProcess>c__Iterator1.<AsAdventureEffectPerSecondProcess>c__AnonStorey2 $locvar2;

		// Token: 0x040057AA RID: 22442
		private static Func<IBattleUnit, bool> <>f__am$cache0;

		// Token: 0x040057AB RID: 22443
		private BlessedSinEffectProcess.<AsAdventureEffectPerSecondProcess>c__Iterator1.<AsAdventureEffectPerSecondProcess>c__AnonStorey4 $locvar3;

		// Token: 0x040057AC RID: 22444
		private static Func<IBattleUnit, bool> <>f__am$cache1;

		// Token: 0x040057AD RID: 22445
		private static Func<IBattleUnit, bool> <>f__am$cache2;

		// Token: 0x02000F1D RID: 3869
		private sealed class <AsAdventureEffectPerSecondProcess>c__AnonStorey2
		{
			// Token: 0x060061CC RID: 25036 RVA: 0x00185D39 File Offset: 0x00184139
			public <AsAdventureEffectPerSecondProcess>c__AnonStorey2()
			{
			}

			// Token: 0x040057AE RID: 22446
			internal IEncounter encounter;

			// Token: 0x040057AF RID: 22447
			internal BlessedSinData data;
		}

		// Token: 0x02000F1E RID: 3870
		private sealed class <AsAdventureEffectPerSecondProcess>c__AnonStorey4
		{
			// Token: 0x060061CD RID: 25037 RVA: 0x00185D41 File Offset: 0x00184141
			public <AsAdventureEffectPerSecondProcess>c__AnonStorey4()
			{
			}

			// Token: 0x060061CE RID: 25038 RVA: 0x00185D4C File Offset: 0x0018414C
			internal BattleDamage <>m__0(IBattleUnit t)
			{
				BlessedSinEffectProcess.<AsAdventureEffectPerSecondProcess>c__Iterator1.<AsAdventureEffectPerSecondProcess>c__AnonStorey2 <>f__ref$2 = this.<>f__ref$2;
				BlessedSinEffectProcess.<AsAdventureEffectPerSecondProcess>c__Iterator1.<AsAdventureEffectPerSecondProcess>c__AnonStorey4 <>f__ref$4 = this;
				IBattleUnit t = t2;
				return new BattleDamage(t, new SpecialEffectTriggerSource(this.<>f__ref$2.encounter.PlayerUnits.FirstOrDefault<IBattleUnit>(), this.<>f__ref$2.data.GetSpecialEffectType()), new List<DamageComponentValue>
				{
					new DamageComponentValue((from ot in this.<>f__ref$2.data.DamageTypes
					select DamagePotionValue.CreateRawValuedDamageComponent(t, <>f__ref$4.triggerUnit, OutputType.RealDamage, <>f__ref$2.data.DamagePerSecondPerType)).ToList<DamagePotionValue>(), t, this.triggerUnit, false, false)
				});
			}

			// Token: 0x040057B0 RID: 22448
			internal IBattleUnit triggerUnit;

			// Token: 0x040057B1 RID: 22449
			internal BlessedSinEffectProcess.<AsAdventureEffectPerSecondProcess>c__Iterator1 <>f__ref$1;

			// Token: 0x040057B2 RID: 22450
			internal BlessedSinEffectProcess.<AsAdventureEffectPerSecondProcess>c__Iterator1.<AsAdventureEffectPerSecondProcess>c__AnonStorey2 <>f__ref$2;

			// Token: 0x02000F1F RID: 3871
			private sealed class <AsAdventureEffectPerSecondProcess>c__AnonStorey3
			{
				// Token: 0x060061CF RID: 25039 RVA: 0x00185DF4 File Offset: 0x001841F4
				public <AsAdventureEffectPerSecondProcess>c__AnonStorey3()
				{
				}

				// Token: 0x060061D0 RID: 25040 RVA: 0x00185DFC File Offset: 0x001841FC
				internal DamagePotionValue <>m__0(OutputType ot)
				{
					return DamagePotionValue.CreateRawValuedDamageComponent(this.t, this.<>f__ref$4.triggerUnit, OutputType.RealDamage, this.<>f__ref$2.data.DamagePerSecondPerType);
				}

				// Token: 0x040057B3 RID: 22451
				internal IBattleUnit t;

				// Token: 0x040057B4 RID: 22452
				internal BlessedSinEffectProcess.<AsAdventureEffectPerSecondProcess>c__Iterator1.<AsAdventureEffectPerSecondProcess>c__AnonStorey2 <>f__ref$2;

				// Token: 0x040057B5 RID: 22453
				internal BlessedSinEffectProcess.<AsAdventureEffectPerSecondProcess>c__Iterator1.<AsAdventureEffectPerSecondProcess>c__AnonStorey4 <>f__ref$4;
			}
		}
	}
}
