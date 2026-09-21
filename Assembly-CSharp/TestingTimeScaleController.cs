using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000294 RID: 660
public class TestingTimeScaleController : MonoBehaviour
{
	// Token: 0x0600119F RID: 4511 RVA: 0x0009BD8D File Offset: 0x0009A18D
	public TestingTimeScaleController()
	{
	}

	// Token: 0x060011A0 RID: 4512 RVA: 0x0009BD98 File Offset: 0x0009A198
	public void UpdateTimeScale()
	{
		int num;
		bool flag = int.TryParse(this.Input.text, out num);
		if (flag)
		{
			Time.timeScale = (float)num;
		}
		else
		{
			Time.timeScale = 0f;
		}
	}

	// Token: 0x04001271 RID: 4721
	public InputField Input;
}
