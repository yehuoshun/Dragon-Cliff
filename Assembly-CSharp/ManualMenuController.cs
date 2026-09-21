using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200020A RID: 522
public class ManualMenuController : MonoBehaviour
{
	// Token: 0x06000DD4 RID: 3540 RVA: 0x0008FF1D File Offset: 0x0008E31D
	public ManualMenuController()
	{
	}

	// Token: 0x06000DD5 RID: 3541 RVA: 0x0008FF30 File Offset: 0x0008E330
	private void Start()
	{
		this._allQuestions.Clear();
		IEnumerator enumerator = this.QuestionContainer.GetEnumerator();
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
		IEnumerator enumerator2 = Enum.GetValues(typeof(ManualType)).GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				object obj2 = enumerator2.Current;
				ManualQuestionItemController manualQuestionItemController = UnityEngine.Object.Instantiate<ManualQuestionItemController>(this.QuestionItemPre);
				manualQuestionItemController.Init((ManualType)obj2);
				manualQuestionItemController.transform.SetParent(this.QuestionContainer, false);
				this._allQuestions.Add(manualQuestionItemController);
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

	// Token: 0x06000DD6 RID: 3542 RVA: 0x00090038 File Offset: 0x0008E438
	public void SelectQuestion(ManualType selectedType)
	{
		foreach (ManualQuestionItemController manualQuestionItemController in this._allQuestions)
		{
			manualQuestionItemController.Select(selectedType);
		}
		this.AnswerPanel.Init(selectedType);
	}

	// Token: 0x04000FC4 RID: 4036
	public Transform QuestionContainer;

	// Token: 0x04000FC5 RID: 4037
	public ManualQuestionItemController QuestionItemPre;

	// Token: 0x04000FC6 RID: 4038
	public ManualAnswerPanelController AnswerPanel;

	// Token: 0x04000FC7 RID: 4039
	private List<ManualQuestionItemController> _allQuestions = new List<ManualQuestionItemController>();
}
