//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity mainCameraEntity { get { return GetGroup(GameMatcher.MainCamera).GetSingleEntity(); } }
    public MainCamera mainCamera { get { return mainCameraEntity.mainCamera; } }
    public bool hasMainCamera { get { return mainCameraEntity != null; } }

    public GameEntity SetMainCamera(UnityEngine.Camera newValue) {
        if (hasMainCamera) {
            throw new Entitas.EntitasException("Could not set MainCamera!\n" + this + " already has an entity with MainCamera!",
                "You should check if the context already has a mainCameraEntity before setting it or use context.ReplaceMainCamera().");
        }
        var entity = CreateEntity();
        entity.AddMainCamera(newValue);
        return entity;
    }

    public void ReplaceMainCamera(UnityEngine.Camera newValue) {
        var entity = mainCameraEntity;
        if (entity == null) {
            entity = SetMainCamera(newValue);
        } else {
            entity.ReplaceMainCamera(newValue);
        }
    }

    public void RemoveMainCamera() {
        mainCameraEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MainCamera mainCamera { get { return (MainCamera)GetComponent(GameComponentsLookup.MainCamera); } }
    public bool hasMainCamera { get { return HasComponent(GameComponentsLookup.MainCamera); } }

    public void AddMainCamera(UnityEngine.Camera newValue) {
        var index = GameComponentsLookup.MainCamera;
        var component = (MainCamera)CreateComponent(index, typeof(MainCamera));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMainCamera(UnityEngine.Camera newValue) {
        var index = GameComponentsLookup.MainCamera;
        var component = (MainCamera)CreateComponent(index, typeof(MainCamera));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMainCamera() {
        RemoveComponent(GameComponentsLookup.MainCamera);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMainCamera;

    public static Entitas.IMatcher<GameEntity> MainCamera {
        get {
            if (_matcherMainCamera == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MainCamera);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMainCamera = matcher;
            }

            return _matcherMainCamera;
        }
    }
}
