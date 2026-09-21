using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000940 RID: 2368
public class KillerEnhancementEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x0600415C RID: 16732 RVA: 0x001AD290 File Offset: 0x001AB690
	public KillerEnhancementEffectProcess()
	{
	}

	// Token: 0x17000C3F RID: 3135
	// (get) Token: 0x0600415D RID: 16733 RVA: 0x001AD298 File Offset: 0x001AB698
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.KillerEnhancement;
		}
	}

	// Token: 0x17000C40 RID: 3136
	// (get) Token: 0x0600415E RID: 16734 RVA: 0x001AD2A0 File Offset: 0x001AB6A0
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitPostReceivesDamage_Single
			};
		}
	}

	// Token: 0x0600415F RID: 16735 RVA: 0x001AD2BC File Offset: 0x001AB6BC
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && evtData is DamageComponent && specialEffectData is KillerEnhancementData && effectCarrier == triggerUnit)
		{
			DamageComponent damage = evtData as DamageComponent;
			if (damage.IsCrit && !damage.IsMissed)
			{
				List<IBattleUnit> members = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true);
				KillerEnhancementData data = specialEffectData as KillerEnhancementData;
				foreach (IBattleUnit battleUnit in members)
				{
					IEnumerator enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.DodgeRateAdjustment,
							ModificationType = ModificationType.Addition,
							Value = data.PartyDodgeRateBoost,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, "killerenhancement", new int?(1), new float?(6f), null, false, true, false), false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x02000FEB RID: 4075
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600673D RID: 26429 RVA: 0x001AD2FD File Offset: 0x001AB6FD
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600673E RID: 26430 RVA: 0x001AD308 File Offset: 0x001AB708
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitPostReceivesDamage_Single || !(evtData is DamageComponent) || !(specialEffectData is KillerEnhancementData) || effectCarrier != triggerUnit)
				{
					goto IL_22A;
				}
				damage = (evtData as DamageComponent);
				if (!damage.IsCrit || damage.IsMissed)
				{
					goto IL_22A;
				}
				members = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true);
				data = (specialEffectData as KillerEnhancementData);
				enumerator = members.GetEnumerator();
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
					battleUnit = enumerator.Current;
					enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.DodgeRateAdjustment,
							ModificationType = ModificationType.Addition,
							Value = data.PartyDodgeRateBoost,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, "killerenhancement", new int?(1), new float?(6f), null, false, true, false), false).GetEnumerator();
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
			IL_22A:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015A9 RID: 5545
		// (get) Token: 0x0600673F RID: 26431 RVA: 0x001AD580 File Offset: 0x001AB980
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015AA RID: 5546
		// (get) Token: 0x06006740 RID: 26432 RVA: 0x001AD588 File Offset: 0x001AB988
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006741 RID: 26433 RVA: 0x001AD590 File Offset: 0x001AB990
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

		// Token: 0x06006742 RID: 26434 RVA: 0x001AD624 File Offset: 0x001ABA24
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006743 RID: 26435 RVA: 0x001AD62B File Offset: 0x001ABA2B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006744 RID: 26436 RVA: 0x001AD634 File Offset: 0x001ABA34
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			KillerEnhancementEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new KillerEnhancementEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x0400610F RID: 24847
		internal AdventureEventType evtType;

		// Token: 0x04006110 RID: 24848
		internal object evtData;

		// Token: 0x04006111 RID: 24849
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04006112 RID: 24850
		internal IBattleUnit effectCarrier;

		// Token: 0x04006113 RID: 24851
		internal IBattleUnit triggerUnit;

		// Token: 0x04006114 RID: 24852
		internal DamageComponent <damage>__1;

		// Token: 0x04006115 RID: 24853
		internal List<IBattleUnit> <members>__2;

		// Token: 0x04006116 RID: 24854
		internal KillerEnhancementData <data>__2;

		// Token: 0x04006117 RID: 24855
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04006118 RID: 24856
		internal IBattleUnit <battleUnit>__3;

		// Token: 0x04006119 RID: 24857
		internal IEnumerator $locvar1;

		// Token: 0x0400611A RID: 24858
		internal object <_>__4;

		// Token: 0x0400611B RID: 24859
		internal IDisposable $locvar2;

		// Token: 0x0400611C RID: 24860
		internal object $current;

		// Token: 0x0400611D RID: 24861
		internal bool $disposing;

		// Token: 0x0400611E RID: 24862
		internal int $PC;
	}
}
