using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008C1 RID: 2241
public class CurseEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F23 RID: 16163 RVA: 0x0018A120 File Offset: 0x00188520
	public CurseEffectProcess()
	{
	}

	// Token: 0x17000B44 RID: 2884
	// (get) Token: 0x06003F24 RID: 16164 RVA: 0x0018A128 File Offset: 0x00188528
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.Curse;
		}
	}

	// Token: 0x17000B45 RID: 2885
	// (get) Token: 0x06003F25 RID: 16165 RVA: 0x0018A130 File Offset: 0x00188530
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitPostReceivesDamage_Single,
				AdventureEventType.UnitPostCastSkill
			};
		}
	}

	// Token: 0x06003F26 RID: 16166 RVA: 0x0018A154 File Offset: 0x00188554
	public override IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.UnitPostReceivesDamage_Single && evt.EventTriggeringUnit.IsPlayer && evt.EventTriggeringUnit.IsAliveInBattle() && specialEffectData is CurseData && evt.AdditionalData is DamageComponent)
		{
			DamageComponent damage = evt.AdditionalData as DamageComponent;
			if (damage.IsDirectDamage && !damage.IsMissed)
			{
				CurseData data = specialEffectData as CurseData;
				List<IBattleUnit> tospread = (from u in evt.EventTriggeringUnit.GetAllLiveFriendlyTargetsIncSelf(true)
				where u != evt.EventTriggeringUnit
				select u).ToList<IBattleUnit>();
				tospread.Shuffle<IBattleUnit>();
				tospread = tospread.Take(data.SpreadNumberOfUnits).ToList<IBattleUnit>();
				if (tospread.Any<IBattleUnit>())
				{
					foreach (ISpreadableDamageOverTime spreadableDamageOverTime in evt.EventTriggeringUnit.BattleEffects.OfType<ISpreadableDamageOverTime>())
					{
						IEnumerator enumerator2 = spreadableDamageOverTime.Spread(evt.EventTriggeringUnit, tospread).GetEnumerator();
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
				IEnumerator enumerator3 = DamageOverTimeEffect.AddDamageOverSecond(evt.EventTriggeringUnit, damage.Dealer, damage.GetTotalDamageSoFar() * data.DamageRate, data.Seconds, damage.Dealer.GetOutputType()).GetEnumerator();
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
		if (evt.EventType == AdventureEventType.UnitPostCastSkill && evt.EventTriggeringUnit.IsPlayer && specialEffectData is CurseData && evt.EventTriggeringUnit.IsAliveInBattle())
		{
			CurseData data2 = specialEffectData as CurseData;
			List<IBattleUnit> tospread2 = (from u in evt.EventTriggeringUnit.GetAllLiveFriendlyTargetsIncSelf(true)
			where u != evt.EventTriggeringUnit
			select u).ToList<IBattleUnit>();
			tospread2.Shuffle<IBattleUnit>();
			tospread2 = tospread2.Take(data2.SpreadNumberOfUnits).ToList<IBattleUnit>();
			if (tospread2.Any<IBattleUnit>())
			{
				foreach (ISpreadableDamageOverTime spreadableDamageOverTime2 in evt.EventTriggeringUnit.BattleEffects.OfType<ISpreadableDamageOverTime>())
				{
					IEnumerator enumerator5 = spreadableDamageOverTime2.Spread(evt.EventTriggeringUnit, tospread2).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x02000F37 RID: 3895
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600626D RID: 25197 RVA: 0x0018A17E File Offset: 0x0018857E
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator0()
		{
		}

		// Token: 0x0600626E RID: 25198 RVA: 0x0018A188 File Offset: 0x00188588
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evt.EventType != AdventureEventType.UnitPostReceivesDamage_Single || !evt.EventTriggeringUnit.IsPlayer || !evt.EventTriggeringUnit.IsAliveInBattle() || !(specialEffectData is CurseData) || !(evt.AdditionalData is DamageComponent))
				{
					goto IL_394;
				}
				damage = (evt.AdditionalData as DamageComponent);
				if (!damage.IsDirectDamage || damage.IsMissed)
				{
					goto IL_394;
				}
				data = (specialEffectData as CurseData);
				tospread = (from u in evt.EventTriggeringUnit.GetAllLiveFriendlyTargetsIncSelf(true)
				where u != evt.EventTriggeringUnit
				select u).ToList<IBattleUnit>();
				tospread.Shuffle<IBattleUnit>();
				tospread = tospread.Take(data.SpreadNumberOfUnits).ToList<IBattleUnit>();
				if (!tospread.Any<IBattleUnit>())
				{
					goto IL_2B2;
				}
				enumerator = evt.EventTriggeringUnit.BattleEffects.OfType<ISpreadableDamageOverTime>().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				Block_11:
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
				goto IL_394;
			case 3u:
				Block_17:
				try
				{
					switch (num)
					{
					case 3u:
						Block_37:
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
						spreadableDamageOverTime2 = enumerator4.Current;
						enumerator5 = spreadableDamageOverTime2.Spread(<AsAdventureEffectProcess>c__AnonStorey.evt.EventTriggeringUnit, tospread2).GetEnumerator();
						num = 4294967293u;
						goto Block_37;
					}
				}
				finally
				{
					if (!flag)
					{
						if (enumerator4 != null)
						{
							enumerator4.Dispose();
						}
					}
				}
				goto IL_59E;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_19:
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
					spreadableDamageOverTime = enumerator.Current;
					enumerator2 = spreadableDamageOverTime.Spread(<AsAdventureEffectProcess>c__AnonStorey.evt.EventTriggeringUnit, tospread).GetEnumerator();
					num = 4294967293u;
					goto Block_19;
				}
			}
			finally
			{
				if (!flag)
				{
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
			}
			IL_2B2:
			enumerator3 = DamageOverTimeEffect.AddDamageOverSecond(<AsAdventureEffectProcess>c__AnonStorey.evt.EventTriggeringUnit, damage.Dealer, damage.GetTotalDamageSoFar() * data.DamageRate, data.Seconds, damage.Dealer.GetOutputType()).GetEnumerator();
			num = 4294967293u;
			goto Block_11;
			IL_394:
			if (<AsAdventureEffectProcess>c__AnonStorey.evt.EventType == AdventureEventType.UnitPostCastSkill && <AsAdventureEffectProcess>c__AnonStorey.evt.EventTriggeringUnit.IsPlayer && specialEffectData is CurseData && <AsAdventureEffectProcess>c__AnonStorey.evt.EventTriggeringUnit.IsAliveInBattle())
			{
				data2 = (specialEffectData as CurseData);
				tospread2 = (from u in <AsAdventureEffectProcess>c__AnonStorey.evt.EventTriggeringUnit.GetAllLiveFriendlyTargetsIncSelf(true)
				where u != <AsAdventureEffectProcess>c__AnonStorey.evt.EventTriggeringUnit
				select u).ToList<IBattleUnit>();
				tospread2.Shuffle<IBattleUnit>();
				tospread2 = tospread2.Take(data2.SpreadNumberOfUnits).ToList<IBattleUnit>();
				if (tospread2.Any<IBattleUnit>())
				{
					enumerator4 = <AsAdventureEffectProcess>c__AnonStorey.evt.EventTriggeringUnit.BattleEffects.OfType<ISpreadableDamageOverTime>().GetEnumerator();
					num = 4294967293u;
					goto Block_17;
				}
			}
			IL_59E:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700149B RID: 5275
		// (get) Token: 0x0600626F RID: 25199 RVA: 0x0018A780 File Offset: 0x00188B80
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700149C RID: 5276
		// (get) Token: 0x06006270 RID: 25200 RVA: 0x0018A788 File Offset: 0x00188B88
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006271 RID: 25201 RVA: 0x0018A790 File Offset: 0x00188B90
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
					if (enumerator != null)
					{
						enumerator.Dispose();
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
					if (enumerator4 != null)
					{
						enumerator4.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06006272 RID: 25202 RVA: 0x0018A8D0 File Offset: 0x00188CD0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006273 RID: 25203 RVA: 0x0018A8D7 File Offset: 0x00188CD7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006274 RID: 25204 RVA: 0x0018A8E0 File Offset: 0x00188CE0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			CurseEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <AsAdventureEffectProcess>c__Iterator = new CurseEffectProcess.<AsAdventureEffectProcess>c__Iterator0();
			<AsAdventureEffectProcess>c__Iterator.evt = evt;
			<AsAdventureEffectProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsAdventureEffectProcess>c__Iterator;
		}

		// Token: 0x040058C3 RID: 22723
		internal BroadcastEvent evt;

		// Token: 0x040058C4 RID: 22724
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x040058C5 RID: 22725
		internal DamageComponent <damage>__1;

		// Token: 0x040058C6 RID: 22726
		internal CurseData <data>__2;

		// Token: 0x040058C7 RID: 22727
		internal List<IBattleUnit> <tospread>__2;

		// Token: 0x040058C8 RID: 22728
		internal IEnumerator<ISpreadableDamageOverTime> $locvar0;

		// Token: 0x040058C9 RID: 22729
		internal ISpreadableDamageOverTime <spreadableDamageOverTime>__3;

		// Token: 0x040058CA RID: 22730
		internal IEnumerator $locvar1;

		// Token: 0x040058CB RID: 22731
		internal object <_>__4;

		// Token: 0x040058CC RID: 22732
		internal IDisposable $locvar2;

		// Token: 0x040058CD RID: 22733
		internal IEnumerator $locvar3;

		// Token: 0x040058CE RID: 22734
		internal object <_>__5;

		// Token: 0x040058CF RID: 22735
		internal IDisposable $locvar4;

		// Token: 0x040058D0 RID: 22736
		internal CurseData <data>__6;

		// Token: 0x040058D1 RID: 22737
		internal List<IBattleUnit> <tospread>__6;

		// Token: 0x040058D2 RID: 22738
		internal IEnumerator<ISpreadableDamageOverTime> $locvar5;

		// Token: 0x040058D3 RID: 22739
		internal ISpreadableDamageOverTime <spreadableDamageOverTime>__7;

		// Token: 0x040058D4 RID: 22740
		internal IEnumerator $locvar6;

		// Token: 0x040058D5 RID: 22741
		internal object <_>__8;

		// Token: 0x040058D6 RID: 22742
		internal IDisposable $locvar7;

		// Token: 0x040058D7 RID: 22743
		internal object $current;

		// Token: 0x040058D8 RID: 22744
		internal bool $disposing;

		// Token: 0x040058D9 RID: 22745
		internal int $PC;

		// Token: 0x040058DA RID: 22746
		private CurseEffectProcess.<AsAdventureEffectProcess>c__Iterator0.<AsAdventureEffectProcess>c__AnonStorey1 $locvar8;

		// Token: 0x02000F38 RID: 3896
		private sealed class <AsAdventureEffectProcess>c__AnonStorey1
		{
			// Token: 0x06006275 RID: 25205 RVA: 0x0018A920 File Offset: 0x00188D20
			public <AsAdventureEffectProcess>c__AnonStorey1()
			{
			}

			// Token: 0x06006276 RID: 25206 RVA: 0x0018A928 File Offset: 0x00188D28
			internal bool <>m__0(IBattleUnit u)
			{
				return u != this.evt.EventTriggeringUnit;
			}

			// Token: 0x06006277 RID: 25207 RVA: 0x0018A93B File Offset: 0x00188D3B
			internal bool <>m__1(IBattleUnit u)
			{
				return u != this.evt.EventTriggeringUnit;
			}

			// Token: 0x040058DB RID: 22747
			internal BroadcastEvent evt;

			// Token: 0x040058DC RID: 22748
			internal CurseEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <>f__ref$0;
		}
	}
}
