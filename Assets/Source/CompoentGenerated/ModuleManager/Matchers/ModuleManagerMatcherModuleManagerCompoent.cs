//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.MatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

public sealed partial class ModuleManagerMatcher {

    static IMatcher<ModuleManagerEntity> _matcherModuleManagerCompoent;

    public static IMatcher<ModuleManagerEntity> ModuleManagerCompoent {
        get {
            if(_matcherModuleManagerCompoent == null) {
                var matcher = (Matcher<ModuleManagerEntity>)Matcher<ModuleManagerEntity>.AllOf(ModuleManagerComponentsLookup.ModuleManagerCompoent);
                matcher.componentNames = ModuleManagerComponentsLookup.componentNames;
                _matcherModuleManagerCompoent = matcher;
            }

            return _matcherModuleManagerCompoent;
        }
    }
}
