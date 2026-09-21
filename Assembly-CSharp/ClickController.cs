using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000134 RID: 308
[Serializable]
public class ClickController : MonoBehaviour
{
	// Token: 0x060008A2 RID: 2210 RVA: 0x00077A89 File Offset: 0x00075E89
	public ClickController()
	{
	}

	// Token: 0x060008A3 RID: 2211 RVA: 0x00077A9C File Offset: 0x00075E9C
	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mousePosition = Input.mousePosition;
			Vector3 targetPos = Camera.main.ScreenToWorldPoint(mousePosition);
			targetPos.z = 0f;
			this.ShowTargetEffectObject(this.effects[this.index], targetPos);
			this.index++;
			if (this.index >= this.effects.Count)
			{
				this.index = 0;
			}
		}
	}

	// Token: 0x060008A4 RID: 2212 RVA: 0x00077B18 File Offset: 0x00075F18
	public void ShowTargetEffectObject(GameObject gameObject, Vector3 targetPos)
	{
		if (gameObject)
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(gameObject, targetPos, Quaternion.identity);
			if ((float)(Screen.width / 2) - targetPos.x >= 0f)
			{
				gameObject2.transform.localScale = new Vector3(-1f, 1f, 1f);
			}
		}
	}

	// Token: 0x04000B33 RID: 2867
	public List<GameObject> effects = new List<GameObject>();

	// Token: 0x04000B34 RID: 2868
	public int index;
}
