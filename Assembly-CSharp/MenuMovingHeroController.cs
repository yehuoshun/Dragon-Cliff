using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000241 RID: 577
public class MenuMovingHeroController : MonoBehaviour
{
	// Token: 0x06000EFD RID: 3837 RVA: 0x00092B38 File Offset: 0x00090F38
	public MenuMovingHeroController()
	{
	}

	// Token: 0x06000EFE RID: 3838 RVA: 0x00092B4C File Offset: 0x00090F4C
	public void Init(AdventurerProfile hero)
	{
		this.UpdateSprites(FilePath.GetCharacterBasicAppearance(hero.UnitClass, false));
		if (UnityEngine.Random.Range(0, 2) == 0)
		{
			this.RectTran.position = this.LeftPoint.position;
			this._reachLeftPoint = true;
			this._reachRightPoint = false;
		}
		else
		{
			this.RectTran.position = this.RightPoint.position;
			this._reachLeftPoint = false;
			this._reachRightPoint = true;
		}
	}

	// Token: 0x06000EFF RID: 3839 RVA: 0x00092BC6 File Offset: 0x00090FC6
	private void OnEnable()
	{
		this._eachActionWaitingTime = UnityEngine.Random.Range(this.EachActionWaitingTimeMin, this.EachActionWaitingTimeMax);
	}

	// Token: 0x06000F00 RID: 3840 RVA: 0x00092BDF File Offset: 0x00090FDF
	private void Start()
	{
		this.Animator.SetFloat("xLastMove", 0f);
		this.Animator.SetFloat("yLastMove", -1f);
		this.Animator.SetBool("isWalking", false);
	}

	// Token: 0x06000F01 RID: 3841 RVA: 0x00092C1C File Offset: 0x0009101C
	private Vector3 GetPosition(float xPosition)
	{
		return new Vector3(xPosition, this.RectTran.position.y, this.RectTran.position.z);
	}

	// Token: 0x06000F02 RID: 3842 RVA: 0x00092C58 File Offset: 0x00091058
	protected void UpdateSprites(CharacterBasicAppearance appearance)
	{
		Sprite[] array = Resources.LoadAll<Sprite>(FilePath.CharacterImagePath + appearance.Path);
		if (array.Length == 0)
		{
			throw new Exception(FilePath.CharacterImagePath + appearance.Path + " not exist, please check.");
		}
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
	}

	// Token: 0x06000F03 RID: 3843 RVA: 0x00092D84 File Offset: 0x00091184
	private void Update()
	{
		this._actionTimer += Time.deltaTime;
		if (this._reachLeftPoint && this._actionTimer > this._eachActionWaitingTime)
		{
			int num = UnityEngine.Random.Range(0, 2);
			if (num != 0)
			{
				if (num == 1)
				{
					this.WalkRight();
				}
			}
			else
			{
				this.AnimateIdle();
			}
			this._actionTimer = 0f;
		}
		if (this._reachRightPoint && this._actionTimer > this._eachActionWaitingTime)
		{
			int num2 = UnityEngine.Random.Range(0, 2);
			if (num2 != 0)
			{
				if (num2 == 1)
				{
					this.WalkLeft();
				}
			}
			else
			{
				this.AnimateIdle();
			}
			this._actionTimer = 0f;
		}
		if (!this._reachLeftPoint && !this._reachRightPoint)
		{
			if (this._walkLeft)
			{
				Vector3 normalized = (this.LeftPoint.position - base.transform.position).normalized;
				this.AnimateMove(normalized.x, normalized.y);
				if (Vector3.Distance(this.LeftPoint.position, base.transform.position) < 5f)
				{
					this._reachLeftPoint = true;
					this.Animator.SetBool("isWalking", false);
				}
			}
			else if (this._walkRight)
			{
				Vector3 normalized2 = (this.RightPoint.position - base.transform.position).normalized;
				this.AnimateMove(normalized2.x, normalized2.y);
				if (Vector3.Distance(this.RightPoint.position, base.transform.position) < 5f)
				{
					this._reachRightPoint = true;
					this.Animator.SetBool("isWalking", false);
				}
			}
		}
	}

	// Token: 0x06000F04 RID: 3844 RVA: 0x00092F6E File Offset: 0x0009136E
	private void WalkLeft()
	{
		this._walkLeft = true;
		this._walkRight = false;
		this._reachLeftPoint = false;
		this._reachRightPoint = false;
	}

