using System;
using TMPro;
using UnityEngine;

// Token: 0x02000139 RID: 313
public class PopupText : MonoBehaviour
{
	// Token: 0x060008B1 RID: 2225 RVA: 0x00077B76 File Offset: 0x00075F76
	public PopupText()
	{
	}

	// Token: 0x060008B2 RID: 2226 RVA: 0x00077BAC File Offset: 0x00075FAC
	private void Start()
	{
		this._speed = UnityEngine.Random.Range(-this._horizontalSpeed, this._horizontalSpeed);
		this.AnimationTime = base.GetComponent<Animator>().runtimeAnimatorController.animationClips[0].length;
		float y = UnityEngine.Random.Range(this._minVertialOffset, this._maxVertialOffset);
		base.transform.position += new Vector3(UnityEngine.Random.Range(-this._startPointOffset, this._startPointOffset), y, 0f);
		this._t = 0f;
	}

	// Token: 0x060008B3 RID: 2227 RVA: 0x00077C40 File Offset: 0x00076040
	private void Update()
	{
		this._t += Time.deltaTime;
		if (this._t <= this.AnimationTime)
		{
			base.transform.Translate(Vector3.right * Time.deltaTime * this._speed);
		}
	}

	// Token: 0x060008B4 RID: 2228 RVA: 0x00077C98 File Offset: 0x00076098
	public virtual void SetText(PopupTextElement text)
	{
		if (text.IsCriticle)
		{
			this.Text.fontSize = (float)this.CriticalTextSize;
			this.Text.text = text.Text + "<size=15>crit</size>";
		}
		else
		{
			this.Text.fontSize = (float)this.NormalTextSize;
			this.Text.text = text.Text;
		}
	}

	// Token: 0x060008B5 RID: 2229 RVA: 0x00077D05 File Offset: 0x00076105
	public virtual void SetTextOnly(string text)
	{
		this.Text.fontSize = (float)this.NormalTextSize;
		this.Text.text = string.Empty + text;
	}

	// Token: 0x04000B3A RID: 2874
	public Color NormalColor;

	// Token: 0x04000B3B RID: 2875
	public int CriticalTextSize;

	// Token: 0x04000B3C RID: 2876
	public int NormalTextSize;

	// Token: 0x04000B3D RID: 2877
	public Animator Animator;

	// Token: 0x04000B3E RID: 2878
	public TextMeshProUGUI Text;

	// Token: 0x04000B3F RID: 2879
	private float _horizontalSpeed = 10f;

	// Token: 0x04000B40 RID: 2880
	private float _startPointOffset = 30f;

	// Token: 0x04000B41 RID: 2881
	private float _minVertialOffset = 10f;

	// Token: 0x04000B42 RID: 2882
	private float _maxVertialOffset = 30f;

	// Token: 0x04000B43 RID: 2883
	private float _speed;

	// Token: 0x04000B44 RID: 2884
	private float _t;

	// Token: 0x04000B45 RID: 2885
	protected float AnimationTime;
}
