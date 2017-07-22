using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldFramework
{
    /// <summary>
    /// 协程管理类的抽象外观
    /// </summary>
    public interface ICoroutineFacade
    {
        /// <summary>
        /// 初始化函数
        /// </summary>
        void Initialize();

        /// <summary>
        /// 释放函数
        /// </summary>
        void Release();


        /// <summary>
        /// 接受从控制类发出的消息
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <param name="arr">参数列表</param>
        void SendMsg(string msg, params IEnumerator[] arr);


        /// <summary>
        /// 更新函数
        /// </summary>
        /// <param name="name">需要更新的类的名字</param>
        /// <param name="dt">当前帧和上一帧的间隔时间</param>
        /// <warnnig>Runtime性能不佳，是一个需要改进的点</warnnig>
        void Update(string name, float dt);
    }
}
