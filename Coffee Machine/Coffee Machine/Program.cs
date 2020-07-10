using System;

namespace Coffee_Machine
{
    class Program
    {
        static void Main(string[] args)
        {

            // Amount of required items to make coffee
            int waterAmount = 400;
            int milkAmount = 540;
            int coffeeBeans = 120;
            int disposableCups = 9;
            int money = 550;

            //CoffeeCupCalculator();
            CoffeeActions(ref waterAmount, ref milkAmount, ref coffeeBeans, ref disposableCups, ref money);
        }

        public static void CoffeeItemsCalculator(int coffeeCup)
        {
            int waterAmount = 200 * coffeeCup;
            int milkAmount = 50 * coffeeCup;
            int coffeeBean = 15 * coffeeCup;

            Console.WriteLine("For {0} cups of coffee you will need:", coffeeCup);
            Console.WriteLine("{0} ml of water", waterAmount);
            Console.WriteLine("{0} ml of milk", milkAmount);
            Console.WriteLine("{0} g of coffee beans", coffeeBean);
        }

        public static void CoffeeCupCalculator()
        {
            Console.WriteLine("Write how many ml of water the coffee machine has:");
            int waterAmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write how many ml of milk the coffee machine has:");
            int milkAmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write how many grams of coffee beans the coffee machine has:");
            int coffeeBean = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write how many cups of coffee you will need:");
            int requiredCoffeeCups = Convert.ToInt32(Console.ReadLine());

            int possibleCoffeeCups = 0;
            while(waterAmount >= 200 && milkAmount >= 50 && coffeeBean >= 15)
            {
                    possibleCoffeeCups++;
                    waterAmount = waterAmount - 200;
                    milkAmount = milkAmount - 50;
                    coffeeBean = coffeeBean - 15;
            }

            if(requiredCoffeeCups < possibleCoffeeCups)
            {
                Console.WriteLine("Yes, I can make that amount of coffee (and even {0} more than that).",
                    Math.Abs(possibleCoffeeCups-requiredCoffeeCups));
            }
            else if(requiredCoffeeCups > possibleCoffeeCups)
            {
                Console.WriteLine("No, I can make only {0} cup(s) of coffee.", possibleCoffeeCups);
            }
            else if(requiredCoffeeCups == possibleCoffeeCups)
            {
                Console.WriteLine("Yes, I can make that amount of coffee.");
            }
        }

        public static void CoffeeActions( ref int waterAmount, ref int milkAmount,
            ref int coffeeBeans, ref int  disposableCups, ref int money)
        {
            string coffeeActionSwitch;
            Console.WriteLine("Write action (buy, fill, take, remaining, exit:)");
            coffeeActionSwitch = Console.ReadLine();

            switch (coffeeActionSwitch)
            {
                case "buy":

                    Console.WriteLine("What do you want to buy? 1 - espresso, 2 - latte, 3 - cappuccino, back- to main menu:");
                    string coffeeBuySwitch = Console.ReadLine();
                    CoffeeTypes(ref waterAmount, ref milkAmount, ref coffeeBeans, ref disposableCups, ref money,  coffeeBuySwitch);
                    CoffeeActions(ref waterAmount, ref milkAmount, ref coffeeBeans, ref disposableCups, ref money);
                    break;

                case "fill":

                    Console.WriteLine("Write how many ml of water do you want to add:");
                    waterAmount = waterAmount + Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Write how many ml of milk do you want to add:");
                    milkAmount = milkAmount + Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Write how many grams of  coffee beans do you want to add:");
                    coffeeBeans = coffeeBeans + Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Write how many disposable cups of coffee do you want to add:");
                    disposableCups = disposableCups+ Convert.ToInt32(Console.ReadLine());

                    CoffeeActions(ref waterAmount, ref milkAmount, ref coffeeBeans, ref disposableCups, ref money);
                    break;

                case "take":

                    Console.WriteLine("I gave you ${0}\n", money);
                    money = 0;
                    CoffeeActions(ref waterAmount, ref milkAmount, ref coffeeBeans, ref disposableCups, ref money);
                    break;

                case "remaining":
                    CoffeeMachineState(ref waterAmount, ref milkAmount,
                        ref coffeeBeans, ref disposableCups, ref money);
                    CoffeeActions(ref waterAmount, ref milkAmount, ref coffeeBeans, ref disposableCups, ref money);
                    break;

                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("You entered wrong action. Please select correct action again! ");
                    CoffeeActions(ref waterAmount, ref milkAmount, ref coffeeBeans, ref disposableCups, ref money);
                    break;


            }
        }

