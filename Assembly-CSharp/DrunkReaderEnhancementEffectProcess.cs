using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008D4 RID: 2260
public class DrunkReaderEnhancementEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F73 RID: 16243 RVA: 0x001911D0 File Offset: 0x0018F5D0
	public DrunkReaderEnhancementEffectProcess()
	{
	}

	// Token: 0x17000B6A RID: 2922
	// (get) Token: 0x06003F74 RID: 16244 RVA: 0x001911D8 File Offset: 0x0018F5D8
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.DrunkReaderEnhancement;
		}
	}

	// Token: 0x17000B6B RID: 2923
	// (get) Token: 0x06003F75 RID: 16245 RVA: 0x001911E0 File Offset: 0x0018F5E0
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

	// Token: 0x06003F76 RID: 16246 RVA: 0x001911FC File Offset: 0x0018F5FC
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.DamageReleased && triggerUnit == effectCarrier && evtData is ReleaseableDamage && specialEffectData is DrunkReaderEnhancementData && effectCarrier.GetUnitType() == UnitClass.DrunkReader)
		{
			ReleaseableDamage damage = evtData as ReleaseableDamage;
			if (damage.BattleDamages.Any((BattleDamage d) => d.Damages.Any((DamageComponent dd) => dd.IsFatal != null && dd.IsFatal.Value)))
			{
				DrunkReaderEnhancementData data = specialEffectData as DrunkReaderEnhancementData;
				IEnumerator enumerator = effectCarrier.ApplySkillEffect(new UndeadEffect(null, null, effectCarrier, data.HealRate), false).GetEnumerator();
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

	// Token: 0x02000F53 RID: 3923
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006333 RID: 25395 RVA: 0x0019123D File Offset: 0x0018F63D
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006334 RID: 25396 RVA: 0x00191248 File Offset: 0x0018F648
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.DamageReleased || triggerUnit != effectCarrier || !(evtData is ReleaseableDamage) || !(specialEffectData is DrunkReaderEnhancementData) || effectCarrier.GetUnitType() != UnitClass.DrunkReader)
				{
					goto IL_18E;
				}
				damage = (evtData as ReleaseableDamage);
				if (!damage.BattleDamages.Any((BattleDamage d) => d.Damages.Any((DamageComponent dd) => dd.IsFatal != null && dd.IsFatal.Value)))
				{
					goto IL_18E;
				}
				data = (specialEffectData as DrunkReaderEnhancementData);
				enumerator = effectCarrier.ApplySkillEffect(new UndeadEffect(null, null, effectCarrier, data.HealRate), false).GetEnumerator();
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
			IL_18E:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014C5 RID: 5317
		// (get) Token: 0x06006335 RID: 25397 RVA: 0x00191400 File Offset: 0x0018F800
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014C6 RID: 5318
		// (get) Token: 0x06006336 RID: 25398 RVA: 0x00191408 File Offset: 0x0018F808
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006337 RID: 25399 RVA: 0x00191410 File Offset: 0x0018F810
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

		// Token: 0x06006338 RID: 25400 RVA: 0x00191480 File Offset: 0x0018F880
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006339 RID: 25401 RVA: 0x00191487 File Offset: 0x0018F887
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600633A RID: 25402 RVA: 0x00191490 File Offset: 0x0018F890
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DrunkReaderEnhancementEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new DrunkReaderEnhancementEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x0600633B RID: 25403 RVA: 0x001914F4 File Offset: 0x0018F8F4
		private static bool <>m__0(BattleDamage d)
		{
			return d.Damages.Any((DamageComponent dd) => dd.IsFatal != null && dd.IsFatal.Value);
		}

		// Token: 0x0600633C RID: 25404 RVA: 0x00191520 File Offset: 0x0018F920
		private static bool <>m__1(DamageComponent dd)
		{
			return dd.IsFatal != null && dd.IsFatal.Value;
		}

		// Token: 0x04005A54 RID: 23124
		internal AdventureEventType evtType;

		// Token: 0x04005A55 RID: 23125
		internal IBattleUnit triggerUnit;

		// Token: 0x04005A56 RID: 23126
		internal IBattleUnit effectCarrier;

		// Token: 0x04005A57 RID: 23127
		internal object evtData;

		// Token: 0x04005A58 RID: 23128
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005A59 RID: 23129
		internal ReleaseableDamage <damage>__1;

		// Token: 0x04005A5A RID: 23130
		internal DrunkReaderEnhancementData <data>__2;

		// Token: 0x04005A5B RID: 23131
		internal IEnumerator $locvar0;

		// Token: 0x04005A5C RID: 23132
		internal object <_>__3;

		// Token: 0x04005A5D RID: 23133
		internal IDisposable $locvar1;

		// Token: 0x04005A5E RID: 23134
		internal object $current;

		// Token: 0x04005A5F RID: 23135
		internal bool $disposing;

		// Token: 0x04005A60 RID: 23136
		internal int $PC;

		// Token: 0x04005A61 RID: 23137
		private static Func<BattleDamage, bool> <>f__am$cache0;

		// Token: 0x04005A62 RID: 23138
		private static Func<DamageComponent, bool> <>f__am$cache1;
	}
}
