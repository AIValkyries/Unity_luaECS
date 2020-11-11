

-- super == 超类
function class(classname, super)
    local superType = type(super)
    local cls
    if not super or superType == "table" then
        -- 继承自Lua Object
        if super then
            cls = {}
            setmetatable(cls, {__index = super})
            cls.super = super
        else
            cls = {ctor = function() end,__gc = true}
        end

        cls.__cname = classname
        cls.__index = cls

        function cls:New(...)
            local instance = setmetatable({}, cls)
            instance.class = cls
            instance:ctor(...)
            return instance
        end
    else
        error(string.format("class() - create class \"%s\" with invalid super type",classname), 0)
    end
    return cls
end