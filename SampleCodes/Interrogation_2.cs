using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    #region Questions

    //What type of inheritance C# uses? answer:
    //What can you tell about Interfaces used in C#? answer:
    //What's the difference between base class and implemented Interface? answer:
    //Why would you use Interfaces? answer:
    //What are virtual and abstract keywords are used for? asnwer: 

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
            //Q-1 How would you simplify the current implementation using inheritance?

            Console.WriteLine(chef.Introduction());
            Console.WriteLine(guest.Introduction());
            Console.WriteLine(banker.Introduction());
            Console.WriteLine(maid.Introduction());
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
        public string Introduction() => $"Hello I am {typeof(Maid).Name} ..";
    }

    public class Guest 
    {
        public string Introduction() => $"Hello I am {typeof(Guest).Name} ..";
    }


    public class RichBanker
    {
        public string Introduction() => $"Hello I am {typeof(Guest).Name} ..";
    }

    #endregion


    #region Task

    public static class RunTask
    {

        public static void Run()
        {

            Console.WriteLine("Running Task 2 \n");
            var iterrogator = new Interrogator();

            iterrogator.InterogateSubjects();
        }
    }
        
    #endregion


}
