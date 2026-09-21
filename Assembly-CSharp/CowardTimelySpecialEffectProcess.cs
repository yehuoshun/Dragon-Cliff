using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008C0 RID: 2240
public class CowardTimelySpecialEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F1F RID: 16159 RVA: 0x00189E72 File Offset: 0x00188272
	public CowardTimelySpecialEffectProcess()
	{
	}

	// Token: 0x17000B42 RID: 2882
	// (get) Token: 0x06003F20 RID: 16160 RVA: 0x00189E81 File Offset: 0x00188281
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B43 RID: 2883
	// (get) Token: 0x06003F21 RID: 16161 RVA: 0x00189E8C File Offset: 0x0018828C
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

	// Token: 0x06003F22 RID: 16162 RVA: 0x00189EA8 File Offset: 0x001882A8
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (triggerUnit == effectCarrier && evtType == AdventureEventType.UnitReadyInBattle)
		{
			CowardTimelyData data = specialEffectData as CowardTimelyData;
			IEnumerator enumerator = triggerUnit.ApplySkillEffect(new TimelyCowardActiveEffect(data.MaxStayingSeconds, triggerUnit, base.GetType().FullName), false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x04002F6F RID: 12143
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.CowardTimely;

	// Token: 0x02000F36 RID: 3894
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006265 RID: 25189 RVA: 0x00189EE8 File Offset: 0x001882E8
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006266 RID: 25190 RVA: 0x00189EF0 File Offset: 0x001882F0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (triggerUnit != effectCarrier || evtType != AdventureEventType.UnitReadyInBattle)
				{
					goto IL_114;
				}
				data = (specialEffectData as CowardTimelyData);
				enumerator = triggerUnit.ApplySkillEffect(new TimelyCowardActiveEffect(data.MaxStayingSeconds, triggerUnit, base.GetType().FullName), false).GetEnumerator();
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
			IL_114:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001499 RID: 5273
		// (get) Token: 0x06006267 RID: 25191 RVA: 0x0018A02C File Offset: 0x0018842C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700149A RID: 5274
		// (get) Token: 0x06006268 RID: 25192 RVA: 0x0018A034 File Offset: 0x00188434
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006269 RID: 25193 RVA: 0x0018A03C File Offset: 0x0018843C
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

		// Token: 0x0600626A RID: 25194 RVA: 0x0018A0AC File Offset: 0x001884AC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600626B RID: 25195 RVA: 0x0018A0B3 File Offset: 0x001884B3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600626C RID: 25196 RVA: 0x0018A0BC File Offset: 0x001884BC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			CowardTimelySpecialEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new CowardTimelySpecialEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.$this = this;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x040058B7 RID: 22711
		internal IBattleUnit triggerUnit;

		// Token: 0x040058B8 RID: 22712
		internal IBattleUnit effectCarrier;

		// Token: 0x040058B9 RID: 22713
		internal AdventureEventType evtType;

		// Token: 0x040058BA RID: 22714
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x040058BB RID: 22715
		internal CowardTimelyData <data>__1;

		// Token: 0x040058BC RID: 22716
		internal IEnumerator $locvar0;

		// Token: 0x040058BD RID: 22717
		internal object <_>__2;

		// Token: 0x040058BE RID: 22718
		internal IDisposable $locvar1;

		// Token: 0x040058BF RID: 22719
		internal CowardTimelySpecialEffectProcess $this;

		// Token: 0x040058C0 RID: 22720
		internal object $current;

		// Token: 0x040058C1 RID: 22721
		internal bool $disposing;

		// Token: 0x040058C2 RID: 22722
		internal int $PC;
	}
}
