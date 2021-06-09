/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;
using System.Collections;
class HelloWorld {
  static void Main() {
    	int[] x={ 0, 2, 0, 3, 0, 5, 6, 0, 0};
        int[] y = { -3, 4, 42 };
        int pointerx=0,pointery=0;
        ArrayList al=new ArrayList();
        while(pointerx<x.Length&&pointery<y.Length){
            while(pointerx<x.Length&&x[pointerx]==0)
                pointerx++;
            while(pointery<y.Length&&y[pointery]==0)  
                pointery++;
            if(pointerx>=x.Length||pointery>=y.Length)
                break;
            if(x[pointerx]<y[pointery]){
                al.Add(x[pointerx++]);
            }
            else{
                al.Add(y[pointery++]);
            }
        }
        while(pointerx<x.Length){
            if(x[pointerx]!=0)
                al.Add(x[pointerx]);
            pointerx++;
        }
        while(pointery<y.Length){
            if(y[pointery]!=0)
                al.Add(y[pointery]);
            pointery++;
        }
        foreach(int temp in al){
            Console.Write(temp+" ");
        }
  }
}