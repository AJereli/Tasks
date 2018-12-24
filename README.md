# Tasks

# QSort
Алгоритм быстрой сортировки работающий за O(n*log(n))
Являет расширением для стандартного перечесляемого типа С# (IEnumerable). Использует вывод типа Generic.
Для сортировки использует либо оператор сравнения определенный для типа T, либо кастомный компаратор для типа T. Который можно опционально указать.

В качестве массива данных испльзует массив структур CoolMan (int Score, string Name) в формате JSON
Результат сортировки по очкам

QSorting TASK

Name: Rik
Score: 150
---
Name: Morty
Score: 120
---
Name: Sasha
Score: 105
---
Name: Alex
Score: 32
---
Name: Rik
Score: 30
---
Name: Den
Score: 10
---
Name: Richard
Score: 10
---
Name: Nik
Score: 1
---

QSorting TASK

Name: Auto5
Score: 121230
---
Name: Auto8
Score: 112305
---
Name: Auto
Score: 32222
---
Name: Auto6
Score: 30123
---
Name: Auto3
Score: 13250
---
Name: Auto7
Score: 11230
---
Name: Auto4
Score: 1330
---
Name: Auto2
Score: 231
---
Исходные массивы:
CollMans:
[{"Score":32,"Name":"Alex"},{"Score":1,"Name":"Nik"},{"Score":105,"Name":"Sasha"},{"Score":30,"Name":"Rik"},{"Score":150,"Name":"Rik"},{"Score":10,"Name":"Richard"},{"Score":10,"Name":"Den"},{"Score":120,"Name":"Morty"}]

Autos:

[{"Price":32222,"Title":"Auto"},{"Price":231,"Title":"Auto2"},{"Price":112305,"Title":"Auto8"},{"Price":30123,"Title":"Auto6"},{"Price":13250,"Title":"Auto3"},{"Price":11230,"Title":"Auto7"},{"Price":1330,"Title":"Auto4"},{"Price":121230,"Title":"Auto5"}]

# Заполнение массива NxM спиралькой
Для решения этой задачи был реализован простой алгоритм "В лоб". 
Для улучшения производительности использует простой двумерный массив.
Для улучшения читабельности кода используется перечесление SnakeDirrection

Пример для матрица 3 на 3

0 1 2 
7 8 3 
6 5 4 

SNAKE
0 1 2 3 4 
15 16 17 18 5 
14 23 24 19 6 
13 22 21 20 7 
12 11 10 9 8 


# Ранжирование результатов запроса в базе данных документа 

В качестве базы документов использовалась выборка описани фильмов за 2018 год. 
Ранжирование происходит за линейное время, результаты сортируются в порядке убывания.
