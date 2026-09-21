using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200014D RID: 333
public class TownAppearanceManager : MonoBehaviour
{
	// Token: 0x06000914 RID: 2324 RVA: 0x00079870 File Offset: 0x00077C70
	public TownAppearanceManager()
	{
	}

	// Token: 0x06000915 RID: 2325 RVA: 0x00079878 File Offset: 0x00077C78
	private void Awake()
	{
		if (TownAppearanceManager.Instance == null)
		{
			TownAppearanceManager.Instance = this;
		}
	}

	// Token: 0x06000916 RID: 2326 RVA: 0x00079890 File Offset: 0x00077C90
	public IEnumerator SeasonChange(Season currentSeason)
	{
		yield return null;
		this.UpdateSeasonMap(currentSeason);
		yield break;
	}

	// Token: 0x06000917 RID: 2327 RVA: 0x000798B2 File Offset: 0x00077CB2
	public void UpdateSeasonMap(Season currentSeason)
	{
		this.TownSpringMap.SetActive(currentSeason == Season.Spring);
		this.TownSummerMap.SetActive(currentSeason == Season.Summer);
		this.TownAutumnMap.SetActive(currentSeason == Season.Autumn);
		this.TownWinterMap.SetActive(currentSeason == Season.Winter);
	}

	// Token: 0x06000918 RID: 2328 RVA: 0x000798F0 File Offset: 0x00077CF0
	public void WeatherChange(Weather currentWeather)
	{
		this.RainingSystem.SetActive(false);
		this.SnowingSystem.SetActive(currentWeather == Weather.Snow);
		this.CloudySystem.SetActive(currentWeather == Weather.Windy);
	}

	// Token: 0x04000BBD RID: 3005
	public static TownAppearanceManager Instance;

	// Token: 0x04000BBE RID: 3006
	public GameObject TownSpringMap;

	// Token: 0x04000BBF RID: 3007
	public GameObject TownSummerMap;

	// Token: 0x04000BC0 RID: 3008
	public GameObject TownAutumnMap;

	// Token: 0x04000BC1 RID: 3009
	public GameObject TownWinterMap;

	// Token: 0x04000BC2 RID: 3010
	public GameObject RainingSystem;

	// Token: 0x04000BC3 RID: 3011
	public GameObject SnowingSystem;

	// Token: 0x04000BC4 RID: 3012
	public GameObject CloudySystem;

	// Token: 0x04000BC5 RID: 3013
	public GameObject LampPosts;

	// Token: 0x02000C1C RID: 3100
	[CompilerGenerated]
	private sealed class <SeasonChange>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060051FA RID: 20986 RVA: 0x0007991C File Offset: 0x00077D1C
		[DebuggerHidden]
		public <SeasonChange>c__Iterator0()
		{
		}

		// Token: 0x060051FB RID: 20987 RVA: 0x00079924 File Offset: 0x00077D24
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = null;
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				base.UpdateSeasonMap(currentSeason);
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x17001182 RID: 4482
		// (get) Token: 0x060051FC RID: 20988 RVA: 0x00079988 File Offset: 0x00077D88
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001183 RID: 4483
		// (get) Token: 0x060051FD RID: 20989 RVA: 0x00079990 File Offset: 0x00077D90
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060051FE RID: 20990 RVA: 0x00079998 File Offset: 0x00077D98
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x060051FF RID: 20991 RVA: 0x000799A8 File Offset: 0x00077DA8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0400400B RID: 16395
		internal Season currentSeason;

		// Token: 0x0400400C RID: 16396
		internal TownAppearanceManager $this;

		// Token: 0x0400400D RID: 16397
		internal object $current;

		// Token: 0x0400400E RID: 16398
		internal bool $disposing;

		// Token: 0x0400400F RID: 16399
		internal int $PC;
	}
}
