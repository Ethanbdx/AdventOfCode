import { readFileSync } from "fs";

// Read and split lines from .txt file
const backpackLines = readFileSync("day3.txt", { encoding: "utf8" }).split(
  "\r\n"
);

let sumOfAll = 0;

backpackLines.forEach((x) => {
  const firstSection = x.slice(0, x.length / 2);
  const secondSection = x.slice(x.length / 2);

  const commonChar = findCommonCharacter(firstSection, secondSection);
  sumOfAll += determineValue(commonChar);
});

console.log(sumOfAll);

function findCommonCharacter(
  firstSection: string,
  secondSection: string
): string {
  const firstSectionSet = new Set();

  for (let i = 0; i < firstSection.length; i++) {
    const char = firstSection[i];
    if (!firstSectionSet.has(char)) {
      firstSectionSet.add(char);
    }
  }

  for (let i = 0; i < secondSection.length; i++) {
    const char = secondSection[i];
    if (firstSectionSet.has(char)) {
      return char;
    }
  }

  throw "No common character found";
}

export function determineValue(char: string): number {
  const asciiValue = char.charCodeAt(0);

  //Is Lower Case
  if (asciiValue - 91 > 0) {
    return asciiValue - 96;
  } else {
    return asciiValue - 38;
  }
}
