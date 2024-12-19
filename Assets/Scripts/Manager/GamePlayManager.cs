using Data;
using Interactable;
using UnityEngine;

namespace Manager
{
    public class GamePlayManager : MonoBehaviour
    {
        [SerializeField] private InteractionManager interactionManager;
        [SerializeField] private CollectiblesData collectibleData;

        private void Start()
        {
            CreateCollectible();
        }

        private void CreateCollectible()
        {
            for (int i = 0; i < 3; i++)
            {
                var collectible = collectibleData.GetCollectible((eCollectiblesType)i);
                Instantiate(collectible.CollectiblePrefab, collectible.CreationPosition, Quaternion.identity);
            }
        }
    }
}
