using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;    // read in details about this class

namespace MyTestWindowsService
{
    public partial class Scheduler : ServiceBase
    {
        System.Timers.Timer timeDelay1;
        System.Timers.Timer timeDelay2;
       

        public Scheduler()
        {
            Random rnd = new Random();
            InitializeComponent();         
            timeDelay1 = new System.Timers.Timer();
            timeDelay2 = new System.Timers.Timer();
            timeDelay1.Interval = rnd.Next(5000,10000);    // 10000 = 10s
            timeDelay1.Elapsed += new System.Timers.ElapsedEventHandler(this.ProcessStart);
            timeDelay2.Interval = rnd.Next(7500,15000);
            timeDelay2.Elapsed += new System.Timers.ElapsedEventHandler(this.ProcessFinish);
        }

        protected override void OnStart(string[] args)
        {
            timeDelay1.Enabled = true;
            timeDelay2.Enabled = true;
            Library.WriteErrorLog("Test window service started");
        }

        private void ProcessStart(object sender, ElapsedEventArgs e)
        {
            Library.WriteErrorLog(" Process x" + Library.ProcessNumber() + " started");    
        }
        private void ProcessFinish(object sender, ElapsedEventArgs e)
        {
            Library.WriteErrorLog(" Process x" + Library.ProcessNumber() + " finished");
        }

        protected override void OnStop()
        {
            timeDelay1.Enabled = true;
            timeDelay2.Enabled = true;
              Library.WriteErrorLog("Test window service stopped");
        }
    }
}
