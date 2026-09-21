using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008D2 RID: 2258
public class DodgeProtectionEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F6B RID: 16235 RVA: 0x00190629 File Offset: 0x0018EA29
	public DodgeProtectionEffectProcess()
	{
	}

	// Token: 0x17000B66 RID: 2918
	// (get) Token: 0x06003F6C RID: 16236 RVA: 0x00190631 File Offset: 0x0018EA31
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.DodgeProtection;
		}
	}

	// Token: 0x17000B67 RID: 2919
	// (get) Token: 0x06003F6D RID: 16237 RVA: 0x00190638 File Offset: 0x0018EA38
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

	// Token: 0x06003F6E RID: 16238 RVA: 0x00190654 File Offset: 0x0018EA54
	public override IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.UnitPostReceivesDamage_Single && evt.EventTriggeringUnit.IsPlayer && evt.AdditionalData is DamageComponent && specialEffectData is DodgeProtectionData)
		{
			DamageComponent damage = evt.AdditionalData as DamageComponent;
			if (damage.IsMissed)
			{
				DodgeProtectionData data = specialEffectData as DodgeProtectionData;
				ReleaseableHeal heal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(evt.EventTriggeringUnit, evt.EventTriggeringUnit, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = evt.EventTriggeringUnit.GetMaxLife(AttributeRetrievalLevel.Skill) * data.RecoveryRate,
							IsDirectHeal = false,
							HealType = OutputType.RealHeal
						}
					}, false)
				}, evt.EventTriggeringUnit);
				IEnumerator enumerator = heal.Release().GetEnumerator();
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

	// Token: 0x02000F51 RID: 3921
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006322 RID: 25378 RVA: 0x0019067E File Offset: 0x0018EA7E
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator0()
		{
		}

		// Token: 0x06006323 RID: 25379 RVA: 0x00190688 File Offset: 0x0018EA88
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evt.EventType != AdventureEventType.UnitPostReceivesDamage_Single || !evt.EventTriggeringUnit.IsPlayer || !(evt.AdditionalData is DamageComponent) || !(specialEffectData is DodgeProtectionData))
				{
					goto IL_1CD;
				}
				damage = (evt.AdditionalData as DamageComponent);
				if (!damage.IsMissed)
				{
					goto IL_1CD;
				}
				data = (specialEffectData as DodgeProtectionData);
				heal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(evt.EventTriggeringUnit, evt.EventTriggeringUnit, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = evt.EventTriggeringUnit.GetMaxLife(AttributeRetrievalLevel.Skill) * data.RecoveryRate,
							IsDirectHeal = false,
							HealType = OutputType.RealHeal
						}
					}, false)
				}, evt.EventTriggeringUnit);
				enumerator = heal.Release().GetEnumerator();
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
			IL_1CD:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014C1 RID: 5313
		// (get) Token: 0x06006324 RID: 25380 RVA: 0x0019087C File Offset: 0x0018EC7C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014C2 RID: 5314
		// (get) Token: 0x06006325 RID: 25381 RVA: 0x00190884 File Offset: 0x0018EC84
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006326 RID: 25382 RVA: 0x0019088C File Offset: 0x0018EC8C
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

		// Token: 0x06006327 RID: 25383 RVA: 0x001908FC File Offset: 0x0018ECFC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006328 RID: 25384 RVA: 0x00190903 File Offset: 0x0018ED03
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006329 RID: 25385 RVA: 0x0019090C File Offset: 0x0018ED0C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DodgeProtectionEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <AsAdventureEffectProcess>c__Iterator = new DodgeProtectionEffectProcess.<AsAdventureEffectProcess>c__Iterator0();
			<AsAdventureEffectProcess>c__Iterator.evt = evt;
			<AsAdventureEffectProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsAdventureEffectProcess>c__Iterator;
		}

		// Token: 0x04005A31 RID: 23089
		internal BroadcastEvent evt;

		// Token: 0x04005A32 RID: 23090
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005A33 RID: 23091
		internal DamageComponent <damage>__1;

		// Token: 0x04005A34 RID: 23092
		internal DodgeProtectionData <data>__2;

		// Token: 0x04005A35 RID: 23093
		internal ReleaseableHeal <heal>__2;

		// Token: 0x04005A36 RID: 23094
		internal IEnumerator $locvar0;

		// Token: 0x04005A37 RID: 23095
		internal object <_>__3;

		// Token: 0x04005A38 RID: 23096
		internal IDisposable $locvar1;

		// Token: 0x04005A39 RID: 23097
		internal object $current;

		// Token: 0x04005A3A RID: 23098
		internal bool $disposing;

		// Token: 0x04005A3B RID: 23099
		internal int $PC;
	}
}
