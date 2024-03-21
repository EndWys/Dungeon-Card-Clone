using UnityEngine;

namespace Assets.GameCore.Utilities.Objects
{
    public class CachedMonoBehaviour : MonoBehaviour
    {
        private Transform _cachedTransform;
        private GameObject _cachedGameObject;

        public Transform CachedTransform
        {
            get
            {
                if (!_cachedTransform)
                {
                    _cachedTransform = transform;
                }
                return _cachedTransform;
            }
        }

        public GameObject CachedGameObject
        {
            get
            {
                if (!_cachedGameObject)
                {
                    _cachedGameObject = gameObject;
                }
                return _cachedGameObject;
            }
        }
    }
}