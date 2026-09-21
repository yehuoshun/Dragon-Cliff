using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020008AD RID: 2221
public class AttributeDepressionEffectProcess : SpecialEffectProcessBase
{
	// Token: 0x06003EC4 RID: 16068 RVA: 0x001840D5 File Offset: 0x001824D5
	public AttributeDepressionEffectProcess()
	{
	}

	// Token: 0x17000B1C RID: 2844
	// (get) Token: 0x06003EC5 RID: 16069 RVA: 0x001840DD File Offset: 0x001824DD
	public override SpecialEffectType CorrespondingEffectType
	{
		get
		{
			return SpecialEffectType.AttributeDepression;
		}
	}

	// Token: 0x17000B1D RID: 2845
	// (get) Token: 0x06003EC6 RID: 16070 RVA: 0x001840E4 File Offset: 0x001824E4
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

	// Token: 0x06003EC7 RID: 16071 RVA: 0x00184100 File Offset: 0x00182500
	public override IEnumerable AsAdventureEffectProcess(ISpecialEffectDataLoad specialEffectData, BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.UnitReadyInBattle && evt.EventTriggeringUnit.IsPlayer && specialEffectData is AttributeDepressionData)
		{
			AttributeDepressionData data = specialEffectData as AttributeDepressionData;
			IEnumerator enumerator = evt.EventTriggeringUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(evt.EventTriggeringUnit, new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = data.Type,
					ModificationType = ModificationType.Multiplication,
					Value = -data.ReductionRate,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				}
			}, "adventureattributedepression", new int?(1), null, null, false, false), false).GetEnumerator();
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

	// Token: 0x02000F15 RID: 3861
	[CompilerGenerated]
	private sealed class <AsAdventureEffectProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006190 RID: 24976 RVA: 0x0018412A File Offset: 0x0018252A
		[DebuggerHidden]
		public <AsAdventureEffectProcess>c__Iterator0()
		{
		}

		// Token: 0x06006191 RID: 24977 RVA: 0x00184134 File Offset: 0x00182534
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evt.EventType != AdventureEventType.UnitReadyInBattle || !evt.EventTriggeringUnit.IsPlayer || !(specialEffectData is AttributeDepressionData))
				{
					goto IL_18F;
				}
				data = (specialEffectData as AttributeDepressionData);
				enumerator = evt.EventTriggeringUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(evt.EventTriggeringUnit, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = data.Type,
						ModificationType = ModificationType.Multiplication,
						Value = -data.ReductionRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "adventureattributedepression", new int?(1), null, null, false, false), false).GetEnumerator();
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
			IL_18F:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700146F RID: 5231
		// (get) Token: 0x06006192 RID: 24978 RVA: 0x001842EC File Offset: 0x001826EC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001470 RID: 5232
		// (get) Token: 0x06006193 RID: 24979 RVA: 0x001842F4 File Offset: 0x001826F4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006194 RID: 24980 RVA: 0x001842FC File Offset: 0x001826FC
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

		// Token: 0x06006195 RID: 24981 RVA: 0x0018436C File Offset: 0x0018276C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006196 RID: 24982 RVA: 0x00184373 File Offset: 0x00182773
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006197 RID: 24983 RVA: 0x0018437C File Offset: 0x0018277C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			AttributeDepressionEffectProcess.<AsAdventureEffectProcess>c__Iterator0 <AsAdventureEffectProcess>c__Iterator = new AttributeDepressionEffectProcess.<AsAdventureEffectProcess>c__Iterator0();
			<AsAdventureEffectProcess>c__Iterator.evt = evt;
			<AsAdventureEffectProcess>c__Iterator.specialEffectData = specialEffectData;
			return <AsAdventureEffectProcess>c__Iterator;
		}

		// Token: 0x04005747 RID: 22343
		internal BroadcastEvent evt;

		// Token: 0x04005748 RID: 22344
		internal ISpecialEffectDataLoad specialEffectData;

		// Token: 0x04005749 RID: 22345
		internal AttributeDepressionData <data>__1;

		// Token: 0x0400574A RID: 22346
		internal IEnumerator $locvar0;

		// Token: 0x0400574B RID: 22347
		internal object <_>__2;

		// Token: 0x0400574C RID: 22348
		internal IDisposable $locvar1;

		// Token: 0x0400574D RID: 22349
		internal object $current;

		// Token: 0x0400574E RID: 22350
		internal bool $disposing;

		// Token: 0x0400574F RID: 22351
		internal int $PC;
	}
}
