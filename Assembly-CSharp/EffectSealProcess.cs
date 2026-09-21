using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008D9 RID: 2265
public class EffectSealProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F89 RID: 16265 RVA: 0x00192015 File Offset: 0x00190415
	public EffectSealProcess()
	{
	}

	// Token: 0x17000B74 RID: 2932
	// (get) Token: 0x06003F8A RID: 16266 RVA: 0x0019201D File Offset: 0x0019041D
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.EffectSeal;
		}
	}

	// Token: 0x17000B75 RID: 2933
	// (get) Token: 0x06003F8B RID: 16267 RVA: 0x00192024 File Offset: 0x00190424
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

	// Token: 0x06003F8C RID: 16268 RVA: 0x00192040 File Offset: 0x00190440
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && evtData is DamageComponent && specialEffectData is EffectSealData)
		{
			DamageComponent damage = evtData as DamageComponent;
			if (damage.Dealer == effectCarrier && damage.Target == triggerUnit)
			{
				EffectSealData data = specialEffectData as EffectSealData;
				if ((double)UnityEngine.Random.value <= data.Chance && damage.Target.IsAliveInBattle())
				{
					IEnumerator enumerator = damage.Target.ApplySkillEffect(new SealedEffect(null, new int?(2), effectCarrier), false).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x02000F57 RID: 3927
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006350 RID: 25424 RVA: 0x00192081 File Offset: 0x00190481
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006351 RID: 25425 RVA: 0x0019208C File Offset: 0x0019048C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitPostReceivesDamage_Single || !(evtData is DamageComponent) || !(specialEffectData is EffectSealData))
				{
					goto IL_184;
				}
				damage = (evtData as DamageComponent);
				if (damage.Dealer != effectCarrier || damage.Target != triggerUnit)
				{
					goto IL_184;
				}
				data = (specialEffectData as EffectSealData);
				if ((double)UnityEngine.Random.value > data.Chance || !damage.Target.IsAliveInBattle())
				{
					goto IL_184;
				}
				enumerator = damage.Target.ApplySkillEffect(new SealedEffect(null, new int?(2), effectCarrier), false).GetEnumerator();
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
			IL_184:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014CB RID: 5323
		// (get) Token: 0x06006352 RID: 25426 RVA: 0x00192238 File Offset: 0x00190638
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014CC RID: 5324
		// (get) Token: 0x06006353 RID: 25427 RVA: 0x00192240 File Offset: 0x00190640
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006354 RID: 25428 RVA: 0x00192248 File Offset: 0x00190648
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

		// Token: 0x06006355 RID: 25429 RVA: 0x001922B8 File Offset: 0x001906B8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006356 RID: 25430 RVA: 0x001922BF File Offset: 0x001906BF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006357 RID: 25431 RVA: 0x001922C8 File Offset: 0x001906C8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			EffectSealProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new EffectSealProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005A7E RID: 23166
		internal AdventureEventType evtType;

		// Token: 0x04005A7F RID: 23167
		internal object evtData;

		// Token: 0x04005A80 RID: 23168
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005A81 RID: 23169
		internal DamageComponent <damage>__1;

		// Token: 0x04005A82 RID: 23170
		internal IBattleUnit effectCarrier;

		// Token: 0x04005A83 RID: 23171
		internal IBattleUnit triggerUnit;

		// Token: 0x04005A84 RID: 23172
		internal EffectSealData <data>__2;

		// Token: 0x04005A85 RID: 23173
		internal IEnumerator $locvar0;

		// Token: 0x04005A86 RID: 23174
		internal object <_>__3;

		// Token: 0x04005A87 RID: 23175
		internal IDisposable $locvar1;

		// Token: 0x04005A88 RID: 23176
		internal object $current;

		// Token: 0x04005A89 RID: 23177
		internal bool $disposing;

		// Token: 0x04005A8A RID: 23178
		internal int $PC;
	}
}
