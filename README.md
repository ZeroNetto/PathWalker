# PathWalker
Бот, который ищет приключений, но пользователь не разрешает

## Управление:
  * WASD - перемещение камеры
  * QE - поворот камеры
  * Scroll - зум камеры

## Что умеет:
  * Ходить по заданному пользователем пути(в формате json)
  * Сглаживать траекторию, добавляя кривые Безье(если в пути есть хотя бы 4 точки)
  * Зацикливаться
  * Качать Json-ы с Яндекс диска(если не будет ограничено количество скачиваний)
  * Примерно расчитывать скорость, необходимое для прохождения пути за заданное пользователем время

## Как поиграться с вводом:
  1) Найти файл patn*.txt (лучше для первой сцены "path1.txt", ибо выключил закачку с Яндекс Диска из-за лимита)
  2) Поменять внутренний Json
  3) Profit!
