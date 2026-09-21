using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008DA RID: 2266
public class ElementalMasterEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F8D RID: 16269 RVA: 0x0019232C File Offset: 0x0019072C
	public ElementalMasterEffectProcess()
	{
	}

	// Token: 0x17000B76 RID: 2934
	// (get) Token: 0x06003F8E RID: 16270 RVA: 0x00192334 File Offset: 0x00190734
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.ElementalMaster;
		}
	}

	// Token: 0x17000B77 RID: 2935
	// (get) Token: 0x06003F8F RID: 16271 RVA: 0x00192338 File Offset: 0x00190738
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReadyInBattle
			};
		}
	}

	// Token: 0x06003F90 RID: 16272 RVA: 0x00192354 File Offset: 0x00190754
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && specialEffectData is ElementalMasterData)
		{
			ElementalMasterData data = specialEffectData as ElementalMasterData;
			List<IBattleUnit> friendlyUnits = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true);
			foreach (IBattleUnit friendlyUnit in friendlyUnits)
			{
				foreach (List<OutputType> dataImmuneType in data.ImmuneTypes)
				{
					IEnumerator enumerator3 = friendlyUnit.ApplySkillEffect(new DamageImmuneEffect("elementalmaster", null, null, effectCarrier, (from i in dataImmuneType
					select i).ToList<OutputType>(), true, 7), false).GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							object _ = enumerator3.Current;
							yield return _;
						}
					}
					finally
					{
						IDisposable disposable;
						if ((disposable = (enumerator3 as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x02000F58 RID: 3928
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006358 RID: 25432 RVA: 0x0019238D File Offset: 0x0019078D
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006359 RID: 25433 RVA: 0x00192398 File Offset: 0x00190798
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitReadyInBattle || triggerUnit != effectCarrier || !(specialEffectData is ElementalMasterData))
				{
					goto IL_22A;
				}
				data = (specialEffectData as ElementalMasterData);
				friendlyUnits = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true);
				enumerator = friendlyUnits.GetEnumerator();
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
					Block_7:
					try
					{
						switch (num)
						{
						case 1u:
							Block_11:
							try
							{
								switch (num)
								{
								}
								if (enumerator3.MoveNext())
								{
									_ = enumerator3.Current;
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
									if ((disposable = (enumerator3 as IDisposable)) != null)
									{
										disposable.Dispose();
									}
								}
							}
							break;
						}
						if (enumerator2.MoveNext())
						{
							dataImmuneType = enumerator2.Current;
							enumerator3 = friendlyUnit.ApplySkillEffect(new DamageImmuneEffect("elementalmaster", null, null, effectCarrier, (from i in dataImmuneType
							select i).ToList<OutputType>(), true, 7), false).GetEnumerator();
							num = 4294967293u;
							goto Block_11;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator2).Dispose();
						}
					}
					break;
				}
				if (enumerator.MoveNext())
				{
					friendlyUnit = enumerator.Current;
					enumerator2 = data.ImmuneTypes.GetEnumerator();
					num = 4294967293u;
					goto Block_7;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_22A:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014CD RID: 5325
		// (get) Token: 0x0600635A RID: 25434 RVA: 0x00192628 File Offset: 0x00190A28
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014CE RID: 5326
		// (get) Token: 0x0600635B RID: 25435 RVA: 0x00192630 File Offset: 0x00190A30
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600635C RID: 25436 RVA: 0x00192638 File Offset: 0x00190A38
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
						try
						{
						}
						finally
						{
							if ((disposable = (enumerator3 as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator2).Dispose();
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x0600635D RID: 25437 RVA: 0x001926F0 File Offset: 0x00190AF0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600635E RID: 25438 RVA: 0x001926F7 File Offset: 0x00190AF7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600635F RID: 25439 RVA: 0x00192700 File Offset: 0x00190B00
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ElementalMasterEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new ElementalMasterEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x06006360 RID: 25440 RVA: 0x00192758 File Offset: 0x00190B58
		private static OutputType <>m__0(OutputType i)
		{
			return i;
		}

		// Token: 0x04005A8B RID: 23179
		internal AdventureEventType evtType;

		// Token: 0x04005A8C RID: 23180
		internal IBattleUnit triggerUnit;

		// Token: 0x04005A8D RID: 23181
		internal IBattleUnit effectCarrier;

		// Token: 0x04005A8E RID: 23182
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005A8F RID: 23183
		internal ElementalMasterData <data>__1;

		// Token: 0x04005A90 RID: 23184
		internal List<IBattleUnit> <friendlyUnits>__1;

		// Token: 0x04005A91 RID: 23185
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04005A92 RID: 23186
		internal IBattleUnit <friendlyUnit>__2;

		// Token: 0x04005A93 RID: 23187
		internal List<List<OutputType>>.Enumerator $locvar1;

		// Token: 0x04005A94 RID: 23188
		internal List<OutputType> <dataImmuneType>__3;

		// Token: 0x04005A95 RID: 23189
		internal IEnumerator $locvar2;

		// Token: 0x04005A96 RID: 23190
		internal object <_>__4;

		// Token: 0x04005A97 RID: 23191
		internal IDisposable $locvar3;

		// Token: 0x04005A98 RID: 23192
		internal object $current;

		// Token: 0x04005A99 RID: 23193
		internal bool $disposing;

		// Token: 0x04005A9A RID: 23194
		internal int $PC;

		// Token: 0x04005A9B RID: 23195
		private static Func<OutputType, OutputType> <>f__am$cache0;
	}
}
