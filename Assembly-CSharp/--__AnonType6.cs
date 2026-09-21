using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000F12 RID: 3858
[CompilerGenerated]
internal sealed class <>__AnonType6<<value>__T>
{
	// Token: 0x06006178 RID: 24952 RVA: 0x00002A9A File Offset: 0x00000E9A
	[DebuggerHidden]
	public <>__AnonType6(<value>__T value)
	{
		this.<value> = value;
	}

	// Token: 0x1700146A RID: 5226
	// (get) Token: 0x06006179 RID: 24953 RVA: 0x00002AA9 File Offset: 0x00000EA9
	public <value>__T value
	{
		get
		{
			return this.<value>;
		}
	}

	// Token: 0x0600617A RID: 24954 RVA: 0x00002AB4 File Offset: 0x00000EB4
	[DebuggerHidden]
	public override bool Equals(object obj)
	{
		var <>__AnonType = obj as <>__AnonType6<<value>__T>;
		return <>__AnonType != null && EqualityComparer<<value>__T>.Default.Equals(this.<value>, <>__AnonType.<value>);
	}

	// Token: 0x0600617B RID: 24955 RVA: 0x00002AE8 File Offset: 0x00000EE8
	[DebuggerHidden]
	public override int GetHashCode()
	{
		int num = (-2128831035 ^ EqualityComparer<<value>__T>.Default.GetHashCode(this.<value>)) * 16777619;
		num += num << 13;
		num ^= num >> 7;
		num += num << 3;
		num ^= num >> 17;
		return num + (num << 5);
	}

	// Token: 0x0600617C RID: 24956 RVA: 0x00002B34 File Offset: 0x00000F34
	[DebuggerHidden]
	public override string ToString()
	{
		string str = "{";
		string str2 = " value = ";
		string str3;
		if (this.<value> != null)
		{
			<value>__T <value>__T = this.<value>;
			str3 = <value>__T.ToString();
		}
		else
		{
			str3 = string.Empty;
		}
		return str + str2 + str3 + " }";
	}

	// Token: 0x04005728 RID: 22312
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly <value>__T <value>;
}
