import { readFileSync } from "fs";

const grid: number[][] = [];

readFileSync("day8.txt", { encoding: "utf8" })
  .split("\r\n")
  .forEach((x) => grid.push(x.split("").map((x) => parseInt(x))));

let numberOfTreesVisible = 0;

for (let i = 0; i < grid.length; i++) {
  for (let j = 0; j < grid[i].length; j++) {
    if (determineIfTreeIsVisible(i, j)) {
      numberOfTreesVisible += 1;
    }
  }
}

console.log(numberOfTreesVisible);

function determineIfTreeIsVisible(row: number, column: number): boolean {
  const node = grid[row][column];

  if (row === 0 || row === grid.length - 1) {
    return true;
  }

  if (column === 0 || column === grid[row].length - 1) {
    return true;
  }

  const topValues: number[] = [];
  const bottomValues: number[] = [];
  const rightValues: number[] = [];
  const leftValues: number[] = [];

  for (let i = row; i > 0; i--) {
    topValues.push(grid[i - 1][column]);
  }

  for (let i = row + 1; i < grid.length; i++) {
    bottomValues.push(grid[i][column]);
  }

  for (let i = column; i > 0; i--) {
    leftValues.push(grid[row][i - 1]);
  }

  for (let i = column; i < grid[row].length - 1; i++) {
    rightValues.push(grid[row][i + 1]);
  }

  return (
    Math.max(...topValues) < node ||
    Math.max(...bottomValues) < node ||
    Math.max(...rightValues) < node ||
    Math.max(...leftValues) < node
  );
}
