using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldFramework
{
    /// <summary>
    /// 协程控制类的接口
    /// </summary>
    public interface ICoroutineCtr : ICanUpdateable
    {

        /// <summary>
        /// 获取当前协程的所有数据成员
        /// </summary>
        /// <returns>数据数组</returns>
        List<IEnumerator> GetData();

        /// <summary>
        /// 为了不使用单例模式，采取了注入的方式
        /// </summary>
        /// <param name="facade">外观实例</param>
        void SetFacade(CoroutineFacade facade);

    }
}
