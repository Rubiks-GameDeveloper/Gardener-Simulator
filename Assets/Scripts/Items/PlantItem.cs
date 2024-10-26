using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "PlantItem", menuName = "ItemData/PlantItem")]
    public class PlantItem : BuildItem
    {
        [SerializeField] private Season season;

        public Season GetSeason() => season;
    }

    public enum Season
    {
        Winter,
        Spring,
        Summer,
        Autumn
    }
}