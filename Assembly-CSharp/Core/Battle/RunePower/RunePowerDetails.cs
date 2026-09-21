using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Core.SpecialEffect.Dataload.RuneEnergyCollection;
using Core.SpecialEffect.Dataload.RuneEnergyCollection.Spender;

namespace Core.Battle.RunePower
{
	// Token: 0x02000463 RID: 1123
	public class RunePowerDetails
	{
		// Token: 0x06001FEC RID: 8172 RVA: 0x000DF31C File Offset: 0x000DD71C
		public RunePowerDetails(List<AdventurerBattleUnit> adventurers)
		{
			this.RunePowers = new Dictionary<RunePowerType, int>
			{
				{
					RunePowerType.ChaoticSpirit,
					0
				},
				{
					RunePowerType.GhostBreaths,
					0
				},
				{
					RunePowerType.PrismLight,
					0
				},
				{
					RunePowerType.VitalEnergy,
					0
				}
			};
			this.RuneCollectionRates = new Dictionary<SpecialEffectType, int>();
			List<RuneEnergyCollectorData> list = adventurers.SelectMany((AdventurerBattleUnit a) => a.SpecialEffects).OfType<RuneEnergyCollectorData>().ToList<RuneEnergyCollectorData>();
			this._powerEffects = new Dictionary<RunePowerType, RunePowerDetails.PowerEffect>();
			if (TestingProcessor.InTesting)
			{
				this.RuneCollectionRates[SpecialEffectType.ChaoticSpiritDirectKillCollection] = 6;
			}
			this._processInTurn = false;
			foreach (RuneEnergyCollectorData runeEnergyCollectorData in list)
			{
				if (this.RuneCollectionRates.ContainsKey(runeEnergyCollectorData.Type))
				{
					Dictionary<SpecialEffectType, int> runeCollectionRates;
					SpecialEffectType type;
					(runeCollectionRates = this.RuneCollectionRates)[type = runeEnergyCollectorData.Type] = runeCollectionRates[type] + runeEnergyCollectorData.Rate;
				}
				else
				{
					this.RuneCollectionRates.Add(runeEnergyCollectorData.Type, runeEnergyCollectorData.Rate);
				}
			}
			foreach (AdventurerBattleUnit adventurerBattleUnit in adventurers)
			{
				List<DeviceSpenderData> list2 = adventurerBattleUnit.SpecialEffects.OfType<DeviceSpenderData>().ToList<DeviceSpenderData>();
				foreach (DeviceSpenderData deviceSpenderData in list2)
				{
					if (!this._powerEffects.ContainsKey(deviceSpenderData.EnergyType))
					{
						this._powerEffects.Add(deviceSpenderData.EnergyType, new RunePowerDetails.PowerEffect
						{
							Spender = deviceSpenderData,
							Unit = adventurerBattleUnit
						});
						if (deviceSpenderData is DeathPreventData)
						{
							(deviceSpenderData as DeathPreventData).CurrentReviveables = 0;
						}
					}
				}
			}
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06001FED RID: 8173 RVA: 0x000DF554 File Offset: 0x000DD954
		// (set) Token: 0x06001FEE RID: 8174 RVA: 0x000DF55C File Offset: 0x000DD95C
		public Dictionary<RunePowerType, int> RunePowers
		{
			[CompilerGenerated]
			get
			{
				return this.<RunePowers>k__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				this.<RunePowers>k__BackingField = value;
			}
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06001FEF RID: 8175 RVA: 0x000DF565 File Offset: 0x000DD965
		// (set) Token: 0x06001FF0 RID: 8176 RVA: 0x000DF56D File Offset: 0x000DD96D
		public Dictionary<SpecialEffectType, int> RuneCollectionRates
		{
			[CompilerGenerated]
			get
			{
				return this.<RuneCollectionRates>k__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				this.<RuneCollectionRates>k__BackingField = value;
			}
		}

		// Token: 0x06001FF1 RID: 8177 RVA: 0x000DF578 File Offset: 0x000DD978
		public IEnumerable TryRun()
		{
			IEnumerator enumerator = this.TryRun(RunePowerType.ChaoticSpirit).GetEnumerator();
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
			IEnumerator enumerator2 = this.TryRun(RunePowerType.GhostBreaths).GetEnumerator();
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
			IEnumerator enumerator3 = this.TryRun(RunePowerType.PrismLight).GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					object _3 = enumerator3.Current;
					yield return _3;
				}
			}
			finally
			{
				IDisposable disposable3;
				if ((disposable3 = (enumerator3 as IDisposable)) != null)
				{
					disposable3.Dispose();
				}
			}
			IEnumerator enumerator4 = this.TryRun(RunePowerType.VitalEnergy).GetEnumerator();
			try
			{
				while (enumerator4.MoveNext())
				{
					object _4 = enumerator4.Current;
					yield return _4;
				}
			}
			finally
			{
				IDisposable disposable4;
				if ((disposable4 = (enumerator4 as IDisposable)) != null)
				{
					disposable4.Dispose();
				}
			}
			yield break;
		}

