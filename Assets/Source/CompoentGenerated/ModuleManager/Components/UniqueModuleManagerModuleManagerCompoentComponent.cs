//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

public partial class ModuleManagerContext {

    public ModuleManagerEntity moduleManagerCompoentEntity { get { return GetGroup(ModuleManagerMatcher.ModuleManagerCompoent).GetSingleEntity(); } }
    public ModuleManagerCompoent moduleManagerCompoent { get { return moduleManagerCompoentEntity.moduleManagerCompoent; } }
    public bool hasModuleManagerCompoent { get { return moduleManagerCompoentEntity != null; } }

    public ModuleManagerEntity SetModuleManagerCompoent() {
        if(hasModuleManagerCompoent) {
            throw new EntitasException("Could not set moduleManagerCompoent!\n" + this + " already has an entity with ModuleManagerCompoentComponent!",
                "You should check if the context already has a moduleManagerCompoentEntity before setting it or use context.ReplaceModuleManagerCompoent().");
        }
        var entity = CreateEntity();
        entity.AddModuleManagerCompoent();
        return entity;
    }

    public void ReplaceModuleManagerCompoent(ModuleManagerCompoent compoent) {
        var entity = moduleManagerCompoentEntity;
        if(entity == null) {
            entity = SetModuleManagerCompoent();
        } else {
            entity.ReplaceModuleManagerCompoent(compoent);
        }
    }

    public void RemoveModuleManagerCompoent() {
        DestroyEntity(moduleManagerCompoentEntity);
    }
}