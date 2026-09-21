using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008AC RID: 2220
[Serializable]
public class AttributeBoostEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003EC0 RID: 16064 RVA: 0x00183D1F File Offset: 0x0018211F
	public AttributeBoostEffectProcess()
	{
	}

	// Token: 0x17000B1A RID: 2842
	// (get) Token: 0x06003EC1 RID: 16065 RVA: 0x00183D27 File Offset: 0x00182127
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.AttributeBoostOnStart;
		}
	}

	// Token: 0x17000B1B RID: 2843
	// (get) Token: 0x06003EC2 RID: 16066 RVA: 0x00183D2C File Offset: 0x0018212C
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

	// Token: 0x06003EC3 RID: 16067 RVA: 0x00183D48 File Offset: 0x00182148
	public override IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.UnitReadyInBattle && evt.EventTriggeringUnit.IsPlayer && evt.EventTriggeringUnit.IsAliveInBattle() && specialEffectData is AttributeBoostData)
		{
			AttributeBoostData data = specialEffectData as AttributeBoostData;
			List<AttributeModifier> modifiers = new List<AttributeModifier>();
			modifiers.AddRange(from a in data.AdditionBoosts
			select new AttributeModifier
			{
				AttributeType = a.BoostAttribute,
				ModificationType = ModificationType.Addition,
				Value = a.BoostValue,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			});
			modifiers.AddRange(from a in data.MultiplicationBoosts
			select new AttributeModifier
			{
				AttributeType = a.BoostAttribute,
				ModificationType = ModificationType.Multiplication,
				Value = a.BoostValue,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			});
			IEnumerator enumerator = evt.EventTriggeringUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(evt.EventTriggeringUnit, modifiers, "startbattlepotion", new int?(8), null, null, false, false, false), false).GetEnumerator();
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

	// Token: 0x02000F14 RID: 3860
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006186 RID: 24966 RVA: 0x00183D72 File Offset: 0x00182172
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator0()
		{
		}

		// Token: 0x06006187 RID: 24967 RVA: 0x00183D7C File Offset: 0x0018217C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evt.EventType != AdventureEventType.UnitReadyInBattle || !evt.EventTriggeringUnit.IsPlayer || !evt.EventTriggeringUnit.IsAliveInBattle() || !(specialEffectData is AttributeBoostData))
				{
					goto IL_1D4;
				}
				data = (specialEffectData as AttributeBoostData);
				modifiers = new List<AttributeModifier>();
				modifiers.AddRange(from a in data.AdditionBoosts
				select new AttributeModifier
				{
					AttributeType = a.BoostAttribute,
					ModificationType = ModificationType.Addition,
					Value = a.BoostValue,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				});
				modifiers.AddRange(from a in data.MultiplicationBoosts
				select new AttributeModifier
				{
					AttributeType = a.BoostAttribute,
					ModificationType = ModificationType.Multiplication,
					Value = a.BoostValue,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				});
				enumerator = evt.EventTriggeringUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(evt.EventTriggeringUnit, modifiers, "startbattlepotion", new int?(8), null, null, false, false, false), false).GetEnumerator();
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
			IL_1D4:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700146D RID: 5229
		// (get) Token: 0x06006188 RID: 24968 RVA: 0x00183F78 File Offset: 0x00182378
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700146E RID: 5230
		// (get) Token: 0x06006189 RID: 24969 RVA: 0x00183F80 File Offset: 0x00182380
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600618A RID: 24970 RVA: 0x00183F88 File Offset: 0x00182388
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

		// Token: 0x0600618B RID: 24971 RVA: 0x00183FF8 File Offset: 0x001823F8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600618C RID: 24972 RVA: 0x00183FFF File Offset: 0x001823FF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600618D RID: 24973 RVA: 0x00184008 File Offset: 0x00182408
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			AttributeBoostEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <AsAdventureEffectProcess>c__Iterator = new AttributeBoostEffectProcess.<AsAdventureEffectProcess>c__Iterator0();
			<AsAdventureEffectProcess>c__Iterator.evt = evt;
			<AsAdventureEffectProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsAdventureEffectProcess>c__Iterator;
		}

		// Token: 0x0600618E RID: 24974 RVA: 0x00184048 File Offset: 0x00182448
		private static AttributeModifier <>m__0(BoostSetting a)
		{
			return new AttributeModifier
			{
				AttributeType = a.BoostAttribute,
				ModificationType = ModificationType.Addition,
				Value = a.BoostValue,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			};
		}

		// Token: 0x0600618F RID: 24975 RVA: 0x00184090 File Offset: 0x00182490
		private static AttributeModifier <>m__1(BoostSetting a)
		{
			return new AttributeModifier
			{
				AttributeType = a.BoostAttribute,
				ModificationType = ModificationType.Multiplication,
				Value = a.BoostValue,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			};
		}

		// Token: 0x0400573B RID: 22331
		internal BroadcastEvent evt;

		// Token: 0x0400573C RID: 22332
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x0400573D RID: 22333
		internal AttributeBoostData <data>__1;

		// Token: 0x0400573E RID: 22334
		internal List<AttributeModifier> <modifiers>__1;

		// Token: 0x0400573F RID: 22335
		internal IEnumerator $locvar0;

		// Token: 0x04005740 RID: 22336
		internal object <_>__2;

		// Token: 0x04005741 RID: 22337
		internal IDisposable $locvar1;

		// Token: 0x04005742 RID: 22338
		internal object $current;

		// Token: 0x04005743 RID: 22339
		internal bool $disposing;

		// Token: 0x04005744 RID: 22340
		internal int $PC;

		// Token: 0x04005745 RID: 22341
		private static Func<BoostSetting, AttributeModifier> <>f__am$cache0;

		// Token: 0x04005746 RID: 22342
		private static Func<BoostSetting, AttributeModifier> <>f__am$cache1;
	}
}
