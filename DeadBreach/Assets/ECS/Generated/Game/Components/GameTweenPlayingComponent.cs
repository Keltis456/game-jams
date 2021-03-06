//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly TweenPlaying tweenPlayingComponent = new TweenPlaying();

    public bool isTweenPlaying {
        get { return HasComponent(GameComponentsLookup.TweenPlaying); }
        set {
            if (value != isTweenPlaying) {
                var index = GameComponentsLookup.TweenPlaying;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : tweenPlayingComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherTweenPlaying;

    public static Entitas.IMatcher<GameEntity> TweenPlaying {
        get {
            if (_matcherTweenPlaying == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TweenPlaying);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTweenPlaying = matcher;
            }

            return _matcherTweenPlaying;
        }
    }
}
