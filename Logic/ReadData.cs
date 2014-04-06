using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Remoting.Messaging;
namespace WebMultiThread.Logic
{
    public class ReadData
    {
        delegate List<long> DoworkDelegate(int w);

        List<long> r1;
        List<long> r2;
        List<long> r3;

        public ReadData()
        {}

        public List<long> DoWorkAsync()
        {
            DoworkDelegate d = new DoworkDelegate(this.DoWork);
            DoworkDelegate d2 = new DoworkDelegate(this.DoWork);
            DoworkDelegate d3 = new DoworkDelegate(this.DoWork);

            IAsyncResult ar1 = d.BeginInvoke(1, new AsyncCallback(WorkComplete1), null);
            IAsyncResult ar2 = d2.BeginInvoke(2, new AsyncCallback(WorkComplete2), null);
            IAsyncResult ar3 = d3.BeginInvoke(3, new AsyncCallback(WorkComplete3), null);

            while (!ar1.IsCompleted || !ar2.IsCompleted || !ar3.IsCompleted )
            {
                System.Threading.Thread.Sleep(10);
            }

            r1 = r1.Concat(r2).Concat(r3).ToList();

            return r1.ToList();
        }

        public void WorkComplete1(IAsyncResult ar)
        {
            DoworkDelegate d = (DoworkDelegate)((AsyncResult)ar).AsyncDelegate;
            r1 = d.EndInvoke(ar);
        }

        public void WorkComplete2(IAsyncResult ar)
        {
            DoworkDelegate d = (DoworkDelegate)((AsyncResult)ar).AsyncDelegate;
            r2 = d.EndInvoke(ar);
        }

        public void WorkComplete3(IAsyncResult ar)
        {
            DoworkDelegate d = (DoworkDelegate)((AsyncResult)ar).AsyncDelegate;
            r3 = d.EndInvoke(ar);
        }

        public List<long> DoWork(int w)
        {
            List<long> lsti = new List<long>();
            
            for (int i = 1; i < 100000; i++)
            {
                if (w == 1)
                {
                   if(i>30000) continue;
                }
                else if (w == 2)
                {
                    if (!(i >= 30000 && i <= 70000)) continue;
                }
                else if (w == 3)
                {
                    if (i<=70000) continue;
                }
                else
                {
                }

                for (int j = 1; j < 10000; j++)
                {
                    var x = i + j;
                }

                lsti.Add(i);
            }

            return lsti;
        }


    }
}