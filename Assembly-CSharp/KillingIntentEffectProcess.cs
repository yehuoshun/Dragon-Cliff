using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008FC RID: 2300
public class KillingIntentEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004022 RID: 16418 RVA: 0x0019A5AC File Offset: 0x001989AC
	public KillingIntentEffectProcess()
	{
	}

	// Token: 0x17000BB8 RID: 3000
	// (get) Token: 0x06004023 RID: 16419 RVA: 0x0019A5B4 File Offset: 0x001989B4
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.KillingIntent;
		}
	}

	// Token: 0x17000BB9 RID: 3001
	// (get) Token: 0x06004024 RID: 16420 RVA: 0x0019A5B8 File Offset: 0x001989B8
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReceivesEffect
			};
		}
	}

	// Token: 0x06004025 RID: 16421 RVA: 0x0019A5D4 File Offset: 0x001989D4
	public override IEnumerable AsActiveUnitPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit effectCarrier)
	{
		KillingIntentEffectData data = specialEffectData as KillingIntentEffectData;
		if (data != null && (double)UnityEngine.Random.value <= data.TickChancePerSecond)
		{
			for (int i = 0; i < data.NumberOfApplicationPerTick; i++)
			{
				IEnumerator enumerator = effectCarrier.ApplySkillEffect(new KillingIntentEffect("killingintenteffect", effectCarrier, new int?(3)), false).GetEnumerator();
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

	// Token: 0x06004026 RID: 16422 RVA: 0x0019A600 File Offset: 0x00198A00
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReceivesEffect && triggerUnit == effectCarrier && evtData is KillingIntentEffect)
		{
			KillingIntentEffectData data = specialEffectData as KillingIntentEffectData;
			if (data != null)
			{
				int currentStack = triggerUnit.BattleEffects.OfType<KillingIntentEffect>().Count<KillingIntentEffect>();
				if (currentStack >= data.MaxStackSize)
				{
					List<KillingIntentEffect> toRemove = triggerUnit.BattleEffects.OfType<KillingIntentEffect>().Take(data.MaxStackSize).ToList<KillingIntentEffect>();
					foreach (KillingIntentEffect killingIntentEffect in toRemove)
					{
						IEnumerator enumerator2 = effectCarrier.LooseSkillEffect(killingIntentEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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
					IEnumerator enumerator3 = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.Agility,
							ModificationType = ModificationType.Multiplication,
							Value = 0.8,
							AttributeModifierType = AttributeModifierType.Skill,
							Key = string.Empty
						},
						new AttributeModifier
						{
							AttributeType = effectCarrier.GetOutputAttributeType(),
							ModificationType = ModificationType.Multiplication,
							Value = 0.8,
							AttributeModifierType = AttributeModifierType.Skill,
							Key = string.Empty
						}
					}, "killingintenteffect", new int?(5), null, new int?(3), false, false, false), false).GetEnumerator();
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
					IEnumerator enumerator4 = UnitStyleConfigurationBase.PushTargetProgress(effectCarrier, effectCarrier, 0.2).GetEnumerator();
					try
					{
						while (enumerator4.MoveNext())
						{
							object _3 = enumerator4.Current;
							yield return _3;
						}
					}
					finally
					{
						IDisposable disposable3;
						if ((disposable3 = (enumerator4 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
					IEnumerator enumerator5 = effectCarrier.ApplySkillEffect(new AdditionaTargetEffect("killingintentproc", null, new int?(2), new int?(data.ExtraTarget), effectCarrier), false).GetEnumerator();
					try
					{
						while (enumerator5.MoveNext())
						{
							object _4 = enumerator5.Current;
							yield return _4;
						}
					}
					finally
					{
						IDisposable disposable4;
						if ((disposable4 = (enumerator5 as IDisposable)) != null)
						{
							disposable4.Dispose();
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x02000F84 RID: 3972
	[CompilerGenerated]
	private sealed class <AsActiveUnitPerSecondProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006484 RID: 25732 RVA: 0x0019A641 File Offset: 0x00198A41
		[DebuggerHidden]
		public <AsActiveUnitPerSecondProcess>c__Iterator0()
		{
		}

		// Token: 0x06006485 RID: 25733 RVA: 0x0019A64C File Offset: 0x00198A4C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				data = (specialEffectData as KillingIntentEffectData);
				if (data == null || (double)UnityEngine.Random.value > data.TickChancePerSecond)
				{
					goto IL_137;
				}
				i = 0;
				break;
			case 1u:
				Block_4:
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
				i++;
				break;
			default:
				return false;
			}
			if (i < data.NumberOfApplicationPerTick)
			{
				enumerator = effectCarrier.ApplySkillEffect(new KillingIntentEffect("killingintenteffect", effectCarrier, new int?(3)), false).GetEnumerator();
				num = 4294967293u;
				goto Block_4;
			}
			IL_137:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700150D RID: 5389
		// (get) Token: 0x06006486 RID: 25734 RVA: 0x0019A7AC File Offset: 0x00198BAC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700150E RID: 5390
		// (get) Token: 0x06006487 RID: 25735 RVA: 0x0019A7B4 File Offset: 0x00198BB4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006488 RID: 25736 RVA: 0x0019A7BC File Offset: 0x00198BBC
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

		// Token: 0x06006489 RID: 25737 RVA: 0x0019A82C File Offset: 0x00198C2C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600648A RID: 25738 RVA: 0x0019A833 File Offset: 0x00198C33
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600648B RID: 25739 RVA: 0x0019A83C File Offset: 0x00198C3C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			KillingIntentEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0 <AsActiveUnitPerSecondProcess>c__Iterator = new KillingIntentEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0();
			<AsActiveUnitPerSecondProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitPerSecondProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitPerSecondProcess>c__Iterator;
		}

		// Token: 0x04005C7D RID: 23677
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005C7E RID: 23678
		internal KillingIntentEffectData <data>__0;

		// Token: 0x04005C7F RID: 23679
		internal int <i>__1;

		// Token: 0x04005C80 RID: 23680
		internal IBattleUnit effectCarrier;

		// Token: 0x04005C81 RID: 23681
		internal IEnumerator $locvar0;

		// Token: 0x04005C82 RID: 23682
		internal object <_>__2;

		// Token: 0x04005C83 RID: 23683
		internal IDisposable $locvar1;

		// Token: 0x04005C84 RID: 23684
		internal object $current;

		// Token: 0x04005C85 RID: 23685
		internal bool $disposing;

		// Token: 0x04005C86 RID: 23686
		internal int $PC;
	}

	// Token: 0x02000F85 RID: 3973
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600648C RID: 25740 RVA: 0x0019A87C File Offset: 0x00198C7C
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator1()
		{
		}

		// Token: 0x0600648D RID: 25741 RVA: 0x0019A884 File Offset: 0x00198C84
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitReceivesEffect || triggerUnit != effectCarrier || !(evtData is KillingIntentEffect))
				{
					goto IL_4AA;
				}
				data = (specialEffectData as KillingIntentEffectData);
				if (data == null)
				{
					goto IL_4AA;
				}
				currentStack = triggerUnit.BattleEffects.OfType<KillingIntentEffect>().Count<KillingIntentEffect>();
				if (currentStack < data.MaxStackSize)
				{
					goto IL_4AA;
				}
				toRemove = triggerUnit.BattleEffects.OfType<KillingIntentEffect>().Take(data.MaxStackSize).ToList<KillingIntentEffect>();
				enumerator = toRemove.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_2B2;
			case 3u:
				goto IL_35C;
			case 4u:
				goto IL_428;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_12:
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
					killingIntentEffect = enumerator.Current;
					enumerator2 = effectCarrier.LooseSkillEffect(killingIntentEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
					num = 4294967293u;
					goto Block_12;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			enumerator3 = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.Agility,
					ModificationType = ModificationType.Multiplication,
					Value = 0.8,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				},
				new AttributeModifier
				{
					AttributeType = effectCarrier.GetOutputAttributeType(),
					ModificationType = ModificationType.Multiplication,
					Value = 0.8,
					AttributeModifierType = AttributeModifierType.Skill,
					Key = string.Empty
				}
			}, "killingintenteffect", new int?(5), null, new int?(3), false, false, false), false).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_2B2:
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
			enumerator4 = UnitStyleConfigurationBase.PushTargetProgress(effectCarrier, effectCarrier, 0.2).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_35C:
				switch (num)
				{
				}
				if (enumerator4.MoveNext())
				{
					_3 = enumerator4.Current;
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
					if ((disposable3 = (enumerator4 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			enumerator5 = effectCarrier.ApplySkillEffect(new AdditionaTargetEffect("killingintentproc", null, new int?(2), new int?(data.ExtraTarget), effectCarrier), false).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_428:
				switch (num)
				{
				}
				if (enumerator5.MoveNext())
				{
					_4 = enumerator5.Current;
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
					if ((disposable4 = (enumerator5 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			IL_4AA:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700150F RID: 5391
		// (get) Token: 0x0600648E RID: 25742 RVA: 0x0019AD88 File Offset: 0x00199188
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001510 RID: 5392
		// (get) Token: 0x0600648F RID: 25743 RVA: 0x0019AD90 File Offset: 0x00199190
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006490 RID: 25744 RVA: 0x0019AD98 File Offset: 0x00199198
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
				}
				finally
				{
					if ((disposable3 = (enumerator4 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			case 4u:
				try
				{
				}
				finally
				{
					if ((disposable4 = (enumerator5 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06006491 RID: 25745 RVA: 0x0019AEE8 File Offset: 0x001992E8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006492 RID: 25746 RVA: 0x0019AEEF File Offset: 0x001992EF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006493 RID: 25747 RVA: 0x0019AEF8 File Offset: 0x001992F8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			KillingIntentEffectProcess.<AsActiveUnitProcess>c__Iterator1 <AsActiveUnitProcess>c__Iterator = new KillingIntentEffectProcess.<AsActiveUnitProcess>c__Iterator1();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005C87 RID: 23687
		internal AdventureEventType evtType;

		// Token: 0x04005C88 RID: 23688
		internal IBattleUnit triggerUnit;

		// Token: 0x04005C89 RID: 23689
		internal IBattleUnit effectCarrier;

		// Token: 0x04005C8A RID: 23690
		internal object evtData;

		// Token: 0x04005C8B RID: 23691
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005C8C RID: 23692
		internal KillingIntentEffectData <data>__1;

		// Token: 0x04005C8D RID: 23693
		internal int <currentStack>__2;

		// Token: 0x04005C8E RID: 23694
		internal List<KillingIntentEffect> <toRemove>__3;

		// Token: 0x04005C8F RID: 23695
		internal List<KillingIntentEffect>.Enumerator $locvar0;

		// Token: 0x04005C90 RID: 23696
		internal KillingIntentEffect <killingIntentEffect>__4;

		// Token: 0x04005C91 RID: 23697
		internal IEnumerator $locvar1;

		// Token: 0x04005C92 RID: 23698
		internal object <_>__5;

		// Token: 0x04005C93 RID: 23699
		internal IDisposable $locvar2;

		// Token: 0x04005C94 RID: 23700
		internal IEnumerator $locvar3;

		// Token: 0x04005C95 RID: 23701
		internal object <_>__6;

		// Token: 0x04005C96 RID: 23702
		internal IDisposable $locvar4;

		// Token: 0x04005C97 RID: 23703
		internal IEnumerator $locvar5;

		// Token: 0x04005C98 RID: 23704
		internal object <_>__7;

		// Token: 0x04005C99 RID: 23705
		internal IDisposable $locvar6;

		// Token: 0x04005C9A RID: 23706
		internal IEnumerator $locvar7;

		// Token: 0x04005C9B RID: 23707
		internal object <_>__8;

		// Token: 0x04005C9C RID: 23708
		internal IDisposable $locvar8;

		// Token: 0x04005C9D RID: 23709
		internal object $current;

		// Token: 0x04005C9E RID: 23710
		internal bool $disposing;

		// Token: 0x04005C9F RID: 23711
		internal int $PC;
	}
}
