Introduction:

This project is a Treasure Chest System inspired by the mechanics of popular games like Clash Royale. It allows players to collect treasure chests by either spending in-game currency (gems) or waiting for a countdown timer to finish. Players have the option to purchase the selected treasure chest when the timer completes or expedite the process by spending additional gems. Additionally, a crucial feature of this system is the ability for players to undo their purchase if they have spent gems to buy a treasure chest.

Design Patterns:

To ensure scalability and modularity, this system is built using several design patterns:

   1 State Design Pattern: The state design pattern is employed to manage and configure the states of treasure chests. This pattern facilitates clean transitions between different states of the chests, such as idle, in progress, or completed.

   2 Model-View-Controller (MVC) Pattern: The MVC pattern is utilized for each entity in the system. The controller handles game logic, ensuring separation of concerns, while UI-related code resides in the view. This separation enhances maintainability and readability of the codebase.

   3 Command Design Pattern: The command pattern is integrated to implement the undo functionality. By encapsulating commands as objects, this pattern allows for easy reversal of player actions, such as gem expenditures for purchasing treasure chests.