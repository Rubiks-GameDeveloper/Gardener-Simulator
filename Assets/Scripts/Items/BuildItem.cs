using UnityEngine;

namespace Items
{
    public class BuildItem : Item
    {
        [SerializeField] private GameObject worldBuildPrefab;

        public GameObject GetWorldBuildPrefab() => worldBuildPrefab;
    }
}
