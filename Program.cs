using System;
using System.Linq;
namespace delegatePractice
{
    class Program
    {
        public delegate void ArithmeticExpr(int a, int b);

        // 顯示出該方法的名稱與 a + b 的結果
        public static void Add(int a, int b)
        {
            Console.WriteLine("Method:[Add] has been called.\nThe answer is: " + (a + b).ToString() + "\n");
        }

        // 顯示出該方法的名稱與 a - b 的結果
        public static void Sub(int a, int b)
        {
            Console.WriteLine("Method:[Sub] has been called.\nThe answer is: " + (a - b).ToString() + "\n");
        }

        // 顯示出該方法的名稱與 a * b 的結果
        public static void Multiply(int a, int b)
        {
            Console.WriteLine("Method:[Multiply] has been called.\nThe answer is: " + (a * b).ToString() + "\n");
        }
        static void Main(string[] args)
        {
            // 宣告三個委派
            ArithmeticExpr ar1, ar2, ar3;
            int[] nums = new int[8] { 1, 0, 2, 3, 0, 4, 5, 0 };

            DuplicateZeros(nums);
            // /*******************Section 1*******************/
            // ar1 = Add;          // 起始將Add指派給ar1
            // ar1(10, 7);         // Invoke委派，呼叫Add並顯示出答案: 17
            // ar1 = Sub;          // ar1指派為Sub
            // ar1(10, 7);         // Invoke委派，呼叫Sub並顯示出答案: 3
            // ar1.Invoke(10, 7);  // 或是可以使用Invoke方法

            // /*******************Section 2*******************/
            // ar2 = Add;  // 起始將Add指派給ar2
            // ar2(3, 41); // Invoke委派，呼叫Add並顯示出答案: 44
            // ar2 += Sub; // 將Sub方法加入ar2的方法清單中
            //             // 現在方法清單中有Add和Sub (順序為: Add -> Sub)
            // ar2(3, 41); // Invoke委派，首先呼叫Add，答案為44;而後呼叫Sub，答案為-38

            // /*******************Section 3*******************/
            // ar3 = Multiply; // 起始將Multiply指派給ar3
            // ar3 += Add;     // 將Add方法加入ar3的方法清單中
            //                 // 現在方法清單中有Multiply和Add (順序為: Multiply -> Add)
            // ar3 += Sub;     // 將Sub方法加入ar3的方法清單中
            //                 // 現在方法清單中有Multiply、Add和Sub (順序為: Multiply -> Add -> Sub)
            // ar3(67, 19);    // Invoke委派，依序呼叫 Multiply、Add和Sub
            // ar3 -= ar2;     // 將Add、Sub移出方法清單
            // ar3(67, 19);    // 再次Invoke委派，這次只有ar3被呼叫
            // ar3 = null;     // 清空整個方法清單
            // ar3(18, 0);     // ERROR ==> 方法清單已經被清空了，拋出例外
            // System.Diagnostics.Debug.WriteLine("Execute Complete");
        }

        public static void DuplicateZeros(int[] arr)
        {

            int[] dupArr = new int[arr.Length];
            int zeroCount = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    zeroCount++;
                    if (i + zeroCount < arr.Length)

                    {
                        dupArr[i + zeroCount] = 0;
                        dupArr[i + zeroCount - 1] = 0;

                    }
                    else
                        break;




                }
                else
                {
                    if (i + zeroCount < arr.Length)
                        dupArr[i + zeroCount] = arr[i];
                    else
                        break;

                }

            }
            arr = dupArr;

        }
    }


}
