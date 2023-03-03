using UnityEngine;

namespace scriptable
{
    [CreateAssetMenu(fileName = "Data", menuName = "Custom/CameraSettings", order = 1)]
    public class CameraSettings : ScriptableObject
    {
        public float MinimalDistance = 1;
        public float MaximalDistance = 2;
        public float Speed = 1;
        public Vector3 Offset = new Vector3(1, 1, 1);
    }

}