using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public abstract class Subject
    {
        protected List<Observer> observers = new List<Observer>();

        protected void Register(Observer observer)
        {
            observers.Add(observer);
        }

        public abstract void Notify();
    }
}
