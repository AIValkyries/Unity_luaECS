
ViewLayer = 
{
	TIP = 0,
	TOP = 1,
	MIDDLE = 2,  
	BOTTOM = 3,  
	MAX = 4
};


-- gameObject     = GameObject
-- ViewPath       = string
-- layer          = ViewLayer
-- CachePrefab    = bool
-- CacheGameObjet = bool
ViewSystemComponent = MakeComponent("ViewSystemCompoent","gameObject","ViewPath","layer","CachePrefab","CacheGameObjet")