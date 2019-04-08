using System;
using RoR2;
using UnityEngine;

namespace SeikoML
{
    public class SurvivorModInfo
    {
        public SurvivorDef RegisterModSurvivor()
        {
            characterObject = UnityEngine.Object.Instantiate(BodyCatalog.FindBodyPrefab(bodyPrefabString));
			UnityEngine.Object.DontDestroyOnLoad(characterObject);
			characterObject.SetActive(false);
			SkillLocator skillLocator = characterObject.GetComponent<SkillLocator>();

            if (Primary != null) skillLocator.primary = Primary;
            if (Secondary!= null) skillLocator.secondary = Secondary;
            if (Utility!= null) skillLocator.utility = Utility;
            if (Special != null) skillLocator.special = Special;
            if (Passive.icon != null || Passive.skillDescriptionToken != null || Passive.skillNameToken != null || Passive.enabled) skillLocator.passiveSkill = Passive;

            if (primarySkillNameToken != null) skillLocator.primary.skillNameToken = primarySkillNameToken;
			if (secondarySkillNameToken != null) skillLocator.secondary.skillNameToken = secondarySkillNameToken;
			if (utilitySkillNameToken != null) skillLocator.utility.skillNameToken = utilitySkillNameToken;
			if (specialSkillNameToken != null) skillLocator.special.skillNameToken = specialSkillNameToken;
            if (passiveSkillNameToken != null) skillLocator.passiveSkill.skillNameToken = passiveSkillNameToken;
            if (primarySkillDescriptionToken != null) skillLocator.primary.skillDescriptionToken = primarySkillDescriptionToken;
			if (secondarySkillDescriptionToken != null) skillLocator.secondary.skillDescriptionToken = secondarySkillDescriptionToken;
			if (utilitySkillDescriptionToken != null) skillLocator.utility.skillDescriptionToken = utilitySkillDescriptionToken;
			if (specialSkillDescriptionToken != null) skillLocator.special.skillDescriptionToken = specialSkillDescriptionToken;
            if (passiveSkillNameToken != null) skillLocator.passiveSkill.skillDescriptionToken = passiveSkillDescriptionToken;
            if (passiveSkillIcon != null) skillLocator.passiveSkill.icon = passiveSkillIcon;


            if (skillLocator.passiveSkill.skillNameToken != null || skillLocator.special.skillDescriptionToken != null || skillLocator.passiveSkill.icon != null) skillLocator.passiveSkill.enabled = true;
            if (passiveSkillDisabled) skillLocator.passiveSkill.enabled = false;

            return new SurvivorDef{
                bodyPrefab = characterObject,
                displayPrefab = Resources.Load<GameObject>(portraitPrefabString),
                descriptionToken = descriptionTokenString,
                primaryColor = new Color(usedColor.r, usedColor.g, usedColor.b),
                unlockableName = unlockableNameString
            };
        }

        public string bodyPrefabString;
        public string portraitPrefabString;
        public string descriptionTokenString;
        public Color usedColor;
        public int toReplace = -1;
        public string unlockableNameString = "";
        public GameObject characterObject;

        public GenericSkill Primary = null;
        public GenericSkill Secondary = null;
        public GenericSkill Utility = null;
        public GenericSkill Special = null;
        public SkillLocator.PassiveSkill Passive = new SkillLocator.PassiveSkill();

        public bool passiveSkillDisabled = false;
        
		public string primarySkillNameToken;
		public string secondarySkillNameToken;
		public string utilitySkillNameToken;
		public string specialSkillNameToken;
		public string primarySkillDescriptionToken;
		public string secondarySkillDescriptionToken;
		public string utilitySkillDescriptionToken;
        public string specialSkillDescriptionToken;
        public string passiveSkillNameToken;
        public string passiveSkillDescriptionToken;
        public Sprite passiveSkillIcon;
	}
}
