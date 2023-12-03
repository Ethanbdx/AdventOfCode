import { readFileSync } from "fs";
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

export const instructions = readFileSync("day5.txt", {
  encoding: "utf8",
})
  .split("\r\n")
  .map((line) => {
    const numbers = line.match(/\d+/gm);
    const quantity = parseInt(numbers[0]);
    const from = parseInt(numbers[1]) - 1;
    const to = parseInt(numbers[2]) - 1;

    return [quantity, from, to];
  });

instructions.forEach(([quantity, from, to]) => {
  moveItems(quantity, from, to);
});

initialStack.forEach((x) => {
  //console.log(x.pop());
});

function moveItems(quantity: number, fromIndex: number, toIndex: number) {
  while (quantity > 0) {
    const numberToMove = initialStack[fromIndex].pop();
    initialStack[toIndex].push(numberToMove);

    quantity--;
  }
}
