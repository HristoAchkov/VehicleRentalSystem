First, I started by creating the Vehicle class and filled it with the common properties of the three class I wanted to inherit it. Then i made the Car, Motorcycle and Cargo Van classes and added their unique attributes.
 
Then, I created the Invoice class and filled it with the needed properties and fields. 

I was wondering between three different approaches about the business logic which were:

-Should I use the Program.cs extensively and write the methods and variables there.

-Should I use the Vehicle class extensively, do the calculations there and keep the Invoice class and Program.cs relatively clean.

-Should I use the Invoice class for the methods and calculations, thus keeping the Vehicle class relatively clean and the Program.cs almost empty.

Ultimately, I decided, I should use the Invoice class, because I wanted the code to look more readable and clean. I injected a Vehicle and used its attributes for the calculations.

Then, I started writing the business logic, following the order in which the business rules were written.

Next, I tested with the given inputs, used some custom inputs, as well, got the correct results and that was basically it.