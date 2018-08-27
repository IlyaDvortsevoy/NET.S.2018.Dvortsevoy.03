## Задачи

1. Протестировать методы сортировки (задания первого дня) на массивах большой размерности.<br/>
[Тесты](https://github.com/IlyaDvortsevoy/NET.S.2018.Dvortsevoy.01/blob/master/Sort.Tests/UnitTest1.cs)

2. Реализовать алгоритм FindNthRoot, позволяющий вычислять корень n-ой степени ( n ∈ N ) из вещественного числа а методом Ньютона с заданной точностью. Разработать модульные тесты (NUnit и (или) MS Unit Test) для тестирования метода. Примерные тест кейсы:
    [TestCase(1, 5, 0.0001,ExpectedResult =1)]
    [TestCase(8, 3, 0.0001,ExpectedResult = 2)]
    [TestCase(0.001, 3, 0.0001,ExpectedResult = 0.1)]
    [TestCase(0.04100625,4 , 0.0001, ExpectedResult =0.45)]
    [TestCase(8, 3, 0.0001, ExpectedResult =2)]
    [TestCase(0.0279936, 7, 0.0001, ExpectedResult =0.6)]
    [TestCase(0.0081, 4, 0.1, ExpectedResult =0.3)]
    [TestCase(-0.008, 3, 0.1, ExpectedResult =-0.2)]
    [TestCase(0.004241979, 9, 0.00000001, ExpectedResult =0.545)]
    [a = -0.01, n = 2, accurancy = 0.0001] <- ArgumentException
    [a = 0.001, n = -2, accurancy = 0.0001] <- ArgumentException
    [a = 0.01, n = 2, accurancy = -1] <- ArgumentException	...<br/>
[Реализация](https://github.com/IlyaDvortsevoy/NET.S.2018.Dvortsevoy.03/blob/master/Algorithm/Algorithms.cs)
[Тесты](https://github.com/IlyaDvortsevoy/NET.S.2018.Dvortsevoy.03/blob/master/Algorithm.Tests/AlgorithmTests.cs)

3. Реализовать метод FindNextBiggerNumber, который принимает положительное целое число и возвращает ближайшее наибольшее целое, состоящее из цифр исходного числа, и null (или -1), если такого числа не существует.<br/>
Разработать модульные тесты (NUnit или MS Unit Test) для тестирования метода. Примерные тест-кейсы
    [TestCase(12, ExpectedResult = 21)]
    [TestCase(513, ExpectedResult = 531)]
    [TestCase(2017, ExpectedResult = 2071)]
    [TestCase(414, ExpectedResult = 441)]
    [TestCase(144, ExpectedResult = 414)]
    [TestCase(1234321, ExpectedResult = 1241233)]
    [TestCase(1234126, ExpectedResult = 1234162)]
    [TestCase(3456432, ExpectedResult = 3462345)]
    [TestCase(10, ExpectedResult = -1)]
    [TestCase(20, ExpectedResult = -1)]
Добавить к методу FindNextBiggerNumber возможность вернуть время нахождения заданного числа, рассмотрев различные языковые возможности. Разработать модульные тесты (NUnit или MS Unit Test) для тестирования метода.<br/>
[Реализация](https://github.com/IlyaDvortsevoy/NET.S.2018.Dvortsevoy.03/blob/master/Algorithm/Algorithms.cs)
[Тесты](https://github.com/IlyaDvortsevoy/NET.S.2018.Dvortsevoy.03/blob/master/Algorithm.Tests/AlgorithmTests.cs)

4. Выполнить сравнительный анализ скорости вычислений для реализаций алгоритма фильтрации FilterDigit с использованием строк и операции целочисленного деления на массивах большой размерности с большим количеством элементов порядка int.MaxValue.<br/>
[Реализация](https://github.com/IlyaDvortsevoy/NET.S.2018.Dvortsevoy.03/blob/master/CompareRealization/AlgorithmVariants.cs)
[Тесты](https://github.com/IlyaDvortsevoy/NET.S.2018.Dvortsevoy.03/blob/master/CompareRealization.Tests/CompareRealizationTests.cs)

5. Разработать класс, позволяющий выполнять вычисления НОД по алгоритму Евклида для двух, трех и т.д. целых чисел. Методы класса помимо вычисления НОД должны предоставлять дополнительную возможность определения значение времени, необходимое для выполнения расчета. Добавить к разработанному классу методы, реализующие алгоритм Стейна (бинарный алгоритм Евклида) для расчета НОД двух, трех и т.д. целых чисел, а также методы, предоставляющие дополнительную возможность определения значение времени, необходимое для выполнения расчета. Рассмотреть различные возможности реализации методов, возвращающих время вычисления НОД. Разработать модульные тесты.<br/>
[Реализация](https://github.com/IlyaDvortsevoy/NET.S.2018.Dvortsevoy.03/blob/master/GcdAlgorithms/Gcd.cs)
[Тесты](https://github.com/IlyaDvortsevoy/NET.S.2018.Dvortsevoy.03/blob/master/GcdAlgorithms.Tests/GcdTests.cs)
