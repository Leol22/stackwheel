<h1>stackwheel</h1>
stackwheel is an esoteric programming language made in 1 hour 15 minutes (the time i had available during class). The documentation was also rushed so i'm sorry.
<h2>basics</h2>
"stackwheel" is a functional programming language based on two "wheels" and an accumulator. The acc, which we will call layer 1 from now on, stores a single int value and is the main i/o for the language. Then, you have layer 2, a wheel comprised of 16 integers. These will be used as storage but most importantly as the operators for math. Finally layer 3, a wheel of 16 stacks, for data storage.
<h2>commands</h2>
<table>
  <tr>
  <th>commands</th>
  <th>purpose</th>
  </tr>
  <tr>
  <td>>2></td>
  <td>this will rotate the second layer by 1 slot. you can replace the "2" with a "3" and the "<"'s with ">" and the command will change layer or direction</td>
  </tr>
    <tr>
  <td>ADD, SUB, MUL, DIV, MOD</td>
  <td>these will perform the corresponding operation  on the acc and the selected item in layer 2 (selected being always the first, the rotate commands will simply shift the whole wheel over) and store the value in acc. The operations are, respectively, addition, subtraction, multiplication, division and modulo.</td>
  </tr>
    <tr>
  <td>>2></td>
  <td>this will rotate the second layer by 1 slot. you can replace the "2" with a "3" and the "<"'s with ">" and the command will change layer or direction</td>
  </tr>
</table>
