\# Unity Slot Machine



\## Game Overview



A slot machine game developed in Unity as part of a technical assessment. The game features animated slot reels, random symbol generation, win detection, payouts, a credits system, a win popup, and an exit confirmation popup.



\## Features



\* Animated slot machine reels

\* Randomized symbol outcomes

\* Win detection for matching symbols

\* Credits and payout system

\* Lever-based spin interaction

\* Win popup notification

\* Exit confirmation popup

\* WebGL build included



\## Controls



\* Click the Lever to spin the reels

\* Click the Exit button to open the exit confirmation popup

\* Select Yes to exit or No to continue playing



\## Winning Combinations \& Payouts



\* Bell Bell Bell = 20 Credits

\* Cherry Cherry Cherry = 30 Credits

\* Bar Bar Bar = 50 Credits

\* Seven Seven Seven = 100 Credits



\## Running the WebGL Build



The WebGL build is located in:



Build/WebGL



To run locally, host the folder using a local web server such as:



\* VS Code Live Server

\* Python HTTP Server



Example:



python -m http.server 8000



Then open:



http://localhost:8000



\## Bonus Features



\* Win popup displaying payout amount

\* Exit confirmation popup

\* Credit tracking system

\* Lever state switching



\## Development Approach



The project was built using a modular architecture with separate systems for reel spinning, symbol management, payout calculation, lever interaction, credits management, and UI handling. The reels use looping symbol strips and randomized outcomes to simulate a traditional slot machine experience.



