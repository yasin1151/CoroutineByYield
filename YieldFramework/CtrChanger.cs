using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldFramework
{
    public class CtrChanger : ICtrChanger
    {
        /// <summary>
        /// 外观实例
        /// </summary>
        private CoroutineFacade _facade;


        /// <summary>
        /// 默认构造函数
        /// </summary>
        public CtrChanger()
        {
            
        }

        /// <summary>
        /// 设置协程外观实例
        /// </summary>
        /// <param name="facade">外观实例</param>
        public void SetFacade(CoroutineFacade facade)
        {
            _facade = facade;
        }

        /// <summary>
        /// 将ator放入别的容器中
        /// </summary>
        /// <param name="ator">协程程序</param>
        /// <param name="changeTo">要加入的容器的枚举名</param>
        /// <returns>是否加入成功</returns>
        public bool ChangeTo(IEnumerator ator, CoroutineCtrEnum changeTo)
        {
            switch (changeTo)
            {
                case CoroutineCtrEnum.Default:
                    _facade.SendMsg(MsgString.ChangeToDefault, ator);
                    break;
                case CoroutineCtrEnum.Wait:
                    _facade.SendMsg(MsgString.ChangeToWait, ator);
                    break;
            }
            return true;
        }

        /// <summary>
        /// 重新安置ator，如果需要被移除，函数内部会自动加入相对应的容器
        /// 并且会返回true, 这时候需要在外部手动从当前容器移除
        /// </summary>
        /// <param name="ator">需要被重新安置的程序</param>
        /// <param name="currentType">当前的type</param>
        /// <returns>如果需要被重新安置，返回true, 否则返回false</returns>
        public bool ResetAtor(IEnumerator ator, CoroutineCtrEnum currentType)
        {

            //不需要重置的情况
            if (null == ator.Current && CoroutineCtrEnum.Default == currentType)
            {
                return false;
            }
            else if (ator.Current is WaitForSeconds && CoroutineCtrEnum.Wait == currentType)
            {
                return false;
            }


            if (null == ator.Current)
            {
                _facade.SendMsg(MsgString.ChangeToDefault, ator);
            }
            else if (ator.Current is WaitForSeconds)
            {
                _facade.SendMsg(MsgString.ChangeToWait, ator);
            }

            return true;
        }
    }
}
