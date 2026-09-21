using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008F7 RID: 2295
public class HydraSpiritEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004009 RID: 16393 RVA: 0x00198ED5 File Offset: 0x001972D5
	public HydraSpiritEffectProcess()
	{
	}

	// Token: 0x17000BB0 RID: 2992
	// (get) Token: 0x0600400A RID: 16394 RVA: 0x00198EE5 File Offset: 0x001972E5
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000BB1 RID: 2993
	// (get) Token: 0x0600400B RID: 16395 RVA: 0x00198EF0 File Offset: 0x001972F0
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

	// Token: 0x0600400C RID: 16396 RVA: 0x00198F0C File Offset: 0x0019730C
	public override IEnumerable AsActiveUnitPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit effectCarrier)
	{
		HydraSpiritData data = specialEffectData as HydraSpiritData;
		if (data != null)
		{
			data.TickCounter++;
			if (data.TickCounter >= data.TickCap)
			{
				data.TickCounter -= data.TickCap;
				List<IBattleUnit> units = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true);
				ReleaseableHeal heals = new ReleaseableHeal((from u in units
				select new BattleHeal(u, effectCarrier, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = u.GetMaxLife(AttributeRetrievalLevel.Skill) * data.HealRate,
						HealType = OutputType.RealHeal,
						IsDirectHeal = false
					}
				}, false)).ToList<BattleHeal>(), effectCarrier);
				IEnumerator enumerator = heals.Release().GetEnumerator();
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
				foreach (IBattleUnit unit in units)
				{
					FireySoulEffect existingFireySoulEffect = unit.BattleEffects.OfType<FireySoulEffect>().FirstOrDefault<FireySoulEffect>();
					if (existingFireySoulEffect != null)
					{
						existingFireySoulEffect.AddCount();
					}
					else
					{
						IEnumerator enumerator3 = unit.ApplySkillEffect(new FireySoulEffect(data.MaxFireySoulCap, effectCarrier, base.GetType().FullName), false).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x0600400D RID: 16397 RVA: 0x00198F40 File Offset: 0x00197340
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.BattleEncounterStarts)
		{
			HydraSpiritData hydraSpiritData = specialEffectData as HydraSpiritData;
			if (hydraSpiritData != null)
			{
				hydraSpiritData.TickCounter = 0;
			}
		}
		yield break;
	}

	// Token: 0x04002F99 RID: 12185
	private readonly SpecialEffectType _correspondingEffectType = SpecialEffectType.HydraSpiritEffect;

	// Token: 0x02000F7D RID: 3965
	[CompilerGenerated]
	private sealed class <AsActiveUnitPerSecondProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006451 RID: 25681 RVA: 0x00198F6B File Offset: 0x0019736B
		[DebuggerHidden]
		public <AsActiveUnitPerSecondProcess>c__Iterator0()
		{
		}

		// Token: 0x06006452 RID: 25682 RVA: 0x00198F74 File Offset: 0x00197374
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				HydraSpiritData data = specialEffectData as HydraSpiritData;
				if (data == null)
				{
					goto IL_325;
				}
				data.TickCounter++;
				if (data.TickCounter < data.TickCap)
				{
					goto IL_325;
				}
				data.TickCounter -= data.TickCap;
				units = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true);
				heals = new ReleaseableHeal((from u in units
				select new BattleHeal(u, effectCarrier, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = u.GetMaxLife(AttributeRetrievalLevel.Skill) * data.HealRate,
						HealType = OutputType.RealHeal,
						IsDirectHeal = false
					}
				}, false)).ToList<BattleHeal>(), effectCarrier);
				enumerator = heals.Release().GetEnumerator();
				num = 4294967293u;
				break;
			}
			case 1u:
				break;
			case 2u:
				goto IL_1D6;
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
			enumerator2 = units.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_1D6:
				switch (num)
				{
				case 2u:
					Block_14:
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
				while (enumerator2.MoveNext())
				{
					unit = enumerator2.Current;
					existingFireySoulEffect = unit.BattleEffects.OfType<FireySoulEffect>().FirstOrDefault<FireySoulEffect>();
					if (existingFireySoulEffect == null)
					{
						enumerator3 = unit.ApplySkillEffect(new FireySoulEffect(<AsActiveUnitPerSecondProcess>c__AnonStorey.data.MaxFireySoulCap, <AsActiveUnitPerSecondProcess>c__AnonStorey.effectCarrier, base.GetType().FullName), false).GetEnumerator();
						num = 4294967293u;
						goto Block_14;
					}
					existingFireySoulEffect.AddCount();
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
			IL_325:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001501 RID: 5377
		// (get) Token: 0x06006453 RID: 25683 RVA: 0x001992FC File Offset: 0x001976FC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001502 RID: 5378
		// (get) Token: 0x06006454 RID: 25684 RVA: 0x00199304 File Offset: 0x00197704
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006455 RID: 25685 RVA: 0x0019930C File Offset: 0x0019770C
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
			}
		}

		// Token: 0x06006456 RID: 25686 RVA: 0x001993E0 File Offset: 0x001977E0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006457 RID: 25687 RVA: 0x001993E7 File Offset: 0x001977E7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006458 RID: 25688 RVA: 0x001993F0 File Offset: 0x001977F0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			HydraSpiritEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0 <AsActiveUnitPerSecondProcess>c__Iterator = new HydraSpiritEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0();
			<AsActiveUnitPerSecondProcess>c__Iterator.$this = this;
			<AsActiveUnitPerSecondProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitPerSecondProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitPerSecondProcess>c__Iterator;
		}

		// Token: 0x04005C23 RID: 23587
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005C24 RID: 23588
		internal IBattleUnit effectCarrier;

		// Token: 0x04005C25 RID: 23589
		internal List<IBattleUnit> <units>__1;

		// Token: 0x04005C26 RID: 23590
		internal ReleaseableHeal <heals>__1;

		// Token: 0x04005C27 RID: 23591
		internal IEnumerator $locvar0;

		// Token: 0x04005C28 RID: 23592
		internal object <_>__2;

		// Token: 0x04005C29 RID: 23593
		internal IDisposable $locvar1;

		// Token: 0x04005C2A RID: 23594
		internal List<IBattleUnit>.Enumerator $locvar2;

		// Token: 0x04005C2B RID: 23595
		internal IBattleUnit <unit>__3;

		// Token: 0x04005C2C RID: 23596
		internal FireySoulEffect <existingFireySoulEffect>__4;

		// Token: 0x04005C2D RID: 23597
		internal IEnumerator $locvar3;

		// Token: 0x04005C2E RID: 23598
		internal object <_>__5;

		// Token: 0x04005C2F RID: 23599
		internal IDisposable $locvar4;

		// Token: 0x04005C30 RID: 23600
		internal HydraSpiritEffectProcess $this;

		// Token: 0x04005C31 RID: 23601
		internal object $current;

		// Token: 0x04005C32 RID: 23602
		internal bool $disposing;

		// Token: 0x04005C33 RID: 23603
		internal int $PC;

		// Token: 0x04005C34 RID: 23604
		private HydraSpiritEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0.<AsActiveUnitPerSecondProcess>c__AnonStorey2 $locvar5;

		// Token: 0x02000F7F RID: 3967
		private sealed class <AsActiveUnitPerSecondProcess>c__AnonStorey2
		{
			// Token: 0x06006461 RID: 25697 RVA: 0x0019943C File Offset: 0x0019783C
			public <AsActiveUnitPerSecondProcess>c__AnonStorey2()
			{
			}

			// Token: 0x06006462 RID: 25698 RVA: 0x00199444 File Offset: 0x00197844
			internal BattleHeal <>m__0(IBattleUnit u)
			{
				return new BattleHeal(u, this.effectCarrier, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = u.GetMaxLife(AttributeRetrievalLevel.Skill) * this.data.HealRate,
						HealType = OutputType.RealHeal,
						IsDirectHeal = false
					}
				}, false);
			}

			// Token: 0x04005C3A RID: 23610
			internal IBattleUnit effectCarrier;

			// Token: 0x04005C3B RID: 23611
			internal HydraSpiritData data;

			// Token: 0x04005C3C RID: 23612
			internal HydraSpiritEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0 <>f__ref$0;
		}
	}

	// Token: 0x02000F7E RID: 3966
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006459 RID: 25689 RVA: 0x0019949A File Offset: 0x0019789A
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator1()
		{
		}

		// Token: 0x0600645A RID: 25690 RVA: 0x001994A4 File Offset: 0x001978A4
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				if (evtType == AdventureEventType.BattleEncounterStarts)
				{
					HydraSpiritData hydraSpiritData = specialEffectData as HydraSpiritData;
					if (hydraSpiritData != null)
					{
						hydraSpiritData.TickCounter = 0;
					}
				}
			}
			return false;
		}

		// Token: 0x17001503 RID: 5379
		// (get) Token: 0x0600645B RID: 25691 RVA: 0x001994EF File Offset: 0x001978EF
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001504 RID: 5380
		// (get) Token: 0x0600645C RID: 25692 RVA: 0x001994F7 File Offset: 0x001978F7
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600645D RID: 25693 RVA: 0x001994FF File Offset: 0x001978FF
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x0600645E RID: 25694 RVA: 0x00199501 File Offset: 0x00197901
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600645F RID: 25695 RVA: 0x00199508 File Offset: 0x00197908
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006460 RID: 25696 RVA: 0x00199510 File Offset: 0x00197910
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			HydraSpiritEffectProcess.<AsActiveUnitProcess>c__Iterator1 <AsActiveUnitProcess>c__Iterator = new HydraSpiritEffectProcess.<AsActiveUnitProcess>c__Iterator1();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005C35 RID: 23605
		internal AdventureEventType evtType;

		// Token: 0x04005C36 RID: 23606
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005C37 RID: 23607
		internal object $current;

		// Token: 0x04005C38 RID: 23608
		internal bool $disposing;

		// Token: 0x04005C39 RID: 23609
		internal int $PC;
	}
}