        public static void CoffeeMachineState(ref int waterAmount, ref int milkAmount, ref int coffeeBeans, ref int disposableCups, ref int money)
        {
            Console.WriteLine("The coffee machine has:");
            Console.WriteLine("{0} of water", waterAmount);
            Console.WriteLine("{0} of milk", milkAmount);
            Console.WriteLine("{0} of coffee beans", coffeeBeans);
            Console.WriteLine("{0} of disposable cups", disposableCups);
            Console.WriteLine("{0} of money", money);
        }

        public static void CoffeeTypes(ref int waterAmount, ref int milkAmount, ref int coffeeBeans, ref int disposableCups, ref int money, string coffeeType)
        {
            switch(coffeeType)
            {
                case "1":
                    if (waterAmount >= 250 && coffeeBeans >= 16 && disposableCups >= 1)
                    {
                        money = money + 4;
                        waterAmount = waterAmount - 250;
                        coffeeBeans = coffeeBeans - 16;
                        disposableCups = disposableCups - 1;
                        Console.WriteLine("I have enough resources, making you a coffee!");
                    }
                    else if (waterAmount < 250)
                    {
                        Console.WriteLine("Sorry, not enough water!");
                    }
                    else if (coffeeBeans < 16)
                    {
                        Console.WriteLine("Sorry, not enough coffee beans!");
                    }
                    break;

                case "2":
                    if (waterAmount >= 350 && milkAmount >= 75 && coffeeBeans >= 20 && disposableCups >= 1)
                    {
                        money = money + 7;
                        waterAmount = waterAmount - 350;
                        milkAmount = milkAmount - 75;
                        coffeeBeans = coffeeBeans - 20;
                        disposableCups = disposableCups - 1;
                        Console.WriteLine("I have enough resources, making you a coffee!");
                    }
                    else if (waterAmount < 350)
                    {
                        Console.WriteLine("Sorry, not enough water!");
                    }
                    else if(milkAmount < 75)
                    {
                        Console.WriteLine("Sorry, not enough milk!");
                    }
                    else if (coffeeBeans < 26)
                    {
                        Console.WriteLine("Sorry, not enough coffee beans!");
                    }
                    break;
                case "3":
                    if (waterAmount >= 200 && milkAmount >= 100 && coffeeBeans >= 12 && disposableCups >= 1)
                    {
                        money = money + 6;
                        waterAmount = waterAmount - 200;
                        milkAmount = milkAmount - 100;
                        coffeeBeans = coffeeBeans - 12;
                        disposableCups = disposableCups - 1;
                        Console.WriteLine("I have enough resources, making you a coffee!");
                    }
                    else if (waterAmount < 200)
                    {
                        Console.WriteLine("Sorry, not enough water!");
                    }
                    else if (milkAmount < 100)
                    {
                        Console.WriteLine("Sorry, not enough milk!");
                    }
                    else if (coffeeBeans < 12)
                    {
                        Console.WriteLine("Sorry, not enough coffee beans!");
                    }
                    break;
                case "back":
                    CoffeeActions(ref waterAmount, ref milkAmount, ref coffeeBeans, ref disposableCups, ref money);
                    break;

            }



        }
    }
}
