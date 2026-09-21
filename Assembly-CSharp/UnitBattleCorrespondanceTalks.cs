using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x0200096C RID: 2412
public class UnitBattleCorrespondanceTalks : GenericBattleSequenceBase
{
	// Token: 0x06004261 RID: 16993 RVA: 0x001B19AC File Offset: 0x001AFDAC
	public UnitBattleCorrespondanceTalks()
	{
	}

	// Token: 0x17000D0D RID: 3341
	// (get) Token: 0x06004262 RID: 16994 RVA: 0x001B19B4 File Offset: 0x001AFDB4
	public Dictionary<DialogIdentifier, AdventurerCorrespondance> AdventurerSkillTalks
	{
		get
		{
			return new Dictionary<DialogIdentifier, AdventurerCorrespondance>
			{
				{
					DialogIdentifier.FirePlayerTactic_c1,
					new AdventurerCorrespondance
					{
						Talks = new List<DialogIdentifier>
						{
							DialogIdentifier.FirePlayerTactic_c1_Cors
						},
						NeedsTobeDifferentTalker = true,
						RequiredCorrespondanceClass = null,
						MustCorresponding = true
					}
				}
			};
		}
	}

	// Token: 0x06004263 RID: 16995 RVA: 0x001B1A10 File Offset: 0x001AFE10
	public override bool MetRequirement(BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.UnitBattleDialogueCompleted)
		{
			BattleUnitSpeaksEvent battleUnitSpeaksEvent = evt.AdditionalData as BattleUnitSpeaksEvent;
			if (battleUnitSpeaksEvent != null)
			{
				UnitBattleCorrespondanceTalks.CorrespondanceModule talker = this.GetTalker(battleUnitSpeaksEvent);
				return talker != null && talker.Talker != null;
			}
		}
		return false;
	}

	// Token: 0x06004264 RID: 16996 RVA: 0x001B1A60 File Offset: 0x001AFE60
	private UnitBattleCorrespondanceTalks.CorrespondanceModule GetTalker(BattleUnitSpeaksEvent talk)
	{
		foreach (DialogDetails dialogDetails in talk.DialogDetails)
		{
			if (this.AdventurerSkillTalks.ContainsKey(dialogDetails.Identifier))
			{
				AdventurerCorrespondance cors = this.AdventurerSkillTalks[dialogDetails.Identifier];
				if (cors.NeedsTobeDifferentTalker)
				{
					if (cors.RequiredCorrespondanceClass != null)
					{
						return new UnitBattleCorrespondanceTalks.CorrespondanceModule
						{
							Talker = talk.BattleUnit.GetAllLiveFriendlyTargetsIncSelf(false).FirstOrDefault((IBattleUnit c) => c != talk.BattleUnit && c.GetUnitType() == cors.RequiredCorrespondanceClass.Value),
							Correspondance = cors
						};
					}
					return new UnitBattleCorrespondanceTalks.CorrespondanceModule
					{
						Talker = talk.BattleUnit.GetAllLiveFriendlyTargetsIncSelf(false).FirstOrDefault((IBattleUnit c) => c != talk.BattleUnit),
						Correspondance = cors
					};
				}
				else
				{
					if (cors.RequiredCorrespondanceClass != null)
					{
						return new UnitBattleCorrespondanceTalks.CorrespondanceModule
						{
							Talker = talk.BattleUnit.GetAllLiveFriendlyTargetsIncSelf(false).FirstOrDefault((IBattleUnit c) => c.GetUnitType() == cors.RequiredCorrespondanceClass.Value),
							Correspondance = cors
						};
					}
					return new UnitBattleCorrespondanceTalks.CorrespondanceModule
					{
						Talker = talk.BattleUnit.GetAllLiveFriendlyTargetsIncSelf(false).FirstOrDefault<IBattleUnit>(),
						Correspondance = cors
					};
				}
			}
		}
		return null;
	}

	// Token: 0x06004265 RID: 16997 RVA: 0x001B1C60 File Offset: 0x001B0060
	public override IEnumerable Run(BroadcastEvent evt)
	{
		if (evt.EventType == AdventureEventType.UnitBattleDialogueCompleted)
		{
			BattleUnitSpeaksEvent talk = evt.AdditionalData as BattleUnitSpeaksEvent;
			if (talk != null)
			{
				UnitBattleCorrespondanceTalks.CorrespondanceModule content = this.GetTalker(talk);
				if (content.Correspondance.Talks.Any<DialogIdentifier>())
				{
					DialogIdentifier selected = content.Correspondance.Talks[UnityEngine.Random.Range(0, content.Correspondance.Talks.Count)];
					if (content.Correspondance.MustCorresponding)
					{
						IEnumerator enumerator = content.Talker.RandomBattleTalk(selected, 1f).GetEnumerator();
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
					else
					{
						IEnumerator enumerator2 = content.Talker.RandomBattleTalk(selected, 0.4f).GetEnumerator();
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
				}
			}
		}
		yield break;
	}

	// Token: 0x0200096D RID: 2413
	private class CorrespondanceModule
	{
		// Token: 0x06004266 RID: 16998 RVA: 0x001B1C8A File Offset: 0x001B008A
		public CorrespondanceModule()
		{
		}

		// Token: 0x17000D0E RID: 3342
		// (get) Token: 0x06004267 RID: 16999 RVA: 0x001B1C92 File Offset: 0x001B0092
		// (set) Token: 0x06004268 RID: 17000 RVA: 0x001B1C9A File Offset: 0x001B009A
		public IBattleUnit Talker
		{
			[CompilerGenerated]
			get
			{
				return this.<Talker>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<Talker>k__BackingField = value;
			}
		}

		// Token: 0x17000D0F RID: 3343
		// (get) Token: 0x06004269 RID: 17001 RVA: 0x001B1CA3 File Offset: 0x001B00A3
		// (set) Token: 0x0600426A RID: 17002 RVA: 0x001B1CAB File Offset: 0x001B00AB
		public AdventurerCorrespondance Correspondance
		{
			[CompilerGenerated]
			get
			{
				return this.<Correspondance>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<Correspondance>k__BackingField = value;
			}
		}

		// Token: 0x040031C0 RID: 12736
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IBattleUnit <Talker>k__BackingField;

		// Token: 0x040031C1 RID: 12737
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private AdventurerCorrespondance <Correspondance>k__BackingField;
	}

	// Token: 0x02000FF4 RID: 4084
	[CompilerGenerated]
	private sealed class <GetTalker>c__AnonStorey1
	{
		// Token: 0x06006771 RID: 26481 RVA: 0x001B1CB4 File Offset: 0x001B00B4
		public <GetTalker>c__AnonStorey1()
		{
		}

		// Token: 0x04006164 RID: 24932
		internal BattleUnitSpeaksEvent talk;
	}

	// Token: 0x02000FF5 RID: 4085
	[CompilerGenerated]
	private sealed class <GetTalker>c__AnonStorey2
	{
		// Token: 0x06006772 RID: 26482 RVA: 0x001B1CBC File Offset: 0x001B00BC
		public <GetTalker>c__AnonStorey2()
		{
		}

		// Token: 0x06006773 RID: 26483 RVA: 0x001B1CC4 File Offset: 0x001B00C4
		internal bool <>m__0(IBattleUnit c)
		{
			return c != this.<>f__ref$1.talk.BattleUnit && c.GetUnitType() == this.cors.RequiredCorrespondanceClass.Value;
		}

		// Token: 0x06006774 RID: 26484 RVA: 0x001B1D05 File Offset: 0x001B0105
		internal bool <>m__1(IBattleUnit c)
		{
			return c != this.<>f__ref$1.talk.BattleUnit;
		}

		// Token: 0x06006775 RID: 26485 RVA: 0x001B1D20 File Offset: 0x001B0120
		internal bool <>m__2(IBattleUnit c)
		{
			return c.GetUnitType() == this.cors.RequiredCorrespondanceClass.Value;
		}

		// Token: 0x04006165 RID: 24933
		internal AdventurerCorrespondance cors;

		// Token: 0x04006166 RID: 24934
		internal UnitBattleCorrespondanceTalks.<GetTalker>c__AnonStorey1 <>f__ref$1;
	}

	// Token: 0x02000FF6 RID: 4086
	[CompilerGenerated]
	private sealed class <Run>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006776 RID: 26486 RVA: 0x001B1D48 File Offset: 0x001B0148
		[DebuggerHidden]
		public <Run>c__Iterator0()
		{
		}

		// Token: 0x06006777 RID: 26487 RVA: 0x001B1D50 File Offset: 0x001B0150
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (evt.EventType != AdventureEventType.UnitBattleDialogueCompleted)
				{
					goto IL_231;
				}
				talk = (evt.AdditionalData as BattleUnitSpeaksEvent);
				if (talk == null)
				{
					goto IL_231;
				}
				content = base.GetTalker(talk);
				if (!content.Correspondance.Talks.Any<DialogIdentifier>())
				{
					goto IL_231;
				}
				selected = content.Correspondance.Talks[UnityEngine.Random.Range(0, content.Correspondance.Talks.Count)];
				if (!content.Correspondance.MustCorresponding)
				{
					enumerator2 = content.Talker.RandomBattleTalk(selected, 0.4f).GetEnumerator();
					num = 4294967293u;
					goto Block_7;
				}
				enumerator = content.Talker.RandomBattleTalk(selected, 1f).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_1AF;
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
			goto IL_231;
			Block_7:
			try
			{
				IL_1AF:
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
			IL_231:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170015B3 RID: 5555
		// (get) Token: 0x06006778 RID: 26488 RVA: 0x001B1FB4 File Offset: 0x001B03B4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170015B4 RID: 5556
		// (get) Token: 0x06006779 RID: 26489 RVA: 0x001B1FBC File Offset: 0x001B03BC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600677A RID: 26490 RVA: 0x001B1FC4 File Offset: 0x001B03C4
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

		// Token: 0x0600677B RID: 26491 RVA: 0x001B2074 File Offset: 0x001B0474
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600677C RID: 26492 RVA: 0x001B207B File Offset: 0x001B047B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600677D RID: 26493 RVA: 0x001B2084 File Offset: 0x001B0484
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UnitBattleCorrespondanceTalks.<Run>c__Iterator0 <Run>c__Iterator = new UnitBattleCorrespondanceTalks.<Run>c__Iterator0();
			<Run>c__Iterator.$this = this;
			<Run>c__Iterator.evt = evt;
			return <Run>c__Iterator;
		}

		// Token: 0x04006167 RID: 24935
		internal BroadcastEvent evt;

		// Token: 0x04006168 RID: 24936
		internal BattleUnitSpeaksEvent <talk>__1;

		// Token: 0x04006169 RID: 24937
		internal UnitBattleCorrespondanceTalks.CorrespondanceModule <content>__2;

		// Token: 0x0400616A RID: 24938
		internal DialogIdentifier <selected>__3;

		// Token: 0x0400616B RID: 24939
		internal IEnumerator $locvar0;

		// Token: 0x0400616C RID: 24940
		internal object <_>__4;

		// Token: 0x0400616D RID: 24941
		internal IDisposable $locvar1;

		// Token: 0x0400616E RID: 24942
		internal IEnumerator $locvar2;

		// Token: 0x0400616F RID: 24943
		internal object <_>__5;

		// Token: 0x04006170 RID: 24944
		internal IDisposable $locvar3;

		// Token: 0x04006171 RID: 24945
		internal UnitBattleCorrespondanceTalks $this;

		// Token: 0x04006172 RID: 24946
		internal object $current;

		// Token: 0x04006173 RID: 24947
		internal bool $disposing;

		// Token: 0x04006174 RID: 24948
		internal int $PC;
	}
}
