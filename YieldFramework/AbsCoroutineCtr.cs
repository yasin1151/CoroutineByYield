using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldFramework
{
    public abstract class AbsCoroutineCtr : ICoroutineCtr
    {
        /// <summary>
        /// 外观类，在构造时注入
        /// </summary>
        protected ICoroutineFacade _facade;

        /// <summary>
        /// 用于存储协程
        /// </summary>
        protected List<IEnumerator> _list;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        protected AbsCoroutineCtr()
        {
            _list = new List<IEnumerator>();
        }

        /// <summary>
        /// 更新函数，每帧调用
        /// </summary>
        /// <param name="dt">当前帧和上一帧的间隔时间</param>
        public abstract void Update(float dt);

        /// <summary>
        /// 获取当前协程的所有数据成员
        /// </summary>
        /// <returns>数据数组</returns>
        public List<IEnumerator> GetData()
        {
            return _list;
        }

        /// <summary>
        /// 为了不使用单例模式，采取了注入的方式
        /// </summary>
        /// <param name="facade">外观实例</param>
        public void SetFacade(ICoroutineFacade facade)
        {
            _facade = facade;
        }
    }
}
