using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldFramework
{
    /// <summary>
    /// 用于控制有等待时间的协程
    /// </summary>
    class WaitTimeCoroutineCtr : AbsCoroutineCtr
    {
        /// <summary>
        /// listbuf
        /// </summary>
        private List<IEnumerator> _bufList;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public WaitTimeCoroutineCtr()
        {
            _bufList = new List<IEnumerator>();
        }

        /// <summary>
        /// 更新函数，每帧调用
        /// </summary>
        /// <param name="dt">当前帧和上一帧的间隔时间</param>
        public override void Update(float dt)
        {
            _bufList = _list.ToList();

            foreach (IEnumerator ator in _bufList)
            {
                WaitForSeconds buf = ator.Current as WaitForSeconds;

                if (null == buf)
                {
                    //add to other list
                    _facade.SendMsg(MsgString.Reset, ator, CoroutineCtrEnum.Wait);
                    _list.Remove(ator);
                    continue;
                }

                buf.SubTime(dt);

                //is can exe
                if (buf.IsCanExecute())
                {
                    //exe
                    if (!ator.MoveNext())
                    {
                        //exe over
                        //destory
                        _list.Remove(ator);
                        continue;
                    }


                    string ret = _facade.SendMsg(MsgString.Reset, ator, CoroutineCtrEnum.Wait);
                    if (MsgString.True == ret)
                    {
                        //reset
                        _list.Remove(ator);
                    }

                }
            }


            _bufList.Clear();
        }
    }
}
