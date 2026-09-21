using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000353 RID: 851
public class BattleBackgroundController : MonoBehaviour
{
	// Token: 0x060016AE RID: 5806 RVA: 0x000B2660 File Offset: 0x000B0A60
	public BattleBackgroundController()
	{
	}

	// Token: 0x060016AF RID: 5807 RVA: 0x000B2674 File Offset: 0x000B0A74
	public void Init(AdventureType selectedAdventure)
	{
		this._backgrounds.ForEach(delegate(BattleBackground b)
		{
			b.gameObject.SetActive(b.AdventureType == selectedAdventure);
		});
		BattleBackground battleBackground = this._backgrounds.FirstOrDefault((BattleBackground b) => b.AdventureType == selectedAdventure);
		if (battleBackground != null)
		{
			this._selectedBackground = battleBackground;
		}
		this.ContinueMoving();
	}

	// Token: 0x060016B0 RID: 5808 RVA: 0x000B26D6 File Offset: 0x000B0AD6
	public void ContinueMoving()
	{
		this._selectedBackground.ContinueMoving();
	}

	// Token: 0x060016B1 RID: 5809 RVA: 0x000B26E3 File Offset: 0x000B0AE3
	public void StopMoving()
	{
		this._selectedBackground.StopMoving();
	}

	// Token: 0x060016B2 RID: 5810 RVA: 0x000B26F0 File Offset: 0x000B0AF0
	public float GetBackgroundMovingSpeed()
	{
		return this.GroudMovingSpeed * 400f;
	}

	// Token: 0x040016BE RID: 5822
	[SerializeField]
	private List<BattleBackground> _backgrounds;

	// Token: 0x040016BF RID: 5823
	public float GroudMovingSpeed = 0.1f;

	// Token: 0x040016C0 RID: 5824
	private BattleBackground _selectedBackground;

	// Token: 0x02000CAD RID: 3245
	[CompilerGenerated]
	private sealed class <Init>c__AnonStorey0
	{
		// Token: 0x060053F5 RID: 21493 RVA: 0x000B26FE File Offset: 0x000B0AFE
		public <Init>c__AnonStorey0()
		{
		}

		// Token: 0x060053F6 RID: 21494 RVA: 0x000B2706 File Offset: 0x000B0B06
		internal void <>m__0(BattleBackground b)
		{
			b.gameObject.SetActive(b.AdventureType == this.selectedAdventure);
		}

		// Token: 0x060053F7 RID: 21495 RVA: 0x000B2721 File Offset: 0x000B0B21
		internal bool <>m__1(BattleBackground b)
		{
			return b.AdventureType == this.selectedAdventure;
		}

		// Token: 0x04004178 RID: 16760
		internal AdventureType selectedAdventure;
	}
}
