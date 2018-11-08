How my program works!
-A guide by Jordan Owiesny, follow along with the requirements
--------------------------------------------------------------
basic function of program:
controller; GUI(Skeletons, Fillers, selector);  Record;

enter mainSkeleton() and to set screen, mainFilling() + mainFilling2() for the content->
using Selector() the user can choose options with limited functionality for safety ->
after user enters the cart and acknowledges there order they move onto payment ->
Payment sets up new window with new options ->
Prompt the user to enter numbers only Regex varified info ->
prints a reciept in a text file END.


1) there are 2 classes.
	-BounceHouse acts strictly as a record but does some math in 1 function
	-GUI handles all screen screen manipulation properties
	-A function in main, program(), acts as the driver commanding the GUI

2) I did exactly 12 items and atempted to make them diverse. there are 5 categories

3) The entire GUI acts as the Menu specifically the 2 methods in region 'BothSkeletons' in the
   GUI class along with the 'menu filler' region which has 3 methods.

   Both regions contain a main menu controller and a payment menu controller. 'menu filler' contains
   second main filler (one menu one body). that was neccessary to split for functionality.

4) Qualtity control is possible by repeatedly going into the 'ADD' option.

5) in the Main menu there is a constant total and quantity. Plus in the 'CART' option there is a
   subtotal and tax total.

6) Payment finalization has its own menu and allows the user to enter things

7) theres taxes

8) Cash, card, and check are all option with verifiation(located in GUI)

9) Reciept is located in the 'OUT.txt' file located in the Bin/Debug after you complete your order.

10) Prompts the user the press 'enter' to restart or any key to exit.

11) Unit tested my math and thanks to testing i changed my math function and left the original test
	for visibility. Nothing else needs to be tested on them.

12) Pushed to Git plenty