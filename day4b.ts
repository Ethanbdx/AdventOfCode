import { readFileSync } from "fs";

const pairLines = readFileSync("day4.txt", { encoding: "utf8" }).split("\r\n");

let countOfOverlappingPairs = 0;

pairLines.forEach((x) => {
  const [firstRange, secondRange] = x.split(",");
  if (doesOverlap(firstRange, secondRange)) {
    countOfOverlappingPairs += 1;
  }
});

console.log(countOfOverlappingPairs);

function doesOverlap(firstRange: string, secondRange: string): boolean {
  const [min1, max1] = firstRange.split("-");
  const [min2, max2] = secondRange.split("-");
  return parseInt(max1) >= parseInt(min2) && parseInt(max2) >= parseInt(min1);
}
