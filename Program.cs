﻿//a program in c# which solves the problem of  
//hanoi towers both recursively and iteratively
using System;
//coded and solved by mohammad safari:)
//objectively and described step by step
class Program
{
    //redefine a better stack class so that can
    //help us solve the problem easier(as i think, i hope :))
    class Stack
    {
        //stack name used in output
        private char name;
        public char Name { get { return name; } }
        //cap as capacity of stack, is max 
        //possible elements or total disks in hanoi
        //imp: should be valued carefully!!
        public static int cap = 10;
        //top is the num of highest element or disk 
        //initailized zero
        private int top = 0;
        //Top prop for getting result out, after internal 
        //changes of field top - only depending on push & pop
        public int Top
        {
            get { return top; }
        }
        //main part of stack
        //actually stack body sized by cap
        //thats why cap should be valued carefully
        private int[] stk = new int[cap];
        //actually for informing us exactly which
        //disk is the top disk!
        public int Top_Dsk
        {
            get { return stk[top - 1]; }
        }
        //a constructor for initializing stack body
        // with zeros (due to comparisons in hanoi class)
        //i think we need but you can check if needed!(:
        public Stack(char c)
        {
            name = c;
            for (int i = 0; i < Stack.cap; i++)
                stk[i] = 0;
        }
        //pushes element or disk top of the stack(array)
        //if only possible(:
        public void push(int dsk)
        {
            if (top < cap)
                stk[top++] = dsk;
        }
        //pops the last element(top_dsk) and returns it
        //then filling it with zero and decreasing top field
        //again if only possible(:
        public int pop()
        {
            if (top > 0)
            {
                int temp = stk[--top];
                stk[top] = 0;
                return temp;
            }
            return 0;
        }
    }
    //a class that bring us to hanoi world!;)
    //lets make it larger so we can fit it!!
    static class Hanoi
    {
        private static Stack a = new Stack('A');
        private static Stack b = new Stack('B');
        private static Stack c = new Stack('C');
        public static Stack A { get { return a; } }
        public static Stack B { get { return b; } }
        public static Stack C { get { return c; } }

        //the disk num should be valued before 
        //anything refers to stack.cap which shows here 
        //both capacity and disk num
        public static void set_disk_num(int n)
        {
            Stack.cap = n;
        }
        //setting the first pole
        //tip: disk are mentioned by nums 1(also the least possible)
        //to stack.cap(the largest possible disk) and
        //obviusly they are unique(in move function they are moving only! 
        //like birds but not breeding:|)
        public static void initialize_Hanoi(Stack A)
        {
            for (int i = 0; i < Stack.cap; i++)
                A.push(Stack.cap - i);
        }
        //graphing our towers(comming soon!!)
        public static void graph_hanoi(Stack A, Stack B, Stack C) { }
        //the main rules of moving:)
        public static void Correct_Move(Stack A, Stack B)
        {
            //first to authorize move to empty stack or pole 
            if (A.Top == 0)
            {
                A.push(B.pop());
                Console.WriteLine("disk " + A.Top_Dsk + " from " + B.Name + " to " + A.Name);
            }
            else if (B.Top == 0)
            {
                B.push(A.pop());
                Console.WriteLine("disk " + B.Top_Dsk + " from " + A.Name + " to " + B.Name);
            }
            //else check which disk is larger which can be pushed!!
            //and made the other poped!
            else if (A.Top_Dsk > B.Top_Dsk)
            {
                A.push(B.pop());
                Console.WriteLine("disk " + A.Top_Dsk + " from " + B.Name + " to " + A.Name);
            }
            else if (B.Top_Dsk > A.Top_Dsk)
            {
                B.push(A.pop());
                Console.WriteLine("disk " + B.Top_Dsk + " from " + A.Name + " to " + B.Name);
            }
        }
        //the easier (i insist very easier way) to understand
        //that almost doesnt need any of the above :(
        //BUT not optimized and dynamic
        public static void Solve_Recursive(int n, char A = 'A', char B = 'B', char C = 'C')
        {
            //base condition(really obvious to explain!!)
            if (n == 1)
            {
                //this really means a simple move :\ because
                // all rules are considered in recursion!! 
                Console.WriteLine("move the last disk of " + A + " to " + C);
                return;
            }
            //a correct move of top n-1 disk to mid pole(not any more one disk necessarily)
            //the function can compromise with itself how to do a correct move :)
            //good function(actually for us not computers!), no?:)
            Solve_Recursive(n - 1, A, C, B);
            {
                //it is the move of last disk toward destinaton!
                Console.WriteLine("move the last disk of " + A + " to " + C);
            }
            //moving correctly all disk of mid pole toward dest!
            //again it understand how! how ? holly recursion!:\
            Solve_Recursive(n - 1, B, A, C);
        }
        //the iterative way(after having carefully trace the 
        //recursive one and finding relations of sequence of moves)
        //Optimized, Dynamic, and i guess the expanded one :)
        public static void Solve_Iterative(Stack A, Stack B, Stack C)
        {
            //first move is depending on odd or even being of
            //disk numbers so i decide to define
            //function default solve is for odd num of disks 
            if (Stack.cap % 2 == 0)
            {
                //adjusting solution  for even disks
                Stack temp = C;
                C = B;
                B = temp;
            }
            //carefully investigating recursive function let us know
            //that every n disk need 2^n -1 move to solve
            int move_num = (int)Math.Pow(2, Stack.cap) - 1;
            for (int i = 1; i <= move_num; i++)
            {
                Console.WriteLine(i + "th move:");
                switch (i % 3)
                {
                    //for odd disk nums the sequence show 3n+1 th move is always
                    //between first pole and third one(even nums first and second)
                    //by move i mean correct move!!
                    case 1:
                        Correct_Move(A, C);
                        break;
                    // for odd disk nums 3n+2 th move between first and second
                    // for even between first and third
                    case 2:
                        Correct_Move(A, B);
                        break;
                    // for both odd and even disk nums 3n th move between second and third
                    //but remember correct move!!
                    case 0:
                        Correct_Move(B, C);
                        break;
                }
            }

        }
    }
    //and at last we will have to use our Hanoi Class to juggle?!
    //coded and solved by mohammad safari!:\
    static void Main(string[] args)
    {
        Console.WriteLine("\nEnter disk numbers, please:");
        //told that cap is important:\
        //(may be not that important, just my gut feelings:|)
        int n = Convert.ToInt32(Console.ReadLine());
        Hanoi.set_disk_num(n);
        Hanoi.initialize_Hanoi(Hanoi.A);
        Hanoi.Solve_Iterative(Hanoi.A, Hanoi.B, Hanoi.C);
        //da dan...!:)
        //by m. safari
        //hope you enjoy!
        //only for comparison:
        //Hanoi.Solve_Recursive(n);
        //p.s : recursive one only lack disk num that we can
        //perform it by arrays that i thought might not be
        //necessary for comparing

    }
}