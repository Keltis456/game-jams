//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SkillCooldown skillCooldown { get { return (SkillCooldown)GetComponent(GameComponentsLookup.SkillCooldown); } }
    public bool hasSkillCooldown { get { return HasComponent(GameComponentsLookup.SkillCooldown); } }

    public void AddSkillCooldown(int newValue) {
        var index = GameComponentsLookup.SkillCooldown;
        var component = (SkillCooldown)CreateComponent(index, typeof(SkillCooldown));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSkillCooldown(int newValue) {
        var index = GameComponentsLookup.SkillCooldown;
        var component = (SkillCooldown)CreateComponent(index, typeof(SkillCooldown));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSkillCooldown() {
        RemoveComponent(GameComponentsLookup.SkillCooldown);
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

    static Entitas.IMatcher<GameEntity> _matcherSkillCooldown;

    public static Entitas.IMatcher<GameEntity> SkillCooldown {
        get {
            if (_matcherSkillCooldown == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SkillCooldown);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSkillCooldown = matcher;
            }

            return _matcherSkillCooldown;
        }
    }
}