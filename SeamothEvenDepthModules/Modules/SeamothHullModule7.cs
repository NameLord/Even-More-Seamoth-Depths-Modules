#if SN1
namespace EvenMoreSeamothDepth.Modules
{
    using SMLHelper.V2.Assets;
    using SMLHelper.V2.Crafting;
    using System.Collections.Generic;
    using UnityEngine;

    public class SeamothHullModule7: Equipable
    {
        public SeamothHullModule7() : base(
            classId: "SeamothHullModule7",
            friendlyName: "Seamoth depth module MK7",
            description: "Enhances diving depth to maximum. Does not stack.")
        {
        }

        public override EquipmentType EquipmentType => EquipmentType.SeamothModule;

        public override TechType RequiredForUnlock => TechType.BaseUpgradeConsole;

        public override TechGroup GroupForPDA => TechGroup.VehicleUpgrades;

        public override TechCategory CategoryForPDA => TechCategory.VehicleUpgrades;

        public override CraftTree.Type FabricatorType => CraftTree.Type.Workbench;

        public override string[] StepsToFabricatorTab => new[] { "EDM" };

        public override QuickSlotType QuickSlotType => QuickSlotType.Passive;

        public override GameObject GetGameObject()
        {
            // Get the ElectricalDefense module prefab and instantiate it
            var path = "WorldEntities/Tools/SeamothElectricalDefense";
            var prefab = Resources.Load<GameObject>(path);
            var obj = Object.Instantiate(prefab);

            // Get the TechTags and PrefabIdentifiers
            var techTag = obj.GetComponent<TechTag>();
            var prefabIdentifier = obj.GetComponent<PrefabIdentifier>();

            // Change them so they fit to our requirements.
            techTag.type = TechType;
            prefabIdentifier.ClassId = ClassID;

            return obj;
        }
        protected override TechData GetBlueprintRecipe()
        {
            return new()
            {
                Ingredients = new List<Ingredient>()
                {
                    new(Main.moduleMK6.TechType, 1),
                    new(TechType.TitaniumIngot, 3),
                    new(TechType.PlasteelIngot, 2),
                    new(TechType.Lead, 8),
                    new(TechType.Kyanite, 8),
                    new(TechType.Aerogel, 4)
                },
                craftAmount = 1
            };
        }

        protected override Atlas.Sprite GetItemSprite()
        {
            return SpriteManager.Get(TechType.VehicleHullModule3);
        }
    }
}
#endif