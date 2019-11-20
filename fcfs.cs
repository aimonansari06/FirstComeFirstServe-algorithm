using System;

namespace csharp
{
    class pcb
    {
        static void Main(string[] args)
        {
          Console.WriteLine("FIRST COME FIRST SERVE SCHEDULING ALGORITHM");
          Console.WriteLine("Enter No: of processes");
          int proc=Convert.ToInt32(Console.ReadLine());
         float [] exetime= new float[proc];
          float [] arrtime= new float[proc];
          float [] fin = new float[proc];
         
          
          for(int i=0; i<proc; i++)
          {
            Console.WriteLine("PROCESS NO {0}",i+1);
            Console.Write("ARRIVAL TIME ");
            arrtime[i]=Convert.ToInt32(Console.ReadLine());
            Console.Write("EXECUTION TIME ");  
            exetime[i]=Convert.ToInt32(Console.ReadLine());
            float temp;
            Console.WriteLine("");
            if(i==0)
            {
              fin[i]=exetime[i];
            }
            else if(i>0)
            {
              
              temp=fin[i-1]+exetime[i]; //8+4 temp=12, 
              fin[i]=temp; //fin=12
            }

          }
        
          cal(fin,exetime,arrtime,proc);
            
        }
        public static void cal(float[] finish, float [] extime,float [] arrival, int npro)
        {
          float [] TTtime=new float[npro];
          float [] utilization=new float[npro];
          float [] wt=new float[npro];
          float awt=0;
          float atat=0;
          
          for(int i=0; i<npro; i++)
          {
           wt[i]=0;
            for(int j=0; j<i; j++)
            {
              wt[i]=wt[i]+extime[j];
            }
            TTtime[i]=wt[i]+extime[i];
            
            utilization[i]=((extime[i]/TTtime[i])*100);
            awt=awt+wt[i];
            atat=atat+TTtime[i];
            
          }
          
          Console.WriteLine("PROCESS ID     EXECUTION TIME            ARRIVAL TIME           WAITING TIME         TURNAROUND TIME          UTILIZATION ");
          for(int o=0; o<npro; o++)
          {
            Console.WriteLine("P{0}                  {1}                         {2}                   {3}                     {4}                   {5}% ", o+1, extime[o],arrival[o],wt[o], TTtime[o], utilization[o]);
            
          }
          
          awt=awt/npro;
          atat=atat/npro;
          Console.WriteLine("Average Waiting time = {0}", awt);
          Console.WriteLine("Average Turn around time ={0}", atat);

          
        }
    }
}