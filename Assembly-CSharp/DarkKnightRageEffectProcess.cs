using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008C4 RID: 2244
public class DarkKnightRageEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F2F RID: 16175 RVA: 0x0018B242 File Offset: 0x00189642
	public DarkKnightRageEffectProcess()
	{
	}

	// Token: 0x17000B4A RID: 2890
	// (get) Token: 0x06003F30 RID: 16176 RVA: 0x0018B252 File Offset: 0x00189652
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B4B RID: 2891
	// (get) Token: 0x06003F31 RID: 16177 RVA: 0x0018B25C File Offset: 0x0018965C
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.BattleEncounterPlayerGaugeReleased,
				AdventureEventType.BattleEncounterEnemyGaugeReleased
			};
		}
	}

	// Token: 0x06003F32 RID: 16178 RVA: 0x0018B280 File Offset: 0x00189680
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.BattleEncounterPlayerGaugeReleased || evtType == AdventureEventType.BattleEncounterEnemyGaugeReleased)
		{
			BattleGaugeUpdateEvent change = evtData as BattleGaugeUpdateEvent;
			DarkRageData data = specialEffectData as DarkRageData;
			if (change != null && data != null && change.ChangeAmount > 0.0 && ((effectCarrier.IsPlayer && evtType == AdventureEventType.BattleEncounterEnemyGaugeReleased) || (!effectCarrier.IsPlayer && evtType == AdventureEventType.BattleEncounterPlayerGaugeReleased)))
			{
				string effectSourceCode = "darkknightdarkrage";
				double changeAmount = -change.ChangeAmount * data.ChargeRate;
				List<AttributeModificationEffect> currentEffects = (from ef in effectCarrier.BattleEffects.OfType<AttributeModificationEffect>()
				where ef.EffectSourceIdentityCode == effectSourceCode
				select ef).ToList<AttributeModificationEffect>();
				List<AttributeModifier> list;
				if (currentEffects.Any<AttributeModificationEffect>())
				{
					list = (from ef in currentEffects.SelectMany((AttributeModificationEffect ef) => ef.GetAdditionalModifiers(effectCarrier, effectCarrier.CurrentEncounter))
					group ef by ef.AttributeType).Select(delegate(IGrouping<AttributeType, AttributeModifier> ef)
					{
						AttributeModifier attributeModifier = new AttributeModifier();
						attributeModifier.AttributeType = ef.Key;
						attributeModifier.ModificationType = ModificationType.Addition;
						attributeModifier.Value = ef.Sum((AttributeModifier f) => f.Value) + changeAmount;
						attributeModifier.AttributeModifierType = AttributeModifierType.Skill;
						attributeModifier.Key = string.Empty;
						return attributeModifier;
					}).ToList<AttributeModifier>();
				}
				else
				{
					list = (from a in data.ChargeAttributeTypes
					select new AttributeModifier
					{
						AttributeType = a,
						ModificationType = ModificationType.Addition,
						Value = changeAmount,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					}).ToList<AttributeModifier>();
				}
				List<AttributeModifier> existingModifiers = list;
				IEnumerator enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, existingModifiers, effectSourceCode, new int?(1), null, null, false, false, false), false).GetEnumerator();
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

	// Token: 0x04002F74 RID: 12148
	private readonly SpecialEffectType _correspondingEffectType = SpecialEffectType.DarkKnightRage;

	// Token: 0x02000F3C RID: 3900
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600628D RID: 25229 RVA: 0x0018B2BA File Offset: 0x001896BA
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600628E RID: 25230 RVA: 0x0018B2C4 File Offset: 0x001896C4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				<AsActiveUnitProcess>c__AnonStorey = new DarkKnightRageEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey2();
				<AsActiveUnitProcess>c__AnonStorey.<>f__ref$0 = this;
				<AsActiveUnitProcess>c__AnonStorey.effectCarrier = effectCarrier;
				if (evtType != AdventureEventType.BattleEncounterPlayerGaugeReleased && evtType != AdventureEventType.BattleEncounterEnemyGaugeReleased)
				{
					goto IL_304;
				}
				change = (evtData as BattleGaugeUpdateEvent);
				data = (specialEffectData as DarkRageData);
				if (change == null || data == null || change.ChangeAmount <= 0.0 || ((!<AsActiveUnitProcess>c__AnonStorey.effectCarrier.IsPlayer || evtType != AdventureEventType.BattleEncounterEnemyGaugeReleased) && (<AsActiveUnitProcess>c__AnonStorey.effectCarrier.IsPlayer || evtType != AdventureEventType.BattleEncounterPlayerGaugeReleased)))
				{
					goto IL_304;
				}
				string effectSourceCode = "darkknightdarkrage";
				double changeAmount = -change.ChangeAmount * data.ChargeRate;
				currentEffects = (from ef in <AsActiveUnitProcess>c__AnonStorey.effectCarrier.BattleEffects.OfType<AttributeModificationEffect>()
				where ef.EffectSourceIdentityCode == effectSourceCode
				select ef).ToList<AttributeModificationEffect>();
				List<AttributeModifier> list;
				if (currentEffects.Any<AttributeModificationEffect>())
				{
					list = (from ef in currentEffects.SelectMany((AttributeModificationEffect ef) => ef.GetAdditionalModifiers(<AsActiveUnitProcess>c__AnonStorey.effectCarrier, <AsActiveUnitProcess>c__AnonStorey.effectCarrier.CurrentEncounter))
					group ef by ef.AttributeType).Select(delegate(IGrouping<AttributeType, AttributeModifier> ef)
					{
						AttributeModifier attributeModifier = new AttributeModifier();
						attributeModifier.AttributeType = ef.Key;
						attributeModifier.ModificationType = ModificationType.Addition;
						attributeModifier.Value = ef.Sum((AttributeModifier f) => f.Value) + changeAmount;
						attributeModifier.AttributeModifierType = AttributeModifierType.Skill;
						attributeModifier.Key = string.Empty;
						return attributeModifier;
					}).ToList<AttributeModifier>();
				}
				else
				{
					list = (from a in data.ChargeAttributeTypes
					select new AttributeModifier
					{
						AttributeType = a,
						ModificationType = ModificationType.Addition,
						Value = changeAmount,
						AttributeModifierType = AttributeModifierType.Skill,
						Key = string.Empty
					}).ToList<AttributeModifier>();
				}
				existingModifiers = list;
				enumerator = <AsActiveUnitProcess>c__AnonStorey.effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(<AsActiveUnitProcess>c__AnonStorey.effectCarrier, existingModifiers, effectSourceCode, new int?(1), null, null, false, false, false), false).GetEnumerator();
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
			IL_304:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014A1 RID: 5281
		// (get) Token: 0x0600628F RID: 25231 RVA: 0x0018B5F0 File Offset: 0x001899F0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014A2 RID: 5282
		// (get) Token: 0x06006290 RID: 25232 RVA: 0x0018B5F8 File Offset: 0x001899F8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006291 RID: 25233 RVA: 0x0018B600 File Offset: 0x00189A00
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

		// Token: 0x06006292 RID: 25234 RVA: 0x0018B670 File Offset: 0x00189A70
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006293 RID: 25235 RVA: 0x0018B677 File Offset: 0x00189A77
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006294 RID: 25236 RVA: 0x0018B680 File Offset: 0x00189A80
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DarkKnightRageEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new DarkKnightRageEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x06006295 RID: 25237 RVA: 0x0018B6D8 File Offset: 0x00189AD8
		private static AttributeType <>m__0(AttributeModifier ef)
		{
			return ef.AttributeType;
		}

		// Token: 0x04005901 RID: 22785
		internal AdventureEventType evtType;

		// Token: 0x04005902 RID: 22786
		internal object evtData;

		// Token: 0x04005903 RID: 22787
		internal BattleGaugeUpdateEvent <change>__1;

		// Token: 0x04005904 RID: 22788
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005905 RID: 22789
		internal DarkRageData <data>__1;

		// Token: 0x04005906 RID: 22790
		internal IBattleUnit effectCarrier;

		// Token: 0x04005907 RID: 22791
		internal List<AttributeModificationEffect> <currentEffects>__2;

		// Token: 0x04005908 RID: 22792
		internal List<AttributeModifier> <existingModifiers>__2;

		// Token: 0x04005909 RID: 22793
		internal IEnumerator $locvar0;

		// Token: 0x0400590A RID: 22794
		internal object <_>__3;

		// Token: 0x0400590B RID: 22795
		internal IDisposable $locvar1;

		// Token: 0x0400590C RID: 22796
		internal object $current;

		// Token: 0x0400590D RID: 22797
		internal bool $disposing;

		// Token: 0x0400590E RID: 22798
		internal int $PC;

		// Token: 0x0400590F RID: 22799
		private DarkKnightRageEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey2 $locvar2;

		// Token: 0x04005910 RID: 22800
		private DarkKnightRageEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar3;

		// Token: 0x04005911 RID: 22801
		private static Func<AttributeModifier, AttributeType> <>f__am$cache0;

		// Token: 0x02000F3D RID: 3901
		private sealed class <AsActiveUnitProcess>c__AnonStorey2
		{
			// Token: 0x06006296 RID: 25238 RVA: 0x0018B6E0 File Offset: 0x00189AE0
			public <AsActiveUnitProcess>c__AnonStorey2()
			{
			}

			// Token: 0x04005912 RID: 22802
			internal IBattleUnit effectCarrier;

			// Token: 0x04005913 RID: 22803
			internal DarkKnightRageEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;
		}

		// Token: 0x02000F3E RID: 3902
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x06006297 RID: 25239 RVA: 0x0018B6E8 File Offset: 0x00189AE8
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x06006298 RID: 25240 RVA: 0x0018B6F0 File Offset: 0x00189AF0
			internal bool <>m__0(AttributeModificationEffect ef)
			{
				return ef.EffectSourceIdentityCode == this.effectSourceCode;
			}

			// Token: 0x06006299 RID: 25241 RVA: 0x0018B703 File Offset: 0x00189B03
			internal IEnumerable<AttributeModifier> <>m__1(AttributeModificationEffect ef)
			{
				return ef.GetAdditionalModifiers(this.<>f__ref$2.effectCarrier, this.<>f__ref$2.effectCarrier.CurrentEncounter);
			}

			// Token: 0x0600629A RID: 25242 RVA: 0x0018B728 File Offset: 0x00189B28
			internal AttributeModifier <>m__2(IGrouping<AttributeType, AttributeModifier> ef)
			{
				AttributeModifier attributeModifier = new AttributeModifier();
				attributeModifier.AttributeType = ef.Key;
				attributeModifier.ModificationType = ModificationType.Addition;
				attributeModifier.Value = ef.Sum((AttributeModifier f) => f.Value) + this.changeAmount;
				attributeModifier.AttributeModifierType = AttributeModifierType.Skill;
				attributeModifier.Key = string.Empty;
				return attributeModifier;
			}

			// Token: 0x0600629B RID: 25243 RVA: 0x0018B794 File Offset: 0x00189B94
			internal AttributeModifier <>m__3(AttributeType a)
			{
				return new AttributeModifier
				{
					AttributeType = a,
					ModificationType = ModificationType.Addition,
					Value = this.changeAmount,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				};
			}

			// Token: 0x0600629C RID: 25244 RVA: 0x0018B7D4 File Offset: 0x00189BD4
			private static double <>m__4(AttributeModifier f)
			{
				return f.Value;
			}

			// Token: 0x04005914 RID: 22804
			internal string effectSourceCode;

			// Token: 0x04005915 RID: 22805
			internal double changeAmount;

			// Token: 0x04005916 RID: 22806
			internal DarkKnightRageEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;

			// Token: 0x04005917 RID: 22807
			internal DarkKnightRageEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey2 <>f__ref$2;

			// Token: 0x04005918 RID: 22808
			private static Func<AttributeModifier, double> <>f__am$cache0;
		}
	}
}
