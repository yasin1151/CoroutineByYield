using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldFramework
{
    /// <summary>
    /// 用来处理ctr类之间的数据转换
    /// </summary>
    public interface ICtrChanger
    {
        /// <summary>
        /// 设置协程外观实例
        /// </summary>
        /// <param name="facade">外观实例</param>
        void SetFacade(CoroutineFacade facade);

        /// <summary>
        /// 将ator放入别的容器中
        /// </summary>
        /// <param name="ator">协程程序</param>
        /// <param name="changeTo">要加入的容器的枚举名</param>
        /// <returns>是否加入成功</returns>
        bool ChangeTo(IEnumerator ator, CoroutineCtrEnum changeTo);


        /// <summary>
        /// 重新安置ator，如果需要被移除，函数内部会自动加入相对应的容器
        /// 并且会返回true, 这时候需要在外部手动从当前容器移除
        /// </summary>
        /// <param name="ator">需要被重新安置的程序</param>
        /// <param name="currentType">当前的type</param>
        /// <returns>如果需要被重新安置，返回true, 否则返回false</returns>
        bool ResetAtor(IEnumerator ator, CoroutineCtrEnum currentType);
    }
}
