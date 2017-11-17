using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            ModifiedState modified = new ModifiedState();
            modified.DoAction(context);

            DeletededState deleted= new DeletededState();
            deleted.DoAction(context);

            Console.WriteLine(context.GetState().ToString());
            Console.ReadLine();
        }
    }

    class ModifiedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Modifed");
            context.SetState(this);
            
        }

        public override string ToString()
        {
            return "Modified";
        }
    }

    class DeletededState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Deleted");
            context.SetState(this);


        }

        public override string ToString()
        {
            return "Deleted";
        }
    }
    class AddedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Added");
            context.SetState(this);
        }
    }


    interface IState
    {
        void DoAction(Context context);
    }

    class Context
    {
        private IState _state;

        public void SetState(IState state)
        {
            _state = state;
        }

        public IState GetState()
        {
            return _state;
        }
    }
}
