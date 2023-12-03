import { readFileSync } from "fs";

const pairLines = readFileSync("day4.txt", { encoding: "utf8" }).split("\r\n");

let countOfPairsFullyContained = 0;

pairLines.forEach((x) => {
  const [firstRange, secondRange] = x.split(",");
  if (isRangeFullyContained(firstRange, secondRange)) {
    countOfPairsFullyContained++;
  }
});

console.log(countOfPairsFullyContained);

function isRangeFullyContained(
  firstRange: string,
  secondRange: string
): boolean {
  const [min1, max1] = firstRange.split("-");
  const [min2, max2] = secondRange.split("-");
  const isRange1Contained =
    parseInt(min1) >= parseInt(min2) && parseInt(max1) <= parseInt(max2);
  const isRange2Contained =
    parseInt(min2) >= parseInt(min1) && parseInt(max2) <= parseInt(max1);
  return isRange1Contained || isRange2Contained;
}
