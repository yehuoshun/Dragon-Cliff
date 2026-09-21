using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000EF4 RID: 3828
[CompilerGenerated]
internal sealed class <>__AnonType5<<buff>__T, <value>__T>
{
	// Token: 0x06006094 RID: 24724 RVA: 0x000027AA File Offset: 0x00000BAA
	[DebuggerHidden]
	public <>__AnonType5(<buff>__T buff, <value>__T value)
	{
		this.<buff> = buff;
		this.<value> = value;
	}

	// Token: 0x17001434 RID: 5172
	// (get) Token: 0x06006095 RID: 24725 RVA: 0x000027C0 File Offset: 0x00000BC0
	public <buff>__T buff
	{
		get
		{
			return this.<buff>;
		}
	}

	// Token: 0x17001435 RID: 5173
	// (get) Token: 0x06006096 RID: 24726 RVA: 0x000027C8 File Offset: 0x00000BC8
	public <value>__T value
	{
		get
		{
			return this.<value>;
		}
	}

	// Token: 0x06006097 RID: 24727 RVA: 0x000027D0 File Offset: 0x00000BD0
	[DebuggerHidden]
	public override bool Equals(object obj)
	{
		var <>__AnonType = obj as <>__AnonType5<<buff>__T, <value>__T>;
		return <>__AnonType != null && EqualityComparer<<buff>__T>.Default.Equals(this.<buff>, <>__AnonType.<buff>) && EqualityComparer<<value>__T>.Default.Equals(this.<value>, <>__AnonType.<value>);
	}

	// Token: 0x06006098 RID: 24728 RVA: 0x00002824 File Offset: 0x00000C24
	[DebuggerHidden]
	public override int GetHashCode()
	{
		int num = ((-2128831035 ^ EqualityComparer<<buff>__T>.Default.GetHashCode(this.<buff>)) * 16777619 ^ EqualityComparer<<value>__T>.Default.GetHashCode(this.<value>)) * 16777619;
		num += num << 13;
		num ^= num >> 7;
		num += num << 3;
		num ^= num >> 17;
		return num + (num << 5);
	}

	// Token: 0x06006099 RID: 24729 RVA: 0x00002888 File Offset: 0x00000C88
	[DebuggerHidden]
	public override string ToString()
	{
		string[] array = new string[6];
		array[0] = "{";
		array[1] = " buff = ";
		int num = 2;
		string text;
		if (this.<buff> != null)
		{
			<buff>__T <buff>__T = this.<buff>;
			text = <buff>__T.ToString();
		}
		else
		{
			text = string.Empty;
		}
		array[num] = text;
		array[3] = ", value = ";
		int num2 = 4;
		string text2;
		if (this.<value> != null)
		{
			<value>__T <value>__T = this.<value>;
			text2 = <value>__T.ToString();
		}
		else
		{
			text2 = string.Empty;
		}
		array[num2] = text2;
		array[5] = " }";
		return string.Concat(array);
	}

	// Token: 0x040055E2 RID: 21986
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly <buff>__T <buff>;

	// Token: 0x040055E3 RID: 21987
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly <value>__T <value>;
}
