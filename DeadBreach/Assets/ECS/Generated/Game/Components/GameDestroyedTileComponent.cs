//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly DestroyedTile destroyedTileComponent = new DestroyedTile();

    public bool isDestroyedTile {
        get { return HasComponent(GameComponentsLookup.DestroyedTile); }
        set {
            if (value != isDestroyedTile) {
                var index = GameComponentsLookup.DestroyedTile;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : destroyedTileComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherDestroyedTile;

    public static Entitas.IMatcher<GameEntity> DestroyedTile {
        get {
            if (_matcherDestroyedTile == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DestroyedTile);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDestroyedTile = matcher;
            }

            return _matcherDestroyedTile;
        }
    }
}
