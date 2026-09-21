using System;
using System.Collections;
using TMPro;
using UnityEngine;

// Token: 0x020001BD RID: 445
public class HeroLogController : MonoBehaviour
{
	// Token: 0x06000B9E RID: 2974 RVA: 0x00087174 File Offset: 0x00085574
	public HeroLogController()
	{
	}

	// Token: 0x06000B9F RID: 2975 RVA: 0x0008717C File Offset: 0x0008557C
	private void OnEnable()
	{
		this.Init();
	}

	// Token: 0x06000BA0 RID: 2976 RVA: 0x00087184 File Offset: 0x00085584
	public void Init()
	{
		IEnumerator enumerator = this.Container.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				UnityEngine.Object.Destroy(transform.gameObject);
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
		int num = 0;
		int num2 = 0;
		IEnumerator enumerator2 = Enum.GetValues(typeof(UnitClass)).GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				object obj2 = enumerator2.Current;
				int num3 = (int)obj2;
				if ((num3 >= 1 && num3 <= 6) || (num3 >= 1001 && num3 <= 3000 && num3 != 1005))
				{
					num2++;
					bool flag = GameWorld.instance.PlayerProfile.AdventurerTypeObtained((UnitClass)num3);
					if (flag)
					{
						num++;
					}
					HeroLogItemController heroLogItemController = UnityEngine.Object.Instantiate<HeroLogItemController>(this.HeroItemPre);
					heroLogItemController.Init((UnitClass)num3, flag);
					heroLogItemController.transform.SetParent(this.Container, false);
				}
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
		this.Title.text = string.Concat(new object[]
		{
			UIComponentType.HeroMenuAdventurerLogTitle.GetName(),
			" (",
			num,
			"/",
			num2,
			")"
		});
	}

	// Token: 0x04000E16 RID: 3606
	public TextMeshProUGUI Title;

	// Token: 0x04000E17 RID: 3607
	public Transform Container;

	// Token: 0x04000E18 RID: 3608
	public HeroLogItemController HeroItemPre;
}
