using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008C2 RID: 2242
public class DamageAttributeReductionValueEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F27 RID: 16167 RVA: 0x0018A950 File Offset: 0x00188D50
	public DamageAttributeReductionValueEffectProcess()
	{
	}

	// Token: 0x17000B46 RID: 2886
	// (get) Token: 0x06003F28 RID: 16168 RVA: 0x0018A983 File Offset: 0x00188D83
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B47 RID: 2887
	// (get) Token: 0x06003F29 RID: 16169 RVA: 0x0018A98B File Offset: 0x00188D8B
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return this._correspondingEvents;
		}
	}

	// Token: 0x06003F2A RID: 16170 RVA: 0x0018A994 File Offset: 0x00188D94
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.DamageReleased && triggerUnit == effectCarrier && triggerUnit.IsPlayer && (triggerUnit.GetUnitClassStyle() == UnitClassStyle.PhysicalWarrior || triggerUnit.GetUnitClassStyle() == UnitClassStyle.SpellWarrior) && evtData is ReleaseableDamage && specialEffectData is DamageAttributeReductionByValueData)
		{
			ReleaseableDamage damage = evtData as ReleaseableDamage;
			List<IBattleUnit> directDamageTargets = (from d in damage.BattleDamages
			where d.Damages.Any((DamageComponent dd) => dd.IsDirectDamage)
			select d.Target).ToList<IBattleUnit>();
			if (directDamageTargets.Any<IBattleUnit>())
			{
				DamageAttributeReductionByValueData data = specialEffectData as DamageAttributeReductionByValueData;
				foreach (IBattleUnit directDamageTarget in directDamageTargets)
				{
					IEnumerator enumerator2 = directDamageTarget.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(damage.Dealer, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = data.AttributeType,
							ModificationType = ModificationType.Addition,
							Key = string.Empty,
							Value = -data.ReductionRate,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, "directdamagereductionbyvalueunique", new int?(1), null, new int?(3), true, true), false).GetEnumerator();
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

	// Token: 0x04002F70 RID: 12144
	private SpecialEffectType _correspondingEffectType = SpecialEffectType.DamageAttributeReductionByValue;

	// Token: 0x04002F71 RID: 12145
	private List<AdventureEventType> _correspondingEvents = new List<AdventureEventType>
	{
		AdventureEventType.DamageReleased
	};

	// Token: 0x02000F39 RID: 3897
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006278 RID: 25208 RVA: 0x0018A9D5 File Offset: 0x00188DD5
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006279 RID: 25209 RVA: 0x0018A9E0 File Offset: 0x00188DE0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.DamageReleased || triggerUnit != effectCarrier || !triggerUnit.IsPlayer || (triggerUnit.GetUnitClassStyle() != UnitClassStyle.PhysicalWarrior && triggerUnit.GetUnitClassStyle() != UnitClassStyle.SpellWarrior) || !(evtData is ReleaseableDamage) || !(specialEffectData is DamageAttributeReductionByValueData))
				{
					goto IL_29B;
				}
				damage = (evtData as ReleaseableDamage);
				directDamageTargets = (from d in damage.BattleDamages
				where d.Damages.Any((DamageComponent dd) => dd.IsDirectDamage)
				select d.Target).ToList<IBattleUnit>();
				if (!directDamageTargets.Any<IBattleUnit>())
				{
					goto IL_29B;
				}
				data = (specialEffectData as DamageAttributeReductionByValueData);
				enumerator = directDamageTargets.GetEnumerator();
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
					directDamageTarget = enumerator.Current;
					enumerator2 = directDamageTarget.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(damage.Dealer, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = data.AttributeType,
							ModificationType = ModificationType.Addition,
							Key = string.Empty,
							Value = -data.ReductionRate,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, "directdamagereductionbyvalueunique", new int?(1), null, new int?(3), true, true), false).GetEnumerator();
					num = 4294967293u;
					goto Block_13;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_29B:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700149D RID: 5277
		// (get) Token: 0x0600627A RID: 25210 RVA: 0x0018ACC8 File Offset: 0x001890C8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700149E RID: 5278
		// (get) Token: 0x0600627B RID: 25211 RVA: 0x0018ACD0 File Offset: 0x001890D0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600627C RID: 25212 RVA: 0x0018ACD8 File Offset: 0x001890D8
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

		// Token: 0x0600627D RID: 25213 RVA: 0x0018AD6C File Offset: 0x0018916C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600627E RID: 25214 RVA: 0x0018AD73 File Offset: 0x00189173
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600627F RID: 25215 RVA: 0x0018AD7C File Offset: 0x0018917C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DamageAttributeReductionValueEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new DamageAttributeReductionValueEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x06006280 RID: 25216 RVA: 0x0018ADE0 File Offset: 0x001891E0
		private static bool <>m__0(BattleDamage d)
		{
			return d.Damages.Any((DamageComponent dd) => dd.IsDirectDamage);
		}

		// Token: 0x06006281 RID: 25217 RVA: 0x0018AE0A File Offset: 0x0018920A
		private static IBattleUnit <>m__1(BattleDamage d)
		{
			return d.Target;
		}

		// Token: 0x06006282 RID: 25218 RVA: 0x0018AE12 File Offset: 0x00189212
		private static bool <>m__2(DamageComponent dd)
		{
			return dd.IsDirectDamage;
		}

		// Token: 0x040058DD RID: 22749
		internal AdventureEventType evtType;

		// Token: 0x040058DE RID: 22750
		internal IBattleUnit triggerUnit;

		// Token: 0x040058DF RID: 22751
		internal IBattleUnit effectCarrier;

		// Token: 0x040058E0 RID: 22752
		internal object evtData;

		// Token: 0x040058E1 RID: 22753
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x040058E2 RID: 22754
		internal ReleaseableDamage <damage>__1;

		// Token: 0x040058E3 RID: 22755
		internal List<IBattleUnit> <directDamageTargets>__1;

		// Token: 0x040058E4 RID: 22756
		internal DamageAttributeReductionByValueData <data>__2;

		// Token: 0x040058E5 RID: 22757
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x040058E6 RID: 22758
		internal IBattleUnit <directDamageTarget>__3;

		// Token: 0x040058E7 RID: 22759
		internal IEnumerator $locvar1;

		// Token: 0x040058E8 RID: 22760
		internal object <_>__4;

		// Token: 0x040058E9 RID: 22761
		internal IDisposable $locvar2;

		// Token: 0x040058EA RID: 22762
		internal object $current;

		// Token: 0x040058EB RID: 22763
		internal bool $disposing;

		// Token: 0x040058EC RID: 22764
		internal int $PC;

		// Token: 0x040058ED RID: 22765
		private static Func<BattleDamage, bool> <>f__am$cache0;

		// Token: 0x040058EE RID: 22766
		private static Func<BattleDamage, IBattleUnit> <>f__am$cache1;

		// Token: 0x040058EF RID: 22767
		private static Func<DamageComponent, bool> <>f__am$cache2;
	}
}
