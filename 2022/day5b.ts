import { instructions } from "./day5a";

//                         [Z] [W] [Z]
//         [D] [M]         [L] [P] [G]
//     [S] [N] [R]         [S] [F] [N]
//     [N] [J] [W]     [J] [F] [D] [F]
// [N] [H] [G] [J]     [H] [Q] [H] [P]
// [V] [J] [T] [F] [H] [Z] [R] [L] [M]
// [C] [M] [C] [D] [F] [T] [P] [S] [S]
// [S] [Z] [M] [T] [P] [C] [D] [C] [D]
//  0   1   2   3   4   5   6   7   8

const initialStack = [
  ["S", "C", "V", "N"],
  ["Z", "M", "J", "H", "N", "S"],
  ["M", "C", "T", "G", "J", "N", "D"],
  ["T", "D", "F", "J", "W", "R", "M"],
  ["P", "F", "H"],
  ["C", "T", "Z", "H", "J"],
  ["D", "P", "R", "Q", "F", "S", "L", "Z"],
  ["C", "S", "L", "H", "D", "F", "P", "W"],
  ["D", "S", "M", "P", "F", "N", "G", "Z"],
];

instructions.forEach(([quantity, from, to]) => {
  const valuesToMove = initialStack[from].splice(
    initialStack[from].length - quantity,
    quantity
  );
  console.log(valuesToMove);
  initialStack[to].push(...valuesToMove);
});

initialStack.forEach((x) => {
  console.log(x.pop());
});
