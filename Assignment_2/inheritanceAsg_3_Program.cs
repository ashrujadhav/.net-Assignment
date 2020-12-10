﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDay2
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Manager("Ashruba", 2, "manager");
            e1.BASIC = 2000;
            e1.Display();

            Console.WriteLine();
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Employee e2 = new GeneralManager("pravin", 3, "GeneralManager", "xyz");
            e2.BASIC = 40000;
            e2.Display();

            Console.WriteLine();
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@");

            Employee e3 = new CEO("Kishor", 4);
            e3.BASIC = 10000000;
            e3.Display();
            Console.WriteLine();

            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Employee e4 = new Manager();

            e4.Display();
            Console.WriteLine();
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Employee e5 = new GeneralManager();

            e5.Display();
            Console.WriteLine();
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@");

            Employee e6 = new CEO();

            e6.Display();
            Console.WriteLine();

            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.ReadLine();
        }
    }
    abstract class Employee : IDBFunction
    {
        private string name;
        private static int S_empno = 0;

        public Employee()
        { }
        public string NAME
        {
            get { return name; }
            set
            {
                if (value == "default")
                {
                    name = "Employee";
                }
                else
                {
                    name = value;
                }
            }
        }
        private int empNo;
        public int EMPNO
        {
            get { return empNo; }
            private set { empNo = ++S_empno; }
        }
        private short deptNo;
        public short DEPTNO
        {
            get { return deptNo; }
            set
            {
                if (value == 0)
                {
                    deptNo = 1;
                }

                deptNo = value;
            }
        }
        protected decimal basic;


        public Employee(string name = "default", short depNo = 0)
        {
            EMPNO = 23;
            this.NAME = name;
            this.DEPTNO = depNo;
        }
        public abstract decimal BASIC { set; get; }

        public abstract decimal CalcNetSalary();

        public virtual void Display()
        {
            Console.Write(EMPNO + " " + NAME + " " + DEPTNO + " " + basic + " " + CalcNetSalary() + " ");
        }

        public void insert()
        {
            throw new NotImplementedException();
        }

        public void update()
        {
            throw new NotImplementedException();
        }

        public void delete()
        {
            throw new NotImplementedException();
        }

        public void create()
        {
            throw new NotImplementedException();
        }
    }


    interface IDBFunction
    {
        void insert();
        void update();
        void delete();
        void create();

    }
    class Manager : Employee, IDBFunction
    {
        private string designation;


        public string DESIGNAION
        {
            get { return designation; }
            set
            {
                if (value == "default")
                {
                    designation = "employee";
                }
                designation = value;
            }
        }

        public Manager(string name = "default", short depNo = 0, string designation = "default") : base(name, depNo)
        {
            this.DESIGNAION = designation;
        }
        public override decimal BASIC
        {
            get => basic;

            set
            {
                if (value <= 15000)
                {
                    basic = 15000;
                }

                basic = value;
            }
        }

        public override decimal CalcNetSalary()
        {
            return BASIC * 1000;
        }


        public override void Display()
        {
            base.Display();
            Console.Write(designation);
        }

        public new void insert()
        {
            throw new NotImplementedException();
        }

        public new void update()
        {
            throw new NotImplementedException();
        }

        public new void delete()
        {
            throw new NotImplementedException();
        }

        public new void create()
        {
            throw new NotImplementedException();
        }
    }

    class GeneralManager : Manager, IDBFunction
    {
        private string perks;
        public string PERKS
        {
            get { return perks; }
            set { perks = value; }
        }
        public GeneralManager(string name = "default", short depNo = 0, string designation = "default", string perks = "default") : base(name, depNo, designation)
        {
            this.PERKS = perks;
        }


        public override void Display()
        {
            base.Display();
            Console.Write(" " + PERKS);
        }

    }

    class CEO : Employee, IDBFunction
    {
        public override decimal BASIC
        {
            get => basic;
            set
            {
                if (value <= 5000)
                {
                    basic = 5000;
                }
                basic = value;
            }
        }

        public new void create()
        {
            Console.WriteLine("Create Manager");
        }

        public new void delete()
        {
            Console.WriteLine("delete Manager");
        }

        public new void insert()
        {
            Console.WriteLine("insert Manager");
        }

        public new void update()
        {
            Console.WriteLine("update Manager");
        }
        public CEO(string name = "default", short deptNo = 0) : base(name, deptNo)
        {

        }
        public sealed override decimal CalcNetSalary()
        {
            return BASIC * 1000 * 20;
        }
    }

    class Tushar : Employee
    {
        public override decimal BASIC { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override decimal CalcNetSalary()
        {
            Console.WriteLine("Ashruba Sealed Method");
            return 3;
        }
    }


}
