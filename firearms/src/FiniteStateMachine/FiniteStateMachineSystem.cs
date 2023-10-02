﻿using Vintagestory.API.Common;
using MaltiezFirearms.FiniteStateMachine.API;
using MaltiezFirearms.FiniteStateMachine.Systems;

namespace MaltiezFirearms.FiniteStateMachine
{
    public class FiniteStateMachineSystem : ModSystem, IFactoryProvider
    {
        private IFactory<IOperation> mOperationFactory;
        private IFactory<ISystem> mSystemFactory;
        private IFactory<IInput> mInputFactory;
        private IInputInterceptor mInputIterceptor;

        public override void Start(ICoreAPI api)
        {
            base.Start(api);

            api.RegisterCollectibleBehaviorClass("maltiezfirearms.weapon", typeof(Framework.FiniteStateMachineBehaviour));

            mOperationFactory = new Framework.Factory<IOperation, Framework.UniqueIdGeneratorForFactory>();
            mSystemFactory = new Framework.Factory<ISystem, Framework.UniqueIdGeneratorForFactory>();
            mInputFactory = new Framework.Factory<IInput, Framework.UniqueIdGeneratorForFactory>();

            RegisterSystems();
            RegisterOperations();
            RegisterInputs();

            mInputIterceptor = new Framework.InputIntercepter(api);
        }

        public void RegisterSystems()
        {  
            mSystemFactory.RegisterType<Systems.BasicSoundSystem>("Sound");
        }
        public void RegisterOperations()
        {
            mOperationFactory.RegisterType<Operations.SimpleOperation>("Simple");
        }

        public void RegisterInputs()
        {
            mInputFactory.RegisterType<Inputs.SimpleKeyPress>("SimpleKeyPress");
        }

        public IFactory<IOperation> GetOperationFactory()
        {
            return mOperationFactory;
        }
        public IFactory<ISystem> GetSystemFactory()
        {
            return mSystemFactory;
        }
        public IFactory<IInput> GetInputFactory()
        {
            return mInputFactory;
        }
        public IInputInterceptor GetInputInterceptor()
        {
            return mInputIterceptor;
        }
    }
}
