using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008C9 RID: 2249
public class DecayBladeEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F44 RID: 16196 RVA: 0x0018CE0C File Offset: 0x0018B20C
	public DecayBladeEffectProcess()
	{
	}

	// Token: 0x17000B54 RID: 2900
	// (get) Token: 0x06003F45 RID: 16197 RVA: 0x0018CE14 File Offset: 0x0018B214
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.DecayBlade;
		}
	}

	// Token: 0x17000B55 RID: 2901
	// (get) Token: 0x06003F46 RID: 16198 RVA: 0x0018CE18 File Offset: 0x0018B218
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReadyInBattle,
				AdventureEventType.UnitRegularTurnStarts
			};
		}
	}

	// Token: 0x06003F47 RID: 16199 RVA: 0x0018CE3C File Offset: 0x0018B23C
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if ((evtType == AdventureEventType.UnitReadyInBattle || evtType == AdventureEventType.UnitRegularTurnStarts) && triggerUnit == effectCarrier && specialEffectData is DecayBladeData)
		{
			DecayBladeData data = specialEffectData as DecayBladeData;
			List<IBattleUnit> targets = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true);
			foreach (IBattleUnit target in targets)
			{
				AttributeType resistance = BattleUnitExtensions.ResistanceToOutput[effectCarrier.GetOutputType()];
				IEnumerator enumerator2 = target.ApplySkillEffect(new DecayBladeEffect(2, data.ResistanceReductionValue, data.AgilityReductionValue, new List<AttributeType>
				{
					resistance
				}, effectCarrier), false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x02000F44 RID: 3908
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060062C7 RID: 25287 RVA: 0x0018CE75 File Offset: 0x0018B275
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060062C8 RID: 25288 RVA: 0x0018CE80 File Offset: 0x0018B280
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if ((evtType != AdventureEventType.UnitReadyInBattle && evtType != AdventureEventType.UnitRegularTurnStarts) || triggerUnit != effectCarrier || !(specialEffectData is DecayBladeData))
				{
					goto IL_1CD;
				}
				data = (specialEffectData as DecayBladeData);
				targets = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true);
				enumerator = targets.GetEnumerator();
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
					target = enumerator.Current;
					resistance = BattleUnitExtensions.ResistanceToOutput[effectCarrier.GetOutputType()];
					enumerator2 = target.ApplySkillEffect(new DecayBladeEffect(2, data.ResistanceReductionValue, data.AgilityReductionValue, new List<AttributeType>
					{
						resistance
					}, effectCarrier), false).GetEnumerator();
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
			IL_1CD:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014AD RID: 5293
		// (get) Token: 0x060062C9 RID: 25289 RVA: 0x0018D098 File Offset: 0x0018B498
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014AE RID: 5294
		// (get) Token: 0x060062CA RID: 25290 RVA: 0x0018D0A0 File Offset: 0x0018B4A0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060062CB RID: 25291 RVA: 0x0018D0A8 File Offset: 0x0018B4A8
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

		// Token: 0x060062CC RID: 25292 RVA: 0x0018D13C File Offset: 0x0018B53C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060062CD RID: 25293 RVA: 0x0018D143 File Offset: 0x0018B543
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060062CE RID: 25294 RVA: 0x0018D14C File Offset: 0x0018B54C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DecayBladeEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new DecayBladeEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005968 RID: 22888
		internal AdventureEventType evtType;

		// Token: 0x04005969 RID: 22889
		internal IBattleUnit triggerUnit;

		// Token: 0x0400596A RID: 22890
		internal IBattleUnit effectCarrier;

		// Token: 0x0400596B RID: 22891
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x0400596C RID: 22892
		internal DecayBladeData <data>__1;

		// Token: 0x0400596D RID: 22893
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x0400596E RID: 22894
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x0400596F RID: 22895
		internal IBattleUnit <target>__2;

		// Token: 0x04005970 RID: 22896
		internal AttributeType <resistance>__3;

		// Token: 0x04005971 RID: 22897
		internal IEnumerator $locvar1;

		// Token: 0x04005972 RID: 22898
		internal object <_>__4;

		// Token: 0x04005973 RID: 22899
		internal IDisposable $locvar2;

		// Token: 0x04005974 RID: 22900
		internal object $current;

		// Token: 0x04005975 RID: 22901
		internal bool $disposing;

		// Token: 0x04005976 RID: 22902
		internal int $PC;
	}
}
