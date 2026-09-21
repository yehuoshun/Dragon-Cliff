using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008E6 RID: 2278
public class FashionEnhancementEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003FC1 RID: 16321 RVA: 0x00194979 File Offset: 0x00192D79
	public FashionEnhancementEffectProcess()
	{
	}

	// Token: 0x17000B8E RID: 2958
	// (get) Token: 0x06003FC2 RID: 16322 RVA: 0x00194981 File Offset: 0x00192D81
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.FashionEnhancement;
		}
	}

	// Token: 0x17000B8F RID: 2959
	// (get) Token: 0x06003FC3 RID: 16323 RVA: 0x00194988 File Offset: 0x00192D88
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitSelectsSkill,
				AdventureEventType.UnitCompletesAction
			};
		}
	}

	// Token: 0x06003FC4 RID: 16324 RVA: 0x001949AC File Offset: 0x00192DAC
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		string code = "fashionenhancementimmune";
		if (evtType == AdventureEventType.UnitSelectsSkill && triggerUnit == effectCarrier && triggerUnit.GetUnitType() == UnitClass.FashionBoy)
		{
			IEnumerator enumerator = effectCarrier.ApplySkillEffect(new DamageImmuneEffect(code, null, null, effectCarrier, new List<OutputType>
			{
				OutputType.Ice,
				OutputType.Physical,
				OutputType.Poison,
				OutputType.Lightening,
				OutputType.Shadow,
				OutputType.Divine,
				OutputType.Fire,
				OutputType.RealDamage
			}, false, 1), false).GetEnumerator();
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
			IEnumerator enumerator2 = effectCarrier.ApplySkillEffect(new EffectImmuneEffect(effectCarrier, null, null, code, 1.0), false).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object _2 = enumerator2.Current;
					yield return _2;
				}
			}
			finally
			{
				IDisposable disposable2;
				if ((disposable2 = (enumerator2 as IDisposable)) != null)
				{
					disposable2.Dispose();
				}
			}
		}
		if (evtType == AdventureEventType.UnitCompletesAction && triggerUnit == effectCarrier && specialEffectData is FashionEnhancementData && triggerUnit.GetUnitType() == UnitClass.FashionBoy)
		{
			List<BattleEffectBase> toremove = (from ef in effectCarrier.BattleEffects
			where ef.EffectSourceIdentityCode == code
			select ef).ToList<BattleEffectBase>();
			foreach (BattleEffectBase battleEffectBase in toremove)
			{
				IEnumerator enumerator4 = effectCarrier.LooseSkillEffect(battleEffectBase, EffectWearsOffType.Expiration).GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						object _3 = enumerator4.Current;
						yield return _3;
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator4 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			int existing = effectCarrier.BattleEffects.OfType<FashionEnhancedEffect>().Sum((FashionEnhancedEffect e) => e.Extra);
			FashionEnhancementData data = specialEffectData as FashionEnhancementData;
			IEnumerator enumerator5 = effectCarrier.ApplySkillEffect(new FashionEnhancedEffect(data.Extra + existing, effectCarrier), false).GetEnumerator();
			try
			{
				while (enumerator5.MoveNext())
				{
					object _4 = enumerator5.Current;
					yield return _4;
				}
			}
			finally
			{
				IDisposable disposable4;
				if ((disposable4 = (enumerator5 as IDisposable)) != null)
				{
					disposable4.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x02000F65 RID: 3941
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060063B8 RID: 25528 RVA: 0x001949E5 File Offset: 0x00192DE5
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x060063B9 RID: 25529 RVA: 0x001949F0 File Offset: 0x00192DF0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				string code = "fashionenhancementimmune";
				if (evtType != AdventureEventType.UnitSelectsSkill || triggerUnit != effectCarrier || triggerUnit.GetUnitType() != UnitClass.FashionBoy)
				{
					goto IL_268;
				}
				enumerator = effectCarrier.ApplySkillEffect(new DamageImmuneEffect(code, null, null, effectCarrier, new List<OutputType>
				{
					OutputType.Ice,
					OutputType.Physical,
					OutputType.Poison,
					OutputType.Lightening,
					OutputType.Shadow,
					OutputType.Divine,
					OutputType.Fire,
					OutputType.RealDamage
				}, false, 1), false).GetEnumerator();
				num = 4294967293u;
				break;
			}
			case 1u:
				break;
			case 2u:
				goto IL_1E4;
			case 3u:
				Block_11:
				try
				{
					switch (num)
					{
					case 3u:
						Block_27:
						try
						{
							switch (num)
							{
							}
							if (enumerator4.MoveNext())
							{
								_3 = enumerator4.Current;
								this.$current = _3;
								if (!this.$disposing)
								{
									this.$PC = 3;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable3 = (enumerator4 as IDisposable)) != null)
								{
									disposable3.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator3.MoveNext())
					{
						battleEffectBase = enumerator3.Current;
						enumerator4 = effectCarrier.LooseSkillEffect(battleEffectBase, EffectWearsOffType.Expiration).GetEnumerator();
						num = 4294967293u;
						goto Block_27;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator3).Dispose();
					}
				}
				existing = effectCarrier.BattleEffects.OfType<FashionEnhancedEffect>().Sum((FashionEnhancedEffect e) => e.Extra);
				data = (specialEffectData as FashionEnhancementData);
				enumerator5 = effectCarrier.ApplySkillEffect(new FashionEnhancedEffect(data.Extra + existing, effectCarrier), false).GetEnumerator();
				num = 4294967293u;
				goto Block_13;
			case 4u:
				goto IL_45C;
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
			enumerator2 = effectCarrier.ApplySkillEffect(new EffectImmuneEffect(effectCarrier, null, null, <AsActiveUnitProcess>c__AnonStorey.code, 1.0), false).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_1E4:
				switch (num)
				{
				}
				if (enumerator2.MoveNext())
				{
					_2 = enumerator2.Current;
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
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			IL_268:
			if (evtType == AdventureEventType.UnitCompletesAction && triggerUnit == effectCarrier && specialEffectData is FashionEnhancementData && triggerUnit.GetUnitType() == UnitClass.FashionBoy)
			{
				toremove = (from ef in effectCarrier.BattleEffects
				where ef.EffectSourceIdentityCode == <AsActiveUnitProcess>c__AnonStorey.code
				select ef).ToList<BattleEffectBase>();
				enumerator3 = toremove.GetEnumerator();
				num = 4294967293u;
				goto Block_11;
			}
			goto IL_4E0;
			Block_13:
			try
			{
				IL_45C:
				switch (num)
				{
				}
				if (enumerator5.MoveNext())
				{
					_4 = enumerator5.Current;
					this.$current = _4;
					if (!this.$disposing)
					{
						this.$PC = 4;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable4 = (enumerator5 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			IL_4E0:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014E1 RID: 5345
		// (get) Token: 0x060063BA RID: 25530 RVA: 0x00194F28 File Offset: 0x00193328
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014E2 RID: 5346
		// (get) Token: 0x060063BB RID: 25531 RVA: 0x00194F30 File Offset: 0x00193330
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060063BC RID: 25532 RVA: 0x00194F38 File Offset: 0x00193338
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
			case 2u:
				try
				{
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			case 3u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable3 = (enumerator4 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator3).Dispose();
				}
				break;
			case 4u:
				try
				{
				}
				finally
				{
					if ((disposable4 = (enumerator5 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x060063BD RID: 25533 RVA: 0x00195088 File Offset: 0x00193488
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060063BE RID: 25534 RVA: 0x0019508F File Offset: 0x0019348F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060063BF RID: 25535 RVA: 0x00195098 File Offset: 0x00193498
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			FashionEnhancementEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new FashionEnhancementEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x060063C0 RID: 25536 RVA: 0x001950F0 File Offset: 0x001934F0
		private static int <>m__0(FashionEnhancedEffect e)
		{
			return e.Extra;
		}

		// Token: 0x04005B1F RID: 23327
		internal AdventureEventType evtType;

		// Token: 0x04005B20 RID: 23328
		internal IBattleUnit triggerUnit;

		// Token: 0x04005B21 RID: 23329
		internal IBattleUnit effectCarrier;

		// Token: 0x04005B22 RID: 23330
		internal IEnumerator $locvar0;

		// Token: 0x04005B23 RID: 23331
		internal object <_>__1;

		// Token: 0x04005B24 RID: 23332
		internal IDisposable $locvar1;

		// Token: 0x04005B25 RID: 23333
		internal IEnumerator $locvar2;

		// Token: 0x04005B26 RID: 23334
		internal object <_>__2;

		// Token: 0x04005B27 RID: 23335
		internal IDisposable $locvar3;

		// Token: 0x04005B28 RID: 23336
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005B29 RID: 23337
		internal List<BattleEffectBase> <toremove>__3;

		// Token: 0x04005B2A RID: 23338
		internal List<BattleEffectBase>.Enumerator $locvar4;

		// Token: 0x04005B2B RID: 23339
		internal BattleEffectBase <battleEffectBase>__4;

		// Token: 0x04005B2C RID: 23340
		internal IEnumerator $locvar5;

		// Token: 0x04005B2D RID: 23341
		internal object <_>__5;

		// Token: 0x04005B2E RID: 23342
		internal IDisposable $locvar6;

		// Token: 0x04005B2F RID: 23343
		internal int <existing>__3;

		// Token: 0x04005B30 RID: 23344
		internal FashionEnhancementData <data>__3;

		// Token: 0x04005B31 RID: 23345
		internal IEnumerator $locvar7;

		// Token: 0x04005B32 RID: 23346
		internal object <_>__6;

		// Token: 0x04005B33 RID: 23347
		internal IDisposable $locvar8;

		// Token: 0x04005B34 RID: 23348
		internal object $current;

		// Token: 0x04005B35 RID: 23349
		internal bool $disposing;

		// Token: 0x04005B36 RID: 23350
		internal int $PC;

		// Token: 0x04005B37 RID: 23351
		private FashionEnhancementEffectProcess.<AsActiveUnitProcess>c__Iterator0.<AsActiveUnitProcess>c__AnonStorey1 $locvar9;

		// Token: 0x04005B38 RID: 23352
		private static Func<FashionEnhancedEffect, int> <>f__am$cache0;

		// Token: 0x02000F66 RID: 3942
		private sealed class <AsActiveUnitProcess>c__AnonStorey1
		{
			// Token: 0x060063C1 RID: 25537 RVA: 0x001950F8 File Offset: 0x001934F8
			public <AsActiveUnitProcess>c__AnonStorey1()
			{
			}

			// Token: 0x060063C2 RID: 25538 RVA: 0x00195100 File Offset: 0x00193500
			internal bool <>m__0(BattleEffectBase ef)
			{
				return ef.EffectSourceIdentityCode == this.code;
			}

			// Token: 0x04005B39 RID: 23353
			internal string code;

			// Token: 0x04005B3A RID: 23354
			internal FashionEnhancementEffectProcess.<AsActiveUnitProcess>c__Iterator0 <>f__ref$0;
		}
	}
}
