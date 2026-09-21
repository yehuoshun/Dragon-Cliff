using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Assets.Scripts.Core.Skills.SkillEffect
{
	// Token: 0x0200074F RID: 1871
	public sealed class EmbracedMindEffect : BattleEffectBase
	{
		// Token: 0x060035C8 RID: 13768 RVA: 0x00166D2C File Offset: 0x0016512C
		public EmbracedMindEffect(IBattleEffectSource efsource, bool isThroughEffect, bool canBeImmuned, float? maxNumberOfLastingSeconds, int? numberOfLastingTurns, bool canBeDispersed)
		{
			this._effectSource = efsource;
			this._isThroughEffect = isThroughEffect;
			this._canBeImmuned = canBeImmuned;
			this._maxStackableInstances = new int?(1);
			this.MaxNumberOfLastingSeconds = maxNumberOfLastingSeconds;
			this.NumberOfLastingTurns = numberOfLastingTurns;
			this.CanBeDispersed = canBeDispersed;
			base.Description = this.BattleEffectType.GetDescription();
			base.TurnEventsCollected = new List<AdventureEventType>();
		}

		// Token: 0x060035C9 RID: 13769 RVA: 0x00166DA7 File Offset: 0x001651A7
		public override List<AdventureEventType> CorrespondingEvents()
		{
			return new List<AdventureEventType>();
		}

		// Token: 0x1700092A RID: 2346
		// (get) Token: 0x060035CA RID: 13770 RVA: 0x00166DAE File Offset: 0x001651AE
		public override string EffectSourceIdentityCode
		{
			get
			{
				return this._effectSourceIdentityCode;
			}
		}

		// Token: 0x1700092B RID: 2347
		// (get) Token: 0x060035CB RID: 13771 RVA: 0x00166DB6 File Offset: 0x001651B6
		public override BattleEffectType BattleEffectType
		{
			get
			{
				return this._battleEffectType;
			}
		}

		// Token: 0x1700092C RID: 2348
		// (get) Token: 0x060035CC RID: 13772 RVA: 0x00166DBE File Offset: 0x001651BE
		// (set) Token: 0x060035CD RID: 13773 RVA: 0x00166DC6 File Offset: 0x001651C6
		public override float? MaxNumberOfLastingSeconds
		{
			[CompilerGenerated]
			get
			{
				return this.<MaxNumberOfLastingSeconds>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<MaxNumberOfLastingSeconds>k__BackingField = value;
			}
		}

		// Token: 0x1700092D RID: 2349
		// (get) Token: 0x060035CE RID: 13774 RVA: 0x00166DCF File Offset: 0x001651CF
		public override IBattleEffectSource EffectSource
		{
			get
			{
				return this._effectSource;
			}
		}

		// Token: 0x1700092E RID: 2350
		// (get) Token: 0x060035CF RID: 13775 RVA: 0x00166DD7 File Offset: 0x001651D7
		// (set) Token: 0x060035D0 RID: 13776 RVA: 0x00166DDF File Offset: 0x001651DF
		public override int? NumberOfLastingTurns
		{
			[CompilerGenerated]
			get
			{
				return this.<NumberOfLastingTurns>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<NumberOfLastingTurns>k__BackingField = value;
			}
		}

		// Token: 0x1700092F RID: 2351
		// (get) Token: 0x060035D1 RID: 13777 RVA: 0x00166DE8 File Offset: 0x001651E8
		public override bool IsThroughEffect
		{
			get
			{
				return this._isThroughEffect;
			}
		}

		// Token: 0x17000930 RID: 2352
		// (get) Token: 0x060035D2 RID: 13778 RVA: 0x00166DF0 File Offset: 0x001651F0
		public override bool CanBeImmuned
		{
			get
			{
				return this._canBeImmuned;
			}
		}

		// Token: 0x17000931 RID: 2353
		// (get) Token: 0x060035D3 RID: 13779 RVA: 0x00166DF8 File Offset: 0x001651F8
		// (set) Token: 0x060035D4 RID: 13780 RVA: 0x00166E00 File Offset: 0x00165200
		public override bool CanBeDispersed
		{
			[CompilerGenerated]
			get
			{
				return this.<CanBeDispersed>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<CanBeDispersed>k__BackingField = value;
			}
		}

		// Token: 0x17000932 RID: 2354
		// (get) Token: 0x060035D5 RID: 13781 RVA: 0x00166E09 File Offset: 0x00165209
		public override int? MaxStackableInstances
		{
			get
			{
				return this._maxStackableInstances;
			}
		}

		// Token: 0x17000933 RID: 2355
		// (get) Token: 0x060035D6 RID: 13782 RVA: 0x00166E11 File Offset: 0x00165211
		public override BattleEffectNature BattleEffectNatureForWearer
		{
			get
			{
				return this._battleEffectNatureForWearer;
			}
		}

		// Token: 0x040029EC RID: 10732
		private string _effectSourceIdentityCode = "embracedMindunique";

		// Token: 0x040029ED RID: 10733
		private BattleEffectType _battleEffectType = BattleEffectType.EmbracedMind;

		// Token: 0x040029EE RID: 10734
		private IBattleEffectSource _effectSource;

		// Token: 0x040029EF RID: 10735
		private bool _isThroughEffect;

		// Token: 0x040029F0 RID: 10736
		private bool _canBeImmuned;

		// Token: 0x040029F1 RID: 10737
		private int? _maxStackableInstances;

		// Token: 0x040029F2 RID: 10738
		private BattleEffectNature _battleEffectNatureForWearer;

		// Token: 0x040029F3 RID: 10739
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float? <MaxNumberOfLastingSeconds>k__BackingField;

		// Token: 0x040029F4 RID: 10740
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int? <NumberOfLastingTurns>k__BackingField;

		// Token: 0x040029F5 RID: 10741
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool <CanBeDispersed>k__BackingField;
	}
}
