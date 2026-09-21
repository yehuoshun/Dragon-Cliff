using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008AA RID: 2218
public class AgilityuIdleBoostEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003EB6 RID: 16054 RVA: 0x001830B4 File Offset: 0x001814B4
	public AgilityuIdleBoostEffectProcess()
	{
	}

	// Token: 0x17000B16 RID: 2838
	// (get) Token: 0x06003EB7 RID: 16055 RVA: 0x001830BC File Offset: 0x001814BC
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.AgilityIdleBoost;
		}
	}

	// Token: 0x17000B17 RID: 2839
	// (get) Token: 0x06003EB8 RID: 16056 RVA: 0x001830C0 File Offset: 0x001814C0
	public override List<AdventureEventType> CorrespondingEvents
	{
		get
		{
			return new List<AdventureEventType>
			{
				AdventureEventType.UnitReadyInBattle,
				AdventureEventType.UnitPostReceivesDamage_Single
			};
		}
	}

	// Token: 0x06003EB9 RID: 16057 RVA: 0x001830E4 File Offset: 0x001814E4
	public override IEnumerable AsActiveUnitProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit triggerUnit, IBattleUnit effectCarrier, AdventureEventType evtType, object evtData)
	{
		if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && specialEffectData is AgilityIdleBoostData)
		{
			AgilityIdleBoostData agilityIdleBoostData = specialEffectData as AgilityIdleBoostData;
			agilityIdleBoostData.Counter = 0;
		}
		if (evtType == AdventureEventType.UnitPostReceivesDamage_Single && triggerUnit == effectCarrier && specialEffectData is AgilityIdleBoostData)
		{
			DamageComponent damage = evtData as DamageComponent;
			if (damage.IsDirectDamage && !damage.IsMissed)
			{
				List<AttributeModificationEffect> toremove = (from ef in triggerUnit.BattleEffects.OfType<AttributeModificationEffect>()
				where ef.EffectSourceIdentityCode == AgilityuIdleBoostEffectProcess._key
				select ef).ToList<AttributeModificationEffect>();
				foreach (AttributeModificationEffect attributeModificationEffect in toremove)
				{
					IEnumerator enumerator2 = triggerUnit.LooseSkillEffect(attributeModificationEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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
				AgilityIdleBoostData data = specialEffectData as AgilityIdleBoostData;
				data.Counter = 0;
			}
		}
		yield break;
	}

	// Token: 0x06003EBA RID: 16058 RVA: 0x00183128 File Offset: 0x00181528
	public override IEnumerable AsActiveUnitPerSecondProcess(ISpecialEffectDataLoad specialEffectData, IBattleUnit effectCarrier)
	{
		AgilityIdleBoostData data = specialEffectData as AgilityIdleBoostData;
		data.Counter++;
		if (data.Counter > data.CoolingDownSeconds)
		{
			IEnumerator enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.Agility,
					Value = data.BoostRate,
					Key = string.Empty,
					ModificationType = ModificationType.Multiplication,
					AttributeModifierType = AttributeModifierType.Skill
				}
			}, AgilityuIdleBoostEffectProcess._key, new int?(1), null, null, false, true, false), false).GetEnumerator();
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
			data.Counter = 0;
		}
		yield break;
	}

	// Token: 0x06003EBB RID: 16059 RVA: 0x00183152 File Offset: 0x00181552
	// Note: this type is marked as 'beforefieldinit'.
	static AgilityuIdleBoostEffectProcess()
	{
	}

	// Token: 0x04002F64 RID: 12132
	private static string _key = "agilityidlekey";

	// Token: 0x02000F10 RID: 3856
	[CompilerGenerated]
	private sealed class <AsActiveUnitProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006167 RID: 24935 RVA: 0x0018315E File Offset: 0x0018155E
		[DebuggerHidden]
		public <AsActiveUnitProcess>c__Iterator0()
		{
		}

		// Token: 0x06006168 RID: 24936 RVA: 0x00183168 File Offset: 0x00181568
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evtType == AdventureEventType.UnitReadyInBattle && triggerUnit == effectCarrier && specialEffectData is AgilityIdleBoostData)
				{
					AgilityIdleBoostData agilityIdleBoostData = specialEffectData as AgilityIdleBoostData;
					agilityIdleBoostData.Counter = 0;
				}
				if (evtType != AdventureEventType.UnitPostReceivesDamage_Single || triggerUnit != effectCarrier || !(specialEffectData is AgilityIdleBoostData))
				{
					goto IL_220;
				}
				damage = (evtData as DamageComponent);
				if (!damage.IsDirectDamage || damage.IsMissed)
				{
					goto IL_220;
				}
				toremove = (from ef in triggerUnit.BattleEffects.OfType<AttributeModificationEffect>()
				where ef.EffectSourceIdentityCode == AgilityuIdleBoostEffectProcess._key
				select ef).ToList<AttributeModificationEffect>();
				enumerator = toremove.GetEnumerator();
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
					attributeModificationEffect = enumerator.Current;
					enumerator2 = triggerUnit.LooseSkillEffect(attributeModificationEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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
			data = (specialEffectData as AgilityIdleBoostData);
			data.Counter = 0;
			IL_220:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001466 RID: 5222
		// (get) Token: 0x06006169 RID: 24937 RVA: 0x001833BC File Offset: 0x001817BC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001467 RID: 5223
		// (get) Token: 0x0600616A RID: 24938 RVA: 0x001833C4 File Offset: 0x001817C4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600616B RID: 24939 RVA: 0x001833CC File Offset: 0x001817CC
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

		// Token: 0x0600616C RID: 24940 RVA: 0x00183460 File Offset: 0x00181860
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600616D RID: 24941 RVA: 0x00183467 File Offset: 0x00181867
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600616E RID: 24942 RVA: 0x00183470 File Offset: 0x00181870
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			AgilityuIdleBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0 <AsActiveUnitProcess>c__Iterator = new AgilityuIdleBoostEffectProcess.<AsActiveUnitProcess>c__Iterator0();
			<AsActiveUnitProcess>c__Iterator.evtType = evtType;
			<AsActiveUnitProcess>c__Iterator.triggerUnit = triggerUnit;
			<AsActiveUnitProcess>c__Iterator.effectCarrier = effectCarrier;
			<AsActiveUnitProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitProcess>c__Iterator.evtData = evtData;
			return <AsActiveUnitProcess>c__Iterator;
		}

		// Token: 0x0600616F RID: 24943 RVA: 0x001834D4 File Offset: 0x001818D4
		private static bool <>m__0(AttributeModificationEffect ef)
		{
			return ef.EffectSourceIdentityCode == AgilityuIdleBoostEffectProcess._key;
		}

		// Token: 0x0400570E RID: 22286
		internal AdventureEventType evtType;

		// Token: 0x0400570F RID: 22287
		internal IBattleUnit triggerUnit;

		// Token: 0x04005710 RID: 22288
		internal IBattleUnit effectCarrier;

		// Token: 0x04005711 RID: 22289
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005712 RID: 22290
		internal object evtData;

		// Token: 0x04005713 RID: 22291
		internal DamageComponent <damage>__1;

		// Token: 0x04005714 RID: 22292
		internal List<AttributeModificationEffect> <toremove>__2;

		// Token: 0x04005715 RID: 22293
		internal List<AttributeModificationEffect>.Enumerator $locvar0;

		// Token: 0x04005716 RID: 22294
		internal AttributeModificationEffect <attributeModificationEffect>__3;

		// Token: 0x04005717 RID: 22295
		internal IEnumerator $locvar1;

		// Token: 0x04005718 RID: 22296
		internal object <_>__4;

		// Token: 0x04005719 RID: 22297
		internal IDisposable $locvar2;

		// Token: 0x0400571A RID: 22298
		internal AgilityIdleBoostData <data>__2;

		// Token: 0x0400571B RID: 22299
		internal object $current;

		// Token: 0x0400571C RID: 22300
		internal bool $disposing;

		// Token: 0x0400571D RID: 22301
		internal int $PC;

		// Token: 0x0400571E RID: 22302
		private static Func<AttributeModificationEffect, bool> <>f__am$cache0;
	}

	// Token: 0x02000F11 RID: 3857
	[CompilerGenerated]
	private sealed class <AsActiveUnitPerSecondProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006170 RID: 24944 RVA: 0x001834E6 File Offset: 0x001818E6
		[DebuggerHidden]
		public <AsActiveUnitPerSecondProcess>c__Iterator1()
		{
		}

		// Token: 0x06006171 RID: 24945 RVA: 0x001834F0 File Offset: 0x001818F0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				data = (specialEffectData as AgilityIdleBoostData);
				data.Counter++;
				if (data.Counter <= data.CoolingDownSeconds)
				{
					goto IL_17E;
				}
				enumerator = effectCarrier.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(effectCarrier, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.Agility,
						Value = data.BoostRate,
						Key = string.Empty,
						ModificationType = ModificationType.Multiplication,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, AgilityuIdleBoostEffectProcess._key, new int?(1), null, null, false, true, false), false).GetEnumerator();
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
			data.Counter = 0;
			IL_17E:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001468 RID: 5224
		// (get) Token: 0x06006172 RID: 24946 RVA: 0x00183698 File Offset: 0x00181A98
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001469 RID: 5225
		// (get) Token: 0x06006173 RID: 24947 RVA: 0x001836A0 File Offset: 0x00181AA0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006174 RID: 24948 RVA: 0x001836A8 File Offset: 0x00181AA8
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

		// Token: 0x06006175 RID: 24949 RVA: 0x00183718 File Offset: 0x00181B18
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006176 RID: 24950 RVA: 0x0018371F File Offset: 0x00181B1F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006177 RID: 24951 RVA: 0x00183728 File Offset: 0x00181B28
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			AgilityuIdleBoostEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator1 <AsActiveUnitPerSecondProcess>c__Iterator = new AgilityuIdleBoostEffectProcess.<AsActiveUnitPerSecondProcess>c__Iterator1();
			<AsActiveUnitPerSecondProcess>c__Iterator.specialEffectData = specialEffectData;
			<AsActiveUnitPerSecondProcess>c__Iterator.effectCarrier = effectCarrier;
			return <AsActiveUnitPerSecondProcess>c__Iterator;
		}

		// Token: 0x0400571F RID: 22303
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005720 RID: 22304
		internal AgilityIdleBoostData <data>__0;

		// Token: 0x04005721 RID: 22305
		internal IBattleUnit effectCarrier;

		// Token: 0x04005722 RID: 22306
		internal IEnumerator $locvar0;

		// Token: 0x04005723 RID: 22307
		internal object <_>__1;

		// Token: 0x04005724 RID: 22308
		internal IDisposable $locvar1;

		// Token: 0x04005725 RID: 22309
		internal object $current;

		// Token: 0x04005726 RID: 22310
		internal bool $disposing;

		// Token: 0x04005727 RID: 22311
		internal int $PC;
	}
}
