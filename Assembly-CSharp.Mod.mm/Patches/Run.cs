using MonoMod;
using System.Collections.Generic;
using System.Linq;
using RoR2;

namespace RoR2
{
    internal class patch_Run : Run
    {
        public void BuildDropTable()
        {
			if (ItemDropManager.DefaultDrops) {
				// Setup default item lists
				DefaultItemDrops.AddDefaults();
			}

			this.availableTier1DropList.Clear();
			this.availableTier1DropList.AddRange(ItemDropManager.GetDefaultDropList(ItemTier.Tier1).Select(x => new PickupIndex(x)).ToList());

			this.availableTier2DropList.Clear();
			this.availableTier2DropList.AddRange(ItemDropManager.GetDefaultDropList(ItemTier.Tier2).Select(x => new PickupIndex(x)).ToList());

			this.availableTier3DropList.Clear();
			this.availableTier3DropList.AddRange(ItemDropManager.GetDefaultDropList(ItemTier.Tier3).Select(x => new PickupIndex(x)).ToList());

			this.availableEquipmentDropList.Clear();
			this.availableEquipmentDropList.AddRange(ItemDropManager.GetDefaultEquipmentDropList().Select(x => new PickupIndex(x)).ToList());

			this.availableLunarDropList.Clear();
			this.availableLunarDropList.AddRange(ItemDropManager.GetDefaultLunarDropList().Select(x => new PickupIndex(x)).ToList());

			this.smallChestDropTierSelector.Clear();
			this.smallChestDropTierSelector.AddChoice(this.availableTier1DropList, 0.8f);
			this.smallChestDropTierSelector.AddChoice(this.availableTier2DropList, 0.2f);
			this.smallChestDropTierSelector.AddChoice(this.availableTier3DropList, 0.01f);
			this.mediumChestDropTierSelector.Clear();
			this.mediumChestDropTierSelector.AddChoice(this.availableTier2DropList, 0.8f);
			this.mediumChestDropTierSelector.AddChoice(this.availableTier3DropList, 0.2f);
			this.largeChestDropTierSelector.Clear();
		}
    }
}
