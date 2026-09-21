using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000D35 RID: 3381
[CompilerGenerated]
internal sealed class <>__AnonType0<<slot>__T, <building>__T>
{
	// Token: 0x0600567C RID: 22140 RVA: 0x00002050 File Offset: 0x00000450
	[DebuggerHidden]
	public <>__AnonType0(<slot>__T slot, <building>__T building)
	{
		this.<slot> = slot;
		this.<building> = building;
	}

	// Token: 0x1700123E RID: 4670
	// (get) Token: 0x0600567D RID: 22141 RVA: 0x00002066 File Offset: 0x00000466
	public <slot>__T slot
	{
		get
		{
			return this.<slot>;
		}
	}

	// Token: 0x1700123F RID: 4671
	// (get) Token: 0x0600567E RID: 22142 RVA: 0x0000206E File Offset: 0x0000046E
	public <building>__T building
	{
		get
		{
			return this.<building>;
		}
	}

	// Token: 0x0600567F RID: 22143 RVA: 0x00002078 File Offset: 0x00000478
	[DebuggerHidden]
	public override bool Equals(object obj)
	{
		var <>__AnonType = obj as <>__AnonType0<<slot>__T, <building>__T>;
		return <>__AnonType != null && EqualityComparer<<slot>__T>.Default.Equals(this.<slot>, <>__AnonType.<slot>) && EqualityComparer<<building>__T>.Default.Equals(this.<building>, <>__AnonType.<building>);
	}

	// Token: 0x06005680 RID: 22144 RVA: 0x000020CC File Offset: 0x000004CC
	[DebuggerHidden]
	public override int GetHashCode()
	{
		int num = ((-2128831035 ^ EqualityComparer<<slot>__T>.Default.GetHashCode(this.<slot>)) * 16777619 ^ EqualityComparer<<building>__T>.Default.GetHashCode(this.<building>)) * 16777619;
		num += num << 13;
		num ^= num >> 7;
		num += num << 3;
		num ^= num >> 17;
		return num + (num << 5);
	}

	// Token: 0x06005681 RID: 22145 RVA: 0x00002130 File Offset: 0x00000530
	[DebuggerHidden]
	public override string ToString()
	{
		string[] array = new string[6];
		array[0] = "{";
		array[1] = " slot = ";
		int num = 2;
		string text;
		if (this.<slot> != null)
		{
			<slot>__T <slot>__T = this.<slot>;
			text = <slot>__T.ToString();
		}
		else
		{
			text = string.Empty;
		}
		array[num] = text;
		array[3] = ", building = ";
		int num2 = 4;
		string text2;
		if (this.<building> != null)
		{
			<building>__T <building>__T = this.<building>;
			text2 = <building>__T.ToString();
		}
		else
		{
			text2 = string.Empty;
		}
		array[num2] = text2;
		array[5] = " }";
		return string.Concat(array);
	}

	// Token: 0x04004509 RID: 17673
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly <slot>__T <slot>;

	// Token: 0x0400450A RID: 17674
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly <building>__T <building>;
}
