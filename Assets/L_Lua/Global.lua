
require("Logic.functions")
require("entitas");

String          = System.String
Screen			= UnityEngine.Screen
GameObject 		= UnityEngine.GameObject
Transform 		= UnityEngine.Transform
Space			= UnityEngine.Space
Camera			= UnityEngine.Camera
QualitySettings = UnityEngine.QualitySettings
AudioClip		= UnityEngine.AudioClip
MeshRenderer	= UnityEngine.MeshRenderer
PlayerPrefs     = UnityEngine.PlayerPrefs
BoxCollider     = UnityEngine.BoxCollider
UnityEvent      = UnityEngine.Events.UnityEvent

------------------------------------------UnityEngine.UI----------------------------
Button                    = UnityEngine.UI.Button
Text                      = UnityEngine.UI.Text
EventSystem               = UnityEngine.EventSystems.EventSystem
StandaloneInputModule     = UnityEngine.EventSystems.StandaloneInputModule
RectTransform             = UnityEngine.RectTransform



ProtobufDataConfigSystems = ProtobufDataConfigSystems
GameWorld 		          = GameWorld
ResourcesSceneSystems     = ResourcesSceneSystems
ResourcesSystems          = ResourcesSystems
TcpNetworkSystems         = TcpNetworkSystems


ViewSystem = require("Framework.moduleBase.ViewSystem")
ModuleBaseSystems = require("Framework.moduleBase.ModuleBaseSystems")
require("Framework.moduleBase.ModuleParam")