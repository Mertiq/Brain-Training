
### Randomly Puzzle Initalizing Process

   1- Randomly choose an operator for 1st operation.
   2- Randomly choose a left operand for 1st operation.
    - If operator of the operation is 'x' or '/' or '-',
      - If operator == 'x' -> then left operand most be lower than 10. 
      - If operator == '/' -> then left operand most be in range of 40 -90
      - If operator == '-' --> then left operand most be in range of 5 - 90
   3- Randomly choose a right operand for 1st operation.
    - If operator of the operation is 'x' or '/' or '-'
        - If operator == 'x' then right operand most be lower than 10
        - If operator == '/' then right operand most be sub multiplier of left operand including the left operand value.
        - If operator == '-' then right operand most be lower then left operand.
   4- Calculate the result
    6 / 2 3
    -   - 
    - - - -
    -   -  
   5- Do same point from 1 to 4 for 4th operation.
        6 / 2 3
        -   - 
        3 + 5 8
        -   -  
   6- Then look at 3rd operation. You will see that the operands are already placed. So do the steps;
     6.1-Choose the operator
        -You can use "+" operation everywhere without condition.
        -If right operand is little than left operand you can use "-" operation,
        -If right operand is submultiplier of left operand you can use "/" operation,
        -If left operand * right operand < 100 you can use "x" operation
     6.2- Calculate the result
        6 / 2 3
        %   - 
        3 + 5 8
        2   -  
   7- Then look at 4th operation. You will see operand are already placed. So do the steps same with process 6.
        6 / 2  3
        %   x 
        3 + 5  8
        2   10  
    
    8- Now all of this values is hidden, we do not set the text of the related uı elements. Because this is a puzzle. We
    need to just show results, operators and one randomly chosen operand.


### Process of Guessing The Numbers For Puzzle

    1- We will take all of the operands, except one chosen operand which user will see on screen. We create draggable buttons for every operand.And text of the buttons will be the actual numbers.
    2- When user drags one of the buttons to the empty operand slot, we set the guessed value of the operand slot with dragged buttons' value.
    3- User need to place all 3 operand to the puzzle to be able to finish level.

### Process Of Control Guesses Of User

    1-We look at 3 operands user placed on puzzle. If the guess value of the operand != their actual value -> the operand will be red or sth. to show it is wrong.
    2-Then If user hits restart all the process start again.