	// Token: 0x06000F05 RID: 3845 RVA: 0x00092F8C File Offset: 0x0009138C
	private void WalkRight()
	{
		this._walkRight = true;
		this._walkLeft = false;
		this._reachRightPoint = false;
		this._reachLeftPoint = false;
	}

	// Token: 0x06000F06 RID: 3846 RVA: 0x00092FAC File Offset: 0x000913AC
	protected void AnimateIdle()
	{
		Vector2 vector = new Vector2((float)UnityEngine.Random.Range(-1, 2), (float)UnityEngine.Random.Range(-1, 2));
		if (vector.x == 0f && vector.y == 0f)
		{
			vector.y = -1f;
		}
		if (Math.Abs(vector.y) == Math.Abs(vector.x) && vector.y != 0f)
		{
			vector.x = 0f;
		}
		this.Animator.SetFloat("xLastMove", vector.x);
		this.Animator.SetFloat("yLastMove", vector.y);
		this.Animator.SetBool("isWalking", false);
	}

	// Token: 0x06000F07 RID: 3847 RVA: 0x00093078 File Offset: 0x00091478
	protected void AnimateMove(float xInput, float yInput)
	{
		Vector2 vector = default(Vector2);
		Vector3 a = new Vector3(xInput, yInput, 0f);
		base.transform.position += a * this.WalkingSpeed * Time.deltaTime;
		if (xInput > 0.5f || xInput < -0.5f)
		{
			vector = new Vector2(xInput, 0f);
		}
		if (yInput > 0.5f || yInput < -0.5f)
		{
			vector = new Vector2(0f, yInput);
		}
		if (xInput > 0.5f)
		{
			xInput = 1f;
			yInput = 0f;
		}
		if (xInput < -0.5f)
		{
			xInput = -1f;
			yInput = 0f;
		}
		if (yInput > 0.5f)
		{
			yInput = 1f;
			xInput = 0f;
		}
		if (yInput < -0.5f)
		{
			yInput = -1f;
			xInput = 0f;
		}
		this.Animator.SetFloat("xInput", xInput);
		this.Animator.SetFloat("yInput", yInput);
		this.Animator.SetFloat("xLastMove", vector.x);
		this.Animator.SetFloat("yLastMove", vector.y);
		this.Animator.SetBool("isWalking", true);
	}

	// Token: 0x04001062 RID: 4194
	public RectTransform LeftPoint;

	// Token: 0x04001063 RID: 4195
	public RectTransform RightPoint;

	// Token: 0x04001064 RID: 4196
	public Animator Animator;

	// Token: 0x04001065 RID: 4197
	public RectTransform RectTran;

	// Token: 0x04001066 RID: 4198
	public float WalkingSpeed;

	// Token: 0x04001067 RID: 4199
	public float EachActionWaitingTimeMin;

	// Token: 0x04001068 RID: 4200
	public float EachActionWaitingTimeMax;

	// Token: 0x04001069 RID: 4201
	public Image SouthLeft;

	// Token: 0x0400106A RID: 4202
	public Image SouthMiddle;

	// Token: 0x0400106B RID: 4203
	public Image SouthRight;

	// Token: 0x0400106C RID: 4204
	public Image WestLeft;

	// Token: 0x0400106D RID: 4205
	public Image WestMiddle;

	// Token: 0x0400106E RID: 4206
	public Image WestRight;

	// Token: 0x0400106F RID: 4207
	public Image EastLeft;

	// Token: 0x04001070 RID: 4208
	public Image EastMiddle;

	// Token: 0x04001071 RID: 4209
	public Image EastRight;

	// Token: 0x04001072 RID: 4210
	public Image NorthLeft;

	// Token: 0x04001073 RID: 4211
	public Image NorthMiddle;

	// Token: 0x04001074 RID: 4212
	public Image NorthRight;

	// Token: 0x04001075 RID: 4213
	private bool _reachLeftPoint;

	// Token: 0x04001076 RID: 4214
	private bool _reachRightPoint;

	// Token: 0x04001077 RID: 4215
	private bool _walkLeft;

	// Token: 0x04001078 RID: 4216
	private bool _walkRight;

	// Token: 0x04001079 RID: 4217
	private float _actionTimer;

	// Token: 0x0400107A RID: 4218
	private float _eachActionWaitingTime = 2.5f;
}
