//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ModuleBaseEntity {

    public UIManagerCompoent uIManagerCompoent { get { return (UIManagerCompoent)GetComponent(ModuleBaseComponentsLookup.UIManagerCompoent); } }
    public bool hasUIManagerCompoent { get { return HasComponent(ModuleBaseComponentsLookup.UIManagerCompoent); } }

    public UIManagerCompoent AddUIManagerCompoent() {
        var component = CreateComponent<UIManagerCompoent>(ModuleBaseComponentsLookup.UIManagerCompoent);
        AddComponent(ModuleBaseComponentsLookup.UIManagerCompoent, component);
        return component;
    }

    public void ReplaceUIManagerCompoent(UIManagerCompoent compoent) {
        var component = CreateComponent<UIManagerCompoent>(ModuleBaseComponentsLookup.UIManagerCompoent);
        ReplaceComponent(ModuleBaseComponentsLookup.UIManagerCompoent, component);
    }

    public void RemoveUIManagerCompoent() {
        RemoveComponent(ModuleBaseComponentsLookup.UIManagerCompoent);
    }
}
