using System;
using System.Collections.Generic;
using System.Text;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace Assembly_CSharp.Mod.mm.Patches
{
	class patch_SceneDirector : SceneDirector
	{
		// Token: 0x04001863 RID: 6243
		private Xoroshiro128Plus rng;


		private void Start()
		{
			if (NetworkServer.active)
			{
				this.rng = new Xoroshiro128Plus((ulong)Run.instance.stageRng.nextUint);
				float num = 0.5f + (float)Run.instance.participatingPlayerCount * 0.5f;
				ClassicStageInfo component = SceneInfo.instance.GetComponent<ClassicStageInfo>();
				if (component)
				{
					this.interactableCredit = (int)(component.sceneDirectorInteractibleCredits * num * ItemDropManager.ChestSpawnRate);
					Debug.LogFormat("Spending {0} credits on interactables...", new object[]
					{
						this.interactableCredit
					});
					this.monsterCredit = (int)((float)component.sceneDirectorMonsterCredits * Run.instance.difficultyCoefficient);
				}
				this.PopulateScene();
			}
		}
	}
}
