//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly PointerEnter pointerEnterComponent = new PointerEnter();

    public bool isPointerEnter {
        get { return HasComponent(GameComponentsLookup.PointerEnter); }
        set {
            if (value != isPointerEnter) {
                var index = GameComponentsLookup.PointerEnter;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : pointerEnterComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherPointerEnter;

    public static Entitas.IMatcher<GameEntity> PointerEnter {
        get {
            if (_matcherPointerEnter == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PointerEnter);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPointerEnter = matcher;
            }

            return _matcherPointerEnter;
        }
    }
}
