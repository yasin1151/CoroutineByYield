using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace YieldFramework
{
    class Program
    {

        static IEnumerator test1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(" i'm wait time test : " + i);
                yield return new WaitForSeconds(1);
            }
            yield break;
        }

        static IEnumerator test2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(" i'm default test : " + i);
                yield return null;
            }
            yield break;

        }

        static void Main(string[] args)
        {
            CoroutineMgr ctr = new CoroutineMgr();
            ctr.Initialize();

            ctr.StartContorine(test1());
            ctr.StartContorine(test2());

            float maxTime = 11;
            float timeSum = 0;
            float timeStep = 0.016f;



            while (true)
            {


                //模拟运行，每一帧为0.016s
                ctr.Update("DefaultCtr", timeStep);
                ctr.Update("WaitTimeCtr", timeStep);
                timeSum += timeStep;


                Thread.Sleep(16);

                if (timeSum > maxTime)
                {
                    Console.WriteLine("timeSum greate than maxTime");
                    break;
                }

            }




            ctr.Release();
        }
    }
}
