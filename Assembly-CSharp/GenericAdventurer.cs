using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000323 RID: 803
public class GenericAdventurer : MonoBehaviour
{
	// Token: 0x0600155F RID: 5471 RVA: 0x000AA9BB File Offset: 0x000A8DBB
	public GenericAdventurer()
	{
	}

	// Token: 0x17000115 RID: 277
	// (get) Token: 0x06001560 RID: 5472 RVA: 0x000AA9C3 File Offset: 0x000A8DC3
	// (set) Token: 0x06001561 RID: 5473 RVA: 0x000AA9CB File Offset: 0x000A8DCB
	public AdventurerProfile Adventurer
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

	// Token: 0x06001562 RID: 5474 RVA: 0x000AA9D4 File Offset: 0x000A8DD4
	public void Init(AdventurerProfile adventurer)
	{
		this.Adventurer = adventurer;
		this.UpdateBasicSprites(FilePath.GetCharacterBasicAppearance(this.Adventurer.UnitClass, false));
		this.InitWeaponImage(adventurer.GetEquipments().FirstOrDefault((Item e) => e.SlotType == ItemType.Weapon));
	}

	// Token: 0x06001563 RID: 5475 RVA: 0x000AAA30 File Offset: 0x000A8E30
	public void Transparent()
	{
		Color32 color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 160);
		this.SetColor(color);
	}

	// Token: 0x06001564 RID: 5476 RVA: 0x000AAA60 File Offset: 0x000A8E60
	public void ResetColor()
	{
		Color32 color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
		this.SetColor(color);
	}

	// Token: 0x06001565 RID: 5477 RVA: 0x000AAA90 File Offset: 0x000A8E90
	private void SetColor(Color32 color)
	{
		this.SouthLeft.color = color;
		this.SouthMiddle.color = color;
		this.SouthRight.color = color;
		this.WestLeft.color = color;
		this.WestMiddle.color = color;
		this.WestRight.color = color;
		this.EastLeft.color = color;
		this.EastMiddle.color = color;
		this.EastRight.color = color;
		this.NorthLeft.color = color;
		this.NorthMiddle.color = color;
		this.NorthRight.color = color;
	}

	// Token: 0x06001566 RID: 5478 RVA: 0x000AAB69 File Offset: 0x000A8F69
	public void InitAppearanceBaseOnUnitClass(UnitClass UnitClass)
	{
		this.UpdateBasicSprites(FilePath.GetCharacterBasicAppearance(UnitClass, false));
	}

	// Token: 0x06001567 RID: 5479 RVA: 0x000AAB78 File Offset: 0x000A8F78
	private void InitWeaponImage(Item weapon)
	{
		if (weapon == null)
		{
			foreach (SpriteRenderer spriteRenderer in this.WeaponImages)
			{
				spriteRenderer.enabled = false;
			}
		}
		else
		{
			foreach (SpriteRenderer spriteRenderer2 in this.WeaponImages)
			{
				spriteRenderer2.enabled = true;
				spriteRenderer2.sprite = FilePath.GetRecipeImage(weapon.Type);
			}
		}
	}

	// Token: 0x06001568 RID: 5480 RVA: 0x000AABF8 File Offset: 0x000A8FF8
	private void UpdateBasicSprites(CharacterBasicAppearance appearance)
	{
		Sprite[] array = Resources.LoadAll<Sprite>(FilePath.CharacterImagePath + appearance.Path);
		this.SouthLeft.sprite = array[appearance.SouthLeft];
		this.SouthMiddle.sprite = array[appearance.SouthMiddle];
		this.SouthRight.sprite = array[appearance.SouthRight];
		this.WestLeft.sprite = array[appearance.WestLeft];
		this.WestMiddle.sprite = array[appearance.WestMiddle];
		this.WestRight.sprite = array[appearance.WestRight];
		this.EastLeft.sprite = array[appearance.EastLeft];
		this.EastMiddle.sprite = array[appearance.EastMiddle];
		this.EastRight.sprite = array[appearance.EastRight];
		this.NorthLeft.sprite = array[appearance.NorthLeft];
		this.NorthMiddle.sprite = array[appearance.NorthMiddle];
		this.NorthRight.sprite = array[appearance.NorthRight];
		AdventurerEffectColorController componentInChildren = base.GetComponentInChildren<AdventurerEffectColorController>();
		if (componentInChildren != null)
		{
			componentInChildren.GetComponent<SpriteRenderer>().sprite = array[appearance.EastMiddle];
		}
	}

	// Token: 0x06001569 RID: 5481 RVA: 0x000AAD25 File Offset: 0x000A9125
	public void SetWeapon()
	{
	}

	// Token: 0x0600156A RID: 5482 RVA: 0x000AAD27 File Offset: 0x000A9127
	[CompilerGenerated]
	private static bool <Init>m__0(Item e)
	{
		return e.SlotType == ItemType.Weapon;
	}

	// Token: 0x04001580 RID: 5504
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventurerProfile <Adventurer>k__BackingField;

	// Token: 0x04001581 RID: 5505
	public SpriteRenderer SouthLeft;

	// Token: 0x04001582 RID: 5506
	public SpriteRenderer SouthMiddle;

	// Token: 0x04001583 RID: 5507
	public SpriteRenderer SouthRight;

	// Token: 0x04001584 RID: 5508
	public SpriteRenderer WestLeft;

	// Token: 0x04001585 RID: 5509
	public SpriteRenderer WestMiddle;

	// Token: 0x04001586 RID: 5510
	public SpriteRenderer WestRight;

	// Token: 0x04001587 RID: 5511
	public SpriteRenderer EastLeft;

	// Token: 0x04001588 RID: 5512
	public SpriteRenderer EastMiddle;

	// Token: 0x04001589 RID: 5513
	public SpriteRenderer EastRight;

	// Token: 0x0400158A RID: 5514
	public SpriteRenderer NorthLeft;

	// Token: 0x0400158B RID: 5515
	public SpriteRenderer NorthMiddle;

	// Token: 0x0400158C RID: 5516
	public SpriteRenderer NorthRight;

	// Token: 0x0400158D RID: 5517
	public SpriteRenderer[] WeaponImages;

	// Token: 0x0400158E RID: 5518
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache0;
}
