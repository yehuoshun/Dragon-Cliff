using System;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.Town.ObjectPool;
using TMPro;
using UnityEngine;

// Token: 0x020001DA RID: 474
public class TalentPointPanelController : MonoBehaviour
{
	// Token: 0x06000CBC RID: 3260 RVA: 0x0008B259 File Offset: 0x00089659
	public TalentPointPanelController()
	{
	}

	// Token: 0x06000CBD RID: 3261 RVA: 0x0008B264 File Offset: 0x00089664
	public void Init(AdventurerProfile selectedAdventurer)
	{
		this.ClearAllTrans();
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		IOrderedEnumerable<IAdventurerTalent> orderedEnumerable = from t in selectedAdventurer.Talents
		orderby t.GetCorrespondingType()
		select t;
		foreach (IAdventurerTalent adventurerTalent in orderedEnumerable)
		{
			switch (adventurerTalent.GetTier())
			{
			case AdventurerTalentTier.First:
			{
				TalentAttributeController component = this.PoolObject(PoolType.TalentAttributeItem, default(Vector3)).GetComponent<TalentAttributeController>();
				component.Init(adventurerTalent, selectedAdventurer);
				component.transform.SetParent(this.TierOneTrans, false);
				num += adventurerTalent.GetCurrentLevel();
				break;
			}
			case AdventurerTalentTier.Second:
			{
				TalentSkillController component2 = this.PoolObject(PoolType.TalentSkillItem, default(Vector3)).GetComponent<TalentSkillController>();
				component2.Init(adventurerTalent, selectedAdventurer);
				component2.transform.SetParent(this.TierTwoTrans, false);
				num2 += adventurerTalent.GetCurrentLevel();
				break;
			}
			case AdventurerTalentTier.Third:
			{
				TalentAttributeController component3 = this.PoolObject(PoolType.TalentAttributeItem, default(Vector3)).GetComponent<TalentAttributeController>();
				component3.Init(adventurerTalent, selectedAdventurer);
				component3.transform.SetParent(this.TierThreeTrans, false);
				num3 += adventurerTalent.GetCurrentLevel();
				break;
			}
			case AdventurerTalentTier.Forth:
			{
				TalentSkillController component4 = this.PoolObject(PoolType.TalentSkillItem, default(Vector3)).GetComponent<TalentSkillController>();
				component4.Init(adventurerTalent, selectedAdventurer);
				component4.transform.SetParent(this.TierForthTrans, false);
				num4 += adventurerTalent.GetCurrentLevel();
				break;
			}
			}
		}
		this.TierOnePointsText.text = ColorPicker.GetHaxString(ColorPicker.Yellow, " " + num + "/10");
		this.TierTwoPointsText.text = ColorPicker.GetHaxString(ColorPicker.Yellow, " " + num2 + "/1");
		this.TierThreePointsText.text = ColorPicker.GetHaxString(ColorPicker.Yellow, " " + num3 + "/5");
		this.TierForthPointsText.text = ColorPicker.GetHaxString(ColorPicker.Yellow, " " + num4 + "/1");
		this.TalentPointLastText.text = UIComponentType.TalentPointLastTitle.GetName() + ": <b>" + ColorPicker.GetHaxString(ColorPicker.Yellow, selectedAdventurer.TalentPoints.ToString()) + "</b>";
	}

	// Token: 0x06000CBE RID: 3262 RVA: 0x0008B520 File Offset: 0x00089920
	private void ClearAllTrans()
	{
		IEnumerator enumerator = this.TierOneTrans.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				transform.gameObject.PoolDestroy(PoolType.TalentAttributeItem);
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
		IEnumerator enumerator2 = this.TierTwoTrans.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				object obj2 = enumerator2.Current;
				Transform transform2 = (Transform)obj2;
				transform2.gameObject.PoolDestroy(PoolType.TalentSkillItem);
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
		IEnumerator enumerator3 = this.TierThreeTrans.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				object obj3 = enumerator3.Current;
				Transform transform3 = (Transform)obj3;
				transform3.gameObject.PoolDestroy(PoolType.TalentAttributeItem);
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
		IEnumerator enumerator4 = this.TierForthTrans.GetEnumerator();
		try
		{
			while (enumerator4.MoveNext())
			{
				object obj4 = enumerator4.Current;
				Transform transform4 = (Transform)obj4;
				transform4.gameObject.PoolDestroy(PoolType.TalentSkillItem);
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
	}

	// Token: 0x06000CBF RID: 3263 RVA: 0x0008B6B0 File Offset: 0x00089AB0
	[CompilerGenerated]
	private static AdventurerTalentType <Init>m__0(IAdventurerTalent t)
	{
		return t.GetCorrespondingType();
	}

	// Token: 0x04000ED4 RID: 3796
	public Transform TierOneTrans;

	// Token: 0x04000ED5 RID: 3797
	public Transform TierTwoTrans;

	// Token: 0x04000ED6 RID: 3798
	public Transform TierThreeTrans;

	// Token: 0x04000ED7 RID: 3799
	public Transform TierForthTrans;

	// Token: 0x04000ED8 RID: 3800
	public TextMeshProUGUI TierOnePointsText;

	// Token: 0x04000ED9 RID: 3801
	public TextMeshProUGUI TierTwoPointsText;

	// Token: 0x04000EDA RID: 3802
	public TextMeshProUGUI TierThreePointsText;

	// Token: 0x04000EDB RID: 3803
	public TextMeshProUGUI TierForthPointsText;

	// Token: 0x04000EDC RID: 3804
	public TextMeshProUGUI TalentPointLastText;

	// Token: 0x04000EDD RID: 3805
	public TalentAttributeController AttributeItemPre;

	// Token: 0x04000EDE RID: 3806
	public TalentSkillController SkillItemPre;

	// Token: 0x04000EDF RID: 3807
	[CompilerGenerated]
	private static Func<IAdventurerTalent, AdventurerTalentType> <>f__am$cache0;
}
