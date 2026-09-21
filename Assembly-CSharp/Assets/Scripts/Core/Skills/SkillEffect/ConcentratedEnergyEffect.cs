using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Assets.Scripts.Core.Skills.SkillEffect
{
	// Token: 0x02000741 RID: 1857
	public sealed class ConcentratedEnergyEffect : BattleEffectBase
	{
		// Token: 0x060034CE RID: 13518 RVA: 0x0015FA88 File Offset: 0x0015DE88
		public ConcentratedEnergyEffect(IBattleEffectSource effectSource, bool isThroughEffect, bool canBeImmuned, float? maxNumberOfLastingSeconds, int? numberOfLastingTurns, bool canBeDispersed)
		{
			this._effectSource = effectSource;
			this._isThroughEffect = isThroughEffect;
			this._canBeImmuned = canBeImmuned;
			this._maxStackableInstances = new int?(15);
			this.MaxNumberOfLastingSeconds = maxNumberOfLastingSeconds;
			this.NumberOfLastingTurns = numberOfLastingTurns;
			this.CanBeDispersed = canBeDispersed;
			this._battleEffectNatureForWearer = BattleEffectNature.Positive;
			base.Description = BattleEffectType.ConcentratedEnergy.GetDescription();
			base.TurnEventsCollected = new List<AdventureEventType>();
		}

		// Token: 0x060034CF RID: 13519 RVA: 0x0015FB07 File Offset: 0x0015DF07
		public override List<AdventureEventType> CorrespondingEvents()
		{
			return new List<AdventureEventType>();
		}

		// Token: 0x17000899 RID: 2201
		// (get) Token: 0x060034D0 RID: 13520 RVA: 0x0015FB0E File Offset: 0x0015DF0E
		public override string EffectSourceIdentityCode
		{
			get
			{
				return this._effectSourceIdentityCode;
			}
		}

		// Token: 0x1700089A RID: 2202
		// (get) Token: 0x060034D1 RID: 13521 RVA: 0x0015FB16 File Offset: 0x0015DF16
		public override BattleEffectType BattleEffectType
		{
			get
			{
				return this._battleEffectType;
			}
		}

		// Token: 0x1700089B RID: 2203
		// (get) Token: 0x060034D2 RID: 13522 RVA: 0x0015FB1E File Offset: 0x0015DF1E
		// (set) Token: 0x060034D3 RID: 13523 RVA: 0x0015FB26 File Offset: 0x0015DF26
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

		// Token: 0x1700089C RID: 2204
		// (get) Token: 0x060034D4 RID: 13524 RVA: 0x0015FB2F File Offset: 0x0015DF2F
		public override IBattleEffectSource EffectSource
		{
			get
			{
				return this._effectSource;
			}
		}

		// Token: 0x1700089D RID: 2205
		// (get) Token: 0x060034D5 RID: 13525 RVA: 0x0015FB37 File Offset: 0x0015DF37
		// (set) Token: 0x060034D6 RID: 13526 RVA: 0x0015FB3F File Offset: 0x0015DF3F
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

		// Token: 0x1700089E RID: 2206
		// (get) Token: 0x060034D7 RID: 13527 RVA: 0x0015FB48 File Offset: 0x0015DF48
		public override bool IsThroughEffect
		{
			get
			{
				return this._isThroughEffect;
			}
		}

		// Token: 0x1700089F RID: 2207
		// (get) Token: 0x060034D8 RID: 13528 RVA: 0x0015FB50 File Offset: 0x0015DF50
		public override bool CanBeImmuned
		{
			get
			{
				return this._canBeImmuned;
			}
		}

		// Token: 0x170008A0 RID: 2208
		// (get) Token: 0x060034D9 RID: 13529 RVA: 0x0015FB58 File Offset: 0x0015DF58
		// (set) Token: 0x060034DA RID: 13530 RVA: 0x0015FB60 File Offset: 0x0015DF60
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

		// Token: 0x170008A1 RID: 2209
		// (get) Token: 0x060034DB RID: 13531 RVA: 0x0015FB69 File Offset: 0x0015DF69
		public override int? MaxStackableInstances
		{
			get
			{
				return this._maxStackableInstances;
			}
		}

		// Token: 0x170008A2 RID: 2210
		// (get) Token: 0x060034DC RID: 13532 RVA: 0x0015FB71 File Offset: 0x0015DF71
		public override BattleEffectNature BattleEffectNatureForWearer
		{
			get
			{
				return this._battleEffectNatureForWearer;
			}
		}

		// Token: 0x0400294F RID: 10575
		private string _effectSourceIdentityCode = "concentratedenergykiller";

		// Token: 0x04002950 RID: 10576
		private BattleEffectType _battleEffectType = BattleEffectType.ConcentratedEnergy;

		// Token: 0x04002951 RID: 10577
		private IBattleEffectSource _effectSource;

		// Token: 0x04002952 RID: 10578
		private bool _isThroughEffect;

		// Token: 0x04002953 RID: 10579
		private bool _canBeImmuned;

		// Token: 0x04002954 RID: 10580
		private int? _maxStackableInstances;

		// Token: 0x04002955 RID: 10581
		private BattleEffectNature _battleEffectNatureForWearer;

		// Token: 0x04002956 RID: 10582
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float? <MaxNumberOfLastingSeconds>k__BackingField;

		// Token: 0x04002957 RID: 10583
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int? <NumberOfLastingTurns>k__BackingField;

		// Token: 0x04002958 RID: 10584
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool <CanBeDispersed>k__BackingField;
	}
}
