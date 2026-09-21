using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008DE RID: 2270
public class EvilHeartEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003FA0 RID: 16288 RVA: 0x00192E2C File Offset: 0x0019122C
	public EvilHeartEffectProcess()
	{
	}

	// Token: 0x17000B7E RID: 2942
	// (get) Token: 0x06003FA1 RID: 16289 RVA: 0x00192E34 File Offset: 0x00191234
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.EvilHeart;
		}
	}

	// Token: 0x17000B7F RID: 2943
	// (get) Token: 0x06003FA2 RID: 16290 RVA: 0x00192E38 File Offset: 0x00191238
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

	// Token: 0x06003FA3 RID: 16291 RVA: 0x00192E54 File Offset: 0x00191254
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReceivesEffect && evtData is LockTimeEffect)
		{
			LockTimeEffect ef = evtData as LockTimeEffect;
			if (ef.SourceUnit == effectCarrier && specialEffectData is EvilHeartData)
			{
				EvilHeartData data = specialEffectData as EvilHeartData;
				IEnumerator enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.EffectMastery,
						ModificationType = ModificationType.Addition,
						Value = data.MasteryRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.HitRateAdjustment,
						ModificationType = ModificationType.Addition,
						Value = data.HitRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "evilheart", new int?(3), null, null, false, false, false), false).GetEnumerator();
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

	// Token: 0x02000F5C RID: 3932
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006373 RID: 25459 RVA: 0x00192E8E File Offset: 0x0019128E
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006374 RID: 25460 RVA: 0x00192E98 File Offset: 0x00191298
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitReceivesEffect || !(evtData is LockTimeEffect))
				{
					goto IL_1DE;
				}
				ef = (evtData as LockTimeEffect);
				if (ef.SourceUnit != effectCarrier || !(specialEffectData is EvilHeartData))
				{
					goto IL_1DE;
				}
				data = (specialEffectData as EvilHeartData);
				enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.EffectMastery,
						ModificationType = ModificationType.Addition,
						Value = data.MasteryRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.HitRateAdjustment,
						ModificationType = ModificationType.Addition,
						Value = data.HitRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "evilheart", new int?(3), null, null, false, false, false), false).GetEnumerator();
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
			IL_1DE:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014D3 RID: 5331
		// (get) Token: 0x06006375 RID: 25461 RVA: 0x001930A0 File Offset: 0x001914A0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014D4 RID: 5332
		// (get) Token: 0x06006376 RID: 25462 RVA: 0x001930A8 File Offset: 0x001914A8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006377 RID: 25463 RVA: 0x001930B0 File Offset: 0x001914B0
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

		// Token: 0x06006378 RID: 25464 RVA: 0x00193120 File Offset: 0x00191520
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006379 RID: 25465 RVA: 0x00193127 File Offset: 0x00191527
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600637A RID: 25466 RVA: 0x00193130 File Offset: 0x00191530
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			EvilHeartEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new EvilHeartEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005AB1 RID: 23217
		internal AdventureEventType evtType;

		// Token: 0x04005AB2 RID: 23218
		internal object evtData;

		// Token: 0x04005AB3 RID: 23219
		internal LockTimeEffect <ef>__1;

		// Token: 0x04005AB4 RID: 23220
		internal IBattleUnit effectCarrier;

		// Token: 0x04005AB5 RID: 23221
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005AB6 RID: 23222
		internal EvilHeartData <data>__2;

		// Token: 0x04005AB7 RID: 23223
		internal IEnumerator $locvar0;

		// Token: 0x04005AB8 RID: 23224
		internal object <_>__3;

		// Token: 0x04005AB9 RID: 23225
		internal IDisposable $locvar1;

		// Token: 0x04005ABA RID: 23226
		internal object $current;

		// Token: 0x04005ABB RID: 23227
		internal bool $disposing;

		// Token: 0x04005ABC RID: 23228
		internal int $PC;
	}
}
