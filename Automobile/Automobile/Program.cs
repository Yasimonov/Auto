using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        //класс исключения, для улавливания ошибок неверно введеных параметров
        class AutoParamsException : Exception
        {
            //конструктуры класса ислючения
            public AutoParamsException() { }
            //msg - сообщение об ошибке
            public AutoParamsException(string msg) : base(msg) { }
        }
        //класс автомобиля
        class auto
        {
            public int MaxSpeed
            {
                get;
                private set; // гарантирует, что свойство можно задать только внутри класса
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
            //конструктор класса auto
            public auto(int max_speed, int boost_speed, int engine_power, int pass_places)
            {
                if (max_speed < 0 || boost_speed < 0 || engine_power < 0 || pass_places < 0)
                    throw new AutoParamsException("Negative values"); //кидается исключение, из-за того
                                                                      //введены отрицательные значения
                //задание параметров автомобиля
                this.MaxSpeed = max_speed;
                this.BoostSpeed = boost_speed;
                this.EnginePower = engine_power;
                this.PassPlaces = pass_places;
                //проверка параметров автомобиля
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
            //стандартные функции проверки параметров
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
        
        class light : auto //класс, задающий легковой автомобиль
        {
            //конструктор класа, который наследуется от конструктора auto
            public light(int max_speed, int boost_speed, int engine_power, int pass_places) : base(max_speed, boost_speed, engine_power, pass_places) { }
            //специфические функции проверки параметров легкого автомобиля
            //являются перегруженными функциями класса auto
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
        
        class coupe : light //класс, задающий автомобиль класса coupe,
                            //является наследником класса light
        {
            public coupe(int max_speed, int boost_speed, int engine_power, int pass_places) : base(max_speed, boost_speed, engine_power, pass_places) { }
            //специфические функции проверки параметров автомобиля класса coupe
            //являются перегруженными функциями класса auto
            public override bool check_num_pass()
            {
                return this.PassPlaces == 2;
            }
        }
        class sedan : light //класс, задающий автомобиль класса sedan,
                            //является наследником класса light
        {
            public sedan(int max_speed, int boost_speed, int engine_power, int pass_places) : base(max_speed, boost_speed, engine_power, pass_places) { }
        }
        class cabriolet : light
        {
            public cabriolet(int max_speed, int boost_speed, int engine_power, int pass_places) : base(max_speed, boost_speed, engine_power, pass_places) { }
            //специфические функции проверки параметров автомобиля класса sedan
            //являются перегруженными функциями класса auto
            public override bool check_engine_power()
            {
                return this.EnginePower <= 400;
            }
            public override bool check_num_pass()
            {
                return this.PassPlaces <= 4;
            }
        }
        class heavy : auto //класс, задающий грузовой автомобиль
        {
            public heavy(int max_speed, int boost_speed, int engine_power, int pass_places) : base(max_speed, boost_speed, engine_power, pass_places) { }
            //специфические функции проверки параметров грузового автомобиля
            //являются перегруженными функциями класса auto
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
        class bus : heavy //класс, задающий автомобиль класса автобус,
                          //является наследником класса heavy
        {
            public bus(int max_speed, int boost_speed, int engine_power, int pass_places) : base(max_speed, boost_speed, engine_power, pass_places) { }
            //специфические функции проверки параметров автобуса
            //являются перегруженными функциями класса auto
            public override bool check_num_pass()
            {
                return this.PassPlaces <= 100;
            }
        }
        class van : heavy //класс, задающий автомобиль класса van,
                          //является наследником класса heavy
        {
            public van(int max_speed, int boost_speed, int engine_power, int pass_places) : base(max_speed, boost_speed, engine_power, pass_places) { }
            //специфические функции проверки параметров класса van
            //являются перегруженными функциями класса auto
            public override bool check_num_pass()
            {
                return this.PassPlaces <= 12;
            }
        }
        class lorry : heavy //класс, задающий автомобиль класса грузовик,
                            //является наследником класса heavy
        {
            public lorry(int max_speed, int boost_speed, int engine_power, int pass_places) : base(max_speed, boost_speed, engine_power, pass_places) { }
            //специфические функции проверки параметров класса грузовик
            //являются перегруженными функциями класса auto
            public override bool check_num_pass()
            {
                return this.PassPlaces <= 4;
            }
        }
        class speed : auto //класс, задающий гоночный автомобиль
        {
            public speed(int max_speed, int boost_speed, int engine_power, int pass_places) : base(max_speed, boost_speed, engine_power, pass_places) { }
            //специфические функции проверки параметров класса гоночного автомобиля
            //являются перегруженными функциями класса auto
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
            //проверка, что все нормально
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