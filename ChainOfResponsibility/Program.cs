﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();
            
            manager.SetSuccesor(vicePresident);
            vicePresident.SetSuccesor(president);

            Expense expense = new Expense{Detail = "Training",Amount = 1418};

            manager.HandleExpense(expense);

            Console.ReadLine();
        }
    }

    class Expense
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    }

    abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase Succesor;
        public abstract void HandleExpense(Expense expense);

        public void SetSuccesor(ExpenseHandlerBase succesor)
        {
            Succesor = succesor;
        }
    }

    class Manager : ExpenseHandlerBase // müdür
    {

        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount <= 100)
            {
                Console.WriteLine("Manager handled the expense!");
            }
            else if (Succesor != null)
            {
                Succesor.HandleExpense(expense);
            }

        }
    }

    class VicePresident : ExpenseHandlerBase // başkan yardımcısı
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 100 && expense.Amount <= 1000)
            {
                Console.WriteLine("Vice president handled the expense!");
            }
            else if (Succesor != null)
            {
                Succesor.HandleExpense(expense);
            }
        }
    }

    class President : ExpenseHandlerBase // başkan
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 1000)
            {
                Console.WriteLine("President handled the expense!");
            }

        }
    }
}
