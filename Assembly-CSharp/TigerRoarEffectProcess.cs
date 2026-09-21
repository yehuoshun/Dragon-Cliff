using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000938 RID: 2360
public class TigerRoarEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06004137 RID: 16695 RVA: 0x001AAF9E File Offset: 0x001A939E
	public TigerRoarEffectProcess()
	{
	}

	// Token: 0x17000C2F RID: 3119
	// (get) Token: 0x06004138 RID: 16696 RVA: 0x001AAFA6 File Offset: 0x001A93A6
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.TigerRoar;
		}
	}

	// Token: 0x17000C30 RID: 3120
	// (get) Token: 0x06004139 RID: 16697 RVA: 0x001AAFAC File Offset: 0x001A93AC
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

	// Token: 0x0600413A RID: 16698 RVA: 0x001AAFC8 File Offset: 0x001A93C8
	public override IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.DamageReleased && evt.EventTriggeringUnit.IsPlayer && specialEffectData is TigerRoarData && evt.AdditionalData is ReleaseableDamage)
		{
			ReleaseableDamage damage = evt.AdditionalData as ReleaseableDamage;
			TigerRoarData data = specialEffectData as TigerRoarData;
			foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
			{
				bool hit = false;
				foreach (DamageComponent damageComponent in damageBattleDamage.Damages)
				{
					if (damageComponent.IsDirectDamage && !damageComponent.IsMissed && (double)UnityEngine.Random.value <= data.Chance)
					{
						hit = true;
					}
				}
				if (hit)
				{
					IEnumerator enumerator3 = damageBattleDamage.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(evt.EventTriggeringUnit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.HitRateAdjustment,
							ModificationType = ModificationType.Addition,
							Value = -data.ReductionRate,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						},
						new AttributeModifier
						{
							AttributeType = AttributeType.DodgeRateAdjustment,
							ModificationType = ModificationType.Addition,
							Value = -data.ReductionRate,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, "tigerRoareffect", new int?(1), new float?((float)data.LastingSeconds), null, true, true), false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x02000FDD RID: 4061
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060066E4 RID: 26340 RVA: 0x001AAFF2 File Offset: 0x001A93F2
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator0()
		{
		}

		// Token: 0x060066E5 RID: 26341 RVA: 0x001AAFFC File Offset: 0x001A93FC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evt.EventType != AdventureEventType.DamageReleased || !evt.EventTriggeringUnit.IsPlayer || !(specialEffectData is TigerRoarData) || !(evt.AdditionalData is ReleaseableDamage))
				{
					goto IL_305;
				}
				damage = (evt.AdditionalData as ReleaseableDamage);
				data = (specialEffectData as TigerRoarData);
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
					Block_10:
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
					hit = false;
					enumerator2 = damageBattleDamage.Damages.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							DamageComponent damageComponent = enumerator2.Current;
							if (damageComponent.IsDirectDamage && !damageComponent.IsMissed && (double)UnityEngine.Random.value <= data.Chance)
							{
								hit = true;
							}
						}
					}
					finally
					{
						((IDisposable)enumerator2).Dispose();
					}
					if (hit)
					{
						enumerator3 = damageBattleDamage.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(evt.EventTriggeringUnit, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = AttributeType.HitRateAdjustment,
								ModificationType = ModificationType.Addition,
								Value = -data.ReductionRate,
								Key = string.Empty,
								AttributeModifierType = AttributeModifierType.Skill
							},
							new AttributeModifier
							{
								AttributeType = AttributeType.DodgeRateAdjustment,
								ModificationType = ModificationType.Addition,
								Value = -data.ReductionRate,
								Key = string.Empty,
								AttributeModifierType = AttributeModifierType.Skill
							}
						}, "tigerRoareffect", new int?(1), new float?((float)data.LastingSeconds), null, true, true), false).GetEnumerator();
						num = 4294967293u;
						goto Block_10;
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
			IL_305:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001595 RID: 5525
		// (get) Token: 0x060066E6 RID: 26342 RVA: 0x001AB364 File Offset: 0x001A9764
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001596 RID: 5526
		// (get) Token: 0x060066E7 RID: 26343 RVA: 0x001AB36C File Offset: 0x001A976C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060066E8 RID: 26344 RVA: 0x001AB374 File Offset: 0x001A9774
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

		// Token: 0x060066E9 RID: 26345 RVA: 0x001AB408 File Offset: 0x001A9808
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060066EA RID: 26346 RVA: 0x001AB40F File Offset: 0x001A980F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060066EB RID: 26347 RVA: 0x001AB418 File Offset: 0x001A9818
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			TigerRoarEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <AsAdventureEffectProcess>c__Iterator = new TigerRoarEffectProcess.<AsAdventureEffectProcess>c__Iterator0();
			<AsAdventureEffectProcess>c__Iterator.evt = evt;
			<AsAdventureEffectProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsAdventureEffectProcess>c__Iterator;
		}

		// Token: 0x04006083 RID: 24707
		internal BroadcastEvent evt;

		// Token: 0x04006084 RID: 24708
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04006085 RID: 24709
		internal ReleaseableDamage <damage>__1;

		// Token: 0x04006086 RID: 24710
		internal TigerRoarData <data>__1;

		// Token: 0x04006087 RID: 24711
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04006088 RID: 24712
		internal BattleDamage <damageBattleDamage>__2;

		// Token: 0x04006089 RID: 24713
		internal bool <hit>__3;

		// Token: 0x0400608A RID: 24714
		internal List<DamageComponent>.Enumerator $locvar1;

		// Token: 0x0400608B RID: 24715
		internal IEnumerator $locvar2;

		// Token: 0x0400608C RID: 24716
		internal object <_>__4;

		// Token: 0x0400608D RID: 24717
		internal IDisposable $locvar3;

		// Token: 0x0400608E RID: 24718
		internal object $current;

		// Token: 0x0400608F RID: 24719
		internal bool $disposing;

		// Token: 0x04006090 RID: 24720
		internal int $PC;
	}
}
