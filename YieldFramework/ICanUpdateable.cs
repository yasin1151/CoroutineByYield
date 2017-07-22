using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldFramework
{
    /// <summary>
    /// 拥有可更新能力的接口
    /// </summary>
    public interface ICanUpdateable
    {
        /// <summary>
        /// 更新函数，每帧调用
        /// </summary>
        /// <param name="dt">当前帧和上一帧的间隔时间</param>
        void Update(float dt);
    }
}
