# Тестовое задание Junior/Middle C# для Mindbox

## Вопрос №1
Разместите код на Github и приложите ссылку. Если в задании что-то непонятно, опишите возникшие вопросы и сделанные предположения. Например, в комментариях в коде.

Задание:
Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам. Дополнительно к работоспособности оценим:
* Юнит-тесты
* Легкость добавления других фигур
* Вычисление площади фигуры без знания типа фигуры в compile-time
* Проверку на то, является ли треугольник прямоугольным

###### Решение находится в проекте Mindbox. Юнит тесты для решения находятся в проекте Mindbox.Tests
###### Решение задачи является крайней степенью оверинженеринга, в связи с чем, копирование не рекомендуется никому ¯\\_(ツ)_/¯

## Вопрос №2

В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.
По возможности — положите ответ рядом с кодом из первого вопроса.

###### Не хочется засорять код неиспользуемым текстовым файлом. Решение прикладываю ниже:
```
/*CREATE TABLE products (id INTEGER, name VARCHAR(20));
CREATE TABLE categories (id INTEGER, name VARCHAR(20));
CREATE TABLE products_categories (id INTEGER, product_id INTEGER, category_id INTEGER);

INSERT INTO products VALUES
(1, 'product_1'),
(2, 'product_2');

INSERT INTO categories VALUES
(1, 'category_1'),
(2, 'category_2'),
(3, 'category_3');

INSERT INTO products_categories VALUES
(1, 1, 1),
(2, 1, 2);*/

SELECT p.name, c.name 
FROM products p
LEFT JOIN products_categories pc ON p.id = pc.product_id
LEFT JOIN categories c ON pc.category_id = c.id;
```
