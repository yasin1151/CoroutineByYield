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
    public class CoroutineFacade
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
        /// 控制器转换者
        /// </summary>
        private ICtrChanger _ctrChanger;

        /// <summary>
        /// 初始化函数，在这个阶段注入Facade
        /// </summary>
        public void Initialize()
        {
            _waitTimeCtr = new WaitTimeCoroutineCtr();
            _waitTimeCtr.SetFacade(this);
            _defaultCtr = new DefaultCoroutineCtr();
            _defaultCtr.SetFacade(this);
            _ctrChanger = new CtrChanger();
            _ctrChanger.SetFacade(this);
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
        public string SendMsg(string msg, params Object[] arr)
        {

            if (MsgString.Change == msg)
            {
                _ctrChanger.ChangeTo(arr[0] as IEnumerator, (CoroutineCtrEnum) arr[1]);
                return null;
            }
            else if (MsgString.Reset == msg)
            {
                return _ctrChanger.ResetAtor(arr[0] as IEnumerator, (CoroutineCtrEnum)arr[1]) ? "true" : "false";   
            }




            if (MsgString.ChangeToWait == msg)
            {
                _waitTimeCtr.GetData().Add(arr[0] as IEnumerator);
            }
            else if (MsgString.ChangeToDefault == msg)
            {
                _defaultCtr.GetData().Add(arr[0] as IEnumerator);
            }

            return null;
        }


        [System.Obsolete("请用枚举版的Update")]
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

        /// <summary>
        /// 更新函数
        /// </summary>
        /// <param name="state">枚举的类型</param>
        /// <param name="dt">当前帧和上一帧的间隔时间</param>
        public void Update(CoroutineCtrEnum state, float dt)
        {
            switch (state)
            {
                case CoroutineCtrEnum.Default:
                    _defaultCtr.Update(dt);
                    break;
                case CoroutineCtrEnum.Wait:
                    _waitTimeCtr.Update(dt);
                    break;
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
