using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000151 RID: 337
public class BattleLogAdventurerItemController : MonoBehaviour
{
	// Token: 0x06000922 RID: 2338 RVA: 0x00079BF1 File Offset: 0x00077FF1
	public BattleLogAdventurerItemController()
	{
	}

	// Token: 0x17000038 RID: 56
	// (get) Token: 0x06000923 RID: 2339 RVA: 0x00079BF9 File Offset: 0x00077FF9
	// (set) Token: 0x06000924 RID: 2340 RVA: 0x00079C01 File Offset: 0x00078001
	public AdventurerBattleUnit Adventurer
	{
		[CompilerGenerated]
		get
		{
			return this.<Adventurer>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Adventurer>k__BackingField = value;
		}
	}

	// Token: 0x06000925 RID: 2341 RVA: 0x00079C0C File Offset: 0x0007800C
	public void Init(AdventurerBattleUnit adventurer, double damageAmount)
	{
		this.Adventurer = adventurer;
		this.GradeImage.sprite = FilePath.GetAdventurerGradeBackground(adventurer.Grade, adventurer.AdventurerProfile.IsStar());
		this.AdventurerImage.sprite = FilePath.GetAdventuererAvatarSprite(adventurer.GetUnitType());
		this.AmountText.text = damageAmount.DoubleToShortNumber();
		this.NameText.text = adventurer.AdventurerProfile.GetUnitName();
		this.CurrentAmount = damageAmount;
	}

	// Token: 0x06000926 RID: 2342 RVA: 0x00079C85 File Offset: 0x00078085
	public void UpdateAmount(double damageAmount)
	{
		this.AmountText.text = damageAmount.DoubleToShortNumber();
		this.CurrentAmount = damageAmount;
	}

	// Token: 0x04000BD2 RID: 3026
	public Image GradeImage;

	// Token: 0x04000BD3 RID: 3027
	public Image AdventurerImage;

	// Token: 0x04000BD4 RID: 3028
	public TextMeshProUGUI NameText;

	// Token: 0x04000BD5 RID: 3029
	public TextMeshProUGUI AmountText;

	// Token: 0x04000BD6 RID: 3030
	public double CurrentAmount;

	// Token: 0x04000BD7 RID: 3031
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventurerBattleUnit <Adventurer>k__BackingField;
}
