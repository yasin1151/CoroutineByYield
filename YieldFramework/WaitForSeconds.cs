using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldFramework
{
    public class WaitForSeconds : IEnumerator
    {
        /// <summary>
        /// 当前需要等待的时间
        /// </summary>
        private float _needWaitTime;


        /// <summary>
        /// 获取当前类是否可以执行
        /// </summary>
        /// <returns>true - 可以， false - 不可以</returns>
        public bool IsCanExecute()
        {
            return _needWaitTime <= 0;
        }
        
        /// <summary>
        /// 减少需要等待的时间
        /// </summary>
        /// <param name="time">减少的时间</param>
        public void SubTime(float time)
        {
            _needWaitTime -= time;
        }


        public float GetNeedTime()
        {
            return _needWaitTime;
        }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="time">需要等待的秒数,单位是秒</param>
        public WaitForSeconds(float time)
        {
            _needWaitTime = time;
            Current = this;
        }

        /// <summary>
        /// 将枚举数推进到集合的下一个元素。
        /// </summary>
        /// <returns>
        /// 如果枚举数成功地推进到下一个元素，则为 true；如果枚举数越过集合的结尾，则为 false。
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">在创建了枚举数后集合被修改了。</exception>
        public bool MoveNext()
        {
            return false;
        }

        /// <summary>
        /// 将枚举数设置为其初始位置，该位置位于集合中第一个元素之前。
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">在创建了枚举数后集合被修改了。</exception>
        public void Reset()
        {
            
        }

        /// <summary>
        /// 获取集合中的当前元素。
        /// </summary>
        /// <returns>
        /// 集合中的当前元素。
        /// </returns>
        public object Current { get; }
    }
}
