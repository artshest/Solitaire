# Solitaire
### Примерное время выполнения задания - 12 часов.

- Паттерн MVC использовался таким образом, чтобы от Unity зависело только View. Потому Model и Controller не наследуются от MonoBehaviour и инициализируются в классе Bootstrap.
- Так как карты должны быть изначально нанесены на сцену, инициализацией карт также занимается Bootstrap. Он определяет отношения между картами на основе их очерёдности в Hierarchy на сцене. 
- Игровое поле гарантированно имеет одно решение.
