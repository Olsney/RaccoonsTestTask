using Code.Data;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Factory.Game;
using Code.Infrastructure.Factory.State;
using Code.Infrastructure.States;
using Code.Services.CubeSpawnerProviders;
using Code.Services.GameOver;
using Code.Services.InputHandlerProvider;
using Code.Services.InputHandlerProviders;
using Code.Services.Inputs;
using Code.Services.Merge;
using Code.Services.Random;
using Code.Services.Randoms;
using Code.Services.SpawnPointProviders;
using Code.Services.StaticData;
using Code.UI.Factory;
using Code.UI.Services.Windows;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            BindCoroutine();
            BindFactories();
            BindStates();
            BindServices();
            BindSceneLoader();
        }
        
        private void BindCoroutine() => 
            Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();
        
        private void BindFactories()
        {
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
        }

        private void BindStates()
        {
            Container.Bind<GameStateMachine>().AsSingle();
            Container.Bind<BootstrapState>().AsSingle();
            Container.Bind<LoadLevelState>().AsSingle();
            Container.Bind<LoadProgressState>().AsSingle();
            Container.Bind<GameLoopState>().AsSingle();
        }
        
        private void BindServices()
        {
            BindInputService();
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<IPlayerInputHandlerProvider>().To<PlayerInputHandlerProvider>().AsSingle();
            Container.Bind<ICubeSpawnPointProvider>().To<CubeSpawnPointProvider>().AsSingle();
            Container.Bind<IMergeService>().To<MergeService>().AsSingle();
            Container.Bind<IRandomService>().To<RandomService>().AsSingle();
            Container.Bind<ICubeSpawnerProvider>().To<CubeSpawnerProvider>().AsSingle();
            Container.Bind<IGameOverService>().To<GameOverService>().AsSingle();
            Container.Bind<IWorldData>().To<WorldData>().AsSingle();
            Container.Bind<IWindowService>().To<WindowService>().AsSingle();
        }
        
        private void BindInputService()
        {
            if (Application.isEditor)
                Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
            else
                Container.Bind<IInputService>().To<MobileInputService>().AsSingle();
        }
        
        private void BindSceneLoader() => 
            Container.Bind<SceneLoader>().AsSingle();
    }
}