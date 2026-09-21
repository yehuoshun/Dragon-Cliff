using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008E4 RID: 2276
public class FadeoutSpecialEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003FB9 RID: 16313 RVA: 0x001942E4 File Offset: 0x001926E4
	public FadeoutSpecialEffectProcess()
	{
	}

	// Token: 0x17000B8A RID: 2954
	// (get) Token: 0x06003FBA RID: 16314 RVA: 0x001942F4 File Offset: 0x001926F4
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B8B RID: 2955
	// (get) Token: 0x06003FBB RID: 16315 RVA: 0x001942FC File Offset: 0x001926FC
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitRegularTurnStarts,
				AdventureEventType.UnitEntersTurn
			};
		}
	}

	// Token: 0x06003FBC RID: 16316 RVA: 0x00194320 File Offset: 0x00192720
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (triggerUnit == effectCarrier)
		{
			FadeoutData data = specialEffectData as FadeoutData;
			if (data.TriggerEventType == evtType && (double)UnityEngine.Random.value <= data.Chance)
			{
				IEnumerator enumerator = effectCarrier.ApplySkillEffect(new FadeEffect(effectCarrier, base.GetType().FullName, data.LastingTurns), false).GetEnumerator();
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

	// Token: 0x04002F89 RID: 12169
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.Fadeout;

	// Token: 0x02000F61 RID: 3937
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060063A3 RID: 25507 RVA: 0x00194360 File Offset: 0x00192760
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060063A4 RID: 25508 RVA: 0x00194368 File Offset: 0x00192768
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (triggerUnit != effectCarrier)
				{
					goto IL_133;
				}
				data = (specialEffectData as FadeoutData);
				if (data.TriggerEventType != evtType || (double)UnityEngine.Random.value > data.Chance)
				{
					goto IL_133;
				}
				enumerator = effectCarrier.ApplySkillEffect(new FadeEffect(effectCarrier, base.GetType().FullName, data.LastingTurns), false).GetEnumerator();
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
			IL_133:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014DD RID: 5341
		// (get) Token: 0x060063A5 RID: 25509 RVA: 0x001944C4 File Offset: 0x001928C4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014DE RID: 5342
		// (get) Token: 0x060063A6 RID: 25510 RVA: 0x001944CC File Offset: 0x001928CC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060063A7 RID: 25511 RVA: 0x001944D4 File Offset: 0x001928D4
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

		// Token: 0x060063A8 RID: 25512 RVA: 0x00194544 File Offset: 0x00192944
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060063A9 RID: 25513 RVA: 0x0019454B File Offset: 0x0019294B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060063AA RID: 25514 RVA: 0x00194554 File Offset: 0x00192954
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			FadeoutSpecialEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new FadeoutSpecialEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.$this = this;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005B01 RID: 23297
		internal IBattleUnit triggerUnit;

		// Token: 0x04005B02 RID: 23298
		internal IBattleUnit effectCarrier;

		// Token: 0x04005B03 RID: 23299
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005B04 RID: 23300
		internal FadeoutData <data>__1;

		// Token: 0x04005B05 RID: 23301
		internal AdventureEventType evtType;

		// Token: 0x04005B06 RID: 23302
		internal IEnumerator $locvar0;

		// Token: 0x04005B07 RID: 23303
		internal object <_>__2;

		// Token: 0x04005B08 RID: 23304
		internal IDisposable $locvar1;

		// Token: 0x04005B09 RID: 23305
		internal FadeoutSpecialEffectProcess $this;

		// Token: 0x04005B0A RID: 23306
		internal object $current;

		// Token: 0x04005B0B RID: 23307
		internal bool $disposing;

		// Token: 0x04005B0C RID: 23308
		internal int $PC;
	}
}
