using System;
using System.Linq;
using UnityEngine;

namespace Data
{
    public enum eCollectiblesType
    {
        Door,
        Chest,
        PickupItem1
    }
    
    [Serializable]
    public class CollectibleData
    {
        public eCollectiblesType eCollectible;
        public Vector3 CreationPosition;
        public GameObject CollectiblePrefab;
    }
    [CreateAssetMenu(fileName = "CollectiblesData", menuName = "CollectiblesData/Create")]
    public class CollectiblesData : ScriptableObject
    {
        [SerializeField] private CollectibleData[] CollectibleDatas;

        public CollectibleData GetCollectible(eCollectiblesType type)
        {
            return CollectibleDatas.FirstOrDefault(i => i.eCollectible == type);
        }
    }
}

