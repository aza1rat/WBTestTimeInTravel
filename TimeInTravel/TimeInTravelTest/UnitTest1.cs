using System;
using System.Windows.Forms;
using Project = TimeInTravel.Form1;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimeInTravelTest
{
    [TestClass]
    public class TimeInTravelTest_StatementCoverage
    {
        //Проверка на корректное добавление в элемент списка диапазона значений
        [TestMethod]
        public void CBChangeValues_CheckItemsValueAfterUpdate()
        {
            //Arrange
            ComboBox actual = new ComboBox();
            actual.Items.Add(1);
            actual.Items.Add(2);
            actual.Items.Add(3); //Изначально список хранит диапазон 1-3
            //Act
            Project.CBChangeValues(actual, 1, 31); //После выполнения функции список должен хранить 1-31
            //Assert
            int expected = 0;
            int value = 0;
            foreach (int element in actual.Items)
            {
                value++;
                if (element == value)
                    expected++;
            }
            Assert.IsTrue(actual.Items.Count == expected, "Количество элементов не совпадает с ожидаемым");
        }
        
        //Проверка на високосность года
        [TestMethod]
        public void CheckNotVesokosYear_TestYear()
        {
            //Arrange
            int year = 2022;
            bool expected = true;
            //Act
            bool actual = Project.CheckNotVesokosYear(year);
            //Assert
            Assert.IsTrue(expected == actual, "Вискоксность года определена неправильно");
        }

        //Проверка на определение месяца с 31 днем
        [TestMethod]
        public void DayInMouth_CheckMonthWith31Days()
        {
            //Arrange
            int expected = 31;
            int month = 2;
            int year = 2022;
            //Act
            int actual = Project.DayInMouth(month, year);
            //Assert
            Assert.IsTrue(actual == expected, "Количество дней в выбранном месяце (март) не совпадает с ожидаемым");
        }

        //Проверка на определение месяца с 30 днями
        [TestMethod]
        public void DayInMouth_CheckMonthWith30Days()
        {
            //Arrange
            int expected = 30;
            int month = 3;
            int year = 2022;
            //Act
            int actual = Project.DayInMouth(month, year);
            //Assert
            Assert.IsTrue(actual == expected, "Количество дней в выбранном месяце (апрель) не совпадает с ожидаемым");
        }

        //Проверка на определение кол-ва дней в високосном феврале
        [TestMethod]
        public void DayInMouth_CheckFebruaryWhenYearIsVesokos()
        {
            //Arrange
            int expected = 29;
            int month = 1;
            int year = 2020;
            //Act
            int actual = Project.DayInMouth(month, year);
            //Assert
            Assert.IsTrue(actual == expected, "Количество дней в феврале високосного года не совпадает с ожидаемым");
        }

        //Проверка на определение кол-ва дней в невисокосном феврале
        [TestMethod]
        public void DayInMouth_CheckFebruaryWhenYearIsNotVesokos()
        {
            //Arrange
            int expected = 28;
            int month = 1;
            int year = 2021;

            //Act
            int actual = Project.DayInMouth(month, year);
            //Assert
            Assert.IsTrue(actual == expected, "Количество дней в феврале високосного года не совпадает с ожидаемым");
        }

        //Проверка на изменение диапазона дней при взаимодействии с компонентом списком-отправление
        [TestMethod]
        public void SelectedIndexChangedTest_AddItemsInDayFrom()
        {
            //Arrange
            ComboBox month = new ComboBox();
            ComboBox year = new ComboBox();
            ComboBox daysFrom = new ComboBox();
            ComboBox daysTo = new ComboBox();
            month.Tag = "From";
            foreach(string element in Project.months)
            {
                month.Items.Add(element);
            }
            year.Items.Add(2022);
            month.SelectedIndex = 3;
            year.SelectedIndex = 0;
            //Act
            TestFunctions.SelectedIndexChangedTest(month, daysFrom, daysTo, month, year);
            //Assert
            int expected = 0;
            int value = 0;
            foreach (int element in daysFrom.Items)
            {
                value++;
                if (element == value)
                    expected++;
            }
            Assert.IsTrue(daysFrom.Items.Count == expected, "Количество добавленных элементов-дней не совпадает " +
                "с ожидаемым");

        }

        //Проверка на изменение диапазона дней при взаимодействии с компонентом списком-назначения
        [TestMethod]
        public void SelectedIndexChangedTest_AddItemsInDayTo()
        {
            //Arrange
            ComboBox month = new ComboBox();
            ComboBox year = new ComboBox();
            ComboBox daysFrom = new ComboBox();
            ComboBox daysTo = new ComboBox();
            month.Tag = "To";
            foreach (string element in Project.months)
            {
                month.Items.Add(element);
            }
            year.Items.Add(2022);
            month.SelectedIndex = 3;
            year.SelectedIndex = 0;
            //Act
            TestFunctions.SelectedIndexChangedTest(month, daysFrom, daysTo, month, year);
            //Assert
            int expected = 0;
            int value = 0;
            foreach (int element in daysFrom.Items)
            {
                value++;
                if (element == value)
                    expected++;
            }
            Assert.IsTrue(daysFrom.Items.Count == expected, "Количество добавленных элементов-дней не " +
                "совпадает с ожидаемым");

        }

        //Проверка на правильную корректировку времени в пути, если номер дня и час меньше месяца отправления
        [TestMethod]
        public void CorrectDateTest_DayAndHourFromMoreThanToWithNewMounth()
        {
            //Arrange
            DateTime From = new DateTime(1970, 1, 2, 1, 0, 0);
            DateTime To = new DateTime(1970, 2, 1, 0, 0, 0);
            int monthSkipped = 1;
            //Act
            int days = Project.CorrectDate(To, From, ref monthSkipped);
            //Assert
            Assert.IsTrue(days == 29 && monthSkipped == 0, "Разница между датами расчитана неправильно " +
                "(Должен пройти не весь месяц, так как месяц начинался со 2-го числа и 1-го часа)");

        }

        //Проверка на правильную корректировку времени в пути, если час меньше месяца отправления
        [TestMethod]
        public void CorrectDateTest_HourFromMoreThanToWithNextMonth()
        {
            //Arrange
            DateTime From = new DateTime(1970, 1, 1, 1, 0, 0);
            DateTime To = new DateTime(1970, 2, 1, 0, 0, 0);
            int monthSkipped = 1;
            //Act
            int days = Project.CorrectDate(To, From, ref monthSkipped);
            //Assert
            Assert.IsTrue(days == 0 && monthSkipped == 1, "Разница между датами расчитана неправильно " +
                "(Должен пройти весь месяц)");

        }

        //Проверка на правильную конвертацию полученного ввода в переменную DateTime
        [TestMethod]
        public void GetDateTest_TestConvertingToDate()
        {
            //Arrange
            ComboBox month = new ComboBox();
            ComboBox year = new ComboBox();
            ComboBox days= new ComboBox();
            ComboBox hours = new ComboBox();
            ComboBox min = new ComboBox();

            foreach (string element in Project.months)
            {
                month.Items.Add(element);
            }
            year.Items.Add(2022);
            days.Items.Add(1);
            hours.Items.Add(0);
            min.Items.Add(0);
            month.SelectedIndex = 0;
            year.SelectedIndex = 0;
            days.SelectedIndex = 0;
            hours.SelectedIndex = 0;
            min.SelectedIndex = 0;
            //Act
            DateTime dat = Project.GetDate(year, month, days, hours, min);
            //Assert
            Assert.IsTrue(dat == new DateTime(2022, 1, 1, 0, 0, 0), "Дата получена некорректно");
        }

        //Проверка на наличие исключения при неправильном вводе
        [TestMethod]
        public void StartClickTest_CheckCatchException()
        {
            //Arrange
            ComboBox cbNull = new ComboBox();
            string expected = "Даты указаны неверно";
            //Act
            string actual = TestFunctions.Start_ClickTest(cbNull, cbNull, cbNull, cbNull, cbNull, cbNull, cbNull,
                cbNull, cbNull, cbNull);
            //Assert
            Assert.AreEqual(expected, actual, "Функция преобразовала некорректную дату");
        }

        //Проверка на получение корректного ответа при корректном вводе
        [TestMethod]
        public void StartClickTest_CheckGettingTimeInTravel()
        {
            //Arrange
            string expected = "Прошло 1 д. 1 мес. 1 г. 1 ч. 1 мин.";

            ComboBox yearFrom = new ComboBox();
            ComboBox monthFrom = new ComboBox();
            ComboBox dayFrom = new ComboBox();
            ComboBox hourFrom = new ComboBox();
            ComboBox minFrom = new ComboBox();
            ComboBox yearTo = new ComboBox();
            ComboBox monthTo = new ComboBox();
            ComboBox dayTo = new ComboBox();
            ComboBox hourTo = new ComboBox();
            ComboBox minTo = new ComboBox();

            foreach (string element in Project.months)
            {
                monthFrom.Items.Add(element);
                monthTo.Items.Add(element);
            }
            yearFrom.Items.Add(2022); yearFrom.SelectedIndex = 0;
            yearTo.Items.Add(2023); yearTo.SelectedIndex = 0;
            dayFrom.Items.Add(1); dayFrom.SelectedIndex = 0;
            dayTo.Items.Add(2); dayTo.SelectedIndex = 0;
            hourFrom.Items.Add(0); hourFrom.SelectedIndex = 0;
            hourTo.Items.Add(1); hourTo.SelectedIndex = 0;
            minFrom.Items.Add(0); minFrom.SelectedIndex = 0;
            minTo.Items.Add(1); minTo.SelectedIndex = 0;
            monthFrom.SelectedIndex = 0;
            monthTo.SelectedIndex = 1;

            //Act
            string actual =  TestFunctions.Start_ClickTest(yearFrom, monthFrom, dayFrom, hourFrom, minFrom,
                yearTo, monthTo, dayTo, hourTo, minTo);
            //Assert
            Assert.AreEqual(expected, actual, "Неправильно посчитан срок между двумя датами");
        }

        //Проверка на наличие исключения при вводе даты назначения меньше даты отправления
        [TestMethod]
        public void StartClickTest_CheckExceptionWhenDateFromMoreThanTo()
        {
            //Arrange
            string expected = "Дата прибытия не может быть меньше даты отбытия";

            ComboBox yearFrom = new ComboBox();
            ComboBox monthFrom = new ComboBox();
            ComboBox dayFrom = new ComboBox();
            ComboBox hourFrom = new ComboBox();
            ComboBox minFrom = new ComboBox();
            ComboBox yearTo = new ComboBox();
            ComboBox monthTo = new ComboBox();
            ComboBox dayTo = new ComboBox();
            ComboBox hourTo = new ComboBox();
            ComboBox minTo = new ComboBox();

            foreach (string element in Project.months)
            {
                monthFrom.Items.Add(element);
                monthTo.Items.Add(element);
            }
            yearFrom.Items.Add(2023); yearFrom.SelectedIndex = 0;
            yearTo.Items.Add(2022); yearTo.SelectedIndex = 0;
            dayFrom.Items.Add(1); dayFrom.SelectedIndex = 0;
            dayTo.Items.Add(2); dayTo.SelectedIndex = 0;
            hourFrom.Items.Add(0); hourFrom.SelectedIndex = 0;
            hourTo.Items.Add(1); hourTo.SelectedIndex = 0;
            minFrom.Items.Add(0); minFrom.SelectedIndex = 0;
            minTo.Items.Add(1); minTo.SelectedIndex = 0;
            monthFrom.SelectedIndex = 0;
            monthTo.SelectedIndex = 1;

            //Act
            string actual = TestFunctions.Start_ClickTest(yearFrom, monthFrom, dayFrom, hourFrom, minFrom,
                yearTo, monthTo, dayTo, hourTo, minTo);
            //Assert
            Assert.AreEqual(expected, actual, "Неправильно посчитан срок между двумя датами");
        }

    }

    [TestClass]
    public class TimeInTravelTest_ConditionCoverage
    {
        //Проверка на получение корректного ответа при корректном вводе
        [TestMethod]
        public void Start_ClickTest_DateFromLessThanDateTo()
        {
            //Arrange
            string expected = "Прошло 1 д. 1 мес. 1 г. 1 ч. 1 мин.";

            ComboBox yearFrom = new ComboBox();
            ComboBox monthFrom = new ComboBox();
            ComboBox dayFrom = new ComboBox();
            ComboBox hourFrom = new ComboBox();
            ComboBox minFrom = new ComboBox();
            ComboBox yearTo = new ComboBox();
            ComboBox monthTo = new ComboBox();
            ComboBox dayTo = new ComboBox();
            ComboBox hourTo = new ComboBox();
            ComboBox minTo = new ComboBox();

            foreach (string element in Project.months)
            {
                monthFrom.Items.Add(element);
                monthTo.Items.Add(element);
            }
            yearFrom.Items.Add(2022); yearFrom.SelectedIndex = 0;
            yearTo.Items.Add(2023); yearTo.SelectedIndex = 0;
            dayFrom.Items.Add(1); dayFrom.SelectedIndex = 0;
            dayTo.Items.Add(2); dayTo.SelectedIndex = 0;
            hourFrom.Items.Add(0); hourFrom.SelectedIndex = 0;
            hourTo.Items.Add(1); hourTo.SelectedIndex = 0;
            minFrom.Items.Add(0); minFrom.SelectedIndex = 0;
            minTo.Items.Add(1); minTo.SelectedIndex = 0;
            monthFrom.SelectedIndex = 0;
            monthTo.SelectedIndex = 1;

            //Act
            string actual = TestFunctions.Start_ClickTest(yearFrom, monthFrom, dayFrom, hourFrom, minFrom,
                yearTo, monthTo, dayTo, hourTo, minTo);
            //Assert
            Assert.AreEqual(expected, actual, "Неправильно посчитан срок между двумя датами");
        }

        //Проверка на наличие исключения при вводе даты назначения меньше даты отправления
        [TestMethod]
        public void Start_ClickTest_DateFromMoreThanDateTo()
        {
            //Arrange
            string expected = "Дата прибытия не может быть меньше даты отбытия";

            ComboBox yearFrom = new ComboBox();
            ComboBox monthFrom = new ComboBox();
            ComboBox dayFrom = new ComboBox();
            ComboBox hourFrom = new ComboBox();
            ComboBox minFrom = new ComboBox();
            ComboBox yearTo = new ComboBox();
            ComboBox monthTo = new ComboBox();
            ComboBox dayTo = new ComboBox();
            ComboBox hourTo = new ComboBox();
            ComboBox minTo = new ComboBox();

            foreach (string element in Project.months)
            {
                monthFrom.Items.Add(element);
                monthTo.Items.Add(element);
            }
            yearFrom.Items.Add(2023); yearFrom.SelectedIndex = 0;
            yearTo.Items.Add(2022); yearTo.SelectedIndex = 0;
            dayFrom.Items.Add(1); dayFrom.SelectedIndex = 0;
            dayTo.Items.Add(2); dayTo.SelectedIndex = 0;
            hourFrom.Items.Add(0); hourFrom.SelectedIndex = 0;
            hourTo.Items.Add(1); hourTo.SelectedIndex = 0;
            minFrom.Items.Add(0); minFrom.SelectedIndex = 0;
            minTo.Items.Add(1); minTo.SelectedIndex = 0;
            monthFrom.SelectedIndex = 0;
            monthTo.SelectedIndex = 1;

            //Act
            string actual = TestFunctions.Start_ClickTest(yearFrom, monthFrom, dayFrom, hourFrom, minFrom,
                yearTo, monthTo, dayTo, hourTo, minTo);
            //Assert
            Assert.AreEqual(expected, actual, "Неправильно посчитан срок между двумя датами");
        }

        //Проверка на изменение диапазона дней при взаимодействии с компонентом списком-отправление
        [TestMethod]
        public void SelectedIndexChangedTest_AddItemsInDayFrom()
        {
            //Arrange
            ComboBox month = new ComboBox();
            ComboBox year = new ComboBox();
            ComboBox daysFrom = new ComboBox();
            ComboBox daysTo = new ComboBox();
            month.Tag = "From";
            foreach (string element in Project.months)
            {
                month.Items.Add(element);
            }
            year.Items.Add(2022);
            month.SelectedIndex = 3;
            year.SelectedIndex = 0;
            //Act
            TestFunctions.SelectedIndexChangedTest(month, daysFrom, daysTo, month, year);
            //Assert
            int expected = 0;
            int value = 0;
            foreach (int element in daysFrom.Items)
            {
                value++;
                if (element == value)
                    expected++;
            }
            Assert.IsTrue(daysFrom.Items.Count == expected, "Количество добавленных элементов-дней не " +
                "совпадает с ожидаемым");

        }

        //Проверка на изменение диапазона дней при взаимодействии с компонентом списком-назначение
        [TestMethod]
        public void SelectedIndexChangedTest_AddItemsInDayTo()
        {
            //Arrange
            ComboBox month = new ComboBox();
            ComboBox year = new ComboBox();
            ComboBox daysFrom = new ComboBox();
            ComboBox daysTo = new ComboBox();
            month.Tag = "To";
            foreach (string element in Project.months)
            {
                month.Items.Add(element);
            }
            year.Items.Add(2022);
            month.SelectedIndex = 3;
            year.SelectedIndex = 0;
            //Act
            TestFunctions.SelectedIndexChangedTest(month, daysFrom, daysTo, month, year);
            //Assert
            int expected = 0;
            int value = 0;
            foreach (int element in daysFrom.Items)
            {
                value++;
                if (element == value)
                    expected++;
            }
            Assert.IsTrue(daysFrom.Items.Count == expected, "Количество добавленных элементов-дней не " +
                "совпадает с ожидаемым");

        }

        //Проверка на изменение диапазона дней при взаимодействии с компонентом списком без тега
        [TestMethod]
        public void SelectedIndexChangedTest_AddItemsNotFound()
        {
            //Arrange
            ComboBox month = new ComboBox();
            ComboBox year = new ComboBox();
            ComboBox daysFrom = new ComboBox();
            ComboBox daysTo = new ComboBox();
            month.Tag = "";
            foreach (string element in Project.months)
            {
                month.Items.Add(element);
            }
            year.Items.Add(2022);
            month.SelectedIndex = 3;
            year.SelectedIndex = 0;
            //Act
            TestFunctions.SelectedIndexChangedTest(month, daysFrom, daysTo, month, year);
            //Assert
            Assert.IsTrue(daysFrom.Items.Count == 0, "Значения элементов не должны изменяться");
        }

        //Проверка на високосность года, если год не делится на 4, 100, 400
        [TestMethod]
        public void CheckNotVesokosYear_YearNotDivOn4On100On400()
        {
            //Arrange
            bool expected = true;
            //Act
            bool actual = Project.CheckNotVesokosYear(2022);
            //Assert
            Assert.AreEqual(expected, actual, "Год определен как високосный");
        }

        //Проверка на вискосность года, если год делится на 4, но не на 100 и 400
        [TestMethod]
        public void CheckNotVesokosYear_YearDivOn4NotOn100On400()
        {
            //Arrange
            bool expected = false;
            //Act
            bool actual = Project.CheckNotVesokosYear(2024);
            //Assert
            Assert.AreEqual(expected, actual, "Год определен как не високосный");
        }

        //Проверка на високосность года, если год делится на 4, 100, 400
        [TestMethod]
        public void CheckNotVesokosYear_YearDivOn4On100On400()
        {
            //Arrange
            bool expected = false;
            //Act
            bool actual = Project.CheckNotVesokosYear(2000);
            //Assert
            Assert.AreEqual(expected, actual, "Год определен как не високосный");
        }

        //Проверка на високосность года, если год делится на 4, 100, но не на 400
        [TestMethod]
        public void CheckNotVesokosYear_YearDivOn4On100NotOn400()
        {
            //Arrange
            bool expected = true;
            //Act
            bool actual = Project.CheckNotVesokosYear(1900);
            //Assert
            Assert.AreEqual(expected, actual, "Год определен как високосный");
        }

        //Проверка на определение кол-ва дней в месяце, если месяц больше 7 и является четным
        [TestMethod]
        public void DayInMouthTest_MouthMore7Chet()
        {
            //Arrange
            int expected = 30;
            //Act
            int actual = Project.DayInMouth(8, 2022);
            //Assert
            Assert.AreEqual(expected, actual, "Некорреткное определение количества дней в месяце");
        }

        //Проверка на определение кол-ва дней в месяце, если месяц 7 и является нечетным
        [TestMethod]
        public void DayInMouthTest_MouthAre7Nechet()
        {
            //Arrange
            int expected = 31;
            //Act
            int actual = Project.DayInMouth(7, 2022);
            //Assert
            Assert.AreEqual(expected, actual, "Некорреткное определение количества дней в" +
                " месяце");
        }

        //Проверка на определение кол-ва дней в месяце, если месяц четный, хотя больше 7
        [TestMethod]
        public void DayInMouthTest_ChetMouthMore7()
        {
            //Arrange
            int expected = 30;
            //Act
            int actual = Project.DayInMouth(10, 2022);
            //Assert
            Assert.AreEqual(expected, actual, "Некорреткное определение количества дней " +
                "в месяце");
        }

        //Проверка на определение кол-ва дней в месяце, если месяц меньше 7 и является нечетным
        [TestMethod]
        public void DayInMouthTest_MouthLess7Nechet()
        {
            //Arrange
            int expected = 30;
            //Act
            int actual = Project.DayInMouth(5, 2022);
            //Assert
            Assert.AreEqual(expected, actual, "Некорреткное определение количества дней в месяце");
        }

        //Проверка на определение кол-ва дней в месяце, если месяц меньше 7 и является четным
        [TestMethod]
        public void DayInMouthTest_MouthLess7Chet()
        {
            //Arrange
            int expected = 31;
            //Act
            int actual = Project.DayInMouth(4, 2022);
            //Assert
            Assert.AreEqual(expected, actual, "Некорреткное определение количества дней в " +
                "месяце");
        }

        //Проверка на определение кол-ва дней в феврале, если год не високосный
        [TestMethod]
        public void DayInMouthTest_FebruaryNotVesokos()
        {
            //Arrange
            int expected = 28;
            //Act
            int actual = Project.DayInMouth(1, 2022);
            //Assert
            Assert.AreEqual(expected, actual, "Некорреткное определение количества дней " +
                "в феврале (не високосный)");
        }

        //Проверка на определение кол-ва дней в феврале, если год високосный
        [TestMethod]
        public void DayInMouthTest_FebruaryVesokos()
        {
            //Arrange
            int expected = 29;
            //Act
            int actual = Project.DayInMouth(1, 2024);
            //Assert
            Assert.AreEqual(expected, actual, "Некорреткное определение количества дней в" +
                " феврале (високосный)");
        }

        //Проверка на отсутствие переноса времени в пути, если даты одинаковые
        [TestMethod]
        public void CorrectDateTest_WithoutPerenos()
        {
            //Arrange
            DateTime dat1 = new DateTime(2022, 2, 1, 0, 0, 0);
            DateTime dat2 = new DateTime(2022, 2, 1, 0, 0, 0);
            int monts = 0;
            //Act
            int days = Project.CorrectDate(dat1, dat2, ref monts);
            //Assert
            Assert.IsTrue(days == 0 && monts == 0, "Некорректное определение кол-ва дней " +
                "и месяцев");
        }

        //Проверка на перенос времени в пути, если дата отправления начинается на час позже
        [TestMethod]
        public void CorrectDateTest_PerenosHours()
        {
            //Arrange
            DateTime dat1 = new DateTime(2022, 2, 3, 0, 0, 0);
            DateTime dat2 = new DateTime(2022, 1, 1, 1, 0, 0);
            int monts = 1;
            //Act
            int days = Project.CorrectDate(dat1, dat2, ref monts);
            //Assert
            Assert.IsTrue(days == 1 && monts == 1, "Некорректное определение кол-ва дней " +
                "(должно быть меньше так как прошел час) и месяцев");
        }

        //Проверка на корректное отображения кол-ва дней, если день отправления и назначение 
        //одинаковый, но дата отправления на час больше
        [TestMethod]
        public void CorrectDateTest_PerenosHoursDaysIs0()
        {
            //Arrange
            DateTime dat1 = new DateTime(2022, 2, 1, 0, 0, 0);
            DateTime dat2 = new DateTime(2022, 1, 1, 1, 0, 0);
            int monts = 1;
            //Act
            int days = Project.CorrectDate(dat1, dat2, ref monts);
            //Assert
            Assert.IsTrue(days == 0 && monts == 1, "Некорректное определение кол-ва дней " +
                "(должно быть не меньше 0) и месяцев");
        }

        //Проверка на корректное отображения кол-ва дней, если не весь месяц не прошел
        [TestMethod]
        public void CorrectDateTest_PerenosDays()
        {
            //Arrange
            DateTime dat1 = new DateTime(2022, 2, 1, 0, 0, 0);
            DateTime dat2 = new DateTime(2022, 1, 3, 0, 0, 0);
            int monts = 1;
            //Act
            int days = Project.CorrectDate(dat1, dat2, ref monts);
            //Assert
            Assert.IsTrue(days == 29 && monts == 0, "Некорректное определение кол-ва дней и " +
                "месяцев (Прошел на один день меньше чем весь месяц)");
        }

        //Проверка на корректное отображения кол-ва дней, если не весь месяц прошел и отправление на час позже
        public void CorrectDateTest_PerenosDaysHours()
        {
            //Arrange
            DateTime dat1 = new DateTime(2022, 2, 1, 0, 0, 0);
            DateTime dat2 = new DateTime(2022, 1, 2, 1, 0, 0);
            int monts = 1;
            //Act
            int days = Project.CorrectDate(dat1, dat2, ref monts);
            //Assert
            Assert.IsTrue(days == 29 && monts == 0, "Некорректное определение кол-ва дней (Должно учитываться что в наступившем месяце число меньше чем предыдущий) и месяцев (Прошел на один день меньше чем весь месяц)");
        }
    }

    


        //Перенес методов, которых нельзя проверить напрямую из проекта
        public class TestFunctions
    {
        public static void SelectedIndexChangedTest(ComboBox cb, ComboBox cb_from, ComboBox cb_to, ComboBox cb_month, ComboBox cb_year)
        {
            switch (cb.Tag)
            {
                case "From": Project.CBChangeValues(cb_from, 1, Project.DayInMouth(cb_month.SelectedIndex, Convert.ToInt32(cb_year.SelectedItem))); break;
                case "To": Project.CBChangeValues(cb_to, 1, Project.DayInMouth(cb_month.SelectedIndex, Convert.ToInt32(cb_year.SelectedIndex))); break;
            }
        }

        public static string Start_ClickTest(ComboBox cb_from_year, ComboBox cb_from_month, ComboBox cb_from_day, ComboBox cb_from_hour, ComboBox cb_from_min,
            ComboBox cb_to_year, ComboBox cb_to_month, ComboBox cb_to_day, ComboBox cb_to_hour, ComboBox cb_to_min)
        {
            string result;
            DateTime dateFrom = new DateTime();
            DateTime dateTo = new DateTime();
            try
            {
                dateFrom = Project.GetDate(cb_from_year, cb_from_month, cb_from_day, cb_from_hour, cb_from_min);
                dateTo = Project.GetDate(cb_to_year, cb_to_month, cb_to_day, cb_to_hour, cb_to_min);
            }
            catch
            {
                MessageBox.Show("Даты указаны неверно");
                return "Даты указаны неверно";
            }
            if (dateFrom <= dateTo)
            {
                TimeSpan skipped = dateTo - dateFrom;
                int showMonths = (dateTo.Month - dateFrom.Month) + 12 * (dateTo.Year - dateFrom.Year);
                int showDays = Project.CorrectDate(dateTo, dateFrom, ref showMonths);
                int showYears = showMonths / 12;
                showMonths = showMonths % 12;
                result = $"Прошло {showDays} д. " +
                    $"{showMonths} мес. " +
                    $"{showYears} г. " +
                    $"{skipped.Hours} ч. " +
                    $"{skipped.Minutes} мин.";
                MessageBox.Show($"Прошло {showDays} д. " +
                    $"{showMonths} мес. " +
                    $"{showYears} г. " +
                    $"{skipped.Hours} ч. " +
                    $"{skipped.Minutes} мин.");
            }
            else
            {
                result = "Дата прибытия не может быть меньше даты отбытия";
                MessageBox.Show("Дата прибытия не может быть меньше даты отбытия");
            }
            return result;
        }

        
    }
}
