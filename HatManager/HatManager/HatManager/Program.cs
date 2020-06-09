using System;
using Hat.Controller;

namespace HatManager
{
    class Program
    {
        static void Main(string[] args)
        {
            HatController hatController = new HatController();
            hatController.Run();
        }
    }
}