		// Token: 0x06001FF2 RID: 8178 RVA: 0x000DF59C File Offset: 0x000DD99C
		private IEnumerable TryRun(RunePowerType type)
		{
			if (this._powerEffects.ContainsKey(type) && this._powerEffects[type].Unit.IsAliveInBattle() && this.HasSufficientPower(type, this._powerEffects[type].Spender.Cost))
			{
				IEnumerator enumerator = this.ConsumePower(type, this._powerEffects[type].Spender.Cost, this._powerEffects[type].Unit).GetEnumerator();
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
				IEnumerator enumerator2 = this._powerEffects[type].Spender.Process(this._powerEffects[type].Unit).GetEnumerator();
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
			yield break;
		}

		// Token: 0x06001FF3 RID: 8179 RVA: 0x000DF5C6 File Offset: 0x000DD9C6
		public int GetRate(SpecialEffectType type)
		{
			if (this.RuneCollectionRates.ContainsKey(type))
			{
				return this.RuneCollectionRates[type];
			}
			return 0;
		}

		// Token: 0x06001FF4 RID: 8180 RVA: 0x000DF5E7 File Offset: 0x000DD9E7
		public int GetPowerAmount(RunePowerType type)
		{
			if (this.RunePowers.ContainsKey(type))
			{
				return this.RunePowers[type];
			}
			return 0;
		}

		// Token: 0x06001FF5 RID: 8181 RVA: 0x000DF608 File Offset: 0x000DDA08
		public bool HasSufficientPower(RunePowerType type, int amount)
		{
			return this.RunePowers.ContainsKey(type) && this.RunePowers[type] >= amount;
		}

		// Token: 0x06001FF6 RID: 8182 RVA: 0x000DF630 File Offset: 0x000DDA30
		public IEnumerable AddPower(RunePowerType type, int add, IBattleUnit triggerUnit)
		{
			if (add > 0)
			{
				int max = 100;
				if (!this.RunePowers.ContainsKey(type))
				{
					this.RunePowers.Add(type, 0);
				}
				int maxPossible = max - this.RunePowers[type];
				int toAdd = (add > maxPossible) ? maxPossible : add;
				Dictionary<RunePowerType, int> runePowers;
				(runePowers = this.RunePowers)[type] = runePowers[type] + toAdd;
				IEnumerator enumerator = this.TryRun(type).GetEnumerator();
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

		// Token: 0x06001FF7 RID: 8183 RVA: 0x000DF664 File Offset: 0x000DDA64
		public IEnumerable ConsumePower(RunePowerType type, int remove, IBattleUnit triggerUnit)
		{
			if (this.HasSufficientPower(type, remove))
			{
				Dictionary<RunePowerType, int> runePowers;
				(runePowers = this.RunePowers)[type] = runePowers[type] - remove;
				yield break;
			}
			yield break;
		}

		// Token: 0x06001FF8 RID: 8184 RVA: 0x000DF695 File Offset: 0x000DDA95
		[CompilerGenerated]
		private static IEnumerable<ISpecialEffectDataLoad> <RunePowerDetails>m__0(AdventurerBattleUnit a)
		{
			return a.SpecialEffects;
		}

		// Token: 0x04001C84 RID: 7300
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Dictionary<RunePowerType, int> <RunePowers>k__BackingField;

		// Token: 0x04001C85 RID: 7301
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Dictionary<SpecialEffectType, int> <RuneCollectionRates>k__BackingField;

		// Token: 0x04001C86 RID: 7302
		private Dictionary<RunePowerType, RunePowerDetails.PowerEffect> _powerEffects;

		// Token: 0x04001C87 RID: 7303
		public bool _processInTurn;

		// Token: 0x04001C88 RID: 7304
		[CompilerGenerated]
		private static Func<AdventurerBattleUnit, IEnumerable<ISpecialEffectDataLoad>> <>f__am$cache0;

		// Token: 0x02000464 RID: 1124
		private class PowerEffect
		{
			// Token: 0x06001FF9 RID: 8185 RVA: 0x000DF69D File Offset: 0x000DDA9D
			public PowerEffect()
			{
			}

			// Token: 0x170001F7 RID: 503
			// (get) Token: 0x06001FFA RID: 8186 RVA: 0x000DF6A5 File Offset: 0x000DDAA5
			// (set) Token: 0x06001FFB RID: 8187 RVA: 0x000DF6AD File Offset: 0x000DDAAD
			public AdventurerBattleUnit Unit
			{
				[CompilerGenerated]
				get
				{
					return this.<Unit>k__BackingField;
				}
				[CompilerGenerated]
				set
				{
					this.<Unit>k__BackingField = value;
				}
			}

			// Token: 0x170001F8 RID: 504
			// (get) Token: 0x06001FFC RID: 8188 RVA: 0x000DF6B6 File Offset: 0x000DDAB6
			// (set) Token: 0x06001FFD RID: 8189 RVA: 0x000DF6BE File Offset: 0x000DDABE
			public DeviceSpenderData Spender
			{
				[CompilerGenerated]
				get
				{
					return this.<Spender>k__BackingField;
				}
				[CompilerGenerated]
				set
				{
					this.<Spender>k__BackingField = value;
				}
			}

			// Token: 0x04001C89 RID: 7305
			[CompilerGenerated]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private AdventurerBattleUnit <Unit>k__BackingField;

			// Token: 0x04001C8A RID: 7306
			[CompilerGenerated]
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private DeviceSpenderData <Spender>k__BackingField;
		}

		// Token: 0x02000D1C RID: 3356
		[CompilerGenerated]
		private sealed class <TryRun>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06005610 RID: 22032 RVA: 0x000DF6C7 File Offset: 0x000DDAC7
			[DebuggerHidden]
			public <TryRun>c__Iterator0()
			{
			}

			// Token: 0x06005611 RID: 22033 RVA: 0x000DF6D0 File Offset: 0x000DDAD0
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					enumerator = base.TryRun(RunePowerType.ChaoticSpirit).GetEnumerator();
					num = 4294967293u;
					break;
				case 1u:
					break;
				case 2u:
					goto IL_E5;
				case 3u:
					goto IL_181;
				case 4u:
					goto IL_21D;
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
				enumerator2 = base.TryRun(RunePowerType.GhostBreaths).GetEnumerator();
				num = 4294967293u;
				try
				{
					IL_E5:
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
				enumerator3 = base.TryRun(RunePowerType.PrismLight).GetEnumerator();
				num = 4294967293u;
				try
				{
					IL_181:
					switch (num)
					{
					}
					if (enumerator3.MoveNext())
					{
						_3 = enumerator3.Current;
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
						if ((disposable3 = (enumerator3 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				enumerator4 = base.TryRun(RunePowerType.VitalEnergy).GetEnumerator();
				num = 4294967293u;
				try
				{
					IL_21D:
					switch (num)
					{
					}
					if (enumerator4.MoveNext())
					{
						_4 = enumerator4.Current;
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
						if ((disposable4 = (enumerator4 as IDisposable)) != null)
						{
							disposable4.Dispose();
						}
					}
				}
				this.$PC = -1;
				return false;
			}

			// Token: 0x1700122E RID: 4654
			// (get) Token: 0x06005612 RID: 22034 RVA: 0x000DF9BC File Offset: 0x000DDDBC
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700122F RID: 4655
			// (get) Token: 0x06005613 RID: 22035 RVA: 0x000DF9C4 File Offset: 0x000DDDC4
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06005614 RID: 22036 RVA: 0x000DF9CC File Offset: 0x000DDDCC
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
					}
					finally
					{
						if ((disposable3 = (enumerator3 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
					break;
				case 4u:
					try
					{
					}
					finally
					{
						if ((disposable4 = (enumerator4 as IDisposable)) != null)
						{
							disposable4.Dispose();
						}
					}
					break;
				}
			}

			// Token: 0x06005615 RID: 22037 RVA: 0x000DFAF8 File Offset: 0x000DDEF8
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x06005616 RID: 22038 RVA: 0x000DFAFF File Offset: 0x000DDEFF
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x06005617 RID: 22039 RVA: 0x000DFB08 File Offset: 0x000DDF08
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				RunePowerDetails.<TryRun>c__Iterator0 <TryRun>c__Iterator = new RunePowerDetails.<TryRun>c__Iterator0();
				<TryRun>c__Iterator.$this = this;
				return <TryRun>c__Iterator;
			}

			// Token: 0x04004493 RID: 17555
			internal IEnumerator $locvar0;

			// Token: 0x04004494 RID: 17556
			internal object <_>__1;

			// Token: 0x04004495 RID: 17557
			internal IDisposable $locvar1;

			// Token: 0x04004496 RID: 17558
			internal IEnumerator $locvar2;

			// Token: 0x04004497 RID: 17559
			internal object <_>__2;

			// Token: 0x04004498 RID: 17560
			internal IDisposable $locvar3;

			// Token: 0x04004499 RID: 17561
			internal IEnumerator $locvar4;

			// Token: 0x0400449A RID: 17562
			internal object <_>__3;

			// Token: 0x0400449B RID: 17563
			internal IDisposable $locvar5;

			// Token: 0x0400449C RID: 17564
			internal IEnumerator $locvar6;

			// Token: 0x0400449D RID: 17565
			internal object <_>__4;

			// Token: 0x0400449E RID: 17566
			internal IDisposable $locvar7;

			// Token: 0x0400449F RID: 17567
			internal RunePowerDetails $this;

			// Token: 0x040044A0 RID: 17568
			internal object $current;

			// Token: 0x040044A1 RID: 17569
			internal bool $disposing;

			// Token: 0x040044A2 RID: 17570
			internal int $PC;
		}

		// Token: 0x02000D1D RID: 3357
		[CompilerGenerated]
		private sealed class <TryRun>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06005618 RID: 22040 RVA: 0x000DFB3C File Offset: 0x000DDF3C
			[DebuggerHidden]
			public <TryRun>c__Iterator1()
			{
			}

			// Token: 0x06005619 RID: 22041 RVA: 0x000DFB44 File Offset: 0x000DDF44
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
					if (!this._powerEffects.ContainsKey(type) || !this._powerEffects[type].Unit.IsAliveInBattle() || !base.HasSufficientPower(type, this._powerEffects[type].Spender.Cost))
					{
						goto IL_244;
					}
					enumerator = base.ConsumePower(type, this._powerEffects[type].Spender.Cost, this._powerEffects[type].Unit).GetEnumerator();
					num = 4294967293u;
					break;
				case 1u:
					break;
				case 2u:
					goto IL_1C2;
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
				enumerator2 = this._powerEffects[type].Spender.Process(this._powerEffects[type].Unit).GetEnumerator();
				num = 4294967293u;
				try
				{
					IL_1C2:
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
				IL_244:
				this.$PC = -1;
				return false;
			}

			// Token: 0x17001230 RID: 4656
			// (get) Token: 0x0600561A RID: 22042 RVA: 0x000DFDBC File Offset: 0x000DE1BC
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001231 RID: 4657
			// (get) Token: 0x0600561B RID: 22043 RVA: 0x000DFDC4 File Offset: 0x000DE1C4
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x0600561C RID: 22044 RVA: 0x000DFDCC File Offset: 0x000DE1CC
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

			// Token: 0x0600561D RID: 22045 RVA: 0x000DFE7C File Offset: 0x000DE27C
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x0600561E RID: 22046 RVA: 0x000DFE83 File Offset: 0x000DE283
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x0600561F RID: 22047 RVA: 0x000DFE8C File Offset: 0x000DE28C
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				RunePowerDetails.<TryRun>c__Iterator1 <TryRun>c__Iterator = new RunePowerDetails.<TryRun>c__Iterator1();
				<TryRun>c__Iterator.$this = this;
				<TryRun>c__Iterator.type = type;
				return <TryRun>c__Iterator;
			}

			// Token: 0x040044A3 RID: 17571
			internal RunePowerType type;

			// Token: 0x040044A4 RID: 17572
			internal IEnumerator $locvar0;

			// Token: 0x040044A5 RID: 17573
			internal object <_>__1;

			// Token: 0x040044A6 RID: 17574
			internal IDisposable $locvar1;

			// Token: 0x040044A7 RID: 17575
			internal IEnumerator $locvar2;

			// Token: 0x040044A8 RID: 17576
			internal object <_>__2;

			// Token: 0x040044A9 RID: 17577
			internal IDisposable $locvar3;

			// Token: 0x040044AA RID: 17578
			internal RunePowerDetails $this;

			// Token: 0x040044AB RID: 17579
			internal object $current;

			// Token: 0x040044AC RID: 17580
			internal bool $disposing;

			// Token: 0x040044AD RID: 17581
			internal int $PC;
		}

		// Token: 0x02000D1E RID: 3358
		[CompilerGenerated]
		private sealed class <AddPower>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06005620 RID: 22048 RVA: 0x000DFECC File Offset: 0x000DE2CC
			[DebuggerHidden]
			public <AddPower>c__Iterator2()
			{
			}

			// Token: 0x06005621 RID: 22049 RVA: 0x000DFED4 File Offset: 0x000DE2D4
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0u:
				{
					if (add <= 0)
					{
						goto IL_17F;
					}
					max = 100;
					if (!base.RunePowers.ContainsKey(type))
					{
						base.RunePowers.Add(type, 0);
					}
					maxPossible = max - base.RunePowers[type];
					toAdd = ((add > maxPossible) ? maxPossible : add);
					Dictionary<RunePowerType, int> runePowers;
					RunePowerType key;
					(runePowers = base.RunePowers)[key = type] = runePowers[key] + toAdd;
					enumerator = base.TryRun(type).GetEnumerator();
					num = 4294967293u;
					break;
				}
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
				IL_17F:
				this.$PC = -1;
				return false;
			}

			// Token: 0x17001232 RID: 4658
			// (get) Token: 0x06005622 RID: 22050 RVA: 0x000E007C File Offset: 0x000DE47C
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001233 RID: 4659
			// (get) Token: 0x06005623 RID: 22051 RVA: 0x000E0084 File Offset: 0x000DE484
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06005624 RID: 22052 RVA: 0x000E008C File Offset: 0x000DE48C
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

			// Token: 0x06005625 RID: 22053 RVA: 0x000E00FC File Offset: 0x000DE4FC
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x06005626 RID: 22054 RVA: 0x000E0103 File Offset: 0x000DE503
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x06005627 RID: 22055 RVA: 0x000E010C File Offset: 0x000DE50C
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				RunePowerDetails.<AddPower>c__Iterator2 <AddPower>c__Iterator = new RunePowerDetails.<AddPower>c__Iterator2();
				<AddPower>c__Iterator.$this = this;
				<AddPower>c__Iterator.add = add;
				<AddPower>c__Iterator.type = type;
				return <AddPower>c__Iterator;
			}

			// Token: 0x040044AE RID: 17582
			internal int add;

			// Token: 0x040044AF RID: 17583
			internal int <max>__1;

			// Token: 0x040044B0 RID: 17584
			internal RunePowerType type;

			// Token: 0x040044B1 RID: 17585
			internal int <maxPossible>__1;

			// Token: 0x040044B2 RID: 17586
			internal int <toAdd>__1;

			// Token: 0x040044B3 RID: 17587
			internal IEnumerator $locvar0;

			// Token: 0x040044B4 RID: 17588
			internal object <_>__2;

			// Token: 0x040044B5 RID: 17589
			internal IDisposable $locvar1;

			// Token: 0x040044B6 RID: 17590
			internal RunePowerDetails $this;

			// Token: 0x040044B7 RID: 17591
			internal object $current;

			// Token: 0x040044B8 RID: 17592
			internal bool $disposing;

			// Token: 0x040044B9 RID: 17593
			internal int $PC;
		}

		// Token: 0x02000D1F RID: 3359
		[CompilerGenerated]
		private sealed class <ConsumePower>c__Iterator3 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06005628 RID: 22056 RVA: 0x000E0158 File Offset: 0x000DE558
			[DebuggerHidden]
			public <ConsumePower>c__Iterator3()
			{
			}

			// Token: 0x06005629 RID: 22057 RVA: 0x000E0160 File Offset: 0x000DE560
			public bool MoveNext()
			{
				bool flag = this.$PC != 0;
				this.$PC = -1;
				if (!flag && base.HasSufficientPower(type, remove))
				{
					Dictionary<RunePowerType, int> runePowers;
					RunePowerType key;
					(runePowers = base.RunePowers)[key = type] = runePowers[key] - remove;
				}
				return false;
			}

			// Token: 0x17001234 RID: 4660
			// (get) Token: 0x0600562A RID: 22058 RVA: 0x000E01C9 File Offset: 0x000DE5C9
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17001235 RID: 4661
			// (get) Token: 0x0600562B RID: 22059 RVA: 0x000E01D1 File Offset: 0x000DE5D1
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x0600562C RID: 22060 RVA: 0x000E01D9 File Offset: 0x000DE5D9
			[DebuggerHidden]
			public void Dispose()
			{
			}

			// Token: 0x0600562D RID: 22061 RVA: 0x000E01DB File Offset: 0x000DE5DB
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x0600562E RID: 22062 RVA: 0x000E01E2 File Offset: 0x000DE5E2
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
			}

			// Token: 0x0600562F RID: 22063 RVA: 0x000E01EC File Offset: 0x000DE5EC
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				RunePowerDetails.<ConsumePower>c__Iterator3 <ConsumePower>c__Iterator = new RunePowerDetails.<ConsumePower>c__Iterator3();
				<ConsumePower>c__Iterator.$this = this;
				<ConsumePower>c__Iterator.type = type;
				<ConsumePower>c__Iterator.remove = remove;
				return <ConsumePower>c__Iterator;
			}

			// Token: 0x040044BA RID: 17594
			internal RunePowerType type;

			// Token: 0x040044BB RID: 17595
			internal int remove;

			// Token: 0x040044BC RID: 17596
			internal RunePowerDetails $this;

			// Token: 0x040044BD RID: 17597
			internal object $current;

			// Token: 0x040044BE RID: 17598
			internal bool $disposing;

			// Token: 0x040044BF RID: 17599
			internal int $PC;
		}
	}
}
