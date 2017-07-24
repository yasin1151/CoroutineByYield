### CoroutineByYield    

>   Auther : PengYao    
    Email  : yasin1151@outlook.com  
    time   : 2017/7/22  
    version: 1.2

### Version : 1.2
    弃用了使用string来区分的Update方法，新增了使用枚举来区分的Update方法

### Version : 1.1
    添加了一层中间层来处理SendMsg中的事件，这样在新增加功能时只需要修改这个中间层
    对扩展更加友好

### Version : 1.0
    使用了Facade模式实现了大体的框架，为了防止某些问题，没有使用单例模式，  
    而是采取了注入的手段。 整体结构不是特别明朗，应该会有下一个版本    


Example :   
```CS
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
```



Result :
```CSS
i'm wait time test : 0
 i'm default test : 0
 i'm default test : 1
 i'm default test : 2
 i'm default test : 3
 i'm default test : 4
 i'm default test : 5
 i'm default test : 6
 i'm default test : 7
 i'm default test : 8
 i'm default test : 9
 i'm wait time test : 1
 i'm wait time test : 2
 i'm wait time test : 3
 i'm wait time test : 4
 i'm wait time test : 5
 i'm wait time test : 6
 i'm wait time test : 7
 i'm wait time test : 8
 i'm wait time test : 9
timeSum greate than maxTime
```


