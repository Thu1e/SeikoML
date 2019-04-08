using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityStates;
using EntityStates.Barrel;
using MonoMod;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace RoR2 {
	internal class patch_ChestBehavior : ChestBehavior
	{
		private PickupIndex dropPickup;

		[MonoModPublic]
		public void RollItem() {
			if (!NetworkServer.active) {
				Debug.LogWarning("[Server] function 'System.Void RoR2.ChestBehavior::RollItem()' called on client");
				return;
			}

			Debug.Log("T1: " + this.tier1Chance);
			Debug.Log("T2: " + this.tier2Chance);
			Debug.Log("T3: " + this.tier3Chance);
			Debug.Log("Lun: " + this.lunarChance);

			if (lunarChance >= 1f)
			{
				this.dropPickup = ItemDropManager.GetSelection(ItemDropLocation.LunarChest,
					Run.instance.treasureRng.nextNormalizedFloat);
			}
			else if (tier3Chance >= 0.2f)
			{
				this.dropPickup = ItemDropManager.GetSelection(ItemDropLocation.LargeChest,
					Run.instance.treasureRng.nextNormalizedFloat);
			}
			else if (tier2Chance >= 0.8f)
			{
				this.dropPickup = ItemDropManager.GetSelection(ItemDropLocation.MediumChest,
					Run.instance.treasureRng.nextNormalizedFloat);
			}
			else if (tier1Chance <= 0.8f)
			{
				this.dropPickup = ItemDropManager.GetSelection(ItemDropLocation.SmallChest,
					Run.instance.treasureRng.nextNormalizedFloat);
			}
		}

		[MonoModPublic]
		public void RollEquipment() {
			if (!NetworkServer.active) {
				Debug.LogWarning("[Server] function 'System.Void RoR2.ChestBehavior::RollEquipment()' called on client");
				return;
			}
			
			this.dropPickup = ItemDropManager.GetSelection(ItemDropLocation.EquipmentChest,
				Run.instance.treasureRng.nextNormalizedFloat);
		}
	}
}
