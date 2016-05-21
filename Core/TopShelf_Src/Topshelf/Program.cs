using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Topshelf
{
    // todo Change "AService" to something else
    public class AService
    {
        readonly Timer _timer;
        public AService()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => Console.WriteLine("It is {0} an all is well", DateTime.Now);
        }
        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // DO NOT USE .New(...) - won't work!!!
            HostFactory.Run(x =>                                 //1
            {
                x.Service<AService>(s =>                        //2
                {
                    s.ConstructUsing(name => new AService());     //3
                    s.WhenStarted(tc => tc.Start());              //4
                    s.WhenStopped(tc => tc.Stop());               //5
                });

                // http://docs.topshelf-project.com/en/latest/configuration/config_api.html#service-identity
                x.RunAsLocalSystem();                            //6

                // http://docs.topshelf-project.com/en/latest/configuration/config_api.html#service-start-modes
                x.StartAutomatically(); // Start the service automatically
                //x.StartManually(); // Start the service manually

                // todo: set service name, display name, description
                // http://docs.topshelf-project.com/en/latest/configuration/config_api.html#service-description
                x.SetDescription("AService Desc");             //7
                // http://docs.topshelf-project.com/en/latest/configuration/config_api.html#display-name
                x.SetDisplayName("AService");                  //8
                // http://docs.topshelf-project.com/en/latest/configuration/config_api.html#service-name
                x.SetServiceName("AService");                  //9
            });                                                 //10


            //1. Here we are setting up the host using the HostFactory.Run the runner. We open up a new lambda where the ‘x’ in this case exposes all of the host level configuration. Using this approach the command arguments are extracted from environment variables.
            //2. Here we are telling Topshelf that there is a service of type ‘TownCrier”. The lambda that gets opened here is exposing the service configuration options through the ‘s’ parameter.
            //3. This tells Topshelf how to build an instance of the service. Currently we are just going to ‘new it up’ but we could just as easily pull it from an IoC container with some code that would look something like ‘container.GetInstance<TownCrier>()’
            //4. How does Topshelf start the service
            //5. How does Topshelf stop the service
            //6. Here we are setting up the ‘run as’ and have selected the ‘local system’
            //7. We can also set up from the command line
            //8. Interactively with a win from type prompt
            //9. We can also just pass in some username/password as string arguments
            //10. Here we are setting up the description for the winservice to be use in the windows service monitor
            //11. Here we are setting up the display name for the winservice to be use in the windows service monitor
            //12. Here we are setting up the service name for the winservice to be use in the windows service monitor
            //13. Now that the lambda has closed, the configuration will be executed and the host will start running.

        }
    }
}
