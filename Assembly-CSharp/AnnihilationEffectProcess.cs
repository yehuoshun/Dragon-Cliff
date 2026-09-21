using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008AB RID: 2219
public class AnnihilationEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003EBC RID: 16060 RVA: 0x00183768 File Offset: 0x00181B68
	public AnnihilationEffectProcess()
	{
	}

	// Token: 0x17000B18 RID: 2840
	// (get) Token: 0x06003EBD RID: 16061 RVA: 0x0018379B File Offset: 0x00181B9B
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B19 RID: 2841
	// (get) Token: 0x06003EBE RID: 16062 RVA: 0x001837A3 File Offset: 0x00181BA3
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return this._correspondingEvents;
		}
	}

	// Token: 0x06003EBF RID: 16063 RVA: 0x001837AC File Offset: 0x00181BAC
	public override IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.BattleEncounterStarts && specialEffectData is AnnihilationData)
		{
			AnnihilationData data = specialEffectData as AnnihilationData;
			IEnumerable<IBattleUnit> enemyUnits = evt.EventTriggeringUnit.CurrentEncounter.EnemyUnits;
			if (AnnihilationEffectProcess.<>f__mg$cache0 == null)
			{
				AnnihilationEffectProcess.<>f__mg$cache0 = new Func<IBattleUnit, bool>(BattleUnitExtensions.IsAliveInBattle);
			}
			List<IBattleUnit> enemies = enemyUnits.Where(AnnihilationEffectProcess.<>f__mg$cache0).ToList<IBattleUnit>();
			IEnumerable<AdventurerBattleUnit> adventurers = evt.EventTriggeringUnit.CurrentAdventure.Adventurers;
			if (AnnihilationEffectProcess.<>f__mg$cache1 == null)
			{
				AnnihilationEffectProcess.<>f__mg$cache1 = new Func<AdventurerBattleUnit, bool>(BattleUnitExtensions.IsAliveInBattle);
			}
			var highestHit = (from u in adventurers.Where(AnnihilationEffectProcess.<>f__mg$cache1)
			select new
			{
				value = u.GetAttributeValue_Final(AttributeType.EffectHitRating, AttributeRetrievalLevel.Skill)
			}).FirstOrDefault();
			double hit = (highestHit == null) ? 0.0 : highestHit.value;
			foreach (IBattleUnit battleUnit in enemies)
			{
				IEnumerator enumerator2 = battleUnit.ApplySkillEffect(new AnnihilationEffect(data.EffectResistanceReductionRate, data.OutputReductionRate, evt.EventTriggeringUnit), false).GetEnumerator();
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
				if (hit > 0.0)
				{
					IEnumerator enumerator3 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(evt.EventTriggeringUnit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.EffectResistanceRating,
							ModificationType = ModificationType.Addition,
							Value = -hit,
							AttributeModifierType = AttributeModifierType.Skill,
							Key = string.Empty
						}
					}, "annihiliationdecayuniqueeff", new int?(1), null, null, false, false), false).GetEnumerator();
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
			}
		}
		yield break;
	}

	// Token: 0x04002F65 RID: 12133
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.Annihilation;

	// Token: 0x04002F66 RID: 12134
	private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
	{
		AdventureEventType.BattleEncounterStarts
	};

	// Token: 0x04002F67 RID: 12135
	[CompilerGenerated]
	private static Func<IBattleUnit, bool> <>f__mg$cache0;

	// Token: 0x04002F68 RID: 12136
	[CompilerGenerated]
	private static Func<AdventurerBattleUnit, bool> <>f__mg$cache1;

	// Token: 0x02000F13 RID: 3859
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600617D RID: 24957 RVA: 0x001837D6 File Offset: 0x00181BD6
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator0()
		{
		}

		// Token: 0x0600617E RID: 24958 RVA: 0x001837E0 File Offset: 0x00181BE0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				if (evt.EventType != AdventureEventType.BattleEncounterStarts || !(specialEffectData is AnnihilationData))
				{
					goto IL_37E;
				}
				data = (specialEffectData as AnnihilationData);
				IEnumerable<IBattleUnit> enemyUnits = evt.EventTriggeringUnit.CurrentEncounter.EnemyUnits;
				if (AnnihilationEffectProcess.<>f__mg$cache0 == null)
				{
					AnnihilationEffectProcess.<>f__mg$cache0 = new Func<IBattleUnit, bool>(BattleUnitExtensions.IsAliveInBattle);
				}
				enemies = enemyUnits.Where(AnnihilationEffectProcess.<>f__mg$cache0).ToList<IBattleUnit>();
				IEnumerable<AdventurerBattleUnit> adventurers = evt.EventTriggeringUnit.CurrentAdventure.Adventurers;
				if (AnnihilationEffectProcess.<>f__mg$cache1 == null)
				{
					AnnihilationEffectProcess.<>f__mg$cache1 = new Func<AdventurerBattleUnit, bool>(BattleUnitExtensions.IsAliveInBattle);
				}
				highestHit = (from u in adventurers.Where(AnnihilationEffectProcess.<>f__mg$cache1)
				select new
				{
					value = u.GetAttributeValue_Final(AttributeType.EffectHitRating, AttributeRetrievalLevel.Skill)
				}).FirstOrDefault();
				hit = ((highestHit == null) ? 0.0 : highestHit.value);
				enumerator = enemies.GetEnumerator();
				num = 4294967293u;
				break;
			}
			case 1u:
			case 2u:
				break;
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
					if (hit <= 0.0)
					{
						goto IL_353;
					}
					enumerator3 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(evt.EventTriggeringUnit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.EffectResistanceRating,
							ModificationType = ModificationType.Addition,
							Value = -hit,
							AttributeModifierType = AttributeModifierType.Skill,
							Key = string.Empty
						}
					}, "annihiliationdecayuniqueeff", new int?(1), null, null, false, false), false).GetEnumerator();
					num = 4294967293u;
					break;
				case 2u:
					break;
				default:
					goto IL_353;
				}
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
				IL_353:
				if (enumerator.MoveNext())
				{
					battleUnit = enumerator.Current;
					enumerator2 = battleUnit.ApplySkillEffect(new AnnihilationEffect(data.EffectResistanceReductionRate, data.OutputReductionRate, evt.EventTriggeringUnit), false).GetEnumerator();
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
			IL_37E:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700146B RID: 5227
		// (get) Token: 0x0600617F RID: 24959 RVA: 0x00183BC4 File Offset: 0x00181FC4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700146C RID: 5228
		// (get) Token: 0x06006180 RID: 24960 RVA: 0x00183BCC File Offset: 0x00181FCC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006181 RID: 24961 RVA: 0x00183BD4 File Offset: 0x00181FD4
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
			case 2u:
				try
				{
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
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06006182 RID: 24962 RVA: 0x00183CBC File Offset: 0x001820BC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006183 RID: 24963 RVA: 0x00183CC3 File Offset: 0x001820C3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006184 RID: 24964 RVA: 0x00183CCC File Offset: 0x001820CC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			AnnihilationEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <AsAdventureEffectProcess>c__Iterator = new AnnihilationEffectProcess.<AsAdventureEffectProcess>c__Iterator0();
			<AsAdventureEffectProcess>c__Iterator.evt = evt;
			<AsAdventureEffectProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsAdventureEffectProcess>c__Iterator;
		}

		// Token: 0x06006185 RID: 24965 RVA: 0x00183D0C File Offset: 0x0018210C
		private static <>__AnonType6<double> <>m__0(AdventurerBattleUnit u)
		{
			return new
			{
				value = u.GetAttributeValue_Final(AttributeType.EffectHitRating, AttributeRetrievalLevel.Skill)
			};
		}

		// Token: 0x04005729 RID: 22313
		internal BroadcastEvent evt;

		// Token: 0x0400572A RID: 22314
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x0400572B RID: 22315
		internal AnnihilationData <data>__1;

		// Token: 0x0400572C RID: 22316
		internal List<IBattleUnit> <enemies>__1;

		// Token: 0x0400572D RID: 22317
		internal <>__AnonType6<double> <highestHit>__1;

		// Token: 0x0400572E RID: 22318
		internal double <hit>__1;

		// Token: 0x0400572F RID: 22319
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04005730 RID: 22320
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x04005731 RID: 22321
		internal IEnumerator $locvar1;

		// Token: 0x04005732 RID: 22322
		internal object <_>__3;

		// Token: 0x04005733 RID: 22323
		internal IDisposable $locvar2;

		// Token: 0x04005734 RID: 22324
		internal IEnumerator $locvar3;

		// Token: 0x04005735 RID: 22325
		internal object <_>__4;

		// Token: 0x04005736 RID: 22326
		internal IDisposable $locvar4;

		// Token: 0x04005737 RID: 22327
		internal object $current;

		// Token: 0x04005738 RID: 22328
		internal bool $disposing;

		// Token: 0x04005739 RID: 22329
		internal int $PC;

		// Token: 0x0400573A RID: 22330
		private static Func<AdventurerBattleUnit, <>__AnonType6<double>> <>f__am$cache0;
	}
}
