using UnityEngine;

namespace Code.Infrastructure.Factory.Game
{
    public interface IGameFactory
    {
        GameObject CreatePlayerInputHandler();
        GameObject CreateCube(int cubeValue);
        GameObject CreateCube(int cubeValue, Vector3 at);
        GameObject CreateCubeSpawner();
    }
}