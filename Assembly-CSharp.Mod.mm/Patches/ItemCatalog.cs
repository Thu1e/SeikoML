using System;
using System.Collections.Generic;
using System.Text;
using MonoMod;

namespace RoR2{
	class patch_ItemCatalog
	{
		// In this case since the method is marked orig_ we don't need to mark it with [MonoModIgnore]
		private static extern void orig_RegisterItem(ItemIndex itemIndex, ItemDef itemDef);
		[MonoModPublic]
		public static void RegisterItem(ItemIndex itemIndex, ItemDef itemDef)
		{
			orig_RegisterItem(itemIndex, itemDef);
		}
	}
}
