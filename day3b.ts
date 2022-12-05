import { determineValue } from "./day3a";
import { readFileSync } from "fs";

const backpackLines = readFileSync("day3.txt", { encoding: "utf8" }).split(
  "\r\n"
);

let sum = 0;

for (let i = 0; i < backpackLines.length; i += 3) {
  const commonChar = findCommonCharacter(
    backpackLines[i],
    backpackLines[i + 1],
    backpackLines[i + 2]
  );
  sum += determineValue(commonChar);
}

console.log(sum);

function findCommonCharacter(
  firstLine: string,
  secondLine: string,
  thirdLine: string
): string {
  for (let i = 0; i < firstLine.length; i++) {
    if (secondLine.includes(firstLine[i]) && thirdLine.includes(firstLine[i])) {
      return firstLine[i];
    }
  }
}
