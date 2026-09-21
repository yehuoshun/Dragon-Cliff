using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200027D RID: 637
public class LevelUpPageController : MonoBehaviour
{
	// Token: 0x060010D9 RID: 4313 RVA: 0x00098A30 File Offset: 0x00096E30
	public LevelUpPageController()
	{
	}

	// Token: 0x060010DA RID: 4314 RVA: 0x00098A38 File Offset: 0x00096E38
	public void UpdateHero(ALUTextItem item)
	{
		if (item.Adventurer != null)
		{
			this.Reset();
			AdventurerUIAnimation component = GameObjectCreator.CreateUiHero(item.Adventurer, this.HeroContainer).GetComponent<AdventurerUIAnimation>();
			UnityEngine.Object.Destroy(component.GetComponent<Button>());
			UnityEngine.Object.Destroy(component.GetComponent<AdventurerUIController>());
			component.Init(FixedAdventurerAnimation.Happy);
			return;
		}
		throw new Exception("Adventrurer is empty, please check initialization.");
	}

	// Token: 0x060010DB RID: 4315 RVA: 0x00098A9C File Offset: 0x00096E9C
	private void Reset()
	{
		IEnumerator enumerator = this.HeroContainer.GetEnumerator();
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
	}

	// Token: 0x040011E6 RID: 4582
	public Transform HeroContainer;
}
