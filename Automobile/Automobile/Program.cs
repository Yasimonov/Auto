using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        class AutoParamsException : Exception
        {
            public AutoParamsException() { }
            public AutoParamsException(string msg) : base(msg) { }
        }
        class auto
        {
            public int MaxSpeed
            {
                get;
                private set;
            }
            public int EnginePower
            {
                get;
                private set;
            }
            public int BoostSpeed
            {
                get;
                private set;
            }
            public int PassPlaces
            {
                get;
                private set;
            }
            public auto(int max_speed, int boost_speed, int engine_power, int pass_places)
            {
                //                create(max_speed, boost_speed, engine_power, pass_places);
                if (max_speed < 0 || boost_speed < 0 || engine_power < 0 || pass_places < 0)
                    throw new AutoParamsException("Negative values");
                this.MaxSpeed = max_speed;
                this.BoostSpeed = boost_speed;
                this.EnginePower = engine_power;
                this.PassPlaces = pass_places;
                if (!check_max_speed())
                    throw new AutoParamsException("Wrong max speed");
                if (!check_boost_speed())
                    throw new AutoParamsException("Wrong boost speed");
                if (!check_engine_power())
                    throw new AutoParamsException("Wrong engine power");
                if (!check_num_pass())
                    throw new AutoParamsException("Wrong number if passengers places");
            }
            public void print()
            {
            }
            public virtual bool check_max_speed()
            {
                return this.MaxSpeed >= 0;
            }
            public virtual bool check_boost_speed()
            {
                return this.BoostSpeed >= 0;
            }
            public virtual bool check_engine_power()
            {
                return this.EnginePower >= 0;
            }
            public virtual bool check_num_pass()
            {
                return this.PassPlaces >= 0;
            }

        }

        class light : auto //легковая
        {
            public light(int max_speed, int boost_speed, int engine_power, int pass_places) : base(max_speed, boost_speed, engine_power, pass_places) { }
            public override bool check_max_speed()
            {
                return this.MaxSpeed <= 220;
            }
            public override bool check_boost_speed()
            {
                return this.BoostSpeed <= 5;
            }
            public override bool check_engine_power()
            {
                return this.EnginePower <= 500;
            }
            public override bool check_num_pass()
            {
                return this.PassPlaces <= 7;
            }
        }
        class coupe : light
        {
            public coupe(int max_speed, int boost_speed, int engine_power, int pass_places) : base(max_speed, boost_speed, engine_power, pass_places) { }
            public override bool check_num_pass()
            {
                return this.PassPlaces == 2;
            }
        }
        class sedan : light
        {
            public sedan(int max_speed, int boost_speed, int engine_power, int pass_places) : base(max_speed, boost_speed, engine_power, pass_places) { }
        }
        class cabriolet : light
        {
            public cabriolet(int max_speed, int boost_speed, int engine_power, int pass_places) : base(max_speed, boost_speed, engine_power, pass_places) { }
            public override bool check_engine_power()
            {
                return this.EnginePower <= 400;
            }
            public override bool check_num_pass()
            {
                return this.PassPlaces <= 4;
            }
        }
        class heavy : auto
        {
            public heavy(int max_speed, int boost_speed, int engine_power, int pass_places) : base(max_speed, boost_speed, engine_power, pass_places) { }
            public override bool check_max_speed()
            {
                return this.MaxSpeed <= 180;
            }
            public override bool check_boost_speed()
            {
                return this.BoostSpeed >= 10;
            }
            public override bool check_engine_power()
            {
                return this.EnginePower <= 300;
            }
        }
        class bus : heavy
        {
            public bus(int max_speed, int boost_speed, int engine_power, int pass_places) : base(max_speed, boost_speed, engine_power, pass_places) { }
            public override bool check_num_pass()
            {
                return this.PassPlaces <= 100;
            }
        }
        class van : heavy
        {
            public van(int max_speed, int boost_speed, int engine_power, int pass_places) : base(max_speed, boost_speed, engine_power, pass_places) { }
            public override bool check_num_pass()
            {
                return this.PassPlaces <= 12;
            }
        }
        class lotry : heavy
        {
            public lotry(int max_speed, int boost_speed, int engine_power, int pass_places) : base(max_speed, boost_speed, engine_power, pass_places) { }
            public override bool check_num_pass()
            {
                return this.PassPlaces <= 4;
            }
        }
        class speed : auto
        {
            public speed(int max_speed, int boost_speed, int engine_power, int pass_places) : base(max_speed, boost_speed, engine_power, pass_places) { }
            public override bool check_max_speed()
            {
                return this.MaxSpeed >= 250;
            }
            public override bool check_boost_speed()
            {
                return this.BoostSpeed <= 4;
            }
            public override bool check_engine_power()
            {
                return this.EnginePower >= 300;
            }
            public override bool check_num_pass()
            {
                return this.PassPlaces == 0;
            }
        }
        static void Main(string[] args)
        {
            try
            {
                auto t = new bus(1, 1, 1, 1);
            }
            catch (AutoParamsException e)
            {
            }
        }
    }
}