using UnityEngine;
using Zenject;

namespace Input
{
    public class InputInstaller : MonoInstaller<InputInstaller>
    {
        [SerializeField] private InputHandler handler;
        
        public override void InstallBindings()
        {
            Container.Bind<IPlayerInputSubject>().FromInstance(handler).AsSingle();
            Container.Bind<IUIInputSubject>().FromInstance(handler).AsSingle();
        }
    }
}