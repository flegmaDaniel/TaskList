using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    #region Questions

    //What type of access modifiers exists in C#? 
    //What is their order if the most strict one should come first? asnwer: 
    //Why would you use protected modifier? asnwer: 

    #endregion


    #region Questions by example

    public class Interrogator
    {
        Chef chef;
        Guest guest;
        RichBanker banker;
        Maid maid;

        public Interrogator()
        {
            SummonParticipants();
        }

        public void InterogateSubjects()
        {
            //Q-1 will the following lines compile?

            //Console.WriteLine(chef.Introduction());
            //Console.WriteLine(guest.Introduction()); 
            //Console.WriteLine(banker.Introduction()); 
            //Console.WriteLine(maid.Introduction());
        }

        private void SummonParticipants()
        {
            chef = new Chef();
            guest = new Guest();
            banker = new RichBanker();  
            maid = new Maid();  
        }
    }

    public class Chef 
    {
        public string Introduction() => $"Hello I am {typeof(Chef).Name} .."; 
    }

    public class Maid 
    {
        internal string Introduction() => $"Hello I am {typeof(Maid).Name} ..";
    }

    public class Guest 
    {
        private string Introduction() => $"Hello I am {typeof(Guest).Name} ..";
    }


    public class RichBanker 
    {
        protected string Introduction() => $"Hello I am {typeof(Guest).Name} ..";
    }



    #endregion


    #region Task

    public static class RunTask
    {

        public static void Run()
        {
            Console.WriteLine("Running Task 1 \n");

            var iterrogator = new Interrogator();

            iterrogator.InterogateSubjects();
        }
    }
        
    #endregion


}
