

--[[--
 * @Description: 通过名字获取子控件  
 * @param:       父控件的Transform,子控件名字 
 * @return:      返回子控件Transform
 ]]
function Child(go,str)
	if go == nil then
		Trace("go == nil")
		return nil
	end
    return go:Find(str);
end


--[[--
 * @Description: 获取子控件组件
 * @param:       控件transform，子控件名称 , 组件名 
 * @return:      返回子控件Transform
 ]]
function SubComponentGet(trans,childCompName,typeName )
	if trans == nil then
		return;
	end
	local transChild = Child(trans, childCompName)
	if transChild == nil then
		return nil
	end
	return transChild.gameObject:GetComponent(typeName)
end


--[[--
 * @Description: 按钮点击事件注册  
 * @param:       控件transform，子控件名称 , 回调函数
 ]]
function AddClickCallback(trans,callback )
	local typeName = type(callback)

	if typeName == "function" then
		trans.onClick:AddListener(callback)
	end
end