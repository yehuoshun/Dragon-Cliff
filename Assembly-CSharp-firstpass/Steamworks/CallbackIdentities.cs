using System;

namespace Steamworks
{
	// Token: 0x02000039 RID: 57
	internal class CallbackIdentities
	{
		// Token: 0x06000332 RID: 818 RVA: 0x0000F9E3 File Offset: 0x0000DDE3
		public CallbackIdentities()
		{
		}

		// Token: 0x06000333 RID: 819 RVA: 0x0000F9EC File Offset: 0x0000DDEC
		public static int GetCallbackIdentity(Type callbackStruct)
		{
			object[] customAttributes = callbackStruct.GetCustomAttributes(typeof(CallbackIdentityAttribute), false);
			int num = 0;
			if (num >= customAttributes.Length)
			{
				throw new Exception("Callback number not found for struct " + callbackStruct);
			}
			CallbackIdentityAttribute callbackIdentityAttribute = (CallbackIdentityAttribute)customAttributes[num];
			return callbackIdentityAttribute.Identity;
		}
	}
}
