using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020008AE RID: 2222
public class AttributeDestroyEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003EC8 RID: 16072 RVA: 0x001843BC File Offset: 0x001827BC
	public AttributeDestroyEffectProcess()
	{
	}

	// Token: 0x17000B1E RID: 2846
	// (get) Token: 0x06003EC9 RID: 16073 RVA: 0x001843C4 File Offset: 0x001827C4
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.AttributeDestroy;
		}
	}

	// Token: 0x17000B1F RID: 2847
	// (get) Token: 0x06003ECA RID: 16074 RVA: 0x001843C8 File Offset: 0x001827C8
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.DamageReleased
			};
		}
	}

	// Token: 0x06003ECB RID: 16075 RVA: 0x001843E4 File Offset: 0x001827E4
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.DamageReleased && triggerUnit == effectCarrier && evtData is ReleaseableDamage)
		{
			ReleaseableDamage damage = evtData as ReleaseableDamage;
			if (damage.Dealer == effectCarrier && specialEffectData is AttributeDestroyData)
			{
				AttributeDestroyData data = specialEffectData as AttributeDestroyData;
				foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
				{
					bool trigger = false;
					if (damageBattleDamage.Target.IsAliveInBattle())
					{
						foreach (DamageComponent damageComponent in from d in damageBattleDamage.Damages
						where d.IsDirectDamage && !d.IsMissed
						select d)
						{
							if ((double)UnityEngine.Random.value <= data.Chance)
							{
								trigger = true;
							}
						}
					}
					if (trigger)
					{
						AttributeModificationEffect effect = AttributeModificationEffect.CreateArmorReplaceEffect(effectCarrier, data.ReplacementValue, data.ReplaceAttribute, base.GetType().FullName);
						IEnumerator enumerator3 = damageBattleDamage.Target.ApplySkillEffect(effect, false).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x02000F16 RID: 3862
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006198 RID: 24984 RVA: 0x0018442C File Offset: 0x0018282C
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006199 RID: 24985 RVA: 0x00184434 File Offset: 0x00182834
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.DamageReleased || triggerUnit != effectCarrier || !(evtData is ReleaseableDamage))
				{
					goto IL_27F;
				}
				damage = (evtData as ReleaseableDamage);
				if (damage.Dealer != effectCarrier || !(specialEffectData is AttributeDestroyData))
				{
					goto IL_27F;
				}
				data = (specialEffectData as AttributeDestroyData);
				enumerator = damage.BattleDamages.GetEnumerator();
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
					Block_13:
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
				while (enumerator.MoveNext())
				{
					damageBattleDamage = enumerator.Current;
					trigger = false;
					if (damageBattleDamage.Target.IsAliveInBattle())
					{
						foreach (DamageComponent damageComponent in from d in damageBattleDamage.Damages
						where d.IsDirectDamage && !d.IsMissed
						select d)
						{
							if ((double)UnityEngine.Random.value <= data.Chance)
							{
								trigger = true;
							}
						}
					}
					if (trigger)
					{
						effect = AttributeModificationEffect.CreateArmorReplaceEffect(effectCarrier, data.ReplacementValue, data.ReplaceAttribute, base.GetType().FullName);
						enumerator3 = damageBattleDamage.Target.ApplySkillEffect(effect, false).GetEnumerator();
						num = 4294967293u;
						goto Block_13;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_27F:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001471 RID: 5233
		// (get) Token: 0x0600619A RID: 24986 RVA: 0x00184718 File Offset: 0x00182B18
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001472 RID: 5234
		// (get) Token: 0x0600619B RID: 24987 RVA: 0x00184720 File Offset: 0x00182B20
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600619C RID: 24988 RVA: 0x00184728 File Offset: 0x00182B28
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
						if ((disposable = (enumerator3 as IDisposable)) != null)
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

		// Token: 0x0600619D RID: 24989 RVA: 0x001847BC File Offset: 0x00182BBC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600619E RID: 24990 RVA: 0x001847C3 File Offset: 0x00182BC3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600619F RID: 24991 RVA: 0x001847CC File Offset: 0x00182BCC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			AttributeDestroyEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new AttributeDestroyEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.$this = this;
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x060061A0 RID: 24992 RVA: 0x0018483C File Offset: 0x00182C3C
		private static bool <>m__0(DamageComponent d)
		{
			return d.IsDirectDamage && !d.IsMissed;
		}

		// Token: 0x04005750 RID: 22352
		internal AdventureEventType evtType;

		// Token: 0x04005751 RID: 22353
		internal IBattleUnit triggerUnit;

		// Token: 0x04005752 RID: 22354
		internal IBattleUnit effectCarrier;

		// Token: 0x04005753 RID: 22355
		internal object evtData;

		// Token: 0x04005754 RID: 22356
		internal ReleaseableDamage <damage>__1;

		// Token: 0x04005755 RID: 22357
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005756 RID: 22358
		internal AttributeDestroyData <data>__2;

		// Token: 0x04005757 RID: 22359
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04005758 RID: 22360
		internal BattleDamage <damageBattleDamage>__3;

		// Token: 0x04005759 RID: 22361
		internal bool <trigger>__4;

		// Token: 0x0400575A RID: 22362
		internal AttributeModificationEffect <effect>__5;

		// Token: 0x0400575B RID: 22363
		internal IEnumerator $locvar2;

		// Token: 0x0400575C RID: 22364
		internal object <_>__6;

		// Token: 0x0400575D RID: 22365
		internal IDisposable $locvar3;

		// Token: 0x0400575E RID: 22366
		internal AttributeDestroyEffectProcess $this;

		// Token: 0x0400575F RID: 22367
		internal object $current;

		// Token: 0x04005760 RID: 22368
		internal bool $disposing;

		// Token: 0x04005761 RID: 22369
		internal int $PC;

		// Token: 0x04005762 RID: 22370
		private static Func<DamageComponent, bool> <>f__am$cache0;
	}
}
