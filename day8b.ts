import { readFileSync } from "fs";

const grid: number[][] = [];

readFileSync("day8.txt", { encoding: "utf8" })
  .split("\r\n")
  .forEach((x) => grid.push(x.split("").map((x) => parseInt(x))));

let maxScenicScore = 0;

for (let i = 0; i < grid.length; i++) {
  for (let j = 0; j < grid[i].length; j++) {
    let score = determineScenicScore(i, j);
    if (score > maxScenicScore) {
      maxScenicScore = score;
    }
  }
}

console.log(maxScenicScore);

function determineScenicScore(row: number, column: number): number {
  const node = grid[row][column];

  if (
    row === 0 ||
    row === grid.length - 1 ||
    column === 0 ||
    column === grid[column].length - 1
  ) {
    return 0;
  }

  const topValues: number[] = [];
  const bottomValues: number[] = [];
  const rightValues: number[] = [];
  const leftValues: number[] = [];

  for (let i = row; i > 0; i--) {
    topValues.push(grid[i - 1][column]);
    if (node <= grid[i - 1][column]) {
      break;
    }
  }

  for (let i = row + 1; i < grid.length; i++) {
    bottomValues.push(grid[i][column]);
    if (node <= grid[i][column]) {
      break;
    }
  }

  for (let i = column; i > 0; i--) {
    leftValues.push(grid[row][i - 1]);
    if (node <= grid[row][i - 1]) {
      break;
    }
  }

  for (let i = column; i < grid[row].length - 1; i++) {
    rightValues.push(grid[row][i + 1]);
    if (node <= grid[row][i + 1]) {
      break;
    }
  }

  if (row === 1 && column === 2) {
    console.log("Node", node);
    console.log("Top Val/Vis", topValues, topValues.length);
    console.log("Bottom Val/Vis", bottomValues, bottomValues.length);
    console.log("Right Val/Vis", rightValues, rightValues.length);
    console.log("Left Val/Vis", leftValues, leftValues.length);
  }

  return (
    topValues.length *
    bottomValues.length *
    rightValues.length *
    leftValues.length
  );
}
