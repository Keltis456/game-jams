//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly PointerEnterHandler pointerEnterHandlerComponent = new PointerEnterHandler();

    public bool isPointerEnterHandler {
        get { return HasComponent(GameComponentsLookup.PointerEnterHandler); }
        set {
            if (value != isPointerEnterHandler) {
                var index = GameComponentsLookup.PointerEnterHandler;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : pointerEnterHandlerComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherPointerEnterHandler;

    public static Entitas.IMatcher<GameEntity> PointerEnterHandler {
        get {
            if (_matcherPointerEnterHandler == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PointerEnterHandler);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPointerEnterHandler = matcher;
            }

            return _matcherPointerEnterHandler;
        }
    }
}