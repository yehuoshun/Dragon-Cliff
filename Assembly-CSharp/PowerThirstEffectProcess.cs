using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000910 RID: 2320
public class PowerThirstEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x0600407F RID: 16511 RVA: 0x0019F6A4 File Offset: 0x0019DAA4
	public PowerThirstEffectProcess()
	{
	}

	// Token: 0x17000BE1 RID: 3041
	// (get) Token: 0x06004080 RID: 16512 RVA: 0x0019F6AC File Offset: 0x0019DAAC
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.PowerThirst;
		}
	}

	// Token: 0x17000BE2 RID: 3042
	// (get) Token: 0x06004081 RID: 16513 RVA: 0x0019F6B0 File Offset: 0x0019DAB0
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

	// Token: 0x06004082 RID: 16514 RVA: 0x0019F6CC File Offset: 0x0019DACC
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.DamageReleased && triggerUnit == effectCarrier && specialEffectData is PowerThirstData && evtData is ReleaseableDamage)
		{
			ReleaseableDamage damage = evtData as ReleaseableDamage;
			PowerThirstData data = specialEffectData as PowerThirstData;
			List<IBattleUnit> targets = new List<IBattleUnit>();
			using (List<BattleDamage>.Enumerator enumerator = damage.BattleDamages.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					BattleDamage damageBattleDamage = enumerator.Current;
					if (targets.All((IBattleUnit t) => t.GetId() != damageBattleDamage.Target.GetId()))
					{
						targets.Add(damageBattleDamage.Target);
					}
				}
			}
			double totalOutputCollected = 0.0;
			foreach (IBattleUnit battleUnit in targets)
			{
				double outputCollection = data.SuctionRate * battleUnit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value;
				if (outputCollection > 0.0)
				{
					totalOutputCollected += outputCollection;
					IEnumerator enumerator3 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = battleUnit.GetOutputAttributeType(),
							ModificationType = ModificationType.Addition,
							Value = -outputCollection,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, "powerthirstnegativeunique", new int?(5), null, new int?(2), true, true), false).GetEnumerator();
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
			if (totalOutputCollected > 0.0)
			{
				List<IBattleUnit> friendlyUnits = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true);
				foreach (IBattleUnit unit in friendlyUnits)
				{
					IEnumerator enumerator5 = unit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = unit.GetOutputAttributeType(),
							ModificationType = ModificationType.Addition,
							Value = totalOutputCollected,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, "uniquepowerthirstpositive", new int?(1), null, new int?(2), false, true, false), false).GetEnumerator();
					try
					{
						while (enumerator5.MoveNext())
						{
							object _2 = enumerator5.Current;
							yield return _2;
						}
					}
					finally
					{
						IDisposable disposable2;
						if ((disposable2 = (enumerator5 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x02000F9C RID: 3996
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600653D RID: 25917 RVA: 0x0019F70D File Offset: 0x0019DB0D
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x0600653E RID: 25918 RVA: 0x0019F718 File Offset: 0x0019DB18
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.DamageReleased || triggerUnit != effectCarrier || !(specialEffectData is PowerThirstData) || !(evtData is ReleaseableDamage))
				{
					goto IL_48E;
				}
				damage = (evtData as ReleaseableDamage);
				data = (specialEffectData as PowerThirstData);
				targets = new List<IBattleUnit>();
				enumerator = damage.BattleDamages.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						BattleDamage damageBattleDamage = enumerator.Current;
						if (targets.All((IBattleUnit t) => t.GetId() != damageBattleDamage.Target.GetId()))
						{
							targets.Add(damageBattleDamage.Target);
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				totalOutputCollected = 0.0;
				enumerator2 = targets.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_329;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_16:
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
				while (enumerator2.MoveNext())
				{
					battleUnit = enumerator2.Current;
					outputCollection = data.SuctionRate * battleUnit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value;
					if (outputCollection > 0.0)
					{
						totalOutputCollected += outputCollection;
						enumerator3 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = battleUnit.GetOutputAttributeType(),
								ModificationType = ModificationType.Addition,
								Value = -outputCollection,
								Key = string.Empty,
								AttributeModifierType = AttributeModifierType.Skill
							}
						}, "powerthirstnegativeunique", new int?(5), null, new int?(2), true, true), false).GetEnumerator();
						num = 4294967293u;
						goto Block_16;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
			if (totalOutputCollected <= 0.0)
			{
				goto IL_48E;
			}
			friendlyUnits = effectCarrier.GetAllLiveFriendlyTargetsIncSelf(true);
			enumerator4 = friendlyUnits.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_329:
				switch (num)
				{
				case 2u:
					Block_27:
					try
					{
						switch (num)
						{
						}
						if (enumerator5.MoveNext())
						{
							_2 = enumerator5.Current;
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
							if ((disposable2 = (enumerator5 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
					}
					break;
				}
				if (enumerator4.MoveNext())
				{
					unit = enumerator4.Current;
					enumerator5 = unit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = unit.GetOutputAttributeType(),
							ModificationType = ModificationType.Addition,
							Value = totalOutputCollected,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, "uniquepowerthirstpositive", new int?(1), null, new int?(2), false, true, false), false).GetEnumerator();
					num = 4294967293u;
					goto Block_27;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator4).Dispose();
				}
			}
			IL_48E:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001537 RID: 5431
		// (get) Token: 0x0600653F RID: 25919 RVA: 0x0019FC3C File Offset: 0x0019E03C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001538 RID: 5432
		// (get) Token: 0x06006540 RID: 25920 RVA: 0x0019FC44 File Offset: 0x0019E044
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006541 RID: 25921 RVA: 0x0019FC4C File Offset: 0x0019E04C
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
					((IDisposable)enumerator2).Dispose();
				}
				break;
			case 2u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable2 = (enumerator5 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator4).Dispose();
				}
				break;
			}
		}

		// Token: 0x06006542 RID: 25922 RVA: 0x0019FD40 File Offset: 0x0019E140
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006543 RID: 25923 RVA: 0x0019FD47 File Offset: 0x0019E147
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006544 RID: 25924 RVA: 0x0019FD50 File Offset: 0x0019E150
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			PowerThirstEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new PowerThirstEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x04005DAC RID: 23980
		internal AdventureEventType evtType;

		// Token: 0x04005DAD RID: 23981
		internal IBattleUnit triggerUnit;

		// Token: 0x04005DAE RID: 23982
		internal IBattleUnit effectCarrier;

		// Token: 0x04005DAF RID: 23983
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005DB0 RID: 23984
		internal object evtData;

		// Token: 0x04005DB1 RID: 23985
		internal ReleaseableDamage <damage>__1;

		// Token: 0x04005DB2 RID: 23986
		internal PowerThirstData <data>__1;

		// Token: 0x04005DB3 RID: 23987
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x04005DB4 RID: 23988
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04005DB5 RID: 23989
		internal double <totalOutputCollected>__1;

		// Token: 0x04005DB6 RID: 23990
		internal List<IBattleUnit>.Enumerator $locvar1;

		// Token: 0x04005DB7 RID: 23991
		internal IBattleUnit <battleUnit>__2;

		// Token: 0x04005DB8 RID: 23992
		internal double <outputCollection>__3;

		// Token: 0x04005DB9 RID: 23993
		internal IEnumerator $locvar2;

		// Token: 0x04005DBA RID: 23994
		internal object <_>__4;

		// Token: 0x04005DBB RID: 23995
		internal IDisposable $locvar3;

		// Token: 0x04005DBC RID: 23996
		internal List<IBattleUnit> <friendlyUnits>__5;

		// Token: 0x04005DBD RID: 23997
		internal List<IBattleUnit>.Enumerator $locvar4;

		// Token: 0x04005DBE RID: 23998
		internal IBattleUnit <unit>__6;

		// Token: 0x04005DBF RID: 23999
		internal IEnumerator $locvar5;

		// Token: 0x04005DC0 RID: 24000
		internal object <_>__7;

		// Token: 0x04005DC1 RID: 24001
		internal IDisposable $locvar6;

		// Token: 0x04005DC2 RID: 24002
		internal object $current;

		// Token: 0x04005DC3 RID: 24003
		internal bool $disposing;

		// Token: 0x04005DC4 RID: 24004
		internal int $PC;

		// Token: 0x02000F9D RID: 3997
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x06006545 RID: 25925 RVA: 0x0019FDB4 File Offset: 0x0019E1B4
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x06006546 RID: 25926 RVA: 0x0019FDBC File Offset: 0x0019E1BC
			internal bool <>m__0(IBattleUnit t)
			{
				return t.GetId() != this.damageBattleDamage.Target.GetId();
			}

			// Token: 0x04005DC5 RID: 24005
			internal BattleDamage damageBattleDamage;
		}
	}
}
