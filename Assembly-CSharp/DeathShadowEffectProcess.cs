using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008C8 RID: 2248
public class DeathShadowEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003F3F RID: 16191 RVA: 0x0018C6D8 File Offset: 0x0018AAD8
	public DeathShadowEffectProcess()
	{
	}

	// Token: 0x17000B52 RID: 2898
	// (get) Token: 0x06003F40 RID: 16192 RVA: 0x0018C6E8 File Offset: 0x0018AAE8
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return this._correspondingEffectType;
		}
	}

	// Token: 0x17000B53 RID: 2899
	// (get) Token: 0x06003F41 RID: 16193 RVA: 0x0018C6F0 File Offset: 0x0018AAF0
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitPreKilled
			};
		}
	}

	// Token: 0x06003F42 RID: 16194 RVA: 0x0018C70C File Offset: 0x0018AB0C
	public override IEnumerable AsActiveUnitPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit effectCarrier)
	{
		if (!effectCarrier.BattleEffects.OfType<InversedKillEffect>().Any<InversedKillEffect>())
		{
			DeathShadowData data = specialEffectData as DeathShadowData;
			if (data != null)
			{
				data.CoolingDownCounter++;
				if (data.HaveRevived && data.CoolingDownCounter >= data.CoolingDownSecondsAfterRebirth)
				{
					IEnumerator enumerator = effectCarrier.ApplySkillEffect(new InversedKillEffect(effectCarrier, data.DamageRate, data.DamageType, data.ChannelingSeconds), false).GetEnumerator();
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
					data.CoolingDownCounter -= data.CoolingDownSecondsAfterRebirth;
				}
				if (!data.HaveRevived && data.CoolingDownCounter >= data.CoolingDownSeconds)
				{
					IEnumerator enumerator2 = effectCarrier.ApplySkillEffect(new InversedKillEffect(effectCarrier, data.DamageRate, data.DamageType, data.ChannelingSeconds), false).GetEnumerator();
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
					data.CoolingDownCounter -= data.CoolingDownSeconds;
				}
			}
		}
		yield break;
	}

	// Token: 0x06003F43 RID: 16195 RVA: 0x0018C738 File Offset: 0x0018AB38
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitPreKilled && triggerUnit == effectCarrier && effectCarrier.HealthPoints <= 0.0)
		{
			DeathShadowData data = specialEffectData as DeathShadowData;
			if (data != null && !data.HaveRevived)
			{
				ReleaseableHeal heal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(effectCarrier, effectCarrier, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill) * data.ReviveRate,
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
						}
					}, true)
				}, effectCarrier);
				data.HaveRevived = true;
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

	// Token: 0x04002F78 RID: 12152
	private readonly SpecialEffectType _correspondingEffectType = SpecialEffectType.DeathShadowEffect;

	// Token: 0x02000F42 RID: 3906
	[CompilerGenerated]
	private sealed class <AsActiveUnitPerSecondProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060062B7 RID: 25271 RVA: 0x0018C771 File Offset: 0x0018AB71
		[DebuggerHidden]
		public <AsActiveUnitPerSecondProcess>c__Iterator0()
		{
		}

		// Token: 0x060062B8 RID: 25272 RVA: 0x0018C77C File Offset: 0x0018AB7C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (effectCarrier.BattleEffects.OfType<InversedKillEffect>().Any<InversedKillEffect>())
				{
					goto IL_290;
				}
				data = (specialEffectData as DeathShadowData);
				if (data == null)
				{
					goto IL_290;
				}
				data.CoolingDownCounter++;
				if (!data.HaveRevived || data.CoolingDownCounter < data.CoolingDownSecondsAfterRebirth)
				{
					goto IL_180;
				}
				enumerator = effectCarrier.ApplySkillEffect(new InversedKillEffect(effectCarrier, data.DamageRate, data.DamageType, data.ChannelingSeconds), false).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				Block_9:
				try
				{
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
				data.CoolingDownCounter -= data.CoolingDownSeconds;
				goto IL_290;
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
			data.CoolingDownCounter -= data.CoolingDownSecondsAfterRebirth;
			IL_180:
			if (!data.HaveRevived && data.CoolingDownCounter >= data.CoolingDownSeconds)
			{
				enumerator2 = effectCarrier.ApplySkillEffect(new InversedKillEffect(effectCarrier, data.DamageRate, data.DamageType, data.ChannelingSeconds), false).GetEnumerator();
				num = 4294967293u;
				goto Block_9;
			}
			IL_290:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014A9 RID: 5289
		// (get) Token: 0x060062B9 RID: 25273 RVA: 0x0018CA40 File Offset: 0x0018AE40
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014AA RID: 5290
		// (get) Token: 0x060062BA RID: 25274 RVA: 0x0018CA48 File Offset: 0x0018AE48
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060062BB RID: 25275 RVA: 0x0018CA50 File Offset: 0x0018AE50
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
			}
		}

		// Token: 0x060062BC RID: 25276 RVA: 0x0018CB00 File Offset: 0x0018AF00
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060062BD RID: 25277 RVA: 0x0018CB07 File Offset: 0x0018AF07
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060062BE RID: 25278 RVA: 0x0018CB10 File Offset: 0x0018AF10
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DeathShadowEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0 <AsActiveUnitPerSecondProcess>c__Iterator = new DeathShadowEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator0();
			<AsActiveUnitPerSecondProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitPerSecondProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitPerSecondProcess>c__Iterator;
		}

		// Token: 0x04005950 RID: 22864
		internal IBattleUnit effectCarrier;

		// Token: 0x04005951 RID: 22865
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005952 RID: 22866
		internal DeathShadowData <data>__1;

		// Token: 0x04005953 RID: 22867
		internal IEnumerator $locvar0;

		// Token: 0x04005954 RID: 22868
		internal object <_>__2;

		// Token: 0x04005955 RID: 22869
		internal IDisposable $locvar1;

		// Token: 0x04005956 RID: 22870
		internal IEnumerator $locvar2;

		// Token: 0x04005957 RID: 22871
		internal object <_>__3;

		// Token: 0x04005958 RID: 22872
		internal IDisposable $locvar3;

		// Token: 0x04005959 RID: 22873
		internal object $current;

		// Token: 0x0400595A RID: 22874
		internal bool $disposing;

		// Token: 0x0400595B RID: 22875
		internal int $PC;
	}

	// Token: 0x02000F43 RID: 3907
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060062BF RID: 25279 RVA: 0x0018CB50 File Offset: 0x0018AF50
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator1()
		{
		}

		// Token: 0x060062C0 RID: 25280 RVA: 0x0018CB58 File Offset: 0x0018AF58
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType != AdventureEventType.UnitPreKilled || triggerUnit != effectCarrier || effectCarrier.HealthPoints > 0.0)
				{
					goto IL_1A5;
				}
				data = (specialEffectData as DeathShadowData);
				if (data == null || data.HaveRevived)
				{
					goto IL_1A5;
				}
				heal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(effectCarrier, effectCarrier, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = effectCarrier.GetMaxLife(AttributeRetrievalLevel.Skill) * data.ReviveRate,
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
						}
					}, true)
				}, effectCarrier);
				data.HaveRevived = true;
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
			IL_1A5:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170014AB RID: 5291
		// (get) Token: 0x060062C1 RID: 25281 RVA: 0x0018CD24 File Offset: 0x0018B124
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170014AC RID: 5292
		// (get) Token: 0x060062C2 RID: 25282 RVA: 0x0018CD2C File Offset: 0x0018B12C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060062C3 RID: 25283 RVA: 0x0018CD34 File Offset: 0x0018B134
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

		// Token: 0x060062C4 RID: 25284 RVA: 0x0018CDA4 File Offset: 0x0018B1A4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060062C5 RID: 25285 RVA: 0x0018CDAB File Offset: 0x0018B1AB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060062C6 RID: 25286 RVA: 0x0018CDB4 File Offset: 0x0018B1B4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DeathShadowEffectProcess.<AsActiveUnitProcess>c__Iterator1 <AsActiveUnitProcess>c__Iterator = new DeathShadowEffectProcess.<AsActiveUnitProcess>c__Iterator1();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x0400595C RID: 22876
		internal AdventureEventType evtType;

		// Token: 0x0400595D RID: 22877
		internal IBattleUnit triggerUnit;

		// Token: 0x0400595E RID: 22878
		internal IBattleUnit effectCarrier;

		// Token: 0x0400595F RID: 22879
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005960 RID: 22880
		internal DeathShadowData <data>__1;

		// Token: 0x04005961 RID: 22881
		internal ReleaseableHeal <heal>__2;

		// Token: 0x04005962 RID: 22882
		internal IEnumerator $locvar0;

		// Token: 0x04005963 RID: 22883
		internal object <_>__3;

		// Token: 0x04005964 RID: 22884
		internal IDisposable $locvar1;

		// Token: 0x04005965 RID: 22885
		internal object $current;

		// Token: 0x04005966 RID: 22886
		internal bool $disposing;

		// Token: 0x04005967 RID: 22887
		internal int $PC;
	}
}
