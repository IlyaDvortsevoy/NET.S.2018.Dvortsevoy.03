﻿1) Реализовать алгоритм FindNthRoot, позволяющий вычислять корень n-ой степени ( n ∈ N ) из вещественного числа а методом Ньютона с заданной точностью. Разработать модульные тесты (NUnit и (или) MS Unit Test) для тестирования метода. Примерные тест кейсы:

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
[a = 0.01, n = 2, accurancy = -1] <- ArgumentException	...

Рекомендованный шаблон для тестового метода проверки исключений.
MethodName_Number_Degree_Precision_ArgumentOutOfRangeException(double number, int degree, double precision, double expected) => Assert.Throws(() => ClassName.MethodName(number, degree, precision));

2) выполнить сравнительный анализ скорости вычислений для реализаций алгоритмов с использованием строк и операции целочисленного деления для задачи #6 на массивах большой размерности с большим количеством элементов порядка int.MaxValue.

3) Разработать класс, позволяющий выполнять вычисления НОД по алгоритму Евклида для двух, трех и т.д. целых чисел (http://en.wikipedia.org/wiki/Euclidean_algorithm , https://habrahabr.ru/post/205106/, https://habrahabr.ru/post/205106/ ). Методы класса помимо вычисления НОД должны предоставлять дополнительную возможность определения значение времени, необходимое для выполнения расчета. Добавить к разработанному классу методы, реализующие алгоритм Стейна (бинарный алгоритм Евклида) для расчета НОД двух, трех и т.д. целых чисел (http://en.wikipedia.org/wiki/Binary_GCD_algorithm, https://habrahabr.ru/post/205106/ ), а также методы, предоставляющие дополнительную возможность определения значение времени, необходимое для выполнения расчета. Рассмотреть различные возможности реализации методов, возвращающих время вычисления НОД. Разработать модульные тесты.