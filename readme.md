# Unity Hackbase
## How does it work
The Code you write in Unity is getting compiled to IL. which then gets "compiled" on runtime. IL is easily reversable and editeable.
Im Exploiting that. The base concept of this base is that it has minimal interaction with the game which leads to minimal maintenance costs.
### How do you get it to work
First you need to get either a hold of my ILPatcher (become moderator to gain access to that ;) ) or get yourself ilpatcher/.net reflector with reflexil. Then find a class bzw. a function that is getting called at the start or where you want the base to get initialized.
In the method you just place a call to the static init function of the hack.
then just add some stuff as reference and get coding with my base.