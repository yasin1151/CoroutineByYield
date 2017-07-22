using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldFramework
{
    /// <summary>
    /// 协程控制类的外观
    /// </summary>
    class CoroutineMgr : ICoroutineFacade
    {
        /// <summary>
        /// 需要等待时间的控制器
        /// </summary>
        private AbsCoroutineCtr _waitTimeCtr;

        /// <summary>
        /// 默认控制器
        /// </summary>
        private AbsCoroutineCtr _defaultCtr;


        /// <summary>
        /// 初始化函数
        /// </summary>
        public void Initialize()
        {
            _waitTimeCtr = new WaitTimeCoroutineCtr();
            _waitTimeCtr.SetFacade(this);
            _defaultCtr = new DefaultCoroutineCtr();
            _defaultCtr.SetFacade(this);
        }

        /// <summary>
        /// 释放函数
        /// </summary>
        public void Release()
        {

        }

        /// <summary>
        /// 接受从控制类发出的消息
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <param name="arr">参数列表</param>
        public void SendMsg(string msg, params IEnumerator[] arr)
        {
            if ("ChangeToWait" == msg)
            {
                _waitTimeCtr.GetData().Add(arr[0]);
            }
            else if ("ChangeToDefault" == msg)
            {
                _defaultCtr.GetData().Add(arr[0]);
            }
        }

        /// <summary>
        /// 更新函数
        /// </summary>
        /// <param name="name">需要更新的类的名字</param>
        /// <param name="dt">当前帧和上一帧的间隔时间</param>
        /// <warnnig>Runtime性能不佳，是一个需要改进的点</warnnig>
        public void Update(string name, float dt)
        {
            if ("WaitTimeCtr" == name)
            {
                _waitTimeCtr.Update(dt);
            }
            else if ("DefaultCtr" == name)
            {
                _defaultCtr.Update(dt);
            }
        }


        public void StartContorine(IEnumerator ator)
        {
            if (null == ator.Current)
            {
                //默认类型
                _defaultCtr.GetData().Add(ator);
            }
            else if (ator.Current is WaitForSeconds)
            {
                //等待时间类型
                _waitTimeCtr.GetData().Add(ator);
            }
        }
    }
}
