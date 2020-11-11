///----------------------------------------------------------------
///<summary>
/// 版 本：v1.0.0
/// 创建人：Lonely
/// 日 期：2020/11/4 15:54:33
/// 描 述：
///</summary>
///----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public interface IEventSystem
{
    int GetModuleID();
    int[] GetListener();
    void Notify(int op,System.Object param);
}
