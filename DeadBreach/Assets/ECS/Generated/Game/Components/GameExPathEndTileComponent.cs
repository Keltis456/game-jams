////------------------------------------------------------------------------------
//// <auto-generated>
////     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
////
////     Changes to this file may cause incorrect behavior and will be lost if
////     the code is regenerated.
//// </auto-generated>
////------------------------------------------------------------------------------
//public partial class GameEntity {

//    static readonly ExPathEndTile exPathEndTileComponent = new ExPathEndTile();

//    public bool isExPathEndTile {
//        get { return HasComponent(GameComponentsLookup.ExPathEndTile); }
//        set {
//            if (value != isExPathEndTile) {
//                var index = GameComponentsLookup.ExPathEndTile;
//                if (value) {
//                    var componentPool = GetComponentPool(index);
//                    var component = componentPool.Count > 0
//                            ? componentPool.Pop()
//                            : exPathEndTileComponent;

//                    AddComponent(index, component);
//                } else {
//                    RemoveComponent(index);
//                }
//            }
//        }
//    }
//}

////------------------------------------------------------------------------------
//// <auto-generated>
////     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
////
////     Changes to this file may cause incorrect behavior and will be lost if
////     the code is regenerated.
//// </auto-generated>
////------------------------------------------------------------------------------
//public sealed partial class GameMatcher {

//    static Entitas.IMatcher<GameEntity> _matcherExPathEndTile;

//    public static Entitas.IMatcher<GameEntity> ExPathEndTile {
//        get {
//            if (_matcherExPathEndTile == null) {
//                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ExPathEndTile);
//                matcher.componentNames = GameComponentsLookup.componentNames;
//                _matcherExPathEndTile = matcher;
//            }

//            return _matcherExPathEndTile;
//        }
//    }
//}
