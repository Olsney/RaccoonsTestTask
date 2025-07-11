using UnityEngine;

namespace Code.Services.CubePools
{
    public interface ICubePool
    {
        GameObject Get(Vector3 position, Quaternion rotation);
        void Release(GameObject cubeObject);
    }
}