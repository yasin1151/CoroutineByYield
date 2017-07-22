using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldFramework
{
    class DefaultCoroutineCtr : AbsCoroutineCtr
    {
        private List<IEnumerator> _needRemoveList;

        public DefaultCoroutineCtr()
        {
            _needRemoveList = new List<IEnumerator>();
        }

        /// <summary>
        /// 更新函数，每帧调用
        /// </summary>
        /// <param name="dt">当前帧和上一帧的间隔时间</param>
        public override void Update(float dt)
        {
            foreach (IEnumerator ator in _list)
            {
                if (!ator.MoveNext())
                {
                    _needRemoveList.Add(ator);
                    continue;
                }

                if (ator.Current is WaitForSeconds)
                {
                    //change to other
                    _facade.SendMsg("ChangeToWait", ator);
                    _needRemoveList.Add(ator);
                }
            }


            foreach (IEnumerator ator in _needRemoveList)
            {
                //remove
                _list.Remove(ator);
            }

            _needRemoveList.Clear();
        }
    }
}
