//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class TestModuleEntity {

    public HeroInfo heroInfo { get { return (HeroInfo)GetComponent(TestModuleComponentsLookup.HeroInfo); } }
    public bool hasHeroInfo { get { return HasComponent(TestModuleComponentsLookup.HeroInfo); } }

    public HeroInfo AddHeroInfo() {
        var component = CreateComponent<HeroInfo>(TestModuleComponentsLookup.HeroInfo);
        AddComponent(TestModuleComponentsLookup.HeroInfo, component);
        return component;
    }

    public void ReplaceHeroInfo(HeroInfo compoent) {
        var component = CreateComponent<HeroInfo>(TestModuleComponentsLookup.HeroInfo);
        ReplaceComponent(TestModuleComponentsLookup.HeroInfo, component);
    }

    public void RemoveHeroInfo() {
        RemoveComponent(TestModuleComponentsLookup.HeroInfo);
    }
}
